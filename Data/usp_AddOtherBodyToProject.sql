DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_AddOtherBodyToProject`(inProjectId int, inOtherBodyId int)
BEGIN
INSERT INTO `tdt`.`projectotherbodies`
(`Project_Id`,
`OtherBody_Id`)
VALUES
(inProjectId,
inOtherBodyId);




END$$
DELIMITER ;
