DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_GetRelatedProjects`(inProjectId int)
BEGIN

SELECT r.`Id`,
    r.`Project_Id`,
    r.`RelationshipKey`,
    p.`ProjectIdentifier`,
    p.`ProjectName`
FROM `tdt`.`relatedprojects` r, `tdt`.`projects` p
WHERE r.RelationshipKey = p.Id
  AND r.Project_Id = inProjectId;


END$$
DELIMITER ;
