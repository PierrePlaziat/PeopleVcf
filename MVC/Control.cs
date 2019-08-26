using System;
using System.IO;
using System.Text;
using System.Windows;

namespace PeopleVcf.MVC
{
    class Control
    {

        #region CTOR

        public Model model;
        public View vue;
        private readonly VCardReader cardReader;

        public Control(View vue)
        {
            this.vue = vue;
            model = new Model();
            cardReader = new VCardReader();
        }

        #endregion

        #region MTDS

        internal void Import()
        {
            // Select file
            string filePath = PathBox.DialogHelper.DialogOpenFile(
                @"D:\\", 
                "VCF Files (*.vcf)|*.vcf"
            );
            // Read it
            string wholefile = File.ReadAllText(
                filePath, 
                Encoding.UTF8
            );
            // Split it
            string[] cards= wholefile.Split(
                new string[] { "END:VCARD" }, 
                StringSplitOptions.None
            );
            // Import its datas
            foreach(string card in cards)
            {
                model.Contacts.Add(
                    cardReader.ParseCard(
                        card
                    )
                );
            }
        }

        // TODO dialog box debug
        internal void Export()
        {
            // dialog box
            string path = PathBox.DialogHelper.DialogOpenFolder(@"D:\\");
            // export
            StringBuilder sb = new StringBuilder();
            foreach(var contact in model.Contacts)
            {
                sb.Append(
                    contact.ToString()+"\n"
                );
            }
            // write file
            File.WriteAllText(path+"\\export.vcf", sb.ToString());
            MessageBox.Show("Done");
        }
        
        internal void NewContact()
        {
            model.Contacts.Add(
                new Contact()
                {
                    FormattedName = "NewContact",
                    Name1="NewContact"
                }
            );
            model.Selected = model.Contacts[model.Contacts.Count-1];
        }
        
        internal void DeleteContact()
        {
            Contact cardToDelete = model.Selected;
            model.Contacts.Remove(cardToDelete);
            model.Selected = model.Contacts[0];
        }

        #endregion

    }
}
