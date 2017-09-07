using Midi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace _4ChordsTool
{
    public partial class SongEditForm : Form
    {
        private const string steamGame = "steam://rungameid/476930";
        private string tempPath = Application.StartupPath + @"\Temp\";
        SongBeatControl ff;
        SongLoader song = new SongLoader();
        BackgroundWorker playMidiThread = new BackgroundWorker();
        string lastChord = string.Empty;
        static Pitch prevnote = Pitch.None;
        static Midi.Pitch prevBassNote;
        OutputDevice outputDevice;

        static bool StopPlay = false; 

        public SongEditForm()
        {
            InitializeComponent();
            //Для предотвращения мерцания при перерисовке

            //SetDoubleBuffered(panel1);
            DoubleBuffered = true;

            // Tell the graphical overlay that it belongs to this form.
            // This allows the component to transform the paint event's graphics object 
            // and to respond when the form is resized. 
            graphicalOverlay1.Owner = this;

            playMidiThread.WorkerSupportsCancellation = true;
            playMidiThread.DoWork += playMidiThread_DoWork;
            playMidiThread.RunWorkerCompleted += playMidiThread_RunWorkerCompleted;
        }



        private void playMidiThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            StopPlay = false;
            outputDevice.Close();
        }


        void PlayChord(string name, bool bass, OutputDevice outputDevice)
        {

            if (name != null)
            {
                //CHord _

                var strChord = name[0].ToString();

                if (name.Length > 1)
                {
                    if (name[1] == 'm')
                        strChord += name[1];
                }

                if (strChord != "_")
                {

                    lastChord = strChord;

                    var chord = new Chord(strChord);

                    Midi.Pitch previousNote = (Midi.Pitch)(-1);
                    for (Midi.Pitch pitch = Midi.Pitch.A3; pitch < Midi.Pitch.C5; ++pitch)
                    {
                        if (chord.Contains(pitch))
                        {
                            outputDevice.SendNoteOn(Channel.Channel2, pitch, 50);

                            previousNote = pitch;
                        }
                    }
                }
            }

            if (bass)
            {
                outputDevice.SendNoteOff(Channel.Channel3, prevBassNote, 80);
                prevBassNote = (Midi.Pitch)Enum.Parse(typeof(Midi.Pitch), lastChord[0] + "2");
                outputDevice.SendNoteOn(Channel.Channel3, prevBassNote, 80);

            }
        }


        private void OpenMidiDevice()
        {
            outputDevice = OutputDevice.InstalledDevices[0];
            outputDevice.Open();
            outputDevice.SendProgramChange(Channel.Channel2, Instrument.AcousticGuitarSteel);
            outputDevice.SendProgramChange(Channel.Channel1, Instrument.AcousticGrandPiano);
            outputDevice.SendProgramChange(Channel.Channel3, Instrument.ElectricBassPick);
        }

        void PlayBeat(int index, OutputDevice device)
        {
            this.panel1.Invoke((MethodInvoker)delegate { ff.LoadBeat(index);
                //lyricsListBox.SelectedIndex = index;
                lyricsDataGrid.ClearSelection();
               lyricsDataGrid.Rows[index].Selected = true;
            });

            var chords = song[index].Chords;
            var notes = song[index].Melody;
            var hihats = song[index].Hihats;
            var snares = song[index].Snares;
            var claps = song[index].Claps;

            var bass = song[index].Bass;

            for (int k = 0; k < 16; k++)
            {
                if (StopPlay) break;

                var curNote = notes[k];

                if (hihats[k])
                    device.SendPercussion((Percussion)42, 90);

                if (snares[k])
                    device.SendPercussion((Percussion)38, 90);

                if (claps[k])
                    device.SendPercussion((Percussion)39, 90);

                PlayChord(chords[k], bass[k], device);

                if (curNote != Pitch.None)
                {
                    if (curNote == Pitch.z)
                    {
                        if (prevnote != Pitch.None)
                            device.SendNoteOff(Channel.Channel1, (Midi.Pitch)prevnote, 80);
                        Thread.Sleep(song.NoteDuration);
                    }
                    else if (curNote == Pitch.None | curNote == Pitch._)
                    {
                        Thread.Sleep(song.NoteDuration);
                    }
                    else
                    {
                        if (prevnote != Pitch.None)
                            device.SendNoteOff(Channel.Channel1, (Midi.Pitch)prevnote, 80);

                        // var noteint = Convert.ToInt32(curNote);
                        device.SendNoteOn(Channel.Channel1, (Midi.Pitch)curNote, 80);

                        Thread.Sleep(song.NoteDuration);

                        prevnote = curNote;
                    }
                }
                else
                    Thread.Sleep(song.NoteDuration);

                ff.BeatProgress++;
                this.panel1.Invoke((MethodInvoker)delegate { Invalidate(true); });
            }

            ff.BeatProgress = 0;
            device.SendNoteOff(Channel.Channel3, prevBassNote, 80);
            //  device.SendNoteOff(Channel.Channel2, previousNote, 50);

        }

        void PlayAllSong(OutputDevice outputDevice, int index)
        {
            for (int i = index; i < song.Count; i++)
            {
                if (StopPlay) return;
                PlayBeat(i, outputDevice);
            }

        }

        private void playMidiThread_DoWork(object sender, DoWorkEventArgs e)
        {
            OpenMidiDevice();

            prevnote = Pitch.None;

            var beatToPlay = (int)e.Argument;

            if (beatToPlay == -1)
                PlayAllSong(outputDevice, 0);
            else
                PlayAllSong(outputDevice, beatToPlay);
        }


        private void SongEditForm_Load(object sender, EventArgs e)
        {
            ff = new SongBeatControl(panel1);

           // LoadSong(@"C:\1678.xml");
        }


        private void graphicalOverlay1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(panel1.Location.X, panel1.Location.Y);
            ff.Paint(e);
        }


        private void BindSongToLirycsBox(SongLoader sl)
        {
          //  lyricsListBox.DataSource = sl;
          //  lyricsListBox.DisplayMember = "Lirycs";

            var source = new BindingSource(sl, null);
            lyricsDataGrid.DataSource = source;
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            song[lyricsDataGrid.CurrentRow.Index].Lirycs = (sender as TextBox).Text;
        }


        private void loadSongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                LoadSong(openFileDialog1.FileName);
            }
        }

        private void LoadSong(string file)
        {
            using (var content = File.OpenText(file))
            {
                var serializer = new XmlSerializer(typeof(SongXML));
                var data = (SongXML)serializer.Deserialize(content);

                song.LoadSong(data);

                ff.Song = song;

                BindSongToLirycsBox(song);

                artistTextBox.Text = data.Song.MetaData.ArtistName;
                titleTextBox.Text = data.Song.MetaData.TitleName;

                samplePackCombo.Text = data.Song.SamplePack;
                strumIdCombo.Text = data.Song.StrumId;
                bpmNumeric.Value = data.Song.Tempos.TempoList[0].BPM;

                ff.LoadBeat(0);

            }
        }

        private void saveSongToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SaveSong(saveFileDialog1.FileName);
            }
        }

        private void SaveSong(string path)
        {
            using (var sw = new StreamWriter(new FileStream(path, FileMode.OpenOrCreate), Encoding.UTF8))
            {
                var saveSong = song.SaveSong(artistTextBox.Text, titleTextBox.Text, samplePackCombo.Text, strumIdCombo.Text);

                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");

                var serializer = new XmlSerializer(saveSong.GetType());
                serializer.Serialize(sw, saveSong, ns);
            }
        }

        private void importLyricsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] content = File.ReadAllLines(openFileDialog1.FileName);

                song.LoadLirycs(content);

                ff.Song = song;

                BindSongToLirycsBox(song);

                ff.LoadBeat(0);
            }
        }

        private void importMIDIToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{

            //    using (var content = File.OpenText(openFileDialog1.FileName))
            //    {
            //    }
            //}

            MidiReader md = new MidiReader("test.mid");
            song.LoadMidi(md.GetChords(), md.GetMelody(), md.GetSnares(), md.GetHihats(), (int)md.Tempo);
            ff.Song = song;
            BindSongToLirycsBox(song);
            ff.LoadBeat(0);
        }


        private void addBeatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            song.Insert(lyricsDataGrid.CurrentRow.Index, new SongBeat());
        }

        private void removeBeatToolStripMenuItem_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < lyricsDataGrid.SelectedCells.Count; i++)
            {
                song.RemoveAt(lyricsDataGrid.SelectedCells[i].RowIndex);
            }

           
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (playMidiThread.IsBusy != true)
            {
                playMidiThread.RunWorkerAsync(-1);
            }
        }

        private void selectedBeatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (playMidiThread.IsBusy != true)
            {
                StopPlay = false;
                playMidiThread.RunWorkerAsync(lyricsDataGrid.CurrentRow.Index);
            }
            else
                StopPlay = true;

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            song = new SongLoader();
            song.Add(new SongBeat() { Lirycs = "Привет" });

            song.BPM = 120;

            ff.Song = song;
            BindSongToLirycsBox(song);
        }

        private void lyricsDataGrid_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lyricsDataGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);

        }



      //  private Rectangle dragBoxFromMouseDown;
        private int rowIndexFromMouseDown;
        private int rowIndexOfItemUnderMouseToDrop;

        private List<SongBeat> dragBeats = new List<SongBeat>();

        private void lyricsDataGrid_MouseDown(object sender, MouseEventArgs e)
        {
            dragBeats.Clear();
            rowIndexFromMouseDown = lyricsDataGrid.HitTest(e.X, e.Y).RowIndex;

            for (int i = 0; i < lyricsDataGrid.SelectedCells.Count; i++)
            {
                dragBeats.Add(song[lyricsDataGrid.SelectedCells[i].RowIndex]);
            }

            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                DragDropEffects dropEffect = lyricsDataGrid.DoDragDrop(
                    dragBeats,
                    DragDropEffects.Move);
            }
        }



        private void lyricsDataGrid_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void lyricsDataGrid_DragDrop(object sender, DragEventArgs e)
        {
            Point clientPoint = lyricsDataGrid.PointToClient(new Point(e.X, e.Y));

            rowIndexOfItemUnderMouseToDrop =
                lyricsDataGrid.HitTest(clientPoint.X, clientPoint.Y).RowIndex;

            if (rowIndexFromMouseDown != rowIndexOfItemUnderMouseToDrop)
            {
                if (e.Effect == DragDropEffects.Move)
                {
                    foreach (var item in dragBeats)
                    {
                        song.Remove(item);
                        song.Insert(rowIndexOfItemUnderMouseToDrop, item);
                    }



                    //  foreach (var item in dragBeats)
                    //  {
                    //    lyricsDataGrid.Rows[rowIndexOfItemUnderMouseToDrop].Selected = true;
                    //  }

  
                    dragBeats.Clear();
                }
            }


        }

        private void lyricsDataGrid_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;

        }


        private void lyricsDataGrid_DragEnter(object sender, DragEventArgs e)
        {
        
        }

        private void lyricsDataGrid_MouseUp(object sender, MouseEventArgs e)
        {
        }

        private void lyricsDataGrid_SelectionChanged(object sender, EventArgs e)
        {
            if (lyricsDataGrid.SelectedCells.Count != 0)
            {
                ff.LoadBeat(lyricsDataGrid.SelectedCells[0].RowIndex);
                textBox1.Text = song[lyricsDataGrid.SelectedCells[0].RowIndex].Lirycs;
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            song[lyricsDataGrid.CurrentRow.Index].Lirycs = (sender as TextBox).Text;
        }

        private void testInGameToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SaveSong(tempPath + Utils.getRandomId() + ".xml");

            if (MainForm.MakeSongPack("Test Song", tempPath))
            {
                MainForm.InitWorker(WaitingThread_RunWorkerCompleted);

                if (MainForm.waitingThread.IsBusy != true)
                {
                    MainForm.waitingThread.RunWorkerAsync(tempPath);
                }
            }
        }

        private void WaitingThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Utils.RemoveFiles(tempPath);
            Utils.StartCmdLine(steamGame, string.Empty, false);
        }
    }
}
