using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace walsh0715cosc295a2
{
    public class Opponent
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
