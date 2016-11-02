create table student_test_data(
	id int not null IDENTITY,
	mcq_choice varchar(1),
	descriptive_ans text,
	ture_false bit,
	question_id int,
	student_id int,
	primary key(id),
	foreign key(question_id) references question_table(question_id),
	foreign key(student_id) references student_table(student_id)
)	
