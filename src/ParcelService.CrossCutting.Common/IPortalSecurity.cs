namespace ParcelService.CrossCutting.Common
{
    public enum FilterFlag
    {
        MultiLine = 1,
        Nomarkup = 2,
        NoScripting = 4,
        NoSQL = 8
    }
    public interface IPortalSecurity
    {
        public string InputFilter(string userInput, FilterFlag filterType);
    }
}
