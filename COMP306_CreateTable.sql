DROP TABLE DrivingCentres;

BEGIN
CREATE TABLE DrivingCentres 
    ( AddressId INTEGER NOT NULL IDENTITY NOT FOR REPLICATION , 
      Number    INTEGER, 
      Street1   VARCHAR (50) , 
      Street2   VARCHAR (50) , 
	  Country   VARCHAR (50) , 
	  Province  VARCHAR (50) , 
	  District  VARCHAR(50),
	  City      VARCHAR (50) , 
	  ZipCode   VARCHAR (50) 
    ) 
CREATE unique nonclustered index addressId_idx ON DrivingCentres ( addressId )

INSERT INTO DrivingCentres 
      ( Number,Street1,         Street2, Country,  Province,  District,    City,       ZipCode ) 
VALUES( 5555,  'Eglinton Ave W','',     'Canada', 'Ontario', 'Etobicoke', 'Toronto', 'M9C 5M1')

INSERT INTO DrivingCentres 
      (Number,Street1,         Street2,                              Country,  Province,  District,      City,      ZipCode ) 
VALUES(1448, 'Lawrence Ave E','Unit 15 Victoria Terrace Plaza',     'Canada', 'Ontario', 'North York' , 'Toronto', 'M4A 2V6')

END