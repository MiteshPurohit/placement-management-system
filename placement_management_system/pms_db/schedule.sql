create table schedule(
	id int not null IDENTITY,
	student_id int,
	company_id int,
	tentative_interview_date date,
	tentative_written_test_date date,
	primary key(id),
	foreign key(company_id) references company_table(company_id),
	foreign key(student_id) references student_table(student_id)
)