using System.Drawing;

namespace SistemaAmbientesUAB
{
    // ============================================================
    // SISTEMA DE TEMAS - UAB
    // Paleta basada en azules del dark mode aplicados a light/dark
    // ============================================================

    public enum Tema { Light, Dark }

    public static class ColorTheme
    {
        // ── Tema activo (cambia en runtime) ──────────────────────
        private static Tema _temaActual = Tema.Light;
        public static Tema TemaActual => _temaActual;

        public static void CambiarTema(Tema tema)
        {
            _temaActual = tema;
        }

        public static void Alternar()
        {
            _temaActual = _temaActual == Tema.Light ? Tema.Dark : Tema.Light;
        }

        // ============================================================
        // COLORES DINÁMICOS (devuelven el color según el tema activo)
        // ============================================================

        // Fondos
        public static Color FondoApp => _temaActual == Tema.Light ? LightFondoApp : DarkFondoApp;
        public static Color FondoCard => _temaActual == Tema.Light ? LightFondoCard : DarkFondoCard;
        public static Color FondoSidebar => _temaActual == Tema.Light ? LightFondoSidebar : DarkFondoSidebar;
        public static Color FondoTopbar => _temaActual == Tema.Light ? LightFondoTopbar : DarkFondoTopbar;
        public static Color FondoInput => _temaActual == Tema.Light ? LightFondoInput : DarkFondoInput;
        public static Color FondoStatCard => _temaActual == Tema.Light ? LightFondoStatCard : DarkFondoStatCard;
        public static Color FondoNavActivo => _temaActual == Tema.Light ? LightNavActivo : DarkNavActivo;
        public static Color FondoNavHover => _temaActual == Tema.Light ? LightNavHover : DarkNavHover;

        // Textos
        public static Color TextoPrimario => _temaActual == Tema.Light ? LightTextoPrimario : DarkTextoPrimario;
        public static Color TextoSecundario => _temaActual == Tema.Light ? LightTextoSecundario : DarkTextoSecundario;
        public static Color TextoNavActivo => _temaActual == Tema.Light ? Color.White : DarkTextoNavActivo;
        public static Color TextoNavNormal => _temaActual == Tema.Light ? LightTextoSecundario : DarkTextoSecundario;

        // Bordes
        public static Color Borde => _temaActual == Tema.Light ? LightBorde : DarkBorde;
        public static Color BordeInput => _temaActual == Tema.Light ? LightBordeInput : DarkBordeInput;

        // ── Color primario (azul en ambos temas) ─────────────────
        public static Color Primario => Color.FromArgb(62, 142, 247);    // #3e8ef7
        public static Color PrimarioHover => Color.FromArgb(26, 110, 212);    // #1a6ed4
        public static Color PrimarioSuave => _temaActual == Tema.Light
                                                  ? Color.FromArgb(230, 244, 255)  // #e6f4ff
                                                  : Color.FromArgb(13, 39, 68);    // #0d2744

        // ── Colores semánticos (estado de reservas) ──────────────
        public static Color Exito => _temaActual == Tema.Light ? Color.FromArgb(34, 168, 74) : Color.FromArgb(74, 222, 128);
        public static Color ExitoSuave => _temaActual == Tema.Light ? Color.FromArgb(230, 244, 230) : Color.FromArgb(13, 42, 26);
        public static Color ExitoTexto => _temaActual == Tema.Light ? Color.FromArgb(22, 101, 52) : Color.FromArgb(74, 222, 128);

        public static Color Error => _temaActual == Tema.Light ? Color.FromArgb(163, 45, 45) : Color.FromArgb(248, 113, 113);
        public static Color ErrorSuave => _temaActual == Tema.Light ? Color.FromArgb(255, 235, 235) : Color.FromArgb(42, 13, 13);
        public static Color ErrorTexto => _temaActual == Tema.Light ? Color.FromArgb(163, 45, 45) : Color.FromArgb(248, 113, 113);

        public static Color Aviso => _temaActual == Tema.Light ? Color.FromArgb(217, 119, 6) : Color.FromArgb(251, 191, 36);
        public static Color AvisoSuave => _temaActual == Tema.Light ? Color.FromArgb(255, 247, 230) : Color.FromArgb(42, 26, 13);
        public static Color AvisoTexto => _temaActual == Tema.Light ? Color.FromArgb(133, 79, 11) : Color.FromArgb(251, 191, 36);

        public static Color Info => Primario;
        public static Color InfoSuave => PrimarioSuave;
        public static Color InfoTexto => _temaActual == Tema.Light ? Color.FromArgb(12, 82, 176) : Color.FromArgb(99, 179, 255);

        // ── Badges de rol ─────────────────────────────────────────
        public static Color RolAdminFondo => _temaActual == Tema.Light ? Color.FromArgb(237, 233, 255) : Color.FromArgb(30, 22, 68);
        public static Color RolAdminTexto => _temaActual == Tema.Light ? Color.FromArgb(74, 60, 181) : Color.FromArgb(167, 139, 250);

        public static Color RolDocenteFondo => _temaActual == Tema.Light ? Color.FromArgb(230, 244, 255) : Color.FromArgb(13, 39, 68);
        public static Color RolDocenteTexto => _temaActual == Tema.Light ? Color.FromArgb(12, 82, 176) : Color.FromArgb(99, 179, 255);

        public static Color RolEstFondo => _temaActual == Tema.Light ? Color.FromArgb(234, 243, 222) : Color.FromArgb(13, 42, 26);
        public static Color RolEstTexto => _temaActual == Tema.Light ? Color.FromArgb(59, 109, 17) : Color.FromArgb(74, 222, 128);

        public static Color RolAdmFondo => _temaActual == Tema.Light ? Color.FromArgb(250, 238, 218) : Color.FromArgb(42, 26, 13);
        public static Color RolAdmTexto => _temaActual == Tema.Light ? Color.FromArgb(133, 79, 11) : Color.FromArgb(251, 191, 36);

        public static Color RolIglesiaFondo => _temaActual == Tema.Light ? Color.FromArgb(251, 234, 240) : Color.FromArgb(42, 13, 26);
        public static Color RolIglesiaTexto => _temaActual == Tema.Light ? Color.FromArgb(153, 53, 86) : Color.FromArgb(244, 114, 182);

        // ── Avatar / iniciales ────────────────────────────────────
        public static Color AvatarFondo => PrimarioSuave;
        public static Color AvatarTexto => InfoTexto;

        // ============================================================
        // CONSTANTES LIGHT MODE
        // ============================================================
        public static readonly Color LightFondoApp = Color.FromArgb(240, 244, 255); // #f0f4ff
        public static readonly Color LightFondoCard = Color.FromArgb(255, 255, 255); // #ffffff
        public static readonly Color LightFondoSidebar = Color.FromArgb(255, 255, 255); // #ffffff
        public static readonly Color LightFondoTopbar = Color.FromArgb(255, 255, 255); // #ffffff
        public static readonly Color LightFondoInput = Color.FromArgb(255, 255, 255); // #ffffff
        public static readonly Color LightFondoStatCard = Color.FromArgb(240, 244, 255); // #f0f4ff
        public static readonly Color LightNavActivo = Color.FromArgb(62, 142, 247);  // #3e8ef7
        public static readonly Color LightNavHover = Color.FromArgb(240, 244, 255); // #f0f4ff
        public static readonly Color LightTextoPrimario = Color.FromArgb(26, 58, 107);   // #1a3a6b
        public static readonly Color LightTextoSecundario = Color.FromArgb(122, 139, 168); // #7a8ba8
        public static readonly Color LightBorde = Color.FromArgb(216, 226, 240); // #d8e2f0
        public static readonly Color LightBordeInput = Color.FromArgb(208, 218, 240); // #d0daf0

        // ============================================================
        // CONSTANTES DARK MODE
        // ============================================================
        public static readonly Color DarkFondoApp = Color.FromArgb(13, 17, 23);    // #0d1117
        public static readonly Color DarkFondoCard = Color.FromArgb(22, 27, 39);    // #161b27
        public static readonly Color DarkFondoSidebar = Color.FromArgb(22, 27, 39);    // #161b27
        public static readonly Color DarkFondoTopbar = Color.FromArgb(22, 27, 39);    // #161b27
        public static readonly Color DarkFondoInput = Color.FromArgb(26, 33, 51);    // #1a2133
        public static readonly Color DarkFondoStatCard = Color.FromArgb(26, 33, 51);    // #1a2133
        public static readonly Color DarkNavActivo = Color.FromArgb(30, 58, 110);   // #1e3a6e
        public static readonly Color DarkNavHover = Color.FromArgb(26, 36, 54);    // #1a2436
        public static readonly Color DarkTextoPrimario = Color.FromArgb(232, 240, 254); // #e8f0fe
        public static readonly Color DarkTextoSecundario = Color.FromArgb(90, 112, 144); // #5a7090
        public static readonly Color DarkTextoNavActivo = Color.FromArgb(99, 179, 255);  // #63b3ff
        public static readonly Color DarkBorde = Color.FromArgb(42, 53, 80);    // #2a3550
        public static readonly Color DarkBordeInput = Color.FromArgb(42, 53, 80);    // #2a3550

        // ============================================================
        // HELPER: obtener colores de badge por estado de reserva
        // ============================================================
        public static (Color fondo, Color texto) ColoresBadgeEstado(string estado)
        {
            switch (estado?.ToLower())
            {
                case "activa": return (ExitoSuave, ExitoTexto);
                case "cancelada": return (ErrorSuave, ErrorTexto);
                case "finalizada":
                    return (_temaActual == Tema.Light
                                           ? Color.FromArgb(241, 239, 232)
                                           : Color.FromArgb(40, 40, 38),
                                          TextoSecundario);
                default: return (FondoStatCard, TextoSecundario);
            }
        }

        // ── Helper: badge por nombre de rol ──────────────────────
        public static (Color fondo, Color texto) ColoresBadgeRol(string rol)
        {
            switch (rol?.ToLower())
            {
                case "admin": return (RolAdminFondo, RolAdminTexto);
                case "docente": return (RolDocenteFondo, RolDocenteTexto);
                case "estudiante": return (RolEstFondo, RolEstTexto);
                case "administrativo": return (RolAdmFondo, RolAdmTexto);
                case "iglesia": return (RolIglesiaFondo, RolIglesiaTexto);
                default: return (FondoStatCard, TextoSecundario);
            }
        }
    }
}