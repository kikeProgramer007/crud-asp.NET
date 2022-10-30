Create database crud

use crud

create table Usuario(
 id_usuario int identity (1,1),
 nombre varchar(15),
 edad int,
 correo varchar(max),
 fecha_nacimiento date
)

go
create procedure sp_load
as begin
select * from Usuario
end

--CRUD: CREATE, READ, UPDATE, DELETE
go
create procedure sp_create
@nombre varchar(15),
@edad int,
@correo varchar(max),
@fecha date
as begin
insert into Usuario values(@nombre, @edad, @correo, @fecha)
end

--READ
go
create procedure sp_read
@id int
as begin
select * from Usuario where id_usuario=@id
end
exec sp_read 2

--UPDATE
go
create procedure sp_update
@id int,
@nombre varchar(15),
@edad int,
@correo varchar(max),
@fecha date
as begin
	update Usuario set nombre=@nombre, edad=@edad, correo=@correo, fecha_nacimiento=@fecha
	where id_usuario=@id
end

--DELETE
go
create procedure sp_delete
@id int
as begin
	delete from Usuario where id_usuario=@id
end

select * from Usuario

