DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_AddVisitToProject`(inProjectId int, inVisitDateStart datetime, inVisitDateEnd datetime, inVisitor varchar(100))
BEGIN
INSERT INTO `tdt`.`visitdates`
(`Project_Id`,
`VisitDateStart`,
`VisitDateEnd`,
`Visitor`)
VALUES
(inProjectId,
inVisitDateStart,
inVisitDateEnd,
inVisitor);

END$$
DELIMITER ;
