using NumbersApi.Data;
using System;
using System.IO;
using Xamarin.Forms;

namespace NumbersApi
{
    public partial class App : Application
    {
        static Database _notesDB;

        public static Database Database
        {
            get
            {
                if (_notesDB is null)
                {
                    _notesDB = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "NotesDB.db3"));
                }
                return _notesDB;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
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
}
