using System;

namespace PromartTest.Job.Settings
{
    public class CronSettings<T>
    {
        public string CronExpression { get; set; } = default!;
        public TimeZoneInfo TimeZone { get; set; } = default!;
    }
}
