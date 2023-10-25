using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using HomeApp.Models;

namespace HomeApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GalleryPage : ContentPage
    {
        //public ObservableCollection<string> Items { get; set; }

        string path = @"/storage/emulated/0/DCIM/Camera/";
        private ObservableCollection<PicInfo> _pictureList { get; set; }
        private PicInfo _currentPicture;
        public GalleryPage()
        {
            InitializeComponent();
            _pictureList = new ObservableCollection<PicInfo>();
            pictureList.ItemsSource = _pictureList;
            InitializeData();

            //Items = new ObservableCollection<string>
            //{
            //    "Item 1",
            //    "Item 2",
            //    "Item 3",
            //    "Item 4",
            //    "Item 5"
            //};			
			//MyListView.ItemsSource = Items;
        }
        private void InitializeData()
        {
            LoadPictureList();
        }
        private async void LoadPictureList()
        {
            if (Device.RuntimePlatform != Device.Android || !Directory.Exists(path))
                return;

            DirectoryInfo dir = new DirectoryInfo(path);

            var files = dir.GetFileSystemInfos("*.jpg");

            foreach (var file in files)
            {
                _pictureList.Add(new PicInfo(file.Name, file.FullName, file.CreationTime));
            }
        }
        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private void OpenPicrureButton_Clicked(object sender, EventArgs e)
        {
            if (pictureList.SelectedItem is null)
                return;

            Navigation.PushAsync(new PicPage(pictureList.SelectedItem as PicInfo));
        }

        private async void RemovePictureButton_Clicked(object sender, EventArgs e)
        {
            if (pictureList.SelectedItem is null)
                return;
            PicInfo pic = pictureList.SelectedItem as PicInfo;
            var answer = await DisplayAlert("Внимание!", $"Удалить {pic.NameFile}", "Да", "Нет");

            if (answer == false)
            {
                return;
            }

            try
            {
                if (File.Exists(pic.PathToPicture))
                {
                    File.Delete(pic.PathToPicture);
                }
                _pictureList.Remove(pic);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Ошибка!", ex.Message, "OK");
            }
        }
    }
}
