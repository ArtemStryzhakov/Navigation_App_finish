using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Navigation_App
{
    public class Maakond: INotifyPropertyChanged
    {
        string nimetus;
        string pealinn;
        int inimeste_arv;

        public Maakond() { }

        public Maakond(string Nimetus, string Pealinn, int Inimeste_arv)
        {
            nimetus = Nimetus;
            pealinn = Pealinn;
            inimeste_arv = Inimeste_arv;
        }

        public string Nimetus
        {
            get { return nimetus; }
            set
            {
                if (nimetus != value)
                {
                    nimetus = value;
                    OnPropertyChanged("Nimetus");
                }
            }
        }

        public string Pealinn
        {
            get { return pealinn; }
            set
            {
                if (pealinn != value)
                {
                    pealinn = value;
                    OnPropertyChanged("Pealinn");
                }
            }
        }

        public int Inimester_arv
        {
            get { return inimeste_arv; }
            set
            {
                if (inimeste_arv != value)
                {
                    inimeste_arv = value;
                    OnPropertyChanged("Inimeste_arv");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string v = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }
    }
}
