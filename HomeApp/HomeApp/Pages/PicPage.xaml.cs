using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HomeApp.Models;

namespace HomeApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PicPage : ContentPage
	{
		public PicPage(PicInfo pictureInfo)
		{
			InitializeComponent();
			this.BindingContext = pictureInfo;			
		}
	}
}