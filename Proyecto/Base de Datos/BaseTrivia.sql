use master
go
set dateformat dmy
if exists(Select * FROM SysDataBases WHERE name='Trivia')
BEGIN
	DROP DATABASE Trivia
END
go

CREATE DATABASE Trivia
ON(
	NAME=Terminal,
	FILENAME='C:\Trivia.mdf'
)
go

-------------------------------------
USE Trivia
go

CREATE TABLE Usuario
(
	Usuario varchar(25) not null unique,
	Cedula  varchar (9)not null,
	Contraseña varchar(25) not null check (LEN(Contraseña)=7),
	nombreCompleto varchar(120) not null,
	primary key(Cedula)
)
go

CREATE TABLE Administrador
(
	Cedula varchar (9) not null,
	VerEstadistica bit not null,
	foreign key(Cedula) references Usuario(Cedula),
	primary key (Cedula)
)
go

CREATE TABLE Jugador
(
	Cedula varchar (9) not null,
	NombrePublico varchar(120) not null,
	foreign key(Cedula) references Usuario(Cedula),
	primary key(Cedula)
)
go

CREATE TABLE Juego
(
	id int Primary Key Identity(1,1),
	tiradas int,
	fechaInicio date,
	fechaFin date
)
go

CREATE TABLE JuegoCliente
(
	Cedula varchar (9) Foreign Key References Jugador(Cedula),
	id int Foreign Key References Juego(id),
	Primary Key(Cedula,id)
)
go

CREATE TABLE Pregunta
(
	id int Identity(1,1),
	tipo varchar(25) not null,
	texto varchar(120) not null,
	Primary Key (id) 
	
)
go

CREATE TABLE JuegoPregunta
(
	idJuego int Foreign Key References Juego(id),
	idPregunta int Foreign Key References Pregunta(id),
	Primary Key(idJuego,idPregunta)
)
go

CREATE TABLE Respuesta
(
	id int Primary Key Identity(1,1),
	texto varchar(70),
	correcto bit
)
go

CREATE TABLE PreguntaRespuesta
(
	idPregutnta int not null Foreign Key References Pregunta(id),
	idRespuesta int not null Foreign Key References Respuesta(id),
	Primary key(idPregutnta,idRespuesta)
)
go

----------------------------------------
