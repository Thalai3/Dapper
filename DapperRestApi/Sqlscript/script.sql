Create table tbl_employee(
ID int primary key identity(1,1),
EmployeeName varchar(20) not null,
Age int not null,
Resumes varbinary(max) 
)

--drop table tbl_employee;
select * from tbl_employee;
Insert into tbl_employee values('Thalai.pdf',24,0x255044462D312E350A25E2E3CFD30A)
