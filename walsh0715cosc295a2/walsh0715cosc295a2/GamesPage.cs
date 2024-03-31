using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace walsh0715cosc295a2
{
    public class GamesPage : ContentPage
    {
        public static string title = "Games";
        public GamesPage(string prev)
        {
            List<Game> games = App.AppDB.GetGames();

            setToolBar(prev);

            ListView lvGames = new ListView
            {
                ItemsSource = games.Select(game => new
                {
                    Game = game,
                    MatchCount = App.AppDB.CountByGame(game.ID),
                }).ToList(),
                ItemTemplate = new DataTemplate(typeof(GameCell)),
                RowHeight = GameCell.RowHeight,
            };

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
        public void setToolBar(string p)
        {
            Title = p;
            ToolbarItem btnSettings = new ToolbarItem
            {
                Text = "Settings",
                Order = ToolbarItemOrder.Primary,
            };
            ToolbarItem btnGames = new ToolbarItem
            {
                Text = "Games",
                Order = ToolbarItemOrder.Primary,
                IsEnabled = false,
            };

            btnSettings.Clicked += OnSettingsClick;

            ToolbarItems.Add(btnGames);
            ToolbarItems.Add(btnSettings);
        }
        public void OnSettingsClick(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SettingsPage());
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
                WidthRequest = 290,
                Children = { lblGameName, lblDescription, stkMatches }
            };
            StackLayout stkRight = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                WidthRequest = 60,
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