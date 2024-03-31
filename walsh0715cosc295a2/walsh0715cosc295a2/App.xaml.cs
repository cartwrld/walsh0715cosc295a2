using System;
using System.Collections.Generic;
using walsh0715cosc295a2.db;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace walsh0715cosc295a2
{
    public partial class App : Application
    {
        static AppDB appDB;

        public static AppDB AppDB
        {
            get
            {
                if (appDB == null)   // check if database is already connected
                {
                    appDB = new AppDB(DependencyService.Get<IFileHelper>().GetLocalFilePath("AppSQLite.db3"));
                }
                return appDB;
            }
        }
        
        public App()
        {
            InitializeComponent();

            //DeleteDatabases();
            NavigationPage page = new NavigationPage(new OpponentsPage());
            //page.BarBackgroundColor = Color.SlateGray;

            MainPage = page;
        }

        public static void DeselectItem(ListView lv)
        {
            lv.ItemTapped += (sender, e) =>
            {
                ((ListView)sender).SelectedItem = null;
            };
        }


        private void DeleteDatabases()
        {
            DependencyService.Get<IFileHelper>().DeleteLocalFile("AppSQLite.db3");
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }



    public interface IFileHelper
    {
        string GetLocalFilePath(string filename);
        void DeleteLocalFile(string filename);

    }

}
