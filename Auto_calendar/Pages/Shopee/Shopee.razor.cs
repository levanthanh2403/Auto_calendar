using Microsoft.AspNetCore.Components;
using Quartz.Impl;
using Quartz;
using Auto_calendar.ScheduledTasks;
using Serilog;
using Auto_calendar.Data;
using System.Text;
using System.IO;
using Microsoft.JSInterop;
using Radzen;

namespace Auto_calendar.Pages.Shopee
{
    public class ShopeeBase : PageBase
    {
        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                RefreshLog();
            }
            StateHasChanged();
        }
        public string log = "";
        public async Task StartJob()
        {
            Log.Information("Start Job!!!");
            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            await scheduler.Start();
            IJobDetail job = JobBuilder.Create<ShopeeJob>()
                .WithIdentity("dailyJob")
                .Build();
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("dailyJobTrigger")
                .WithCronSchedule("0 21 22 * * ?")
                .ForJob("dailyJob")
                .Build();
            await scheduler.ScheduleJob(job, trigger);
            Log.Information("Started Job!!!");
        }
        public void RefreshLog()
        {
            using (var fs = new FileStream(@"logs\log-" + DateTime.Now.ToString("yyyyMMdd") + ".txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var sr = new StreamReader(fs, Encoding.Default))
            {
                log = sr.ReadToEnd();
            }
        }
        public void checkItemInCart()
        {
            AlertInfor("Test");
        }
    }
}
