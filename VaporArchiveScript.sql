Use [VaporArchive.ArchiveDatabaseContext]

--Queries per table
select * from Games
select * from GameCustomerAccounts
select * from Submitters
select * from Customers
select * from Accounts

----------reset for testing-----------------
--remove all rows
--DELETE FROM Games
--DELETE FROM Customers
--DELETE FROM Submitters
--DELETE FROM Accounts
--DELETE FROM GameCustomerAccounts
--reset identity
--DBCC CHECKIDENT ('[Accounts]', RESEED, 0);
--create sysadmin
--INSERT INTO Accounts
--		   UserName   	 AccountCreated				PasswordHash salted with Precomputed byte array from seed AccountCreated.day for password vS4n7YQ3eh8vnpAH
--VALUES ('sysadmin', '2017-06-25 21:52:52.280', 'DC8YLUdMVKnjFHBS4mZuL9XRvBiqIOu94Ta45IO85Xs=' );
--create Customers
insert into Accounts
--		UserName   			AccountCreated				PasswordHash for password aZ1
values ('cust', '2017-06-26 04:19:07.263', 'opl9DjFRwcT/H/0Oq5nl/QUGRu65p1RyADrh7PaP0h8=' );
--create Submitters
insert into Accounts
--		UserName   			AccountCreated			PasswordHash for password 123JohnAndHarry123
values ('John And Harry', '2017-06-28 11:17:59.600', 'On6IPqcouR28PRMFsM6tXZ/H6eOhHtu9z3MgPLmzCys=' );
--create Games
insert into Games
values ('Lotto', 'Archive\John And Harry\Lotto.zip', 98, '2017-06-28 11:17:59.600', 0, 'Gambling',3 );
----------reset for testing-----------------