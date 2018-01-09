--seed.sql
INSERT INTO TipNamestaja (Naziv, Obrisan) VALUES ('Polica', 0);
INSERT INTO TipNamestaja (Naziv, Obrisan) VALUES ('Regal', 0);
INSERT INTO TipNamestaja (Naziv, Obrisan) VALUES ('Ugaona', 0);
INSERT INTO TipNamestaja (Naziv, Obrisan) VALUES ('Krevet', 0);

INSERT INTO Namestaj (TipNamestajaId, Naziv, Sifra, Cena, Kolicina, Obrisan)
VALUES (1, 'Ultra polica', 'ul1po', 1200, 2, 0);
INSERT INTO Namestaj (TipNamestajaId, Naziv, Sifra, Cena, Kolicina, Obrisan)
VALUES (2, 'Crni regal', 'cr2re', 345, 7, 0);
INSERT INTO Namestaj (TipNamestajaId, Naziv, Sifra, Cena, Kolicina, Obrisan)
VALUES (3, 'Ugggg', 'ug1po', 765, 5, 0);

INSERT INTO Usluga (Naziv, Cena, Obrisan) VALUES ('Prevoz', 220, 0);
INSERT INTO Usluga (Naziv, Cena, Obrisan) VALUES ('Montiranje', 7800, 0);
INSERT INTO Usluga (Naziv, Cena, Obrisan) VALUES ('Nesto', 399, 0);

INSERT INTO Korisnik (Ime, Prezime, KorisnickoIme, Lozinka, TipKorisnika, Obrisan)
VALUES ('Petar', 'Petrovic', 'pera', 'pera', 'Administrator', 0);
INSERT INTO Korisnik (Ime, Prezime, KorisnickoIme, Lozinka, TipKorisnika, Obrisan)
VALUES ('Ivan', 'Ivanovic', 'ivan', 'ivan', 'Prodavac', 0);

INSERT INTO Prodaja (DatumProdaje, BrojRacuna, Kupac, UkupanIznos)
VALUES ('2010-11-12 11:22:33', 23, 'Peroo', 2345);

INSERT INTO Stavka (IdProdaje, IdNamestaja, Kolicina) VALUES (1, 2, 3);
INSERT INTO Stavka (IdProdaje, IdNamestaja, Kolicina) VALUES (2, 1, 4);

INSERT INTO UslugaProdaje (IdProdaje, IdUsluge) VALUES (1, 2);

INSERT INTO Akcija (Naziv, PocetakAkcije, KrajAkcije, Popust)
VALUES ('Novogodisnji popust', '2010-11-12', '2015-11-12', 22);
INSERT INTO Akcija (Naziv, PocetakAkcije, KrajAkcije, Popust)
VALUES ('Uskrsnji popust', '2015-11-03', '2017-02-12', 15);

INSERT INTO NaAkciji (IdAkcije, IdNamestaja) VALUES (1, 1);

DELETE FROM Stavka WHERE Id BETWEEN 1051 AND 1060;
DELETE FROM Prodaja WHERE Id BETWEEN 1055 AND 1066;
DELETE FROM UslugaProdaje WHERE Id BETWEEN 2 AND 3;

SELECT * FROM TipNamestaja ORDER BY Naziv;