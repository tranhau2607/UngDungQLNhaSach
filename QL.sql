
create database QL_NHASACH
go
use QL_NHASACH


SET DATEFORMAT DMY;

--Tạo bảng TheLoai
create table TheLoai
(
	MaTL int IDENTITY(1,1),
	TenTL nvarchar(50),
	constraint PK_TheLoai primary key (MaTL)
)
--Tạo bảng TacGia
create table TacGia
(
	MaTG int IDENTITY(1,1),
	TenTG nvarchar(50),
	LienLac varchar(255),
	NamSinh INT,
	NamMat INT,
	constraint PK_TacGia primary key (MaTG)
)
--Tạo bảng NhaXuatBan
create table NhaXuatBan
(
	MaNXB int IDENTITY(1,1),
	TenNXB nvarchar(50),
	DiaChiNXB nvarchar(255),
	DienThoai int,
	Email NVARCHAR(50)
	constraint PK_NhaXuatBan primary key (MaNXB)
)

--Tạo bảng SACH
create table Sach
(
	MaSach int IDENTITY(1,1),
	TenSach nvarchar(50),
	GiaBan int,
	MaTL int,
	MaNXB int,
	MaTG int,
	SoLuongTon int,
	HinhAnh nvarchar(255),
	NgonNgu nvarchar(50),
	NamXuatBan datetime
	constraint PK_Sach primary key (MaSach)
)

--Tạo bảng PhieuNhap
create table PhieuNhap
(
	MaPN int IDENTITY(1,1),
	MaNCC int,
	TenDN char(20),
	NgayNhap Date,
	SoLuongNhap int,
	TongTien float,
	constraint PK_PhieuNhap primary key (MaPN),
)

--Tạo bảng nhà cung cấp
Create table NhaCC
(
	MaNCC int IDENTITY(1,1) primary key,
	TenNCC nvarchar(100)
)


--Tạo bảng HoaDon
create table HoaDon
(
	MaHD int IDENTITY(1,1),
	TenDN char(20),
	NgayBan Date,
	TongTien float
	constraint PK_HoaDon primary key (MaHD)
)

--Tạo bảng ChiTietPhieuNhap
create table ChiTietPhieuNhap
(
	MaPN int ,
	MaSach int,
	SoLuong int,
	GiaNhap Float,
	constraint PK_ChiTietPhieuNhap primary key (MaPN,MaSach)
)	

--Tạo bảng ChiTietHoaDon
create table ChiTietHoaDon
(
	MaHD int,
	MaSach int,
	SoLuongBan int,
	GiaBan Float,
	constraint PK_ChiTietHoaDon primary key (MaSach,MaHD)
)

create table TaiKhoan
(
	TenDN char(20) primary key,
	Passwords nvarchar(100),
	Passwords_MD5 nvarchar(100),
	Vaitro nvarchar (20)
)

--Tạo khóa ngoại cho bảng Sach
alter table Sach
add constraint FK_Sach_MaTL foreign key(MaTL) references TheLoai(MaTL)

alter table Sach
add constraint FK_Sach_MaTG foreign key(MaTG) references TacGia(MaTG)

alter table Sach
add constraint FK_Sach_MaNXB foreign key(MaNXB) references NhaXuatBan(MaNXB)

--Tạo khóa ngoại cho bảng ChiTietPhieuNhap
alter table ChiTietPhieuNhap
add constraint FK_ChiTietPhieuNhap_MaSach foreign key(MaSach) references Sach(MaSach)

alter table ChiTietPhieuNhap
add constraint FK_ChiTietPhieuNhap_PN foreign key(MaPN) references PhieuNhap(MaPN)



--Tạo khóa ngoại cho bảng ChiTietHoaDon
alter table ChiTietHoaDon
add constraint FK_ChiTietHoaDon_MaSach foreign key(MaSach) references Sach(MaSach)

alter table ChiTietHoaDon
add constraint FK_ChiTietHoaDon_HD foreign key(MaHD) references HoaDon(MaHD)


--Tạo khóa ngoại cho PhieuNhap
alter table PhieuNhap 
add constraint FK_PhieuNhap_TenDN foreign key (TenDN) references TaiKhoan(TenDN)

alter table PhieuNhap
add constraint Fk_PN_Mancc foreign key(MaNCC) references NhaCC(MaNCC)

--Tạo khóa ngoại cho Hóa đơn
alter table HoaDon 
add constraint FK_HoaDon_TenDN foreign key (TenDN) references TaiKhoan(TenDN)

--INSERT
INSERT INTO TheLoai (TenTL) VALUES	( N'Văn học');
INSERT INTO TheLoai (TenTL) VALUES	(N'Khoa học kỹ thuật');
INSERT INTO TheLoai (TenTL) VALUES	( N'Kinh tế - Xã hội');
INSERT INTO TheLoai (TenTL) VALUES	(N'Thiếu nhi');
INSERT INTO TheLoai (TenTL) VALUES	( N'Tiểu thuyết');
INSERT INTO TheLoai (TenTL) VALUES	(N'Truyện ngắn');
INSERT INTO TheLoai (TenTL) VALUES	( N'Thơ ca');
INSERT INTO TheLoai (TenTL) VALUES	( N'Kịch');
INSERT INTO TheLoai (TenTL) VALUES	(N'Tình Cảm');
go

INSERT INTO TacGia (TenTG, LienLac, NamSinh, NamMat) VALUES ( N'Nguyễn Trãi', 'nguyentrai@gmail.com', 1380, 1442);
INSERT INTO TacGia (TenTG, LienLac, NamSinh, NamMat) VALUES( N'Hồ Xuân Hương', 'hoxuanhuong@yahoo.com', 1772, 1822);
INSERT INTO TacGia (TenTG, LienLac, NamSinh, NamMat) VALUES( N'Nam Cao', 'namcao@vnedu.vn', 1915, 1951);
INSERT INTO TacGia (TenTG, LienLac, NamSinh, NamMat) VALUES( N'Kim Lân', 'kimlan@gmail.com', 1910, 2007);
INSERT INTO TacGia (TenTG, LienLac, NamSinh, NamMat) VALUES( N'Nguyễn Du', 'd@gmail.com', 1910, 2007);
go
INSERT INTO TacGia (TenTG, LienLac, NamSinh, NamMat) VALUES ( N'Trịnh Xuân Thuận', 'txt@gmail.com', 1380, 1442);
INSERT INTO TacGia (TenTG, LienLac, NamSinh, NamMat) VALUES( N'Nguyên Phong', 'np@yahoo.com', 1772, 1822);
INSERT INTO TacGia (TenTG, LienLac, NamSinh, NamMat) VALUES( N'Ngọc Bích', 'nb@vnedu.vn', 1915, 1951);
INSERT INTO TacGia (TenTG, LienLac, NamSinh, NamMat) VALUES( N'Nhân Văn', 'nv@gmail.com', 1910, 2007);
INSERT INTO TacGia (TenTG, LienLac, NamSinh, NamMat) VALUES( N'Minh Đức', 'md@gmail.com', 1910, 2007);


INSERT INTO NhaXuatBan ( TenNXB, DiaChiNXB, DienThoai, Email)VALUES( N'Nhà xuất bản Giáo dục Việt Nam', N'Số 49, phố Trần Hưng Đạo, Hoàn Kiếm, Hà Nội', '19001080', 'nxbgiaoduc@vnedu.vn');
INSERT INTO NhaXuatBan ( TenNXB, DiaChiNXB, DienThoai, Email)VALUES( N'Nhà xuất bản Kim Đồng', N'Số 97, phố Nguyễn Thượng Hiền, Hai Bà Trưng, Hà Nội', '19006216', 'nxbkidong@gmail.com');
INSERT INTO NhaXuatBan ( TenNXB, DiaChiNXB, DienThoai, Email)VALUES( N'Nhà xuất bản Trẻ', N'Số 656, đường Cách Mạng Tháng Tám, quận 10, Thành phố Hồ Chí Minh', '1900558888', 'nxbtre@nxbtre.com.vn');
go
INSERT INTO NhaXuatBan ( TenNXB, DiaChiNXB, DienThoai, Email)VALUES( N'NXB Tổng hợp TP.HCM', N'Tp.HCM', '0903118878', 'nxbgiaoduc@vnedu.vn');
INSERT INTO NhaXuatBan ( TenNXB, DiaChiNXB, DienThoai, Email)VALUES( N'NXB Thống kê', N'Biên Hòa-Đồng Nai', '1900151112', 'nxbkidong@gmail.com');
INSERT INTO NhaXuatBan ( TenNXB, DiaChiNXB, DienThoai, Email)VALUES( N'Thanh Niên', N'Tp.HCM', '0903118811', 'nxbtre@nxbtre.com.vn');
INSERT INTO NhaXuatBan ( TenNXB, DiaChiNXB, DienThoai, Email)VALUES( N'Đại học quốc gia', N'Số 49, phố Trần Hưng Đạo, Hoàn Kiếm, Hà Nội', '0908419981', 'nxbgiaoduc@vnedu.vn');
INSERT INTO NhaXuatBan ( TenNXB, DiaChiNXB, DienThoai, Email)VALUES( N'Văn hóa nghệ thuật', N'Số 97, phố Nguyễn Thượng Hiền, Hai Bà Trưng, Hà Nội', '0903118833', 'nxbkidong@gmail.com');
INSERT INTO NhaXuatBan ( TenNXB, DiaChiNXB, DienThoai, Email)VALUES( N'NXB Tài Chính', N'Huế', '0903118833', 'nxbtre@nxbtre.com.vn');
go

INSERT INTO TaiKhoan(TenDN, Passwords, Passwords_MD5,Vaitro)VALUES('khanhnam', '123456', 'e10adc3949ba59abbe56e057f20f883e ','User');
INSERT INTO TaiKhoan(TenDN, Passwords, Passwords_MD5,Vaitro)VALUES('tranhau', '654321', 'c33367701511b4f6020ec61ded352059 ','Admin');
INSERT INTO TaiKhoan(TenDN, Passwords, Passwords_MD5,Vaitro)VALUES( 'tandat', '123654', '733d7be2196ff70efaf6913fc8bdcabf ','User');
INSERT INTO TaiKhoan(TenDN, Passwords,Vaitro)VALUES( 'hunganh', '123654','User');

go

INSERT INTO Sach (TenSach, GiaBan,MaTL, MaNXB, MaTG, SoLuongTon, HinhAnh, NgonNgu, NamXuatBan)VALUES( N'Truyện Kiều',20000, 1, 1, 1, 1000, '000055.jpg', N'Tiếng Việt', '2023-11-01');
INSERT INTO Sach (TenSach, GiaBan, MaTL, MaNXB, MaTG, SoLuongTon, HinhAnh, NgonNgu, NamXuatBan)VALUES( N'Vàng lửa',20000, 2, 2, 2, 500, '000056.jpg', N'Tiếng Việt', '2023-11-01');
INSERT INTO Sach (TenSach, GiaBan,MaTL, MaNXB, MaTG, SoLuongTon, HinhAnh, NgonNgu, NamXuatBan)VALUES( N'Đời thừa',20000, 1, 3, 3, 300, '000057.jpg', N'Tiếng Việt', '2023-11-01');
INSERT INTO Sach ( TenSach, GiaBan,MaTL, MaNXB, MaTG, SoLuongTon, HinhAnh, NgonNgu, NamXuatBan)VALUES( N'Làng',20000, 1, 1, 4, 200, '000058.jpg', N'Tiếng Việt', '2023-11-01');
go
INSERT INTO Sach (TenSach, GiaBan,MaTL, MaNXB, MaTG, SoLuongTon, HinhAnh, NgonNgu, NamXuatBan)VALUES( N'Cuộc Đời Là Vô Thường',43000, 5, 1, 1, 50, '000064.jpg', N'Tiếng Việt', '2023-11-01');
INSERT INTO Sach (TenSach, GiaBan, MaTL, MaNXB, MaTG, SoLuongTon, HinhAnh, NgonNgu, NamXuatBan)VALUES( N'Tình Yêu Phổ Quát',43000, 6, 2, 9, 500, '000062.jpg', N'Tiếng Việt', '2023-11-01');
INSERT INTO Sach (TenSach, GiaBan,MaTL, MaNXB, MaTG, SoLuongTon, HinhAnh, NgonNgu, NamXuatBan)VALUES( N'Nghệ Thuật Sống An Lạc ',20000, 3, 2, 3, 300, '000011.jpg', N'Tiếng Việt', '2023-11-01');
INSERT INTO Sach ( TenSach, GiaBan,MaTL, MaNXB, MaTG, SoLuongTon, HinhAnh, NgonNgu, NamXuatBan)VALUES( N'Ngọc Sáng Trong Hoa Sen',30000, 9, 7, 4, 200, '000013.jpg', N'Tiếng Việt', '2023-11-01');
INSERT INTO Sach (TenSach, GiaBan,MaTL, MaNXB, MaTG, SoLuongTon, HinhAnh, NgonNgu, NamXuatBan)VALUES( N'Hành Trình Về Phương Đông',30000, 7, 5, 5, 1000, '000014.jpg', N'Tiếng Việt', '2023-11-01');
INSERT INTO Sach (TenSach, GiaBan, MaTL, MaNXB, MaTG, SoLuongTon, HinhAnh, NgonNgu, NamXuatBan)VALUES( N'Đơn Giản Và Thuần Khiết',30000, 2, 2, 6, 500, '000016.jpg', N'Tiếng Việt', '2023-11-01');
INSERT INTO Sach (TenSach, GiaBan,MaTL, MaNXB, MaTG, SoLuongTon, HinhAnh, NgonNgu, NamXuatBan)VALUES( N'Nàng Lọ Lem Và Đàn Chuột Mất Tích',30000, 2, 3, 7, 300, '000026.jpg', N'Tiếng Việt', '2023-11-01');
INSERT INTO Sach ( TenSach, GiaBan,MaTL, MaNXB, MaTG, SoLuongTon, HinhAnh, NgonNgu, NamXuatBan)VALUES( N'Công Chúa Aurora Và Chú Rồng Nhỏ',30000, 2, 1, 8, 200, '000027.jpg', N'Tiếng Việt', '2023-11-01');
INSERT INTO Sach (TenSach, GiaBan,MaTL, MaNXB, MaTG, SoLuongTon, HinhAnh, NgonNgu, NamXuatBan)VALUES( N'Truyện Kiều',32000, 1, 9, 9, 1000, '000055.jpg', N'Tiếng Việt', '2023-11-01');
INSERT INTO Sach (TenSach, GiaBan, MaTL, MaNXB, MaTG, SoLuongTon, HinhAnh, NgonNgu, NamXuatBan)VALUES( N'Hành Trình Tâm Linh Siêu Việt',32000, 3, 8, 10, 500, '000046.jpg', N'Tiếng Việt', '2023-11-01');
INSERT INTO Sach (TenSach, GiaBan,MaTL, MaNXB, MaTG, SoLuongTon, HinhAnh, NgonNgu, NamXuatBan)VALUES( N'Tỉnh Thức',32000, 1, 7, 1, 300, '000048.jpg', N'Tiếng Việt', '2023-11-01');
INSERT INTO Sach ( TenSach, GiaBan,MaTL, MaNXB, MaTG, SoLuongTon, HinhAnh, NgonNgu, NamXuatBan)VALUES( N'Đạo Kỷ Nguyên Mới',32000, 5, 6, 2, 200, '000050.jpg', N'Tiếng Việt', '2023-11-01');
INSERT INTO Sach (TenSach, GiaBan,MaTL, MaNXB, MaTG, SoLuongTon, HinhAnh, NgonNgu, NamXuatBan)VALUES( N'Nghệ Thuật Thiền Định',43000, 1, 5, 3, 1000, '000057.jpg', N'Tiếng Việt', '2023-11-01');
INSERT INTO Sach (TenSach, GiaBan, MaTL, MaNXB, MaTG, SoLuongTon, HinhAnh, NgonNgu, NamXuatBan)VALUES( N'Bàn Về Hạnh Phúc',43000, 2, 8, 4, 500, '000058.jpg', N'Tiếng Việt', '2023-11-01');
INSERT INTO Sach (TenSach, GiaBan,MaTL, MaNXB, MaTG, SoLuongTon, HinhAnh, NgonNgu, NamXuatBan)VALUES( N'Lượng tử hoa và sen',43000, 8, 3, 5, 300, '000059.jpg', N'Tiếng Việt', '2023-11-01');
INSERT INTO Sach ( TenSach, GiaBan,MaTL, MaNXB, MaTG, SoLuongTon, HinhAnh, NgonNgu, NamXuatBan)VALUES( N'Tình Yêu Phổ Quát',43000, 9, 2, 6, 200, '000064.jpg', N'Tiếng Việt', '2023-11-01');
go

insert into NhaCC(TenNCC) values(N'Nhà sách Fahasa');
insert into NhaCC(TenNCC) values(N'Nhà sách Nguyễn Văn Cừ');
insert into NhaCC(TenNCC) values(N'Nhà sách Minh Khai');
insert into NhaCC(TenNCC) values(N'Nhà sách Phương Nam');
insert into NhaCC(TenNCC) values(N'Nhà sách Tiki');
insert into NhaCC(TenNCC) values(N'Nhà sách Dân Trí');
insert into NhaCC(TenNCC) values(N'Nhà sách Đại Học Quốc Gia');
insert into NhaCC(TenNCC) values(N'Nhà sách Quảng Trị');
go


INSERT INTO PhieuNhap (NgayNhap,TenDN, MaNCC) VALUES	('2023-11-01','tandat',1);
INSERT INTO PhieuNhap (NgayNhap,TenDN, MaNCC) VALUES	('2023-11-01','tandat',2);
INSERT INTO PhieuNhap (NgayNhap,TenDN, MaNCC) VALUES	('2023-11-01','tandat',1);
INSERT INTO PhieuNhap (NgayNhap,TenDN, MaNCC) VALUES	('2023-11-01','tandat',2);
INSERT INTO PhieuNhap (NgayNhap,TenDN, MaNCC) VALUES	('2023-11-01','tandat',1);
go


INSERT INTO ChiTietPhieuNhap (MaPN, MaSach, SoLuong, GiaNhap) VALUES	(1, 4, 1000, 25000);
INSERT INTO ChiTietPhieuNhap (MaPN, MaSach, SoLuong, GiaNhap) VALUES	(1, 2, 1000, 25000);
INSERT INTO ChiTietPhieuNhap (MaPN, MaSach, SoLuong, GiaNhap) VALUES	(1, 3, 1000, 25000);
INSERT INTO ChiTietPhieuNhap (MaPN, MaSach, SoLuong, GiaNhap) VALUES	(3, 3, 1000, 25000);
INSERT INTO ChiTietPhieuNhap (MaPN, MaSach, SoLuong, GiaNhap) VALUES	(4, 2, 1000, 25000);
INSERT INTO ChiTietPhieuNhap (MaPN, MaSach, SoLuong, GiaNhap) VALUES	(5, 2, 1000, 25000);
go

INSERT INTO HoaDon (NgayBan, TongTien,TenDN)VALUES ('2023-11-05', null,'tandat');
INSERT INTO HoaDon (NgayBan, TongTien,TenDN)VALUES ('2023-11-06', null,'tandat');
INSERT INTO HoaDon (NgayBan, TongTien,TenDN)VALUES ('2023-11-07', null,'tandat');
INSERT INTO HoaDon (NgayBan, TongTien,TenDN)VALUES ('2023-11-08', null,'tandat');
go

INSERT INTO ChiTietHoaDon (MaHD, MaSach, SoLuongBan, GiaBan)VALUES	(1, 3, 4, 30000);
INSERT INTO ChiTietHoaDon (MaHD, MaSach, SoLuongBan, GiaBan)VALUES	(1, 2, 2, 40000);
INSERT INTO ChiTietHoaDon (MaHD, MaSach, SoLuongBan, GiaBan)VALUES	(2, 4, 2, 50000);
INSERT INTO ChiTietHoaDon (MaHD, MaSach, SoLuongBan, GiaBan)VALUES	(3,3, 1, 70000);
INSERT INTO ChiTietHoaDon (MaHD, MaSach, SoLuongBan, GiaBan)VALUES	(6,3, 1, 70000);
INSERT INTO ChiTietHoaDon (MaHD, MaSach, SoLuongBan, GiaBan) VALUES(6,2, 3, 20000);

-------------------
--Năm Sinh Tác giả nhỏ hơn năm hiện tại
alter table TacGia
add constraint CHK_NS check (NamSinh <year(getdate()))
--Năm mất Tác giả nhỏ hơn năm hiện tại
alter table TacGia
add constraint CHK_NM check (NamMat <= year(getdate()))

alter table TacGia
add constraint CHK_LC check (LienLac LIKE '%@%.%')


------------------SACH--------------------------
alter table Sach
add constraint CHK_SLT check (SoLuongTon>0)

alter table Sach
add constraint CHK_NXB check (NamXuatBan <= getdate())

---------------------------------------------
--Ràng buộc Giá nhập>0
alter table ChiTietPhieuNhap
add constraint CHK_GiaNhap check (GiaNhap>0)

--Ràng buộc Giá bán>0
alter table ChiTietHoaDon
add constraint CHK_GiaBan check (GiaBan>0) 

alter table ChiTietHoaDon
add constraint CHK_SLB check (SoLuongBan >0)
--Ràng buộc Số lượng nhập>0
alter table ChiTietPhieuNhap
add constraint CHK_SoLuongNhap check (SoLuong>0)



------Cập nhật số lượng-------
CREATE PROC CAPNHATSLNhap
AS
	UPDATE PhieuNhap
	SET SoLuongNhap =(SELECT sum(SoLuong) 
						FROM ChiTietPhieuNhap 
						WHERE PhieuNhap.MaPN=ChiTietPhieuNhap.MaPN )

EXEC CAPNHATSLNhap
SELECT * FROM PhieuNhap
---------Cập nhật tổng tiền-------
CREATE PROC CAPNHATTongTien
AS
	UPDATE HoaDon
	SET TongTien =(SELECT SUM(GiaBan * SoLuongBan)
						FROM ChiTietHoaDon 
						WHERE HoaDon.MaHD=ChiTietHoaDon.MaHD)

EXEC CAPNHATTongTien
SELECT * FROM HoaDon
SELECT * FROM ChiTietHoaDon
SELECT * FROM PhieuNhap
-------Tính Tổng tiền----------
CREATE FUNCTION TinhTongTien(@MaHD int)
RETURNS float
AS
BEGIN
  DECLARE @TongTien float

  SELECT @TongTien = SUM(GiaBan * SoLuongBan)
  FROM ChiTietHoaDon
  WHERE MaHD = @MaHD

  RETURN @TongTien
END

SELECT dbo.TinhTongTien (1)

select *from HoaDon
select *from ChiTietHoaDon

select *from PhieuNhap
select *from ChiTietPhieuNhap

update HoaDon
set TongTien= (select sum(SoLuongBan*GiaBan)) from ChiTietHoaDon where ChiTietHoaDon.MaHD=HoaDon.MaHD

UPDATE PhieuNhap
	SET TongTien =(SELECT sum(SoLuong*GiaNhap) 
						FROM ChiTietPhieuNhap 
						WHERE PhieuNhap.MaPN=ChiTietPhieuNhap.MaPN )