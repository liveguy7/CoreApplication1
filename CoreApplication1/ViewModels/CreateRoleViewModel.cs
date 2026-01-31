using System.ComponentModel.DataAnnotations;

namespace CoreApplication1.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public String RoleName { get; set; }

    }
}
