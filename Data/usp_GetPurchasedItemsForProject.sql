DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_GetPurchasedItemsForProject`(inProjectId int)
BEGIN

SELECT `purchaseditems`.`Id`,
    `purchaseditems`.`Project_Id`,
    `purchaseditems`.`PurchasedItem`,
    `purchaseditems`.`DatePurchased`,
    `purchaseditems`.`ItemCost`
FROM `tdt`.`purchaseditems`
WHERE Project_Id = inProjectId;


END$$
DELIMITER ;
