DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_AddFunderToProject`(inProjectId int, inFunderId int, inAmountFunded decimal)
BEGIN
INSERT INTO `tdt`.`projectfunders`
(`Project_Id`,
`Funder_Id`,
`AmountFunded`)
VALUES
(inProjectId,
inFunderId,
inAmountFunded);


END$$
DELIMITER ;
