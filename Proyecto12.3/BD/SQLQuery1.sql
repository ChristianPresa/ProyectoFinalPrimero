create database Pronostico
on (
name= Pronostico,
filename ='C:\Bios\Pronostico.mdp'
)
go

use Pronostico
go

create table Pais(

CodPais varchar (3) not null primary key check (CodPais like '[A-Z][A-z][A-Z]') ,
NomPais varchar (30) not null

)
go

create table Ciudad(
CodCiudad varchar (3) not null check (CodCiudad like '[A-Z][A-z][A-Z]')  ,
CodPais varchar(3) not null foreign key references Pais (CodPais),
NomCiudad varchar (50) not null,
Primary key (CodCiudad,CodPais)
)
go

Create table usuario(
NomLog varchar (50) not null primary key,
Contraseña varchar (50) not null,
Nombre1 varchar (30) not null,
Nombre2 varchar (30) null,
Apellido1 varchar (30)not null,
Apellido2 varchar (30) null

--foreign key (CodUsuario) references escriben(CodUsuario),
)
go

create table Pronostico(
Probabilidad int not null,
TipoCielo varchar (50) not null, --check (TipoCielo like 'nuboso''despejado'^'parcialmente nuboso'),
VelocidadViento int  not null,
CodPronostico int not null primary key identity,
Fecha date not null ,
Hora time not null,
TempMax int not null,
TempMin int not null,
CodPais varchar (3) not null,
CodCiudad varchar (3) not null,

foreign key (CodCiudad,CodPais) references Ciudad (CodCiudad,CodPais)


)
go

create table Escriben(
NomLog varchar (50) not null ,
CodPronostico int not null ,
foreign key (NomLog) references usuario (NomLog),
foreign key (CodPronostico) references Pronostico (CodPronostico)
)
go




------------------------------------------

--USUARIO

insert into usuario(Nombre1,Nombre2,Apellido1,Apellido2,NomLog,Contraseña)values
('Çhristian','Gabriel','Presa','Boms','logueo1','ch123')

--------------------------------------------
--PAIS

insert into Pais (CodPais, NomPais)values
('URU','Uruguay')
insert into Pais (CodPais, NomPais)values
('arg','argentina')
insert into Pais (CodPais, NomPais)values
('esp','españa')


---------------------------------------------
--CIUDAD

insert into Ciudad (CodPais,CodCiudad,NomCiudad) values
('URU','MVD','Montevideo')
insert into Ciudad (CodPais,CodCiudad,NomCiudad) values
('arg','bas','Buenosaires')
insert into Ciudad (CodPais,CodCiudad,NomCiudad) values
('esp','mad','Madrid')
---------------------------------------------
--PRONOSTICO

insert into Pronostico (Probabilidad,TipoCielo,TempMax,TempMin,VelocidadViento,Fecha,Hora,CodCiudad,CodPais)values
(10,'nuboso',30,20,20,'10/10/2021' ,'06:00:00','MVD','URU')




----------------------------------------------------  USUARIO  ---------------------------------------------

create proc Logueo
@NomLog varchar(50),
@Contraseña varchar (50)
as 
begin
select * from Usuario where NomLog = @NomLog and Contraseña = @Contraseña
end


create proc BuscarUsuarios
@NomLog varchar (50)
as
begin
	Select * from usuario where usuario.NomLog = @NomLog
end



--EXEC Logueo 'logueo1','ch123'

create proc AltaUsuario
@NomLog varchar (50),
@Contraseña varchar (50),
@Nombre1 varchar (30),
@Nombre2 varchar (30),
@Apellido1 varchar (30),
@Apellido2 varchar (30)
as
begin
if exists (select * from usuario where NomLog = @NomLog)
    return -1
    else
    
	insert into usuario values (@NomLog, @Contraseña, @Nombre1,@Nombre2,@Apellido1,@Apellido2)
	return 1
end


--exec  AltaUsuario 'mat3','222','Mati2','mat3','rod2','rod3'


--select * from usuario

-----
create proc ModificarUsuario
@NomLog varchar (50),
@Contraseña varchar (50),
@Nombre1 varchar (30),
@Nombre2 varchar (30),
@Apellido1 varchar (30),
@Apellido2 varchar (30)
as
begin
if  not exists (select * from usuario where NomLog = @NomLog)
    return -1
    else
		update Usuario set Contraseña=@Contraseña, Nombre1=@Nombre1, Nombre2=@Nombre2,
		Apellido1 = @Apellido1,Apellido2=@Apellido2 where NomLog = @NomLog
	
		return 1
end

--declare @resultado int
--exec @resultado= ModificarUsuario 'mat3','666','Mati2','mat3','rod2','rod3'
--select @resultado

--Select * from usuario

----
create proc EliminarUsuario
@NomLog varchar (50)
as
begin
    if not exists ( select * from usuario where NomLog = @NomLog)
    return -2
	if exists (select * from Escriben where NomLog = @NomLog)
		return -1
	else	
	delete from Usuario where NomLog = @NomLog
    return 1
end

--declare @resultado int
--exec @resultado= EliminarUsuario 'mat'
--select @resultado

--Select* from usuario

 ------------------------------------------------------------------------------- Pais  -------------------------------------------------------------------------------

create proc BuscarPais
@CodPais varchar(3)
as 
begin
select * from Pais where CodPais =@CodPais
end


--exec BuscarPais 'URU'

--------
create  proc AgregarPais
@CodPais varchar (3) ,
@NomPais varchar (30)
as 
begin
if exists (select * from Pais where CodPais = @CodPais )
return -1
else
 insert into Pais values (@CodPais,@NomPais)
return 1
	end
	
declare @resultado int 
exec @resultado = AgregarPais 'ARG', 'Argentina'
Select @resultado
	
--	select * from Pais
	
-------
create proc ModPais
@CodPais varchar (3),
@NomPais varchar (30)	
as 
begin
 if not exists (select * from Pais where CodPais = @CodPais)
 return -1
	update Pais set NomPais = @NomPais where CodPais=@CodPais
	return 1
end

--declare @resultado int 
--	exec @resultado = ModPais 'ukr', 'ucrania'
--	Select @resultado
 
 ------
 
create proc EliminarPais
@CodPais varchar (3)
as 
begin
	if not exists (select * from Pais where CodPais =  @CodPais)
		return -4
	if exists (select * from Pronostico where CodPais =  @CodPais)
		return -1

	begin transaction
	delete from Ciudad where CodPais = @CodPais
	if @@ERROR <> 0
	begin
		rollback tran
		return -2
	end
	delete from Pais where CodPais =@CodPais
	if @@ERROR <>0
	begin 
		rollback tran
		commit tran
		return -3
	end
  end 

declare @resultado int 
exec @resultado = EliminarPais 'ARG'
Select @resultado
 
 select *from Pais
 
 ------------------
 
 ------------------------------------------------------------------------------- CIUDAD  -------------------------------------------------------------------------------
 
 Create proc BuscarCiudad
@CodCiudad varchar(50),
@CodPais varchar (50)
as
begin
select * from Ciudad where CodCiudad = @CodCiudad and CodPais = @CodPais
end

--exec BuscarCiudad 'MVD','URU'

create proc AgregarCiudad
 @CodPais varchar (3),
 @CodCiudad varchar (3),
 @NomCiudad varchar (30)
 as 
 begin
 if not exists (select * from Pais where CodPais = @CodPais)
 return -1
 if exists (select * from Ciudad where CodCiudad = @CodCiudad and CodPais =@CodPais)
 return -2
 else 
 insert into Ciudad (CodPais,CodCiudad,NomCiudad) values (@CodPais,@CodCiudad,@NomCiudad)
 return 1
 end
 
 --declare @resultado int 
--	exec @resultado = AgregarCiudad 'Arg', 'BSA','Buenos aires'
--	Select @resultado
 --
 --select * from Ciudad
 
 --select * from usuario
 
 -------

create proc ModCiudad
 @CodCiudad varchar (3),
 @NomCiudad varchar (30),
 @CodPais varchar (3)
 as 
 begin
 if not exists (select * from Ciudad where CodCiudad =@CodCiudad and CodPais = @CodPais)
 return -1
 else
 update ciudad set NomCiudad = @NomCiudad where CodCiudad = @CodCiudad

 return 1
 end
 
 --declare @resultado int 
--	exec @resultado = ModCiudad 'BSA','Buenos aires2'
--	Select @resultado
 
-- select * from Ciudad
 
 ----------
 
create proc EliminarCiudad  
 @CodCiudad varchar(3),
 @CodPais varchar (3)
 as 
 begin 
 if not exists (select * from Ciudad where CodCiudad = @CodCiudad and CodPais = @CodPais)
 return -1
		begin tran
		delete from Escriben where CodPronostico in (Select CodPronostico from Pronostico where CodCiudad = @CodCiudad and CodPais = @CodPais)
		if @@ERROR <>0
		begin 
			rollback tran
			return -2
		end 	
		delete from Pronostico where CodCiudad = @CodCiudad and CodPais = @CodPais
		if @@ERROR <>0
		begin 
			rollback tran
			return -3
		end 	
		delete from Ciudad where CodCiudad = @CodCiudad and CodPais = @CodPais
		if @@ERROR <>0
		begin 
			rollback tran
			return -4
		end 		
commit transaction
return 1
end
	
-- declare @resultado int 
--exec @resultado = EliminarCiudad 'BSA','ARG'
--Select @resultado
		
 
-- select * from Ciudad
 
 
 ------------------------------------------------------------------------------- Proonostico  -----------------------------------------------------------------------------------------------------------------
 

create proc AgregarPronostico
@Probabilidad int ,
@TipoCielo varchar (50) ,
@VelocidadViento int ,
@TempMax int ,
@TempMin int ,
@CodCiudad varchar(3),
@CodPais varchar(3),
@NomLog varchar (20),
@Fecha date,
@Hora time 
as
begin
if not exists ( select * from Usuario where Usuario.NomLog = @NomLog)-- Si el usuario no existe va al ELSE
begin
return -1
end
else
if not exists ( select * from Ciudad where Ciudad.CodCiudad = @Codciudad and Ciudad.CodPais = @CodPais)-- Si la ciudad no existe va al ELSE
begin
return -2
end
else
begin transaction
declare @CodPronostico int
insert into Pronostico(Probabilidad,TipoCielo,VelocidadViento,TempMax,TempMin,CodCiudad,CodPais,Fecha,hora) values(@Probabilidad,@TipoCielo,@VelocidadViento,@TempMax,@TempMin,@CodCiudad,@CodPais,Convert(nvarchar(10),@Fecha,101),@hora)
set @CodPronostico = @@IDENTITY
if @@ERROR <> 0
begin
rollback tran
return -3
end insert into Escriben values(@NomLog,@CodPronostico)
if @@ERROR <> 0
begin
rollback tran
return -4
end
commit tran
return @CodPronostico
end


declare @resultado int
exec @resultado=AgregarPronostico 8,'Nubos',15,30,19,'MVD','URU','logueo1','13/03/2022','10:25:00'
select @resultado

--select* from Pronostico
--select* from usuario


 ------------------------------------------------------------------------------- Listar  -------------------------------------------------------------------------------

create proc ListarPronosticoPorCiudad
@CodPais varchar (3),
@CodCiudad varchar (3)
as 
begin
select * from Pronostico inner join Escriben
on Escriben.CodPronostico = Pronostico.CodPronostico
where CodPais = @CodPais and CodCiudad = @CodCiudad
order by Fecha, Hora
end

exec ListarPronosticoPorCiudad  'ASD','MVD'


create proc ListarCiudadPorPais
@CodPais varchar (3)
as 
begin
select * from Ciudad where Ciudad.CodPais = @CodPais
end


create proc ListarPais
as 
begin
select * from Pais
end


create proc ListarPronosticoDiario
@Fecha date
as 
begin
	select * from Pronostico inner join Escriben 
	on Escriben.CodPronostico = Pronostico.CodPronostico 
	where Fecha = Convert(nvarchar(10),@Fecha,101)
end

exec ListarPronosticoDiario '03/13/2022'

--select * from Pronostico

create proc ListarCiudad
as
begin
	select * from Ciudad
end

select * from pais
