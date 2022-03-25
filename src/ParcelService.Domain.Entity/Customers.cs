using System;

namespace ParcelService.Domain.Entity
{
    public class Customers
    {
        #region Properties
        public int Customer_Id { get; set; }
        public int User_Access { get; set; }
        public int Branchoffice_Id { get; set; }
        public int Third_Type_Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string TradeName { get; set; }
        public string CompanyName { get; set; }
        public string Rfc { get; set; }
        public string Email { get; set; }
        public string Area_Code { get; set; }
        public string Phone { get; set; }
        public int Customer_Type_Id { get; set; }
        public bool With_Agreement { get; set; }
        public DateTime Date_Creates { get; set; }
        public DateTime Date_Modifies { get; set; }
        public DateTime Date_Authorizes { get; set; }
        public int Usr_Creates_Id { get; set; }
        public int Usr_Modifies_id { get; set; }
        public int Usr_Authorizes_Id { get; set; }
        #endregion
    }
}
