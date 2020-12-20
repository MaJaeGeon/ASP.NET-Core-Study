using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "입력해주세요."), EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "입력해주세요."), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}