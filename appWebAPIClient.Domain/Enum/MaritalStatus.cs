using System;

namespace appWebAPIClient.Domain.Enum
{
    [Flags]
    public enum MaritalStatus : byte
    {
        Single = 1,
        Married = 2,
        Widower = 3,
        Divorced = 4
    }
}
