using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace walsh0715cosc295a2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewOppPage : ContentPage
    {
        public static string title = "Add Opponent";
        public AddNewOppPage()
        {
            InitializeComponent();

            setToolBar();

            EntryCell ecFirst = new EntryCell { Label = "First :" };
            EntryCell ecLast = new EntryCell { Label = "Last :" };
            EntryCell ecAddr = new EntryCell { Label = "Addr:" };
            EntryCell ecPhone = new EntryCell { Label = "Phone:" };
            EntryCell ecEmail = new EntryCell { Label = "Email:" };

            TableView tvNewOpp = new TableView
            {
                Intent = TableIntent.Form,
                Root = { new TableSection("Add New Opponent") { ecFirst, ecLast, ecAddr, ecPhone, ecEmail } }
            };

            Button btnSaveNew = new Button { Text = "Save New Opponent", Margin = 35, Padding = new Thickness(15, 0), HorizontalOptions = LayoutOptions.Center };

            btnSaveNew.Clicked += (s, e) =>
            {
                string[] oppValues = { ecFirst.Text,ecLast.Text,ecAddr.Text,ecPhone.Text,ecEmail.Text };

                for (int i=0; i<oppValues.Length; i++) 
                {
                    if (oppValues[i] == "")
                    {
                        oppValues[i] = "N/A";
                    }
                }

                Opponent opp = new Opponent
                {
                    FirstName = oppValues[0],
                    LastName = oppValues[1],
                    Address = oppValues[2],
                    Phone = oppValues[3],
                    Email = oppValues[4]
                };
                App.AppDB.SaveOpponent(opp);

                MessagingCenter.Send(this, "DBUpdated");

                Navigation.PopAsync();
            };

            StackLayout stackLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = { tvNewOpp, btnSaveNew }
            };

            Content = stackLayout;
        }

        public void setToolBar()
        {
            Title = "Opponents";

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
}