DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_AddDocumentToProject`(inProjectId int, inDocName nvarchar(255), inFilePath nvarchar(255), inDescription nvarchar(255), inDocCategory nvarchar(255))
BEGIN
INSERT INTO `tdt`.`projectdocs`
(`Project_Id`,
`DocName`,
`FilePath`,
`Description`,
`DocCategory`)
VALUES
(inProjectId,
inDocName,
inFilePath,
inDescription,
inDocCategory);



END$$
DELIMITER ;
