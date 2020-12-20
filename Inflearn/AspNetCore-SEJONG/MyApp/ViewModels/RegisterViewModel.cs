using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "필수 입력 항목"), EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "필수 입력 항목")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "필수 입력 항목")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "필수 입력 항목"), DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password), Compare("Password", ErrorMessage = "비밀번호가 일치하지 않음")]
        public string ConfirmPassword { get; set; }
    }
}
