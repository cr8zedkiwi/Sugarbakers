using System;
using System.Collections.Generic;

namespace Sugarbakers.Models;

public partial class Zipcode
{
    public string Zipcode1 { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
