using Auto_calendar.Data;
using Quartz;
using Serilog;
using System.Text.Json;

namespace Auto_calendar.ScheduledTasks
{
    public class ShopeeJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            Log.Information(JsonSerializer.Serialize(CONST.shopeeModel));
        }
    }
    public class OrderLogitechJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            Log.Information(JsonSerializer.Serialize(CONST.shopeeModel));
        }
    }
}
