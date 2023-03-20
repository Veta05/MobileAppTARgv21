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
    public partial class Frame_Page : ContentPage
    {
        Frame fr;
        Label lbl;
        Grid gr;
        public Frame_Page()
        {
            lbl = new Label
            {
                Text = "Border design",
                FontSize = Device.GetNamedSize(NamedSize.Subtitle, typeof(Label))
            };

            gr = new Grid
            {
                //RowDefinitions =
                //{
                //    new RowDefinition{Height=new GridLength(2,GridUnitType.Star)},
                //    new RowDefinition{Height=new GridLength(1,GridUnitType.Star)},
                //    new RowDefinition{Height=new GridLength(1,GridUnitType.Star)}
                //},
                //ColumnDefinitions =
                //{
                //    new ColumnDefinition{Width = new GridLength(1, GridUnitType.Star)},
                //    new ColumnDefinition{Width = new GridLength(1, GridUnitType.Star)}
                //}

                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            //gr.Children.Add(new BoxView { Color = Color.Blue }, 0, 0);
            //gr.Children.Add(new BoxView { Color = Color.Green }, 1, 0);
            //gr.Children.Add(new BoxView { Color = Color.Red }, 0, 1);
            //gr.Children.Add(new BoxView { Color = Color.YellowGreen }, 1, 1);
            //gr.Children.Add(new BoxView { Color = Color.Purple }, 0, 2);
            //gr.Children.Add(new BoxView { Color = Color.Pink }, 1, 2);

            int r = 0, g = 0, b = 0;
            Random rnd = new Random();

            List<int> widths = new List<int> { (int)DeviceDisplay.MainDisplayInfo.Height/20, (int)
                (DeviceDisplay.MainDisplayInfo.Height)/40, (int)DeviceDisplay.MainDisplayInfo.Height/20};
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    r = rnd.Next(0, 255);
                    g = rnd.Next(0, 255);
                    b = rnd.Next(0, 255);
                    gr.RowDefinitions.Add(new RowDefinition { Height = new GridLength(widths[i]) });
                    gr.Children.Add(new BoxView
                    {
                        Color = Color.FromRgb(r, g, b),
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                    }, j, i);
                }
                gr.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }

            fr = new Frame
            {
                Content=gr,
                BorderColor = Color.Violet,
                CornerRadius = 20,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            StackLayout st = new StackLayout
            {
                Children = { lbl, fr }
            };
            Content = st;
        }
    }
}