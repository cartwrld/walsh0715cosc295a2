using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace walsh0715cosc295a2
{
    public class GamesDB
    {
        readonly SQLiteConnection database;

        public GamesDB(string dbPath)
        {
            database = new SQLiteConnection(dbPath);

            database.CreateTable<Game>();


            if (database.Table<Game>().Count() == 0)    // Table<> returns a collection we can do further operations on, like Count or Where
            {
                // configure and save a new purchase
                Game game = new Game { GameName = "Overwatch", Description = "Hanamura", Rating = 9.5 };
                Game game2 = new Game { GameName = "Shadow Quest", Description = "Explore ancient ruins and battle dark creatures.", Rating = 8.7 };
                Game game3 = new Game { GameName = "Mystic Lands", Description = "A world full of magic, mysteries, and adventures awaits.", Rating = 9.0 };
                Game game4 = new Game { GameName = "Cyber Sprint", Description = "A fast-paced race through a dystopian future.", Rating = 8.3 };
                Game game5 = new Game { GameName = "Galactic Battles", Description = "Lead your fleet to victory in epic space wars.", Rating = 9.2 };
                Game game6 = new Game { GameName = "Fantasy Kingdoms", Description = "Build and rule your kingdom in a land of dragons and knights.", Rating = 8.5 };


                SaveGame(game);
                SaveGame(game2);
                SaveGame(game3);
                SaveGame(game4);
                SaveGame(game5);
                SaveGame(game6);
            }
        }

        public int SaveGame(Game game)
        {
            if (game.ID != 0)
            {
                return database.Update(game);   // perform an update on the associated record
            }
            else
            {
                return database.Insert(game);   // returns primary key that was generated
            }
        }
        public int DeleteGame(Game game)
        {
            return database.Delete(game);
        }
        public List<Game> GetGames()
        {
            return database.Table<Game>().ToList();
        }
  
        public Game GetGame(int id)
        {
            return database.Table<Game>().Where(i => i.ID == id).FirstOrDefault();  // 
        }

    }
}
