using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace HebNavi
{
    public class AlphabetTable
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public bool IsConsonant { get; set; }
        public string Character { get; set; }
        public string Name { get; set; }
        public string Pronunciation { get; set; }
        public string CharacterAudio { get; set; }
        public string NameAudio { get; set; }
        public string PronunciationAudio { get; set; }
        public bool isGuttural { get; set; }
    }
}
