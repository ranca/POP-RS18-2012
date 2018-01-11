--seed.sql

INSERT INTO TipNamestaja (Naziv, Obrisan) VALUES('Klub i set stolovi', 0);
INSERT INTO TipNamestaja (Naziv, Obrisan) VALUES('Komadni namestaj za sedelje', 0);
INSERT INTO TipNamestaja (Naziv, Obrisan) VALUES('Vitrine i regali', 0);
INSERT INTO TipNamestaja (Naziv, Obrisan) VALUES('Tapacirani nameštaj - garniture', 0);
INSERT INTO TipNamestaja (Naziv, Obrisan) VALUES('Police', 0);
INSERT INTO TipNamestaja (Naziv, Obrisan) VALUES('TV Police', 0);
INSERT INTO TipNamestaja (Naziv, Obrisan) VALUES('Kreveti', 0);
INSERT INTO TipNamestaja (Naziv, Obrisan) VALUES('Dečije sobe', 0);
INSERT INTO TipNamestaja (Naziv, Obrisan) VALUES('Komode, fiokari i noćni orm.', 0);
INSERT INTO TipNamestaja (Naziv, Obrisan) VALUES('Garderoberi i ormani', 0);
INSERT INTO TipNamestaja (Naziv, Obrisan) VALUES('Kuhinje', 0);
INSERT INTO TipNamestaja (Naziv, Obrisan) VALUES('Trpezarije', 0);
INSERT INTO TipNamestaja (Naziv, Obrisan) VALUES('Predsoblja', 0);
INSERT INTO TipNamestaja (Naziv, Obrisan) VALUES('Kancelarijski i radni nameštaj', 0);
INSERT INTO TipNamestaja (Naziv, Obrisan) VALUES('Dodaci', 0);
INSERT INTO TipNamestaja (Naziv, Obrisan) VALUES('Dušeci', 0);

INSERT INTO Akcije(DatumPocetka, DatumZavrsetka, Popust, Obrisan)
	VALUES('11/06/2017', '11/26/2018', 30, 0)
INSERT INTO Akcije(DatumPocetka, DatumZavrsetka, Popust, Obrisan)
	VALUES('06/08/2017', '11/20/2018', 20, 0)
INSERT INTO Akcije(DatumPocetka, DatumZavrsetka, Popust, Obrisan)
	VALUES('03/03/2017', '05/05/2018', 10, 0)	

INSERT INTO Namestaj (TipNamestajaId, AkcijaId, Naziv, Sifra, Cena, PopustCena, KolicinaUMagacinu, ProdataKolicina, Obrisan)
	VALUES(1, 1, 'KLUB STO UNO 90x50', 'UNO950', 5860.0, 4490.0, 50, 1, 0);
INSERT INTO Namestaj (TipNamestajaId, AkcijaId, Naziv, Sifra, Cena, PopustCena, KolicinaUMagacinu, ProdataKolicina, Obrisan)
	VALUES(1, 1, 'KLUB STO CRAFT ST', 'CRAFTST', 12720.0, 10176.0, 50, 6, 0);
INSERT INTO Namestaj (TipNamestajaId, AkcijaId, Naziv, Sifra, Cena, PopustCena, KolicinaUMagacinu, ProdataKolicina, Obrisan)
	VALUES(2, 3, 'FOTELJA KAPRI', 'FOTK', 12440.0, 9952.0, 50, 2, 0);
INSERT INTO Namestaj (TipNamestajaId, AkcijaId, Naziv, Sifra, Cena, PopustCena, KolicinaUMagacinu, ProdataKolicina, Obrisan)
	VALUES(2, 2, 'RELAX FOTELJA', 'RF013', 7220.0, 4490.0, 50, 1, 0);
INSERT INTO Namestaj (TipNamestajaId, AkcijaId, Naziv, Sifra, Cena, PopustCena, KolicinaUMagacinu, ProdataKolicina, Obrisan)
	VALUES(3, 1, 'KLIZNI GARDEROBER WINNER PLUS', '21019083', 36910.0, 21.990, 50, 6, 0);
INSERT INTO Namestaj (TipNamestajaId, AkcijaId, Naziv, Sifra, Cena, PopustCena, KolicinaUMagacinu, ProdataKolicina, Obrisan)
	VALUES(3, NULL, 'VITRINA LEVANO LVNM01', '21019887', 27690.0, 17990.0, 50, 1, 0);
INSERT INTO Namestaj (TipNamestajaId, AkcijaId, Naziv, Sifra, Cena, PopustCena, KolicinaUMagacinu, ProdataKolicina, Obrisan)
	VALUES(3, NULL, 'REGAL APUS', '11003055', 18800.0, 9990.0, 50, 1, 0);
INSERT INTO Namestaj (TipNamestajaId, AkcijaId, Naziv, Sifra, Cena, PopustCena, KolicinaUMagacinu, ProdataKolicina, Obrisan)
	VALUES(3, NULL, 'VITRINA KENT VS', '11005739', 17060.0, 11890.0, 50, 1, 0);
INSERT INTO Namestaj (TipNamestajaId, AkcijaId, Naziv, Sifra, Cena, PopustCena, KolicinaUMagacinu, ProdataKolicina, Obrisan)
	VALUES(4, NULL, 'UGAONA GARNITURA KULMA + TABURE', '21019518', 43120.0, 27990.0, 50, 6, 0);
INSERT INTO Namestaj (TipNamestajaId, AkcijaId, Naziv, Sifra, Cena, PopustCena, KolicinaUMagacinu, ProdataKolicina, Obrisan)
	VALUES(4, NULL, 'LEŽAJ TEO', '21014721', 28470.0, 18990.0, 50, 1, 0);
INSERT INTO Namestaj (TipNamestajaId, AkcijaId, Naziv, Sifra, Cena, PopustCena, KolicinaUMagacinu, ProdataKolicina, Obrisan)
	VALUES(5, NULL, 'TV POLICA KENT 120', '11005737', 10240.0, 7090.0, 50, 2, 0);
INSERT INTO Namestaj (TipNamestajaId, AkcijaId, Naziv, Sifra, Cena, PopustCena, KolicinaUMagacinu, ProdataKolicina, Obrisan)
	VALUES(5, NUll, 'TV POLICA AMOS TV2P', '11005715', 7360.0, 5888.0, 50, 1, 0);
INSERT INTO Namestaj (TipNamestajaId, AkcijaId, Naziv, Sifra, Cena, PopustCena, KolicinaUMagacinu, ProdataKolicina, Obrisan)
	VALUES(6, NULL, 'BRAČNI KREVET', '21019083', 36910.0, 21.990, 50, 6, 0);
INSERT INTO Namestaj (TipNamestajaId, AkcijaId, Naziv, Sifra, Cena, PopustCena, KolicinaUMagacinu, ProdataKolicina, Obrisan)
	VALUES(6, NULL, 'VITRINA LEVANO LVNM01', '21019887', 27690.0, 17990.0, 50, 1, 0);
INSERT INTO Namestaj (TipNamestajaId, AkcijaId, Naziv, Sifra, Cena, PopustCena, KolicinaUMagacinu, ProdataKolicina, Obrisan)
	VALUES(7, NULL, 'FOTELJA KAPRI', 'FOTK', 12440.0, 9952.0, 50, 2, 0);
INSERT INTO Namestaj (TipNamestajaId, AkcijaId, Naziv, Sifra, Cena, PopustCena, KolicinaUMagacinu, ProdataKolicina, Obrisan)
	VALUES(7, NULL, 'RELAX FOTELJA', 'RF013', 7220.0, 4490.0, 50, 1, 0);
INSERT INTO Namestaj (TipNamestajaId, AkcijaId, Naziv, Sifra, Cena, PopustCena, KolicinaUMagacinu, ProdataKolicina, Obrisan)
	VALUES(3, NULL, 'KLIZNI GARDEROBER WINNER PLUS', '21019083', 36910.0, 21.990, 50, 6, 0);
INSERT INTO Namestaj (TipNamestajaId, AkcijaId, Naziv, Sifra, Cena, PopustCena, KolicinaUMagacinu, ProdataKolicina, Obrisan)
	VALUES(3, NULL, 'VITRINA LEVANO LVNM01', '21019887', 27690.0, 17990.0, 50, 1, 0);



;
INSERT INTO DodatneUsluge (Naziv, Cena, Obrisan) VALUES('Prevoz i montaža', 500, 0);
INSERT INTO DodatneUsluge (Naziv, Cena, Obrisan) VALUES('Uzimanje starog namestaja', 200, 0);
INSERT INTO DodatneUsluge (Naziv, Cena, Obrisan) VALUES('Nista(sami dolazite po nameštaj)', 1, 0);

INSERT INTO Korisnici (Ime, Prezime, KorisnickoIme, Lozinka, TipKorisnika, Obrisan)
	VALUES('Aleksandar', 'Rancic', 'acacar', 'aca123', 'Administrator' , 0);
INSERT INTO Korisnici (Ime, Prezime, KorisnickoIme, Lozinka, TipKorisnika, Obrisan)
	VALUES('Pera', 'Peric', 'pera', 'pera', 'Prodavac' , 0);
INSERT INTO Korisnici (Ime, Prezime, KorisnickoIme, Lozinka, TipKorisnika, Obrisan)
	VALUES('Mirko', 'Miric', 'mire', 'mire', 'Prodavac' , 0);


INSERT INTO Salon(Naziv, Adresa, Telefon, Email, AdresaInternetSajta, Pib, MaticniBroj, BrojZiroRacuna, Obrisan)
	VALUES('FormaIdeale', 'Svetog Save 10', '021-888-888', 'info@formaideale.rs', 'www.formaideale.rs', 103251239, 	17546830, '290-11750-07', 0)