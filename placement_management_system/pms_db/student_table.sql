create table student_table(
	student_id int not null IDENTITY ,
	collage_id varchar(12) not null unique,
	gender varchar(1) not null,
	email_id varchar(90),
	password varchar(30) not null,
	mobile_no varchar(10) not null,
	refrance_documents VARBINARY(MAX),
	branch varchar(2) NOT NULL,
	dob date NOT NULL,
	cpi NUMERIC(3, 3) NOT NULL,
	full_name varchar(90) NOT NULL,
	primary key (student_id)
)