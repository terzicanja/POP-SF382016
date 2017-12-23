--crebas.sql
CREATE TABLE TipNamestaja (
	Id INT PRIMARY KEY IDENTITY(1, 1),
	Naziv VARCHAR(80),
	Obrisan BIT
)
GO
CREATE TABLE Namestaj(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	TipNamestajaId INT,
	Naziv VARCHAR(100),
	Sifra VARCHAR(20),
	Cena NUMERIC(9, 2),
	Kolicina INT,
	Obrisan BIT,
	FOREIGN KEY (TipNamestajaId) REFERENCES TipNamestaja(Id)
);

CREATE TABLE Usluga(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	Naziv VARCHAR(80),
	Cena NUMERIC(9, 2),
	Obrisan BIT
);

CREATE TABLE Korisnik(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	Ime VARCHAR(20),
	Prezime VARCHAR(40),
	KorisnickoIme VARCHAR(40),
	Lozinka VARCHAR(50),
	TipKorisnika VARCHAR(20) CHECK(TipKorisnika IN ('Administrator', 'Prodavac')),
	Obrisan BIT
);

CREATE TABLE Prodaja(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	DatumProdaje DATETIME,
	BrojRacuna INT,
	Kupac VARCHAR(50),
	UkupanIznos NUMERIC(10, 2)
);

CREATE TABLE Stavka(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	IdProdaje INT,
	IdNamestaja INT,
	Kolicina INT,
	FOREIGN KEY (IdProdaje) REFERENCES Prodaja(Id),
	FOREIGN KEY (IdNamestaja) REFERENCES Namestaj(Id)
);

CREATE TABLE UslugaProdaje(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	IdProdaje INT,
	IdUsluge INT,
	FOREIGN KEY (IdProdaje) REFERENCES Prodaja(Id),
	FOREIGN KEY (IdUsluge) REFERENCES Usluga(Id)
);

CREATE TABLE Akcija(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	Naziv VARCHAR(70),
	PocetakAkcije DATE,
	KrajAkcije DATE,
	Popust INT
);

CREATE TABLE NaAkciji(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	IdAkcije INT,
	IdNamestaja INT,
	FOREIGN KEY (IdAkcije) REFERENCES Akcija(Id),
	FOREIGN KEY (IdNamestaja) REFERENCES Namestaj(Id)
);



DROP TABLE Akcija;


SELECT * FROM Namestaj;