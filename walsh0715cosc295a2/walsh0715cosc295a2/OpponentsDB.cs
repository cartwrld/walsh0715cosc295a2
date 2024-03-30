using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using walsh0715cosc295a2;

namespace walsh0715cosc295a2.db
{
    public partial class OpponentsDB
    {
        readonly SQLiteConnection database;
        public OpponentsDB(string dbPath)
        {
            database = new SQLiteConnection(dbPath);

            database.CreateTable<Opponent>();

            if (database.Table<Opponent>().Count() == 0)    // Table<> returns a collection we can do further operations on, like Count or Where
            {
                // configure and save a new purchase
                Opponent opp0 = new Opponent { FirstName = "Brett", LastName = "Slobs", Address = "123 Wallaby Way", Phone = "123-456-7890", Email = "brett@slobs.net" };
                Opponent opp = new Opponent { FirstName = "Cartavious", LastName = "Walsh", Address = "263 Weyakwin Drive", Phone = "123-294-8332", Email = "cart@cart.com"};
                Opponent opp2 = new Opponent { FirstName = "Alex", LastName = "Smith", Address = "456 Crescent Moon Drive", Phone = "321-654-0987", Email = "alex@smith.com" };
                Opponent opp3 = new Opponent { FirstName = "Jamie", LastName = "Rivera", Address = "789 Sunset Boulevard", Phone = "654-321-5678", Email = "jamie@rivera.com" };
                Opponent opp4 = new Opponent { FirstName = "Taylor", LastName = "Zinkleton", Address = "123 Starry Lane", Phone = "987-654-3210", Email = "taylor@jordan.com" };
                Opponent opp5 = new Opponent { FirstName = "Casey", LastName = "Kimushu", Address = "321 Lunar Valley", Phone = "567-890-1234", Email = "casey@kim.com" };
                Opponent opp6 = new Opponent { FirstName = "Jordan", LastName = "Lee", Address = "654 Solar Ridge", Phone = "890-567-4567", Email = "jordan@lee.com" };

                SaveOpponent(opp0);
                SaveOpponent(opp);
                SaveOpponent(opp2);
                SaveOpponent(opp3);
                SaveOpponent(opp4);
                SaveOpponent(opp5);
                SaveOpponent(opp6);
            }
        }

        public void ResetOpponentsDB()
        {
            database.Query<Opponent>("DELETE FROM [Opponent]");
        }

        public int SaveOpponent(Opponent opp)
        {
            if (opp.ID != 0)
            {
                return database.Update(opp);   // perform an update on the associated record
            }
            else
            {
                return database.Insert(opp);   // returns primary key that was generated
            }
        }
        public int DeleteOpponent(Opponent opp)
        {
            return database.Delete(opp);
        }
        public List<Opponent> GetOpponents()
        {
            return database.Table<Opponent>().ToList();
        }
        public Opponent GetOpponent(int id)
        {
            return database.Table<Opponent>().Where(i => i.ID == id).FirstOrDefault();
        }
    }
}

