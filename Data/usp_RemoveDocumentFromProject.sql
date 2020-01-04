DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_RemoveDocumentFromProject`(inProjectDocsId int)
BEGIN

DELETE FROM `tdt`.`projectdocs`
WHERE Id = inProjectDocsId;


END$$
DELIMITER ;
