using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agrogar.Shared.DTOs
{
    public class UserProfileDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Created { get; set; }
        public string PhoneNumber { get; set; }
        public bool LicensePP { get; set; }
    }
}
