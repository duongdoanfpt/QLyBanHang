	create database QLyBanHang;

use QLyBanHang;

create table NHANVIEN
(
	Manv varchar(20) not null,
	ID int identity(1,1) not null,
	email nvarchar(50) not null,
	matKhau nvarchar(max) default '2331542419640203562132429613354120146463',
	tenNv nvarchar(50) not null,
	tinhTrang tinyint not null,
	vaiTro tinyint not null,
	diaChi nvarchar(50)
	primary key (MaNV)
)





create table HANGHOA
(
	maHang int identity(1,1) not null,
	MaNV varchar(20) not null,
	tenHang nvarchar(50) not null,
	hinhAnh nvarchar(400),
	ghiChu nvarchar(50),
	donGiaNhap float not null,
	donGiaBan float not null,
	soLuong int not null
	primary key (MaHang),
	Foreign key (MaNV) references NHANVIEN(MaNV)
);

create table KHACHHANG
(
	dienthoai varchar(15) not null,
	Manv varchar(20) not null,
	tenKhach nvarchar(50) not null,
	diaChi nvarchar(100) not null,
	phai nvarchar(5) not null,
	primary key(dienThoai),
	Foreign key (MaNV) references NHANVIEN(MaNV)
);


insert into KHACHHANG
(dienthoai,Manv,tenKhach,diaChi,phai) values ('0979510278','NV001',N'Đặng Thanh Duy',N'Quận 12','Nam');


insert into NhanVien
(MaNV,Email,TenNV,tinhTrang,vaiTro,DiaChi) values ('NV001','duongdoan@gmail.com',N'Duong Doan',1,1,N'Go Vap');

insert into NhanVien
(MaNV,Email,TenNV,tinhTrang,vaiTro,DiaChi) values ('NV002','duong@gmail.com',N'Duong Doan',1,0,N'Go Vap');


-- SP DangNhap
go
CREATE PROCEDURE [dbo].[DangNhap] @email varchar(50),@matKhau varchar(50)
AS
BEGIN
      declare @status int

if exists(select * from NhanVien where email=@email and matKhau=@matKhau)
       set @status=1
else
       set @status=0
select @status
END

--SP QuenMatKhau

go
CREATE PROCEDURE QuenMatKhau @email varchar(50)
AS
BEGIN
      declare @status int
if exists(select MaNv from NHANVIEN where email=@email )
       set @status=1
else
       set @status=0
select @status
END
go

--SP Tao MatKhau Moi
Create PROCEDURE TaoMatKhauMoi
@email nvarchar(50),
@matkhau nvarchar(max)
AS
BEGIN
UPDATE NHANVIEN SET matKhau = @matkhau
where email  =  @email
END
go


--SP LayVaiTroNhanVien
Create PROCEDURE [dbo].[LayVaiTroNV] @email varchar(50)
AS
BEGIN
      SELECT vaitro FROM NHANVIEN
	  where email = @email
END
go



--SP Change MK
CREATE procedure [dbo].[chgpwd]
(
@email Varchar(50),
@opwd nVarchar(max),
@npwd nVarchar(max)
)
AS
declare @op varchar(50)
select @op= matKhau from NHANVIEN where email=@email
if @op=@opwd
begin
update NHANVIEN set matKhau=@npwd where email=@email
return 1
end
else
return -1
go

-- SP GET ALL NHANVIEN
Create PROCEDURE [dbo].[DanhSachNV]
AS
BEGIN
      SELECT email, tenNv, diachi,vaitro, tinhtrang FROM NHANVIEN
END
GO

-- SP INSERT NV
CREATE PROCEDURE [dbo].[InsertDataIntoTblNhanVien]
@email nvarchar(50),
@tennv varchar(50),
@diachi nvarchar(100),
@vaiTro tinyint,
@tinhTrang tinyint
AS
BEGIN
DECLARE @Manv VARCHAR(20);
DECLARE @Id INT;

SELECT @Id = ISNULL(MAX(ID),0) + 1 FROM NHANVIEN
SELECT @Manv = 'NV' + RIGHT('0000' + CAST(@Id AS VARCHAR(4)), 4)
INSERT INTO NHANVIEN(Manv,email,tenNv, diaChi,vaiTro,tinhTrang) 
VALUES (@Manv, @email, @tennv, @diachi,@vaiTro,@tinhTrang) 
END
go

-- SP DELETE NV
CREATE PROCEDURE [dbo].[DeleteDataFromtblNhanVien]
@email varchar(50)
AS
BEGIN
DELETE FROM NHANVIEN
WHERE email = @email
END
go

--SP UPDATE NV
CREATE PROCEDURE [dbo].[UpdateDataIntoTblNhanVien]
@email nvarchar(50),
@tenNv nvarchar(50),
@diaChi nvarchar(50),
@vaiTro tinyint,
@tinhTrang tinyint
AS
BEGIN
UPDATE NHANVIEN SET TenNv=@tenNv, diaChi=@diaChi,vaiTro=@vaiTro, tinhTrang =@tinhTrang
where email  =  @email
END
go

--SP TKIEM NV
CREATE PROCEDURE [dbo].[SearchNhanVien]
@tenNv nvarchar(50)
AS
BEGIN
      SET NOCOUNT ON;
      SELECT email, tenNv, diachi,vaitro, tinhtrang 
      FROM NHANVIEN where tennv like '%' + @tenNv + '%'
END
go


--- PHAN KHACHHANG
-- SP GET KHACHHANG
GO
CREATE PROCEDURE [dbo].[DanhSachKhach]
AS
BEGIN
      SET NOCOUNT ON;
      SELECT *
      FROM KHACHHANG
END
go


-- Insert KhachHang
CREATE PROCEDURE [dbo].[InsertDataIntoTblKhach]
@dienThoai varchar(15),@tenKhach nvarchar(50),
@diaChi nvarchar(100),@phai nvarchar(5),@email varchar(50)
AS
BEGIN
DECLARE @Manv VARCHAR(20);
select @Manv = manv from NHANVIEN where email=@email
INSERT INTO KHACHHANG(DienThoai, TenKhach,DiaChi,phai,Manv) 
VALUES ( @dienThoai,@tenKhach,@diaChi,@phai,@Manv) 
END
go

-- Delete KhachHang
CREATE PROCEDURE [dbo].[DeleteDataFromtblKhach]
@dienthoai varchar(15)
AS
BEGIN
DELETE FROM KHACHHANG
WHERE DienThoai = @dienthoai
END
go

-- Update KhachHang
CREATE PROCEDURE [dbo].[UpdateDataIntoTblKhach]
@dienThoai varchar(15),
@tenKhach nvarchar(50),
@diaChi nvarchar(100),
@phai nvarchar(5)
AS
BEGIN
UPDATE KHACHHANG SET TenKhach=@tenKhach, DiaChi=@diaChi, phai=@phai
where dienThoai  =  @dienThoai
END
go

-- SP Search KhachHang
CREATE PROCEDURE [dbo].[SearchKhach]
@dienthoai varchar(15)
AS
BEGIN
      SET NOCOUNT ON;
      SELECT *
      FROM KHACHHANG where DienThoai like + '%' + @dienthoai + '%'
END
go


-- SP SanPham

--SP Get SP
CREATE PROCEDURE DanhSachHang
AS
BEGIN
      SET NOCOUNT ON;
      SELECT *
      FROM HANGHOA
END
go

--SP Insert SP
CREATE PROCEDURE [dbo].[InsertDataIntoTblHang]
@tenHang nvarchar(50),
@soLuong int,
@donGiaNhap float,
@donGiaBan float,
@hinhAnh nvarchar(400),
@ghiChu nvarchar(50),
@email varchar(50)
AS
BEGIN
DECLARE @Manv VARCHAR(20);
select @Manv = manv from NHANVIEN where email=@email
INSERT INTO HANGHOA(TenHang, SoLuong, DonGiaNhap, DonGiaBan,HinhAnh,GhiChu,Manv) 
VALUES ( @tenHang, @soLuong, @donGiaNhap,@donGiaBan,@hinhAnh,@ghiChu,@Manv) 
END
go

--SP Delete Hang
CREATE PROCEDURE DeleteDataFromtblHang
@maHang int
AS
BEGIN
DELETE FROM HANGHOA
WHERE MaHang = @maHang
END
go

--SP Update Hang
CREATE PROCEDURE [dbo].[UpdateDataIntoTblHang]
@maHang int,
@tenHang nvarchar(50),
@soLuong int,
@donGiaNhap float,
@donGiaBan float,
@hinhAnh nvarchar(400),
@ghiChu nvarchar(50)
AS
BEGIN
UPDATE HANGHOA SET TenHang=@tenHang, SoLuong=@soLuong,
DonGiaNhap=@donGiaNhap,DonGiaBan=@donGiaBan,HinhAnh=@hinhAnh,GhiChu=@ghiChu
where MaHang  =  @maHang
END
go

--SP Search Hang
CREATE PROCEDURE [dbo].[SearchHang]
@tenHang nvarchar(50)
AS
BEGIN
      SET NOCOUNT ON;
      SELECT TenHang,SoLuong,DonGiaNhap,DonGiaBan,HinhAnh,GhiChu
      FROM HANGHOA where TenHang like '%' + @tenHang + '%'
END
go


-- SP Thống Kê Tồn Kho
create procedure ThongKeTonKho
as
begin
	select TenHang ,SUM(SoLuong)
	from HANGHOA
	group by tenHang
end

-- SP Thống kê SP
go
CREATE PROCEDURE ThongKeSP
AS
BEGIN
	select HANGHOA.MaNV, tenNv, COUNT(maHang)
	from HANGHOA inner join NHANVIEN on HANGHOA.MaNV = NHANVIEN.Manv
	group by HANGHOA.MaNV, tenNv
end