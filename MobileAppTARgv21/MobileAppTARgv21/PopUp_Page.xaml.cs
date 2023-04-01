using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileAppTARgv21
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopUp_Page : ContentPage
    {
        Button alertListButton;
        public PopUp_Page()
        {
            Button alertButton = new Button
            {
                Text = "Teade",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center
            };
            alertButton.Clicked += AlertButton_Clicked;

            Button alertYesNoButton = new Button
            {
                Text = "Jah või ei",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center
            };
            alertYesNoButton.Clicked += AlertYesNoButton_Clicked;

            alertListButton = new Button
            {
                Text = "Valik",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center
            };
            alertListButton.Clicked += AlertListButton_Clicked;

            Button alertQuestButton = new Button
            {
                Text = "Küsimus",
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Center
            };
            alertQuestButton.Clicked += AlertQuestButton_Clicked;

            Content = new StackLayout
            {
                Children = { alertButton, alertYesNoButton, alertListButton, alertQuestButton }
            };
        }

        private async void AlertQuestButton_Clicked(object sender, EventArgs e)
        {
            //string result1 = await DisplayPromptAsync("Küsimus", "Kuidas läheb?", placeholder: "Tore");
            //string result2 = await DisplayPromptAsync("Vasta", "Millega võrdub 5 + 5?", initialValue: "10", maxLength: 2, keyboard: Keyboard.Numeric);

            string result = await DisplayPromptAsync("Küsimus", "Mis päev täna on?", "Ok", "Cancel", "Siia kirjuta nimetus", keyboard: Keyboard.Chat);
            string result2 = await DisplayPromptAsync("Teine küsimus", "Millega võrdub 2+2?", "Vastan", "Ei vasta", initialValue: "4", maxLength: 3, keyboard: Keyboard.Numeric);
        }

        private async void AlertListButton_Clicked(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("Lemmik värv?", "Loobu", "Kinnita", "Sinine", "Punane", "Kollane");
            if (action == "Sinine")
            {
                alertListButton.BackgroundColor = Color.Blue;
            }
            else if (action == "Punane")
            {
                alertListButton.BackgroundColor = Color.Red;
            }
            else if (action == "Kollane")
            {
                alertListButton.BackgroundColor = Color.Yellow;
            }
        }

        private async void AlertYesNoButton_Clicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Kinnitus", "Kas oled kindel?", "Olen kindel", "Ei ole kindel");
            await DisplayAlert("Teade", "Teie valik on: " + (result ? "Jah" : "Ei"), "OK");
        }

        private void AlertButton_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Teade", "Teil on uus teade", "OK");
        }
    }
}