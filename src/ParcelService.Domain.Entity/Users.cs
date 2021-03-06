namespace ParcelService.Domain.Entity
{
    public class Users
    {
        #region Properties
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        #endregion

        public virtual bool IsActiveUser(string password)
        {
            return false;
        }
    }
}
