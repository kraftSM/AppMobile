using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using HomeApp.Pages;

namespace HomeApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        // Константs для текста кнопок
        public const string TIMER_BUTTON_TEXT = "Установить Будильник";
        public const string WEATHER_BUTTON_TEXT = "Получить данные о погоде";
        public const string STATUS_MESSAGE_TEXT = "Hi! It's you again";
        public WelcomePage()
        {
            InitializeComponent();
        }
        private void SetTimer_Click(object sender, EventArgs e)
        {
            StatusMessage.Text = $"  Setting Timer  in progress...";
            //App.Current.MainPage = new TimerPage();
            Navigation.PushAsync(new TimerPage());
        }
        private void GetWeather_Click(object sender, EventArgs e)
        {
            StatusMessage.Text = $"Get Weather data  in progress...";
            //App.Current.MainPage = new WeatherPage();
            Navigation.PushAsync(new WeatherPage());

        }
        private void Test_Click(object sender, EventArgs e)
        {
            StatusMessage.Text = $" Testig_Click data  in progress...";
            //App.Current.MainPage = new TestingPage();
            Navigation.PushAsync(new TestingPage());

        }
    }
}