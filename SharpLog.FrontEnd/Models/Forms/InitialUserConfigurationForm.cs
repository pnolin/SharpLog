using System.ComponentModel.DataAnnotations;

namespace SharpLog.FrontEnd.Models.Forms
{
    public class InitialUserConfigurationForm
    {
        [Required]
        public string Username { get; set; } = "";
    }
}