using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace walsh0715cosc295a2
{
    public class GamesPage : ContentPage
    {
        public GamesPage()
        {
            List<Game> games = App.GamesDatabase.GetGames();

            setToolBar("Games");

            ListView lvGames = new ListView
            {
                ItemsSource = games.Select(game => new
                {
                    Game = game,
                    MatchCount = App.MatchesDatabase.CountByGame(game.ID),
                }).ToList(),
                ItemTemplate = new DataTemplate(typeof(GameCell)),
                RowHeight = GameCell.RowHeight,
            };

            StackLayout stkLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = { lvGames }
            };

            Content = stkLayout;
        }
        public void setToolBar(string title)
        {
            Title = title;
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
            Navigation.PushAsync(new GamesPage());
        }
    }

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

            lblGameName.SetBinding(Label.TextProperty, "Game.GameName");
            lblDescription.SetBinding(Label.TextProperty, "Game.Description");
            lblMatchCount.SetBinding(Label.TextProperty, "MatchCount");
            lblRating.SetBinding(Label.TextProperty, "Game.Rating");

            StackLayout stkMatches = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { lblMatches, lblMatchCount }
            };

            StackLayout stkLeft = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = 300,
                Children = { lblGameName, lblDescription, stkMatches }
            };
            StackLayout stkRight = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = 50,
                Children = { lblRating }

            };

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