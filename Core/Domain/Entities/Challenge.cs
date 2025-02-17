using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Challenge
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string challenge { get; set; } = string.Empty;
}

