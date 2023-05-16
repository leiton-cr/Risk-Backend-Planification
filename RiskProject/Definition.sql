
CREATE TABLE tbl_users(
	id VARCHAR(36) PRIMARY KEY,
	email VARCHAR(50) UNIQUE NOT NULL,
	pepper VARCHAR(48) NOT NULL,
	salt INT NOT NULL,
	pass VARCHAR(50) DEFAULT 1 NOT NULL,
	active BIT DEFAULT 1
);


CREATE TABLE tbl_tasks(
	id VARCHAR(36) PRIMARY KEY,
	name VARCHAR(50) UNIQUE NOT NULL,
	active BIT DEFAULT 1
);


CREATE TABLE tbl_projects(
	id VARCHAR(36) PRIMARY KEY,
	name VARCHAR(50) UNIQUE NOT NULL,
	active BIT DEFAULT 1
);

CREATE TABLE tbl_probabilities(
	id VARCHAR(36) PRIMARY KEY,
	name VARCHAR(15) UNIQUE NOT NULL,
	active BIT DEFAULT 1
);

CREATE TABLE tbl_impacts(
	id VARCHAR(36) PRIMARY KEY,
	name VARCHAR(15) UNIQUE NOT NULL,
	active BIT DEFAULT 1
);

CREATE TABLE tbl_priorities(
	id VARCHAR(36) PRIMARY KEY,
	name VARCHAR(15) UNIQUE NOT NULL,
	active BIT DEFAULT 1
);

CREATE TABLE tbl_registers(
	id VARCHAR(36),
	project_id VARCHAR(36),
	task_id VARCHAR(36),
	probability_id VARCHAR(36),
	impact_id VARCHAR(36),
	priority_id VARCHAR(36),
	active BIT DEFAULT 1,
	created_at DATE DEFAULT CURRENT_TIMESTAMP,
	updated_at DATE,
	created_by  VARCHAR(36),
	updated_by  VARCHAR(36),
	
	CONSTRAINT FK_registers_projects FOREIGN KEY (project_id) REFERENCES tbl_projects(id),
    CONSTRAINT FK_registers_tasks FOREIGN KEY (task_id) REFERENCES tbl_tasks(id),
    CONSTRAINT FK_registers_probabilities FOREIGN KEY (probability_id) REFERENCES tbl_probabilities(id),
    CONSTRAINT FK_registers_impacts FOREIGN KEY (impact_id) REFERENCES tbl_impacts(id),
    CONSTRAINT FK_registers_priorties FOREIGN KEY (priority_id) REFERENCES tbl_priorities(id),
    CONSTRAINT FK_registers_created_by FOREIGN KEY (created_by) REFERENCES tbl_users(id),
    CONSTRAINT FK_registers_updated_by FOREIGN KEY (updated_by) REFERENCES tbl_users(id)
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















