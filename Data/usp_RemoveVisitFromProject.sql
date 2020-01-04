DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_RemoveVisitFromProject`(inVisitDateId int)
BEGIN

DELETE FROM `tdt`.`visitdates`
WHERE Id = inVisitDateId;


END$$
DELIMITER ;
