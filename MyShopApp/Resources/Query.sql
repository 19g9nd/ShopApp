INSERT INTO Users( Login, Password, Email,isAdmin)
VALUES ('SampleLogin', 'SampleLogin',
'sample@example.com',1);

Insert into Statuses (Name) 
values ('in stock');
Insert into Statuses (Name) 
values ('out of stock');
Insert into Statuses (Name) 
values ('unknown');


insert into Products (Name,Description,StatusId)
values ('Iphone 14','apple phone',1)

select * from Users

select * from Statuses

select p.Id,p.Name,p.Description,p.StatusId,s.Name from Products p
join Statuses s on s.Id = p.StatusId;