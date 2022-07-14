CREATE TABLE TbUser(
	Id INT IDENTITY(1,1),
	Name VARCHAR(40) NOT NULL,
	Email VARCHAR(100) NOT NULL UNIQUE,
	Password VARCHAR(32) NOT NULL
);

SELECT * 
	FROM TbUser;

INSERT INTO TbUser 
	VALUES('Admin', 'Admin', 'admin1234'); 

USE ToDoList

INSERT INTO TbUser 
	VALUES('Lucas', 'lucas@hotmail.com', 'A3242938@dfsadf'); 

ALTER TABLE TbUser
	ADD CONSTRAINT PK_User 
	PRIMARY KEY(Id);


SELECT * FROM TbUser
	WHERE Id = 1

SELECT * FROM TbUser
	WHERE Password = 'admin1234'

UPDATE TbUser 
	SET Email = 'Admin@hotmail.com'
	WHERE id = 1;

UPDATE TbUser 
	SET Password = 'admin1234' 
	WHERE id = 1;

SELECT * 
	FROM TbUser

CREATE TABLE TbCard(
	Id INT IDENTITY,
	Title VARCHAR(500),
	Description VARCHAR(4000),
	DateTime Date,
	UserId INT
);

ALTER TABLE TbCard
	ADD CONSTRAINT Pk_Card 
	PRIMARY KEY (Id);

ALTER TABLE TbCard
	ADD CONSTRAINT FK_TbUser_TbCard 
		FOREIGN KEY (UserId) 
		REFERENCES TbUser ;

SELECT * 
	FROM TbCard

SELECT Title, Description, DateTime
	FROM TbCard Where IdUser = 1 Order by DateTime

INSERT INTO TbCard 
	VALUES('Cinema' ,'Wathing jurassic park dominion', GETDATE(), 1)

INSERT INTO TbCard (Title,IdUser) 
	VALUES('What Jurassic World Dominion in the Cinema', 1)



SELECT Title, Description, DateTime FROM TbCard Where IdUser = 1

INSERT INTO TbCard (title,DateTime,IdUser) 
	VALUES('Verify Email','2022-05-02', 1) Order by 


DROP TABLE TbCard
DROP TABLE TbuSER

SELECT FROM TbCard Where IdUser = 1 Order by DateTime

SELECT * FROM TbCard


SELECT * FROM TbCard Where UserId = 1 Order by DateTime