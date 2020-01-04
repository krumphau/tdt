DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_RemoveRelatedProject`(inRelatedProjectId int)
BEGIN

DELETE FROM `tdt`.`relatedprojects`
WHERE Id = inRelatedProjectId;


END$$
DELIMITER ;
