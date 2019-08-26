using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleVcf.MVC
{
    class Model : INotifyPropertyChanged
    {
        #region NOTIFY PROPERTY

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
                Console.WriteLine(DateTime.Now + " Lm Widget Part >>> PropertyChanged : " + property);
            }
        }

        #endregion

        private ObservableCollection<Contact> contacts = new ObservableCollection<Contact>();
        public ObservableCollection<Contact> Contacts
        {
            get { return contacts; }
            set { contacts = value; RaisePropertyChanged("Contacts"); }
        }

        private Contact selected;
        public Contact Selected
        {
            get { return selected; }
            set { selected = value; RaisePropertyChanged("Selected"); }
        }

    }
}
