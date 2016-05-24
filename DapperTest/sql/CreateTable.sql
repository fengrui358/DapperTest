﻿CREATE TABLE `area` (
	`AreaId` INT(11) NOT NULL AUTO_INCREMENT,
	`AreaName` VARCHAR(50) NULL DEFAULT NULL,
	`AreaDes` VARCHAR(250) NULL DEFAULT NULL,
	`ParentAreaId` INT(11) NULL DEFAULT NULL,
	`FullName` VARCHAR(250) NULL DEFAULT NULL,
	`CreateTime` DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
	`RowIdentity` VARCHAR(36) NULL DEFAULT NULL,
	PRIMARY KEY (`AreaId`),
	INDEX `AreaName` (`AreaName`)
)
COLLATE='utf8_general_ci'
ENGINE=MyISAM;