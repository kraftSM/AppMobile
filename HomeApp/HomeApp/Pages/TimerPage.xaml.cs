using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using HomeApp.Pages;
using System.ComponentModel;
using static System.Net.Mime.MediaTypeNames;
//using Xamarin.Forms.PlatformConfiguration.iOSSpecific;



namespace HomeApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimerPage : ContentPage
    {
        public const string TIMER_SET_BUTTON_TEXT = "Установить Будильник";
        public const string TIMER_CAN_BUTTON_TEXT = "Отменить установку";
        
        public const string TimerDateFormat = "yyyy/MMM/dd dddd";
        public const string TimerTimeFormat = "HH:mm";

        public const string TimerDtTmMessageFormat = "dd-MMM-yyyy HH:mm dddd";
        public static DateTime TimerSetParams; // 
        private static string TimerInfo;
        private static string TimerMessage;
        public TimerPage()
        {
            InitializeComponent();
            GetContent();
        }
        public void GetContent()
        {
            TimerSetParams = DateTime.Now ;
            TimerMessage = "Timer Message for USER...";
            TimerInfo = "Timer Info ...";

            // Date viget
            var datePicker = new DatePicker
            {
                //Format = "d",
                Format = TimerDateFormat,
                // Диапазон дат: +21/-1 день
                Date = TimerSetParams,
                MaximumDate = TimerSetParams.AddDays(21),
                MinimumDate = TimerSetParams.AddDays(-1)                
            };
            var datePickerText = new Label { Text = "Дата запуска " + TimerSetParams.Date.ToString(TimerDateFormat),  VerticalOptions = LayoutOptions.StartAndExpand };//Margin = new Thickness(0, 10, 0, 0),
                      
            // Time viget                      
            var timePicker = new TimePicker
            {
                Format = TimerTimeFormat,
                //Time = new TimeSpan(13, 0, 0) //Время в Andriod Simulator не совпадает с реальным ...
                Time = TimerSetParams.AddMinutes(10).TimeOfDay
            };
            var timePickerText = new Label { Text = "Время  запуска " + timePicker.Time.ToString() };//, Margin = new Thickness(0, 10, 0, 0)

            // Switch переключатель
            var switchHeader = new Label { Text = "Срабатывать однократно", HorizontalOptions = LayoutOptions.Center};
            Switch switchControl = new Switch
            {
                //ThumbColor = Color.DodgerBlue,
                //OnColor = Color.LightSteelBlue,
                IsToggled = false
            };

            // timerInfo Elements
            var timerInfo = new Entry  {Placeholder = "Type " + TimerInfo + " ... "};//Text = TimerInfo ,     
            var timerMessage = new Editor
            {
                HeightRequest = 80,
                WidthRequest = 800,
                MinimumWidthRequest = 300,     
                Placeholder = "Type " + TimerMessage + " ... "
            };

            //Buttons
            //BackgroundColor = Color.Silver, Margin = new Thickness(0, 5, 0, 0) // заданы через Global Style in <ResourceDictionary>
            var bt_TimeSet = new Button { Text = TIMER_SET_BUTTON_TEXT };
            var bt_TimeClr = new Button { Text = TIMER_CAN_BUTTON_TEXT };
            //Slider
            Slider slider = new Slider
            {
                //ThumbColor = Color.DodgerBlue,
                //MinimumTrackColor = Color.DodgerBlue,
                //MaximumTrackColor = Color.Gray,
                Minimum = 0,
                Maximum = 1.0,
                Value = 0.50
                
            };
            var sliderText = new Label { Text = $"Уровень сигнала: {slider.Value*100} %", HorizontalOptions = LayoutOptions.Center };

     #region Build Layout 
            //Build Screen Layout // Добавляем всё на страницу
            //stackLayout.Children.Add(new Label { Text = "Устройство" });
            //stackLayout.Children.Add(new Entry { BackgroundColor = Color.AliceBlue, Text = "Холодильник" });

            //Add timePicker [label + viget]
            stackLayout.Children.Add(timePickerText);
            stackLayout.Children.Add(timePicker);
            //Add Config fields             
            stackLayout.Children.Add(switchHeader);
            stackLayout.Children.Add(switchControl);
            //Add datePicker [label + viget]
            stackLayout.Children.Add(datePickerText);
            stackLayout.Children.Add(datePicker);
            //Add Level Config fields   
            stackLayout.Children.Add(sliderText);
            stackLayout.Children.Add(slider);
            //Add Info fields            
            stackLayout.Children.Add(timerInfo);
            stackLayout.Children.Add(timerMessage);
            //Add Buttons
            stackLayout.Children.Add(bt_TimeSet); 
            stackLayout.Children.Add(bt_TimeClr);
    #endregion

            // Регистрируем обработчики событий
            datePicker.DateSelected += (sender, e) => DateSelectedHandler(sender, e, datePickerText, datePicker);            
            timePicker.PropertyChanged += (sender, e) => TimeChangedHandler(sender, e, timePickerText, timePicker);
            bt_TimeSet.Clicked += (sender, e) => bt_TimeSet_Click(sender, e);
            bt_TimeClr.Clicked += (sender, e) => bt_TimeClr_Click(sender, e);
            switchControl.Toggled += (sender, e) => SwitchHandler(sender, e, switchHeader);
            slider.ValueChanged += (sender, e) => TimerLevelChangedHandler(sender, e, sliderText);
        }
        private void TimerLevelChangedHandler(object sender, ValueChangedEventArgs e, Label header)
        {
            header.Text =  String.Format("Уровень сигнала: {0:P2}", e.NewValue);                
        }
        public void SwitchHandler(object sender, ToggledEventArgs e, Label header)
        {
            if (!e.Value)
            {
                //header.Text = "Срабатывать однократно";
                //header.TextColor = Color.DimGray;
                header.TextColor = Color.Black;
                return;
            }
            else {
                //header.Text = "Срабатывать ежедневно";
                header.TextColor= Color.DodgerBlue; 
            } 
        }
        public void DateSelectedHandler(object sender, DateChangedEventArgs e, Label datePickerText, DatePicker datePicker)
        {
            // При срабатывании выбора - будет меняться информационное сообщение.
            TimerSetParams = new DateTime(datePicker.Date.Year, datePicker.Date.Month, datePicker.Date.Day, TimerSetParams.Hour, TimerSetParams.Minute, 0);
            datePickerText.Text = "Запустится " + TimerSetParams.ToString(TimerDateFormat);
            //datePickerText.Text = "Запустится " + e.NewDate.ToString(TimerDateFormat);

        }
        public void TimeChangedHandler(object sender, PropertyChangedEventArgs e, Label timePickerText, TimePicker timePicker)
        {
            // Обновляем текст сообщения, когда появляется новое значение времени
            if (e.PropertyName == "Time") {
                TimerSetParams = new DateTime(TimerSetParams.Year, TimerSetParams.Month, TimerSetParams.Day, timePicker.Time.Hours, timePicker.Time.Minutes,0);
                //timePickerText.Text = "В " + timePicker.Time.ToString();
                //timePickerText.Text = "В " + TimerSetParams.TimeOfDay.ToString();
                timePickerText.Text = "Время запуска: " + TimerSetParams.ToString("HH:mm");
            }
            
        }
        private void bt_TimeSet_Click(object sender, EventArgs e)
        {
            //StatusMessage.Text = $" Testig_Click data  in progress...";
            //App.Current.MainPage = new TestingPage();
            //TimerSetParamsInfo = "Дата запуска " + TimerSetParams.Date.ToString(TimerDateFormat);
            DisplayAlert("Внимание!", "Сейчас \n\t" + DateTime.Now.ToString(TimerDtTmMessageFormat) + "\nБудильник установлен  на \n\t" + TimerSetParams.ToString(TimerDtTmMessageFormat), "OK");
            Navigation.PopAsync();

        }
        private void bt_TimeClr_Click(object sender, EventArgs e)
        {
            //StatusMessage.Text = $" Testig_Click data  in progress...";
            //App.Current.MainPage = new TestingPage();
            DisplayAlert("Внимание!", "Будильник не установлен", "OK");
            Navigation.PopAsync();

        }
        
    }
}