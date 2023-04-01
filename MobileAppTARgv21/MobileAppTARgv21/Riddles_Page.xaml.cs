using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static MobileAppTARgv21.Riddles_Page;

namespace MobileAppTARgv21
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Riddles_Page : ContentPage
    {
        Label title;
        Button gameButton;

        public int CorrectAnswers { get; set; }
        public Riddles_Page()
        {

            title = new Label
            {
                Text = "Поиграем в загадки?",
                FontSize = 30,
                Margin = 50,
                TextColor = Color.Black,
                HorizontalOptions = LayoutOptions.Center,
            };

            gameButton = new Button
            {
                Text = "Давай",
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                FontAttributes = FontAttributes.Bold,
                BorderRadius = 20,
                HeightRequest = 50,
                HorizontalOptions = LayoutOptions.Center,
            };
            gameButton.Clicked += GameButton_Clicked;


            Content = new StackLayout
            {
                Children = { title, gameButton}
            };

            
        }

        private async void GameButton_Clicked(object sender, System.EventArgs e)
        {
            string name = await DisplayPromptAsync("Давай познакомимся", "Как тебя зовут?", "Ok", "Отменить", "Введи имя", keyboard: Keyboard.Chat);
            var action = await DisplayActionSheet("Приятно познакомиться, " + name + "! Начнём загадки?", "Нет", "Да");
            if(action == "Да") 
            {
                RiddleGame();
            }
        }

        private async void RiddleGame()
        {
            string[] riddles = new string[]
            {
                "Можно ли слону встать на одну ногу?",
                "Какой лук самый быстрый?",
                "Какого цвета утка?",
                "Что не имеет длины, глубины и высоты, но может быть измерено?"
            };

            int correctAnswers = 0;

            for (int i = 0; i < riddles.Length; i++)
            {
                string riddle = riddles[i];
                string answer = await DisplayPromptAsync("Загадка " + (i + 1), riddle, "Ответ", maxLength: 20);


                if (answer?.ToLower() == "нет")
                {
                    await DisplayAlert("Правильно!", "Слон не может встать на одну ногу", "OK");
                    correctAnswers++;
                }
                else if (answer?.ToLower() == "шалот")
                {
                    await DisplayAlert("Правильно!", "Шалот - самый быстрый лук", "OK");
                    correctAnswers++;
                }
                else if (answer?.ToLower() == "красного")
                {
                    await DisplayAlert("Правильно!", "Утка может быть любого цвета, если ее покрасить в красный цвет", "OK");
                    correctAnswers++;
                }
                else if (answer?.ToLower() == "время")
                {
                    await DisplayAlert("Правильно!", "Время измеримо", "OK");
                    correctAnswers++;
                }
                else
                {
                    await DisplayAlert("Неправильно", "Попробуй в следующий раз", "OK");
                }
            }

            await DisplayAlert("Итого", "Вы ответили правильно на " + correctAnswers + " из " + riddles.Length + " загадок", "OK");
        }
    }
}