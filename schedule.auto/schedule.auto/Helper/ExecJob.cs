using Newtonsoft.Json;
using Quartz.Impl;
using Quartz;
using schedule.auto.Data;
using schedule.auto.Models;
using schedule.auto.ScheduledTasks;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Serilog;

namespace schedule.auto.Helper
{
    public static class ExecJob
    {
        public static async Task Createjob(backup_model item)
        {
            try
            {
                IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
                await scheduler.Start();
                await scheduler.DeleteJob(new JobKey(item.jobId));
                Log.Information("Deleted job {0} - {1}", item.jobName, item.jobId);
                if (item.status == "0") return;

                if (string.IsNullOrEmpty(item.jobName)
                                || string.IsNullOrEmpty(item.ipSource)
                                || string.IsNullOrEmpty(item.pathSource)
                                || string.IsNullOrEmpty(item.ipDestination)
                                || string.IsNullOrEmpty(item.pathDestination)
                                || string.IsNullOrEmpty(item.status)
                                || string.IsNullOrEmpty(item.frequency)
                                || (item.frequency != "1PD" && string.IsNullOrEmpty(item.dateExec))
                                || string.IsNullOrEmpty(item.timeExec)) throw new Exception("Chưa nhập đủ thông tin của các jobs!!!");
                try { Convert.ToInt32(item.frequency != "1PD" ? item.dateExec : "0"); } catch (Exception ex) { Log.Error($"convert date exec: {ex}"); throw new Exception("Ngày chạy không hợp lệ!!!"); }
                try { DateTime.ParseExact(item.timeExec, "HH:mm", CultureInfo.InvariantCulture); } catch (Exception ex) { Log.Error($"convert time exec: {ex}"); throw new Exception("Giờ chạy không hợp lệ!!!"); }
                if (item.frequency == "1PM" && (Convert.ToInt32(item.dateExec) < 1 || Convert.ToInt32(item.dateExec) > 28)) throw new Exception("Ngày chạy phải nằm trong khoảng từ 1 - 28!!!");
                if (item.frequency == "1PW" && (Convert.ToInt32(item.dateExec) < 1 || Convert.ToInt32(item.dateExec) > 7)) throw new Exception("Ngày chạy phải nằm trong khoảng từ 1 - 7!!!");

                string cron_expression = "";
                cron_expression = CONST._freq.Where(o => o.value == item.frequency).FirstOrDefault().expression;
                if (item.frequency != "1PD") cron_expression = cron_expression.Replace("d", item.dateExec);
                if (!string.IsNullOrEmpty(item.timeExec)) cron_expression =
                        cron_expression
                        .Replace("h", item.timeExec.Split(':')[0])
                        .Replace("m", item.timeExec.Split(':')[1]);
                item.cronExpression = cron_expression;
                IJobDetail job = JobBuilder.Create<BackupJob>()
                    .WithIdentity(item.jobId)
                    .WithDescription(JsonConvert.SerializeObject(item))
                    .Build();
                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity(item.jobName + "-" + item.jobId)
                    .WithCronSchedule(item.cronExpression)
                    .ForJob(item.jobId)
                    .Build();
                await scheduler.ScheduleJob(job, trigger);
                Log.Information("Created Job {0} - {1}: {2}", item.jobName, item.jobId, item.cronExpression);
            }
            catch (Exception ex)
            {
                Log.Error($"Error create job: {ex}");
                throw new Exception(ex.Message);
            }
        }
    }
}
