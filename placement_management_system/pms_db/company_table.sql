
create table company_table(
	company_id int not null IDENTITY,
	password varchar(30) not null,
	tentative_salary varchar(10),
	job_post varchar(30),
	job_location varchar(30),
	company_name varchar(30) NOT NULL,
	description text,
	other_details text,
	required_min_cpi NUMERIC(3, 3),
	primary key(company_id)
)
