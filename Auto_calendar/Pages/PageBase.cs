using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;

namespace Auto_calendar.Pages
{
    public class PageBase : ComponentBase
    {
        [Inject] protected IJSRuntime jsRuntime { get; set; }
        [Inject] protected NotificationService notificationService { get; set; }

        public void AlertInfor(string Message)
        {
            //NotificationMessage a = new NotificationMessage
            //{
            //    Severity = NotificationSeverity.Info,
            //    Summary = "Thông báo",
            //    Detail = Message,
            //    Duration = 6000
            //};
            //notificationService.Notify(a);
            jsRuntime.InvokeAsync<String>("alert", Message);
        }
    }
}
