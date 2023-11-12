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
insert into footer values(N'??c Hotelier',N'Nguy?n H?u Th?',N'52000645@student.tdtu.edu.vn','0379999999','Download Hotelier � Premium Version, build a professional website for your hotel business and grab the attention of new visitors upon your site�s launch.','','','true', 1,'')

insert into Menu values(N'Trang ch?','','/Default/Index','true', 1,'')
insert into Menu values(N'D?ch v?','','/Sevice/Index','true', 2,'')
insert into Menu values(N'??t ph�ng','','/Booking/Index','true',3,'')
insert into Menu values(N'Li�n h?','','/Contact/Index','true',4,'')
insert into Menu values(N'Ph�ng ?� ??t','','/Booking/Find','true',5,'')

insert into Caterogy values(N'Ph�ng th??ng','','phong-thuong','true', 1,'')
insert into Caterogy values(N'Ph�ng cao c?p','','phong-cao-cap','true', 1,'')
insert into Caterogy values(N'Ph�ng sang tr?ng','','phong-sang-trong','true', 1,'')


insert into About values(N'Welcome to ??c Hotell',N'L� m?t kh�ch s?n ??y ?? d?ch v?, ch�ng t�i cung c?p nh� h�ng trong khu�n vi�n, kh�ng gian t? ch?c h?i ngh? v� h?i ngh?, b�i bi?n ri�ng v� h? b?i ngo�i tr?i� Ch�ng t�i ch� � ??n t?ng chi ti?t ?? k? ngh? c?a b?n tho?i m�i nh?t c� th? v?i nhi?u ti?n nghi v� phong c�ch','','','true',1,'')

insert into Room values(N'Ph�ng th??ng',300000,N'room-1.jpg',N'Erat ipsum justo amet duo et elitr dolor est duo duo eos lorem sed diam stet diam sed stet lorem','','phong-thuong','true', 1 ,GETDAte(),1)
insert into Room values(N'Ph�ng cao c?p',500000,N'room-2.jpg',
N'Erat ipsum justo amet duo et elitr dolor, est duo duo eos lorem sed diam stet diam sed stet lorem.','','phong-cao-cap','true',1,'',2)
insert into Room values(N'Ph�ng Sang tr?ng',1000000,N'room-3.jpg',
N'Erat ipsum justo amet duo et elitr dolor, est duo duo eos lorem sed diam stet diam sed stet lorem.','','phong-sang-trong','true',1,'',3)
insert into Room values(N'Ph�ng th??ng',300000,N'room-1.jpg',N'Erat ipsum justo amet duo et elitr dolor est duo duo eos lorem sed diam stet diam sed stet lorem','','phong-thuong','true', 1 ,'',1)
insert into Room values(N'Ph�ng cao c?p',500000,N'room-2.jpg',
N'Erat ipsum justo amet duo et elitr dolor, est duo duo eos lorem sed diam stet diam sed stet lorem.','','phong-cao-cap','true',1,'',2)
insert into Room values(N'Ph�ng Sang tr?ng',1000000,N'room-3.jpg',
N'Erat ipsum justo amet duo et elitr dolor, est duo duo eos lorem sed diam stet diam sed stet lorem.','','phong-sang-trong','true',1,'',3)
insert into Room values(N'Ph�ng Sang tr?ng',1000000,N'room-3.jpg',
N'Erat ipsum justo amet duo et elitr dolor, est duo duo eos lorem sed diam stet diam sed stet lorem.','','phong-sang-trong','true',1,'',3)
insert into Room values(N'Ph�ng cao c?p',500000,N'room-2.jpg',
N'Erat ipsum justo amet duo et elitr dolor, est duo duo eos lorem sed diam stet diam sed stet lorem.','','phong-cao-cap','true',1,'',2)
insert into Room values(N'Ph�ng th??ng',300000,N'room-1.jpg',N'Erat ipsum justo amet duo et elitr dolor est duo duo eos lorem sed diam stet diam sed stet lorem','','phong-thuong','true', 1 ,'',1)

insert into Reviews values(N'Nguy?n H?u ??c','duc@gmail.com',N'Sinh vi�n',N'L� m?t kh�ch s?n ??y ?? d?ch v?, ch�ng t�i cung c?p nh� h�ng trong khu�n vi�n, kh�ng gian t? ch?c h?i ngh? v� h?i ngh?, b�i bi?n ri�ng v� h? b?i ngo�i tr?i� Ch�ng t�i ch� � ??n t?ng chi ti?t ?? k? ngh? c?a b?n tho?i m�i nh?t c� th? v?i nhi?u ti?n nghi v� phong c�ch','','','true',1,'')
insert into Reviews values(N'Nguy?n H?u ??c','duc@gmail.com',N'K? s?',N'L� m?t kh�ch s?n ??y ?? d?ch v?, ch�ng t�i cung c?p nh� h�ng trong khu�n vi�n, kh�ng gian t? ch?c h?i ngh? v� h?i ngh?, b�i bi?n ri�ng v� h? b?i ngo�i tr?i� Ch�ng t�i ch� � ??n t?ng chi ti?t ?? k? ngh? c?a b?n tho?i m�i nh?t c� th? v?i nhi?u ti?n nghi v� phong c�ch','','','true',1,'')
insert into Reviews values(N'Nguy?n H?u ??c','duc@gmail.com',N'Gi�m ??c',N'L� m?t kh�ch s?n ??y ?? d?ch v?, ch�ng t�i cung c?p nh� h�ng trong khu�n vi�n, kh�ng gian t? ch?c h?i ngh? v� h?i ngh?, b�i bi?n ri�ng v� h? b?i ngo�i tr?i� Ch�ng t�i ch� � ??n t?ng chi ti?t ?? k? ngh? c?a b?n tho?i m�i nh?t c� th? v?i nhi?u ti?n nghi v� phong c�ch','','','true',1,'')
insert into Reviews values(N'Nguy?n H?u ??c','duc@gmail.com',N'Ch? t?ch',N'L� m?t kh�ch s?n ??y ?? d?ch v?, ch�ng t�i cung c?p nh� h�ng trong khu�n vi�n, kh�ng gian t? ch?c h?i ngh? v� h?i ngh?, b�i bi?n ri�ng v� h? b?i ngo�i tr?i� Ch�ng t�i ch� � ??n t?ng chi ti?t ?? k? ngh? c?a b?n tho?i m�i nh?t c� th? v?i nhi?u ti?n nghi v� phong c�ch','','','true',1,'')
insert into Reviews values(N'Nguy?n H?u ??c','duc@gmail.com',N'Streamer',N'L� m?t kh�ch s?n ??y ?? d?ch v?, ch�ng t�i cung c?p nh� h�ng trong khu�n vi�n, kh�ng gian t? ch?c h?i ngh? v� h?i ngh?, b�i bi?n ri�ng v� h? b?i ngo�i tr?i� Ch�ng t�i ch� � ??n t?ng chi ti?t ?? k? ngh? c?a b?n tho?i m�i nh?t c� th? v?i nhi?u ti?n nghi v� phong c�ch','','','true',1,'')
insert into Reviews values(N'Nguy?n H?u ??c','duc@gmail.com',N'Reviewer',N'L� m?t kh�ch s?n ??y ?? d?ch v?, ch�ng t�i cung c?p nh� h�ng trong khu�n vi�n, kh�ng gian t? ch?c h?i ngh? v� h?i ngh?, b�i bi?n ri�ng v� h? b?i ngo�i tr?i� Ch�ng t�i ch� � ??n t?ng chi ti?t ?? k? ngh? c?a b?n tho?i m�i nh?t c� th? v?i nhi?u ti?n nghi v� phong c�ch','','','true',1,'')


insert into News values(N'Tin H�m nay',N'room-1.jpg',
N'Erat ipsum justo amet duo et elitr dolor est duo duo eos lorem sed diam stet diam sed stet lorem',N'Erat ipsum justo amet duo et elitr dolor est duo duo eos lorem sed diam stet diam sed stet lorem'
,'','tinhomnay','true', 1 ,GETDATE())
insert into News values(N'Tin Ng�y Mai',N'room-2.jpg',
N'Erat ipsum justo amet duo et elitr dolor est duo duo eos lorem sed diam stet diam sed stet lorem',N'Erat ipsum justo amet duo et elitr dolor est duo duo eos lorem sed diam stet diam sed stet lorem'
,'','tinhomnay','true', 1 ,GETDATE())
insert into News values(N'Tin H�m Qua',N'room-3.jpg',
N'Erat ipsum justo amet duo et elitr dolor est duo duo eos lorem sed diam stet diam sed stet lorem',N'Erat ipsum justo amet duo et elitr dolor est duo duo eos lorem sed diam stet diam sed stet lorem'
,'','tinhomnay','true', 1 ,GETDATE())


insert into Booking values(N'Ph�ng Th??ng',1,N'Nguy?n H?u ??c',0379999999,'admin@gmail.com','215555889111',GETDATE(),GETDATE(),N'?� ??t',500000,
'','phong-thuong-1','true', 1 ,GETDATE())

