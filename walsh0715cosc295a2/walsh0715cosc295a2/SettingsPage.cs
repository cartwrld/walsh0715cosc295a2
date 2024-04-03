using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace walsh0715cosc295a2
{
    public class SettingsPage : ContentPage
    {
        public static string title = "Settings";

        public SettingsPage()
        {
            setToolBar();

            Label lblTitle = new Label { Text = "Reset Game Data" };
            Button btnReset = new Button { Text = "Reset",
                TextColor = Color.White,
                FontAttributes = FontAttributes.Bold,
                BackgroundColor = Color.Accent,
            };

            btnReset.Clicked += (sender, e) =>
            {
                App.AppDB.ResetDB();

                MessagingCenter.Send(this, "DBReset");

                Navigation.PopToRootAsync();
            };

            StackLayout stkBase = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Children = { lblTitle, btnReset }
              
            };

            Content = stkBase;
        }
        public void setToolBar()
        {
            Title = title;
            ToolbarItem btnSettings = new ToolbarItem
            {
                Text = "Settings",
                Order = ToolbarItemOrder.Primary,
                IsEnabled = false,
            };
            ToolbarItem btnGames = new ToolbarItem
            {
                Text = "Games",
                Order = ToolbarItemOrder.Primary,
            };

            btnGames.Clicked += OnGamesClick;

            ToolbarItems.Add(btnGames);
            ToolbarItems.Add(btnSettings);
        }
   
        public void OnGamesClick(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GamesPage(title));
        }
    }
}