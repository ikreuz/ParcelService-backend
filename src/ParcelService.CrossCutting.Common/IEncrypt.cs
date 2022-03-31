namespace ParcelService.CrossCutting.Common
{
    public interface IEncrypt
    {
        public string Encrypt(string original);
        public string Decrypt(string encrypted);
    }
}
