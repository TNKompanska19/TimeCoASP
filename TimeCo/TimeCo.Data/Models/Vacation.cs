using System;
using System.Collections.Generic;

namespace TimeCo.Data.Models;

public partial class Vacation
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public bool IsMainVacation { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
