using System;

namespace CsharpHelpers
{
    public interface IAuditable
    {
        DateTime UpdatedAt { get; set; }
        string UpdatedBy { get; set; }
        DateTime CreatedAt { get; set; }
        string CreatedBy { get; set; }
    }
}