using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;
using static Xamarin.Essentials.Permissions;
using ListView = Xamarin.Forms.ListView;

namespace walsh0715cosc295a2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewOppPage : ContentPage
    {
        public AddNewOppPage()
        {
            InitializeComponent();

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
                App.OppDatabase.SaveOpponent(opp);

                MessagingCenter.Send(this, "DatabaseUpdated");

                Navigation.PopAsync();


            };

            StackLayout stackLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = { tvNewOpp, btnSaveNew }
            };

            Content = stackLayout;
        }
    }
}