using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace PeopleVcf.MVC
{

    public partial class View : Window
    {

        #region CTOR

        Control ctrl;

        public View()
        {
            InitializeComponent();
            Show();
            ctrl = new Control(this);
            DataContext = ctrl.model;
        }

        #endregion

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ((ListBox)sender).SelectedIndex;
            if (index>=0 && index < ctrl.model.Contacts.Count)
            {
                ctrl.model.Selected = ctrl.model.Contacts[((ListBox)sender).SelectedIndex];
            }
            else
            {
                ctrl.model.Selected = new Contact();
            }
        }

        #region BUTTONS

        private void ButtonImport_Click(object sender, RoutedEventArgs e)
        {
            if (ctrl.model.Contacts == null || ctrl.model.Contacts.Count == 0)
            {
                ctrl.model.Contacts = new ObservableCollection<Contact>();
                ctrl.Import();
            }
            else
            {
                MessageBoxResult result = MessageBox.Show(
                    "Keep previously loaded?", 
                    "Importing", 
                    MessageBoxButton.YesNoCancel
                );
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        ctrl.Import();
                        break;
                    case MessageBoxResult.No:
                        ctrl.model.Contacts = new ObservableCollection<Contact>();
                        ctrl.Import();
                        break;
                    case MessageBoxResult.Cancel:
                        break;
                }
            }
            listBoxContact.Items.Refresh();
        }

        private void ButtonExport_Click(object sender, RoutedEventArgs e)
        {
            ctrl.Export();
        }

        private void ButtonNewContact_Click(object sender, RoutedEventArgs e)
        {
            ctrl.NewContact();
            listBoxContact.Items.Refresh();
        }

        private void ButtonDeleteContact_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                       "Do you really wanna delete this card?",
                       "Contact deletion",
                       MessageBoxButton.YesNoCancel
                   );
            switch (result)
            {
                case MessageBoxResult.Yes:
                    ctrl.DeleteContact();
                    break;
                case MessageBoxResult.No:
                    break;
                case MessageBoxResult.Cancel:
                    break;
            }
            
        }

        #endregion

    }
}
