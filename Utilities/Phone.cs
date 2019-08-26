namespace PeopleVcf
{
    public class Phone
    {
        public HomeWorkType Type { get; set; }
        public string Number { get; set; }
        public object PhoneType { get; set; }
        public bool Fav { get; set; }
    }

    public enum PhoneType
    {
        VOICE,
        CELL,
        PAGER,
        MSG,
        FAX
    }

}