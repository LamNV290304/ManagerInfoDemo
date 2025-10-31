using System;
using System.Collections.Generic;

namespace ManagerInfoDemo.Models;

public partial class Customer
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public DateTime? CreatedAt { get; set; }

    public bool? IsVerify { get; set; }

    public int? CreatedBy { get; set; }

    public virtual Staff? CreatedByNavigation { get; set; }
}
