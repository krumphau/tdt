DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_AddRelatedProject`(inProjectId int, inRelationshipKey int)
BEGIN
INSERT INTO `tdt`.`relatedprojects`
(`Project_Id`,
`RelationshipKey`)
VALUES
(inProjectId,
inRelationshipKey);


END$$
DELIMITER ;
