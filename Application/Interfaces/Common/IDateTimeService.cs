using System;

namespace Application.Interfaces.Common
{
    public interface IDateTimeService
    {
        DateTime NowUtc { get; }
    }
}