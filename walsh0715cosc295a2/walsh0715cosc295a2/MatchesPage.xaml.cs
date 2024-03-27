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
        public string fullName;
        public int counter;

        public MatchesPage(Opponent opp)
        {
            Title = "Matches";

            fullName = opp.FirstName + " " + opp.LastName;

            currentOpp = App.OppDatabase.GetOpponent(opp.ID);
            

            List<Match> matches = App.MatchesDatabase.GetMatchesByID(opp.ID);

            ListView lvMatches = new ListView
            {
                ItemsSource = matches.Select(match => new
                {
                    Match = match,
                    FullName = $"{opp.FirstName} {opp.LastName}",
                    GameName = App.GamesDatabase.GetGame(match.GameID)?.GameName
                }).ToList(),
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
        public const int RowHeight = 110;

        public MatchCell()
        {

            
            Label lblFullName = new Label { FontSize = 20 };
            Label lblDate = new Label { FontSize = 18, FontAttributes = FontAttributes.Italic };
            Label lblGameType = new Label { FontSize = 18 };
            Label lblComments = new Label { FontSize = 16 };
            Label lblWin = new Label { FontSize = 18, Text = "Win?" };
            Switch swWin = new Switch();

            lblFullName.SetBinding(Label.TextProperty, "FullName");
            lblDate.SetBinding(Label.TextProperty, new Binding("Match.Date", BindingMode.Default, new DateConverter()));
            lblGameType.SetBinding(Label.TextProperty, "GameName");
            lblComments.SetBinding(Label.TextProperty, "Match.Comments");
            //swWin.SetBinding(Switch, true);


            StackLayout stkWin = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,
                Children = {lblWin, swWin }
            };

            StackLayout stkLeft = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                WidthRequest = 350,
                Children = { lblFullName, lblDate, lblGameType }
            };
            StackLayout stkRight = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.End,
                WidthRequest = 150,
                Children = { lblComments, stkWin }
            };

            StackLayout stkBase = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(20,10,10,10),
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