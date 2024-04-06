using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;

namespace walsh0715cosc295a2
{
    public class GamesPage : ContentPage
    {
        public static string title = "Games";
        public GamesPage(string prev)
        {
            // get list of games
            List<Game> games = App.AppDB.GetGames();

            // setup the toolbar
            SetToolBar(prev);

            // get listview of games
            ListView lvGames = new ListView
            {
                // create list of games with a match count for each game
                ItemsSource = games.Select(game => new
                {
                    Game = game,
                    MatchCount = App.AppDB.CountByGame(game.ID),
                }).ToList(),
                ItemTemplate = new DataTemplate(typeof(GameCell)),
                RowHeight = GameCell.RowHeight,
            };

            // remove highlighting when tapped
            lvGames.ItemTapped += (sender, e) =>
            {
                ((ListView)sender).SelectedItem = null;
            };

            StackLayout stkLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = { lvGames }
            };

            Content = stkLayout;
        }

        /**
        * This function sets the toolbar for the Games page 
        */
        public void SetToolBar(string p)
        {
            // previous title
            Title = p;

            ToolbarItem btnSettings = new ToolbarItem { Text = "Settings", Order = ToolbarItemOrder.Primary, };
            ToolbarItem btnGames = new ToolbarItem 
            { 
                Text = "Games",
                Order = ToolbarItemOrder.Primary,
                // disabled since we're on the games page
                IsEnabled = false, 
            };

            // setting function for the settings click
            btnSettings.Clicked += (s,e) => Navigation.PushAsync(new SettingsPage(title));

            // add buttons to the toolbar
            ToolbarItems.Add(btnGames);
            ToolbarItems.Add(btnSettings);
        }
       

    }

    /**
    * This class is used to represent the Games on the Games page of
    * the App. An GameCell displays the GameName, Description, Rating, 
    * and number of Matches that contain that Game.
    */
    public class GameCell : ViewCell
    {
        public static int RowHeight = 130;

        public GameCell()
        {
            Label lblGameName = new Label { FontAttributes = FontAttributes.Bold, FontSize = 20};
            Label lblDescription = new Label { FontSize = 16 };
            Label lblMatches = new Label { Text = "# Matches:", FontSize = 16 };
            Label lblMatchCount = new Label { FontSize = 16 };
            Label lblRating = new Label {  FontSize = 26, VerticalTextAlignment = TextAlignment.Center,HorizontalTextAlignment = TextAlignment.Center};

            // set bindings to the game list
            lblGameName.SetBinding(Label.TextProperty, "Game.GameName");
            lblDescription.SetBinding(Label.TextProperty, "Game.Description");
            lblMatchCount.SetBinding(Label.TextProperty, "MatchCount");
            lblRating.SetBinding(Label.TextProperty, "Game.Rating");

            StackLayout stkMatches = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { lblMatches, lblMatchCount }
            };

            // stack for the left items
            StackLayout stkLeft = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = 290,
                Children = { lblGameName, lblDescription, stkMatches }
            };

            // stack for the right item
            StackLayout stkRight = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = 60,
                Children = { lblRating }
            };

            // left and right together now
            StackLayout stkBase = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(20,13,20,20),
                Children = { stkLeft, stkRight }
            };

            View = stkBase;
        }
    }


}