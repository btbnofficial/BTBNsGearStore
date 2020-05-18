create database btbnGearsStore;
go
use btbnGearsStore;
go

create table Category
(
	ID int identity primary key,
	Name nvarchar(100),
	Image varchar(100)
)
go

create table Brand
(
	ID varchar(100) primary key, --Có thể ID này sẽ trùng tên brand kiểu như MSI các kiểu nhưng làm cả 2 cho vui =)))
	Name Nvarchar(100),
	Image varchar(100),
	info nvarchar(100) --cái này đưa đường link đến trang chủ của nhà sx hoặc có thể 
)
go

create table account
(
	ID varchar(100) primary key,
	password varchar(100) not null,
	Name nvarchar(100),
	Phone varchar(100),
	Type int, --admin/staff:1/0
	Salary float,
	dateJoined Date,
	Department nvarchar(100)
)
go

create table product
(
	Id int identity primary key,
	Name nvarchar(100),
	CategoryId int,
	BrandId varchar(100),
	Guarantee int,--thangs
	EntryPrice float,
	Price float,
	Image1 varchar(100),
	Image2 varchar(100),
	Image3 varchar(100),
	Image4 varchar(100),
	Detail nvarchar(1000),--thong so ky thuat
	Amount int,
	NoiDung ntext,
	foreign key (CategoryId) references dbo.Category(Id),
	foreign key (BrandId) references dbo.Brand(Id)
)
go

create table Customer
(
	Id int identity primary key,
	Name nvarchar(100),
	Email varchar(100),
	Phone varchar(100) not null,
	Address nvarchar(1000) not null,
	SocialNetwork varchar(100) -- đường link mạng xã hội
)
go

create table Bill
(
	Id int identity primary key,
	CustomerId int,
	DateOrdered Date,
	status int,--Đã nhận 1/ chưa nhận 0
	foreign key(CustomerId) references dbo.Customer(Id)
)
go

create table BillDetail
(
	Id int identity primary key,
	BillId int not null,
	ProductId int not null,
	count int not null default 0,
	foreign key(BillId) references dbo.Bill(Id),
	foreign key(ProductId) references dbo.Product(Id)
)
go

create table Post
(
	Id int identity primary key,
	DatePosted Date,
	Content ntext
)
go

insert into dbo.Category(Name,Image) values(N'Bàn Phím / Keyboard','keyboardicon.jpg');
insert into dbo.Category(Name,Image) values(N'Chuột / Mouse','ZOWIE-EC1-B-Mouse-for-e-Sports-01.jpg');
insert into dbo.Category(Name,Image) values(N'Màn hình / Monitor','23773_m__n_h__nh_benq_xl2411p_24___tn_fhd_144hz_3.jpg');
select * from Category;

insert into dbo.Brand(ID,Name,Image,info) values('BenQ',N'BenQ','Kv6wserx.png','https://www.benq.com/vi-vn/index.html');
insert into dbo.Brand(ID,Name,Image,info) values('Asus',N'Asus','60562_asus_512x512.png','https://www.asus.com/vn/');
insert into dbo.Brand(ID,Name,Image,info) values('Dareu',N'Dareu','dareulogo.png','https://vi-vn.facebook.com/DareUVietNam2018/');
select * from Brand;

insert into dbo.account(Id,password,name,Phone,Type,Salary,dateJoined,Department)
values ('btbncsgo','btbnisabeast',N'Đỗ Minh Tiến','0981134542',1,0,GETDATE(),N'Giám đốc');
insert into dbo.account(Id,password,name,Type,Salary,dateJoined,Department)
values ('staff1','staff1',N'Mai Đức Quang',0,5000000,GETDATE(),N'Nhân viên kĩ thuật');
select * from account;

insert into dbo.product
(	Name,
	CategoryId,
	BrandId,
	Guarantee,
	EntryPrice,
	Price,
	Image1,
	Image2,
	Image3,
	Image4,
	Detail,
	Amount)
values(N'Màn Hình BenQ Zowie XL2411P',3,'BenQ',36,5300000,5650000,'1b80e069bb3df19a63f8a97d74e536ac.jpg','23773_m__n_h__nh_benq_xl2411p_24___tn_fhd_144hz_3.jpg',
'71+iuN7lIyL._AC_SL1245_.jpg','back.jpg',N'Màn hình dành cho game FPS với các thông số: 24"/TN/FHD/350cd/m²/144Hz/1ms/DP+HDMI+DVI',5);
insert into dbo.product
(	Name,
	CategoryId,
	BrandId,
	Guarantee,
	EntryPrice,
	Price,
	Image1,
	Image2,
	Image3,
	Image4,
	Detail,
	Amount)
values(N'Bàn Phím Cơ Dareu Ek880 RGB',1,'DareU',24,570000,650000,'31873_BanphimcDareuDK880RGBUSB.jpg','20190911_94df4da01e7baadb66e4608308d7e094_1568184109.jpg',
'4a662748d2768235903ae0fe3f9704a8.jpg','unnamed.jpg',N'Bàn phím cơ chơi game với led RGB, D switch độc quyền và cảm giác gõ tốt nhất tầm giá',5);
select * from product;

insert into dbo.Customer(Name,	Email,	Phone,	Address,	SocialNetwork)
values
(
	N'Nguyễn Viết Nghĩa','nguyenvietnghia@gmail.com','123456789',N'Số 7 ngõ 27 đường Giáp Bát - Hà Nội', 'https://www.facebook.com/nghia.3.ngo?fref=hovercard&hc_location=chat'
)
insert into dbo.Customer(Name,	Email,	Phone,	Address,	SocialNetwork)
values
(
	N'Phạm Quang Hiếu','HieuPham@gmail.com','12345678910',N'Gần nhà ông Đông ở Bồng Lai - Đan Phượng', 'https://www.facebook.com/nhatki.03'
)
select * from Customer;

insert into dbo.Bill(CustomerId,	DateOrdered,	status) values(1,'02/20/2020',1);
insert into dbo.Bill(CustomerId,	DateOrdered,	status) values(2,'02/29/2020',0);
select * from Bill;

insert into dbo.BillDetail(BillId ,	ProductId,	count)values(2,1,4);
insert into dbo.BillDetail(BillId ,	ProductId,	count)values(3,2,1);
select * from BillDetail;

select * from btbnGearsStore;

create procedure usp_LayDanhSachBrand
as
begin
	select * from Brand;
end
go

execute usp_LayDanhSachBrand;

alter procedure usp_XoaBrand
(
	@Id varchar(100)
)
as
begin
	delete from Brand where brand.ID like @Id;
end
go

execute usp_XoaBrand 'Asus'

create procedure usp_ThemMoiBrand
(
	@ID varchar(100), --Có thể ID này sẽ trùng tên brand kiểu như MSI các kiểu nhưng làm cả 2 cho vui =)))
	@Name Nvarchar(100),
	@Image varchar(100),
	@info nvarchar(100) --cái này đưa đường link đến trang chủ của nhà sx hoặc có thể 
)
as
begin
	insert into dbo.Brand(ID,Name,Image,info) values(@Id,@Name,@Image,@info);
end
go

execute usp_ThemMoiBrand 'E-dra',N'E-dra','watermarked-bo-phim-chuot-khong-day-e-dra-ec888bk-3.jpg','https://www.facebook.com/EDRAVN/';
select * from Brand

create procedure usp_LayDanhSachCategory
as
begin
	select * from Category;
end
go

execute usp_LayDanhSachCategory

create procedure usp_ThemMoiCategory
(
	@Name nvarchar(100),
	@Image varchar(100)
)
as
begin
	insert into dbo.Category(Name,Image) values(@Name,@Image);
end
go

create procedure usp_XoaCategory
(
	@Id int
)
as
begin
	delete from Category where ID = @Id;
end
go

create procedure usp_LayDanhSachAccount
as
begin
	select * from account;
end
go

execute usp_LayDanhSachAccount;

alter procedure usp_XoaAccount
(
	@Id varchar(100)
)
as
begin
	delete from account where ID = @Id;
end
go

create procedure usp_ChiTietAccountTheoId
(@Id varchar(100))
as
begin
	select * from account where ID = @Id;
end
go

execute usp_ChiTietAccountTheoId 'btbncsgo'

alter procedure usp_ThemMoiAccount
(
	@ID varchar(100),
	@password varchar(100),
	@Name nvarchar(100),
	@Phone varchar(100),
	@Type int, --admin/staff:1/0
	@Salary float,
	@Department nvarchar(100)
)
as
begin
	insert into dbo.account(Id,password,name,Phone,Type,Salary,dateJoined,Department)
	values (@ID,@password,@Name,@Phone,@Type,@Salary,GETDATE(),@Department);
end
go

create procedure usp_SuaAccount
(
	@ID varchar(100),
	@password varchar(100),
	@Name nvarchar(100),
	@Phone varchar(100),
	@Type int, --admin/staff:1/0
	@Salary float,
	@Department nvarchar(100)
)
as
begin
	update dbo.account set password = @password, Name = @Name, Phone = @Phone, Type = @Type, Salary=@Salary, Department=@Department where Id = @ID;
end
go

alter procedure usp_LayDanhSachProduct
as
begin
	select * from product order by Id desc
end
go

execute usp_LayDanhSachProduct;

alter procedure usp_ThemMoiProduct
(
	@Name nvarchar(100),
	@CategoryId int,
	@BrandId varchar(100),
	@Guarantee int,--thangs
	@EntryPrice float,
	@Price float,
	@Image1 varchar(100),
	@Image2 varchar(100),
	@Image3 varchar(100),
	@Image4 varchar(100),
	@Detail nvarchar(1000),--thong so ky thuat
	@Amount int,
	@NoiDung ntext
)
as
begin
	insert into dbo.product
(	
	Name,CategoryId,BrandId,Guarantee,	EntryPrice,	Price,	Image1,	Image2,	Image3,	Image4,	Detail,	Amount, NoiDung
)
values
(
	@Name,@CategoryId,	@BrandId,@Guarantee,@EntryPrice,@Price,	@Image1,@Image2,@Image3,@Image4,@Detail,@Amount,@NoiDung
)
end
go

execute usp_ThemMoiProduct N'Bàn Phím Cơ E-Dra EK387 RGB',1,'E-dra',24,570000,650000,'31873_BanphimcDareuDK880RGBUSB.jpg','20190911_94df4da01e7baadb66e4608308d7e094_1568184109.jpg',
'4a662748d2768235903ae0fe3f9704a8.jpg','unnamed.jpg',N'Bàn phím cơ chơi game với led RGB, chất lượng tốt nhất tầm giá',10 , N''

select * from product;
select * from Brand;
select * from Category;





create procedure usp_ChiTietProductTheoId
(
@Id int
)
as
begin
	select * from product where Id = @Id
end
go

execute usp_ChiTietProductTheoId 3

alter procedure usp_SuaProduct
(
	@Id int,
	@Name nvarchar(100),
	@CategoryId int,
	@BrandId varchar(100),
	@Guarantee int,--thangs
	@EntryPrice float,
	@Price float,
	@Image1 varchar(100),
	@Image2 varchar(100),
	@Image3 varchar(100),
	@Image4 varchar(100),
	@Detail nvarchar(1000),--thong so ky thuat
	@Amount int,
	@NoiDung ntext
)
as
begin
	update dbo.product set Name=@Name, CategoryId = @CategoryId, BrandId = @BrandId, Guarantee = @Guarantee, EntryPrice = @EntryPrice, Price = @Price,
	Image1 = @Image1, Image2 = @Image2, Image3 = @Image3, Image4 = @Image4, Detail = @Detail, Amount = @Amount, NoiDung = @NoiDung
	where id=@Id
end
go

execute usp_SuaProduct 3, N'Bàn Phím Cơ E-Dra EK387 RGB',1,'E-dra',24,570000,650000,'31873_BanphimcDareuDK880RGBUSB.jpg','20190911_94df4da01e7baadb66e4608308d7e094_1568184109.jpg',
'4a662748d2768235903ae0fe3f9704a8.jpg','unnamed.jpg',N'Bàn phím cơ chơi game với led RGB 16,7 triệu màu, chất lượng tốt nhất tầm giá',10 , N''

create procedure usp_XoaProduct
(
@Id int
)
as
begin
	delete from product where id = @id;
end
go

execute usp_XoaProduct 3

Select product.* from product,Category 
where 1=1 
And(product.Name like N'Ban phim cơ' or product.Detail like N'') 
And (product.BrandId = 'E-Dra')
And(product.CategoryId = Category.ID)
and(Category.Name like N'Bàn Phím / Keyboard')
select * from category

Select * from product inner join Category on product.CategoryId = Category.ID where 1=1 
And (product.Name like N'%Bàn Phím%' or product.Detail like N'') 
And (product.BrandId like 'E-Dra')
and(Category.ID = N'Bàn Phím / Keyboard')


create procedure usp_LayDanhSachPost
as
begin
	select * from Post;
end
go

create procedure usp_ChiTietPostTheoId
(
	@Id int
)
as
begin
	select * from Post where Id = @Id;
end
go

create procedure usp_ThemMoiPost
(
	@Title nvarchar(200),
	@noiDung ntext
)
as
begin
	insert into dbo.Post(DatePosted,title,NoiDung)
	values(getDate(),@Title,@noiDung)
end
go

create procedure usp_SuaPost
(
	@Id int,@Title nvarchar(200), @NoiDung ntext
)
as
begin
	update dbo.Post set Title = @Title, DatePosted = GetDate() , NoiDung = @NoiDung where Id = @Id;
end
go

create procedure usp_XoaPost
(
	@Id int
)
as
begin
	delete from Post where Id = @Id;
end
go

select * from Post;

execute usp_ChiTietPostTheoId 2

select * from account;

alter procedure usp_dangNhap
(
	@Id varchar(100),
	@password varchar(100)
)
as
begin
	select * from account where Id = @Id and password = @password;
end
go

execute usp_dangNhap 'btbncsgo','btbnisabeast';