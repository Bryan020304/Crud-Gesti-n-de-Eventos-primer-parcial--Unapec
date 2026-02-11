nuevo
🎯 Sistema CRUD de Gestión de Eventos - UNAPEC
📋 Información Académica
Universidad: Universidad Acción Pro Educación y Cultura (UNAPEC)

Asignatura: ISO 815 - Integración de Aplicación con Tec Propietaria

Evaluación: 1era Evaluación Parcial (Enero-Abril 2026)

Estudiante: Bryan Candelario, Javier Montero, Jean Pierre

Profesor: Omar Reyes Medina

Fecha de Entrega: 11/02/2026

🚀 Descripción del Proyecto
Sistema web desarrollado en ASP.NET Core MVC 8.0 para la gestión integral de eventos. Implementa operaciones CRUD (Crear, Leer, Actualizar, Eliminar) utilizando Entity Framework Core con SQL Server, siguiendo el patrón Modelo-Vista-Controlador. Incluye inteligencia de negocios para análisis de datos y toma de decisiones.

📊 Objetivos Cumplidos
✅ Desarrollar aplicación web funcional en ASP.NET MVC

✅ Implementar operaciones CRUD con LINQ to SQL

✅ Aplicar correctamente el patrón MVC

✅ Diseñar modelos de datos conectados a base de datos relacional

✅ Crear vistas amigables utilizando Razor

✅ Implementar validaciones en formularios

✅ Probar funcionamiento completo del sistema

✅ Inteligencia de Negocios: Dashboard con métricas y análisis

🛠️ Tecnologías Utilizadas
Backend
Framework: ASP.NET Core MVC 8.0

Lenguaje: C# 12.0

ORM: Entity Framework Core 8.0

Base de Datos: Microsoft SQL Server Express

Validaciones: Data Annotations

Patrón: Modelo-Vista-Controlador (MVC)

Frontend
UI Framework: Bootstrap 5.3

Motor de Vistas: Razor Pages

Iconografía: Bootstrap Icons

Validaciones: JavaScript + Data Annotations

Responsive Design: Mobile-first

Herramientas de Desarrollo
IDE: Visual Studio 2022

Control de Versiones: Git + GitHub

Gestor de Paquetes: NuGet

Servidor Web: Kestrel

📁 Estructura del Proyecto

EventosCRUD-UNAPEC/
│
├── Controllers/                    # Controladores MVC
│   └── EventosController.cs       # Controlador principal de Eventos
│
├── Models/                        # Modelos de datos
│   ├── Evento.cs                  # Modelo principal de Evento
│   └── AppDbContext.cs            # Contexto de base de datos
│
├── Views/                         # Vistas Razor
│   └── Eventos/
│       ├── Index.cshtml          # Lista de eventos con métricas
│       ├── Create.cshtml         # Formulario creación
│       ├── Edit.cshtml           # Formulario edición
│       ├── Details.cshtml        # Detalles del evento
│       ├── Delete.cshtml         # Confirmación eliminación
│       └── Dashboard.cshtml      # Dashboard de inteligencia de negocios
│
├── ViewModels/                    # Modelos de vista
│   └── DashboardViewModel.cs     # Modelo para dashboard
│
├── wwwroot/                       # Archivos estáticos
│   └── lib/
│       └── bootstrap/            # Bootstrap CSS/JS
│
├── Migrations/                    # Migraciones de EF Core
│   ├── [timestamp]_InitialCreate.cs
│   ├── [timestamp]_AddCapacidadMaximaAndBusinessIntelligence.cs
│   └── AppDbContextModelSnapshot.cs
│
├── Properties/                    # Configuración del proyecto
│   └── launchSettings.json
│
├── appsettings.json              # Configuración de la aplicación
├── appsettings.Development.json  # Configuración desarrollo
├── Program.cs                    # Punto de entrada
├── EventosCRUD.csproj           # Archivo del proyecto
├── README.md                    # Documentación
└── .gitignore                   # Archivos ignorados por Git


🎯 Funcionalidades Implementadas
1. Operaciones CRUD Completas
Create (Crear): Formulario para agregar nuevos eventos

Read (Leer): Listado y visualización detallada de eventos

Update (Actualizar): Edición de eventos existentes

Delete (Eliminar): Eliminación de eventos con confirmación

2. Inteligencia de Negocios (NUEVO)
Dashboard Analítico: Métricas clave en tiempo real

Métricas Calculadas:

Lugares Disponibles: Capacidad - Asistentes

Porcentaje de Ocupación: (Asistentes / Capacidad) * 100%

Estado del Evento: Hoy, Próximo, Programado, Finalizado

Disponibilidad: Agotado, Últimos lugares, Disponible

Análisis Agregados:

Total de eventos activos

Eventos próximos (7 días)

Eventos finalizados

Ocupación general del sistema

Distribución por estado

3. Validaciones Avanzadas
Validaciones del lado del servidor: Data Annotations

Validaciones del lado del cliente: HTML5 + JavaScript

Campos requeridos: Todos los campos obligatorios

Rangos válidos: Asistentes entre 0 y 1000

Tipos de datos: Fechas válidas, números positivos

Validaciones de negocio: Asistentes ≤ Capacidad Máxima

4. Interfaz de Usuario
Diseño responsive: Adaptable a móviles, tablets y desktop

Navegación intuitiva: Menú con acceso al Dashboard

Feedback visual: Mensajes de éxito/error con badges de color

Accesibilidad: Etiquetas semánticas y ARIA

Visualización de datos: Tablas con métricas en tiempo real
    
5. Gestión de Base de Datos
Entity Framework Core: ORM para acceso a datos

Migrations: Control de versiones del esquema

SQL Server: Base de datos relacional robusta

LINQ: Consultas fuertemente tipadas
