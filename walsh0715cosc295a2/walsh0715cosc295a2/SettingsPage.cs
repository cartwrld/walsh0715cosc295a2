using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace walsh0715cosc295a2
{
    public class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            
            Label lblTitle = new Label { Text = "Reset Game Data" };
            Button btnReset = new Button { Text = "Reset" };

            btnReset.Clicked += (sender, e) =>
            {
                App.OppDatabase.ResetOpponentsDB();
                App.MatchesDatabase.ResetMatchesDB();
                App.GamesDatabase.ResetGamesDB();

                MessagingCenter.Send(this, "DBReset");

                Navigation.PopAsync();
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
    }
}