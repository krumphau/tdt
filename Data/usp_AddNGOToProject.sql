DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_AddNGOToProject`(inProjectId int, inNGOId int)
BEGIN
INSERT INTO `tdt`.`projectngos`
(`Project_Id`,
`NGO_Id`)
VALUES
(inProjectId,
inNGOId);


END$$
DELIMITER ;
