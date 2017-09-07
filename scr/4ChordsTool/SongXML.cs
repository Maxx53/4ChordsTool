using System.Collections.Generic;
using System.Xml.Serialization;

namespace _4ChordsTool
{
    [XmlRoot("xml")]
    public class SongXML
    {
        [XmlElement("song")]
        public SongObject Song { get; set; }

        public class SongObject
        {
            [XmlElement("metadata")]
            public MetaDataObject MetaData { get; set; }

            [XmlElement("starttime")]
            public int StartTime { get; set; }

            [XmlElement("tempos")]
            public TemposObject Tempos { get; set; }

            [XmlElement("timesignatures")]
            public SignaturesObject TimeSignatures { get; set; }

            [XmlElement("strumid")]
            public string StrumId { get; set; }

            [XmlElement("samplepack")]
            public string SamplePack { get; set; }

            [XmlElement("chords")]
            public string Chords { get; set; }

            [XmlElement("lyrics")]
            public string Lyrics { get; set; }

            [XmlElement("melody")]
            public string Melody { get; set; }

            [XmlElement("bass")]
            public string Bass { get; set; }

            [XmlElement("hihats")]
            public string Hihats { get; set; }

            [XmlElement("snares")]
            public string Snares { get; set; }

            [XmlElement("claps")]
            public string Claps { get; set; }
        }

        public class MetaDataObject
        {
            [XmlElement("artist")]
            public string ArtistName { get; set; }
            [XmlElement("title")]
            public string TitleName { get; set; }
            [XmlElement("songid")]
            public string SongId { get; set; }
        }

        public class TemposObject
        {
            [XmlElement("tempo")]
            public List<Tempo> TempoList { get; set; }
        }

        public class Tempo
        {
            [XmlElement("bpm")]
            public int BPM { get; set; }
            [XmlElement("beats")]
            public int Beats { get; set; }
        }

        public class SignaturesObject
        {
            [XmlElement("timesignature")]
            public List<Signature> SignatureList { get; set; }
        }

        public class Signature
        {
            [XmlElement("ts")]
            public int Ts { get; set; }
            [XmlElement("beats")]
            public int Beats { get; set; }
        }
    }
}
