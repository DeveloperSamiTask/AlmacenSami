
use BDBoticaCurso 
go

Alter procedure Sp_Registrar_Credito
(
@idnotacredito char (11),
@idDoc char (11),
@Fecha_Credito datetime,
@nomcliente varchar (50),
@total_ped real,
@Saldo_Pdnte real,
@Fecha_vncmnto Date

)
as
insert into credito 
values
(
@idnotacredito ,
@idDoc  ,
@Fecha_Credito ,
@nomcliente ,
@total_ped ,
@Saldo_Pdnte ,
@Fecha_vncmnto ,
'Pendiente'
)
go


--======================
Alter procedure Sp_ingresar_det_Credito
(
@idnotacredito char (11),
@Acuenta real,
@saldoactual real,
@Fecha_Pago datetime,
@TipoPago varchar (50),
@nroOpera nvarchar (max),
@idUsu int
)
as
insert into detalle_credito 
values
(
@idnotacredito ,
@Acuenta ,
@saldoactual,
@Fecha_Pago,
@TipoPago ,
@nroOpera ,
@idUsu 
)
go


--una vista:
Create View V_Documento_Credito
as
select 
c.IdNotaCred, c.Fecha_Credito , c.Nom_Cliente , c.Total_Cre , c.Saldo_Pdnte, c.Fecha_Vncimnto , c.Estado_Cred ,
d.id_Doc , d.Fecha_Emi ,d.ImporteDoc, d.Estado_Doc,
p.id_Ped, p.TotalGancia, p.TotalPed, p.Estado_Ped, 
k.Id_Cliente, k.Razon_Social_Nombres, k.Limit_Credit, k.DNI
from Credito c, Documento d, Pedido p , Cliente k
where
c.id_Doc=d.id_Doc and
d.id_Ped = p.Id_Ped and
p.Id_Cliente= k.Id_Cliente
go



--nuevo nuevo nuevo nuevo
Create Procedure Sp_Ver_SumaTotal_credito_xcliente
@nomcliente varchar (50)
as
select SUM(Total_Cre) from V_Documento_Credito
Where
Id_Cliente=@nomcliente or
Nom_Cliente = @nomcliente and
Saldo_Pdnte > 0
Go

select * from Caja
go



----validamos el credito para que no se vayan a crear dos Agendas del mismo pedido
Create Procedure Sp_validar_credito
@Id_Doc char (11)
as
select COUNT (*) from Credito 
where Id_Doc =  @Id_Doc 
Go


-- verificamos si la fecha de vencimiento es igual al dia de hoy, para avisar al admin que
 --hay un credito vencido hoy
alter Procedure Sp_verificar_vencimiento_credito
	@Cod_credito char (11)
	as
	select COUNT (*) from Credito 
	where 
	DATEPART (YEAR,GETDATE()) = DATEPART(YEAR ,Fecha_Vncimnto) and
	DATEPART (DAYOFYEAR,GETDATE()) > DATEPART (DAYOFYEAR ,Fecha_Vncimnto)
	and IdNotaCred =@Cod_credito OR 
	DATEPART (YEAR,GETDATE()) > DATEPART(YEAR ,Fecha_Vncimnto) and
	DATEPART (DAYOFYEAR,GETDATE()) < DATEPART (DAYOFYEAR ,Fecha_Vncimnto)
	and IdNotaCred =@Cod_credito 
Go




----actualizar tabla principal del credito
--Create Procedure Sp_Actualizar_TablaPrincipal_credito
--	@idnotacredito char (6),
--	@idDoc char (11),
--	@nomcliente varchar (50),
--	@total_ped real,
--	@Saldo_Pndte real,
--	@Fecha_vncmnto Date,
--	@xstado varchar (13)
	
--As
--	Begin Tran
--	update Credito set 
--	Id_Doc =@idDoc ,
--	Nom_Cliente =@nomcliente ,
--	Total_Cre =@total_ped,
--	Saldo_Pdnte=@Saldo_Pndte ,
--	Fecha_Vncimnto =@Fecha_vncmnto ,
--	Estado_Cred=@xstado 
--Where 
--IdNotaCred =@idnotacredito 
--if @@ERROR <> 0 
--begin 
--print @@error
--rollback tran
--return
--end
--commit tran
--go

--update notacredito--
Alter Proc Sp_Actualizar_Saldo_Pdnte
(
@idnotacredito char (11),
@Saldo_Pndte real,
@Stado varchar (13)
)
as
BEGIN TRAN
update  Credito    set 
Saldo_Pdnte = @Saldo_Pndte,
Estado_Cred=@Stado 
where 
IdNotaCred =@idnotacredito  
 if @@ERROR <> 0 
begin 
print @@error
rollback tran
return
end
commit tran
go



--actualizar el estado de un credito, cuando es cancelado en su totalidad
Alter Procedure Sp_Actualizar_Estado_credito
@Id_credito  char (11),
@xstado varchar (13)
As
update Credito set 
Estado_Cred = @xstado 
where
IdNotaCred=@Id_credito 
Go

----============== Nuevo Cambiar Nro de Doc en Credito
--Create Procedure Sp_Cambiar_NroDoc_Encredito (
--@Id_credito  char (6),
--@NroDocu char (11)
--)	
--As	
--update  Credito    set 
--Id_Doc= @NroDocu 
--where
--IdNotaCred =@Id_credito 
--Go



--=================CONSULTAS PARA EL EXPLORADOR DE CREDITOS ===========================

----select--mostrar notas de crdito
Create procedure  Sp_Ver_Todo_Credito
as
select * from V_Documento_Credito 
order by Fecha_Credito Asc
go

create procedure  Sp_Filtrar_creditos_xEstado
@Stado varchar (13)
as
select * from V_Documento_Credito 
Where
Estado_Cred=@Stado 
go

Create procedure  Sp_Filtrar_creditos_delMes
@xmes date
as
select * from V_Documento_Credito
Where
DATEPART(YEAR,Fecha_Credito)= DATEPART(YEAR,@Xmes) and
DATEPART(MONTH ,Fecha_Credito)= DATEPART(MONTH ,@Xmes)
go

create procedure  Sp_Filtrar_creditos_deldia
@xmes date
as
select * from V_Documento_Credito
Where
DATEPART(YEAR,Fecha_Credito)= DATEPART(YEAR,@Xmes) and
DATEPART(MONTH ,Fecha_Credito)= DATEPART(MONTH ,@Xmes) and
DATEPART(DAYOFYEAR ,Fecha_Credito)= DATEPART(DAYOFYEAR ,@Xmes)
go

----buscar creditos por nombre de cliente
create procedure Sp_Buscador_creditos
@nomcliente varchar (50)
as
select * from V_Documento_Credito 
Where 
	IdNotaCred =@nomcliente or 
	Id_Doc = @nomcliente or 
	Nom_Cliente   like + '%'+ @nomcliente  or Nom_Cliente  like + '%' + @nomcliente  + '%' or
	Nom_Cliente  like @nomcliente  + '%' 
		
Go

exec Sp_Buscador_creditos 'N01-0007015'
go

----cargamos el detalle de los creditos para la ventana buscar creditos
Alter Procedure Sp_Ver_Det_credito
@id_Cred char (11)
as
select * from Detalle_Credito 
Where
IdNotaCred =@id_Cred 
order by Saldo_Actual asc
Go

Create View V_CredityDetalle_documento
as
select 
c.IdNotaCred, c.Fecha_Credito , c.Nom_Cliente , c.Total_Cre , c.Saldo_Pdnte, c.Fecha_Vncimnto , c.Estado_Cred ,
d.id_Doc , d.Fecha_Emi ,d.ImporteDoc, d.Estado_Doc,
p.id_Ped, p.TotalGancia, p.TotalPed, p.Estado_Ped, 
k.Id_Cliente, k.Razon_Social_Nombres, k.Limit_Credit, k.DNI ,
s.A_cuenta, s.Saldo_Actual , s.Fecha_Pago , s.TipoPago , s.Nro_Opera_Coment 

from Credito c, Documento d, Pedido p , Cliente k , Detalle_Credito s
where
c.id_Doc=d.id_Doc and
d.id_Ped = p.Id_Ped and
p.Id_Cliente= k.Id_Cliente and
s.Id_DetCred = c.IdNotaCred 
go

--eliminar creditos erroneo

ALTER Procedure [dbo].[Sp_eliminar_Credito_Permanente]
@Idcredito char (11)
As	
Delete from Detalle_Credito 
where 
IdNotaCred=@Idcredito 
Delete from credito 
where IdNotaCred   =@Idcredito
