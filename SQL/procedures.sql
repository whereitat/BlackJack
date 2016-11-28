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
		DECLARE @ERRORMESSAGE NVARCHAR(4000);
		DECLARE @ERRORSEVERITY INT;
		DECLARE @ERRORSTATE INT;

		SELECT 
		@ERRORMESSAGE = ERROR_MESSAGE(),
		@ERRORSEVERITY = ERROR_SEVERITY(),
		@ERRORSTATE = ERROR_STATE();
		
		RAISERROR(@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE)
END CATCH
END

-- ADD USER

CREATE PROCEDURE [dbo].[ADDUSER] @USERNAME VARCHAR(20), @PASSWORD VARCHAR(128)
AS
BEGIN
	BEGIN TRY
		DECLARE @BALANCE FLOAT
		DECLARE @USERSTATUS VARCHAR(20)

		SET @BALANCE = 0
		SET @USERSTATUS = 'STANDARD'
		INSERT INTO account
		VALUES (@USERNAME, @USERSTATUS, @BALANCE, @PASSWORD)
	END TRY

	BEGIN CATCH
		DECLARE @ERRORMESSAGE NVARCHAR(4000);
		DECLARE @ERRORSEVERITY INT;
		DECLARE @ERRORSTATE INT;

		SELECT 
		@ERRORMESSAGE = ERROR_MESSAGE(),
		@ERRORSEVERITY = ERROR_SEVERITY(),
		@ERRORSTATE = ERROR_STATE();
		
		RAISERROR(@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE)
	END CATCH
END

-- DELETE USER
CREATE PROCEDURE [dbo].[DELETEUSER] @USERNAME VARCHAR(20), @PASSWORD VARCHAR (128)
AS
BEGIN
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

		ELSE
		BEGIN
			SET @ERRORMESSAGE = 'DELETEUSER ERROR, NO USER FOUND'
			RAISERROR(@ERRORMESSAGE, 16, 1)
		END
	END TRY

	BEGIN CATCH
		DECLARE @ERRORSEVERITY INT;
		DECLARE @ERRORSTATE INT;

		SELECT 
		@ERRORMESSAGE = ERROR_MESSAGE(),
		@ERRORSEVERITY = ERROR_SEVERITY(),
		@ERRORSTATE = ERROR_STATE();
		
		RAISERROR(@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE)
	END CATCH
END

-- GET USER

CREATE PROCEDURE [dbo].[GETUSER] @USERNAME VARCHAR(20), @PASSWORD VARCHAR(128)
AS
BEGIN
	DECLARE @NAME VARCHAR(20)
	DECLARE @PSW VARCHAR(128)
	DECLARE @ERRORMESSAGE NVARCHAR(4000);
	BEGIN TRY
 
		SELECT @NAME = aname, @PSW = [password]
		FROM account
		WHERE aname = @USERNAME
		AND [password] = @PASSWORD

		IF (@USERNAME IS NOT NULL AND @PASSWORD IS NOT NULL AND @NAME IS NOT NULL AND @PSW IS NOT NULL)
		BEGIN
			SELECT aname, astatus, balance, [password]
			FROM account
			WHERE aname = @USERNAME
		END

		ELSE
		BEGIN
			SET @ERRORMESSAGE = 'GETUSER ERROR, USER NOT FOUND'
			RAISERROR(@ERRORMESSAGE, 16, 1)
		END
	END TRY

	BEGIN CATCH
		DECLARE @ERRORSEVERITY INT;
		DECLARE @ERRORSTATE INT;

		SELECT 
		@ERRORMESSAGE = ERROR_MESSAGE(),
		@ERRORSEVERITY = ERROR_SEVERITY(),
		@ERRORSTATE = ERROR_STATE();
		
		RAISERROR(@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE)
	END CATCH
END

-- WITHDRAW FUNDS FROM ACCOUNT

CREATE PROCEDURE [dbo].[WITHDRAWFUNDS] @USERNAME VARCHAR(20), @AMOUNT FLOAT
AS

SET NOCOUNT ON
DECLARE @ERRORMESSAGE VARCHAR(4000)
DECLARE @BALANCE FLOAT
DECLARE @NAME VARCHAR(20)

BEGIN TRY

	BEGIN TRANSACTION

		SELECT @BALANCE = balance
		FROM account
		WHERE aname = @USERNAME

		IF (@BALANCE >= @AMOUNT AND @AMOUNT > 0)
		BEGIN

			SET @BALANCE = @BALANCE - @AMOUNT

			UPDATE account
			SET balance = @BALANCE
			WHERE aname = @USERNAME
			COMMIT
		END

		ELSE IF (@AMOUNT > @BALANCE)
			BEGIN
			SET @ERRORMESSAGE = 'WITHDRAWFUNDS ERROR, INSUFFICIENT FUNDS'
			RAISERROR(@ERRORMESSAGE, 16, 1)
		END

		ELSE 
		BEGIN
			SET @ERRORMESSAGE = 'WITHDRAWFUNDS ERROR, INVALID INPUT'
			RAISERROR(@ERRORMESSAGE, 16, 1)
		END
	END TRY

	BEGIN CATCH
		ROLLBACK
		DECLARE @ERRORSEVERITY INT;
		DECLARE @ERRORSTATE INT;

		SELECT 
		@ERRORMESSAGE = ERROR_MESSAGE(),
		@ERRORSEVERITY = ERROR_SEVERITY(),
		@ERRORSTATE = ERROR_STATE();

		RAISERROR(@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE)
	END CATCH

-- DEPOSIT FUNDS TO ACCOUNT

CREATE PROCEDURE [dbo].[DEPOSITFUNDS] @USERNAME VARCHAR(20), @AMOUNT FLOAT
AS
BEGIN
	BEGIN TRY
		BEGIN TRANSACTION
		DECLARE @ERRORMESSAGE VARCHAR(4000)
		DECLARE @BALANCE FLOAT
		DECLARE @NAME VARCHAR(20)

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
			COMMIT
		END

		ELSE
		BEGIN
			SET @ERRORMESSAGE = 'DEPOSITFUNDS ERROR, INVALID INPUT'
			RAISERROR(@ERRORMESSAGE, 16, 1)
		END
	END TRY

	BEGIN CATCH
		ROLLBACK
		DECLARE @ERRORSEVERITY INT;
		DECLARE @ERRORSTATE INT;

		SELECT 
		@ERRORMESSAGE = ERROR_MESSAGE(),
		@ERRORSEVERITY = ERROR_SEVERITY(),
		@ERRORSTATE = ERROR_STATE();

		RAISERROR(@ERRORMESSAGE, @ERRORSEVERITY, @ERRORSTATE)

	END CATCH
END

-- TRANSACTION

CREATE PROCEDURE [dbo].[GAMETRANSACTION] @USERNAME VARCHAR(20) = NULL, @GAMEID INTEGER = NULL
AS
BEGIN
BEGIN TRANSACTION
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


----- GETMINBET

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

CREATE PROCEDURE [dbo].[CREATEGAMEROUND] @BET INT = NULL, @RESULT INT = NULL, @USERNAME VARCHAR(20) = NULL, @SESSIONID INT = NULL
AS
BEGIN
DECLARE @ERRORMESSAGE VARCHAR (4000)
DECLARE @GAMEID INT
DECLARE @DATE DATETIME
SET @DATE = GETDATE()
BEGIN TRY
INSERT INTO gameround
VALUES (@BET, @RESULT, @DATE, @USERNAME, @SESSIONID)

SELECT gameid
FROM gameround
WHERE gdate = @DATE

IF (@BET IS NULL OR @RESULT IS NULL OR @USERNAME IS NULL OR @SESSIONID IS NULL)
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

BEGIN TRY
SELECT *
FROM BlackjackGame
END TRY

BEGIN CATCH
SELECT ERROR_NUMBER() AS 'ERROR'
END CATCH
END



--------------------------------------------
