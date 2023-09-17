using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace HomeApp.Pages
{
    class LoadingPage : ContentPage
    {
        public LoadingPage()
        {
            // Объявим новый текстовый элемент
            Label header = new Label() { Text = $"Загрузка моего 1-го приложения{Environment.NewLine} на Xamarin... для Гришки!!!! " };

            // Здесь можно сразу установить стили и шрифт
            header.Opacity = 0;
            header.HorizontalTextAlignment = TextAlignment.Center;
            header.VerticalTextAlignment = TextAlignment.Center;
            header.FontSize = 21;
            // Можем даже задать анимацию
            header.FadeTo(1, 5000);

            // Инициализация свойства Content новым элементом.
            Content = header;

            //header.Text = $"Приложени загружено...";


        }
    }
}
