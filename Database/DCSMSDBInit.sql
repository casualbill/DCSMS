/*

SQLyog Ultimate v8.53 
MySQL - 5.5.19 : Database - desouttercsms

*********************************************************************

*/



/*!40101 SET NAMES utf8 */;



/*!40101 SET SQL_MODE=''*/;



/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;

/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;

/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

CREATE DATABASE /*!32312 IF NOT EXISTS*/`desouttercsms` /*!40100 DEFAULT CHARACTER SET utf8 */;



USE `desouttercsms`;



/*Table structure for table `citylist` */



DROP TABLE IF EXISTS `citylist`;



CREATE TABLE `citylist` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `City` varchar(20) NOT NULL DEFAULT '',
  `ProvinceId` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;



/*Table structure for table `customerinfo` */



DROP TABLE IF EXISTS `customerinfo`;



CREATE TABLE `customerinfo` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CustomerName` varchar(100) NOT NULL DEFAULT '',
  `EndCustomerName` varchar(100) NOT NULL DEFAULT '',
  `ContactPerson` varchar(50) NOT NULL DEFAULT '',
  `Telephone` varchar(20) DEFAULT NULL,
  `Mobile` varchar(20) DEFAULT NULL,
  `Address` varchar(100) DEFAULT NULL,
  `PostCode` varchar(10) DEFAULT NULL,
  `Remark` varchar(300) DEFAULT NULL,
  `Verified` bit(1) NOT NULL DEFAULT b'0',
  `CityId` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;



/*Table structure for table `imageinfo` */



DROP TABLE IF EXISTS `imageinfo`;



CREATE TABLE `imageinfo` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `FileUrl` varchar(300) NOT NULL DEFAULT '',
  `OrderId` char(9) NOT NULL DEFAULT '',
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;




/*Table structure for table `inspectionresult` */



DROP TABLE IF EXISTS `inspectionresult`;



CREATE TABLE `inspectionresult` (
  `OrderId` char(9) NOT NULL DEFAULT '',
  `Item1` tinyint(3) DEFAULT NULL,
  `Item2` tinyint(3) DEFAULT NULL,
  `Item3` tinyint(3) DEFAULT NULL,
  `Item4` tinyint(3) DEFAULT NULL,
  `Item5` tinyint(3) DEFAULT NULL,
  `Item6` tinyint(3) DEFAULT NULL,
  `Item7` tinyint(3) DEFAULT NULL,
  `Item8` tinyint(3) DEFAULT NULL,
  `Comment1` varchar(300) DEFAULT NULL,
  `Comment2` varchar(300) DEFAULT NULL,
  `Comment3` varchar(300) DEFAULT NULL,
  `Comment4` varchar(300) DEFAULT NULL,
  `Comment5` varchar(300) DEFAULT NULL,
  `Comment6` varchar(300) DEFAULT NULL,
  `Comment7` varchar(300) DEFAULT NULL,
  `Comment8` varchar(300) DEFAULT NULL,
  PRIMARY KEY (`OrderId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;



/*Table structure for table `orderinfo` */



DROP TABLE IF EXISTS `orderinfo`;



CREATE TABLE `orderinfo` (
  `Id` char(9) NOT NULL DEFAULT '',
  `FailureDescription` varchar(500) DEFAULT NULL,
  `Remark` varchar(500) DEFAULT NULL,
  `WorkType` int(11) NOT NULL DEFAULT '0',
  `CreateTime` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  `UpdateTime` datetime DEFAULT NULL,
  `CreateUserId` int(11) NOT NULL DEFAULT '0',
  `TechnicianId` int(11) NOT NULL DEFAULT '0',
  `AdminId` int(11) DEFAULT NULL,
  `CustomerId` int(11) NOT NULL DEFAULT '0',
  `StationId` int(11) NOT NULL DEFAULT '0',
  `OrderStatus` tinyint(3) NOT NULL DEFAULT '0',
  `IsPublic` bit(1) NOT NULL DEFAULT b'0',
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;



/*Table structure for table `orderlog` */



DROP TABLE IF EXISTS `orderlog`;



CREATE TABLE `orderlog` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `OrderId` char(9) NOT NULL DEFAULT '',
  `UserId` int(11) NOT NULL DEFAULT '0',
  `FormerStatus` tinyint(3) NOT NULL DEFAULT '0',
  `NewStatus` tinyint(3) DEFAULT NULL,
  `OperateTime` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  PRIMARY KEY (`Id`),
  KEY `OperateTime` (`OperateTime`)
) ENGINE=MyISAM AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;



/*Table structure for table `productinfo` */



DROP TABLE IF EXISTS `productinfo`;



CREATE TABLE `productinfo` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `ProductName` varchar(50) NOT NULL DEFAULT '',
  `SerialNumber` varchar(30) NOT NULL DEFAULT '',
  `OrderingNumber` varchar(30) NOT NULL DEFAULT '',
  `CycleCounters` varchar(50) DEFAULT NULL,
  `FirmwareVersion` varchar(20) DEFAULT NULL,
  `Remark` varchar(300) DEFAULT NULL,
  `ToolType` tinyint(3) NOT NULL DEFAULT '0',
  `OrderId` char(9) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;



/*Table structure for table `provincelist` */



DROP TABLE IF EXISTS `provincelist`;



CREATE TABLE `provincelist` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Province` varchar(20) NOT NULL DEFAULT '',
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;



/*Table structure for table `repairlog` */



DROP TABLE IF EXISTS `repairlog`;



CREATE TABLE `repairlog` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `StartTime` datetime DEFAULT NULL,
  `EndTime` datetime DEFAULT NULL,
  `WorkDetail` varchar(300) DEFAULT NULL,
  `DefaultCharacter` varchar(300) DEFAULT NULL,
  `WorkTime` varchar(10) DEFAULT NULL,
  `OrderId` char(9) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;



/*Table structure for table `sparepartinfo` */



DROP TABLE IF EXISTS `sparepartinfo`;



CREATE TABLE `sparepartinfo` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `SparePartName` varchar(50) NOT NULL DEFAULT '',
  `OrderingNumber` varchar(30) NOT NULL DEFAULT '',
  `Amount` int(11) NOT NULL DEFAULT '0',
  `Remark` varchar(300) DEFAULT NULL,
  `OrderId` char(9) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=1 DEFAULT CHARSET=utf8;



/*Table structure for table `stationinfo` */



DROP TABLE IF EXISTS `stationinfo`;



CREATE TABLE `stationinfo` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `StationName` varchar(50) NOT NULL DEFAULT '',
  `StationCode` char(2) NOT NULL DEFAULT '',
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;



/*Data for the table `stationinfo` */



insert  into `stationinfo`(`Id`,`StationName`,`StationCode`) values (1,'驻场服务','OS'),(2,'上海维修站','DS'),(3,'现场服务','FS');



/*Table structure for table `toolfunctiontest` */



DROP TABLE IF EXISTS `toolfunctiontest`;



CREATE TABLE `toolfunctiontest` (
  `OrderId` char(9) NOT NULL DEFAULT '',
  `Item1` tinyint(3) DEFAULT NULL,
  `Item2` tinyint(3) DEFAULT NULL,
  `Item3` tinyint(3) DEFAULT NULL,
  `Item4` tinyint(3) DEFAULT NULL,
  `Item5` tinyint(3) DEFAULT NULL,
  `Item6` tinyint(3) DEFAULT NULL,
  `Comment1` varchar(300) DEFAULT NULL,
  `Comment2` varchar(300) DEFAULT NULL,
  `Comment3` varchar(300) DEFAULT NULL,
  `Comment4` varchar(300) DEFAULT NULL,
  `Comment5` varchar(300) DEFAULT NULL,
  `Comment6` varchar(300) DEFAULT NULL,
  PRIMARY KEY (`OrderId`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;



/*Table structure for table `userinfo` */



DROP TABLE IF EXISTS `userinfo`;



CREATE TABLE `userinfo` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserName` varchar(50) NOT NULL DEFAULT '',
  `Password` char(32) NOT NULL DEFAULT '',
  `RealName` varchar(50) NOT NULL DEFAULT '',
  `EmpCode` varchar(20) DEFAULT NULL,
  `Telephone` varchar(20) DEFAULT NULL,
  `Email` varchar(50) DEFAULT NULL,
  `UserType` tinyint(3) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;



/*Data for the table `userinfo` */



insert  into `userinfo`(`Id`,`UserName`,`Password`,`RealName`,`EmpCode`,`Telephone`,`Email`,`UserType`) values (1,'admin','3e709bb5f00b519a','admin',NULL,NULL,NULL,5),(9,'casualbill','ca68890ba6dd056f','Casual Bill',NULL,NULL,NULL,5);



/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;

/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;

/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;

/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

