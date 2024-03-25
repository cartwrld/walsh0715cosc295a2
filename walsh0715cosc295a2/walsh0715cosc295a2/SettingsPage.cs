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
            Content = new StackLayout
            {
                Children = {
                    new StackLayout 
                    {
                        Orientation = StackOrientation.Vertical,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        Children = { new Label { Text = "Reset Game Data" }, new Button { Text = "Reset" } }
                    }
                }
            };
        }
    }
}