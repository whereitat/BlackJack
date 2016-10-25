--BLACKJACK PROJECT, T5 ADVANCED DATABASE SYSTEMS

--DROP TABLES--
DROP TABLE GameRound
DROP TABLE BlackjackGame
DROP TABLE Deck
DROP TABLE Account


--CREATE TABLES-
CREATE TABLE Account (
accountId INTEGER IDENTITY(0,1) NOT NULL,
aname VARCHAR(20) NOT NULL,
astatus VARCHAR(20) NOT NULL,
balance FLOAT NOT NULL,
PRIMARY KEY (AccountId));

CREATE TABLE Deck (
cardId VARCHAR(20) NOT NULL,
value INTEGER NOT NULL,
PRIMARY KEY (cardId));

CREATE TABLE BlackjackGame (
sessionId INTEGER IDENTITY(200,1) NOT NULL,
minBet FLOAT NOT NULL,
maxBet FLOAT NOT NULL,
gstatus VARCHAR(20) NOT NULL,
PRIMARY KEY(sessionId),
);

CREATE TABLE GameRound (
gameId INTEGER IDENTITY(1000,1) NOT NULL,
bet FLOAT NOT NULL,
result FLOAT NOT NULL,
gdate DATETIME NOT NULL,
accountId INTEGER NOT NULL,
sessionId INTEGER NOT NULL,
PRIMARY KEY (gameId),
FOREIGN KEY (accountId) REFERENCES Account
ON DELETE CASCADE,
FOREIGN KEY (sessionId) REFERENCES BlackjackGame
ON DELETE CASCADE);

--INSERT VALUES--
INSERT INTO Account VALUES ('BANK', 'BANK', 1000000.00);
INSERT INTO Account VALUES ('Mattias West', 'VIP', 10000.00);
INSERT INTO Account VALUES ('Johan Csirmaz', 'VIP', 10000.00);
INSERT INTO Account VALUES ('Gustav Hedin', 'STANDARD', 10000.00);
INSERT INTO Account VALUES ('Erik Hallkvist', 'STANDARD', 10000.00);

INSERT INTO Deck VALUES ('D.A', 11);
INSERT INTO Deck VALUES ('D.2', 2);
INSERT INTO Deck VALUES ('D.3', 3);
INSERT INTO Deck VALUES ('D.4', 4);
INSERT INTO Deck VALUES ('D.5', 5);
INSERT INTO Deck VALUES ('D.6', 6);
INSERT INTO Deck VALUES ('D.7', 7);
INSERT INTO Deck VALUES ('D.8', 8);
INSERT INTO Deck VALUES ('D.9', 9);
INSERT INTO Deck VALUES ('D.10', 10);
INSERT INTO Deck VALUES ('D.J', 10);
INSERT INTO Deck VALUES ('D.Q', 10);
INSERT INTO Deck VALUES ('D.K', 10);

INSERT INTO Deck VALUES ('H.A', 11);
INSERT INTO Deck VALUES ('H.2', 2);
INSERT INTO Deck VALUES ('H.3', 3);
INSERT INTO Deck VALUES ('H.4', 4);
INSERT INTO Deck VALUES ('H.5', 5);
INSERT INTO Deck VALUES ('H.6', 6);
INSERT INTO Deck VALUES ('H.7', 7);
INSERT INTO Deck VALUES ('H.8', 8);
INSERT INTO Deck VALUES ('H.9', 9);
INSERT INTO Deck VALUES ('H.10', 10);
INSERT INTO Deck VALUES ('H.J', 10);
INSERT INTO Deck VALUES ('H.Q', 10);
INSERT INTO Deck VALUES ('H.K', 10);

INSERT INTO Deck VALUES ('C.A', 11);
INSERT INTO Deck VALUES ('C.2', 2);
INSERT INTO Deck VALUES ('C.3', 3);
INSERT INTO Deck VALUES ('C.4', 4);
INSERT INTO Deck VALUES ('C.5', 5);
INSERT INTO Deck VALUES ('C.6', 6);
INSERT INTO Deck VALUES ('C.7', 7);
INSERT INTO Deck VALUES ('C.8', 8);
INSERT INTO Deck VALUES ('C.9', 9);
INSERT INTO Deck VALUES ('C.10', 10);
INSERT INTO Deck VALUES ('C.J', 10);
INSERT INTO Deck VALUES ('C.Q', 10);
INSERT INTO Deck VALUES ('C.K', 10);

INSERT INTO Deck VALUES ('S.A', 11);
INSERT INTO Deck VALUES ('S.2', 2);
INSERT INTO Deck VALUES ('S.3', 3);
INSERT INTO Deck VALUES ('S.4', 4);
INSERT INTO Deck VALUES ('S.5', 5);
INSERT INTO Deck VALUES ('S.6', 6);
INSERT INTO Deck VALUES ('S.7', 7);
INSERT INTO Deck VALUES ('S.8', 8);
INSERT INTO Deck VALUES ('S.9', 9);
INSERT INTO Deck VALUES ('S.10', 10);
INSERT INTO Deck VALUES ('S.J', 10);
INSERT INTO Deck VALUES ('S.Q', 10);
INSERT INTO Deck VALUES ('S.K', 10);

INSERT INTO BlackjackGame VALUES (100.00, 200.00, 'OPEN');
INSERT INTO BlackjackGame VALUES (200.00, 400.00, 'OPEN');
INSERT INTO BlackjackGame VALUES (600.00, 1200.00, 'VIP');

INSERT INTO GameRound VALUES (100.00, 200.00, GETDATE(), 1, 200);
INSERT INTO GameRound VALUES (100.00, -100.00, GETDATE(), 1, 200);
INSERT INTO GameRound VALUES (100.00, 250.00, GETDATE(), 1, 200);
INSERT INTO GameRound VALUES (100.00, -100.00, GETDATE(), 1, 200);