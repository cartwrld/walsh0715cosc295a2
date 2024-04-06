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

            // setup the toolbar
            SetToolBar();

            // entrycells for the info about the new Opponent
            EntryCell ecFirst = new EntryCell{ Label = "First:"};
            EntryCell ecLast = new EntryCell { Label = "Last:"};
            EntryCell ecAddr = new EntryCell{ Label = "Address:"};
            EntryCell ecPhone = new EntryCell{ Label = "Phone:"};
            EntryCell ecEmail = new EntryCell{ Label = "Email:"};

            // tableview for the add opponent table
            TableView tvNewOpp = new TableView
            {
                Intent = TableIntent.Form,
                Root = { new TableSection{new AddOppTblHdr(), ecFirst, ecLast, ecAddr, ecPhone, ecEmail } }
            };

            // initializing the save button
            Button btnSaveNew = new Button {
                Text = "Save New Opponent", 
                Margin = 35, 
                Padding = new Thickness(15, 0),
                HorizontalOptions = LayoutOptions.Center,
                FontAttributes = FontAttributes.Bold,
                BackgroundColor = Color.Accent,
                TextColor = Color.White,
            };

            // function to handle the clicking of the save button
            btnSaveNew.Clicked += (s, e) =>
            {
                // putting all the values in a string[] for ease
                string[] oppValues = { ecFirst.Text,ecLast.Text,ecAddr.Text,ecPhone.Text,ecEmail.Text };

                // setting unfilled values to 'N/A'
                for (int i=0; i<oppValues.Length; i++) 
                {
                    if (oppValues[i] == "")
                    {
                        oppValues[i] = "N/A";
                    }
                }

                // create new opponent
                Opponent opp = new Opponent
                {
                    FirstName = oppValues[0],
                    LastName = oppValues[1],
                    Address = oppValues[2],
                    Phone = oppValues[3],
                    Email = oppValues[4]
                };

                // save new opponent to the db
                App.AppDB.SaveOpponent(opp);

                // send message to update the listview
                MessagingCenter.Send(this, "DBUpdated");

                // pop the page back to the Opponents page
                Navigation.PopAsync();
            };

            StackLayout stackLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = { tvNewOpp, btnSaveNew }
            };

            Content = stackLayout;
        }

        /**
         * This function sets the toolbar for the AddNewOppPage page 
         */
        public void SetToolBar()
        {
            Title = "Opponents";

            ToolbarItem btnSettings = new ToolbarItem { Text = "Settings", Order = ToolbarItemOrder.Primary };
            ToolbarItem btnGames = new ToolbarItem { Text = "Games", Order = ToolbarItemOrder.Primary };

            btnGames.Clicked += (s,e) => Navigation.PushAsync(new SettingsPage(title));
            btnSettings.Clicked += (s,e) => Navigation.PushAsync(new GamesPage(title));

            ToolbarItems.Add(btnGames);
            ToolbarItems.Add(btnSettings);
        }
    }

    /**
    * This class is used for the TableViews as a custom Table Title cell
    */
    public class AddOppTblHdr : ViewCell
    {
        public AddOppTblHdr()
        {
            Label lblTableHeader = new Label { Text = "Add New Opponent", FontSize = 18, Padding = new Thickness(25, 10, 15, 0), WidthRequest = 800, TextColor = Color.GhostWhite, FontAttributes = FontAttributes.Bold, HorizontalTextAlignment = TextAlignment.Start, VerticalTextAlignment = TextAlignment.Center, };
            StackLayout stkTblHdr = new StackLayout { BackgroundColor = Color.Accent, HeightRequest = 50, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Children = { lblTableHeader } };
            View = stkTblHdr;
        }
    }
}