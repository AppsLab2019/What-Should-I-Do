using System.Collections.ObjectModel;
using System.Windows.Input;
using What_Should_I_Do.Models;
using Xamarin.Forms;

namespace What_Should_I_Do.ViewModels
{
    public sealed class MainViewModel
    {
        public ObservableCollection<Reminder> Reminders => App.Reminders;

        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }

        public MainViewModel()
        {
            AddCommand = new Command(HandleAdd);
            DeleteCommand = new Command<Reminder>(HandleDelete);
        }

        private async void HandleAdd()
        {
            var nav = (NavigationPage)Application.Current.MainPage;
            await nav.PushAsync(new AddItemPage());
        }

        private async void HandleDelete(Reminder reminder)
        {
            await App.Database.DeleteNoteAsync(reminder);
            Reminders.Remove(reminder);
        }
    }
}
