CREATE DATABASE Comenzi;
GO
USE Comenzi;
GO
-- create schema comenzi;
/*
drop view Comenzi_view;
drop table comenzi_detaliu;
drop table comenzi;
drop table produse;
drop table parteneri;
*/
Create table parteneri(
  id int NOT NULL IDENTITY primary key,
  nume varchar(20) NOT NULL UNIQUE,
  tel varchar(30),
  email varchar(50)
);

CREATE TABLE produse(
  id int NOT NULL IDENTITY primary key,
  denumire varchar(20) NOT NULL UNIQUE,
  pret  decimal (14,2)
);


CREATE TABLE comenzi(
  id int NOT NULL IDENTITY primary key,
  id_partener int NOT NULL foreign key references parteneri(id) ON DELETE CASCADE,
  nr varchar(20) NOT NULL,		-- nr. comanda
  data date default GETDATE()
);



/*
  - detaliu comazi
*/
CREATE TABLE comenzi_detaliu(
  id int NOT NULL IDENTITY primary key,
  id_comanda int NOT NULL foreign key references comenzi(id) ON DELETE CASCADE,
  id_produs int NOT NULL foreign key references produse(id) ON DELETE NO ACTION,
  cant decimal(14,2)
);

go

-- view cu comenzi _+ valoare fiecarei comezi
CREATE VIEW Comenzi_view AS 
SELECT c.id, c.nr, c.data, p.nume, p.tel, val.valoare
FROM comenzi as c
INNER JOIN parteneri as p on p.id = c.id_partener
INNER JOIN (
   SELECT id_comanda,  Sum(Pret*Cant) as valoare
   from comenzi_detaliu d
   inner join produse p on p.id = d.id_produs
   group by id_comanda
   ) as val on val.id_comanda = c.id



   --select * from Comenzi_view 
   --  where YEAR(data) = 2019
   --order by valoare desc
