using Cinema.WinForms.Forms;

namespace Cinema.WinForms
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            ApplicationConfiguration.Initialize();
            Form mainForm = args.Contains("--management", StringComparer.OrdinalIgnoreCase)
                ? new ManagementForm()
                : new MainForm();
            Application.Run(mainForm);
        }
    }
}
