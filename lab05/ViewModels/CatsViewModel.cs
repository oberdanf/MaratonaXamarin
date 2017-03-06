using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MaratonaXamarin
{
    public class CatsViewModel : INotifyPropertyChanged
    {
        private bool isBusy;

        private readonly Repository repository;

        public event PropertyChangedEventHandler PropertyChanged;

        public CatsViewModel()
        {
            Cats = new ObservableCollection<Cat>();
            this.repository = new Repository();
            GetCatsCommand = new Command(async () => await GetCatsAsync(), () => !IsBusy);
        }

        public bool IsBusy
        {
            get
            {
                return this.isBusy;
            }

            set
            {
                this.isBusy = value;
                OnPropertyChanged();
                GetCatsCommand.ChangeCanExecute();
            }
        }

        public ObservableCollection<Cat> Cats { get; set; }

        public Command GetCatsCommand { get; set; }

        private async Task GetCatsAsync()
        {
            if (!IsBusy)
            {
                try
                {
                    IsBusy = true;
                    var cats = await this.repository.GetCats();
                    Cats.Clear();

                    foreach (var cat in cats)
                    {
                        Cats.Add(cat);
                    }
                }
                catch (Exception ex)
                {
                    await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
                }
                finally
                {
                    IsBusy = false;
                }
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
