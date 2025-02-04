using Serilog.Events;
using Serilog;
using Serilog.Sinks.RichTextBoxForms;
using Serilog.Sinks.RichTextBoxForms.Themes;
using schedule.auto.Control;
using schedule.auto.Models;
using schedule.auto.Helper;
using System.Threading.Tasks;

namespace schedule.auto
{
    public partial class Form1 : Form
    {
        private RichTextBoxSinkOptions _options = null;
        public List<ListTasks> _tasks = new List<ListTasks>();
        private void Initialize()
        {
            _options = new RichTextBoxSinkOptions(ThemePresets.Dark, 200, 5, true, 1000000000);
            var sink = new RichTextBoxSink(rTBConsoleLog, _options);
            string applicationName = "SCHEDULE AUTO";
            Log.Logger = new LoggerConfiguration()
                //.MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                //.MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
                //.Enrich.WithEnvironmentName()
                //.Enrich.FromLogContext()
                //.Enrich.WithMachineName()
                .Enrich.WithProperty("ApplicationName", applicationName)
                .MinimumLevel.Verbose()
                .WriteTo.File(//path: "logs\\log-.txt",
                              path: @"C:\logs\log-.txt",
                              outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] [{SourceContext}] [{EventId}] {Message}{NewLine}{Exception}",
                              rollingInterval: RollingInterval.Day,
                              shared: true,
                              retainedFileCountLimit: 100,
                              rollOnFileSizeLimit: true,
                              fileSizeLimitBytes: 10485760)
                .WriteTo.Sink(sink, LogEventLevel.Verbose)
                .CreateLogger();
            Log.Information("Started application!");
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            Initialize();
            LoadPopulateItem();
        }
        public async void LoadPopulateItem()
        {
            try
            {
                DataHelper _helper = new DataHelper();
                var dataJobs = _helper.LoadDataFromExcel();

                if (dataJobs.Count > 0)
                {
                    foreach (var data in dataJobs)
                    {
                        var item = new ListTasks();
                        item.JobId = data.jobId;
                        item.JobName = data.jobName;
                        item.IpSource = data.ipSource;
                        item.PathSource = data.pathSource;
                        item.IpDestination = data.ipDestination;
                        item.PathDestination = data.pathDestination;
                        item.Frequency = data.frequency;
                        item.DateExec = data.dateExec;
                        item.TimeExec = data.timeExec;
                        item.Status = data.status;
                        item.ButtonClick += (sender, e) =>
                        {
                            RemovePopulateItem(item.JobId);
                        };
                        _tasks.Add(item);
                        Log.Information("Loaded Job: " + item.JobId);
                    }
                    if (flowLayoutPanel1.Controls.Count > 0) flowLayoutPanel1.Controls.Clear();
                    flowLayoutPanel1.Controls.AddRange(_tasks.ToArray());

                    await StartJob();
                }
                else
                {
                    AddJobs();
                }
            }
            catch (Exception ex)
            {
                Log.Error($"Load list jobs: {ex}");
            }
        }
        public void AddJobs()
        {
            var item = new ListTasks();
            item.JobId = Guid.NewGuid().ToString();
            item.JobName = "";
            item.IpSource = "";
            item.PathSource = "";
            item.IpDestination = "";
            item.PathDestination = "";
            item.Frequency = "1PD";
            item.DateExec = "";
            item.TimeExec = "";
            item.Status = "0";
            item.ButtonClick += (sender, e) =>
            {
                //System.Windows.Forms.Button btn = (System.Windows.Forms.Button)sender;
                //MessageBox.Show("Parent name: " + btn.Parent.Name + ", button name: " + btn.Name);
                RemovePopulateItem(item.JobId);
            };
            _tasks.Add(item);
            if (flowLayoutPanel1.Controls.Count > 0) flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.AddRange(_tasks.ToArray());
            Log.Information("Added Job: " + item.JobId);
        }
        public void RemovePopulateItem(string jobId)
        {
            try
            {
                if (_tasks.Count > 0)
                {
                    var _items = _tasks.Where(o => o.JobId == jobId).ToList();
                    if (_items.Count > 0)
                    {
                        _tasks.RemoveAll(o => o.JobId == jobId);
                        if (flowLayoutPanel1.Controls.Count > 0) flowLayoutPanel1.Controls.Clear();
                        flowLayoutPanel1.Controls.AddRange(_tasks.ToArray());
                        Log.Information("Removed Job: " + jobId);
                    }
                }
                else MessageBox.Show("Hết job để xóa rồi!!!");
            }
            catch (Exception ex)
            {
                Log.Error($"Remove job: {ex}");
            }
        }
        private void btnAddJob_Click(object sender, EventArgs e)
        {
            if (_tasks.Count > 10) MessageBox.Show("Đã đạt số lượng công việc tối đa!!!");
            else
            {
                AddJobs();
            }
        }
        private async void btnStartAllJob_Click(object sender, EventArgs e)
        {
            await StartJob();
        }
        public async Task StartJob()
        {
            try
            {
                _tasks.All(o => { o.Status = "1"; return true; });
                var dataJob = _tasks
                    //.Where(o => o.Status == "1")
                    .Select(o => new backup_model
                    {
                        jobId = o.JobId,
                        jobName = o.JobName,
                        ipSource = o.IpSource,
                        pathSource = o.PathSource,
                        ipDestination = o.IpDestination,
                        pathDestination = o.PathDestination,
                        status = o.Status,
                        frequency = o.Frequency,
                        dateExec = o.DateExec,
                        timeExec = o.TimeExec
                    })
                    .ToList();
                if (dataJob.Count > 0)
                {
                    foreach (var item in dataJob)
                    {
                        await ExecJob.Createjob(item);
                    }
                    DataHelper _helper = new DataHelper();
                    _helper.InsertDataToExcel(dataJob);
                }
                else throw new Exception("Không có job đang mở!!!");
            }
            catch (Exception ex)
            {
                Log.Error($"btnStartAllJob_Click: {ex}");
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnStopAllJob_Click(object sender, EventArgs e)
        {
            try
            {
                _tasks.All(o => { o.Status = "0"; return true; });
                var dataJob = _tasks
                    //.Where(o => o.Status == "1")
                    .Select(o => new backup_model
                    {
                        jobId = o.JobId,
                        jobName = o.JobName,
                        ipSource = o.IpSource,
                        pathSource = o.PathSource,
                        ipDestination = o.IpDestination,
                        pathDestination = o.PathDestination,
                        status = o.Status,
                        frequency = o.Frequency,
                        dateExec = o.DateExec,
                        timeExec = o.TimeExec
                    })
                    .ToList();
                if (dataJob.Count > 0)
                {
                    foreach (var item in dataJob)
                    {
                        await ExecJob.Createjob(item);
                    }
                    DataHelper _helper = new DataHelper();
                    _helper.InsertDataToExcel(dataJob);
                }
                else throw new Exception("Không có job đang mở!!!");
            }
            catch (Exception ex)
            {
                Log.Error($"btnStopAllJob_Click: {ex}");
                MessageBox.Show(ex.Message);
            }
        }
    }
}