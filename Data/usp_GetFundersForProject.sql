DELIMITER $$
DROP PROCEDURE IF EXISTS `usp_GetFundersForProject`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_GetFundersForProject`(inProjectId int)
BEGIN

SELECT p.`Id`,
    p.`Project_Id`,
    p.`Funder_Id`,
    p.`AmountFunded`,
    f.Name
FROM `tdt`.`projectfunders` p, `tdt`.`funders` f
WHERE p.Funder_Id = f.Id
  AND p.Project_Id = inProjectId;


END$$
DELIMITER ;
