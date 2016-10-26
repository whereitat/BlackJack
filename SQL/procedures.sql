-- SHUFFLE
CREATE PROCEDURE [dbo].[SHUFFLECARDS]
AS
SET NOCOUNT ON
BEGIN
BEGIN TRY
SELECT ROW_NUMBER() OVER (ORDER BY NEWID()) as [Index], * 
FROM deck
END TRY

BEGIN CATCH
SELECT ERROR_NUMBER() AS 'ERROR'
END CATCH
END

-- ADD USER

CREATE PROCEDURE [dbo].[ADDUSER] @USERNAME VARCHAR(20), @PASSWORD VARCHAR(128)
AS
BEGIN
SET NOCOUNT ON
BEGIN TRY
DECLARE @BALANCE FLOAT
DECLARE @USERSTATUS VARCHAR(20)

SET @BALANCE = 0
SET @USERSTATUS = 'STANDARD'
INSERT INTO account
VALUES (@USERNAME, @USERSTATUS, @BALANCE, @PASSWORD)
END TRY

BEGIN CATCH
SELECT ERROR_NUMBER() AS 'ERROR'
END CATCH
END

-- DELETE USER

CREATE PROCEDURE [dbo].[DELETEUSER] @USERNAME VARCHAR(20), @PASSWORD VARCHAR (128)
AS
BEGIN
SET NOCOUNT ON
DECLARE @ERRORMESSAGE VARCHAR(4000)
DECLARE @NAME VARCHAR(20)
DECLARE @PSW VARCHAR(128)

BEGIN TRY

SELECT @NAME = aname, @PSW = [password]
FROM account
WHERE aname = @USERNAME
AND [password] = @PASSWORD

IF(@USERNAME IS NOT NULL AND @PASSWORD IS NOT NULL AND @NAME IS NOT NULL AND @PSW IS NOT NULL)
BEGIN
DELETE FROM account
WHERE aname = @USERNAME
AND [password] = @PASSWORD
END

ELSE IF (@USERNAME IS NULL OR @PASSWORD IS NULL OR @NAME IS NULL OR @PSW IS NULL)
BEGIN
SET @ERRORMESSAGE = 'NO USER FOUND'
RAISERROR(@ERRORMESSAGE, 16, 1)
END
END TRY

BEGIN CATCH
SELECT ERROR_MESSAGE() AS 'ERROR'
END CATCH
END

-- READ USER

CREATE PROCEDURE [dbo].[GETUSER] @USERNAME VARCHAR(20)
AS
BEGIN
SET NOCOUNT ON
DECLARE @ERRORMESSAGE VARCHAR(4000)
DECLARE @NAME VARCHAR(20)

BEGIN TRY
 
SELECT @NAME = aname
FROM account
WHERE aname = @USERNAME

IF (@USERNAME IS NOT NULL AND @NAME IS NOT NULL)
BEGIN
SELECT aname, astatus, balance
FROM account
WHERE aname = @USERNAME
END

ELSE IF (@USERNAME IS NULL OR @NAME IS NULL)
BEGIN
SET @ERRORMESSAGE = 'NO USER FOUND'
RAISERROR(@ERRORMESSAGE, 16, 1)
END
END TRY

BEGIN CATCH
SELECT ERROR_MESSAGE() AS 'ERROR'
END CATCH
END


-- WITHDRAW FUNDS FROM ACCOUNT

CREATE PROCEDURE [dbo].[WITHDRAWFUNDS] @USERNAME VARCHAR(20), @AMOUNT FLOAT
AS
BEGIN
BEGIN TRANSACTION
SET NOCOUNT ON
DECLARE @ERRORMESSAGE VARCHAR(4000)
DECLARE @BALANCE FLOAT
DECLARE @NAME VARCHAR(20)

BEGIN TRY
SELECT @BALANCE = balance
FROM account
WHERE aname = @USERNAME

IF (@BALANCE >= @AMOUNT AND @AMOUNT > 0)
BEGIN
SET @BALANCE = @BALANCE - @AMOUNT
UPDATE account
SET balance = @BALANCE
WHERE aname = @USERNAME

SELECT aname, astatus, balance
FROM account
WHERE aname = @USERNAME

SELECT @NAME = aname
FROM account
WHERE aname = @USERNAME
COMMIT
END

ELSE IF (@AMOUNT > @BALANCE)
BEGIN
SET @ERRORMESSAGE = 'INSUFFICIENT FUNDS'
RAISERROR(@ERRORMESSAGE, 16, 1)
END

ELSE IF (@USERNAME IS NULL OR @AMOUNT <= 0 OR @AMOUNT IS NULL OR @NAME IS NULL)
BEGIN
SET @ERRORMESSAGE = 'INVALID INPUT'
RAISERROR(@ERRORMESSAGE, 16, 1)
END
END TRY

BEGIN CATCH
SELECT ERROR_MESSAGE() AS 'ERROR'
ROLLBACK
END CATCH
END

-- DEPOSIT FUNDS TO ACCOUNT

CREATE PROCEDURE [dbo].[DEPOSITFUNDS] @USERNAME VARCHAR(20), @AMOUNT FLOAT
AS
BEGIN
BEGIN TRANSACTION
SET NOCOUNT ON
DECLARE @ERRORMESSAGE VARCHAR(4000)
DECLARE @BALANCE FLOAT
DECLARE @NAME VARCHAR(20)

BEGIN TRY

SELECT @NAME = aname
FROM account
WHERE aname = @USERNAME

IF (@USERNAME IS NOT NULL AND @NAME IS NOT NULL AND @AMOUNT IS NOT NULL AND @AMOUNT > 0)
BEGIN
SELECT @BALANCE = balance
FROM account
WHERE aname = @USERNAME

SET @BALANCE = @BALANCE + @AMOUNT

UPDATE account
SET balance = @BALANCE
WHERE aname = @USERNAME

SELECT aname, astatus, balance
FROM account
WHERE aname = @USERNAME
COMMIT
END

ELSE IF (@AMOUNT IS NULL OR @AMOUNT <= 0 OR @USERNAME IS NULL OR @NAME IS NULL)
BEGIN
SET @ERRORMESSAGE = 'INVALID INPUT'
RAISERROR(@ERRORMESSAGE, 16, 1)
END
END TRY

BEGIN CATCH
ROLLBACK
SELECT ERROR_MESSAGE() AS 'ERROR'
END CATCH
END

-- TRANSACTION

CREATE PROCEDURE [dbo].[GAMETRANSACTION] @USERNAME VARCHAR(20) = NULL, @GAMEID INTEGER = NULL
AS
BEGIN
BEGIN TRANSACTION
SET NOCOUNT ON
DECLARE @BALANCE FLOAT
DECLARE @TRANSACTIONAMOUNT FLOAT

BEGIN TRY
SELECT @BALANCE = balance
FROM account
WHERE aname = @USERNAME

SELECT @TRANSACTIONAMOUNT = result
FROM gameround
WHERE aname = @USERNAME AND gameid = @GAMEID

SET @BALANCE = @BALANCE + @TRANSACTIONAMOUNT
 
UPDATE account
SET balance = @BALANCE
WHERE aname = @USERNAME

SELECT @BALANCE = balance
FROM account
WHERE aname = 'BANK'

SELECT @TRANSACTIONAMOUNT = result
FROM gameround
WHERE aname = @USERNAME AND gameid = @GAMEID

SET @BALANCE = @BALANCE - @TRANSACTIONAMOUNT

UPDATE account
SET balance = @BALANCE
WHERE aname = 'BANK'
COMMIT
END TRY

BEGIN CATCH
ROLLBACK
SELECT ERROR_NUMBER() AS 'ERROR'
END CATCH
END

----- GETMAXBET

CREATE PROCEDURE [dbo].[GETMAXBET] @SESSIONID INT = NULL
AS
BEGIN
DECLARE @ERRORMESSAGE VARCHAR(4000)
BEGIN TRY
DECLARE @MAXBET INT
SELECT @MAXBET = maxbet
FROM BlackjackGame
WHERE sessionid = @SESSIONID

IF (@MAXBET IS NULL)
BEGIN
SET @ERRORMESSAGE = 'SESSIONID DOES NOT EXIST'
RAISERROR(@ERRORMESSAGE, 16, 1)
END

SELECT @MAXBET AS 'MAX BET'
END TRY

BEGIN CATCH
SELECT @ERRORMESSAGE AS 'ERROR'
END CATCH
END


...... GETMINBET

CREATE PROCEDURE [dbo].[GETMINBET] @SESSIONID INT = NULL
AS
BEGIN
DECLARE @ERRORMESSAGE VARCHAR(4000)
BEGIN TRY
DECLARE @MINBET INT
SELECT @MINBET = minbet 
FROM BlackjackGame
WHERE sessionid = @SESSIONID

IF (@MINBET IS NULL)
BEGIN
SET @ERRORMESSAGE = 'SESSIONID DOES NOT EXIST'
RAISERROR(@ERRORMESSAGE, 16, 1)
END

SELECT @MINBET AS 'MIN BET'
END TRY

BEGIN CATCH
SELECT @ERRORMESSAGE AS 'ERROR'
END CATCH
END


----- CREATEGAMEROUND

CREATE PROCEDURE [dbo].[CREATEGAMEROUND] @BET INT = NULL, @RESULT INT = NULL, @ACCOUNTNAME VARCHAR(20) = NULL, @SESSIONID INT = NULL
AS
BEGIN
DECLARE @ERRORMESSAGE VARCHAR (4000)
BEGIN TRY
INSERT INTO gameround
VALUES (@BET, @RESULT, GETDATE(), @ACCOUNTNAME, @SESSIONID)

IF (@BET IS NULL OR @RESULT IS NULL OR @ACCOUNTNAME IS NULL OR @SESSIONID IS NULL)
BEGIN
RAISERROR(@ERRORMESSAGE, 16, 1)
END
END TRY

BEGIN CATCH
SELECT ERROR_NUMBER() AS 'ERROR'
END CATCH
END


------- GETBLACKJACKGAME

CREATE PROCEDURE [dbo].[GETBLACKJACKGAME]
AS
BEGIN
SET NOCOUNT ON

BEGIN TRY
SELECT *
FROM BlackjackGame
END TRY

BEGIN CATCH
SELECT ERROR_NUMBER() AS 'ERROR'
END CATCH
END



--------------------------------------------
