using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileAppTARgv21
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Editor_Page : ContentPage
    {
        Editor editor;
        Button back_btn;
        Label lbl;
        public Editor_Page()
        {
            editor = new Editor
            {
                TextColor = Color.Black,
                Placeholder = "Enter the text",
                BackgroundColor = Color.LightGray,
            };
            editor.TextChanged += Editor_TextChanged;


            lbl = new Label
            {
                Text = "...",
                TextColor= Color.Black,
            };


            back_btn = new Button
            { 
                Text = "Back" 
            };
            back_btn.Clicked += Back_btn_Clicked;


            StackLayout stack = new StackLayout
            { 
                Children= { editor, lbl, back_btn } 
            };
            stack.BackgroundColor = Color.White;
            Content = stack;
        }
        
        //Count, how much A letter you enter
        int i = 0;
        private void Editor_TextChanged(object sender, TextChangedEventArgs e)
        {
            lbl.Text = editor.Text;
            editor.TextChanged -= Editor_TextChanged;
            char key = e.NewTextValue?.LastOrDefault() ?? ' ';
            if (key == 'A' || key == 'a')
            {
                i++;
                lbl.Text = key.ToString() + ": " + i;
            }
            editor.TextChanged += Editor_TextChanged;
        }

        //Back button
        private async void Back_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        
    }
}