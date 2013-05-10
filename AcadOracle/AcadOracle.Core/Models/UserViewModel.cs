
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using AcadOracle.Core.Interfaces;

namespace AcadOracle.Core.Models
{
    public class UserViewModel : IUser
    {
        public int Id { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Nome")]
        public string Name { get; set; }
        [DisplayName("Senha")]
        public string Password { get; set; }
    }
}
