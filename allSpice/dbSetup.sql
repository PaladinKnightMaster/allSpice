-- Active: 1666715466993@@SG-berry-server-8496-6844-mysql-master.servers.mongodirector.com@3306@SqlDb

CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture'
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS recipes(
        id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        title VARCHAR(255) NOT NULL,
        instructions VARCHAR(255) NOT NULL,
        img VARCHAR(255) NOT NULL DEFAULT "https://img.freepik.com/premium-photo/mediterranean-food-cooking-background-fresh-tomatoes-basil-olive-oil-garlic-light-green-background_136595-18609.jpg?w=2000",
        category VARCHAR(255) NOT NULL,
        creatorId VARCHAR(255) NOT NULL,
        Foreign Key (creatorId) REFERENCES accounts(id)
    ) default charset utf8 COMMENT '';

CREATE TABLE
    IF NOT EXISTS ingredients(
        id INT NOT NULL primary key AUTO_INCREMENT,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name VARCHAR(255) NOT NULL,
        quantity VARCHAR(255) NOT NULL,
        recipeId int NOT NULL,
        Foreign Key (recipeId) REFERENCES recipes(id)
    ) default charset utf8 COMMENT '';

create table
    if not exists favorites (
        id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        recipeId int NOT NULL,
        accountId VARCHAR(255) NOT NULL,
        Foreign Key (recipeId) REFERENCES recipes(id),
        Foreign Key (accountId) REFERENCES accounts(id)
    ) default charset utf8 COMMENT '';

select r.*, ac.*
from recipes r
    join accounts ac on ac.id = r.creatorId;

select i.* from ingredients i where recipeId = 42 ;

select i.* from ingredients i where i.id = 3 ;

DELETE FROM favorites;

-- DELETE FROM recipes;

-- DELETE FROM ingredients