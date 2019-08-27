using System;
using System.Collections.Generic;
using System.Text;

namespace PeopleVcf
{
    class Contact
    {

        #region Attributes

        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string Name3 { get; set; }
        public string Name4 { get; set; }
        public string FormattedName { get; set; }
        public string NickName { get; set; }
        public string Photo { get; set; }
        public DateTime? Birthday { get; set; }
        public List<Address> Addresses { get; set; } = new List<Address>();
        public List<Phone> Phones{ get; set; } = new List<Phone>();
        public List<Email> Mails { get; set; } = new List<Email>();
        public string EmailProgram { get; set; }
        public string TimeZone { get; set; }
        public string GlobalPositionning { get; set; }
        public string Title { get; set; }
        public string Occupation { get; set; }
        public string Logo { get; set; }
        public string Organization { get; set; }
        public string Category { get; set; }
        public string Note { get; set; }
        public string LastRevision { get; set; }
        public string Sortstring { get; set; }
        public string Sound { get; set; }
        public string Url { get; set; }
        public string UniqueIdentifier { get; set; }
        public string Version { get; set; }
        public string PublicKey { get; set; }
        public string Agent { get; set; }

        #endregion

        #region ToString

        /// Used to export to vcf file
        override
        public string ToString()
        {
            StringBuilder vCardString = new StringBuilder();

            #region FILLCARD

            // VCARD HEADER

            vCardString.Append("BEGIN:VCARD\n");
            vCardString.Append("VERSION:2.1\n");

            // VCARD BODY

            if (!string.IsNullOrEmpty(Name1 + Name2 + Name3 + Name4))
            {

                #region NAME

                vCardString.Append("N:"  + "TEST_"+Name1 + ";" + Name2 + ";" + Name3 + ";" + Name4 + "\n");
                vCardString.Append("FN:" + Name1 + " " + Name2 + " " + Name3 + " " + Name4 + "\n");

                #endregion

                #region CONTACT

                if (Phones.Count > 0)
                {
                    foreach (Phone tel in Phones)
                    {
                        if (!string.IsNullOrEmpty(tel.Number))
                        {
                            vCardString.Append(
                                "TEL"+
                                (string.IsNullOrEmpty(tel.Type.ToString()) ? (";" + tel.Type.ToString()) : "") +
                                ":" + tel.Number + "\n"
                            );
                        }
                    }
                }
                if (Phones.Count > 0)
                {
                    foreach (Address adr in Addresses)
                    {
                        if (!string.IsNullOrEmpty(adr.Street))
                        {
                            vCardString.Append(
                                "ADR" +
                                (string.IsNullOrEmpty(adr.Type.ToString()) ? (";" + adr.Type.ToString()) : "") +
                                ":" + adr.Street + "\n"
                            );
                        }
                    }
                }
                if (Phones.Count > 0)
                {
                    foreach (Email mail in Mails)
                    {
                        if (!string.IsNullOrEmpty(mail.Address))
                        {
                            vCardString.Append(  
                                "EMAIL" +
                                (string.IsNullOrEmpty(mail.Type.ToString()) ? (";" + mail.Type.ToString()) : "") + 
                                ":" + mail.Address + "\n"
                            );
                        }
                    }
                }

                #endregion

                #region MISC INFOS

                if (!String.IsNullOrEmpty(Title)) vCardString.Append("TITLE:" + Title + "\n");
                if (!String.IsNullOrEmpty(Organization)) vCardString.Append("ORG:" + Organization + "\n");
                if (!String.IsNullOrEmpty(Note)) vCardString.Append("NOTE:" + Note + "\n");
                //FAM,PRE,Sec,Titre
                //sb.Append("PHOTO:"+Photo+"\n");
                //sb.Append("BDAY:"+Birthday+"\n");
                //sb.Append("MAILER:"+ EmailProgram + "\n");
                //sb.Append("TZ:"+TimeZone+"\n");
                //sb.Append("GEO:"+GlobalPositionning+"\n");
                //sb.Append("ROLE:"+Occupation+"\n");
                //sb.Append("LOGO:"+Logo+"\n");
                //sb.Append("AGENT:"+Agent+"\n");
                //sb.Append("CATEGORIES:"+Category+"\n");
                //sb.Append("URL:"+Url+"\n");
                //sb.Append("REV:"+LastRevision+"\n");
                //sb.Append("SOUND:"+Sound+"\n");
                //sb.Append("UID:"+UniqueIdentifier+"\n");
                //sb.Append("KEY:"+PublicKey+"\n");

                #endregion

            }

            // VCARD FOOTER

            vCardString.Append("END:VCARD\n");

            #endregion

            return vCardString.ToString();
        }

        #endregion

        internal void GeneratePhoto()
        {
            throw new NotImplementedException();
        }

    }
}
