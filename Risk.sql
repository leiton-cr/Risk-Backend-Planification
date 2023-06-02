

-- DROP SCHEMA dbo;

create database Risk;
use Risk; 
-- Risk.dbo.tbl_impacts definition

-- Drop table

-- DROP TABLE Risk.dbo.tbl_impacts;

CREATE TABLE Risk.dbo.tbl_impacts (
	id varchar(36) COLLATE Modern_Spanish_CI_AS NOT NULL,
	name varchar(15) COLLATE Modern_Spanish_CI_AS NULL,
	value int NULL,
	active bit DEFAULT 1 NULL,
	CONSTRAINT PK__tbl_impa__3213E83FBA413FD1 PRIMARY KEY (id),
	CONSTRAINT UQ__tbl_impa__40BBEA3A0BF810E2 UNIQUE (value),
	CONSTRAINT UQ__tbl_impa__72E12F1BC4438D42 UNIQUE (name)
);


-- Risk.dbo.tbl_priorities definition

-- Drop table

-- DROP TABLE Risk.dbo.tbl_priorities;

CREATE TABLE Risk.dbo.tbl_priorities (
	id varchar(36) COLLATE Modern_Spanish_CI_AS NOT NULL,
	name varchar(15) COLLATE Modern_Spanish_CI_AS NULL,
	value int NULL,
	active bit DEFAULT 1 NULL,
	CONSTRAINT PK__tbl_prio__3213E83FAFE49325 PRIMARY KEY (id),
	CONSTRAINT UQ__tbl_prio__40BBEA3AF966D022 UNIQUE (value),
	CONSTRAINT UQ__tbl_prio__72E12F1B09DA1903 UNIQUE (name)
);


-- Risk.dbo.tbl_probabilities definition

-- Drop table

-- DROP TABLE Risk.dbo.tbl_probabilities;

CREATE TABLE Risk.dbo.tbl_probabilities (
	id varchar(36) COLLATE Modern_Spanish_CI_AS NOT NULL,
	name varchar(15) COLLATE Modern_Spanish_CI_AS NULL,
	value int NULL,
	active bit DEFAULT 1 NULL,
	CONSTRAINT PK__tbl_prob__3213E83F0A70C1C8 PRIMARY KEY (id),
	CONSTRAINT UQ__tbl_prob__40BBEA3A0E9FF674 UNIQUE (value),
	CONSTRAINT UQ__tbl_prob__72E12F1BCC5EF7C7 UNIQUE (name)
);


-- Risk.dbo.tbl_projects definition

-- Drop table

-- DROP TABLE Risk.dbo.tbl_projects;

CREATE TABLE Risk.dbo.tbl_projects (
	id varchar(36) COLLATE Modern_Spanish_CI_AS NOT NULL,
	name varchar(50) COLLATE Modern_Spanish_CI_AS NULL,
	active bit DEFAULT 1 NULL,
	CONSTRAINT PK__tbl_proj__3213E83FFA3EEA8E PRIMARY KEY (id),
	CONSTRAINT UQ__tbl_proj__72E12F1BD9AA36A2 UNIQUE (name)
);


-- Risk.dbo.tbl_users definition

-- Drop table

-- DROP TABLE Risk.dbo.tbl_users;

CREATE TABLE Risk.dbo.tbl_users (
	id varchar(36) COLLATE Modern_Spanish_CI_AS NOT NULL,
	email varchar(50) COLLATE Modern_Spanish_CI_AS NULL,
	pepper varchar(48) COLLATE Modern_Spanish_CI_AS NULL,
	salt int NOT NULL,
	pass varchar(50) COLLATE Modern_Spanish_CI_AS NULL,
	active bit DEFAULT 1 NULL,
	name varchar(50) COLLATE Modern_Spanish_CI_AS NULL,
	url_image varchar(255) COLLATE Modern_Spanish_CI_AS NULL,
	CONSTRAINT PK__tbl_user__3213E83FF352FA2B PRIMARY KEY (id),
	CONSTRAINT UQ__tbl_user__AB6E6164C4C7147B UNIQUE (email)
);


-- Risk.dbo.tbl_registers definition

-- Drop table

-- DROP TABLE Risk.dbo.tbl_registers;

CREATE TABLE Risk.dbo.tbl_registers (
	id varchar(36) COLLATE Modern_Spanish_CI_AS NOT NULL,
	project_id varchar(36) COLLATE Modern_Spanish_CI_AS NULL,
	task_id varchar(36) COLLATE Modern_Spanish_CI_AS NULL,
	task_description varchar(150) COLLATE Modern_Spanish_CI_AS NULL,
	active bit DEFAULT 1 NULL,
	updated_at date NULL,
	CONSTRAINT PK__tbl_regi__3213E83FB096B9B8 PRIMARY KEY (id),
	CONSTRAINT UQ__tbl_regi__0492148C6302D470 UNIQUE (task_id),
	CONSTRAINT FK_registers_projects FOREIGN KEY (project_id) REFERENCES Risk.dbo.tbl_projects(id)
);


-- Risk.dbo.tbl_details definition

-- Drop table

-- DROP TABLE Risk.dbo.tbl_details;

CREATE TABLE Risk.dbo.tbl_details (
	id varchar(36) COLLATE Modern_Spanish_CI_AS NOT NULL,
	id_register varchar(36) COLLATE Modern_Spanish_CI_AS NULL,
	risk_description varchar(150) COLLATE Modern_Spanish_CI_AS NULL,
	impact_description varchar(150) COLLATE Modern_Spanish_CI_AS NULL,
	probability_id varchar(36) COLLATE Modern_Spanish_CI_AS NULL,
	impact_id varchar(36) COLLATE Modern_Spanish_CI_AS NULL,
	owner varchar(50) COLLATE Modern_Spanish_CI_AS NULL,
	response_plan varchar(150) COLLATE Modern_Spanish_CI_AS NULL,
	priority_id varchar(36) COLLATE Modern_Spanish_CI_AS NULL,
	points int NULL,
	CONSTRAINT PK__tbl_deta__3213E83F3E49FB59 PRIMARY KEY (id),
	CONSTRAINT FK_details_impacts FOREIGN KEY (impact_id) REFERENCES Risk.dbo.tbl_impacts(id),
	CONSTRAINT FK_details_priorties FOREIGN KEY (priority_id) REFERENCES Risk.dbo.tbl_priorities(id),
	CONSTRAINT FK_details_probabilities FOREIGN KEY (probability_id) REFERENCES Risk.dbo.tbl_probabilities(id),
	CONSTRAINT FK_details_registers FOREIGN KEY (id_register) REFERENCES Risk.dbo.tbl_registers(id)
);

INSERT INTO Risk.dbo.tbl_details (id,id_register,risk_description,impact_description,probability_id,impact_id,owner,response_plan,priority_id,points) VALUES
	 (N'0cc65da7-e0a0-409d-8692-deb414b928d4',N'03b7fb70-f3ca-4511-bae4-dbb63c44aa2c',N'qqq',N'qqqqqqqq',N'3',N'3',N'qqqqqq',N'qqqqqqqqqqqqa',N'2b2c56e7-48c6-455d-9c60-8b1b786d3e44',9),
	 (N'0ce116fb-3bb6-4065-85b0-f639112a631e',N'6c0930a7-bbf1-406c-94b8-305c48554d9c',N'validar inserciones ',N'si no se valida pued eque se tengan datos nulos ',N'3',N'3',N'new risk to nova',N'new risk to nova',N'2b2c56e7-48c6-455d-9c60-8b1b786d3e44',9),
	 (N'10d59f90-d7fa-4618-803c-b1c872685be4',N'14c190d0-8827-4530-9dff-181d6ff13d07',N'zzzzzz',N'zzzzzzzz',N'3',N'3',N'zzzzzzzzzzz',N'zzzzzzzzzzzz',N'5eb5ed2d-1c2a-4e2d-89cf-0d5f3c09140a',9),
	 (N'115a12c5-5a6a-4dd2-a0f8-96a735b9596e',N'14c190d0-8827-4530-9dff-181d6ff13d07',N'asdasdas',N'dasdasd',N'2',N'3',N'asdasd',N'asdasd',N'5eb5ed2d-1c2a-4e2d-89cf-0d5f3c09140a',6),
	 (N'142a1d7b-c576-4126-9cc6-52ae309d04b0',N'bd2ad56d-b224-4556-8323-46c9c22d3991',N'sgsdfg',N'dfgdf',N'2',N'3',N'dfgdfg',N'dfgdfg',N'2b2c56e7-48c6-455d-9c60-8b1b786d3e44',6),
	 (N'1dd2e5bb-a2ae-4e65-9a97-4bd61703918a',N'8019bdb8-4195-4781-8ab2-0a456843ac82',N'aaaaaa',N'aaaaaaaa',N'5',N'5',N'aaaaaaaaa',N'aaaaaaaaa',N'292a2f92-8137-4b17-8c7b-fd6b8577f60c',25),
	 (N'1fcb37cd-b9fb-4815-acee-6347b18b2766',N'87341691-1293-4eef-930f-410c012bd3b4',N'nuevo riesgo',N'nuevo riesgo',N'2',N'4',N'nuevo riesgo',N'nuevo riesgo',N'2b2c56e7-48c6-455d-9c60-8b1b786d3e44',8),
	 (N'2c277c3c-b2b8-41ac-ade4-f1d26f267ac6',N'1af90653-c785-40c1-ba17-e0fdab646cbd',N'asdasd',N'asdas',N'3',N'3',N'asdasd',N'asdasd',N'2b2c56e7-48c6-455d-9c60-8b1b786d3e44',9),
	 (N'308b99ba-1229-4836-b7af-ac16bcf94050',N'70e32aa9-9761-413a-9c2a-c377ad4cbf4a',N'zxczxczx',N'czxczxc',N'2',N'3',N'zxczxc',N'zxczx',N'2b2c56e7-48c6-455d-9c60-8b1b786d3e44',6),
	 (N'355a0070-e4c8-4352-8e95-32947a1b7692',N'8019bdb8-4195-4781-8ab2-0a456843ac82',N'bbbbb',N'bbbbbbb',N'2',N'2',N'bbbbbbbbb',N'bbbbbbbbb',N'e8947edc-6f28-4f87-b6ec-23f22a3e9b3e',4);
INSERT INTO Risk.dbo.tbl_details (id,id_register,risk_description,impact_description,probability_id,impact_id,owner,response_plan,priority_id,points) VALUES
	 (N'3875171c-1ff8-492b-bd8e-84961cf65036',N'5a318fc6-d38c-4005-b29d-d3a4b7b4dca6',N'ttttt',N'tttttttttt',N'1',N'3',N'tttttttttt',N'tttttt',N'2b2c56e7-48c6-455d-9c60-8b1b786d3e44',3),
	 (N'3db1ed3b-5c6c-4c02-a693-53032df6efc0',N'5d3fbe86-9b5a-4eb5-9370-c140e81803b8',N'qweertg',N'ertert',N'3',N'3',N'ertert',N'erter',N'e8947edc-6f28-4f87-b6ec-23f22a3e9b3e',9),
	 (N'48c44997-de4a-4b5e-a71c-0e66931445e1',N'61d17eb0-d463-48fc-99c5-a34f7ec482d3',N'Some random risk new diferent',N'Some random impact',N'1',N'2',N'Luis Leiton',N'Some random response plan',N'5eb5ed2d-1c2a-4e2d-89cf-0d5f3c09140a',2),
	 (N'4b3f7efc-3f49-46eb-aca4-89343df1fde2',N'b8bb4bb9-efcf-4249-b7e7-9ed37da99f7c',N'tyutyu',N'tyutyu',N'5',N'5',N'tyutyut',N'tyut',N'79c484be-b38b-4e4f-ba0e-857ee5f99ad4',25),
	 (N'624a1929-cbc9-484a-b3cd-b29d72d19fa2',N'b8bb4bb9-efcf-4249-b7e7-9ed37da99f7c',N'fdgdsfdg',N'fdgdfg',N'1',N'1',N'xcvxcvxc',N'xcvxcv',N'2b2c56e7-48c6-455d-9c60-8b1b786d3e44',1),
	 (N'66a6bc9e-7449-474c-8c8c-353c62c1d7b8',N'14c190d0-8827-4530-9dff-181d6ff13d07',N'asdasd',N'asdasd',N'3',N'4',N'asdasd',N'adasd',N'79c484be-b38b-4e4f-ba0e-857ee5f99ad4',12),
	 (N'72e8c19c-ab2d-4c64-9188-4170224283f0',N'61d17eb0-d463-48fc-99c5-a34f7ec482d3',N'Some random risk new diferent',N'Some random impact',N'4',N'3',N'Luis Leiton',N'Some random response plan',N'5eb5ed2d-1c2a-4e2d-89cf-0d5f3c09140a',3),
	 (N'894c4ea1-3104-4ecc-9d3f-ecc3d5cd3059',N'4ee355b7-efe2-403d-a4d9-550bd93ae9cc',N'uiouio',N'uiouio',N'2',N'2',N'uiouio',N'uiouio',N'2b2c56e7-48c6-455d-9c60-8b1b786d3e44',4),
	 (N'90df47db-bf8c-450e-9192-316586d252d0',N'556d62e5-0638-4371-9ea0-9046b82dfd33',N'sdfsdf',N'xcascasd',N'1',N'3',N'asdasd',N'asdasd',N'2b2c56e7-48c6-455d-9c60-8b1b786d3e44',3),
	 (N'91f2620a-8a66-4e1b-b2d9-e22b91b31946',N'9126fe59-ee32-49b9-b40c-ab9e11d97a7e',N'wwww',N'wwwwww',N'2',N'4',N'wwwwww',N'wwwwwww',N'2b2c56e7-48c6-455d-9c60-8b1b786d3e44',8);
INSERT INTO Risk.dbo.tbl_details (id,id_register,risk_description,impact_description,probability_id,impact_id,owner,response_plan,priority_id,points) VALUES
	 (N'922fb571-0a08-474c-8b56-897c05d5befe',N'03b7fb70-f3ca-4511-bae4-dbb63c44aa2c',N'kljkljksss',N'jkljkl',N'3',N'2',N'jkljk',N'jkljkl',N'2b2c56e7-48c6-455d-9c60-8b1b786d3e44',6),
	 (N'a5d2e18b-7588-4ba2-baea-477f57753343',N'9ef3e512-0448-4002-af04-21588bcba2cd',N'zxczx',N'czxczxc',N'3',N'4',N'zxczxc',N'zxczxczxc',N'79c484be-b38b-4e4f-ba0e-857ee5f99ad4',12),
	 (N'b48d5960-df04-498d-aa8d-c136d0e830ea',N'1c1d36fd-709e-4be1-99fa-a4c4f1adc2a5',N'xcvxcv',N'xcvxcv',N'2',N'3',N'xcvxcv',N'xcvxcv',N'2b2c56e7-48c6-455d-9c60-8b1b786d3e44',6),
	 (N'd120c409-b66c-483b-be52-a65e53d070be',N'61d17eb0-d463-48fc-99c5-a34f7ec482d3',N'Some random risk new diferent',N'Some random impact',N'5',N'1',N'Luis Leiton',N'Some random response plan',N'5eb5ed2d-1c2a-4e2d-89cf-0d5f3c09140a',5),
	 (N'da01a61a-8e15-4801-bd2b-be531fb85bd9',N'61d17eb0-d463-48fc-99c5-a34f7ec482d3',N'Some random risk new diferent',N'Some random impact',N'4',N'3',N'Luis Leiton',N'Some random response plan',N'5eb5ed2d-1c2a-4e2d-89cf-0d5f3c09140a',3),
	 (N'e060b030-bfcc-4f47-95f4-af9a7ef0d67d',N'9126fe59-ee32-49b9-b40c-ab9e11d97a7e',N'',N'eeee',N'2',N'2',N'eeeeeeee',N'eeeeeeee',N'e8947edc-6f28-4f87-b6ec-23f22a3e9b3e',4),
	 (N'e6955bf2-1ed8-45f2-91bf-262f3f2c2fff',N'61d17eb0-d463-48fc-99c5-a34f7ec482d3',N'Some random risk new diferent',N'Some random impact',N'2',N'4',N'Luis Leiton',N'Some random response plan',N'5eb5ed2d-1c2a-4e2d-89cf-0d5f3c09140a',5),
	 (N'ef2467ae-dee0-4a9c-9652-d32e3fbd68ca',N'61d17eb0-d463-48fc-99c5-a34f7ec482d3',N'Some random risk new diferent',N'Some random impact',N'5',N'1',N'Luis Leiton',N'Some random response plan',N'5eb5ed2d-1c2a-4e2d-89cf-0d5f3c09140a',5),
	 (N'f6b1748a-b714-44db-926f-cc608ba371e9',N'14c190d0-8827-4530-9dff-181d6ff13d07',N'sdasd',N'asdasd',N'3',N'3',N'asdasd',N'asdas',N'2b2c56e7-48c6-455d-9c60-8b1b786d3e44',9),
	 (N'fb64d2cb-b6b8-4bc0-973f-4d73c58decd4',N'8bfc3c03-cc52-44ed-9e77-0c6e9a3075e1',N'se caiga el cdn de sweet alert',N'no se mostraran alertas',N'3',N'3',N'Steven Rojas',N'Steven Rojas',N'2b2c56e7-48c6-455d-9c60-8b1b786d3e44',9);
INSERT INTO Risk.dbo.tbl_details (id,id_register,risk_description,impact_description,probability_id,impact_id,owner,response_plan,priority_id,points) VALUES
	 (N'fff38c6e-5320-4d07-a951-a357d9c8ec79',N'6336d5a8-4ec4-4321-94a2-b787c222a767',N'agregar un nuevo risgo',N'no se ',N'3',N'3',N'Steven Rojas',N'Steven Rojas',N'2b2c56e7-48c6-455d-9c60-8b1b786d3e44',9);


INSERT INTO Risk.dbo.tbl_impacts (id,name,value,active) VALUES
	 (N'1',N'insignificant',0,1),
	 (N'2',N'minor',1,1),
	 (N'3',N'significant',2,1),
	 (N'4',N'major',3,1),
	 (N'5',N'severe',4,1);


INSERT INTO Risk.dbo.tbl_priorities (id,name,value,active) VALUES
	 (N'292a2f92-8137-4b17-8c7b-fd6b8577f60c',N'Lowest',0,1),
	 (N'2b2c56e7-48c6-455d-9c60-8b1b786d3e44',N'Medium',2,1),
	 (N'5eb5ed2d-1c2a-4e2d-89cf-0d5f3c09140a',N'Highest',4,1),
	 (N'79c484be-b38b-4e4f-ba0e-857ee5f99ad4',N'High',3,1),
	 (N'e8947edc-6f28-4f87-b6ec-23f22a3e9b3e',N'Low',1,1);

INSERT INTO Risk.dbo.tbl_probabilities (id,name,value,active) VALUES
	 (N'1',N'Rare',0,1),
	 (N'2',N'Unlikely',1,1),
	 (N'3',N'Moderate',2,1),
	 (N'4',N'Likely',3,1),
	 (N'5',N'Almost certain',4,1);

INSERT INTO Risk.dbo.tbl_projects (id,name,active) VALUES
	 (N'1f00767d-463d-4fc2-9fc2-22deed51b5d5',N'Infinity',1),
	 (N'22d19be4-b7b4-4ca9-b7d1-b6e48a7e2f0d',N'Helios',1),
	 (N'3a2913b2-920d-43d5-9f72-0fa61a2a313f',N'Titan',1),
	 (N'3dc3fddc-0b23-482e-af27-0a3eb0f2a573',N'Odyssey II',1),
	 (N'4f9ee4c4-833f-4a71-8a0f-efc23e29e531',N'Prometheus',1),
	 (N'6b3c07d9-9dd3-4c69-b3d4-97bf4e86f4c4',N'Nimbus',1),
	 (N'6eb1b6cf-522d-4568-8ca3-3b28337c0971',N'Atlas II',1),
	 (N'b372f8de-9aae-4c81-93e8-0d0a1a656ef4',N'Phoenix',1),
	 (N'bd2af2f7-ff6d-4be7-9356-cf72a020c09b',N'Apollo',1),
	 (N'c4a4f94d-834e-4fb3-b3aa-fcbce15d973f',N'Atlas',1);
INSERT INTO Risk.dbo.tbl_projects (id,name,active) VALUES
	 (N'cfb51c57-fa04-4a2b-8725-5a8b5dbd35b6',N'Nova',1),
	 (N'e68c3cb9-9da2-43b5-9b1d-57a81f078d68',N'Horizon',1),
	 (N'eaedf6f1-6a8c-487f-bcfa-b0c579f0ed12',N'Odyssey',1),
	 (N'f5dcfb50-720a-41d5-836c-c170548a7d71',N'Prometheus II',1),
	 (N'fb9f0e79-090a-4c84-8a84-10a4e4dd4d4a',N'Eclipse',1);

INSERT INTO Risk.dbo.tbl_registers (id,project_id,task_id,task_description,active,updated_at) VALUES
	 (N'03b7fb70-f3ca-4511-bae4-dbb63c44aa2c',N'4f9ee4c4-833f-4a71-8a0f-efc23e29e531',N'29afe0e4-9ce2-4d90-87bf-ae2701a58a5e',N'esto es una prueba actualizada',1,'2023-06-01'),
	 (N'14c190d0-8827-4530-9dff-181d6ff13d07',N'e68c3cb9-9da2-43b5-9b1d-57a81f078d68',N'8ffc2b74-2459-4edb-8d60-75a8db3b0afa',N'prueba ',1,'0001-01-01'),
	 (N'1af90653-c785-40c1-ba17-e0fdab646cbd',N'3dc3fddc-0b23-482e-af27-0a3eb0f2a573',N'ac46ba48-e768-4565-9d2e-31d02ecf27be',N'agregar riesgo en odissey',1,'0001-01-01'),
	 (N'1c1d36fd-709e-4be1-99fa-a4c4f1adc2a5',N'6b3c07d9-9dd3-4c69-b3d4-97bf4e86f4c4',N'aaf43d6a-fdb5-4c5a-b908-1938a61b144b',N'xcvxcv',1,NULL),
	 (N'4ee355b7-efe2-403d-a4d9-550bd93ae9cc',N'b372f8de-9aae-4c81-93e8-0d0a1a656ef4',N'856d4bdd-e847-4969-9ec1-6ac34b6ec982',N'iouiouio',0,NULL),
	 (N'556d62e5-0638-4371-9ea0-9046b82dfd33',N'6b3c07d9-9dd3-4c69-b3d4-97bf4e86f4c4',N'26d0f7a6-b514-4305-adb8-6859bdd7f2e4',N'adADAs',1,NULL),
	 (N'5a318fc6-d38c-4005-b29d-d3a4b7b4dca6',N'3a2913b2-920d-43d5-9f72-0fa61a2a313f',N'22649bee-d1ea-4de1-b0f1-5e9a57f5ce20',N'ttttttttt',0,NULL),
	 (N'5d3fbe86-9b5a-4eb5-9370-c140e81803b8',N'f5dcfb50-720a-41d5-836c-c170548a7d71',N'7a9f7a03-dd5f-4298-8f88-3fbf024081d0',N'qwqwq',0,NULL),
	 (N'61d17eb0-d463-48fc-99c5-a34f7ec482d3',N'1f00767d-463d-4fc2-9fc2-22deed51b5d5',N'8efe0473-d69e-4583-bc3a-3db7687ec67e',N'Some random project updated',1,'0001-01-01'),
	 (N'6336d5a8-4ec4-4321-94a2-b787c222a767',N'cfb51c57-fa04-4a2b-8725-5a8b5dbd35b6',N'9d2fa8e1-9add-44c6-8cb3-87a3a19c2282',N'que calor',0,'0001-01-01');
INSERT INTO Risk.dbo.tbl_registers (id,project_id,task_id,task_description,active,updated_at) VALUES
	 (N'6c0930a7-bbf1-406c-94b8-305c48554d9c',N'cfb51c57-fa04-4a2b-8725-5a8b5dbd35b6',N'cbee8deb-62d9-49dd-8f33-b15048b75444',N'Validar datos de entrada',1,'0001-01-01'),
	 (N'70e32aa9-9761-413a-9c2a-c377ad4cbf4a',N'b372f8de-9aae-4c81-93e8-0d0a1a656ef4',N'b88d8c59-d48d-4f30-abe7-613d5022f798',N'zxczxczx',1,NULL),
	 (N'8019bdb8-4195-4781-8ab2-0a456843ac82',N'fb9f0e79-090a-4c84-8a84-10a4e4dd4d4a',N'93e48a6c-a95f-47b0-8086-91de7e6df1eb',N'agregar riesgos',1,NULL),
	 (N'87341691-1293-4eef-930f-410c012bd3b4',N'22d19be4-b7b4-4ca9-b7d1-b6e48a7e2f0d',N'401adc42-2f7e-4916-83c4-fa0890c94b26',N'nuevo riesgo',0,NULL),
	 (N'8bfc3c03-cc52-44ed-9e77-0c6e9a3075e1',N'cfb51c57-fa04-4a2b-8725-5a8b5dbd35b6',N'3098059d-b743-46cc-8399-3c45a696588d',N'agregar alertas',1,'0001-01-01'),
	 (N'9126fe59-ee32-49b9-b40c-ab9e11d97a7e',N'3dc3fddc-0b23-482e-af27-0a3eb0f2a573',N'256903bf-92c4-457d-8cc7-98d142d6bf49',N'wwwwwwwww',0,NULL),
	 (N'9ef3e512-0448-4002-af04-21588bcba2cd',N'6b3c07d9-9dd3-4c69-b3d4-97bf4e86f4c4',N'3add4640-47cf-4103-8ffe-e37d0e43c870',N'zxczxczx',1,NULL),
	 (N'b8bb4bb9-efcf-4249-b7e7-9ed37da99f7c',N'fb9f0e79-090a-4c84-8a84-10a4e4dd4d4a',N'7055b133-dfb0-4f07-83e9-a8b5fb35b9e5',N'NUeva tarea ',1,NULL),
	 (N'bd2ad56d-b224-4556-8323-46c9c22d3991',N'3dc3fddc-0b23-482e-af27-0a3eb0f2a573',N'b4daca91-9875-4d6a-8d43-0f3c559f7f5c',N'sdasd',0,NULL),
	 (N'e4b5919f-f830-421e-ab52-2f63763f490e',N'1f00767d-463d-4fc2-9fc2-22deed51b5d5',N'0e7ee09b-7b74-4933-a985-918d40f211bc',N'Some random projecta',0,NULL);


INSERT INTO Risk.dbo.tbl_users (id,email,pepper,salt,pass,active,name,url_image) VALUES
	 (N'0a5bd216-5209-4412-b154-0250bb665557',N'Fernando_Iglesias@gmail.com',N'R0gzbEdlODNWeVVpYTB6cTQxTVg5YlowVVJJPQ==',7600193,N'000blPaDTN4MGA6ehBDr+j4TUPmNnsxWA1wDy4mdxlA=',1,NULL,NULL),
	 (N'110df171-d260-452a-8ff8-1bf13d2c5c3e',N'steverova0594@gmail.com',N'Y2Nsc2h4N2NJWVQwa1JUL1hCbEJiaE5tQXRrPQ==',3770387,N'000sdtSYkKG3xm0KhcA0xfjBswH4V8vh8iC8GyN6fuk=',1,NULL,NULL),
	 (N'8d940b92-4d0c-4d96-8c32-c36a228421f8',N'Luis.leiton.cr@gmail.com',N'Ti9nSjhFZklBdC95aUFtKzNVS001RHNRVkpZPQ==',662848,N'000EwjVXwee431RkqqBQ9qzt6EtBhZGffkY3hr4/IwU=',1,NULL,NULL),
	 (N'e5d9715b-1a75-4117-be69-fd857b0281cd',N'string',N'ZDRKblJYVFZ3ajEyTmtBdGttTWFuOGc0ZUdFPQ==',5224141,N'000QnUQToXWR/jqkKfcVTzl0oJmyuZ+HGsoalBR8Q6M=',1,NULL,NULL);


