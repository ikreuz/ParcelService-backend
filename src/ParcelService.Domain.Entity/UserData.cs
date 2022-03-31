using System;

namespace ParcelService.Domain.Entity
{
    public class UserData
    {
        #region Properties
        public int User_Id { get; set; }
        public int Role_Id { get; set; }
        public string Role_Name { get; set; }
        public string App_User { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public bool Activity_Status { get; set; }
        public int App_User_Type { get; set; }
        public string App_User_Type_Txt { get; set; }
        public DateTime Date_Creation { get; set; }
        public DateTime Date_Modification { get; set; }
        public int Usr_Creates_Id { get; set; }
        public string Usr_Creates { get; set; }
        public int Usr_Modifies_Id { get; set; }
        public string Usr_Modifies { get; set; }
        public int Total_Count { get; set; }
        #endregion
    }
}
