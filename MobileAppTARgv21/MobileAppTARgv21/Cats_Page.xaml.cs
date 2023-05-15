using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileAppTARgv21
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Cats_Page : ContentPage
    {
        private Entry catNameEntry;
        private Button generateButton;
        private Button add;
        private Label lbl;

        public const string fileName = "CatNames.txt";
        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), fileName);

        public Cats_Page()
        {
            catNameEntry = new Entry
            {
                Placeholder = "Введите имя кота"
            };

            add = new Button
            {
                Text = "Добавить имя кота",
                FontSize = 18,
                TextColor = Color.BlueViolet,
                CornerRadius = 15,
                WidthRequest = 350,
                HeightRequest = 50,
                BackgroundColor = Color.LightBlue,
                HorizontalOptions = LayoutOptions.Center
            };
            add.Clicked += Add_Clicked; ;

            generateButton = new Button
            {
                Text = "Сгенерировать",
                FontSize = 18,
                TextColor = Color.BlueViolet,
                CornerRadius = 15,
                WidthRequest = 350,
                HeightRequest = 50,
                BackgroundColor = Color.LightBlue,
                HorizontalOptions = LayoutOptions.Center
            };
            generateButton.Clicked += GenerateButton_Clicked;

            lbl = new Label
            {
                Text = "Здесь появиться имя кота! Добавьте и свои несколько вариантов!",
                FontSize = 25,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            Content = new StackLayout
            {
                Children = { catNameEntry, add, generateButton, lbl }
            };

        }

        private void GenerateButton_Clicked(object sender, EventArgs e)
        {
            string[] catNames = ReadCatNamesFromFile();

            if (catNames != null && catNames.Length >= 2)
            {
                string catNameOutput = string.Empty;

                Random random = new Random();

                string randomCatName = catNames[random.Next(catNames.Length)];

                catNameOutput = randomCatName;

                lbl.Text = catNameOutput;
            }
            else
            {
                lbl.Text = "Не удалось прочитать имена котов из файла, кажется список пуст!";
            }
        }

        private void Add_Clicked(object sender, EventArgs e)
        {
            string catName = catNameEntry.Text;

            if (!string.IsNullOrWhiteSpace(catName))
            {
                lbl.Text = $"Имя кота добавлено: {catName}\nСпасибо!";

                SaveCatNameToFile(catName);
            }
            else
            {
                lbl.Text = "Пожалуйста, введите имя кота";
            }

            catNameEntry.Text = string.Empty;
        }

        private void SaveCatNameToFile(string catName)
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), fileName);

            using (StreamWriter write = File.AppendText(filePath))
            {
                write.WriteLine(catName);
            }
        }

       

        private string[] ReadCatNamesFromFile()
        {
            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), fileName);

            try
            {
                string[] catNames = File.ReadAllLines(filePath);

                return catNames.Skip(1).ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка чтения файла {fileName}: {ex.Message}");
                return null;
            }
        }
    }
}