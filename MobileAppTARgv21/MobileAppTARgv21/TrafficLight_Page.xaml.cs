using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileAppTARgv21
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrafficLight_Page : ContentPage
    {
        BoxView cirkleRed;
        Frame cirkleYellow;
        Frame cirkleGreen;

        public TrafficLight_Page()
        { 
            //TapGestureRecognizer tap_one= new TapGestureRecognizer();
            //TapGestureRecognizer tap_two = new TapGestureRecognizer();
            //TapGestureRecognizer tap_three = new TapGestureRecognizer();
            cirkleRed = new BoxView
            {
                BackgroundColor = Color.Gray,
                CornerRadius = 1000,
                WidthRequest = 100,
                HeightRequest = 100,
                HorizontalOptions = LayoutOptions.Center,
            };
            //tap_one.Tapped += Tap_Tapped_One;
            //cirkleRed.GestureRecognizers.Add(tap_one); //связан с распознованием жестов

            //cirkleYellow = new Frame
            //{
            //    BackgroundColor = Color.Gray,
            //    CornerRadius = 1000,
            //    WidthRequest = 100,
            //    HeightRequest= 100,
            //    HorizontalOptions = LayoutOptions.Center,
            //};
            ////tap_two.Tapped += Tap_Tapped_Two;
            ////cirkleGreen.GestureRecognizers.Add(tap_two); //связан с распознованием жестов

            //cirkleGreen = new Frame
            //{
            //    BackgroundColor = Color.Gray,
            //    CornerRadius = 1000,
            //    WidthRequest = 100,
            //    HeightRequest = 100,
            //    HorizontalOptions = LayoutOptions.Center,
            //};
            //tap_three.Tapped += Tap_Tapped_Three;
            //cirkleGreen.GestureRecognizers.Add(tap_three); //связан с распознованием жестов

            StackLayout stack = new StackLayout
            {
                Children = { cirkleRed}
            };

        }
        //private void Tap_Tapped_One(object sender, EventArgs e)
        //{
        //    BackgroundColor = Color.Red;
        //}
        
        //private void Tap_Tapped_Two(object sender, EventArgs e)
        //{
        //    BackgroundColor = Color.Yellow;
        //}

        //private void Tap_Tapped_Three(object sender, EventArgs e)
        //{
        //    BackgroundColor = Color.Green;
        //}
    }
}