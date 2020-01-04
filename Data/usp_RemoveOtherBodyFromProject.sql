DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_RemoveOtherBodyFromProject`(inProjectOtherBodyId int)
BEGIN

DELETE FROM `tdt`.`projectotherbodies`
WHERE Id = inProjectOtherBodyId;


END$$
DELIMITER ;
