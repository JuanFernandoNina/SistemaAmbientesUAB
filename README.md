# 🏫 AmbientesUAB — Sistema de Gestión de Reservas de Ambientes

> **Proyecto Final — Base de Datos I**  
> Universidad Adventista de Bolivia (UAB)

---

## 📋 Descripción

Sistema de escritorio para gestionar la reserva de aulas, laboratorios, auditorios y otros espacios físicos de la UAB. Permite a docentes, estudiantes, administrativos y miembros de iglesia reservar ambientes de forma eficiente, evitando conflictos de horarios y duplicidad de reservas.

---

## 🛠️ Tecnologías utilizadas

| Tecnología | Versión |
|-----------|---------|
| Lenguaje | C# |
| Interfaz | Windows Forms (.NET Framework 4.7.2) |
| Base de datos | Microsoft SQL Server (Express) |
| IDE | Visual Studio 2022 |
| Control de versiones | Git + GitHub |

---

## 🗄️ Base de datos — `AmbientesUAB`

### Tablas creadas

#### 1. `Bloque`
Representa los bloques físicos de la universidad (A, B, C, D...).

| Campo | Tipo | Descripción |
|-------|------|-------------|
| id_bloque | INT (PK) | Identificador único |
| nombre | VARCHAR(10) | Nombre del bloque (A, B, C...) |
| descripcion | VARCHAR(100) | Descripción del bloque |

---

#### 2. `Ambiente`
Aulas, laboratorios, auditorios y otros espacios reservables.

| Campo | Tipo | Descripción |
|-------|------|-------------|
| id_ambiente | INT (PK) | Identificador único |
| id_bloque | INT (FK) | Bloque al que pertenece |
| codigo | VARCHAR(20) | Código del ambiente (Ej: A101) |
| tipo | VARCHAR(30) | aula, laboratorio, auditorio, coliseo |
| capacidad | INT | Capacidad máxima de personas |
| tiene_proyector | BIT | Si cuenta con proyector |
| tiene_computadoras | BIT | Si tiene computadoras individuales |
| tiene_enchufes | BIT | Si tiene enchufes eléctricos |
| estado | VARCHAR(20) | disponible / mantenimiento / inhabilitado |

---

#### 3. `Usuario`
Usuarios del sistema con autenticación y roles.

| Campo | Tipo | Descripción |
|-------|------|-------------|
| id_usuario | INT (PK) | Identificador único |
| codigo | VARCHAR(20) | Código institucional |
| nombre_completo | VARCHAR(100) | Nombre completo |
| tipo_usuario | VARCHAR(30) | docente / estudiante / administrativo / iglesia |
| carrera_area | VARCHAR(80) | Carrera o área académica |
| correo | VARCHAR(100) | Correo electrónico |
| telefono | VARCHAR(20) | Número de teléfono |
| username | VARCHAR(50) | Nombre de usuario para login |
| password_hash | VARCHAR(255) | Contraseña (hash) |
| es_admin | BIT | 1 si es administrador |
| estado | VARCHAR(10) | activo / inactivo |

---

#### 4. `HorarioBloque`
Bloques horarios predefinidos para días lunes a viernes.

| Campo | Tipo | Descripción |
|-------|------|-------------|
| id_horario | INT (PK) | Identificador único |
| hora_inicio | TIME | Hora de inicio del bloque |
| hora_fin | TIME | Hora de fin del bloque |
| descripcion | VARCHAR(50) | Ej: "Bloque 1", "Bloque 2" |

> Los sábados y domingos permiten hora libre (sin bloques predefinidos).

---

#### 5. `Evento`
Eventos institucionales que requieren ambientes.

| Campo | Tipo | Descripción |
|-------|------|-------------|
| id_evento | INT (PK) | Identificador único |
| id_responsable | INT (FK) | Usuario responsable del evento |
| nombre_evento | VARCHAR(100) | Nombre del evento |
| cantidad_asistentes | INT | Cantidad esperada de asistentes |
| requerimientos | VARCHAR(255) | Requerimientos especiales |
| fecha_evento | DATE | Fecha del evento |

---

#### 6. `Reserva`
Núcleo del sistema. Registra todas las reservas de ambientes.

| Campo | Tipo | Descripción |
|-------|------|-------------|
| id_reserva | INT (PK) | Identificador único |
| id_usuario | INT (FK) | Usuario que solicita |
| id_ambiente | INT (FK) | Ambiente reservado |
| id_evento | INT (FK, nullable) | Evento asociado (opcional) |
| fecha_inicio | DATE | Fecha de inicio |
| fecha_fin | DATE | Fecha de fin |
| hora_inicio | TIME | Hora de inicio |
| hora_fin | TIME | Hora de fin |
| motivo | VARCHAR(100) | clases, reunión, GP, evento... |
| cantidad_asistentes | INT | Asistentes esperados |
| es_recurrente | BIT | Si es reserva recurrente |
| frecuencia | VARCHAR(20) | diaria / semanal / mensual / anual |
| estado | VARCHAR(20) | activa / cancelada / finalizada |
| fecha_creacion | DATETIME | Fecha en que se registró |
| creado_por_admin | BIT | 1 si el admin reservó por otro usuario |

---

#### 7. `Cancelacion`
Registra el historial de cancelaciones con motivo y responsable.

| Campo | Tipo | Descripción |
|-------|------|-------------|
| id_cancelacion | INT (PK) | Identificador único |
| id_reserva | INT (FK) | Reserva cancelada |
| id_usuario_cancela | INT (FK) | Usuario que canceló |
| fecha_cancelacion | DATETIME | Fecha y hora de cancelación |
| motivo_cancelacion | VARCHAR(255) | Motivo de la cancelación |

---

### Relaciones entre tablas

```
BLOQUE ──────────< AMBIENTE
USUARIO ─────────< RESERVA >──────── AMBIENTE
RESERVA >──────── EVENTO (opcional)
RESERVA ─────────< CANCELACION
USUARIO ─────────< CANCELACION
USUARIO ─────────< EVENTO (responsable)
```

---

## 📊 Datos de prueba cargados

```sql
SELECT * FROM Usuario;
SELECT * FROM Evento;
SELECT * FROM Reserva;
SELECT * FROM Cancelacion;
```

### Tabla `Usuario`

| id_usuario | codigo | nombre_completo | tipo_usuario | carrera_area | correo | telefono | username | password_hash | es_admin | estado |
|-----------|--------|----------------|-------------|-------------|--------|---------|---------|--------------|---------|--------|
| 1 | ADM001 | Admin Sistema | administrativo | Sistemas | admin@uab.edu.bo | 70000001 | admin | hash_admin | 1 | activo |
| 2 | DOC001 | Juan Pérez | docente | Ingeniería | jperez@uab.edu.bo | 70000002 | jperez | hash_jperez | 0 | activo |
| 3 | EST001 | María Flores | estudiante | Sistemas | mflores@uab.edu.bo | 70000003 | mflores | hash_mflores | 0 | activo |
| 4 | EST002 | Carlos Mamani | estudiante | Administración | cmamani@uab.edu.bo | 70000004 | cmamani | hash_cmamani | 0 | activo |
| 5 | IGL001 | Pastor Ramos | iglesia | NULL | pramos@uab.edu.bo | 70000005 | pramos | hash_pramos | 0 | activo |
| 6 | DOC002 | Ana Quispe | docente | Nutrición | aquispe@uab.edu.bo | 70000006 | aquispe | hash_aquispe | 0 | activo |

---

### Tabla `Evento`

| id_evento | id_responsable | nombre_evento | cantidad_asistentes | requerimientos | fecha_evento |
|----------|---------------|--------------|-------------------|---------------|-------------|
| 1 | 1 | Semana de la Ciencia | 150 | Auditorio con proyector | 2025-09-15 |

---

### Tabla `Reserva`

| id_reserva | id_usuario | id_ambiente | id_evento | fecha_inicio | fecha_fin | hora_inicio | hora_fin | motivo | cantidad_asistentes | es_recurrente | frecuencia | estado | creado_por_admin |
|-----------|-----------|------------|----------|-------------|----------|------------|---------|-------|-------------------|-------------|-----------|-------|-----------------|
| 4 | 2 | 1 | NULL | 2025-06-02 | 2025-06-02 | 07:15 | 08:00 | clases | 35 | 0 | NULL | activa | 0 |
| 5 | 3 | 3 | NULL | 2025-06-03 | 2025-06-03 | 08:55 | 10:25 | laboratorio | 20 | 0 | NULL | cancelada | 0 |
| 6 | 5 | 12 | 1 | 2025-09-15 | 2025-09-15 | 09:00 | 12:00 | evento | 150 | 0 | NULL | activa | 1 |

---

### Tabla `Cancelacion`

| id_cancelacion | id_reserva | id_usuario_cancela | fecha_cancelacion | motivo_cancelacion |
|---------------|-----------|------------------|------------------|-------------------|
| 2 | 5 | 3 | 2026-05-21 | La reserva fue cancelada por mantenimiento del ambiente |

---

## 🖥️ Avance de la aplicación C#

### Formularios desarrollados hasta ahora

#### `Form1` — Login *(nombre provisional, será renombrado a `LoginForm` o similar)*
- Autenticación de usuarios con `username` y `password_hash`
- Validación de campos vacíos
- Verificación de estado activo del usuario
- Detección de rol administrador (`es_admin`)
- Conexión a SQL Server mediante `Conexion.cs`

> ⚠️ **Nota:** Este es un borrador inicial. Los nombres de los formularios están sujetos a cambios durante el desarrollo.

---

### Estructura del proyecto

```
SistemaAmbientesUAB/
├── App.config              ← Cadena de conexión a SQL Server
├── Program.cs              ← Punto de entrada
├── Conexion.cs             ← Clase de conexión reutilizable
├── Form1.cs                ← Formulario de Login (borrador)
├── Form1.Designer.cs       ← Diseño visual del Login
└── AmbientesUAB.sql        ← Script completo de la base de datos
```

---

## 🚀 Cómo ejecutar el proyecto

1. Instalar **SQL Server Express** y **SSMS**
2. Ejecutar el script `AmbientesUAB.sql` en SSMS
3. Abrir la solución en **Visual Studio 2022**
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

## 👥 Equipo

| Integrante |
|-----------|
| Juan Fernando Nina Cachi |
| Axel Alberto Ticona Vallejos |

---

> Proyecto en desarrollo — Base de Datos I · UAB · 2025
