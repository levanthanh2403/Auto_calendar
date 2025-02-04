using schedule.auto.Models;

namespace schedule.auto.Data
{
    public static class CONST
    {
        public static List<combobox_model> _freq = new List<combobox_model>()
        {
            new combobox_model() { value = "1PD", text = "1 lần/ngày", expression = "0 m h * * ?" },
            new combobox_model() { value = "1PW", text = "1 lần/tuần(T2-CN:1-7)", expression = "0 m h ? * d" },
            new combobox_model() { value = "1PM", text = "1 lần/tháng(1-28)", expression = "0 m h d * ?" }
        };
        public static List<combobox_model> _status = new List<combobox_model>()
        {
            new combobox_model() { value = "1", text = "Hoạt động" },
            new combobox_model() { value = "0", text = "Dừng hoạt động" }
        };
    }
}
