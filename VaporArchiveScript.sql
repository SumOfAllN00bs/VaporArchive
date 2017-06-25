Use [VaporArchive.ArchiveDatabaseContext]
--create sysadmin
INSERT INTO Accounts
--		UserName   	 AccountCreated				PasswordHash salted with Precomputed byte array from seed AccountCreated.day for password vS4n7YQ3eh8vnpAH
VALUES ('sysadmin', '2017-06-25 21:52:52.280', 'DC8YLUdMVKnjFHBS4mZuL9XRvBiqIOu94Ta45IO85Xs=' );
--create Submitters

--create Customers

--create Games

--Queries per table
select * from Games
select * from GameCustomerAccounts
select * from Submitters
select * from Customers
select * from Accounts
--remove all rows
DELETE FROM Games
DELETE FROM Customers
DELETE FROM Submitters
DELETE FROM Accounts
--DELETE FROM GameCustomerAccounts
--reset identity
DBCC CHECKIDENT ('[Accounts]', RESEED, 0);