using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4ChordsTool
{
    public class SongBeat: INotifyPropertyChanged
    {
        public SongBeat()
        {
            Chords = new string[16];
            Melody = new Pitch[16];

            for (int i = 0; i < 16; i++)
            {
                Melody[i] = Pitch.None;

            }


            Bass = new bool[16];
            Hihats = new bool[16];
            Snares = new bool[16];
            Claps = new bool[16];
        }


        private string _lirycs;
        public string Lirycs
        {
            get
            {
                return this._lirycs;
            }

            set
            {
                if (value != this._lirycs)
                {
                    this._lirycs = value;
                    NotifyPropertyChanged();
                }
            }
        }


        public string[] Chords { get; set; }
        public bool[] Bass { get; set; }
        public bool[] Hihats { get; set; }
        public bool[] Snares { get; set; }
        public bool[] Claps { get; set; }
        public Pitch[] Melody { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }


    public class SongLoader : BindingList<SongBeat>
    {
        public int NoteDuration { get; set; }


        private int _bpm;
        public int BPM
        {
            get
            {
                return this._bpm;
            }

            set
            {
                if (value != this._bpm)
                {
                    this._bpm = value;
                    NoteDuration = (int)(15000f / (float)_bpm);
                    //NotifyPropertyChanged();
                }
            }
        }


        public void LoadLirycs(string[] content)
        {
            foreach (var lyricString in content)
            {
                this.Add(new SongBeat() { Lirycs = lyricString });
            }
        }


        public void LoadMidi(List<string> chords, List<Pitch> melody, List<bool> snares, List<bool> hihats, int tempo)
        {
            BPM = tempo;

            for (int i = 0; i < snares.Count; i += 16)
            {
                var chordBeat = chords.GetRange(i, Math.Min(16, chords.Count - i)).ToArray();
                var melodyBeat = melody.GetRange(i, Math.Min(16, melody.Count - i)).ToArray();
                var snaresBeat = snares.GetRange(i, Math.Min(16, snares.Count - i)).ToArray();
                var hihatsBeat = hihats.GetRange(i, Math.Min(16, hihats.Count - i)).ToArray();
                this.Add(new SongBeat() { Chords = chordBeat, Melody = melodyBeat, Hihats = hihatsBeat, Snares = snaresBeat, Claps = snaresBeat });
            }
        }

        public void LoadSong(SongXML data)
        {
            BPM = data.Song.Tempos.TempoList[0].BPM;

            // float msByBeat = (60000f / BPM) * 4f;
            // float noteDuration = msByBeat / 16f;

            NoteDuration = (int)(15000f / (float)BPM);


            var beatCount = data.Song.Tempos.TempoList[0].Beats;

            var melodyBeats = data.Song.Melody.Split(',');
            var chordBeats = data.Song.Chords.Split(',');
            var bassBeats = data.Song.Bass.Split(',');
            var hitHatsBeats = data.Song.Hihats.Split(',');
            var snaresBeats = data.Song.Snares.Split(',');
            var clapsBeats = data.Song.Claps.Split(',');

            var lirycs = data.Song.Lyrics.Split(new[] { '\r', '\n' });

            for (int k = 0; k < beatCount; k++)
            {
                var melodyNotes = melodyBeats[k].Split(' ');
                var chordNotes = chordBeats[k].Split(' ');
                var bassNotes = bassBeats[k].Split(' ');
                var hitHatsNotes = hitHatsBeats[k].Split(' ');
                var snaresNotes = snaresBeats[k].Split(' ');
                var clapsNotes = clapsBeats[k].Split(' ');

                var Beat = new SongBeat();

                if (k < lirycs.Length - 1)
                    Beat.Lirycs = lirycs[k + 1].Replace("|", string.Empty).Replace(@"\", string.Empty).Trim();


                var scale = Beat.Melody.Length / melodyNotes.Length;

                for (int i = 0; i < melodyNotes.Length; i++)
                {
                    var curNote = melodyNotes[i].Trim();

                    if (curNote == string.Empty)
                    {
                        Beat.Melody[i * scale] = Pitch.None;
                    }
                    else
                        Beat.Melody[i * scale] = ((Pitch)Enum.Parse(typeof(Pitch), curNote));
                }


                scale = Beat.Chords.Length / chordNotes.Length;

                for (int i = 0; i < chordNotes.Length; i++)
                {
                    var curNote = chordNotes[i].Trim();

                    if (curNote == string.Empty)
                    {
                        continue;
                    }

                    Beat.Chords[i* scale] = curNote;
                }


                scale = Beat.Bass.Length / bassNotes.Length ;
                for (int i = 0; i < bassNotes.Length; i++)
                {
                    var curNote = bassNotes[i].Trim();

                    if (curNote == string.Empty)
                    {
                        continue;
                    }

                    Beat.Bass[i * scale] = (curNote == "1");
                }


                scale = Beat.Hihats.Length / hitHatsNotes.Length;
                for (int i = 0; i < hitHatsNotes.Length; i++)
                {
                    var curNote = hitHatsNotes[i].Trim();

                    if (curNote == string.Empty)
                    {
                        continue;
                    }

                    Beat.Hihats[i * scale] = (curNote == "1");
                }


                scale = Beat.Snares.Length / snaresNotes.Length;
                for (int i = 0; i < snaresNotes.Length; i++)
                {
                    var curNote = snaresNotes[i].Trim();

                    if (curNote == string.Empty)
                    {
                        continue;
                    }

                    Beat.Snares[i * scale] = (curNote == "1");
                }

                scale = Beat.Claps.Length / clapsNotes.Length;
                for (int i = 0; i < clapsNotes.Length; i++)
                {
                    var curNote = clapsNotes[i].Trim();

                    if (curNote == string.Empty)
                    {
                        continue;
                    }

                    Beat.Claps[i * scale] = (curNote == "1");
                }

                this.Add(Beat);
            }
        }


        public SongXML SaveSong(string artist, string title, string sample, string strum)
        {
            SongXML song = new SongXML();

            song.Song = new SongXML.SongObject();

            song.Song.MetaData = new SongXML.MetaDataObject()
            {
                ArtistName = artist,
                TitleName = title,
                SongId = Utils.getRandomId().ToString()
            };

            song.Song.SamplePack = sample;
            song.Song.StrumId = strum;

            song.Song.StartTime = 897;

            song.Song.Tempos = new SongXML.TemposObject()
            {
                TempoList = new List<SongXML.Tempo>() {
                    new SongXML.Tempo() {
                        BPM = this.BPM,
                        Beats = this.Count
                    }
                }
            };

            song.Song.TimeSignatures = new SongXML.SignaturesObject()
            {
                SignatureList = new List<SongXML.Signature>() {
                    new SongXML.Signature() {
                        Ts = 4,
                        Beats = this.Count
                    }
                }
            };

            string chords = string.Empty;
            string melody = string.Empty;
            string bass = string.Empty;
            string hihats = string.Empty;
            string snares = string.Empty;
            string claps = string.Empty;

            string lirycs = string.Empty;

            foreach (var beat in this)
            {
                foreach (var chord in beat.Chords)
                {
                    if (string.IsNullOrEmpty(chord)) continue;

                    chords += chord + " ";
                }

                if (chords != string.Empty)
                    chords = chords.Remove(chords.Length - 1, 1);

                chords += "," + Environment.NewLine;


                foreach (var note in beat.Melody)
                {
                    int fnote = (int)note;
                    string strnote = fnote.ToString();

                    if (fnote == 128)
                        strnote = "z";
                    else if (fnote == 129)
                        strnote = "_";
                    else if (fnote == 130)
                    {
                        continue;
                    }

                    melody += strnote + " ";
                }

                melody = melody.Remove(melody.Length - 1, 1) + "," + Environment.NewLine;


                foreach (var bassNote in beat.Bass)
                {
                    bass += Convert.ToInt32(bassNote).ToString() + " ";
                }

                bass = bass.Remove(bass.Length - 1, 1) + "," + Environment.NewLine;

                foreach (var Hihat in beat.Hihats)
                {
                    hihats += Convert.ToInt32(Hihat).ToString() + " ";
                }

                hihats = hihats.Remove(hihats.Length - 1, 1) + "," + Environment.NewLine;


                foreach (var Snare in beat.Snares)
                {
                    snares += Convert.ToInt32(Snare).ToString() + " ";
                }

                snares = snares.Remove(snares.Length - 1, 1) + "," + Environment.NewLine;

                foreach (var Clap in beat.Claps)
                {
                    claps += Convert.ToInt32(Clap).ToString() + " ";
                }

                claps = claps.Remove(claps.Length - 1, 1) + "," + Environment.NewLine;

                if (beat.Lirycs == string.Empty)
                {
                    lirycs += @"|\" + Environment.NewLine;
                }
                else
                    lirycs += string.Format(@"|{0} \{1}", beat.Lirycs, Environment.NewLine);
            }

            song.Song.Melody = melody;
            song.Song.Chords = chords;
            song.Song.Lyrics = lirycs;

            song.Song.Bass = bass;
            song.Song.Hihats = hihats;
            song.Song.Snares = snares;
            song.Song.Claps = claps;
          
            return song;
        }


    }
}
