CREATE DATABASE QLDaiHoc
USE QLDaiHoc
CREATE TABLE User_Account(
	UserID			VARCHAR(10) NOT NULL PRIMARY KEY,  
	UserName		VARCHAR(20),
	Password		VARCHAR(20),
	Position		VARCHAR(50),
	--tao rang buoc duy nhat
	CONSTRAINT UNI_User_Account
        UNIQUE (UserID),
	--Check constraint
	CONSTRAINT CHECK_User
		CHECK (UserName LIKE '%[^?<>_-@!#$%&*()]%'),
);
CREATE TABLE Category_Course(
	CategoryID		VARCHAR(10) NOT NULL PRIMARY KEY,
	Category_Name	VARCHAR(50) NOT NULL,
	Description		VARCHAR(255),
	--tao rang buoc duy nhat
	CONSTRAINT UNI_Category_Course
        UNIQUE (CategoryID),
);
CREATE TABLE Course(
	CourseID		VARCHAR(20) NOT NULL PRIMARY KEY,
	Course_Name		VARCHAR(50) NOT NULL,
	Description		VARCHAR(255),
	CategoryID		VARCHAR(10) NOT NULL,
	UserID			VARCHAR(10) NOT NULL,
	--tao rang buoc duy nhat
	CONSTRAINT UNI_Course
        UNIQUE (CourseID),
	--tao khoa ngoai
	CONSTRAINT FK_CateId 
		FOREIGN KEY (CategoryID)
		REFERENCES  Category_Course(CategoryID),
	CONSTRAINT FK_UserId 
		FOREIGN KEY (UserID)
		REFERENCES  User_Account(UserID),
);
CREATE TABLE Topic(
	TopicID			VARCHAR(10) NOT NULL PRIMARY KEY, 
	Topic_Name		VARCHAR(20) NOT NULL,
	Description		VARCHAR(255),
	CourseID		VARCHAR(20) NOT NULL,
	UserID			VARCHAR(10) NOT NULL,
	--tao rang buoc duy nhat
	CONSTRAINT UNI_Topic
        UNIQUE (TopicID),
	--tao khoa ngoai
	CONSTRAINT FK_CourId 
		FOREIGN KEY (CourseID)
		REFERENCES  Course(CourseID),
	CONSTRAINT FK_User 
		FOREIGN KEY (UserID)
		REFERENCES  User_Account(UserID),
);

CREATE TABLE Profile_User(
	UserID			VARCHAR(10) NOT NULL,
	Full_Name		VARCHAR(50) NOT NULL,
	Address			VARCHAR(50) NOT NULL,
	Phone			CHAR(10)	NOT NULL,
	DateOfBirth		DATE,
	--tao rang buoc duy nhat
	CONSTRAINT PK_Pro_User
		PRIMARY KEY (UserID,Full_Name),
	--tao rang buoc
	CONSTRAINT CHECK_Date
		CHECK (DateOfBirth < DATEADD(YEAR , -18 , GETDATE())),
	CONSTRAINT CHECK_Phone
		CHECK (Phone NOT LIKE '%[^0-9]%'),
	--tao khao ngoai
	CONSTRAINT FK_user_id  
		FOREIGN KEY (UserID)
		REFERENCES  User_Account(UserID),
);



