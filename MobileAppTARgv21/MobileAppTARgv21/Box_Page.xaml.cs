using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileAppTARgv21
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Box_Page : ContentPage
    {
        BoxView box;
        
        public Box_Page()
        {
            int r = 0, g = 0, b = 0;

            box = new BoxView
            {
                Color= Color.FromRgb(r,g,b),
                CornerRadius=20,
                WidthRequest=200, HeightRequest=300,
                HorizontalOptions=LayoutOptions.Center,
            };
            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Tap_Tapped;
            box.GestureRecognizers.Add(tap); //связан с распознованием жестов
            Content = new StackLayout { Children = { box } };
        }

        Random rnd = new Random();
        private void Tap_Tapped(object sender, EventArgs e)
        {
            box.Color= Color.FromRgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0,255));
            box.WidthRequest = box.Width + 10;
            box.HeightRequest= box.Height + 10;
            //Что бы не выходил за пределы дисплея
            if (box.HeightRequest>(int)DeviceDisplay.MainDisplayInfo.Height/5)
            {
                box.HeightRequest = 300;
                box.WidthRequest = 200;
            }
        }

        private async void back_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}