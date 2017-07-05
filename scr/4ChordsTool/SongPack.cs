using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _4ChordsTool
{
    [XmlRoot("catalog")]
    public class SongPack
    {

        [XmlElement("category")]
        public CategoryInfo MetaData { get; set; }

        public class CategoryInfo
        {
            [XmlAttribute]
            public string name { get; set; }

            [XmlAttribute]
            public string type { get; set; }

            [XmlElement("song")]
            public List<SongInfo> songs { get; set; }
        }

        public class SongInfo
        {
            [XmlAttribute]
            public string songid { get; set; }

            [XmlElement("title")]
            public string TitleName { get; set; }

            [XmlElement("artist")]
            public string ArtistName { get; set; }

            [XmlElement("downloadUrl")]
            public string SongFile { get; set; }

            [XmlElement("chords")]
            public ChordsInfo chords { get; set; }
        }

        public class ChordsInfo
        {
            [XmlElement("chord")]
            public List<string> chord { get; set; }
        }


        }
}
