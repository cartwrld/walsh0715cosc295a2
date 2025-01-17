﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using walsh0715cosc295a2;

namespace walsh0715cosc295a2.db
{
    public partial class AppDB
    {
        readonly SQLiteConnection database;
        public AppDB(string dbPath)
        {
            database = new SQLiteConnection(dbPath);

            database.CreateTable<Opponent>();
            database.CreateTable<Match>();
            database.CreateTable<Game>();

            setDefaultData();
        }

        /**
         * This method is used to reset the database. All tables will be dropped,
         * then default games will be added into the games table.
         */
        public void ResetDB()
        {
            database.Query<Opponent>("DROP TABLE [Opponent]");
            database.Query<Match>("DROP TABLE [Match]");
            database.Query<Game>("DROP TABLE [Game]");

            database.CreateTable<Opponent>();
            database.CreateTable<Match>();
            database.CreateTable<Game>();

            database.Insert(new Game { GameName = "Chess", Description = "Simple grid game", Rating = 9.5 });
            database.Insert(new Game { GameName = "Checkers", Description = "Simpler grid game", Rating = 5 });
            database.Insert(new Game { GameName = "Dominoes", Description = "Blocks game", Rating = 6.75 });
        }

        // ========== Opponent Database Actions ==========

        /**
         * This method is responsible for saving an opponent to the database
         */
        public int SaveOpponent(Opponent opp)
        {
            return database.Insert(opp);   // returns primary key that was generated
        }

        /**
         * This methood is responsible for deleing an opponent from the database
         */
        public int DeleteOpponent(Opponent opp)
        {
            return database.Delete(opp);
        }

        /**
         * This method returns full name of the opponent that corresponds
         * with the Opponent ID passed in
         */
        public string GetOpponentName(int id)
        {
            Opponent o = (database.Query<Opponent>("SELECT * FROM [Opponent] WHERE [ID] = " + id)).ElementAt(0);
            return $"{o.FirstName} { o.LastName}";
        }

        /**
         * This method returns a list of all Opponents in the database
         */
        public List<Opponent> GetOpponents()
        {
            return database.Table<Opponent>().ToList();
        }

        // ========== Match Database Actions ==========

        /**
         * This function takes in a Match, and updates it if it has an ID,
         * and creates if if not
         */
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

        /**
         * This function takes in a match and deletes it from the database
         */
        public int DeleteMatch(Match match)
        {
            return database.Delete(match);
        }

        /**
         * This method deletes all of the matches that correspond with the specified
         * Opponent ID
         */
        public List<Match> DeleteMatchesByOppID(int oppID)
        {
            return database.Query<Match>("DELETE FROM [Match] WHERE [OppID] = " + oppID);    // returns a regular list
        }

        /**
         * This method returns a list of matches that correspond with the specified 
         * Opponent ID
         */
        public List<Match> GetMatchesByID(int id)
        {
            return database.Query<Match>("SELECT * FROM [Match] WHERE [OppID] = " + id);    // returns a regular list
        }

        /**
         * This method returns a count of how many matches exist for the specified
         * game ID
         */
        public int CountByGame(int gameID)
        {
            return database.ExecuteScalar<int>("SELECT COUNT(*) FROM [Match] WHERE [GameID] = ?", gameID);
        }

        // ========== Game Database Actions ==========

        /**
         * This method saves the spcified game to the database
         */
        public int SaveGame(Game game)
        {
            return database.Insert(game);
        }

        /**
         * This method deletes the specified game from the database
         */
        public int DeleteGame(Game game)
        {
            return database.Delete(game);
        }

        /**
         * This method returns a list of games from the database
         */
        public List<Game> GetGames()
        {
            return database.Table<Game>().ToList();
        }

        /**
         * This method returns a specific game based on the specified
         * Game ID
         */
        public Game GetGame(int id)
        {
            return database.Table<Game>().Where(i => i.ID == id).FirstOrDefault(); 
        }

        public List<string> GetGameNames()
        {
            List<Game> games = GetGames();
            return games.Select(g => g.GameName).ToList();
        }

        /**
         * This method returns the GameID of the game that corresponds
         * with the specified GameName
         */
        public int GetGameIDByName(string gameName)
        {
            return (database.Table<Game>().Where(i => i.GameName == gameName)).ElementAt(0).ID;
        }

        /**
         * This function is used to set default test data
         */
        public void setDefaultData()
        {   
            if (database.Table<Opponent>().Count() == 0)  
            {
                //SaveOpponent(new Opponent { FirstName = "Brett", LastName = "Slobs", Address = "123 Wallaby Way", Phone = "1(123)456-7890", Email = "brett@slobs.net" });
                //SaveOpponent(new Opponent { FirstName = "Cartavious", LastName = "Walsh", Address = "263 Weyakwin Drive", Phone = "1-123-294-8332", Email = "cart@cart.com" });
                //SaveOpponent(new Opponent { FirstName = "Alex", LastName = "Smith", Address = "456 Crescent Moon Drive", Phone = "321-654-0987", Email = "alex@smith.com" });
                //SaveOpponent(new Opponent { FirstName = "Jamie", LastName = "Rivera", Address = "789 Sunset Boulevard", Phone = "654-321-5678", Email = "jamie@rivera.com" });
                //SaveOpponent(new Opponent { FirstName = "Taylor", LastName = "Zinkleton", Address = "123 Starry Lane", Phone = "987-654-3210", Email = "taylor@jordan.com" });
                //SaveOpponent(new Opponent { FirstName = "Casey", LastName = "Kimushu", Address = "321 Lunar Valley", Phone = "567-890-1234", Email = "casey@kim.com" });
                //SaveOpponent(new Opponent { FirstName = "Jordan", LastName = "Lee", Address = "654 Solar Ridge", Phone = "890-567-4567", Email = "jordan@lee.com" });
            }
            

            if (database.Table<Match>().Count() == 0)  
            { 
                //SaveMatch(new Match { OppID = 1, Date = DateTime.Now.AddDays(1), Comments = "EZ Clap", GameID = 1, Win = true });
                //SaveMatch(new Match { OppID = 2, Date = DateTime.Now, Comments = "Good game friendo", GameID = 2, Win = true });
                //SaveMatch(new Match { OppID = 1, Date = DateTime.Now.AddDays(-1), Comments = "Tough competition!", GameID = 3, Win = false });
                //SaveMatch(new Match { OppID = 3, Date = DateTime.Now.AddDays(-2), Comments = "Close call, but managed to win!", GameID = 2, Win = true });
                //SaveMatch(new Match { OppID = 1, Date = DateTime.Now.AddDays(-3), Comments = "Dominating victory!", GameID = 1, Win = true });
                //SaveMatch(new Match { OppID = 2, Date = DateTime.Now.AddDays(-4), Comments = "Lost, but learned a lot.", GameID = 1, Win = false });
                //SaveMatch(new Match { OppID = 1, Date = DateTime.Now.AddDays(-5), Comments = "Had a great time, good game.", GameID = 5, Win = true });
                //SaveMatch(new Match { OppID = 1, Date = DateTime.Now.AddDays(-6), Comments = "Had a great time, good game.", GameID = 5, Win = true });
            }

            if (database.Table<Game>().Count() == 0)   
            {


                //SaveGame(new Game { GameName = "Overwatch", Description = "Hanamura", Rating = 9.5 });
                //SaveGame(new Game { GameName = "Shadow Quest", Description = "Explore ancient ruins and battle dark creatures.", Rating = 8.7 });
                //SaveGame(new Game { GameName = "Mystic Lands", Description = "A world full of magic, mysteries, and adventures awaits.", Rating = 9.0 });
                //SaveGame(new Game { GameName = "Cyber Sprint", Description = "A fast-paced race through a dystopian future.", Rating = 8.3 });
                //SaveGame(new Game { GameName = "Galactic Battles", Description = "Lead your fleet to victory in epic space wars.", Rating = 9.2 });
                //SaveGame(new Game { GameName = "Fantasy Kingdoms", Description = "Build and rule your kingdom in a land of dragons and knights.", Rating = 8.5 });
                SaveGame(new Game { GameName = "Chess", Description = "Simple grid game", Rating = 9.5 });
                SaveGame(new Game { GameName = "Checkers", Description = "Simpler grid game", Rating = 5 });
                SaveGame(new Game { GameName = "Dominoes", Description = "Blocks game", Rating = 6.75 });
            }
        }
    }
}

