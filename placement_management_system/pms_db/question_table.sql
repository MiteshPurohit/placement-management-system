create table question_table(
	question_id int not null IDENTITY,
	question text not null,
	option_a text,
	option_b text,
	option_c text,
	option_d text,
	choice_ans varchar(1),
	descriptive_ans text,
	company_id int not null,
	primary key(question_id),
	foreign key(company_id) references company_table(company_id),
)