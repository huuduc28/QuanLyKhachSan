CREATE DATABASE HotelOnline
Go
Use HotelOnline

	CREATE TABLE Menu(
		id int IDENTITY(1,1),
		name nvarchar(50),
		link nvarchar(max),
		meta nvarchar(50),
		hide bit,
		[order] int,
		datebegin smalldatetime
		primary key (id)
	)
	CREATE TABLE footer(
		id int IDENTITY(1,1),
		name nvarchar(50),
		address nvarchar(100),
		email nvarchar(50),
		phone nvarchar(10),
		introduce nvarchar(max),
		link nvarchar(max),
		meta nvarchar(50),
		hide bit,
		[order] int,
		datebegin smalldatetime
		primary key (id)
	)
	CREATE TABLE Banner(
		id int IDENTITY(1,1),
		name nvarchar(50),
		title nvarchar(max),
		img1 nvarchar(max),
		img2 nvarchar(max),
		img3 nvarchar(max),
		link nvarchar(max),
		meta nvarchar(50),
		hide bit,
		[order] int,
		datebegin smalldatetime
		primary key (id)
	)
	CREATE TABLE About(
	id int IDENTITY(1,1),
	name nvarchar(50),
	content nvarchar(max),
	link nvarchar(max),
	meta nvarchar(50),
	hide bit,
	[order] int,
	datebegin smalldatetime
	primary key (id)
)
		CREATE TABLE  Caterogy(
		id int IDENTITY(1,1),
		name nvarchar(50),
		link nvarchar(max),
		meta nvarchar(50),
		hide bit,
		[order] int,
		datebegin smalldatetime
		primary key (id)
	)

CREATE TABLE Room(
		id int IDENTITY(1,1),
		name nvarchar(50),
		price int,
		img nvarchar(50),
		content nvarchar(max),
		link nvarchar(max),
		meta nvarchar(50),
		hide bit,
		[order] int,
		datebegin smalldatetime,
		idcategory int FOREIGN KEY (idcategory)REFERENCES Caterogy (id)
		primary key (id)
	)
	
	CREATE TABLE Reviews(
		id int IDENTITY(1,1),
		name nvarchar(50),
		email nvarchar(max),
		profession nvarchar(100),
		reviews nvarchar(max),
		link nvarchar(max),
		meta nvarchar(50),
		hide bit,
		[order] int,
		datebegin smalldatetime
		primary key (id)
	)

	CREATE TABLE News(
		id int IDENTITY(1,1) ,
		name nvarchar(50),
		img nvarchar(50),
		description nvarchar(max),
		detail ntext,
		link nvarchar(max),
		meta nvarchar(50),
		hide bit,
		[order] int,
		datebegin smalldatetime
		primary key (id)
	)

		CREATE TABLE Booking(
		id int IDENTITY(1,1),
		nameRoom nvarchar(50),
		idRoom int FOREIGN KEY (idRoom) REFERENCES Room(id),
		namecustomer nvarchar(50),
		phone nvarchar(10),
		email nvarchar(max),
		customerID  nvarchar(12),
		checkin smalldatetime,
		checkout smalldatetime,
		message nvarchar(50),
		price int,
		link nvarchar(max),
		meta nvarchar(50),
		hide bit,
		[order] int,
		datebegin smalldatetime
		primary key (id)
	)


insert into Banner values(N'Banner',N'Discover A Brand Luxurious Hotel','carousel-1.jpg','carousel-2.jpg','carousel-1.jpg','','','true', 1,'')
insert into footer values(N'??c Hotelier',N'Nguy?n H?u Th?',N'52000645@student.tdtu.edu.vn','0379999999','Download Hotelier – Premium Version, build a professional website for your hotel business and grab the attention of new visitors upon your site’s launch.','','','true', 1,'')

insert into Menu values(N'Trang ch?','','/Default/Index','true', 1,'')
insert into Menu values(N'D?ch v?','','/Sevice/Index','true', 2,'')
insert into Menu values(N'??t phòng','','/Booking/Index','true',3,'')
insert into Menu values(N'Liên h?','','/Contact/Index','true',4,'')
insert into Menu values(N'Phòng ?ã ??t','','/Booking/Find','true',5,'')

insert into Caterogy values(N'Phòng th??ng','','phong-thuong','true', 1,'')
insert into Caterogy values(N'Phòng cao c?p','','phong-cao-cap','true', 1,'')
insert into Caterogy values(N'Phòng sang tr?ng','','phong-sang-trong','true', 1,'')


insert into About values(N'Welcome to ??c Hotell',N'Là m?t khách s?n ??y ?? d?ch v?, chúng tôi cung c?p nhà hàng trong khuôn viên, không gian t? ch?c h?i ngh? và h?i ngh?, bãi bi?n riêng và h? b?i ngoài tr?i… Chúng tôi chú ý ??n t?ng chi ti?t ?? k? ngh? c?a b?n tho?i mái nh?t có th? v?i nhi?u ti?n nghi và phong cách','','','true',1,'')

insert into Room values(N'Phòng th??ng',300000,N'room-1.jpg',N'Erat ipsum justo amet duo et elitr dolor est duo duo eos lorem sed diam stet diam sed stet lorem','','phong-thuong','true', 1 ,GETDAte(),1)
insert into Room values(N'Phòng cao c?p',500000,N'room-2.jpg',
N'Erat ipsum justo amet duo et elitr dolor, est duo duo eos lorem sed diam stet diam sed stet lorem.','','phong-cao-cap','true',1,'',2)
insert into Room values(N'Phòng Sang tr?ng',1000000,N'room-3.jpg',
N'Erat ipsum justo amet duo et elitr dolor, est duo duo eos lorem sed diam stet diam sed stet lorem.','','phong-sang-trong','true',1,'',3)
insert into Room values(N'Phòng th??ng',300000,N'room-1.jpg',N'Erat ipsum justo amet duo et elitr dolor est duo duo eos lorem sed diam stet diam sed stet lorem','','phong-thuong','true', 1 ,'',1)
insert into Room values(N'Phòng cao c?p',500000,N'room-2.jpg',
N'Erat ipsum justo amet duo et elitr dolor, est duo duo eos lorem sed diam stet diam sed stet lorem.','','phong-cao-cap','true',1,'',2)
insert into Room values(N'Phòng Sang tr?ng',1000000,N'room-3.jpg',
N'Erat ipsum justo amet duo et elitr dolor, est duo duo eos lorem sed diam stet diam sed stet lorem.','','phong-sang-trong','true',1,'',3)
insert into Room values(N'Phòng Sang tr?ng',1000000,N'room-3.jpg',
N'Erat ipsum justo amet duo et elitr dolor, est duo duo eos lorem sed diam stet diam sed stet lorem.','','phong-sang-trong','true',1,'',3)
insert into Room values(N'Phòng cao c?p',500000,N'room-2.jpg',
N'Erat ipsum justo amet duo et elitr dolor, est duo duo eos lorem sed diam stet diam sed stet lorem.','','phong-cao-cap','true',1,'',2)
insert into Room values(N'Phòng th??ng',300000,N'room-1.jpg',N'Erat ipsum justo amet duo et elitr dolor est duo duo eos lorem sed diam stet diam sed stet lorem','','phong-thuong','true', 1 ,'',1)

insert into Reviews values(N'Nguy?n H?u ??c','duc@gmail.com',N'Sinh viên',N'Là m?t khách s?n ??y ?? d?ch v?, chúng tôi cung c?p nhà hàng trong khuôn viên, không gian t? ch?c h?i ngh? và h?i ngh?, bãi bi?n riêng và h? b?i ngoài tr?i… Chúng tôi chú ý ??n t?ng chi ti?t ?? k? ngh? c?a b?n tho?i mái nh?t có th? v?i nhi?u ti?n nghi và phong cách','','','true',1,'')
insert into Reviews values(N'Nguy?n H?u ??c','duc@gmail.com',N'K? s?',N'Là m?t khách s?n ??y ?? d?ch v?, chúng tôi cung c?p nhà hàng trong khuôn viên, không gian t? ch?c h?i ngh? và h?i ngh?, bãi bi?n riêng và h? b?i ngoài tr?i… Chúng tôi chú ý ??n t?ng chi ti?t ?? k? ngh? c?a b?n tho?i mái nh?t có th? v?i nhi?u ti?n nghi và phong cách','','','true',1,'')
insert into Reviews values(N'Nguy?n H?u ??c','duc@gmail.com',N'Giám ??c',N'Là m?t khách s?n ??y ?? d?ch v?, chúng tôi cung c?p nhà hàng trong khuôn viên, không gian t? ch?c h?i ngh? và h?i ngh?, bãi bi?n riêng và h? b?i ngoài tr?i… Chúng tôi chú ý ??n t?ng chi ti?t ?? k? ngh? c?a b?n tho?i mái nh?t có th? v?i nhi?u ti?n nghi và phong cách','','','true',1,'')
insert into Reviews values(N'Nguy?n H?u ??c','duc@gmail.com',N'Ch? t?ch',N'Là m?t khách s?n ??y ?? d?ch v?, chúng tôi cung c?p nhà hàng trong khuôn viên, không gian t? ch?c h?i ngh? và h?i ngh?, bãi bi?n riêng và h? b?i ngoài tr?i… Chúng tôi chú ý ??n t?ng chi ti?t ?? k? ngh? c?a b?n tho?i mái nh?t có th? v?i nhi?u ti?n nghi và phong cách','','','true',1,'')
insert into Reviews values(N'Nguy?n H?u ??c','duc@gmail.com',N'Streamer',N'Là m?t khách s?n ??y ?? d?ch v?, chúng tôi cung c?p nhà hàng trong khuôn viên, không gian t? ch?c h?i ngh? và h?i ngh?, bãi bi?n riêng và h? b?i ngoài tr?i… Chúng tôi chú ý ??n t?ng chi ti?t ?? k? ngh? c?a b?n tho?i mái nh?t có th? v?i nhi?u ti?n nghi và phong cách','','','true',1,'')
insert into Reviews values(N'Nguy?n H?u ??c','duc@gmail.com',N'Reviewer',N'Là m?t khách s?n ??y ?? d?ch v?, chúng tôi cung c?p nhà hàng trong khuôn viên, không gian t? ch?c h?i ngh? và h?i ngh?, bãi bi?n riêng và h? b?i ngoài tr?i… Chúng tôi chú ý ??n t?ng chi ti?t ?? k? ngh? c?a b?n tho?i mái nh?t có th? v?i nhi?u ti?n nghi và phong cách','','','true',1,'')


insert into News values(N'Tin Hôm nay',N'room-1.jpg',
N'Erat ipsum justo amet duo et elitr dolor est duo duo eos lorem sed diam stet diam sed stet lorem',N'Erat ipsum justo amet duo et elitr dolor est duo duo eos lorem sed diam stet diam sed stet lorem'
,'','tinhomnay','true', 1 ,GETDATE())
insert into News values(N'Tin Ngày Mai',N'room-2.jpg',
N'Erat ipsum justo amet duo et elitr dolor est duo duo eos lorem sed diam stet diam sed stet lorem',N'Erat ipsum justo amet duo et elitr dolor est duo duo eos lorem sed diam stet diam sed stet lorem'
,'','tinhomnay','true', 1 ,GETDATE())
insert into News values(N'Tin Hôm Qua',N'room-3.jpg',
N'Erat ipsum justo amet duo et elitr dolor est duo duo eos lorem sed diam stet diam sed stet lorem',N'Erat ipsum justo amet duo et elitr dolor est duo duo eos lorem sed diam stet diam sed stet lorem'
,'','tinhomnay','true', 1 ,GETDATE())


insert into Booking values(N'Phòng Th??ng',1,N'Nguy?n H?u ??c',0379999999,'admin@gmail.com','215555889111',GETDATE(),GETDATE(),N'?ã ??t',500000,
'','phong-thuong-1','true', 1 ,GETDATE())

