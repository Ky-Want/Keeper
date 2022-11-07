-- Active: 1666715750209@@SG-Zero-6848-mysql-master.servers.mongodirector.com@3306@ShiniesCollection

CREATE TABLE
    IF NOT EXISTS accounts(
        -- accounts have a string because it uses the id that is returned from auth0 
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        -- 
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture',
        coverImg VARCHAR(255) COMMENT 'User Cover Image'
    ) default charset utf8 COMMENT '';

--

--

--

CREATE TABLE
    IF NOT EXISTS vaults(
        id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        -- 
        name VARCHAR(255) NOT NULL,
        img VARCHAR(255) NOT NULL,
        description VARCHAR(255),
        isPrivate TINYINT DEFAULT 0,
        -- 
        creatorId VARCHAR(255) NOT NULL,
        -- 
        FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

--

--

--

CREATE TABLE
    IF NOT EXISTS keeps(
        -- use int for all ID's, and auto_increment for our database to handle counting 1,2,3,..
        id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        -- 
        name VARCHAR(255) NOT NULL,
        img VARCHAR(300) NOT NULL,
        description VARCHAR(500) NOT NULL,
        -- 
        views int NOT NULL,
        kept int NOT NULL,
        --
        creatorId VARCHAR(255) NOT NULL,
        -- 
        FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
    ) default charset utf8 COMMENT '';

--

--

--

CREATE TABLE
    IF NOT EXISTS vaultKeeps(
        id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        -- 
        creatorId VARCHAR(255) NOT NULL,
        vaultId int NOT NULL,
        keepId int NOT NULL,
        -- 
        FOREIGN KEY (creatorId) REFERENCES accounts(id),
        FOREIGN KEY (vaultId) REFERENCES vaults(id)
    ) default charset utf8 COMMENT '';