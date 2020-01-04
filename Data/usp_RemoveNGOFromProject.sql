DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_RemoveNGOFromProject`(inProjectNgoId int)
BEGIN

DELETE FROM `tdt`.`projectngos`
WHERE Id = inProjectNgoId;


END$$
DELIMITER ;
