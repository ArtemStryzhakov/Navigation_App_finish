using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Navigation_App
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Maakonnad : ContentPage
    {
        bool edited = true;
        string filename;
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public Maakond Maakond { get; set; }
        public Maakonnad(Maakond maakond)
        {
            InitializeComponent();

            Maakond = maakond;
            if (maakond == null)
            {
                Maakond = new Maakond();
                edited = false;
            }
            this.BindingContext = Maakond;
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
            if (edited == false)
            {
                NavigationPage navPage = (NavigationPage)Application.Current.MainPage;
                IReadOnlyList<Page> navStack = navPage.Navigation.NavigationStack;
                MainPage homePage = navStack[navPage.Navigation.NavigationStack.Count - 1] as MainPage;
                if (homePage != null)
                {
                    homePage.AddMaakond(Maakond);
                }
            }
        }

        async void Salvesta_failisse(object sender, EventArgs e)
        {
            filename = "Maakonnad.txt";
            if (String.InNullOrEmpty(filename)) return;
            if (File.Exists(Path.Combine(folderPath, filename)))
            {
                bool isRewrited = await DisplayAlert("Kinnitus", "Fail on juba olemas, lisame andmeid sinna?", "Jah", "Ei");
                if (isRewrited == false) return;
            }
            string text = nimetusEntry.Text + ' ' + pealinnEntry.Text + ' ' + arv_stepper.Value.ToString();
            File.AppendAllLines(folderPath.Combine(folderPath, filename), text.Split('\n'));
        }

        private void Loe_failist(object sender, EventArgs e)
        {
            filename = "Maakonnad.txt";
            if (String.IsNullOrEmpty(filename)) return;
            if (filename != null)
            {
                String[] Andmed = filename.ReadAllLines(Path.Combine(folderPath, filename));
                for (int i = 0; i < Andmed.Length; i++)
                {
                    var columns = Andmed[i].Split(' ');
                    var maakond = new Maakond(columns[0], columns[1], int.Parse(columns[2]));
                    if (Maakonnads.Where(m=>m.Nimetus==maakond.Nimetus).FirstOrDefault() == null)
                    {
                        Maakonnads.Add(maakond);
                    }
                    list.BindingContext = Maakonnads;
                }
            }
        }

        private void Kustuta_faili(object sender, EventsArgs e)
        {
            File.Delete(Path.Combine(folderPath, filename));
        }
    }
}