use Practice

create procedure Verify
@userName varchar(20), 
@passWord varchar(20)

as

begin 
select * from dbo.Login where username = @userName and password = @passWord

end 

exec Verify 'admin', 'admn'


 create procedure findInfor 
 @infor_Name nvarchar(50), 
 @infor_Gender nvarchar(10),
 @infor_Phone nvarchar(15),
 @infor_Email nvarchar(50),
 @infor_Address nvarchar(max)

 as

 begin 
 select * from dbo.Customer where (Name like concat('%', @infor_Name , '%') and 
									 Gender like COALESCE(@infor_Gender, '%%') and
									 Phone like concat('%', @infor_Phone , '%') and
									 Email like concat('%', @infor_Email , '%') and
									 Address like concat('%', @infor_Address , '%'))

 end