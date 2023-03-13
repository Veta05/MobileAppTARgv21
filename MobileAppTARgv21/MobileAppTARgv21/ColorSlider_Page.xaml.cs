using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static System.Net.WebRequestMethods;

namespace MobileAppTARgv21
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ColorSlider_Page : ContentPage
    {
        BoxView box;
        Slider sliderRed;
        Slider sliderGreen;
        Slider sliderBlue;

        Label labelRed;
        Label labelGreen;
        Label labelBlue;
        Label labelOpacity;
        Stepper stepper;
        public ColorSlider_Page()
        {

            labelRed = new Label();
            labelGreen = new Label();
            labelBlue = new Label();
            labelOpacity = new Label();

            stepper = new Stepper
            {
                Minimum = 0,
                Maximum = 255,
                Increment = 5,
                Value = 255,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.EndAndExpand
            };
            stepper.ValueChanged += OnSlideValueChanged;

            sliderRed = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 50,
                MinimumTrackColor = Color.DarkRed,
                MaximumTrackColor = Color.Red
            };
            sliderRed.ValueChanged += OnSlideValueChanged;


            sliderGreen = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 50,
                MinimumTrackColor = Color.Green,
                MaximumTrackColor = Color.DarkGreen
            };
            sliderGreen.ValueChanged += OnSlideValueChanged;

            sliderBlue = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 50,
                MinimumTrackColor = Color.BlueViolet,
                MaximumTrackColor = Color.Blue
            };
            sliderBlue.ValueChanged += OnSlideValueChanged;

            box = new BoxView
            {
                Color = Color.LightPink,
                WidthRequest = 500,
                HeightRequest = 500,
                HorizontalOptions = LayoutOptions.Center,
            };

            StackLayout stack = new StackLayout
            {
                Children = { box, sliderRed, labelRed, sliderGreen, labelGreen, sliderBlue, labelBlue, stepper, labelOpacity}
            };
            stack.BackgroundColor = Color.White;
            Content = stack;

            //AbsoluteLayout abs = new AbsoluteLayout { Children = { box, sliderRed, sliderGreen, sliderBlue } };

            //AbsoluteLayout.SetLayoutBounds(box, new Rectangle(0.4, 0.4, 300, 300));
            //AbsoluteLayout.SetLayoutFlags(box, AbsoluteLayoutFlags.PositionProportional);

            //AbsoluteLayout.SetLayoutBounds(sliderRed, new Rectangle(0.4, 0.7, 500, 100));
            //AbsoluteLayout.SetLayoutFlags(sliderRed, AbsoluteLayoutFlags.PositionProportional);

            //AbsoluteLayout.SetLayoutBounds(sliderGreen, new Rectangle(0.4, 0.8, 500, 100));
            //AbsoluteLayout.SetLayoutFlags(sliderGreen, AbsoluteLayoutFlags.PositionProportional);

            //AbsoluteLayout.SetLayoutBounds(sliderBlue, new Rectangle(0.4, 0.9, 500, 100));
            //AbsoluteLayout.SetLayoutFlags(sliderBlue, AbsoluteLayoutFlags.PositionProportional);

            //Content = abs;

        }

        private void OnSlideValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (sender == sliderRed)
            {
                labelRed.Text = String.Format("Red = {0:X2}", (int)e.NewValue);
            }
            else if (sender == sliderGreen)
            {
                labelGreen.Text = String.Format("Green = {0:X2}", (int)e.NewValue);
            }
            else if (sender == sliderBlue)
            {
                labelBlue.Text = String.Format("Blue = {0:X2}", (int)e.NewValue);
            }
            else if (sender == stepper)
            {
                labelOpacity.Text = String.Format("Alpha = {0:X2}", (int)e.NewValue);
            }

            box.Color = Color.FromRgba((int)sliderRed.Value,
                                      (int)sliderGreen.Value,
                                      (int)sliderBlue.Value,
                                      (int)stepper.Value);

        }
    }
}