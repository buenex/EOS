CREATE DATABASE EOSDatabase

USE EOSDatabase

CREATE TABLE Jogador(
	id INT PRIMARY KEY IDENTITY(0,1),
	nome VARCHAR(50) not null,
	sobrenome VARCHAR(50) not null,
	email VARCHAR(80) not null,
	login VARCHAR(15)not null,
	senha VARCHAR(30) not null,
	
)

CREATE TABLE Location(
	id INT PRIMARY KEY,
	posX FLOAT,
	poxy FLOAT,
	posZ FLOAT,
	rotX FLOAT,
	rotY FLOAT,
	rotZ FLOAT,
	CONSTRAINT FK_Jogador FOREIGN KEY(id) REFERENCES Jogador(id)
)

CREATE TABLE Inventory(
	id INT PRIMARY KEY,
	slot1 INT,
	slot2 INT,
	slot3 INT,
	slot4 INT,
	slot5 INT,
	slot6 INT,
	flashLight FLOAT,
	CONSTRAINT FK_JogadorInventory FOREIGN KEY (id) REFERENCES JOGADOR(id)
)

