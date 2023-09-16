using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Text;

namespace HomeApp
{
    class LoadingPage : ContentPage
    {
        public LoadingPage()
        {
            // Объявим новый текстовый элемент
            Label header = new Label() { Text = $"Запуск моего 1-го приложения{Environment.NewLine} на Xamarin... для Гришки!!!! " };

            // Здесь можно сразу установить стили и шрифт
            header.Opacity = 0;
            header.HorizontalTextAlignment = TextAlignment.Center;
            header.VerticalTextAlignment = TextAlignment.Center;
            header.FontSize = 21;
            // Можем даже задать анимацию
            header.FadeTo(1, 3000);

            // Инициализация свойства Content новым элементом.
            this.Content = header;
        }
    }
}
