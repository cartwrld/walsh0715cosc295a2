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

            setToolBar();

            // opponent list
            List<Opponent> oppList = App.AppDB.GetOpponents();

            // list view to hold the opponents
            ListView lvOpps = new ListView
            {
                ItemsSource = oppList,
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
                BackgroundColor = Color.Accent
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

            MessagingCenter.Subscribe<AddNewOppPage>(this, "DBUpdated", (sender) => {
                UpdateListView();
            });

            MessagingCenter.Subscribe<SettingsPage>(this, "DBReset", (sender) => {
                UpdateListView();
            });

            void UpdateListView()
            {
                lvOpps.ItemsSource = App.AppDB.GetOpponents(); // Update your ListView's ItemsSource
            }

            Content = stklayout;
        }

        public void setToolBar()
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
            Navigation.PushAsync(new GamesPage(title));
        }

    }

    public class OpponentCell : ViewCell
    {
        public OpponentCell()
        { 
            Label lblFirst = new Label { FontSize = 20 };
            Label lblLast = new Label { FontSize = 20 };

            Label lblPhone = new Label { FontSize = 17, VerticalTextAlignment = TextAlignment.Center, HorizontalTextAlignment = TextAlignment.End, WidthRequest = 145 };

            lblFirst.SetBinding(Label.TextProperty, "FirstName");
            lblLast.SetBinding(Label.TextProperty, "LastName");
            lblPhone.SetBinding(Label.TextProperty, "Phone");

            StackLayout stkName = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,

                WidthRequest = 200,
                //Padding = 20,
                Children = { lblFirst, lblLast }
            };

            View = new StackLayout 
            { 
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                //Spacing = 50,
                //Padding = new Thickness(0,12,0,0),
                Children = { stkName, lblPhone }, 
            };

            MenuItem mi = new MenuItem { Text = "Delete", IsDestructive = true };
            mi.Clicked += async (sender, e) =>
            {
                var menuItem = (MenuItem)sender;
                var opponent = (Opponent)menuItem.BindingContext;

                if (opponent != null)
                {
                    App.AppDB.DeleteOpponent(opponent);

                    var lv = (ListView)this.Parent;

                    if (lv != null)
                    {
                        List<Opponent> opponents = App.AppDB.GetOpponents();
                        lv.ItemsSource = new ObservableCollection<Opponent>(opponents);
                    }
                }
            };

            ContextActions.Add(mi);
        }
    }
}