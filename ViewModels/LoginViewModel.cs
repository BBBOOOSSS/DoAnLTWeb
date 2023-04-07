using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoAnLTWeb.ViewModels
{
    public class LoginViewModel
    {
        public int ID_User { get; set; }

        [StringLength(50, ErrorMessage = "Tài khoản quá dài")]
        [Required(ErrorMessage = "Chưa nhập tài khoản.")]
        [Display(Name = "Tài khoản")]
        public string Login { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Phải nhập mật khẩu.")]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        
    }
}