using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace walsh0715cosc295a2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OpponentsPage : ContentPage
    {
        public static string title = "Opponents";
        public OpponentsPage()
        {
            InitializeComponent();

            // setup for the toolbar
            SetToolbar(title);

            // opponent list
            List<Opponent> oppList = App.AppDB.GetOpponents();

            ObservableCollection<Opponent> ocOppList = new ObservableCollection<Opponent>(oppList);

            // list view to hold the opponents
            ListView lvOpps = new ListView
            {
                ItemsSource = ocOppList,
                ItemTemplate = new DataTemplate(typeof(OpponentCell)),
                RowHeight = 50
            };

            // push new matches page when item is tapped in listview
            lvOpps.ItemTapped += (sender, e) =>
            {
                lvOpps.SelectedItem = null;
                Navigation.PushAsync(new MatchesPage((Opponent)e.Item));
            };

            // btn to add new opponent
            Button newBtn = new Button 
            { 
                Text = "Add New Opponent", 
                HorizontalOptions = LayoutOptions.Center,
                Margin = 35, 
                Padding = new Thickness(15, 0), 
                BackgroundColor = Color.Accent,
                TextColor = Color.White,
                FontAttributes = FontAttributes.Bold,
            };

            newBtn.Clicked += (sender, e) =>
            {
                lvOpps.SelectedItem = null;
                Navigation.PushAsync(new AddNewOppPage());
            };

            // stack layout to hold the listview
            StackLayout stklayout = new StackLayout 
            { 
                Orientation = StackOrientation.Vertical, 
                Children = { lvOpps, newBtn } 
            };

            Content = stklayout;

            // get message from AddNewOppPage to refresh the list after adding Opponent
            MessagingCenter.Subscribe<AddNewOppPage>(this, "DBUpdated", (sender) => {
                UpdateListView();
            });

            // get message from SettingPage to refresh the list after resetting the DB
            MessagingCenter.Subscribe<SettingsPage>(this, "DBReset", (sender) => {
                UpdateListView();
            });

            // function that refreshes the listview
            void UpdateListView()
            {
                List<Opponent> list = App.AppDB.GetOpponents();
                ObservableCollection<Opponent> ocOpps = new ObservableCollection<Opponent>(list);
                lvOpps.ItemsSource = ocOpps;
            }
        }

        /**
         * This function sets the toolbar for the Opponents page 
         */
        public void SetToolbar(string prev)
        {
            Title = prev;

            ToolbarItem btnSettings = new ToolbarItem { Text = "Settings", Order = ToolbarItemOrder.Primary };
            ToolbarItem btnGames = new ToolbarItem { Text = "Games", Order = ToolbarItemOrder.Primary };

            btnGames.Clicked += (s, e) => Navigation.PushAsync(new GamesPage(title));
            btnSettings.Clicked += (s, e) => Navigation.PushAsync(new SettingsPage(title));

            ToolbarItems.Add(btnGames);
            ToolbarItems.Add(btnSettings);
        }
    }

    /**
     * This class is used to represent the Opponents on the main page of
     * the App. An OpponentCell displays the Opponents full name, and
     * phone number.
     */
    public class OpponentCell : ViewCell
    {
        public OpponentCell()
        { 
            Label lblFirst = new Label { FontSize = 18 };
            Label lblLast = new Label { FontSize = 18 };
            Label lblPhone = new Label { FontSize = 17, VerticalTextAlignment = TextAlignment.Center, HorizontalTextAlignment = TextAlignment.End, WidthRequest = 145 };

            // set bindings for the fname, lname, and phone
            lblFirst.SetBinding(Label.TextProperty, "FirstName");
            lblLast.SetBinding(Label.TextProperty, "LastName");
            lblPhone.SetBinding(Label.TextProperty, "Phone");

            // horizontal stack for the name
            StackLayout stkName = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                WidthRequest = 200,
                Children = { lblFirst, lblLast }
            };

            View = new StackLayout 
            { 
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Children = { stkName, lblPhone }, 
            };

            // set up the delete function for the menu item
            MenuItem mi = new MenuItem { Text = "Delete", IsDestructive = true };
            mi.Clicked += async (sender, e) =>
            {
                var menuItem = (MenuItem)sender;
                var opponent = (Opponent)menuItem.BindingContext;

                if (opponent != null)
                {
                    // delete opponent
                    App.AppDB.DeleteOpponent(opponent);

                    // delete matches by opponent ID
                    App.AppDB.DeleteMatchesByOppID(opponent.ID);
                    
                    ListView lv = (ListView)this.Parent;

                    if (lv != null)
                    {
                        // reset the list view
                        List<Opponent> opponents = App.AppDB.GetOpponents();
                        lv.ItemsSource = new ObservableCollection<Opponent>(opponents);
                    }
                }
            };

            ContextActions.Add(mi);
        }
    }
}