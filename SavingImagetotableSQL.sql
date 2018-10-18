CREATE TABLE dbo.Images
(
    image_id INT IDENTITY(1,1) NOT NULL,
    image_data IMAGE NOT NULL,
    image_name VARCHAR(75) NOT NULL
)
go
CREATE FUNCTION dbo.udfTrimString (@value VARCHAR(8000))
RETURNS VARCHAR(8000)
AS
    BEGIN
    DECLARE @Trimmed_Value VARCHAR(8000)
    SET @Trimmed_Value = RTrim(LTrim(@value))
    RETURN @Trimmed_Value
    END

go
CREATE PROCEDURE dbo.uspInsertImage @image_data IMAGE, @image_name VARCHAR(75)
AS
    INSERT INTO Images(image_data, image_name)
    VALUES (@image_data, dbo.udfTrimString(@image_name))
go
CREATE PROCEDURE dbo.uspGetImage @image_name VARCHAR(75)
AS
    BEGIN
    SELECT
     image_id AS 'ID',
       image_data AS 'Image',
        image_name AS 'ImageName'
    FROM
        dbo.Images
    WHERE
        image_name = dbo.udfTrimString(@image_name)
    END

	