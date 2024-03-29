﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileAppTARgv21
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Start_Page : ContentPage
    {
        List<ContentPage> pages = new List<ContentPage>() 
        { new Editor_Page(), new Timer_Page(), new Box_Page(), new TrafficLight_Page(), new DateTime_Page(), new StepperSlider_Page(),
        new ColorSlider_Page(), new Image_Page(), new Frame_Page(), new PopUp_Page(), new Riddles_Page(), new Table_Page(), new Picker_Page(),
        new File_Page(), new Cats_Page()};

        List<string> texts = new List<string>
        { "Editor Page", "Timer Page", "Box Page", "Traffic Light Page", "Date/Time Page", "Stepper slider Page",
            "Color Slider Page", "Image Pgae", "Frame Page", "PopUp Page", "Riddle Page", "Table Page", "Picker Page", "File Page", "Cats page"};
        Random random = new Random();
        StackLayout st;
        public Start_Page()
        {
            st = new StackLayout();
            for (int i = 0; i < pages.Count; i++)
            {
                Button button = new Button
                {
                    Text = texts[i],
                    BackgroundColor = Color.FromRgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255)),
                    TabIndex= i
                };
                st.Children.Add(button);
                button.Clicked += Button_Clicked;
            }
            ScrollView scrollView = new ScrollView { Content=st};
            Content = scrollView;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Button b = sender as Button;
            await Navigation.PushAsync(pages[b.TabIndex]);
        }
    }
}