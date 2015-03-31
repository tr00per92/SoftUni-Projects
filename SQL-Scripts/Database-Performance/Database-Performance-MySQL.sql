CREATE DATABASE performancetest;

USE performancetest;

CREATE TABLE testtable
(	
	id int AUTO_INCREMENT,
	date datetime,
	text nvarchar(100),
    PRIMARY KEY (id, date)
) 
PARTITION BY RANGE(YEAR(date)) 
(	
	PARTITION p0 VALUES LESS THAN (2000),
    PARTITION p1 VALUES LESS THAN (2010),
    PARTITION p2 VALUES LESS THAN MAXVALUE
);

INSERT INTO testtable(Text, Date) Values('Text', STR_TO_DATE('1/1/1994', '%d/%m/%Y'));
INSERT INTO testtable(Text, Date) Values('Text', STR_TO_DATE('1/1/1995', '%d/%m/%Y'));
INSERT INTO testtable(Text, Date) Values('Text', STR_TO_DATE('1/1/1996', '%d/%m/%Y'));
INSERT INTO testtable(Text, Date) Values('Text', STR_TO_DATE('1/1/2004', '%d/%m/%Y'));
INSERT INTO testtable(Text, Date) Values('Text', STR_TO_DATE('1/1/2005', '%d/%m/%Y'));
INSERT INTO testtable(Text, Date) Values('Text', STR_TO_DATE('1/1/2006', '%d/%m/%Y'));
INSERT INTO testtable(Text, Date) Values('Text', STR_TO_DATE('1/1/2014', '%d/%m/%Y'));
INSERT INTO testtable(Text, Date) Values('Text', STR_TO_DATE('1/1/2015', '%d/%m/%Y'));
INSERT INTO testtable(Text, Date) Values('Text', STR_TO_DATE('1/1/2016', '%d/%m/%Y'));
INSERT INTO testtable(Text, Date) Values('Text', STR_TO_DATE('1/1/1994', '%d/%m/%Y'));
INSERT INTO testtable(Text, Date) Values('Text', STR_TO_DATE('1/1/1995', '%d/%m/%Y'));
INSERT INTO testtable(Text, Date) Values('Text', STR_TO_DATE('1/1/1996', '%d/%m/%Y'));
INSERT INTO testtable(Text, Date) Values('Text', STR_TO_DATE('1/1/2004', '%d/%m/%Y'));
INSERT INTO testtable(Text, Date) Values('Text', STR_TO_DATE('1/1/2005', '%d/%m/%Y'));
INSERT INTO testtable(Text, Date) Values('Text', STR_TO_DATE('1/1/2006', '%d/%m/%Y'));
INSERT INTO testtable(Text, Date) Values('Text', STR_TO_DATE('1/1/2014', '%d/%m/%Y'));
INSERT INTO testtable(Text, Date) Values('Text', STR_TO_DATE('1/1/2015', '%d/%m/%Y'));
INSERT INTO testtable(Text, Date) Values('Text', STR_TO_DATE('1/1/2016', '%d/%m/%Y'));

DELIMITER //
CREATE PROCEDURE AddDummyData()
BEGIN
	DECLARE counter INT;
    SET counter = 0;
    WHILE (counter < 16) DO
		INSERT INTO TestTable(date, text)
		SELECT DATE_ADD(t.date, INTERVAL counter * 10 MINUTE), CONCAT(t.text, CONVERT(counter, char(5))) FROM testtable t;
		SET counter = counter + 1;
	END WHILE;
END; //
DELIMITER ;

CALL AddDummyData();

SELECT COUNT(*) FROM testtable;

SELECT * FROM testtable
WHERE YEAR(date) IN (2004, 2005, 2006);

SELECT * FROM testtable
WHERE YEAR(date) IN (1995, 2005, 2015);
