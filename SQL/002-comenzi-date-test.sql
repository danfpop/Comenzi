-- date de test pentru comenzi
USE Comenzi;
go
INSERT INTO parteneri (nume, tel, email) VALUES
	('Dennis Ritchie', '555-24878', null),
	('Edgar Ted Codd', '555-73267', 'ted.codd@ibm.com'),
	('William Henry Gates','555-00011','bill.gates@microsoft.com');

INSERT INTO produse(denumire, pret) VALUES 
    ('MASA MASTERS', 1200),
	('COMODA TV', 450),
	('VITRINA', 940),
	('DULAP', 780),
	('CUIER',320);


INSERT INTO comenzi(id_partener, nr, data) 
	VALUES (1, '1', '2017-10-25');
INSERT INTO comenzi_detaliu (id_comanda, id_produs, cant) VALUES
   (IDENT_CURRENT('comenzi'), 1, 2),
   (IDENT_CURRENT('comenzi'), 2, 3);


INSERT INTO comenzi(id_partener, nr, data) 
	VALUES (1, '3', '2019-03-24');
INSERT INTO comenzi_detaliu (id_comanda, id_produs, cant) VALUES
   (IDENT_CURRENT('comenzi'), 1, 2);
  

INSERT INTO comenzi(id_partener, nr, data) 
	VALUES (2, '2', '2018-07-11')
INSERT INTO comenzi_detaliu (id_comanda, id_produs, cant) VALUES
   (IDENT_CURRENT('comenzi'), 1, 1),
   (IDENT_CURRENT('comenzi'), 3, 1),
   (IDENT_CURRENT('comenzi'), 4, 3);

   select * from produse
