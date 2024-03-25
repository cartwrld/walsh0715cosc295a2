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
using Switch = Xamarin.Forms.Switch;
using System.Globalization;


namespace walsh0715cosc295a2
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MatchesPage : ContentPage
    {
        public Opponent currentOpp;

        public MatchesPage(Opponent opp)
        {
            Title = "Matches";

            currentOpp = App.OppDatabase.GetOpponent(opp.ID);
            

            List<Match> matches = App.MatchesDatabase.GetMatchesByID(opp.ID);
            Game game = App.GamesDatabase.GetGame(opp.ID);

            ListView lvMatches = new ListView
            {
                ItemsSource = matches,
                ItemTemplate = new DataTemplate(typeof(MatchCell)),
                RowHeight = MatchCell.RowHeight
            };

            StackLayout stkMatches = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = { lvMatches },
                HeightRequest = 1600
            };

            DatePicker datePicker = new DatePicker { Format = "dddd, MMMM dd, yyyy" };
            ViewCell vcDate = new ViewCell { View = datePicker };
            EntryCell ecComment = new EntryCell { Label = "Comment:" };
            EntryCell ecGame = new EntryCell { Label = "Game:" };
            SwitchCell scWin = new SwitchCell { Text = "Win?" };

            TableView tvAddMatch = new TableView { Intent = TableIntent.Form };
            TableSection section = new TableSection("Add Match") { vcDate, ecComment, ecGame, scWin };

            tvAddMatch.Root = new TableRoot() { section };

            Button saveBtn = new Button { Text = "Save" };

            StackLayout stkAddLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = { tvAddMatch, saveBtn }
            };

            StackLayout stackLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = { stkMatches, stkAddLayout } 
            };


            Content = stackLayout;
        }
    }
    public class MatchCell : ViewCell
    {
        public const int RowHeight = 150;

        public MatchCell()
        {
            
            Label lblFirst = new Label { Text = "firstname" };
            Label lblLast = new Label { Text = "lastname" };
            Label lblDate = new Label { FontAttributes = FontAttributes.Italic };
            Label lblGameType = new Label();
            Label lblComments = new Label();
            Switch swWin = new Switch();

            lblFirst.SetBinding(Label.TextProperty, "OpponentFirstName");
            lblLast.SetBinding(Label.TextProperty, "OpponentLastName");
            lblDate.SetBinding(Label.TextProperty, new Binding("Date", BindingMode.Default, new DateConverter()));
            lblGameType.SetBinding(Label.TextProperty, "GameName");
            lblComments.SetBinding(Label.TextProperty, "Comments");
            //swWin.SetBinding(Switch, true);


            StackLayout stkName = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { lblFirst, lblLast }
            };

            StackLayout stkLeft = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = { stkName, lblDate, lblGameType }
            };
            StackLayout stkRight = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = { lblComments, swWin }
            };

            StackLayout stkBase = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = { stkLeft, stkRight }
            };

            View = stkBase;
        }
    }

    public class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime date = (DateTime)value;
            return date.ToString("dddd, MMMM dd, yyyy");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}