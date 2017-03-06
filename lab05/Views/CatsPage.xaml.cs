using Xamarin.Forms;

namespace MaratonaXamarin
{
    public partial class CatsPage : ContentPage
    {
        public CatsPage()
        {
            InitializeComponent();
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var cat = args.SelectedItem as Cat;
            if (cat != null)
            {
                await Navigation.PushAsync(new DetailsPage(cat));
            }

            this.listViewCats.SelectedItem = null;
        }
    }
}
