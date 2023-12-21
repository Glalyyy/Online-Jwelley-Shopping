Create database jewelly
use jewelly
--1--
Create table AdminLoginMst(
--tự thêm
Name_employee varchar(255),
Avatar varchar(255),
Path_avt varchar(255),
Birthday varchar(255),
Email varchar(255),
Phone varchar(255),
[Address] varchar(255),
--
userName varchar(250) primary key,
[Password] Varchar(50) not null
)
--2--
create table BrandMst(
Brand_ID nchar(10) primary key,
Brand_Type Varchar(50) not null
)
--3--
create table CatMst(
Cat_ID nchar(10) primary key,
Cat_Name Varchar(50) not null
)
--4--
create table CertifyMst(
Certify_ID nchar(10) primary key,
Certify_Type Varchar(50) not null
)
--5--
create table DimMst(
DimMst_ID int primary key IDENTITY,--tự thêm--
Dim_Crt Numeric(10,2) not null,
Dim_Pcs Numeric(10,2) not null,
Dim_Gm Numeric(10,2) Not Null,
Dim_Size Numeric(10,2) Not Null,
Dim_Rate Numeric(10,2) Not Null,
Dim_Amt Numeric(10,2) Not Null
)
--6--
create table DimQltyMst(
DimQlty_ID nchar(10) Primary Key,
DimQlty Varchar(50) Not Null
)
--7--
create table GoldKrtMst(
GoldType_ID nchar(10) Primary Key,
Gold_Crt Varchar(50) Not Null
)
--8--
create table ProdMst(
Prod_ID nchar(10) Primary Key,
Prod_Type Varchar(50) Not Null
)
--9--
create table StoneMst(
Stone_ID int Primary Key identity,--tự thêm--
Stone_Gm Numeric(10,2) Not Null,
Stone_Pcs Numeric(10,2) Not Null,
Stone_Crt Numeric(10,2) Not Null,
Stone_Rate Numeric(10,2) Not Null,
Stone_Amt Numeric(10,2) Not Null
)
--10--
create table StoneQltyMst(
StoneQlty_ID nchar(10) Primary Key,
StoneQlty Varchar(50) Not Null
)
--11--
create table UserRegMst(
userID nchar(10) Primary key,
userFname Text Not Null,
userLname Text Not Null,
address varchar(Max) Not Null,
city nvarchar(50) Not Null,
state nvarchar(50) Not Null,
mobNo Text Not Null,
emailID Text Not Null,
dob nvarchar(50) Not Null,
cdate nvarchar(50) Not Null,
password Varchar(50) Not Null,
photo varchar(255),
Path_photo varchar(255)
)
--12--
create table ItemMst(
Style_Code Varchar(50) Primary Key,
Pairs Numeric(3,0) Not Null,
Quantity Numeric(18,0) Not Null,
Prod_Quality Varchar(50) Not Null,
Gold_Wt Numeric(10,3) Not Null,
Stone_Wt Numeric(10,2) Not Null,
Net_Gold Numeric(10,3) Not Null,
Wstg_Per Numeric(10,3) Not Null,
Wstg Numeric(10,3) Not Null,
Tot_Gross_Wt Numeric(10,3) Not Null,
Gold_Rate Numeric(10,2) Not Null,
Gold_Amt Numeric(10,2) Not Null, 
Gold_Making Numeric(10,2) Not Null,
Stone_Making Numeric(10,2) Not Null,
Other_Making Numeric(10,2) Not Null,
Tot_Making Numeric(10,2) Not Null,
MRP Numeric(10,2) Not Null
)
--13--
create table DimQltySubMst(
DimSubType_ID nchar(10) Primary Key,
DimQlty Varchar(50) Not Null)
--14--
create table DimInfoMst(
DimID nchar(10) Primary Key,
DimType Varchar(50) Not Null,
DimSubType Varchar(50) Not Null,
DimCrt Varchar(50) Not Null,
DimPrice nchar(50) Not Null ,
DimImg Varchar(50) Not Null
)
--15--
create table Inquiry(
ID nchar(10) Primary Key,
Name Varchar(50) not null,
City Varchar(50) Not Null,
Contact Nchar(10) Not Null ,
EmailID Varchar(50) not Null,
Comment Varchar(MAX) Not Null,
Cdate Date Not Null
)
--16--
create table JewelTypeMst(
ID nchar(10) Primary Key ,
Jewellery_Type Varchar(50) Not Null
)
--17--
create table CartList(
ID nchar(10) Primary Key,
Product_Name Varchar(50) Not Null,
MRP Numeric(10,2) Not Null,
Email_ID varchar(255),
OrderDate varchar(255),
ShipName varchar(255),
ShipAddress varchar(255),
OrderCode varchar(255),
ShipCity varchar(255),
ShipCode varchar(255),
ShipCountry varchar(255)
)
--18--
create table Orderdetails(
Orderdetails_ID int Primary key identity,--tự thêm--
Quantity Int ,
UnitPrice money
)
--khóa ngoại--
alter table DimMst
add Style_Code Varchar(50),
DimQlty_ID nchar(10),
DimSubType_ID nchar(10),

CONSTRAINT fk_dim_id_item
FOREIGN KEY (Style_Code)
REFERENCES ItemMst(Style_Code),
CONSTRAINT fk_dim_id_dimqly
FOREIGN KEY (DimQlty_ID)
REFERENCES DimQltyMst(DimQlty_ID),
CONSTRAINT fk_dim_id_sub
FOREIGN KEY (DimSubType_ID)
REFERENCES DimQltySubMst(DimSubType_ID)

alter table StoneMst add
Style_Code Varchar(50),
StoneQlty_ID nchar(10),

CONSTRAINT fk_stone_id_item
FOREIGN KEY (Style_Code)
REFERENCES ItemMst(Style_Code),
CONSTRAINT fk_Stone_id_stoneqlty
FOREIGN KEY (StoneQlty_ID)
REFERENCES StoneQltyMst(StoneQlty_ID)

alter table ItemMst add
Brand_ID nchar(10),
Cat_ID nchar(10),
Certify_ID nchar(10),
Prod_ID nchar(10),
GoldType_ID nchar(10),
DimID nchar(10),
ID_jewelly nchar(10),--tự thêm--

CONSTRAINT fk_item_id_jwelly
FOREIGN KEY (ID_jewelly)
REFERENCES [dbo].[JewelTypeMst](ID),

CONSTRAINT fk_item_id_goldtype
FOREIGN KEY (GoldType_ID)
REFERENCES [dbo].[GoldKrtMst](GoldType_ID),

CONSTRAINT fk_item_id_brand
FOREIGN KEY (Brand_ID)
REFERENCES BrandMst(Brand_ID),

CONSTRAINT fk_item_id_cat
FOREIGN KEY (Cat_ID)
REFERENCES CatMst(Cat_ID),

CONSTRAINT fk_item_id_cer
FOREIGN KEY (Certify_ID)
REFERENCES CertifyMst(Certify_ID),

CONSTRAINT fk_item_id_prod
FOREIGN KEY (Prod_ID)
REFERENCES ProdMst(Prod_ID),

CONSTRAINT fk_item_id_diminfor
FOREIGN KEY (DimID)
REFERENCES DimInfoMst(DimID)

alter table CartList
add userName varchar(250),
userID nchar(10),

CONSTRAINT fk_crt_id_user
FOREIGN KEY (userID)
REFERENCES UserRegMst(userID),

CONSTRAINT fk_crt_id_ad
FOREIGN KEY (userName)
REFERENCES AdminLoginMst(userName)
alter table [dbo].[Orderdetails]
add ID nchar(10), [Style_Code] varchar(50),
CONSTRAINT fk_details_id_cart
FOREIGN KEY (ID)
REFERENCES [dbo].[CartList](ID),

CONSTRAINT fk_details_id_item
FOREIGN KEY ([Style_Code])
REFERENCES [dbo].[ItemMst]([Style_Code])
