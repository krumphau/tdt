DELIMITER $$
DROP PROCEDURE IF EXISTS `usp_GetOtherBodiesForProject` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_GetOtherBodiesForProject`(inProjectId int)
BEGIN

SELECT r.`Id`,
    r.`Project_Id`,
    r.`OtherBody_Id`,
    o.`Name`
FROM `tdt`.`projectotherbodies` r, `tdt`.`otherbodies` o
WHERE r.OtherBody_Id = o.Id
  AND r.Project_Id = inProjectId;


END$$
DELIMITER ;
