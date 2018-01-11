
CREATE TABLE Salon(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	Naziv VARCHAR(80),
	Adresa VARCHAR(40),
	Telefon VARCHAR(30),
	Email VARCHAR(30),
	AdresaInternetSajta VARCHAR(80),
	Pib INT,
	MaticniBroj INT,
	BrojZiroRacuna VARCHAR(40),
	Obrisan BIT
);
CREATE TABLE Korisnici(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	Ime VARCHAR(20),
	Prezime VARCHAR(20),
	KorisnickoIme VARCHAR(20),
	Lozinka VARCHAR(60),
	TipKorisnika VARCHAR(20),
	Obrisan BIT
);
CREATE TABLE TipNamestaja(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	Naziv VARCHAR(80),
	Obrisan BIT
);
CREATE TABLE Akcije(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	DatumPocetka DATE,
	DatumZavrsetka DATE,
	Popust INT,
	Obrisan BIT
);
CREATE TABLE Namestaj(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	Naziv VARCHAR(60),
	Sifra VARCHAR(20),
	Cena NUMERIC(10, 2),
	KolicinaUMagacinu INT,
	TipNamestajaId INT,
	Obrisan BIT,
	PopustCena NUMERIC(9, 2),	
	ProdataKolicina INT,
	AkcijaId INT,
	FOREIGN KEY (TipNamestajaId) REFERENCES TipNamestaja(Id),
	FOREIGN KEY (AkcijaId) REFERENCES Akcije(Id)
);

CREATE TABLE DodatneUsluge(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	Naziv VARCHAR(80),
	Cena NUMERIC(10, 2),
	Obrisan BIT
);
CREATE TABLE ProdajaNamestaja(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	DatumProdaje DATE,
	BrojRacuna INT,
	Kupac VARCHAR(40),
	UkupanIznos DECIMAL,
	UkupanIznosPDV DECIMAL,
	Obrisan BIT
);
CREATE TABLE ProdajaProzorNamestaj(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	NamestajZaProdajuId INT	FOREIGN KEY REFERENCES Namestaj(Id),
	ProdajaNamestajaId INT FOREIGN KEY REFERENCES ProdajaNamestaja(Id),
	Obrisan BIT
);
CREATE TABLE ProdajaProzorUsluga(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	DodatnaUslugaId INT FOREIGN KEY REFERENCES DodatneUsluge(Id),
	ProdajaNamestajaId INT FOREIGN KEY REFERENCES ProdajaNamestaja(Id),
	Obrisan BIT
);

