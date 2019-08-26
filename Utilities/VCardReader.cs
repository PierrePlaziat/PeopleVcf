using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PeopleVcf
{
    class VCardReader
    {
        #region ATTRIBUTES

        private string FormattedName { get; set; }
        private string SortString { get; set; }
        private string Surname { get; set; }
        private string GivenName { get; set; }
        private string MiddleName { get; set; }
        private string Prefix { get; set; }
        private string Suffix { get; set; }
        private string Title { get; set; }
        private DateTime Rev { get; set; } // If Rev in vCard is UTC, Rev will convert utc to local datetime.
        private DateTime? Birthday { get; set; }
        private string Org { get; set; }
        private string Note { get; set; }
        private string Version { get; set; }
        private Address[] Addresses { get; set; }
        private Email[] Emails { get; set; }
        private Phone[] Phones { get; set; }
        private string TimeZone { get; set; }
        private string Key { get; set; }
        private string Mailer { get; set; }
        private string LabelAddress { get; set; }
        private string Geocodage { get; set; }
        private string LastRevision { get; set; }
        private string Logo { get; set; }
        private string Occupation { get; set; }
        private string Photo { get; set; }
        private string Sound { get; set; }
        private string UniqueIdentifier { get; set; }
        private string Url { get; set; }
        private string Category { get; set; }

        #endregion

        #region MTDS

        public Contact ParseCard(string card)
        {

            Regex regex;
            Match match;
            MatchCollection matchCollection;
            RegexOptions options = 
                RegexOptions.IgnoreCase |
                RegexOptions.Multiline | 
                RegexOptions.IgnorePatternWhitespace;

            // formatted name
            regex = new Regex(@"(?<strElement>(FN))   (:(?<strFN>[^\n\r]*))", options);
            match = regex.Match(card);
            if (match.Success)
                FormattedName = match.Groups["strFN"].Value;

            // sort string
            try
            {
                regex = new Regex(@"(?<strElement>(SORT-STRING))   (:(?<strSORT-STRING>[^\n\r]*))", options);
                match = regex.Match(card);
                if (match.Success)
                    SortString = match.Groups["strSORT-STRING"].Value;
            }
            catch
            {
                SortString = "!";
            }

            // lastRevision
            try
            {
                regex = new Regex(@"(?<strElement>(REV))   (:(?<strREV>[^\n\r]*))", options);
                match = regex.Match(card);
                if (match.Success)
                    LastRevision = match.Groups["strREV"].Value;
            }
            catch
            {
                LastRevision = "!";
            }

            // lastRevision
            try
            {
                regex = new Regex(@"(?<strElement>(LOGO))   (:(?<strLOGO>[^\n\r]*))", options);
                match = regex.Match(card);
                if (match.Success)
                    Logo = match.Groups["strLOGO"].Value;
            }
            catch
            {
                Logo = "!";
            }

            // Occupation
            try
            {
                regex = new Regex(@"(?<strElement>(ROLE))   (:(?<strROLE>[^\n\r]*))", options);
                match = regex.Match(card);
                if (match.Success)
                    Occupation = match.Groups["strROLE"].Value;
            }
            catch
            {
                Occupation = "!";
            }

            // Photo
            try
            {
                regex = new Regex(@"(?<strElement>(PHOTO))   (:(?<strPHOTO>[^\n\r]*))", options);
                match = regex.Match(card);
                if (match.Success)
                    Photo = match.Groups["strPHOTO"].Value;
            }
            catch
            {
                Photo = "!";
            }

            // Sound
            try
            {
                regex = new Regex(@"(?<strElement>(SOUND))   (:(?<strSOUND>[^\n\r]*))", options);
                match = regex.Match(card);
                if (match.Success)
                    Sound = match.Groups["strSOUND"].Value;
            }
            catch
            {
                Sound = "!";
            }

            // uniqueIdentifier
            try
            {
                regex = new Regex(@"(?<strElement>(UID))   (:(?<strUID>[^\n\r]*))", options);
                match = regex.Match(card);
                if (match.Success)
                    UniqueIdentifier = match.Groups["strUID"].Value;
            }
            catch
            {
                UniqueIdentifier = "!";
            }

            // url
            try
            {
                regex = new Regex(@"(?<strElement>(URL))   (:(?<strURL>[^\n\r]*))", options);
                match = regex.Match(card);
                if (match.Success)
                    Url = match.Groups["strURL"].Value;
            }
            catch
            {
                Url = "!";
            }

            // category
            try
            {
                regex = new Regex(@"(?<strElement>(CATEGORIES))   (:(?<strCATEGORIES>[^\n\r]*))", options);
                match = regex.Match(card);
                if (match.Success)
                    Category = match.Groups["strCATEGORIES"].Value;
            }
            catch
            {
                Category = "!";
            }

            // version
            try
            {
                regex = new Regex(@"(?<strElement>(VERSION))   (:(?<strVERSION>[^\n\r]*))", options);
                match = regex.Match(card);
                if (match.Success)
                    Version = match.Groups["strVERSION"].Value;
            }
            catch
            {
                Version = "!";
            }

            // timezone
            try
            {
                regex = new Regex(@"(?<strElement>(TZ))   (:(?<strTZ>[^\n\r]*))", options);
                match = regex.Match(card);
                if (match.Success)
                    TimeZone = match.Groups["strTZ"].Value;
            }
            catch
            {
                TimeZone = "!";
            }

            // Public Key
            try
            {
                regex = new Regex(@"(?<strElement>(KEY))   (:(?<strKEY>[^\n\r]*))", options);
                match = regex.Match(card);
                if (match.Success)
                    Key = match.Groups["strKEY"].Value;
            }
            catch
            {
                Key = "!";
            }

            // email program
            try
            {
                regex = new Regex(@"(?<strElement>(MAILER))   (:(?<strMAILER>[^\n\r]*))", options);
                match = regex.Match(card);
                if (match.Success)
                    Mailer = match.Groups["strMAILER"].Value;
            }
            catch
            {
                Mailer = "!";
            }

            // label address
            try
            {
                regex = new Regex(@"(?<strElement>(LABEL))   (:(?<strLABEL>[^\n\r]*))", options);
                match = regex.Match(card);
                if (match.Success)
                    LabelAddress = match.Groups["strLABEL"].Value;
            }
            catch
            {
                LabelAddress = "!";
            }

            // globalPositionning
            try
            {
                regex = new Regex(@"(?<strElement>(GEO))   (:(?<strGEO>[^\n\r]*))", options);
                match = regex.Match(card);
                if (match.Success)
                    Geocodage = match.Groups["strGEO"].Value;
            }
            catch
            {
                Geocodage = "!";
            }

            // other names
            regex = new Regex(@"(\n(?<strElement>(N)))   
                    (:(?<strSurname>([^;]*))) (;(?<strGivenName>([^;]*)))  
                    (;(?<strMidName>([^;]*))) (;(?<strPrefix>([^;]*))) 
                    (;(?<strSuffix>[^\n\r]*))", options);
            match = regex.Match(card);
            if (match.Success)
            {
                Surname = match.Groups["strSurname"].Value;
                GivenName = match.Groups["strGivenName"].Value;
                MiddleName = match.Groups["strMidName"].Value;
                Prefix = match.Groups["strPrefix"].Value;
                Suffix = match.Groups["strSuffix"].Value;
            }

            // Title
            regex = new Regex(@"(?<strElement>(TITLE))   
                    (:(?<strTITLE>[^\n\r]*))", options);
            match = regex.Match(card);
            if (match.Success)
                Title = match.Groups["strTITLE"].Value;

            // ORG
            regex = new Regex(@"(?<strElement>(ORG))   
                    (:(?<strORG>[^\n\r]*))", options);
            match = regex.Match(card);
            if (match.Success)
                Org = match.Groups["strORG"].Value;

            // Note
            regex = new Regex(@"((?<strElement>(NOTE)) 
                    (;*(?<strAttr>(ENCODING=QUOTED-PRINTABLE)))*  
                    ([^:]*)*  (:(?<strValue> 
                    (([^\n\r]*=[\n\r]+)*[^\n\r]*[^=][\n\r]*) )))", options);
            match = regex.Match(card);
            if (match.Success)
            {
                Note = match.Groups["strValue"].Value;
                //Remove connections and escape strings. The order is significant.
                Note = Note.Replace("=" + Environment.NewLine, "");
                Note = Note.Replace("=0D=0A", Environment.NewLine);
                Note = Note.Replace("=3D", "=");
            }

            // Birthday
            regex = new Regex(@"(?<strElement>(BDAY))   
                    (:(?<strBDAY>[^\n\r]*))", options);
            match = regex.Match(card);
            if (match.Success)
            {
                string[] expectedFormats = { "yyyyMMdd", "yyMMdd", "yyyy-MM-dd" };
                Birthday = DateTime.ParseExact
                           (match.Groups["strBDAY"].Value, expectedFormats, null,
                           System.Globalization.DateTimeStyles.AllowWhiteSpaces);
            }

            // Rev
            regex = new Regex(@"(?<strElement>(REV))   (:(?<strREV>[^\n\r]*))", options);
            match = regex.Match(card);
            if (match.Success)
            {
                string[] expectedFormats = { "yyyyMMddHHmmss", "yyyyMMddTHHmmssZ" };
                Rev = DateTime.ParseExact
                      (match.Groups["strREV"].Value, expectedFormats, null,
                      System.Globalization.DateTimeStyles.AllowWhiteSpaces);
            }

            // Emails
            string ss;

            regex = new Regex(@"((?<strElement>(EMAIL)) 
                    (;*(?<strAttr>(HOME|WORK)))*  (;(?<strPref>(PREF)))* 
                    (;[^:]*)*  (:(?<strValue>[^\n\r]*)))", options);
            matchCollection = regex.Matches(card);
            if (matchCollection.Count > 0)
            {
                Emails = new Email[matchCollection.Count];
                for (int i = 0; i < matchCollection.Count; i++)
                {
                    Emails[i] = new Email();
                    match = matchCollection[i];
                    Emails[i].Address = match.Groups["strValue"].Value;
                    ss = match.Groups["strAttr"].Value;
                    if (ss == "HOME")
                        Emails[i].Type = HomeWorkType.HOME;
                    else if (ss == "WORK")
                        Emails[i].Type = HomeWorkType.WORK;

                    if (match.Groups["strPref"].Value == "PREF")
                        Emails[i].Fav = true;
                }
            }

            // Phones
            regex = new Regex(@"(\n(?<strElement>(TEL)) 
                    (;*(?<strAttr>(HOME|WORK)))* 
                    (;(?<strType>(VOICE|CELL|PAGER|MSG|FAX)))*  
                    (;(?<strPref>(PREF)))* (;[^:]*)*  
                    (:(?<strValue>[^\n\r]*)))", options);
            matchCollection = regex.Matches(card);
            if (matchCollection.Count > 0)
            {
                Phones = new Phone[matchCollection.Count];
                for (int i = 0; i < matchCollection.Count; i++)
                {
                    try
                    {
                        Phones[i] = new Phone();
                        match = matchCollection[i];
                        Phones[i].Number = match.Groups["strValue"].Value;
                        ss = match.Groups["strAttr"].Value;
                        if (ss == "HOME")
                            Phones[i].Type = HomeWorkType.HOME;
                        else if (ss == "WORK")
                            Phones[i].Type = HomeWorkType.WORK;

                        if (match.Groups["strPref"].Value == "PREF")
                            Phones[i].Fav = true;

                        ss = match.Groups["strType"].Value;
                        if (ss == "VOICE")
                            Phones[i].PhoneType = PhoneType.VOICE;
                        else if (ss == "CELL")
                            Phones[i].PhoneType = PhoneType.CELL;
                        else if (ss == "PAGER")
                            Phones[i].PhoneType = PhoneType.PAGER;
                        else if (ss == "MSG")
                            Phones[i].PhoneType = PhoneType.MSG;
                        else if (ss == "FAX")
                            Phones[i].PhoneType = PhoneType.FAX;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("!!!!!");
                        Console.WriteLine(e);
                        Console.WriteLine(e.InnerException);
                    }
                }
            }
            // Addresses
            regex = new Regex(@"(\n(?<strElement>(ADR))) 
                    (;*(?<strAttr>(HOME|WORK)))*  (:(?<strPo>([^;]*)))  
                    (;(?<strBlock>([^;]*)))  (;(?<strStreet>([^;]*)))  
                    (;(?<strCity>([^;]*))) (;(?<strRegion>([^;]*))) 
                    (;(?<strPostcode>([^;]*)))(;(?<strNation>[^\n\r]*)) ", options);
            matchCollection = regex.Matches(card);
            if (matchCollection.Count > 0)
            {
                Addresses = new Address[matchCollection.Count];
                for (int i = 0; i < matchCollection.Count; i++)
                {
                    Addresses[i] = new Address();
                    match = matchCollection[i];
                    ss = match.Groups["strAttr"].Value;
                    if (ss == "HOME")
                        Addresses[i].Type = HomeWorkType.HOME;
                    else if (ss == "WORK")
                        Addresses[i].Type = HomeWorkType.WORK;

                    Addresses[i].Po = match.Groups["strPo"].Value;
                    Addresses[i].Ext = match.Groups["strBlock"].Value;
                    Addresses[i].Street = match.Groups["strStreet"].Value;
                    Addresses[i].Locality = match.Groups["strCity"].Value;
                    Addresses[i].Region = match.Groups["strRegion"].Value;
                    Addresses[i].Postcode = match.Groups["strPostcode"].Value;
                    Addresses[i].Country = match.Groups["strNation"].Value;
                }
            }

            return ExtractContact();
        }

        private Contact ExtractContact()
        {
            Contact contact = new Contact()
            {
                FormattedName = FormattedName,
                Name1 = Prefix,
                Name2 = Surname,
                Name3 = GivenName,
                Name4 = MiddleName,
                NickName = GivenName,
                Sortstring = SortString,
                Birthday = Birthday,
                Title = Title,
                Organization = Org,
                Note = Note,
                EmailProgram = Mailer,
                GlobalPositionning = Geocodage,
                LastRevision = LastRevision,
                Logo = Logo,
                Occupation = Occupation,
                Photo = Photo,
                Sound = Sound,
                UniqueIdentifier = UniqueIdentifier,
                Url = Url,
                Category = Category,
                TimeZone = TimeZone,
                PublicKey = Key,
                Version = Version,
            };
            if (Phones!=null && Phones.Any()) 
                contact.Phones = Phones.ToList();
            if (Addresses != null && Addresses.Any())
                contact.Addresses = Addresses.ToList();
            if (Emails != null && Emails.Any())
                contact.Mails = Emails.ToList();
            return contact;
        }

        #endregion

    }

    public enum HomeWorkType
    {
        CELL,
        HOME,
        WORK,
    }

}
