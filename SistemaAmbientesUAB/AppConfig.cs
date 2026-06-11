using System;
using System.IO;
using System.Windows.Forms;

namespace SistemaAmbientesUAB
{
    // ============================================================
    // APP CONFIG — persiste la preferencia de tema entre sesiones
    // Guarda en: %AppData%\UABReservas\config.txt
    // ============================================================

    public static class AppConfig
    {
        private static readonly string CarpetaConfig =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                         "UABReservas");

        private static readonly string ArchivoConfig =
            Path.Combine(CarpetaConfig, "config.txt");

        // ── Cargar tema al iniciar la app ────────────────────────
        // Llamar en Program.cs antes de Application.Run()
        public static void Inicializar()
        {
            try
            {
                if (!Directory.Exists(CarpetaConfig))
                    Directory.CreateDirectory(CarpetaConfig);

                if (File.Exists(ArchivoConfig))
                {
                    string contenido = File.ReadAllText(ArchivoConfig).Trim();
                    if (contenido == "Dark")
                        ColorTheme.CambiarTema(Tema.Dark);
                    else
                        ColorTheme.CambiarTema(Tema.Light);
                }
                else
                {
                    // Primera vez: usar Light por defecto
                    ColorTheme.CambiarTema(Tema.Light);
                    GuardarTema();
                }
            }
            catch
            {
                // Si falla (sin permisos, etc.), usar Light sin error
                ColorTheme.CambiarTema(Tema.Light);
            }
        }

        // ── Guardar tema actual ──────────────────────────────────
        public static void GuardarTema()
        {
            try
            {
                if (!Directory.Exists(CarpetaConfig))
                    Directory.CreateDirectory(CarpetaConfig);

                File.WriteAllText(ArchivoConfig, ColorTheme.TemaActual.ToString());
            }
            catch { /* silencioso */ }
        }

        // ── Cambiar tema y guardar ────────────────────────────────
        // Llamar al presionar el botón toggle en cualquier formulario
        public static void AlternarTema(Form formActual)
        {
            ColorTheme.Alternar();
            GuardarTema();

            // Re-aplicar tema al formulario actual
            UIHelper.AplicarTemaFormulario(formActual);
            formActual.Refresh();
        }
    }
}