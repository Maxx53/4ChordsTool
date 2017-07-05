using System.Xml.Serialization;

namespace _4ChordsTool
{
    [XmlRoot("xml")]
    public class SongContainer
    {
        [XmlElement("song")]
        public SongObject Song { get; set; }

        public class SongObject
        {
            [XmlElement("metadata")]
            public MetaDataObject MetaData { get; set; }

            [XmlElement("chords")]
            public string Chords { get; set; }
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
    }
}
