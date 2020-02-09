DELIMITER $$
DROP PROCEDURE IF EXISTS `usp_GetCategoriesForProject` $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_GetCategoriesForProject`(inProjectId int)
BEGIN

SELECT p.`Id`,
   p.`Project_Id`,
    p.`Category_Id`,
    c.`CategoryName`
FROM `tdt`.`projectcategories` p, `tdt`.`categories` c
WHERE p.Category_Id = c.Id
  AND p.Project_Id = inProjectId;


END$$
DELIMITER ;
