Create database HoTenDB
Use HoTenDB
CREATE TABLE UserAccount(
ID int IDENTITY(1,1) primary key,
UserName  varchar(100) NOT NULL  ,
Password varchar(100) NOT NULL,
Status bit NOT NULL
)
CREATE TABLE LoaiSanPham(
ID int IDENTITY(1,1) primary key,
Name nvarchar(100) NOT NULL,
Description nvarchar(100) NULL,
)
CREATE TABLE SanPham(
ID varchar(50) primary key,
Name nvarchar(100) NOT NULL,
UnitCost money not null,
Quantity int not null,
Image  varchar(100)  NULL,
Description nvarchar(100)  NULL,
Status bit not NULL,
categoryID int  not null,
constraint fk_SanPham_LoaiSanPham foreign key (categoryID) references LoaiSanPham(ID)
)

INSERT INTO UserAccount(UserName,Password,Status)
VALUES  ('admin','827ccb0eea8a706c4c34a16891f84e7b','True'),
		('long','827ccb0eea8a706c4c34a16891f84e7b','True')
INSERT INTO SanPham(ID,Name,UnitCost,Quantity,Image,Description,Status,categoryID)
VALUES  ('Ma01',N'Jordan 1 - Ash pearl',704.000,15,'','','True',1),
 ('Ma02',N'Jordan 1 - Ash pearl',412.000,78,'','','True',3),
  ('Ma03',N'Jordan 1 - Ash pearl',322.000,2,'','','True',2),
   ('Ma04',N'Jordan 1 - Ash pearl',452.000,30,'','','True',3),
    ('Ma05',N'Jordan 1 - Ash pearl',842.000,45,'','','True',4),
	 ('Ma06',N'Jordan 1 - Ash pearl',624.000,24,'','','True',1)
		

INSERT INTO LoaiSanPham(Name,Description)
VALUES  (N'Nike',''),
		(N'ADIDAS',''),
		(N'CONVERSE',''),
		(N'BALENCIAGA',''),
		(N'MLB','')
