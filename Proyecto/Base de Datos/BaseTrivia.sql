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
	NAME=Trivia,
	FILENAME='D:\Trivia.mdf'
)
go

-------------------------------------
USE Trivia
go

CREATE TABLE Usuario
(
	Usuario varchar(25) not null unique,
	Cedula  varchar (9)not null,
	Contrase�a varchar(25) not null,
	NombreCompleto varchar(120) not null,
	primary key(Cedula)
)
go

CREATE TABLE Administrador
(
	Cedula varchar (9) not null,
	VerEstadisticas bit not null,
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
	IdJuego int Primary Key Identity(1,1),
	Tiradas int,
	FechaInicio datetime,
	FechaFin datetime
)
go

CREATE TABLE JuegoCliente
(
	Cedula varchar (9) Foreign Key References Jugador(Cedula),
	IdJuego int Foreign Key References Juego(IdJuego),
	Primary Key(Cedula,IdJuego)
)
go

CREATE TABLE Pregunta
(
	IdPregunta int Identity(1,1),
	Tipo varchar(25) not null,
	Texto varchar(120) not null,
	Primary Key (IdPregunta) 
	
)
go

CREATE TABLE JuegoPregunta
(
	IdJuego int Foreign Key References Juego(IdJuego),
	IdPregunta int Foreign Key References Pregunta(idPregunta),
	Primary Key(IdJuego,IdPregunta)
)
go

CREATE TABLE Respuesta
(
	IdRespuesta int Primary Key Identity(1,1),
	Texto varchar(70),
	Correcto bit
)
go

Create TABLE PreguntaRespuesta
(
	IdPregunta int not null Foreign Key References Pregunta(IdPregunta),
	IdRespuesta int not null Foreign Key References Respuesta(IdRespuesta),
	Primary key(IdPregunta,IdRespuesta)
)
go



----------------------------------------

---------------PA. ADMINS---------------

----------------------------------------


Create Procedure AltaAdmin
@Usuario varchar(25), 
@Cedula varchar(9),
@Contrase�a varchar(25),
@NombreCompleto varchar(120),
@VerEstadisticas bit
AS
begin
	if exists(select * from Usuario where Usuario.Usuario=@Usuario)
begin
	return -1
end

	if exists(select * from Usuario where Usuario.Cedula=@Cedula)
begin
	return -2
end

begin tran
	Insert into Usuario(Usuario,Cedula,Contrase�a,nombreCompleto) values (@Usuario, @Cedula, @Contrase�a, @NombreCompleto)
	if(@@ERROR<>0)
	begin
		return -3
		rollback tran
	end
	Insert into Administrador(Cedula,VerEstadistica) values (@Cedula, @VerEstadisticas)
	if(@@ERROR<>0)
		begin
			return -3
			rollback tran
		end
	else
		begin
		commit tran
		return 0
	end
end

go

Create Procedure BajaAdmin
@Cedula varchar (9)
AS
begin
if not exists(select * from Usuario where Usuario.Cedula=@Cedula)
begin
return -1
end

begin tran
delete from Administrador where Administrador.Cedula=@Cedula
	if(@@ERROR<>0)
		begin
			rollback tran
			return -2
		end
delete from Usuario where Usuario.Cedula=@Cedula
	if(@@ERROR<>0)
		begin
			rollback tran
			return -2
		end
	else
		begin
			commit tran
		return 0
	end
end
go

Create Procedure BuscarAdmin
@Cedula varchar(9)
AS
begin
select * from Usuario inner join Administrador on Usuario.Cedula=Administrador.Cedula
where Administrador.Cedula=@Cedula
end
go

Create Procedure ModificarAdmin
@Usuario varchar(25), 
@Cedula varchar(9),
@Contrase�a varchar(25),
@NombreCompleto varchar(120),
@VerEstadisticas bit
AS
begin
if not exists(select * from Usuario where Usuario.Cedula=@Cedula)
begin
return -1
end

begin tran
Update Usuario set Usuario=@Usuario,Cedula=@Cedula,Contrase�a=@Contrase�a,nombreCompleto=@NombreCompleto where Usuario.Cedula=@Cedula
if(@@ERROR<>0)
	begin
		return -2
		rollback tran
	end
Update Administrador set Cedula=@Cedula,VerEstadistica=@VerEstadisticas where Administrador.Cedula=@Cedula 

if(@@ERROR<>0)
begin
return -2
rollback tran
end

else
begin
commit tran
return 1
end
end

go


----------------------------------------

--------------PA. JUGADOR---------------

----------------------------------------


Create Procedure AltaJugador
@Usuario varchar(25), 
@Cedula varchar(9),
@Contrase�a varchar(25),
@NombreCompleto varchar(120),
@NombrePublico varchar(120)
AS
begin
if exists(select * from Usuario where Usuario.Usuario=@Usuario)
begin
return -1
end

if exists(select * from Usuario where Usuario.Cedula=@Cedula)
begin
return -2
end

begin tran
Insert into Usuario(Usuario,Cedula,Contrase�a,nombreCompleto) values (@Usuario, @Cedula, @Contrase�a, @NombreCompleto)
	if(@@ERROR<>0)
	begin
		return -2
		rollback tran
	end
Insert into Jugador(Cedula,NombrePublico) values (@Cedula, @NombrePublico)
	if(@@ERROR<>0)
	begin
		return -2
		rollback tran
	end

else
	begin
		commit tran
		return 0
	end
end

go



----------------------------------------

--------------PA. PREGUNTAS-------------

----------------------------------------


create procedure AltaPregunta
@Tipo varchar(25),
@Texto varchar(120)
AS
begin
Insert into Pregunta(Tipo, Texto) values(@Tipo, @Texto)
end

go

create procedure BajaPregunta
@IdPregunta int
AS
begin

if not exists (select * from Pregunta where id=@IdPregunta)
begin
return -1
end

begin tran
delete from PreguntaRespuesta where idPregutnta=@IdPregunta
delete from Pregunta where id=@IdPregunta

if (@@ERROR<>0)
begin
rollback tran
return -2
end

else
begin
commit tran
return 1
end
end
go

create procedure BuscarPregunta
@IdPregunta int
AS
begin
select * from Pregunta where id=@IdPregunta
end

go

create procedure ModificarPregunta
@IdPregunta int, 
@Tipo varchar(25),
@Texto varchar(120)
AS
begin
Update Pregunta set Tipo=@Tipo, Texto=@Texto where id =@IdPregunta
end

go


----------------------------------------

----------------PA. JUEGO---------------

----------------------------------------


Create Procedure AltaJuego
@Cedula varchar(9)
AS
Begin
if not exists(select * from Jugador where Jugador.Cedula=@Cedula)
begin
return -1
end

begin tran
Insert into Juego(Tiradas,FechaInicio,FechaFin) values (0,GETDATE(),null)
Insert into JuegoCliente(Cedula,id) values (@Cedula,@@IDENTITY)

if (@@ERROR<>0)
begin
rollback tran
return -2
end

else
begin
commit tran
return 1
end
end

go



