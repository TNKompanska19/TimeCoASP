using TimeCo.Data;

namespace TimeCo.Web.Models
{
    public class VacationViewModel
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public Guid UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
