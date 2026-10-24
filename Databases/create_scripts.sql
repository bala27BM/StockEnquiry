
CREATE DATABASE StockEnquiryDB;
GO

USE StockEnquiryDB;
GO
--parts table
CREATE TABLE Parts
(
    PartNumber VARCHAR(30) PRIMARY KEY,
    Description VARCHAR(200) NOT NULL,
    UOM VARCHAR(10) NOT NULL
);
GO
--stock
CREATE TABLE StockDetails
(
    StockId INT IDENTITY(1,1) PRIMARY KEY,
    PartNumber VARCHAR(30) NOT NULL,
    Location VARCHAR(30) NOT NULL,
    LocationType VARCHAR(30) NOT NULL,
    AvailableQty INT NOT NULL DEFAULT 0,
    ReservedQty INT NOT NULL DEFAULT 0,

    CONSTRAINT FK_StockDetails_Parts
        FOREIGN KEY (PartNumber)
        REFERENCES Parts(PartNumber),

    CONSTRAINT CK_StockDetails_AvailableQty
        CHECK (AvailableQty >= 0),

    CONSTRAINT CK_StockDetails_ReservedQty
        CHECK (ReservedQty >= 0)
);
GO

INSERT INTO Parts (PartNumber, Description, UOM)
VALUES
('PN-10001', 'Hydraulic Pump', 'EA'),
('PN-10002', 'Aircraft Filter', 'EA');
GO

INSERT INTO StockDetails
(
    PartNumber, Location, LocationType,
    AvailableQty, ReservedQty
)
VALUES
('PN-10001', 'LHR-WH', 'Warehouse', 12, 3),
('PN-10001', 'DXB-WH', 'Warehouse', 5, 1),
('PN-10001', 'SIN-LINE', 'Line Station', 2, 0);
GO
