using AntDesign;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UnrealIRCD.WebPanelSharp.Models
{
    public class SysUserEdit
    {
        public long Id { get; set; }

        [StringLength(120, ErrorMessage = "Account is too long")]
        public string Name { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        
        public List<string> GetModelErrors()
        {
            var errors = new List<string>();
            
            if (string.IsNullOrWhiteSpace(Name))
                errors.Add("必须填写账号");

            if(Id == default)
            {
                if (string.IsNullOrWhiteSpace(Password))
                    errors.Add("必须填写密码");

                if (string.IsNullOrWhiteSpace(ConfirmPassword))
                    errors.Add("必须填写确认密码");

                if (Name?.ToLower() == "root")
                    errors.Add("无法使用此账号");
            }

            if (Password != ConfirmPassword)
                errors.Add("两次密码输入不一致");

            return errors;
        }

    }
}
