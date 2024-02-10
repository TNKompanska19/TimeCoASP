using System;
using System.Collections.Generic;

namespace TimeCo.Data.Models;

public partial class Schedule
{
    public int Id { get; set; }

    public string Shift { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public TimeOnly StartHour { get; set; }

    public TimeOnly EndHour { get; set; }

    public int UserId { get; set; }

    public virtual User User { get; set; } = null!;
}
