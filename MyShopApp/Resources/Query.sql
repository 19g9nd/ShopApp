INSERT INTO Users( Login, Password, Email,isAdmin)
VALUES ('SampleLogin', 'SampleLogin',
'sample@example.com',1);

Insert into Statuses (Name) 
values ('in stock');
Insert into Statuses (Name) 
values ('out of stock');
Insert into Statuses (Name) 
values ('unknown');



insert into Products (Name,Description,Quantity,StatusId,Price)
values ('Iphone 10','apple phone',20,1,150)

select * from Users


select * from Statuses
select * from Products

select p.Id,p.Name,p.Description,p.StatusId,p.Quantity, s.Name from Products p
join Statuses s on s.Id = p.StatusId;