using walsh0715cosc295a2.db;
using Xamarin.Forms;

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

            NavigationPage page = new NavigationPage(new OpponentsPage());

            MainPage = page;
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
