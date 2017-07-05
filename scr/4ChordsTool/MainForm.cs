using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace _4ChordsTool
{
    public partial class MainForm : Form
    {
        const string cmdParam = "-quit -batchmode -projectPath {0} -executeMethod ExportAssetBundles.ExportResource";
        static string projectPath = Application.StartupPath + @"\BuildAssetBundle\";
        static string assetsPath = projectPath + "Assets";
        static string resultPath = assetsPath + @"\Result\";

        private Properties.Settings settings = Properties.Settings.Default;
        public BackgroundWorker waitingThread = new BackgroundWorker();


        public MainForm()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.tool;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            waitingThread.WorkerSupportsCancellation = true;
            waitingThread.DoWork += waitingThread_DoWork;
            waitingThread.RunWorkerCompleted += waitingThread_RunWorkerCompleted;

            gamePathTextBox.Text = settings.gamePath;
            unityPathTextBox.Text = settings.unityPath;
            sPathTextBox.Text = settings.lastPath;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            settings.gamePath = gamePathTextBox.Text;
            settings.unityPath = unityPathTextBox.Text;
            settings.lastPath = sPathTextBox.Text;
            settings.Save();
        }


        private void browseSongsPath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                sPathTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void browseUnityButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                unityPathTextBox.Text = openFileDialog1.FileName;

            }
        }

        private void browseGameButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                gamePathTextBox.Text = folderBrowserDialog1.SelectedPath;
            }

        }

        private static bool MakeSongPack(string packName, string filesPath)
        {
            var songPack = new SongPack()
            {
                MetaData = new SongPack.CategoryInfo()
                {
                    name = packName,
                    type = "offline",
                    songs = new List<SongPack.SongInfo>()
                }
            };

            if (!Directory.Exists(filesPath))
            {
                MessageBox.Show("Songs directory no exist!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            foreach (string file in Directory.EnumerateFiles(filesPath, "*.xml"))
            {
                try
                {
                    using (var content = File.OpenText(file))
                    {
                        var serializer = new XmlSerializer(typeof(SongContainer));
                        var data = (SongContainer)serializer.Deserialize(content);

                        songPack.MetaData.songs.Add(new SongPack.SongInfo()
                        {
                            songid = data.Song.MetaData.SongId,
                            ArtistName = data.Song.MetaData.ArtistName,
                            SongFile = Path.GetFileName(file),
                            TitleName = data.Song.MetaData.TitleName,
                            chords = new SongPack.ChordsInfo() { chord = Utils.GetUniqChords(data.Song.Chords) }
                        });
                    }

                }
                catch (Exception)
                {
                    continue;
                }
            }

            if (songPack.MetaData.songs.Count == 0)
            {
                MessageBox.Show("Songs not found!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                using (var sw = new StreamWriter(new FileStream(filesPath + @"\SongPack.xml", FileMode.OpenOrCreate), Encoding.UTF8))
                {
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("", "");

                    var serializer = new XmlSerializer(songPack.GetType());
                    serializer.Serialize(sw, songPack, ns);
                }

                File.WriteAllText(filesPath + @"\identifier.txt", "507290");

                //Success
                return true;
            }
        }


        private void buildDlcButton_Click(object sender, EventArgs e)
        {
            SetStatus(1, "Building DLC...");

            if (File.Exists(unityPathTextBox.Text))
            {
                if (MakeSongPack(spNameTextBox.Text, sPathTextBox.Text))
                {
                    if (waitingThread.IsBusy != true)
                    {
                        //Passing paths from textboxes
                        var paths = new Tuple<string, string>(unityPathTextBox.Text, gamePathTextBox.Text);
                        waitingThread.RunWorkerAsync(paths);
                    }
                }
                else
                {
                    MessageBox.Show("Error making SongPack!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    SetStatus(0, "Ready");
                }
            }
            else
            {
                if (MessageBox.Show("Unity not found, can't build DLC automatically!" + Environment.NewLine +
                      "Make SongPack only?" + Environment.NewLine +
                      "Note: after making SongPack, you must build an asset bundle (DLC) throught Unity manually.", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (MakeSongPack(spNameTextBox.Text, sPathTextBox.Text))
                        MessageBox.Show("SongPack generated successfully and placed to your songs path.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Error making SongPack!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }

                SetStatus(0, "Ready");
            }
        }

        private void waitingThread_DoWork(object sender, DoWorkEventArgs e)
        {
            //Setting paths
            var paths = (e.Argument as Tuple<string, string>);
            var unityPath = paths.Item1;
            var gamePath = paths.Item2;


            //Clean before copying
            Utils.RemoveFiles(assetsPath);
            Utils.RemoveFiles(resultPath);

            Utils.CopyFiles(sPathTextBox.Text, assetsPath);

            //Leave dlc name to Unity script
            var name = Utils.NamingDLC(spNameTextBox.Text);
            File.WriteAllText(resultPath + "DLCname.txt", name);

            //Run Unity in batch mode
            Utils.StartCmdLine(unityPath, string.Format(cmdParam, projectPath), true);

            var dlcFile = resultPath + name;

            if (File.Exists(dlcFile))
            {
                //Copy result DLC to game path
                var destFileResult = gamePath + @"\DLC\" + name;
                File.Copy(dlcFile, destFileResult, true);
                File.SetAttributes(destFileResult, FileAttributes.Normal);

                e.Result = true;
            }
            else
                e.Result = false;

            //Clean after work
            Utils.RemoveFiles(assetsPath);
            Utils.RemoveFiles(resultPath);
        }

        private void waitingThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SetStatus(0, "Ready");

            if ((bool)e.Result)
                MessageBox.Show("DLC was built and placed to game folder!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Something was wrong!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SetStatus(int status, string text)
        {
            switch (status)
            {
                case 0:
                    statusLabel.Image = Properties.Resources.ready;
                    break;
                case 1:
                    statusLabel.Image = Properties.Resources.working;
                    break;

                default:
                    break;
            }
            statusLabel.Text = text;
        }

    }

}
