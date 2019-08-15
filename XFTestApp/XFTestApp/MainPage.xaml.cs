using FFImageLoading.Forms;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFTestApp
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Photo> Images { get; } = new ObservableCollection<Photo>();

        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            listView.ItemsSource = Images;
            GetAllPhotos();
        }
        void OnImageTapped(object sender, EventArgs args)
        {
            var image = sender as CachedImage;
            CreatePage(image.Source.ToString().Split()[1]);
        }

        private async Task TestAsync()
        {
            var nsAPI = RestService.For<IFlickrGetPhotos>("https://www.flickr.com");
            var photos = await nsAPI.GetPhotos("332d3e2c43b98037fe8566ec57790b8b", "01-01-2000");
            List<Photo> list = photos.Photoss.PhotoList;
            list.ForEach(a => {
                a.Link = $"https://farm{a.Farm}.staticflickr.com/{a.Server}/{a.Id}_{a.Secret}.jpg";
                Images.Add(a);
            });
            
        }

        private async void GetAllPhotos() {
            await TestAsync();
        }

        private async void CreatePage(string imageLink) {
            string s = imageLink;
            await Navigation.PushAsync(new ImageFullScreen(imageLink));
        }
    }
}
