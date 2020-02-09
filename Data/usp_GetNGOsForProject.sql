DELIMITER $$
DROP PROCEDURE IF EXISTS `usp_GetNGOsForProject`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_GetNGOsForProject`(inProjectId int)
BEGIN

SELECT p.`Id`,
    p.`Project_Id`,
    p.`NGO_Id`,
    n.`Name`
FROM `tdt`.`projectngos` p, `tdt`.`ngos` n
WHERE p.NGO_Id = n.Id
  AND p.Project_Id = inProjectId;


END$$
DELIMITER ;
