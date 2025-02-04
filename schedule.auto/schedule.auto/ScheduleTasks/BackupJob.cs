using Quartz;
using schedule.auto.Models;
using Serilog;
using System.Text.Json;

namespace schedule.auto.ScheduledTasks
{
    public class BackupJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                backup_model item = new backup_model();
                item = JsonSerializer.Deserialize<backup_model>(context.JobDetail.Description);

                Log.Information("Started job {0} - {1}: {2}", item.jobName, item.jobId, item.cronExpression);
                string sourceServer = @"\\" + item.ipSource + @"\" + item.pathSource;
                string destServer = @"\\" + item.ipDestination + @"\" + item.pathDestination;
                Log.Information("Copy file from {0} to {1}", sourceServer, destServer);
                DirectoryInfo diSource = new DirectoryInfo(sourceServer);
                DirectoryInfo diTarget = new DirectoryInfo(destServer);

                var targetFiles = diTarget.GetFiles().Select(o => o.Name);
                int fileExisted = 0;
                int fileCopySuccess = 0;
                int fileCopyError = 0;
                foreach (FileInfo fi in diSource.GetFiles())
                {
                    string Filename = fi.Name;
                    try
                    {
                        if (targetFiles.Contains(Filename))
                        {
                            fileExisted++;
                            Log.Information("File {0} existed, skip", Filename);
                            continue;
                        }
                        Log.Information(@"Copying {0}\{1}", diSource.FullName, Filename);
                        fi.CopyTo(Path.Combine(diTarget.FullName, Filename), true);
                        fileCopySuccess++;
                        Log.Information("Successed!!!");
                    }
                    catch (Exception ex)
                    {
                        fileCopyError++;
                        Log.Error(@"Error copy file {0}\{1}: {2}", diSource.FullName, Filename, ex);
                    }
                }
                Log.Information("Total: {0}, Success: {1}, Existed: {2}, Error: {3}", diSource.GetFiles().Length, fileCopySuccess, fileExisted, fileCopyError);
            }
            catch(Exception ex)
            {
                Log.Error("Error start job: {0}", ex);
            }
        }
    }
}
