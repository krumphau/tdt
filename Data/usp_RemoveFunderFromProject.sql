DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_RemoveFunderFromProject`(inProjectFundersId int)
BEGIN

DELETE FROM `tdt`.`projectfunders`
WHERE Id = inProjectFundersId;


END$$
DELIMITER ;
