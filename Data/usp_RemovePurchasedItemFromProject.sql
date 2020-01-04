DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_RemovePurchasedItemFromProject`(inPurchasedItemId int)
BEGIN

DELETE FROM `tdt`.`purchaseditems`
WHERE Id = inPurchasedItemId;


END$$
DELIMITER ;
