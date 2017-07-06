Use [VaporArchive.ArchiveDatabaseContext]

--Queries per table
select * from Games
select * from GameCustomerAccounts
select * from Submitters
select * from Customers
select * from Accounts

----------reset for testing-----------------
----remove all rows
--DELETE FROM Games
--DELETE FROM Customers
--DELETE FROM Submitters
--DELETE FROM Accounts
--DELETE FROM GameCustomerAccounts
----reset identity
--DBCC CHECKIDENT ('[Accounts]', RESEED, 0);
--DBCC CHECKIDENT ('[Games]', RESEED, 0);
----create sysadmin
--INSERT INTO Accounts
------   UserName   	 PasswordHash salted with Precomputed byte array from seed AccountCreated.day for password vS4n7YQ3eh8vnpAH   AccountCreated				
--VALUES ('sysadmin', 'DC8YLUdMVKnjFHBS4mZuL9XRvBiqIOu94Ta45IO85Xs=',                                                               '2017-06-25 21:52:52.280' );
----create Customers
--insert into Accounts
----		UserName				PasswordHash for password aZ1   			AccountCreated
--values ('cust', 'opl9DjFRwcT/H/0Oq5nl/QUGRu65p1RyADrh7PaP0h8=', '2017-06-26 04:19:07.263');
--insert into Customers
--values(2)
----create Submitters
--insert into Accounts
----		UserName			PasswordHash for password 123JohnAndHarry123   			AccountCreated
--values ('John And Harry', 'On6IPqcouR28PRMFsM6tXZ/H6eOhHtu9z3MgPLmzCys=', '2017-06-28 11:17:59.600' );
--insert into Accounts
----		UserName			PasswordHash for password 1aZ   			AccountCreated
--values ('a', 'XDT/SpV+2Yj1neu9ju1y7cBE3ItsYUw5NxL08Z9YRfs=', '2017-06-28 13:50:20.687' );
--insert into Accounts
----		UserName			PasswordHash for password MQCpsswrd101   			AccountCreated
--values ('Mary Quite Contrary', '/AcKNXaqZ3wNhreO3bSyNYmT/+keszAi1y+szQ4PgY4=', '2017-07-02 23:44:57.527' );

--insert into Submitters
--values(3),
--(4),
--(5)
----create Games

insert into Games
values ('Lotto', 'Archive\John And Harry\Lotto.zip', 59, '2017-06-28 11:17:59.600', 0, 'Gambling',3,3 );
--insert into Games
--values ('Russian Roulette', 'Archive\John And Harry\RussianRouletteAssessment.zip', 20243, '2017-06-28 11:17:59.600', 0, 'Gambling',3 ,3 );
--insert into Games
--values ('Ih8BenAffleck', 'Archive\a\Ih8BenAffleck.zip', 52, '2017-06-29 11:17:59.600', 0, 'NameSorting',4,4 );
--insert into Games
--values ('MessagesSoManyMessages', 'Archive\a\MessagesSoManyMessages.zip', 53, '2017-06-29 11:17:59.600', 0, 'Greetings',4 ,4 );
--insert into Games
--values ('TheBettingGame', 'Archive\Mary Quite Contrary\TheBettingGame.zip', 3844, '2017-06-30 11:17:59.600', 0, 'Gambling',5 ,5 );
select * from Games
------------reset for testing-----------------
--delete from Games
--where GameID = 29