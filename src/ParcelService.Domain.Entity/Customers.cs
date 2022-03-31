using System;

namespace ParcelService.Domain.Entity
{
    public class Customers
    {
        #region Properties
        public int Customer_Id { get; set; }
        public int User_Access_Id { get; set; }
        public int Branch_Office_Id { get; set; }
        public int Third_Type_Id { get; set; }
        public string Firtsname { get; set; }
        public string Lastname { get; set; }
        public string Business_Name { get; set; }
        public string Company_Name { get; set; }
        public string Rfc { get; set; }
        public string Email { get; set; }
        public string Area_Code { get; set; }
        public string Phone { get; set; }
        public int Customer_Type_Id { get; set; }
        public bool With_Agreement { get; set; }
        public DateTime Date_Creation { get; set; }
        public DateTime Date_Modification { get; set; }
        public DateTime Date_Authorization { get; set; }
        public int Usr_Creates_Id { get; set; }
        public int Usr_Modifies_Id { get; set; }
        public int Usr_Authorizes_Id { get; set; }
        public int Total_Count { get; set; }
        #endregion
    }
}
