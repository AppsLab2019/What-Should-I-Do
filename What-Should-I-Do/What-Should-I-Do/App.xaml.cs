using System;
using System.Collections.ObjectModel;
using System.IO;
using What_Should_I_Do.Database;
using What_Should_I_Do.Models;
using Xamarin.Forms;

namespace What_Should_I_Do
{
    public partial class App : Application
    {
        public static ReminderDatabase Database { get; private set; }

        // store replacement
        public static ObservableCollection<Reminder> Reminders { get; private set; }

        public App()
        {
            var localFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var dbPath = Path.Combine(localFolder, "Notes.db3");
            Database = new ReminderDatabase(dbPath);

            var loadedReminders = Database.GetNotesAsync().Result;
            Reminders = new ObservableCollection<Reminder>(loadedReminders);

            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
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
