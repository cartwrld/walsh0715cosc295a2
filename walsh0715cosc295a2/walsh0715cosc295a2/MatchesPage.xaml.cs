using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Switch = Xamarin.Forms.Switch;
using System.Globalization;
using ListView = Xamarin.Forms.ListView;
using DatePicker = Xamarin.Forms.DatePicker;
using Picker = Xamarin.Forms.Picker;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Essentials;

namespace walsh0715cosc295a2
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MatchesPage : ContentPage
    {
        public static string title = "Matches";

        DatePicker datePicker;
        ViewCell vcDate;
        EntryCell ecComment;
        Picker pickerGame;
        ViewCell vcGame;
        SwitchCell scWin;

        // tracking current match to use for update
        Match currentMatch;
        
        // save button for saving new match/updated matches defined here
        // without the text property set so it can be changed when necessary
        Button saveBtn = new Button
        {
            HorizontalOptions = LayoutOptions.Center,
            Margin = new Thickness(15, 7, 15, 15),
            Padding = new Thickness(15, 0),
            BackgroundColor = Color.Accent,
            TextColor = Color.White,
            FontAttributes = FontAttributes.Bold,
        };

        /**
         * This function is responsible for converting the list of Matches to 
         * MatchItems, to include the GameName and the FullName of the Opponent
         */
        public ObservableCollection<MatchItem> handleMatchItems(List<Match> matches, Opponent opp)
        {
            List<MatchItem> matchItems =
            matches.Select(match => new MatchItem
            {
                Match = match,
                FullName = $"{opp.FirstName} {opp.LastName}",
                GameName = App.AppDB.GetGame(match.GameID)?.GameName
            }).ToList();

            return new ObservableCollection<MatchItem>(matchItems);
        }

        public MatchesPage(Opponent opp)
        {
            // set toolbar
            SetToolbar("Opponents");

            // get matches that contain the selected opponent ID
            List<Match> matches = App.AppDB.GetMatchesByID(opp.ID);

            ObservableCollection<MatchItem> matchItems = handleMatchItems(matches, opp);

            
            // get list of games to retrieve game  names
            List<string> gameNames = App.AppDB.GetGameNames();

            // list view for the matches for the selected opponent
            ListView lvMatches = new ListView
            {
                ItemsSource = matchItems,
                ItemTemplate = new DataTemplate(typeof(MatchCell)),
                RowHeight = MatchCell.RowHeight
            };

            // when an item is tapped
            lvMatches.ItemTapped += (sender, e) =>
            {
                lvMatches.SelectedItem = null;
                MatchItem item = (MatchItem)e.Item;
                
                // set table cells with corresponding data
                datePicker.Date = item.Match.Date;
                ecComment.Text = item.Match.Comments;
                scWin.On = item.Match.Win;
                pickerGame.SelectedItem = item.Match.GameID - 1;
                saveBtn.Text = "Save Match";
                currentMatch = item.Match;
            };

            // subscribe to message from matches page to know when to update the listview
            MessagingCenter.Subscribe<MatchesPage>(this, "MatchesUpdate", (sender) =>
            {
                lvMatches.ItemsSource = App.AppDB.GetMatchesByID(opp.ID);
            });

            // container for the matches
            StackLayout stkMatches = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = { lvMatches },
                HeightRequest = 1385
            };

          

            // game label
            Label lblDate = new Label
            {
                Text = "Date:",
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Start,
                Padding = new Thickness(15, 0, 27, 0)
            };

            // date picker
            datePicker = new DatePicker { Format = "dddd, MMMM d, yyyy", WidthRequest = 303, TextColor = Color.Black};

            // stack for the date
            StackLayout stkDate = new StackLayout
            {
                //Padding = new Thickness(40, 0, 0, 0),
                Orientation= StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
               
                Children = {lblDate, datePicker },
            }; 
            
            // viewcell for the date
            vcDate = new ViewCell { View = stkDate };

            ecComment = new EntryCell { Label = "Comment:"};

            // game label
            Label lblGame = new Label 
            { 
                Text = "Game:", 
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Padding = new Thickness(15,0, 20, 0)
            };

            // picker for the game name
            pickerGame = new Picker
            {
                Title = "Select a game...",
                ItemsSource = gameNames,
                SelectedItem = null,
                WidthRequest = 303,
            };

            // set default selected item
            pickerGame.SelectedItem = "Chess";

            // function to handle saving the selected game to the database when the selected index changes
            pickerGame.SelectedIndexChanged += async (sender, args) =>
            {

                string selectedGameName = pickerGame.Items[pickerGame.SelectedIndex];
                try
                {
                    await SecureStorage.SetAsync("lastSelectedGame", selectedGameName);
                }
                catch (Exception ex)
                {
                    // if there was an issue saving the game
                    Debug.WriteLine($"Error occured when saving selected game: {ex.Message}");
                }
            };

            // HStack for the game label and picker 
            StackLayout stkGame = new StackLayout 
            { 
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Center,
                Children = { lblGame, pickerGame },
            };

            // viewcell that holds the game stack 
            vcGame = new ViewCell { View = stkGame, };
            scWin = new SwitchCell { Text = "Win?" };

            // ========== SETUP - ADD MATCH TABLE ==========
            TableView tvAddMatch = new TableView { Intent = TableIntent.Form, Margin = new Thickness(0,-10,0,0)};

            TableSection tsAddSection = new TableSection() { new AddMatchTblHdr(), vcDate, ecComment, vcGame, scWin };
           
            tvAddMatch.Root = new TableRoot() { tsAddSection };


            // save button for saving new match
            saveBtn.Text = "Add New Match"; 
            saveBtn.Clicked += (sender, e) =>
            {
                // if there is no tapped match
                if (currentMatch == null)
                {
                    // make new match
                    Match match = new Match
                    {
                        OppID = opp.ID,
                        Date = datePicker.Date,
                        Comments = ecComment.Text,
                        GameID = App.AppDB.GetGameIDByName(pickerGame.SelectedItem.ToString()),
                        Win = scWin.On
                    };

                    // save new match to db
                    App.AppDB.SaveMatch(match);    
                }
                else
                {
                    // set the current match to the new values
                    currentMatch.OppID = opp.ID;
                    currentMatch.Date = datePicker.Date;
                    currentMatch.Comments = ecComment.Text;
                    currentMatch.GameID = App.AppDB.GetGameIDByName(pickerGame.SelectedItem.ToString());
                    currentMatch.Win = scWin.On;

                    // update current match in the db
                    App.AppDB.SaveMatch(currentMatch);
                }
                
                // set matches 
                matches = App.AppDB.GetMatchesByID(opp.ID);
               
                // set itemsource to refreshed MatchItem list
                lvMatches.ItemsSource = handleMatchItems(matches, opp);

                // clear tablefields
                datePicker.Date = DateTime.Now;
                ecComment.Text = "";
                pickerGame.SelectedItem = "Chess";
                scWin.On = false;

                // set currentMatch to null
                currentMatch = null;
                // reset button text to add 
                saveBtn.Text = "Add New Match";
            };

            // stack for the table and the save btn
            StackLayout stkAddLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = { tvAddMatch, saveBtn }
            };

            // stack for the list view and the table stack
            StackLayout stkBase = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = { stkMatches, stkAddLayout } 
            };

            Content = stkBase;

            // set the default game
            SetDefaultGame();
        }

        /**
         * This function sets the picker to the last chosen game, and is managed by
         * secure storage
         */
        async void SetDefaultGame()
        {
            try
            {
                string lastGame = await SecureStorage.GetAsync("lastSelectedGame");
                if (lastGame != null)
                {
                    Debug.WriteLine(lastGame);
                    int index = pickerGame.Items.IndexOf(lastGame);
                    if (index != -1)
                    {
                        pickerGame.SelectedIndex = index; 
                    } else
                    {
                        pickerGame.SelectedItem = "Chess";
                    }
                }
            }
            catch (Exception ex)
            {
                // if there was an issue getting the saved game
                Debug.WriteLine($"Error occured when retrieving selected game: {ex.Message}");
            }
        }

        /**
         * This function sets the toolbar for the Matches page 
         */
        public void SetToolbar(string prev)
        {
            Title = prev;

            ToolbarItem btnSettings = new ToolbarItem { Text = "Settings", Order = ToolbarItemOrder.Primary };
            ToolbarItem btnGames = new ToolbarItem{ Text = "Games",Order = ToolbarItemOrder.Primary };

            btnGames.Clicked += (s,e)=>Navigation.PushAsync(new SettingsPage(title));
            btnSettings.Clicked += (s,e)=>Navigation.PushAsync(new GamesPage(title));

            ToolbarItems.Add(btnGames);
            ToolbarItems.Add(btnSettings);
        }
      
    }


    /**
     * This class represents the items that are displayed in the listview
     * for Matches. It contains information from the Match table, as 
     * well as the Opponent and Game tables, so a class is needed.
     * 
     */
    public class MatchItem
    {
        // match representing the match
        public Match Match { get; set; }
        // gamename from the game table
        public string GameName { get; set; }
        // fullname from the opponent table
        public string FullName { get; set; }
    }


    /**
     * This class is used for the TableViews as a custom Table Title cell
     */
    public class AddMatchTblHdr : ViewCell
    {
        public AddMatchTblHdr()
        { 
            Label lblTableHeader = new Label { Text = "Add Match", FontSize = 18, Padding = new Thickness(25, 10, 15, 0), WidthRequest = 800, TextColor = Color.GhostWhite, FontAttributes = FontAttributes.Bold, HorizontalTextAlignment = TextAlignment.Start, VerticalTextAlignment = TextAlignment.Center,};
            StackLayout stkTblHdr = new StackLayout { BackgroundColor = Color.Accent, HeightRequest = 50, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Children = { lblTableHeader } };
            View = stkTblHdr;
        }

    }

    /**
     * This class is used to represent the Matches on the Matches page of
     * the App. An MatchCell displays the Opponents full name, the date of
     * the match, the game name, a comment, and the win status.
     */
    public class MatchCell : ViewCell
    {
        public const int RowHeight = 108;
        public MatchCell()
        { 
            Label lblFullName = new Label { FontSize = 20 };
            //Label lblDate = new Label { FontSize = 17, FontAttributes = FontAttributes.Italic};
            Label lblDate = new Label { FontSize = 17 };
            Label lblGameType = new Label { FontSize = 17 };
            Label lblComments = new Label { FontSize = 15, HorizontalTextAlignment = TextAlignment.End};
            Label lblWin = new Label { FontSize = 17, Text = "Win?" };
            Switch swWin = new Switch();

            // set bindings to the MatchItem list
            lblFullName.SetBinding(Label.TextProperty, "FullName");
            lblDate.SetBinding(Label.TextProperty, new Binding("Match.Date", BindingMode.Default, new DateConverter()));
            lblGameType.SetBinding(Label.TextProperty, "GameName");
            lblComments.SetBinding(Label.TextProperty, "Match.Comments");
            swWin.SetBinding(Switch.IsToggledProperty, "Match.Win");

            StackLayout stkWin = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center,
                Children = { lblWin, swWin }
            };

            // left side of the cell (name, date, gamename)
            StackLayout stkLeft = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                WidthRequest = 350,
                Children = { lblFullName, lblDate, lblGameType }
            };

            // right side of the cell (comment, win)
            StackLayout stkRight = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.End,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                WidthRequest = 150,
                Children = { lblComments, stkWin }
            };

            // left and right in the same stack
            StackLayout stkBase = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(20,10,20,10),
                Children = { stkLeft, stkRight }
            };

            View = stkBase;

            // setting the functionality of deleting matches
            MenuItem mi = new MenuItem { Text = "Delete", IsDestructive = true };
            mi.Clicked += (sender, e) =>
            {
                var menuItem = (MenuItem)sender;
                var matchItem = (MatchItem)menuItem.BindingContext;

                if (matchItem != null)
                {
                    // extract the match
                    Match m = matchItem.Match;

                    // delete match
                    App.AppDB.DeleteMatch(m);

                    ListView lv = (ListView)this.Parent;

                    if (lv != null)
                    { 
                        // refresh list view
                        List<Match> matches = App.AppDB.GetMatchesByID(m.OppID);
                        lv.ItemsSource = matches.Select(match => new MatchItem
                        {
                            Match = match,
                            FullName = $"{App.AppDB.GetOpponentName(match.OppID)}",
                            GameName = App.AppDB.GetGame(match.GameID)?.GameName
                        }).ToList(); ;
                    }
                }
            };

            ContextActions.Add(mi);
        }
       
    }
    

    /**
     * This class is used to convert dates to stirngs.
     */
    public class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime date = (DateTime)value;
            return date.ToString("dddd, MMMM d, yyyy");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

   
}



