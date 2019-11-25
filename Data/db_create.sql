CREATE DATABASE `tdtdata` /*!40100 DEFAULT CHARACTER SET latin1 */;
CREATE TABLE `Categories` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CategoryName` varchar(100) DEFAULT NULL,
  `HighLevelCategory` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;
CREATE TABLE `Districts` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` longtext NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=82 DEFAULT CHARSET=utf8;
CREATE TABLE `Funders` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` longtext NOT NULL,
  `Address1` longtext,
  `Address2` longtext,
  `Address3` longtext,
  `Town` longtext,
  `County` longtext,
  `PostCode` longtext,
  `Tel` longtext,
  `MainContact` longtext NOT NULL,
  `Amount` decimal(19,4) DEFAULT '0.0000',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=28 DEFAULT CHARSET=utf8;
CREATE TABLE `NGOs` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` longtext NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=135 DEFAULT CHARSET=utf8;
CREATE TABLE `OtherBodies` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` longtext NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

CREATE TABLE `ProjectOfficers` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FirstName` longtext NOT NULL,
  `LastName` longtext NOT NULL,
  `Tel` longtext,
  `Mobile` longtext,
  `Email` longtext,
  `Address1` longtext,
  `Address2` longtext,
  `Address3` longtext,
  `Town` longtext,
  `County` longtext,
  `PostCode` longtext,
  `Image` longblob,
  `Info` longtext,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=1020 DEFAULT CHARSET=utf8;

CREATE TABLE `ProjectStatusCodes` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `StatusCode` longtext NOT NULL,
  `Description` longtext NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8;

CREATE TABLE `Regions` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` longtext NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=32 DEFAULT CHARSET=utf8;

CREATE TABLE `Projects` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ProjectIdentifier` longtext NOT NULL,
  `ProjectName` longtext NOT NULL,
  `ApplicationDate` datetime DEFAULT NULL,
  `AmountGrantRequested` bigint(20) DEFAULT NULL,
  `AmountGrantApproved` bigint(20) DEFAULT NULL,
  `DateGrantApproved` datetime DEFAULT NULL,
  `AmountGrantPaid` bigint(20) DEFAULT NULL,
  `DateGrantPaid` datetime DEFAULT NULL,
  `ProjectDescription` longtext,
  `StatusCode_Id` int(11) NOT NULL,
  `StatusDescription` longtext,
  `ProjOfficerRecommendation` longtext,
  `TargetCompletionDate` datetime DEFAULT NULL,
  `Region_Id` int(11) NOT NULL,
  `District_Id` int(11) DEFAULT NULL,
  `Keywords` longtext,
  `Summary` longtext,
  `ProjOfficer_Id` int(11) DEFAULT NULL,
  `Problems` longtext,
  `StatusCodeDate` date DEFAULT NULL,
  `StrengthsWeaknesses` longtext,
  `FinanceOtherFunders` longtext,
  `LocalContribution` longtext,
  `WebSitePicture` longblob,
  `WebSitePictureDescription` longtext,
  `Latitude` decimal(18,12) DEFAULT NULL,
  `Longitude` decimal(18,12) DEFAULT NULL,
  `DocumentsUrl` longtext,
  `PublicDocumentsUrl` longtext,
  `ImpactOfProject` longtext,
  `LastUpdated` datetime DEFAULT NULL,
  `TotalProjectCost` decimal(19,4) DEFAULT NULL,
  `LastUpdatedBy` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_DistrictsProjects` (`District_Id`),
  KEY `FK_ProjectOfficersProjects` (`ProjOfficer_Id`),
  KEY `FK_ProjectStatusCodesProjects` (`StatusCode_Id`),
  KEY `FK_RegionsProjects` (`Region_Id`),
  CONSTRAINT `FK_DistrictsProjects` FOREIGN KEY (`District_Id`) REFERENCES `Districts` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_ProjectOfficersProjects` FOREIGN KEY (`ProjOfficer_Id`) REFERENCES `ProjectOfficers` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_ProjectStatusCodesProjects` FOREIGN KEY (`StatusCode_Id`) REFERENCES `ProjectStatusCodes` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_RegionsProjects` FOREIGN KEY (`Region_Id`) REFERENCES `Regions` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=1608 DEFAULT CHARSET=utf8;

CREATE TABLE `ProjectCategories` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Project_Id` int(11) NOT NULL,
  `Category_Id` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_ProjectCategories_Projects` (`Project_Id`),
  KEY `FK_ProjectCategories_Categories` (`Category_Id`),
  CONSTRAINT `FK_ProjectCategories_Categories` FOREIGN KEY (`Category_Id`) REFERENCES `Categories` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_ProjectCategories_Projects` FOREIGN KEY (`Project_Id`) REFERENCES `Projects` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;

CREATE TABLE `ProjectDocs` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Project_Id` int(11) NOT NULL,
  `DocName` longtext NOT NULL,
  `FilePath` longtext NOT NULL,
  `Description` longtext,
  `DocCategory` longtext NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_ProjectsProjectDocs` (`Project_Id`),
  CONSTRAINT `FK_ProjectsProjectDocs` FOREIGN KEY (`Project_Id`) REFERENCES `Projects` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2009 DEFAULT CHARSET=utf8;

CREATE TABLE `ProjectFunders` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Project_Id` int(11) NOT NULL,
  `Funder_Id` int(11) NOT NULL,
  `AmountFunded` decimal(19,4) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_FunderProjectFunders` (`Funder_Id`),
  KEY `FK_ProjectProjectFunders` (`Project_Id`),
  CONSTRAINT `FK_FunderProjectFunders` FOREIGN KEY (`Funder_Id`) REFERENCES `Funders` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_ProjectProjectFunders` FOREIGN KEY (`Project_Id`) REFERENCES `Projects` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=46 DEFAULT CHARSET=utf8;

CREATE TABLE `ProjectNGOs` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Project_Id` int(11) NOT NULL,
  `NGO_Id` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_NGOProjectNGOs` (`NGO_Id`),
  KEY `FK_ProjectProjectNGOs` (`Project_Id`),
  CONSTRAINT `FK_NGOProjectNGOs` FOREIGN KEY (`NGO_Id`) REFERENCES `NGOs` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_ProjectProjectNGOs` FOREIGN KEY (`Project_Id`) REFERENCES `Projects` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=162 DEFAULT CHARSET=utf8;

CREATE TABLE `ProjectOtherBodies` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Project_Id` int(11) NOT NULL,
  `OtherBody_Id` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_OtherBodyProjectOtherBodies` (`OtherBody_Id`),
  KEY `FK_ProjectProjectOtherBodies` (`Project_Id`),
  CONSTRAINT `FK_OtherBodyProjectOtherBodies` FOREIGN KEY (`OtherBody_Id`) REFERENCES `OtherBodies` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `FK_ProjectProjectOtherBodies` FOREIGN KEY (`Project_Id`) REFERENCES `Projects` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

CREATE TABLE `PurchasedItems` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Project_Id` int(11) NOT NULL,
  `PurchasedItem` longtext NOT NULL,
  `DatePurchased` datetime NOT NULL,
  `ItemCost` decimal(19,4) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_FK_ProjectPurchasedItems` (`Project_Id`),
  CONSTRAINT `FK_ProjectPurchasedItems` FOREIGN KEY (`Project_Id`) REFERENCES `Projects` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8;

CREATE TABLE `RelatedProjects` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Project_Id` int(11) NOT NULL,
  `RelationshipKey` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_ProjectRelatedProject` (`Project_Id`),
  CONSTRAINT `FK_ProjectRelatedProject` FOREIGN KEY (`Project_Id`) REFERENCES `Projects` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=111 DEFAULT CHARSET=utf8;

CREATE TABLE `VisitDates` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Project_Id` int(11) NOT NULL,
  `VisitDateStart` datetime NOT NULL,
  `VisitDateEnd` datetime NOT NULL,
  `Visitor` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `FK_ProjectVisitDates` (`Project_Id`),
  CONSTRAINT `FK_ProjectVisitDates` FOREIGN KEY (`Project_Id`) REFERENCES `Projects` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=150 DEFAULT CHARSET=utf8;
