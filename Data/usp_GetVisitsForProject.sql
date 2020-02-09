DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_GetVisitsForProject`(inProjectId int)
BEGIN

SELECT `visitdates`.`Id`,
    `visitdates`.`Project_Id`,
    `visitdates`.`VisitDateStart`,
    `visitdates`.`VisitDateEnd`,
    `visitdates`.`Visitor`
FROM `tdt`.`visitdates`
WHERE Project_Id = inProjectId;


END$$
DELIMITER ;
