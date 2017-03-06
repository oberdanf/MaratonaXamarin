using Xamarin.Forms;
using System;

namespace MaratonaXamarin
{
    public partial class DetailsPage : ContentPage
    {
        private readonly Cat selectedCat;

        public DetailsPage(Cat cat)
        {
            InitializeComponent();
            this.selectedCat = cat;
            BindingContext = this.selectedCat;
            Title = this.selectedCat.Name;
        }

        private void OnButtonWebsiteClicked(object sender, EventArgs args)
        {
            if (this.selectedCat.WebSite.StartsWith("http", StringComparison.OrdinalIgnoreCase))
            {
                Device.OpenUri(new Uri(this.selectedCat.WebSite));
            }
        }
    }
}
