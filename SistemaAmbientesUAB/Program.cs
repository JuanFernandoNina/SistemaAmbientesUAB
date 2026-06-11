using System;
using System.Windows.Forms;

namespace SistemaAmbientesUAB
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Cargar tema guardado ANTES de abrir cualquier formulario
            AppConfig.Inicializar();

            Application.Run(new FormLogin());
        }
    }
}