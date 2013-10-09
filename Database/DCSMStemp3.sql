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
) ENGINE=MyISAM AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;

/*Data for the table `customerinfo` */

insert  into `customerinfo`(`Id`,`CustomerName`,`EndCustomerName`,`ContactPerson`,`Telephone`,`Mobile`,`Address`,`PostCode`,`Remark`,`Verified`) values (1,'cn','ecn','cp','66666666','12345678901',NULL,'200001','adfarg ae5y hhwhtht',''),(2,'cnnnn','ecn','cp','232323','124','','100002','testeset remak','\0'),(3,'1','','1','','',NULL,'','',''),(4,'2','','1','','',NULL,'','',''),(5,'111','','1','','',NULL,'','','\0'),(6,'IS-7','','1','4234324','',NULL,'','tk',''),(7,'T29','','1','','',NULL,'','tk',''),(8,'Foch 155','','1','','17616',NULL,'','tk',''),(9,'Maus','','1','2646','',NULL,'','tk',''),(10,'T-62A','','1','','',NULL,'','tk','\0'),(12,'FCM50t','franch','fcm','1232123232','2626','YQ2adfdfd','00332','tk',''),(13,'customerNew','','newps','','','','','','\0'),(14,'customerNew','','newps','','','','','','\0');

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

insert  into `orderinfo`(`Id`,`FailureDescription`,`ImgUrl`,`Remark`,`WorkType`,`CreateTime`,`UpdateTime`,`CreateUserId`,`TechnicianId`,`AdminId`,`CustomerId`,`StationId`,`OrderStatus`) values ('OS1300001','','','remark1..log',1,'2013-10-09 14:51:15','2013-10-09 18:32:21',13,15,1,12,1,7),('OS1300002',NULL,NULL,'',2,'2013-10-09 15:04:00',NULL,13,10,0,13,1,1),('OS1300003',NULL,NULL,'',2,'2013-10-09 15:19:04',NULL,13,10,0,9,1,2),('OS1300004',NULL,NULL,'',2,'2013-10-09 15:29:56',NULL,13,10,0,9,1,2),('SH1300002',NULL,NULL,'',2,'2013-10-09 15:30:16',NULL,13,11,0,9,2,2);

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
) ENGINE=MyISAM AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

/*Data for the table `orderlog` */

insert  into `orderlog`(`Id`,`OrderId`,`UserId`,`FormerStatus`,`NewStatus`,`OperateTime`) values (9,'OS1300001',13,2,7,'2013-10-09 18:32:21');

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
) ENGINE=MyISAM AUTO_INCREMENT=16 DEFAULT CHARSET=utf8;

/*Data for the table `productinfo` */

insert  into `productinfo`(`Id`,`ProductName`,`SerialNumber`,`OrderingNumber`,`CycleCounters`,`FirmwareVersion`,`Remark`,`OrderId`) values (13,'Product-A2','PA2-002','ORDERPA2002','','2.4','','OS1300003'),(12,'Product-A2','PA2-001','ORDERPA2001','','2.4','','OS1300002'),(9,'Product-A2','PA2-001','ORDERPA2001','','2.6','','OS1300001'),(14,'Product-A2','PA2-002','ORDERPA2003','','2.4','','OS1300004'),(15,'Product-A3','PA3-001','ORDERPA3001','','2.4','','SH1300002');

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

insert  into `userinfo`(`Id`,`UserName`,`Password`,`RealName`,`EmpCode`,`Telephone`,`Email`,`UserType`) values (1,'adf','12312321','aa',NULL,NULL,NULL,1),(9,'admin','965eb72c92a549dd','AdMin',NULL,'121212121',NULL,5),(10,'kenny','965eb72c92a549dd','yqw','39','76453',NULL,2),(11,'johnnyrscdd','965eb72c92a549dd','fdddd','238','585758416','fdd@dd.dd',2),(12,'adong','965eb72c92a549dd','dong',NULL,NULL,NULL,5),(13,'vivas','965eb72c92a549dd','brain','112',NULL,NULL,3),(14,'patton','965eb72c92a549dd','m46','46',NULL,NULL,4),(15,'pershing','965eb72c92a549dd','m26','26',NULL,NULL,2),(16,'maus','965eb72c92a549dd','rat',NULL,NULL,NULL,2),(17,'conq','965eb72c92a549dd','c',NULL,NULL,NULL,3),(18,'panther','965eb72c92a549dd','pz',NULL,NULL,NULL,2),(19,'hellcat','111111','m16','16','1345678909','hellcat@wot.com',4);

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
