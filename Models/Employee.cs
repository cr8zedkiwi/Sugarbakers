using System;
using System.Collections.Generic;

namespace Sugarbakers.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string LastName { get; set; } = null!;

    public string? Address { get; set; }

    public string? Zip { get; set; }

    public string? Position { get; set; }

    public int? DepartmentId { get; set; }

    public decimal? Salary { get; set; }

    public virtual Department? Department { get; set; }

    public virtual Zipcode? ZipNavigation { get; set; }
}
