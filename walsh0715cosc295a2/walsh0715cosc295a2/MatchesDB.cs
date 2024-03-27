using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace walsh0715cosc295a2
{
    public class MatchesDB
    {
        readonly SQLiteConnection database;
        public MatchesDB(string dbPath)
        {
            database = new SQLiteConnection(dbPath);

            database.CreateTable<Match>();


            if (database.Table<Match>().Count() == 0)    // Table<> returns a collection we can do further operations on, like Count or Where
            {
                // configure and save a new purchase
                Match match0 = new Match { OppID = 1, Date = DateTime.Now.AddDays(1), Comments = "EZ Clap", GameID = 1, Win = true };
                Match match = new Match { OppID = 2, Date = DateTime.Now, Comments = "Good game friendo", GameID = 2, Win = true };
                Match match2 = new Match { OppID = 1, Date = DateTime.Now.AddDays(-1), Comments = "Tough competition!", GameID = 3, Win = false };
                Match match3 = new Match { OppID = 3, Date = DateTime.Now.AddDays(-2), Comments = "Close call, but managed to win!", GameID = 4, Win = true };
                Match match4 = new Match { OppID = 1, Date = DateTime.Now.AddDays(-3), Comments = "Dominating victory!", GameID = 1, Win = true };
                Match match5 = new Match { OppID = 2, Date = DateTime.Now.AddDays(-4), Comments = "Lost, but learned a lot.", GameID = 1, Win = false };
                Match match6 = new Match { OppID = 1, Date = DateTime.Now.AddDays(-5), Comments = "Had a great time, good game.", GameID = 5, Win = true };

                SaveMatch(match0);
                SaveMatch(match);
                SaveMatch(match2);
                SaveMatch(match3);
                SaveMatch(match4);
                SaveMatch(match5);
                SaveMatch(match6);
            }
        }

        public int SaveMatch(Match match)
        {
            if (match.ID != 0)
            {
                return database.Update(match);   // perform an update on the associated record
            }
            else
            {
                return database.Insert(match);   // returns primary key that was generated
            }
        }
        public int DeleteMatch(Match match)
        {
            return database.Delete(match);
        }
        public List<Match> GetMatches()
        {
            return database.Table<Match>().ToList();
        }
        public Match GetMatch(int id)
        {
            return database.Table<Match>().Where(i => i.ID == id).FirstOrDefault();  // 
        }
        public List<Match> GetMatchesByID(int id)
        {
            return database.Query<Match>("SELECT * FROM [Match] WHERE [OppID] = " + id);    // returns a regular list
        }


    }
}
