DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_AddCategoryToProject`(inProjectId int, inCategoryId int)
BEGIN
INSERT INTO `tdt`.`projectcategories`
(`Project_Id`,
`Category_Id`)
VALUES
(inProjectId,
inCategoryId);


END$$
DELIMITER ;
