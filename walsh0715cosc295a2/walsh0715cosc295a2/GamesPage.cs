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
            List<Game> gameList = App.GamesDatabase.GetGames();

            Title = "Games";

            ListView lvGames = new ListView
            {
                ItemsSource = gameList,
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
    }

    public class GameCell : ViewCell
    {
        public static int RowHeight = 135;

        public GameCell()
        {
            Label lblGameName = new Label { FontAttributes = FontAttributes.Bold, FontSize = 20};
            Label lblDescription = new Label { FontSize = 16 };
            Label lblMatches = new Label { Text = "# Matches:", FontSize = 16 };
            Label lblMtCount = new Label { Text = "4", FontSize = 16 };
            Label lblRating = new Label { Padding = new Thickness(0,20,0,0), FontSize = 26, HorizontalTextAlignment = TextAlignment.Center};

            lblGameName.SetBinding(Label.TextProperty, "GameName");
            lblDescription.SetBinding(Label.TextProperty, "Description");
            //lblMatches.SetBinding(Label.TextProperty, "Matches");
            //lblMtCount.SetBinding(Label.TextProperty, "MtCount");
            lblRating.SetBinding(Label.TextProperty, "Rating");

            StackLayout stkMatches = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { lblMatches, lblMtCount }
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
                Padding = new Thickness(30,15,30,30),
                Children = { stkLeft, stkRight }
            };

            View = stkBase;
        }
    }
}