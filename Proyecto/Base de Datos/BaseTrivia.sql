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
	Contraseña varchar(25) not null,
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
	NombrePublico varchar(120) unique not null,
	foreign key(Cedula) references Usuario(Cedula),
	primary key(Cedula)
)
go

CREATE TABLE Juego
(
	IdJuego int Primary Key Identity(1,1),
	Tiradas int default (0),
	FechaInicio datetime,
	FechaFin datetime default (null)
)
go

CREATE TABLE JuegoJugador
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
	Texto varchar(200) not null,
	Primary Key (IdPregunta) 
	
)
go

CREATE TABLE JuegoPregunta
(
	IdJuego int Foreign Key References Juego(IdJuego),
	IdPregunta int Foreign Key References Pregunta(idPregunta),
	contestadaCorrecta bit,
	Primary Key(IdJuego,IdPregunta)
)
go

CREATE TABLE Respuesta	
(
	IdPregunta int Foreign Key References Pregunta(idPregunta),
	IdRespuesta int Check(IdRespuesta > 0 AND IdRespuesta < 4),
	Texto varchar(70),
	Correcto bit default (0),
	Primary Key(IdPregunta,IdRespuesta)
)
go



----------------------------------------

---------------PA. ADMINS---------------

----------------------------------------


Create Procedure AltaAdmin
@Usuario varchar(25), 
@Cedula varchar(9),
@Contraseña varchar(25),
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
	Insert into Usuario(Usuario,Cedula,Contraseña,nombreCompleto) values (@Usuario, @Cedula, @Contraseña, @NombreCompleto)
	if(@@ERROR<>0)
	begin
		return -3
		rollback tran
	end
	Insert into Administrador(Cedula,VerEstadisticas) values (@Cedula, @VerEstadisticas)
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
@Contraseña varchar(25),
@NombreCompleto varchar(120),
@VerEstadisticas bit
AS
begin
if not exists(select * from Usuario where Usuario.Cedula=@Cedula)
begin
return -1
end

begin tran
Update Usuario set Usuario=@Usuario,Cedula=@Cedula,Contraseña=@Contraseña,nombreCompleto=@NombreCompleto where Usuario.Cedula=@Cedula
if(@@ERROR<>0)
	begin
		return -2
		rollback tran
	end
Update Administrador set Cedula=@Cedula,VerEstadisticas=@VerEstadisticas where Administrador.Cedula=@Cedula 

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
@Contraseña varchar(25),
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
Insert into Usuario(Usuario,Cedula,Contraseña,nombreCompleto) values (@Usuario, @Cedula, @Contraseña, @NombreCompleto)
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

if not exists (select * from Pregunta where IdPregunta=@IdPregunta)
begin
return -1
end

begin tran
delete from Respuesta where IdPregunta=@IdPregunta
if (@@ERROR<>0)
begin
rollback tran
return -2
end
delete from Pregunta where IdPregunta=@IdPregunta

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
select * from Pregunta where IdPregunta=@IdPregunta
end

go

create procedure ModificarPregunta
@IdPregunta int, 
@Tipo varchar(25),
@Texto varchar(120)
AS
begin
Update Pregunta set Tipo=@Tipo, Texto=@Texto where IdPregunta =@IdPregunta
end

go




----------------------------------------

--------------PA. Respuestas-------------

----------------------------------------


create procedure AltaRespuesta
@IdPregunta int,
@IdRespuesta int,
@Texto varchar(70),
@Correcto bit
AS
begin
Insert into Respuesta(IdPregunta, IdRespuesta,Texto,Correcto ) values(@IdPregunta, @IdRespuesta,@Texto,@Correcto)
end

go

create procedure BajaRespuesta
@IdPregunta int,
@IdRespuesta int
AS
begin

if not exists (select * from Respuesta where IdPregunta=@IdPregunta and IdRespuesta=@IdRespuesta)
begin
return -1
end

begin tran
delete from Respuesta where IdPregunta=@IdPregunta and IdRespuesta=@IdRespuesta

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

create procedure BuscarRespuesta
@IdPregunta int,
@IdRespuesta int
AS
begin
select * from Respuesta where IdPregunta=@IdPregunta and IdRespuesta=@IdRespuesta
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
if (@@ERROR<>0)
begin
rollback tran
return -2
end

Insert into JuegoJugador(Cedula,IdJuego) values (@Cedula,@@IDENTITY)

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



----------------------------------------

----------------LOGIN---------------

----------------------------------------

create procedure LoginJugador
@Usuario varchar (25),
@Contraseña varchar (25)
as
begin
	select * from Jugador j inner join Usuario u on u.Cedula = j.Cedula where u.Usuario = @Usuario and u.Contraseña = @Contraseña
end
go

create procedure LoginAdministrador
@Usuario varchar (25),
@Contraseña varchar (25)
as
begin
	select * from Administrador a inner join Usuario u on u.Cedula = a.Cedula where u.Usuario = @Usuario and u.Contraseña = @Contraseña
end
go



