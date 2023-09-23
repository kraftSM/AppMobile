using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestingPage : ContentPage
    {
        public TestingPage()
        {
            InitializeComponent();
        }
        
        private void TabPage_Click(object sender, EventArgs e)
        {
            //StatusMessage.Text = $" Testig_Click data  in progress...";
            //App.Current.MainPage = new TestingPage();
            Navigation.PushAsync(new TabPage());

        }

    }
}