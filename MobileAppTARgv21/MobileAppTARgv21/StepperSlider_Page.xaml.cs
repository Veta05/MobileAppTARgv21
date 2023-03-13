using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileAppTARgv21
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StepperSlider_Page : ContentPage
    {
        Stepper stp;
        Slider sld;
        Label lbl;
        public StepperSlider_Page()
        {

            stp = new Stepper
            {
                Minimum = 0,
                Maximum = 100,
                Value = 50,
                Increment = 5
            };
            stp.ValueChanged += Stp_ValueChanged;

            lbl = new Label
            {
                Text = "TTHK",
                FontSize = stp.Value
            };

            sld = new Slider
            {
                Minimum = stp.Minimum,
                Maximum = stp.Maximum,
                Value = stp.Value,
                MinimumTrackColor = Color.Aquamarine,
                MaximumTrackColor= Color.Blue
            };
            sld.ValueChanged+= Stp_ValueChanged;

            AbsoluteLayout abs = new AbsoluteLayout { Children = { stp, sld, lbl } };

            AbsoluteLayout.SetLayoutBounds(lbl, new Rectangle(0.4, 0.4, 200, 100));
            AbsoluteLayout.SetLayoutFlags(lbl, AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(sld, new Rectangle(0.5, 0.6, 200, 100));
            AbsoluteLayout.SetLayoutFlags(sld, AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(stp, new Rectangle(0.6, 0.8, 200, 100));
            AbsoluteLayout.SetLayoutFlags(stp, AbsoluteLayoutFlags.PositionProportional);

            
            Content = abs;
        }

        private void Stp_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            lbl.FontSize = e.NewValue;
        }
    }
}