-- Risk.dbo.tbl_impacts definition

-- Drop table

-- DROP TABLE Risk.dbo.tbl_impacts;

CREATE TABLE Risk.dbo.tbl_impacts (
	id varchar(36) PRIMARY KEY,
	name varchar(15) UNIQUE,
	value int UNIQUE,
	active bit DEFAULT 1
);


-- Risk.dbo.tbl_priorities definition

-- Drop table

-- DROP TABLE Risk.dbo.tbl_priorities;

CREATE TABLE Risk.dbo.tbl_priorities (
	id varchar(36) PRIMARY KEY,
	name varchar(15) UNIQUE,
	value int UNIQUE,
	active bit DEFAULT 1
);


-- Risk.dbo.tbl_probabilities definition

-- Drop table

-- DROP TABLE Risk.dbo.tbl_probabilities;

CREATE TABLE Risk.dbo.tbl_probabilities (
	id varchar(36) PRIMARY KEY,
	name varchar(15) UNIQUE,
	value int UNIQUE,
	active bit DEFAULT 1
);


-- Risk.dbo.tbl_projects definition

-- Drop table

-- DROP TABLE Risk.dbo.tbl_projects;

CREATE TABLE Risk.dbo.tbl_projects (
	id varchar(36) PRIMARY KEY,
	name varchar(50) UNIQUE,
	active bit DEFAULT 1
);


-- Risk.dbo.tbl_users definition

-- Drop table

-- DROP TABLE Risk.dbo.tbl_users;

CREATE TABLE Risk.dbo.tbl_users (
	id varchar(36) PRIMARY KEY,
	email varchar(50) UNIQUE,
	pepper varchar(48),
	salt int NOT NULL,
	pass varchar(50),
	active bit DEFAULT 1
);


-- Risk.dbo.tbl_registers definition

-- Drop table

-- DROP TABLE Risk.dbo.tbl_registers;

CREATE TABLE Risk.dbo.tbl_registers (
	id varchar(36) PRIMARY KEY,
	project_id varchar(36),
	task_id varchar(36) UNIQUE,
	task_description varchar(150),
	active bit DEFAULT 1,
	updated_at date,
	CONSTRAINT FK_registers_projects FOREIGN KEY (project_id) REFERENCES Risk.dbo.tbl_projects(id)
);


CREATE TABLE Risk.dbo.tbl_details(
	id varchar(36) PRIMARY KEY,
	risk_description varchar(150),
	impact_description varchar(150),
	probability_id varchar(36),
	impact_id varchar(36),
	owner varchar(50),
	response_plan varchar(150),
	priority_id varchar(36),
	points int,
	CONSTRAINT FK_details_impacts FOREIGN KEY (impact_id) REFERENCES Risk.dbo.tbl_impacts(id),
	CONSTRAINT FK_details_priorties FOREIGN KEY (priority_id) REFERENCES Risk.dbo.tbl_priorities(id),
	CONSTRAINT FK_details_probabilities FOREIGN KEY (probability_id) REFERENCES Risk.dbo.tbl_probabilities(id)
);

CREATE TABLE Risk.dbo.tbl_registered_details(
	id_register varchar(36),
	id_detail varchar(36),
	PRIMARY KEY(id_register,id_detail),
	CONSTRAINT FK_registered_details_detail FOREIGN KEY (id_register) REFERENCES Risk.dbo.tbl_registers(id),
	CONSTRAINT FK_registered_details_register FOREIGN KEY (id_detail) REFERENCES Risk.dbo.tbl_details(id)
);


INSERT INTO tbl_projects (id, name, active) VALUES 
('b372f8de-9aae-4c81-93e8-0d0a1a656ef4', 'Phoenix', 1),
('4f9ee4c4-833f-4a71-8a0f-efc23e29e531', 'Prometheus', 1),
('c4a4f94d-834e-4fb3-b3aa-fcbce15d973f', 'Atlas', 1),
('eaedf6f1-6a8c-487f-bcfa-b0c579f0ed12', 'Odyssey', 1),
('1f00767d-463d-4fc2-9fc2-22deed51b5d5', 'Infinity', 1),
('3a2913b2-920d-43d5-9f72-0fa61a2a313f', 'Titan', 1),
('6b3c07d9-9dd3-4c69-b3d4-97bf4e86f4c4', 'Nimbus', 1),
('fb9f0e79-090a-4c84-8a84-10a4e4dd4d4a', 'Eclipse', 1),
('bd2af2f7-ff6d-4be7-9356-cf72a020c09b', 'Apollo', 1),
('3dc3fddc-0b23-482e-af27-0a3eb0f2a573', 'Odyssey II', 1),
('cfb51c57-fa04-4a2b-8725-5a8b5dbd35b6', 'Nova', 1),
('22d19be4-b7b4-4ca9-b7d1-b6e48a7e2f0d', 'Helios', 1),
('6eb1b6cf-522d-4568-8ca3-3b28337c0971', 'Atlas II', 1),
('e68c3cb9-9da2-43b5-9b1d-57a81f078d68', 'Horizon', 1),
('f5dcfb50-720a-41d5-836c-c170548a7d71', 'Prometheus II', 1);

INSERT INTO tbl_probabilities (id, name, active) VALUES 
('d53f6da9-6c12-40d7-aa5b-79df1c408a2b', 'Rare', 1),
('2b9c5c5d-1b64-4625-80c5-497f82182aa7', 'Unlikely', 1),
('9c820f8d-0e05-4a4f-a4ad-b81ad1a4d3b3', 'Moderate', 1),
('a57c183d-91b7-4d96-8e84-67c36944ce38', 'Likely', 1),
('98b09a89-24f3-44d5-9106-9fc6f2e78c33', 'Almost certain', 1);

INSERT INTO tbl_impacts (id, name) VALUES 
('e6c8f6e8-6a34-4d1b-8c7e-f2d9b9a6a142', 'insignificant'), 
('d7bda924-0e8e-4edc-9ef4-95dab3c0a3a3', 'minor'),
('3bf9a1d2-f2df-47e1-a563-2c29d80be511', 'significant'),
('5c1599b9-6fc9-4c6f-becf-18a6b09d6b8a', 'major'),
('f69304cf-4552-42f1-a20a-ba122e21bb60', 'severe');

INSERT INTO tbl_priorities (id, name, active) VALUES 
('292a2f92-8137-4b17-8c7b-fd6b8577f60c', 'Lowest', 1),
('e8947edc-6f28-4f87-b6ec-23f22a3e9b3e', 'Low', 1),
('2b2c56e7-48c6-455d-9c60-8b1b786d3e44', 'Medium', 1),
('79c484be-b38b-4e4f-ba0e-857ee5f99ad4', 'High', 1),
('5eb5ed2d-1c2a-4e2d-89cf-0d5f3c09140a', 'Highest', 1);


















