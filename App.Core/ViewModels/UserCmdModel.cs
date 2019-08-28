using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Core.ViewModels
{
    public class UserCmdModel
    {
        public int Id { get; set; }

        public int RoleId { get; set; }
        
        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public string Email { get; set; }

        public string Mobile { get; set; }

        [Required]
        public string Password { get; set; }

        public int ActionId { get; set; }
    }
}
