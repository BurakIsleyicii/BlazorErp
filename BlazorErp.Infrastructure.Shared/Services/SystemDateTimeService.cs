using BlazorErp.Application.Interfaces.Services;
using System;

namespace BlazorErp.Infrastructure.Shared.Services
{
    public class SystemDateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}