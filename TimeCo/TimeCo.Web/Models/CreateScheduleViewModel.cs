using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using TimeCo.Data;
using TimeCo.Service.Users.Models;
namespace TimeCo.Web.Models
{
    public class CreateScheduleViewModel
    {
        public string Shift { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        // public ICollection<UserDTO> Users { get; set; }
        public Guid UserId { get; set; }

        public List<ApplicationUser> Users { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
