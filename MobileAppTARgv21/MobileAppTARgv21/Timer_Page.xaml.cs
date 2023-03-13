using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileAppTARgv21
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Timer_Page : ContentPage
    {
        public Timer_Page()
        {
            InitializeComponent();
        }

        int i = 0;
        private async void ShowTime()
        {
            while (true)
            {
                lbl.Text = DateTime.Now.ToString("T");
                await Task.Delay(1000);
            }
        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            i++;
            lbl.Text = "Clicked " + i.ToString() + " times";
            if(i==10)
            {
                ShowTime();
            }
            else
            {
                lbl.Text = "Clicked " + i.ToString() + "times";
            }
        }

        private async void Back_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }


    }
}