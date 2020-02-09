DELIMITER $$
DROP PROCEDURE IF EXISTS `usp_GetDocsForProject`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_GetDocsForProject`(inProjectId int)
BEGIN

SELECT `projectdocs`.`Id`,
    `projectdocs`.`Project_Id`,
    `projectdocs`.`DocName`,
    `projectdocs`.`FilePath`,
    `projectdocs`.`Description`,
    `projectdocs`.`DocCategory`
FROM `tdt`.`projectdocs`
WHERE Project_Id = inProjectId;


END$$
DELIMITER ;
