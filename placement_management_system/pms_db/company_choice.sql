create table company_choice(
	id int not null IDENTITY,
	student_id int,
	company_id int,
	selected bit,
	primary key(id),
	foreign key(company_id) references company_table(company_id),
	foreign key(student_id) references student_table(student_id)
)