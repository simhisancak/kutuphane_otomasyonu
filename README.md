## Kütüphane Otomasyonu
VISUAL STUDIO NUGET YÜKLEYIN
DAHA SONRA DERLEMEYE BAŞLADIĞINIZDA GEREKLI DOSYALAR INDIRILIP PROJE BAŞLATILACAKTIR


## Gerekli SQL Sorguları

##### Kullanıcılar Tablosu
```sql
CREATE TABLE  kitap_users
(
id int IDENTITY(1,1) PRIMARY KEY,
user_name varchar(50),
user_password varchar(50),
int1 int,
int2 int,
int3 int,
int4 int,
int5 int,
int6 int,
int7 int,
int8 int,
str1 varchar(50),
str2 varchar(50),
str3 varchar(50),
str4 varchar(50),
str5 varchar(50),
str6 varchar(50),
str7 varchar(50),
str8 varchar(50)

)
```

##### Kitaplar Tablosu
```sql
CREATE TABLE  kitap_db
(
id int IDENTITY(1,1) PRIMARY KEY,
kitap_ad varchar(50),
kitap_yazar varchar(50),
kitap_tarih varchar(50),
str4 varchar(50),
str5 varchar(50),
str6 varchar(50),
str7 varchar(50),
str8 varchar(50),
str9 varchar(50),
str10 varchar(50),
str11 varchar(50),
str12 varchar(50),
str13 varchar(50),
str14 varchar(50),
str15 varchar(50),
str16 varchar(50),
int1 varchar(50),
int2 varchar(50),
int3 varchar(50),
int4 varchar(50),
int5 varchar(50),
int6 varchar(50),
int7 varchar(50),
int8 varchar(50),
tarih1 varchar(50),
tarih2 varchar(50),
tarih3 varchar(50),
tarih4 varchar(50)


)
```
##### Kullanıcı Kayıt  (bi kere create bi kerede alter olarak çalıştırmanız lazım)
```sql
create PROC kitap_UserAdd
@user_name varchar(50),
@user_password varchar(50),
@str1 varchar(50),
@str2 varchar(50)
AS
Insert into kitap_users(user_name, user_password,str1,str2)
Values (@user_name, @user_password,@str1,@str2)
```

##### Kitap Kayıt  (bi kere create bi kerede alter olarak çalıştırmanız lazım)
```sql
create PROC kitap_kitapadd
@kitap_ad varchar(50),
@kitap_yazar varchar(50),
@str5 varchar(50),
@tarih1 varchar(50),
@int1 varchar(50),
@tarih2 varchar(50),
@tarih3 varchar(50),
@str4 varchar(50)
AS
Insert into kitap_db(kitap_ad ,kitap_yazar ,str5 ,tarih1 ,int1 ,tarih2 ,tarih3 ,str4)
Values (@kitap_ad ,@kitap_yazar ,@str5 ,@tarih1 ,@int1 ,@tarih2 ,@tarih3 ,@str4)


```

