#  AmbientesUAB — Sistema de Gestión de Reservas de Ambientes

> **Proyecto Final — Base de Datos**
> Universidad Adventista de Bolivia (UAB)

---

## 📋 Descripción

Sistema de escritorio para gestionar la reserva de aulas, laboratorios, auditorios y otros espacios físicos de la UAB. Permite a docentes, estudiantes, administrativos y miembros de iglesia reservar ambientes de forma eficiente, evitando conflictos de horarios y duplicidad de reservas.

---

## 👥 Integrantes

| Nombre |
|--------|
| Juan Fernando Nina Cachi |
| Axel Alberto Ticona Villegas |

**Docente:** Paulo Miguel Choque Poca
**Asignatura:** Base de Datos
**Gestión:** 2026

---

## 🛠️ Tecnologías utilizadas

| Tecnología | Detalle |
|-----------|---------|
| Lenguaje | C# |
| Interfaz | Windows Forms (.NET Framework 4.7.2) |
| Base de datos | Microsoft SQL Server Express |
| IDE | Visual Studio 2022 |
| Control de versiones | Git + GitHub |

---

## 🚀 Cómo ejecutar el proyecto

1. Instalar **SQL Server Express** y **SSMS**
2. Ejecutar el script `AmbientesUAB.sql` en SSMS para crear la base de datos
3. Abrir la solución `SistemaAmbientesUAB.slnx` en Visual Studio 2022
4. Editar `App.config` con el nombre de tu servidor SQL:

```xml
<connectionStrings>
  <add name="Conexion"
       connectionString="Server=TU_SERVIDOR\SQLEXPRESS;Database=AmbientesUAB;Integrated Security=True;"
       providerName="System.Data.SqlClient"/>
</connectionStrings>
```

5. Ejecutar con **F5**

---

## 📁 Estructura del proyecto

```
SistemaAmbientesUAB/
├── App.config                      ← Cadena de conexión a SQL Server
├── Program.cs                      ← Punto de entrada
├── Conexion.cs                     ← Clase de conexión reutilizable
├── AppConfig.cs                    ← Persistencia de preferencia de tema
├── ColorTheme.cs                   ← Paleta de colores Light/Dark
├── TemaManager.cs                  ← Gestor de temas en runtime
├── UIHelper.cs                     ← Helpers de estilos para controles
├── FormLogin.cs                    ← Autenticación de usuarios
├── FormMenu.cs                     ← Shell principal con sidebar
├── FormHome.cs                     ← Dashboard de inicio
├── FormNuevaReserva.cs             ← Crear reservas
├── FormMisReservas.cs              ← Ver reservas propias
├── FormDetalleMisReservas.cs       ← Detalle y cancelación de reserva
├── FormAmbientes.cs                ← Gestión de ambientes (admin)
├── FormAmbienteDetalle.cs          ← Crear/editar ambiente
├── FormUsuarios.cs                 ← Gestión de usuarios (admin)
├── FormUsuarioDetalle.cs           ← Crear/editar usuario
├── FormEventos.cs                  ← Gestión de eventos (admin)
├── FormEventoDetalle.cs            ← Crear/editar evento
└── FormReportes.cs                 ← Reportes y exportación
```

---

## 🗄️ Base de datos

La base de datos `AmbientesUAB` contiene 7 tablas:

| Tabla | Descripción |
|-------|-------------|
| `Bloque` | Bloques físicos del campus (A, B, C, D...) |
| `Ambiente` | Aulas, labs, auditorios con equipamiento y estado |
| `Usuario` | Usuarios con roles, credenciales y estado |
| `HorarioBloque` | Bloques horarios predefinidos (Lun–Vie) |
| `Evento` | Eventos institucionales con responsable |
| `Reserva` | Núcleo del sistema — registra todas las reservas |
| `Cancelacion` | Historial de cancelaciones con motivo y responsable |

### Relaciones

```
Bloque ──────────< Ambiente
Usuario ─────────< Reserva >──────── Ambiente
Reserva >──────── Evento (opcional)
Reserva ─────────< Cancelacion
Usuario ─────────< Cancelacion
Usuario ─────────< Evento (responsable)
```

---

## 🖥️ Módulos del sistema

### 🔐 Login
Autenticación con `username` y `password`. Verifica estado activo y resuelve permisos según el rol del usuario.

### 🏠 Home
Dashboard de bienvenida personalizado con el nombre y rol del usuario.

### 📅 Nueva Reserva
Búsqueda de ambientes disponibles por fecha, horario, capacidad y equipamiento. Usa el stored procedure `sp_SugerirAmbientes`. Soporta reservas recurrentes (diaria, semanal, mensual, anual). El administrador puede reservar en nombre de otro usuario.

### 📋 Mis Reservas
Lista de reservas propias con opción de ver detalle y cancelar, registrando motivo de cancelación.

### 🏢 Ambientes *(admin/administrativo)*
CRUD completo de ambientes con tipo, capacidad, equipamiento y estado.

### 👤 Usuarios *(admin/administrativo)*
Gestión de usuarios con asignación de roles y estado activo/inactivo.

### 🎪 Eventos *(solo admin)*
Registro de eventos institucionales vinculables a reservas.

### 📊 Reportes *(admin, administrativo, docente)*
Cinco reportes con filtro por rango de fechas y exportación a **Excel** y **PDF**:
- Ambientes más usados
- Reservas canceladas
- Disponibilidad de ambientes
- Uso por carrera/área
- Todas las reservas

---

## 🎨 Sistema de temas

La aplicación soporta **modo claro y oscuro**. La preferencia se guarda automáticamente en:

```
%AppData%\UABReservas\config.txt
```

---

## 🔑 Usuarios de prueba

| Username | Rol | Acceso |
|----------|-----|--------|
| `admin` | Administrador | Acceso total |
| `jperez` | Docente | Reservas + Reportes |
| `mflores` | Estudiante | Reservas propias |
| `cmamani` | Estudiante | Reservas propias |
| `pramos` | Iglesia | Reservas propias |
| `aquispe` | Docente | Reservas + Reportes |

---

## 📌 Notas de desarrollo

- Las contraseñas actualmente se almacenan en texto plano. Se recomienda implementar hashing (SHA-256 o bcrypt) antes de pasar a producción.
- La lógica SQL está directamente en los formularios. Para escalar, se recomienda separar en capas DAL/BLL.
- El proyecto cuenta con dos sistemas de temas en paralelo (`ColorTheme.cs` y `TemaManager.cs`) producto de refactorizaciones sucesivas.

---

> Proyecto en desarrollo — Base de Datos · UAB · 2026
