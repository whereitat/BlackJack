-- ACCOUNT STATUS CHECK

CREATE TRIGGER [dbo].[STATUSCHECK]
ON account
AFTER UPDATE
AS
BEGIN
BEGIN TRANSACTION
DECLARE @BALANCE FLOAT
DECLARE @USERNAME VARCHAR(20)

SELECT @USERNAME = aname
FROM inserted
WHERE astatus NOT LIKE 'BANK'

SELECT @BALANCE = balance
FROM account 
WHERE aname = @USERNAME

IF (@BALANCE >= 50000)
BEGIN
UPDATE account
SET astatus = 'VIP'
WHERE aname = @USERNAME
END

ELSE IF (@BALANCE < 50000)
BEGIN
UPDATE account
SET astatus = 'STANDARD'
WHERE aname = @USERNAME
END
COMMIT
END


 -- BANK BALANCE TRIGGER

CREATE TRIGGER [dbo].[BANKBALANCECHECK]
ON account
AFTER UPDATE
AS
BEGIN
BEGIN TRANSACTION
DECLARE @BALANCE FLOAT

SELECT @BALANCE = balance
FROM account
WHERE aname = 'BANK'

IF (@BALANCE < 100000)
BEGIN
UPDATE account
SET balance = 1000000
WHERE aname = 'BANK'
END
COMMIT
END

-------------------------------------------------------------
