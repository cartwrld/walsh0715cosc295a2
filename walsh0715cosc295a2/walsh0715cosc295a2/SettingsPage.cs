using Xamarin.Forms;

namespace walsh0715cosc295a2
{
    public class SettingsPage : ContentPage
    {
        public static string title = "Settings";

        public SettingsPage(string prev)
        {
            // setup for the toolbar
            SetToolbar(prev);

            // label describing what happens when the button is pressed
            Label lblTitle = new Label { Text = "Delete all existing\nOpponents/Matches/Games",FontAttributes = FontAttributes.Bold, HorizontalTextAlignment = TextAlignment.Center};
            
            // button to perform the reset
            Button btnReset = new Button { Text = "Reset",
                TextColor = Color.White,
                FontAttributes = FontAttributes.Bold,
                BackgroundColor = Color.Crimson,
            };

            // click function to reset
            btnReset.Clicked += (sender, e) =>
            {
                // reset the db
                App.AppDB.ResetDB();

                // send message to opponents page to refresh the list
                MessagingCenter.Send(this, "DBReset");

                // pop back to empty opponents page
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


        /**
         * This function sets the toolbar for the Settings page 
         */
        public void SetToolbar(string p)
        {
            // previous title
            Title = p;
            
            ToolbarItem btnSettings = new ToolbarItem 
            { 
                Text = "Settings", 
                Order = ToolbarItemOrder.Primary,
                // disabled since we're on the settings page
                IsEnabled = false,
            };
            ToolbarItem btnGames = new ToolbarItem { Text = "Games", Order = ToolbarItemOrder.Primary };
            
            // setting function for the games click
            btnGames.Clicked += (s, e) => Navigation.PushAsync(new GamesPage(title));
            
            // add buttons to the toolbar
            ToolbarItems.Add(btnGames);
            ToolbarItems.Add(btnSettings);
        }
    }
}