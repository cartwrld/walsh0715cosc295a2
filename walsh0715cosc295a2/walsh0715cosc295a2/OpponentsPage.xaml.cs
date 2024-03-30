using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections;


namespace walsh0715cosc295a2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OpponentsPage : ContentPage
    {
        public OpponentsPage()
        {
            InitializeComponent();

            setToolBar("Opponents");


            // opponent list
            List<Opponent> oppList = App.OppDatabase.GetOpponents();

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
            Button newBtn = new Button { Text = "Add New Opponent", Margin = 35, Padding = new Thickness(15, 0), HorizontalOptions = LayoutOptions.Center };

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
                lvOpps.ItemsSource = App.OppDatabase.GetOpponents(); // Update your ListView's ItemsSource
            }

            Content = stklayout;
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

    public class OpponentCell : ViewCell
    {
        public OpponentCell()
        { 
            Label lblFirst = new Label { FontSize = 20 };
            Label lblLast = new Label { FontSize = 20 };
            Label lblPhone = new Label { FontSize = 20, HorizontalOptions = LayoutOptions.End, WidthRequest=130 };

            lblFirst.SetBinding(Label.TextProperty, "FirstName");
            lblLast.SetBinding(Label.TextProperty, "LastName");
            lblPhone.SetBinding(Label.TextProperty, "Phone");

            StackLayout stkName = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                WidthRequest = 200,
                Children = { lblFirst, lblLast }
            };

            View = new StackLayout 
            { 
                Orientation = StackOrientation.Horizontal,
                Spacing = 50,
                Children = { stkName, lblPhone }, 
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.Center
            };

            MenuItem mi = new MenuItem { Text = "Delete", IsDestructive = true };
            mi.Clicked += async (sender, e) =>
            {
                var menuItem = (MenuItem)sender;
                var opponent = (Opponent)menuItem.BindingContext;

                if (opponent != null)
                {
                    App.OppDatabase.DeleteOpponent(opponent);

                    var lv = (ListView)this.Parent;

                    if (lv != null)
                    {
                        List<Opponent> opponents = App.OppDatabase.GetOpponents();
                        lv.ItemsSource = new ObservableCollection<Opponent>(opponents);
                    }
                }
            };

            ContextActions.Add(mi);
        }
    }
}