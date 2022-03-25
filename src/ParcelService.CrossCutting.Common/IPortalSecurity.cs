namespace ParcelService.CrossCutting.Common
{
    public interface IPortalSecurity
    {
        public string InputFilter { get; set; }
        public bool IncludesMarkup { get; set; }
        public string FormatDisableScripting { get; set; }
        public string FormatMultiLine { get; set; }
        public string FormatRemoveSQL { get; set; }
    }
}
