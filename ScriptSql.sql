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

