using System;
using System.Windows.Input;
using What_Should_I_Do.Models;
using Xamarin.Forms;

namespace What_Should_I_Do.ViewModels
{
    public sealed class AddItemViewModel
    {
        public Reminder Reminder { get; }
        public ICommand AddCommand { get; }

        public AddItemViewModel()
        {
            Reminder = new Reminder
            {
                Date = DateTime.Now
            };

            AddCommand = new Command(HandleAdd);
        }

        private async void HandleAdd()
        {
            try
            {
                await App.Database.SaveNoteAsync(Reminder);

                // store replacement
                App.Reminders.Add(Reminder);

                await Shell.Current.Navigation.PopAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
