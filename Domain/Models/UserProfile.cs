using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class UserProfile
{
    public int UserProfileId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Address1 { get; set; }

    public string? Address2 { get; set; }

    public string? ContactNo { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? Ipaddress { get; set; }

    public int? UserId { get; set; }

    public virtual User? User { get; set; }
}
