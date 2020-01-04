DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_RemoveCategoryFromProject`(inProjectCategoryId int)
BEGIN

DELETE FROM `tdt`.`projectcategories`
WHERE Id = inProjectCategoryId;


END$$
DELIMITER ;
