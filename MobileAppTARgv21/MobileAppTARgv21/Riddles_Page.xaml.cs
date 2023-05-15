using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileAppTARgv21
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Riddles_Page : ContentPage
    {

        Label title;
        Button gameButton;
        List<string> riddles = new List<string>();
        List<string> answers = new List<string>();
        int correctAnswers;

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
                Children = { title, gameButton }
            };

            LoadRiddlesAndAnswers();
        }

        private void LoadRiddlesAndAnswers()
        {
            string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string riddlesFilePath = Path.Combine(folderPath, "riddles.txt");
            string answersFilePath = Path.Combine(folderPath, "answers.txt");

            if (File.Exists(riddlesFilePath))
            {
                riddles = File.ReadAllLines(riddlesFilePath).ToList();
            }

            if (File.Exists(answersFilePath))
            {
                answers = File.ReadAllLines(answersFilePath).ToList();
            }
        }

        private async void GameButton_Clicked(object sender, System.EventArgs e)
        {
            string name = await DisplayPromptAsync("Давай познакомимся", "Как тебя зовут?", "Ok", "Отменить", "Введи имя", keyboard: Keyboard.Chat);
            var action = await DisplayActionSheet("Приятно познакомиться, " + name + "! Начнём загадки?", "Нет", "Да");
            if (action == "Да")
            {
                correctAnswers = 0;
                RiddleGame();
            }
        }

        private async void RiddleGame()
        {
            for (int i = 0; i < riddles.Count; i++)
            {
                string riddle = riddles[i];
                string answer = await DisplayPromptAsync("Загадка " + (i + 1), riddle, "Ответ", maxLength: 20);

                if (answer?.ToLower() == answers[i].ToLower())
                {
                    await DisplayAlert("Правильно!", "Правильный ответ: " + answers[i], "OK");
                    correctAnswers++;
                }
                else
                {
                    await DisplayAlert("Неправильно", "Правильный ответ: " + answers[i], "OK");
                }
            }

            await DisplayAlert("Итого", "Вы ответили правильно на " + correctAnswers + " из " + riddles.Count + " загадок", "OK");
        }
    }

}
