Create database School_Manage_System

Create table AreasTecnicas
(
IdArea int primary key,
Nombre varchar(80) not null
)

Create table Secciones
(
Codigo_Seccion varchar(10) primary key,
IdArea int not null,
Nivel varchar(5) check (Nivel in('4to', '5to', '6to')), 
Seccion char not null,
Aula int unique,
Foreign key(IdArea) references AreasTecnicas(IdArea)
)

Create table Materias
(
Codigo_Materia varchar(12) primary key,
Nombre varchar(40) not null,
IdArea int
foreign key (IdArea) references AreasTecnicas(IdArea)
)

Create table Estudiantes
(
 Matricula varchar(10) check(len(Matricula)=10) primary key,
 Nombre varchar(50) not null,
 Apellido varchar(50) not null,
 Telefono varchar(12) check(len(Telefono)=12) not null,
 CorreoElectronico varchar(Max),
 FechaNacimiento date not null,
 Direccion varchar(Max) not null,
 NombrePadre varchar(50) not null,
 NombreMadre varchar(50) not null,
 CedulaPadre varchar(11) not null,
 CedulaMadre varchar(11) not null,
 Foto2x2 varchar(max) not null,
 IdArea int not  null,
 Seccion varchar(10) not null,
)

Create table Maestros
(
 Cedula varchar(11) primary key,
 Nombre varchar(30) not null,
 Apellido varchar(30) not null,
 Telefono varchar(12) check (len(Telefono)=12) not null,
 CorreoElectronico varchar(max),
 IdArea int

 foreign key (IdArea) references AreasTecnicas (IdArea)
)

Create table MateriasMaestros
(
  IdAsignacion int primary key,
  Cedula varchar(11) not null,
  Codigo_Materia varchar(12) not null

  foreign key(Cedula) references Maestros(Cedula),
  foreign key(Codigo_Materia) references Materias(Codigo_Materia)
)

Create table MaestrosAulas
(
  IdAsignacion int,
  Codigo_Seccion varchar(10)
  primary key (IdAsignacion, Codigo_Seccion),
  foreign key (IdAsignacion) references MateriasMaestros (IdAsignacion),
  foreign key (Codigo_Seccion) references Secciones (Codigo_Seccion)
)

Create table EstudiantesCalificaciones
(
 Codigo_Calificacion int primary key,
 Matricula varchar(10) not null,
 Codigo_Materia varchar(12) not null,
 Periodo int check (Periodo in (1, 2, 3, 4)) not null,

 Foreign key (Matricula) references Estudiantes(Matricula),
 Foreign key (Codigo_Materia) references Materias(Codigo_Materia)
)

Create table HistorialAsistencia
( 
  Codigo int primary key,
  Matricula varchar(10) not null,
  Codigo_Materia varchar(12) not null,
  Fecha date not null,
  Asistencia bit not null

  foreign key (Matricula) references Estudiantes(Matricula),
  foreign key (Codigo_Materia) references Materias(Codigo_Materia)
)

Create table AvisosAdministración
(
 IdAviso int primary key, 
 DetalleAviso varchar(max) not null,
 DirigidoA varchar(50) 
	check (DirigidoA in('Maestros', 'Toda la escuela', 'Padres', 'Toda la comunidad Educativa')),
 Fecha date not null,
 VigenciaHasta date not null
)

Create table AvisosMaestros
(
 IdAviso int primary key,
 CedulaMaestro varchar(11) not null,
 DetalleAviso varchar(max) not null,
 Fecha date not null,
 HoraRegistrado time not null,
 VigenciaHasta date not null

 Foreign key(CedulaMaestro) references Maestros(Cedula)
)

Create table AvisosCursos
(
 IdAviso int,
 Codigo_Seccion varchar(10) not null,

 primary key(IdAviso, Codigo_Seccion),
 foreign key (IdAviso) references AvisosMaestros (IdAviso),
 foreign key (Codigo_Seccion) references Secciones(Codigo_Seccion)
)

Create table ReportesAEstudiantes
(
 Codigo_Reporte int primary key,
 Matricula varchar(10) not null,
 Causa varchar(20) check (Causa in('Irrespeto', 'Irresponsabilidad', 'Agresión física')) not null,
 CedulaMaestro varchar(11) not null,
 Fecha date not null

 Foreign key (Matricula) references Estudiantes(Matricula),
 Foreign key (CedulaMaestro) references Maestros(Cedula)
)

Create table Excusas
(
 IdExcusa int primary key,
 Matricula varchar(10) not null,
 Fecha date not null,

 Foreign key (Matricula) references Estudiantes(Matricula)
)

Create table Roles
(
 IdRol int primary key,
 Nombre varchar(20) not null
)

Create table Usuarios
(
  NombreUsuario varchar(50) primary key,
  PasswordHash varchar(max) not null,
  fotoPerfil varchar(max),
  IdRol int not null

  foreign key(IdRol) references Roles(IdRol)
)


-- INSERCIONES DE DATOS A LAS TABLAS

-- Tabla roles
Insert into Roles values(1, 'Administrador')
Insert into Roles values(2, 'Maestro')
Insert into Roles values(3, 'Estudiante')
Insert into Roles values(4, 'Padre')


-- Tabla Areas Técnicas
Insert into AreasTecnicas values(1,'Desarrollo y administración de aplicaciones informaticas')
Insert into AreasTecnicas values(2, 'Gestión administrativa y tributaria')
Insert into AreasTecnicas values(3, 'Electrónica')
Insert into AreasTecnicas values(4, 'Mecatrónica')
Insert into AreasTecnicas values(5, 'Mecánica Automotriz')
Insert into AreasTecnicas values(6, 'Enfermería')
Insert into AreasTecnicas values(7, 'Electricidad')

-- Creación de usuario administrador
Insert into Usuarios values('Admin', '60fe74406e7f353ed979f350f2fbb6a2e8690a5fa7d1b0c32983d1d8b3f95f67', null, 1)