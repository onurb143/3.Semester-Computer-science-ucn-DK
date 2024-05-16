using MomentozClientApp.GuiLayer;  // Importerer namespace for GUI-laget
using MomentozClientApp.Servicelayer;  // Importerer namespace for servicelaget

static class Program
{
    static void Main()
    {
        Application.SetHighDpiMode(HighDpiMode.SystemAware);  // Indstiller High DPI-tilstand
        Application.EnableVisualStyles();  // Aktiverer visuelle stilarter
        Application.SetCompatibleTextRenderingDefault(false);  // Indstiller tekstrendring til standardv�rdi (false)
        Application.Run(new LogIn(new CustomerAccess()));  // Starter programmet ved at k�re LogIn-formen med CustomerAccess-instantiering
    }
}
