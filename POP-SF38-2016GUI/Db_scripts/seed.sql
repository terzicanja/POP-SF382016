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