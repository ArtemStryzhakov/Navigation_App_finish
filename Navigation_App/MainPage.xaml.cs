using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Navigation_App
{
    public partial class MainPage : ContentPage
    {
        protected internal ObservableCollection<Maakond> Maakonnads { get; set; }
        public MainPage()
        {
            InitializeComponent();
            Maakonnads = new ObservableCollection<Maakond>
            {
                new Maakond {Nimetus = "Harjumaa", Pealinn="Tallinn", Inimester_arv=52000},
                new Maakond {Nimetus = "Tartumaa", Pealinn="Tartu", Inimester_arv=30000},
                new Maakond {Nimetus = "Ida-Virumaa", Pealinn="Kohtla-Järve", Inimester_arv=10000}
            };
            list.BindingContext = Maakonnads;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Maakonnad(null));
        }

        private async void list_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Maakond selected = e.SelectedItem as Maakond;
            if (selected != null)
            {
                list.SelectedItem = null;
                await Navigation.PushAsync(new Maakonnad(selected));
            }
        }

        protected internal void AddMaakond(Maakond maakond)
        {
            Maakonnads.Add(maakond);
        }
    }
}
