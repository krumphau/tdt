DELIMITER $$
drop procedure if exists `usp_SearchProjects`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `usp_SearchProjects` (inIdentifier varchar(255), inRegionID int, inName nvarchar(255), inNGOId int, Keywords nvarchar(255), inOfficerId int, inStatusCode int, inFunderId int)
BEGIN

SELECT Keywords;

SELECT `projects`.`Id`,
    `projects`.`ProjectIdentifier`,
    `projects`.`ProjectName`,
    `projects`.`ApplicationDate`,
    `projects`.`AmountGrantRequested`,
    `projects`.`AmountGrantApproved`,
    `projects`.`DateGrantApproved`,
    `projects`.`AmountGrantPaid`,
    `projects`.`DateGrantPaid`,
    `projects`.`ProjectDescription`,
    `projects`.`StatusCode_Id`,
    `projects`.`StatusDescription`,
    `projects`.`ProjOfficerRecommendation`,
    `projects`.`TargetCompletionDate`,
    `projects`.`Region_Id`,
    `projects`.`District_Id`,
    `projects`.`Keywords`,
    `projects`.`Summary`,
    `projects`.`ProjOfficer_Id`,
    `projects`.`Problems`,
    `projects`.`StatusCodeDate`,
    `projects`.`StrengthsWeaknesses`,
    `projects`.`FinanceOtherFunders`,
    `projects`.`LocalContribution`,
    `projects`.`WebSitePicture`,
    `projects`.`WebSitePictureDescription`,
    `projects`.`Latitude`,
    `projects`.`Longitude`,
    `projects`.`DocumentsUrl`,
    `projects`.`PublicDocumentsUrl`,
    `projects`.`ImpactOfProject`,
    `projects`.`LastUpdated`,
    `projects`.`TotalProjectCost`,
    `projects`.`LastUpdatedBy`
FROM `tdt`.`projects`
WHERE (inIdentifier = '' OR `projects`.`ProjectIdentifier` = inIdentifier)
AND (inRegionID = 0 OR `projects`.`Region_Id` = inRegionID)
AND (inName = '' OR `projects`.`ProjectName` = inName)
AND (inNGOId = 0 OR EXISTS (select 1 from projectngos where Project_Id = `projects`.`Id` AND NGO_Id = inNGOId))
AND (Keywords = '' OR `projects`.`Keywords` LIKE CONCAT('%', Keywords, '%')) -- need to look at this behaviour
AND (inOfficerId = 0 OR `projects`.`ProjOfficer_Id` = inOfficerId)
AND (inStatusCode = 0 OR `projects`.`StatusCode_Id` = inStatusCode)
AND (inFunderId = 0 OR EXISTS( select 1 from projectfunders where Project_Id = `projects`.`Id` AND Funder_Id = inFunderId));

END$$
DELIMITER ;
