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

/*Table structure for table `customerinfo` */

DROP TABLE IF EXISTS `customerinfo`;

CREATE TABLE `customerinfo` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `CustomerName` varchar(100) NOT NULL DEFAULT '',
  `EndCustomerName` varchar(100) DEFAULT NULL,
  `ContactPerson` varchar(50) NOT NULL DEFAULT '',
  `Telephone` varchar(20) DEFAULT NULL,
  `Mobile` varchar(20) DEFAULT NULL,
  `Address` varchar(100) DEFAULT NULL,
  `PostCode` varchar(10) DEFAULT NULL,
  `Remark` varchar(300) DEFAULT NULL,
  `Verified` bit(1) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;

/*Data for the table `customerinfo` */

insert  into `customerinfo`(`Id`,`CustomerName`,`EndCustomerName`,`ContactPerson`,`Telephone`,`Mobile`,`Address`,`PostCode`,`Remark`,`Verified`) values (1,'cn','ecn','cp','66666666','12345678901',NULL,'200001','adfarg ae5y hhwhtht',''),(2,'cnnnn','ecn','cp','232323','124','','100002','testeset remak','\0'),(3,'1','','1','','',NULL,'','',''),(4,'2','','1','','',NULL,'','',''),(5,'111','','1','','',NULL,'','','\0'),(6,'IS-7','','1','4234324','',NULL,'','tk',''),(7,'T29','','1','','',NULL,'','tk',''),(8,'Foch 155','','1','','17616',NULL,'','tk',''),(9,'Maus','','1','2646','',NULL,'','tk',''),(10,'T-62A','','1','','',NULL,'','tk','\0'),(12,'FCM50t','franch','fcm','1232123232','2626','YQ2adfdfd','00332','tk','');

/*Table structure for table `orderinfo` */

DROP TABLE IF EXISTS `orderinfo`;

CREATE TABLE `orderinfo` (
  `Id` char(9) NOT NULL DEFAULT '',
  `FailureDescription` varchar(500) DEFAULT NULL,
  `ImgUrl` varchar(300) DEFAULT NULL,
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
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `orderinfo` */

/*Table structure for table `orderlog` */

DROP TABLE IF EXISTS `orderlog`;

CREATE TABLE `orderlog` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `OrderId` varchar(20) NOT NULL DEFAULT '',
  `UserId` int(11) NOT NULL DEFAULT '0',
  `FormerStatus` tinyint(3) NOT NULL DEFAULT '0',
  `NewStatus` tinyint(3) DEFAULT NULL,
  `OperateTime` datetime NOT NULL DEFAULT '0000-00-00 00:00:00',
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

/*Data for the table `orderlog` */

insert  into `orderlog`(`Id`,`OrderId`,`UserId`,`FormerStatus`,`NewStatus`,`OperateTime`) values (1,'131006121438272',10,1,NULL,'2013-10-06 00:14:38'),(2,'131006024745476',10,1,NULL,'2013-10-06 14:47:45'),(3,'131006024805262',10,1,NULL,'2013-10-06 14:48:05'),(4,'131006024820814',16,1,NULL,'2013-10-06 14:48:20'),(5,'131006024838428',14,1,NULL,'2013-10-06 14:48:38'),(6,'131006024858170',11,1,NULL,'2013-10-06 14:48:58'),(7,'131006040329394',11,1,NULL,'2013-10-06 16:03:29'),(8,'131006160643775',11,1,NULL,'2013-10-06 16:06:43');

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
  `OrderId` varchar(20) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

/*Data for the table `productinfo` */

insert  into `productinfo`(`Id`,`ProductName`,`SerialNumber`,`OrderingNumber`,`CycleCounters`,`FirmwareVersion`,`Remark`,`OrderId`) values (1,'Product1','p111','p11101','','8.8','first product','131006121438272'),(2,'Product2','p222','p22201','','8.8','','131006024745476'),(3,'Product2','p222','p22202','','8.8','','131006024805262'),(4,'Product2','p222','p22203','','8.8','','131006024820814'),(5,'Product2','p222','p22204','','8.8','','131006024838428'),(6,'Product3','p333','p3331','','8.8','','131006024858170'),(7,'Product4','p444','p4441','','8.84','','131006040329394'),(8,'Product4','p444','p4442','','8.84','','131006160643775');

/*Table structure for table `repairlog` */

DROP TABLE IF EXISTS `repairlog`;

CREATE TABLE `repairlog` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `StartTime` datetime DEFAULT NULL,
  `EndTime` datetime DEFAULT NULL,
  `WorkDetail` varchar(300) DEFAULT NULL,
  `OrderId` varchar(20) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `repairlog` */

/*Table structure for table `sparepartinfo` */

DROP TABLE IF EXISTS `sparepartinfo`;

CREATE TABLE `sparepartinfo` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `SparePartName` varchar(50) NOT NULL DEFAULT '',
  `OrderingNumber` varchar(30) NOT NULL DEFAULT '',
  `Amount` int(11) NOT NULL DEFAULT '0',
  `Remark` varchar(300) DEFAULT NULL,
  `OrderId` varchar(20) NOT NULL DEFAULT '0',
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

/*Data for the table `sparepartinfo` */

insert  into `sparepartinfo`(`Id`,`SparePartName`,`OrderingNumber`,`Amount`,`Remark`,`OrderId`) values (1,'SparePart1','sp111',3,'first spare part','131006121438272'),(2,'SparePart2','sp22201',3,'','131006024745476'),(3,'SparePart2','sp22202',2,'','131006024805262'),(4,'SparePart2','sp22203',2,'','131006024820814'),(5,'SparePart2','sp22204',2,'','131006024838428'),(6,'SparePart3','sp3331',5,'','131006024858170'),(7,'SparePart3','sp3331',1,'','131006040329394'),(8,'SparePart3','sp3332',1,'','131006160643775');

/*Table structure for table `stationinfo` */

DROP TABLE IF EXISTS `stationinfo`;

CREATE TABLE `stationinfo` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `StationName` varchar(50) NOT NULL DEFAULT '',
  `StationCode` char(2) NOT NULL DEFAULT '',
  PRIMARY KEY (`Id`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

/*Data for the table `stationinfo` */

insert  into `stationinfo`(`Id`,`StationName`,`StationCode`) values (1,'现场维修','OS'),(2,'上海','SH');

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
) ENGINE=MyISAM AUTO_INCREMENT=20 DEFAULT CHARSET=utf8;

/*Data for the table `userinfo` */

insert  into `userinfo`(`Id`,`UserName`,`Password`,`RealName`,`EmpCode`,`Telephone`,`Email`,`UserType`) values (1,'adf','12312321','aa',NULL,NULL,NULL,1),(9,'admin','965eb72c92a549dd','AdMin',NULL,'121212121',NULL,5),(10,'kenny','965eb72c92a549dd','yqw','39','76453',NULL,1),(11,'johnnyrscdd','965eb72c92a549dd','fdddd','238','585758416','fdd@dd.dd',3),(12,'adong','965eb72c92a549dd','dong',NULL,NULL,NULL,5),(13,'vivas','965eb72c92a549dd','brain','112',NULL,NULL,3),(14,'patton','965eb72c92a549dd','m46','46',NULL,NULL,4),(15,'pershing','965eb72c92a549dd','m26','26',NULL,NULL,2),(16,'maus','965eb72c92a549dd','rat',NULL,NULL,NULL,2),(17,'conq','965eb72c92a549dd','c',NULL,NULL,NULL,3),(18,'panther','965eb72c92a549dd','pz',NULL,NULL,NULL,2),(19,'hellcat','111111','m16','16','1345678909','hellcat@wot.com',4);

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
