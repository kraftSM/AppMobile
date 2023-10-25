using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HomeApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {   
        // Константs для текста кнопки
        public const string BUTTON_TEXT = "Войти";
        public const string PIN_TEXT_ENTRY = "Введите пин-код для входа:";
        public const string PIN_TEXT_ERROR = "Неверный ПИН-код";
        public const string PIN_TEXT_LEN_ERROR = " символа требуется в ПИН-коде";
        public const int PIN_LEN = 4;
        private string _pin; //4321
        // Переменная счетчика
        public static int loginCounter = 0;
       
        public LoginPage()
        {
            InitializeComponent();
            _pin = Preferences.Get("Password", String.Empty);
            if (_pin != string.Empty)
            {
                lgMessage.Text = PIN_TEXT_ENTRY;                
            }
        }
        //private void Login_Click(object sender, EventArgs e)
        //{
        //    loginButton.Text = "Выполняется вход d ...";
        //    //string xaml = "<Button Text=\"⌛ Выполняется вход..\"  />";
        //    //loginButton.LoadFromXaml(xaml);
        //}
        /// <summary>
        /// По клику обрабатываем счётчик и выводим разные сообщения
        /// </summary>
        //private void Login_Click(object sender, EventArgs e)
        //{
        //    if (loginCounter == 0)
        //    {
        //        // Если первая попытка - просто меняем сообщения
        //        loginButton.Text = $"Выполняется вход..";
        //    }
        //    else if (loginCounter > 5) // Слишком много попыток - показываем ошибку
        //    {
        //        // Деактивируем кнопку
        //        loginButton.IsEnabled = false;
        //        // Показываем текстовое сообщение об ошибке
        //        lgMessage.Text = $"Слишком много попыток! Попробуйте позже. Попыток входа: {loginCounter}";
        //    }
        //    else
        //    {
        //        // Изменяем текст кнопки и показываем количество попыток входа
        //        loginButton.Text = $"Выполняется вход...   Попыток входа: {loginCounter}";
        //    }

        //    // Увеличиваем счетчик
        //    loginCounter += 1;
        //}

        private void Login_Click(object sender, EventArgs e)
        {
            string enterPwd = Password.Text;
            if (_pin == string.Empty)
            {
                Preferences.Set("Password", enterPwd);
            }
            else
            {
                if (_pin != Password.Text)
                {
                    string sTxt = PIN_TEXT_ERROR;
                    sTxt.Concat(PIN_LEN.ToString()) ;
                    lgMessage.Text = sTxt;
                    return;
                }
            }

            Navigation.PushAsync(new GalleryPage());
        }

        private void Password_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Password.Text.Length != PIN_LEN)
            {
                lgMessage.Text = PIN_TEXT_LEN_ERROR;
                loginButton.IsEnabled = false;
            }
            else
            {
                loginButton.IsEnabled = true;
                lgMessage.Text = string.Empty;
            }
        }
    }
}