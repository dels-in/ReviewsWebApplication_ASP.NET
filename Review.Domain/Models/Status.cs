using System.ComponentModel;

namespace Review.Domain.Models;

public enum Status
{
    [Description("None")]
    None = 0,
    [Description("Actual")]
    Actual = 1,
    [Description("Deleted")]
    Deleted = 2
}