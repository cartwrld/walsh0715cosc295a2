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
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Security;
using static walsh0715cosc295a2.MatchesPage;

namespace walsh0715cosc295a2
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MatchesPage : ContentPage
    {
        public static string title = "Matches";

        public class MatchItem
        {
            public Match m { get; set; }
            public string gn { get; set; }
            public string fn { get; set; }
        }

        public List<MatchItem> handleMatchItems(List<Match> matches, Opponent opp)
        {
            List<MatchItem> matchItems =
            matches.Select(match => new MatchItem
            {
                m = match,
                fn = $"{opp.FirstName} {opp.LastName}",
                gn = App.AppDB.GetGame(match.GameID)?.GameName
            }).ToList();

            return matchItems;
        }

        public MatchesPage(Opponent opp)
        {
            // set toolbar
            setToolBar("Opponents");

            // get matches that contain the selected opponent ID
            List<Match> matches = App.AppDB.GetMatchesByID(opp.ID);

            List<MatchItem> matchItems = handleMatchItems(matches, opp);

            
            // get list of games to retrieve game  names
            List<string> gameNames = App.AppDB.GetGameNames();

            // list view for the matches for the selected opponent
            ListView lvMatches = new ListView
            {
                // creating custom object literal for opponent name and game name
                ItemsSource = matchItems,
                ItemTemplate = new DataTemplate(typeof(MatchCell)),
                RowHeight = MatchCell.RowHeight
            };

            // container for the matches
            StackLayout stkMatches = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = { lvMatches },
                HeightRequest = 1385
            };



            // ========== CELLS - ADD MATCH TABLE ==========

            // game label
            Label lblDate = new Label
            {
                Text = "Date:",
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Padding = new Thickness(15, 0, 18, 0)
            };
            DatePicker datePicker = new DatePicker { Format = "dddd, MMMM dd, yyyy", WidthRequest = 350, TextColor = Color.Black};
            StackLayout stkDate = new StackLayout 
            {
                Orientation= StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 450,
                Children = { datePicker },
            }; 
            ViewCell vcDate = new ViewCell { View = stkDate };

            EntryCell ecComment = new EntryCell { Label = "Comment:"};
            Picker pickerGame;

            // game label
            Label lblGame = new Label 
            { 
                Text = "Game:", 
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                Padding = new Thickness(15,0, 18, 0)
            };

            // picker for the game name
            pickerGame = new Picker
            {
                Title = "Select a game...",
                ItemsSource = gameNames,
                SelectedItem = null,
                WidthRequest = 264,
            };

            // HStack for the game label and picker 
            StackLayout stkGame = new StackLayout 
            { 
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Center,
                Children = { lblGame, pickerGame },
            };

            // viewcell that holds the game stack 
            ViewCell vcGame = new ViewCell { View = stkGame};
            SwitchCell scWin = new SwitchCell { Text = "Win?" };

            // ========== SETUP - ADD MATCH TABLE ==========
            TableView tvAddMatch = new TableView { Intent = TableIntent.Form };

            TableSection section = new TableSection() { new TableHeaderCell(), vcDate, ecComment, vcGame, scWin };
           
            tvAddMatch.Root = new TableRoot() { section };


            // save button for saving new match
            Button saveBtn = new Button
            {
                Text = "Add New Match",
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(15, 7, 15,15),
                Padding = new Thickness(15, 0),
                BackgroundColor = Color.Accent
            };
            saveBtn.Clicked += (sender, e) =>
            {
                Match match = new Match
                {
                    OppID = opp.ID,
                    Date = datePicker.Date,
                    Comments = ecComment.Text,
                    GameID = App.AppDB.GetGameIDByName(pickerGame.SelectedItem.ToString()),
                };
            };

            StackLayout stkAddLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
 
                Children = { tvAddMatch, saveBtn }
            };

            StackLayout stackLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = { stkMatches, stkAddLayout } 
            };

            Content = stackLayout;
        }

        public void setToolBar(string prev)
        {
            Title = prev;
            ToolbarItem btnSettings = new ToolbarItem
            {
                Text = "Settings",
                Order = ToolbarItemOrder.Primary,
            };
            ToolbarItem btnGames = new ToolbarItem
            {
                Text = "Games",
                Order = ToolbarItemOrder.Primary,
            };

            btnGames.Clicked += OnGamesClick;
            btnSettings.Clicked += OnSettingsClick;

            ToolbarItems.Add(btnGames);
            ToolbarItems.Add(btnSettings);
        }
        public void OnSettingsClick(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SettingsPage());
        }
        public void OnGamesClick(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GamesPage(title));
        }
    }

    public class TableHeaderCell : ViewCell
    {
        public TableHeaderCell()
        {
            Height = 30;
            View = new StackLayout
            {
                BackgroundColor = Color.Accent,
                HeightRequest = 30,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Children =
                {
                    new Label
                    {
                        Text = "Add Match",
                        FontSize = 18,
                        Padding = new Thickness(15, 3, 15, 0),
                        WidthRequest=800,
                        TextColor = Color.GhostWhite,
                        FontAttributes = FontAttributes.Bold,
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalTextAlignment = TextAlignment.Center,
                    }
                }
            };
        }
    }

    public class MatchCell : ViewCell
    {
        public const int RowHeight = 108;
        public MatchCell()
        { 
            Label lblFullName = new Label { FontSize = 20 };
            Label lblDate = new Label { FontSize = 17, FontAttributes = FontAttributes.Italic};
            Label lblGameType = new Label { FontSize = 17 };
            Label lblComments = new Label { FontSize = 15, HorizontalTextAlignment = TextAlignment.End};
            Label lblWin = new Label { FontSize = 17, Text = "Win?" };
            Switch swWin = new Switch();

            lblFullName.SetBinding(Label.TextProperty, "fn");
            lblDate.SetBinding(Label.TextProperty, new Binding("m.Date", BindingMode.Default, new DateConverter()));
            lblGameType.SetBinding(Label.TextProperty, "gn");
            lblComments.SetBinding(Label.TextProperty, "m.Comments");
            swWin.SetBinding(Switch.IsToggledProperty, "m.Win");


            StackLayout stkWin = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center,
                Children = { lblWin, swWin }
            };

            StackLayout stkLeft = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                WidthRequest = 350,
                Children = { lblFullName, lblDate, lblGameType }
            };
            StackLayout stkRight = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.End,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                WidthRequest = 150,
                Children = { lblComments, stkWin }
            };

            StackLayout stkBase = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(20,10,20,10),
                Children = { stkLeft, stkRight }
            };

            View = stkBase;

            MenuItem mi = new MenuItem { Text = "Delete", IsDestructive = true };
            mi.Clicked += (sender, e) =>
            {
                Debug.WriteLine("after click");

                var menuItem = (MenuItem)sender;
                var matchItem = (MatchItem)menuItem.BindingContext;

                if (matchItem != null)
                {
                    Match m = matchItem.m;

                    Console.WriteLine(m);

                    App.AppDB.DeleteMatch(m);

                    ListView lv = (ListView)this.Parent;

                    if (lv != null)
                    {
                        Opponent currentOpp = App.AppDB.GetOpponent();
                        List<Match> matches = App.AppDB.GetMatchesByID();
                        lv.ItemsSource = matches.Select(match => new MatchItem
                        {
                            m = match,
                            fn = $"{App.AppDB.GetOpponentName(match.OppID)}",
                            gn = App.AppDB.GetGame(match.GameID)?.GameName
                        }).ToList(); ;
                    }
                }
            };

            ContextActions.Add(mi);
        }
       
    }
    


    public class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime date = (DateTime)value;
            return date.ToString("dddd, MMMM dd, yyyy");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

   
}