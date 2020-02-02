using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HebNavi
{
    public partial class App : Application
    {
        static HebrewDatabase database;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }
        public static HebrewDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new HebrewDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "HebrewSQLite.db3"));
                }
                return database;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
