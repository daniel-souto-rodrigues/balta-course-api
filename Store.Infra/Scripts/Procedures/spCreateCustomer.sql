CREATE PROCEDURE spCreateCustomer
    @Id UNIQUEIDENTIFIER,
    @FirtName VARCHAR(40),
    @LastName VARCHAR(40),
    @Document CHAR(11),
    @Email VARCHAR(160),
    @Phone VARCHAR(13)

AS
INSERT INTO [Customer]
    (
        [Id],
        [FirstName],
        [LastName],
        [Document],
        [Email],
        [Phone]
    )
VALUES
    (
        @Id,
        @FirtName,
        @LastName,
        @Document,
        @Email,
        @Phone
    )