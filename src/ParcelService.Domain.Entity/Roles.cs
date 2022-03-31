using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcelService.Domain.Entity
{
    public class Roles
    {
        #region Constants
        public const string Master = "Master";
        public const string Administrator = "Administrator";
        public const string Supervisor = "Supervisor";
        public const string Typist = "Typist";
        public const string Courier = "Courier";
        public const string Customer = "Customer";
        public const string Driver = "Driver";
        #endregion

        #region Properties
        public int Role_Id { get; set; }
        public string Role_Name { get; set; }
        #endregion
    }
}
