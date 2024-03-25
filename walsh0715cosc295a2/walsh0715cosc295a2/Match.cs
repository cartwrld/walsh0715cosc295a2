using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace walsh0715cosc295a2
{
    public class Match
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public int OppID { get; set; }
        public DateTime Date { get; set; }
        public string Comments { get; set; }
        public int GameID { get; set; }
        public bool Win { get; set; }


    }
}
