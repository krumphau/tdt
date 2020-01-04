DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_AddPurchasedItemToProject`(inProjectId int,
                                                                inPurchasedItem longtext,
																inDatePurchased datetime,
																inItemCost decimal)
BEGIN

	INSERT INTO `tdt`.`purchaseditems`
		(`Project_Id`,
		`PurchasedItem`,
		`DatePurchased`,
		`ItemCost`)
		VALUES
		(inProject_Id,
		inPurchasedItem,
		inDatePurchased,
		inItemCost);

END$$
DELIMITER ;
