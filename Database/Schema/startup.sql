-- MySQL dump 10.13  Distrib 5.6.23, for Win64 (x86_64)
--
-- Host: us-cdbr-azure-east-b.cloudapp.net    Database: levelspropackagedbstaging
-- ------------------------------------------------------
-- Server version	5.5.42-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `awardperformance`
--

DROP TABLE IF EXISTS `awardperformance`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `awardperformance` (
  `AwardID` int(11) DEFAULT NULL,
  `UserID` int(11) DEFAULT NULL,
  `KPIID` int(11) DEFAULT NULL,
  `Value` int(11) DEFAULT NULL,
  `LastUpdated` datetime DEFAULT NULL,
  `AP_ID` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`AP_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `awardperformance`
--

LOCK TABLES `awardperformance` WRITE;
/*!40000 ALTER TABLE `awardperformance` DISABLE KEYS */;
/*!40000 ALTER TABLE `awardperformance` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `contestperformance`
--

DROP TABLE IF EXISTS `contestperformance`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `contestperformance` (
  `CP_ID` int(11) NOT NULL AUTO_INCREMENT,
  `ContestID` int(11) DEFAULT NULL,
  `UserID` int(11) DEFAULT NULL,
  `KPIID` int(11) DEFAULT NULL,
  `Value` int(11) DEFAULT NULL,
  `LastUpdated` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`CP_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contestperformance`
--

LOCK TABLES `contestperformance` WRITE;
/*!40000 ALTER TABLE `contestperformance` DISABLE KEYS */;
/*!40000 ALTER TABLE `contestperformance` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `daily_report`
--

DROP TABLE IF EXISTS `daily_report`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `daily_report` (
  `id` int(11) NOT NULL,
  `year` int(5) NOT NULL,
  `month` int(2) DEFAULT NULL,
  `day` int(2) DEFAULT NULL,
  `total_emplyees` int(11) DEFAULT NULL,
  `total_managers` int(11) DEFAULT NULL,
  `total_sales` int(11) DEFAULT NULL,
  `total_hours_worked` int(11) DEFAULT NULL,
  `total_hours_login` int(11) DEFAULT NULL,
  `total_number_login` int(11) DEFAULT NULL,
  `total_questions` int(11) DEFAULT NULL,
  `total_quizzes` int(11) DEFAULT NULL,
  `total_levels` int(11) DEFAULT NULL,
  `total_sites` int(11) DEFAULT NULL,
  `total_roles` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `daily_report`
--

LOCK TABLES `daily_report` WRITE;
/*!40000 ALTER TABLE `daily_report` DISABLE KEYS */;
/*!40000 ALTER TABLE `daily_report` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `event_report`
--

DROP TABLE IF EXISTS `event_report`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `event_report` (
  `Id` int(11) NOT NULL,
  `userid` int(11) DEFAULT NULL,
  `entry_date` datetime DEFAULT NULL,
  `description` varchar(50) DEFAULT NULL,
  `area` varchar(25) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `userid` (`userid`),
  CONSTRAINT `userid` FOREIGN KEY (`userid`) REFERENCES `tbluser` (`UserID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `event_report`
--

LOCK TABLES `event_report` WRITE;
/*!40000 ALTER TABLE `event_report` DISABLE KEYS */;
/*!40000 ALTER TABLE `event_report` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `events_history`
--

DROP TABLE IF EXISTS `events_history`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `events_history` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` int(11) NOT NULL,
  `entry_date` datetime DEFAULT NULL,
  `description` varchar(45) DEFAULT NULL,
  `area` varchar(45) DEFAULT NULL,
  `active` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `events_history`
--

LOCK TABLES `events_history` WRITE;
/*!40000 ALTER TABLE `events_history` DISABLE KEYS */;
/*!40000 ALTER TABLE `events_history` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `kpi_history`
--

DROP TABLE IF EXISTS `kpi_history`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `kpi_history` (
  `Id` int(11) NOT NULL,
  `User_ID` int(11) DEFAULT NULL,
  `Level_ID` int(11) DEFAULT NULL,
  `KPI_ID` int(11) DEFAULT NULL,
  `Start_Date` datetime DEFAULT NULL,
  `Finish_Date` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `User_ID` (`User_ID`),
  KEY `Level_ID` (`Level_ID`),
  KEY `KPI_ID` (`KPI_ID`),
  CONSTRAINT `KPI_ID` FOREIGN KEY (`KPI_ID`) REFERENCES `tblkpi` (`KPI_ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `Level_ID` FOREIGN KEY (`Level_ID`) REFERENCES `tbllevel` (`Level_ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `User_ID` FOREIGN KEY (`User_ID`) REFERENCES `tbluser` (`UserID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `kpi_history`
--

LOCK TABLES `kpi_history` WRITE;
/*!40000 ALTER TABLE `kpi_history` DISABLE KEYS */;
/*!40000 ALTER TABLE `kpi_history` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `level_history`
--

DROP TABLE IF EXISTS `level_history`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `level_history` (
  `Id` int(11) NOT NULL,
  `Level_ID_level` int(11) DEFAULT NULL,
  `User_ID_Level` int(11) DEFAULT NULL,
  `start_date` datetime DEFAULT NULL,
  `finish_date` datetime DEFAULT NULL,
  `Duration` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `User_ID_Level` (`User_ID_Level`),
  KEY `Level_ID_level` (`Level_ID_level`),
  CONSTRAINT `Level_ID_level` FOREIGN KEY (`Level_ID_level`) REFERENCES `tbllevel` (`Level_ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `User_ID_Level` FOREIGN KEY (`User_ID_Level`) REFERENCES `tbluser` (`UserID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `level_history`
--

LOCK TABLES `level_history` WRITE;
/*!40000 ALTER TABLE `level_history` DISABLE KEYS */;
/*!40000 ALTER TABLE `level_history` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `login_duration`
--

DROP TABLE IF EXISTS `login_duration`;
/*!50001 DROP VIEW IF EXISTS `login_duration`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `login_duration` AS SELECT 
 1 AS `start_id`,
 1 AS `start_date`,
 1 AS `finish_id`,
 1 AS `finish_date`,
 1 AS `duration_minutes`,
 1 AS `duration_hours`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `login_history`
--

DROP TABLE IF EXISTS `login_history`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `login_history` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `User_ID_login` int(11) DEFAULT NULL,
  `login_date` datetime DEFAULT NULL,
  `logout_date` datetime DEFAULT NULL,
  `duration` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `User_ID_login` (`User_ID_login`),
  CONSTRAINT `User_ID_login` FOREIGN KEY (`User_ID_login`) REFERENCES `tbluser` (`UserID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `login_history`
--

LOCK TABLES `login_history` WRITE;
/*!40000 ALTER TABLE `login_history` DISABLE KEYS */;
/*!40000 ALTER TABLE `login_history` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `month_report`
--

DROP TABLE IF EXISTS `month_report`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `month_report` (
  `month` int(2) NOT NULL,
  `year` int(11) DEFAULT NULL,
  `total_emplyees` int(11) DEFAULT NULL,
  `total_managers` int(11) DEFAULT NULL,
  `total_sales` int(11) DEFAULT NULL,
  `total_hours_worked` int(11) DEFAULT NULL,
  `total_hours_login` int(11) DEFAULT NULL,
  `total_questions` int(11) DEFAULT NULL,
  `total_quizzes` int(11) DEFAULT NULL,
  `total_levels` int(11) DEFAULT NULL,
  `total_sites` int(11) DEFAULT NULL,
  `total_roles` int(11) DEFAULT NULL,
  PRIMARY KEY (`month`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `month_report`
--

LOCK TABLES `month_report` WRITE;
/*!40000 ALTER TABLE `month_report` DISABLE KEYS */;
/*!40000 ALTER TABLE `month_report` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `questions_history`
--

DROP TABLE IF EXISTS `questions_history`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `questions_history` (
  `Id` int(11) NOT NULL,
  `User_ID_Question` int(11) DEFAULT NULL,
  `Question_ID_QH` int(11) DEFAULT NULL,
  `UserSelection` varchar(255) DEFAULT NULL,
  `Duration` int(11) DEFAULT NULL,
  `start_date` datetime DEFAULT NULL,
  `finish_date` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `User_ID_Question` (`User_ID_Question`),
  KEY `Question_ID_QH` (`Question_ID_QH`),
  CONSTRAINT `User_ID_Question` FOREIGN KEY (`User_ID_Question`) REFERENCES `tbluser` (`UserID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `questions_history`
--

LOCK TABLES `questions_history` WRITE;
/*!40000 ALTER TABLE `questions_history` DISABLE KEYS */;
/*!40000 ALTER TABLE `questions_history` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `quiz_history`
--

DROP TABLE IF EXISTS `quiz_history`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `quiz_history` (
  `Id` int(11) NOT NULL,
  `QuizID` int(11) DEFAULT NULL,
  `Total_Questions` int(11) DEFAULT NULL,
  `Times_Played` int(11) DEFAULT NULL,
  `Duration` int(11) DEFAULT NULL,
  `Entry_Date` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `quiz_history`
--

LOCK TABLES `quiz_history` WRITE;
/*!40000 ALTER TABLE `quiz_history` DISABLE KEYS */;
/*!40000 ALTER TABLE `quiz_history` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rewards_history`
--

DROP TABLE IF EXISTS `rewards_history`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `rewards_history` (
  `Id` int(11) NOT NULL,
  `Reward_ID` int(11) DEFAULT NULL,
  `User_ID` int(11) DEFAULT NULL,
  `Reward_Date` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rewards_history`
--

LOCK TABLES `rewards_history` WRITE;
/*!40000 ALTER TABLE `rewards_history` DISABLE KEYS */;
/*!40000 ALTER TABLE `rewards_history` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roles_history`
--

DROP TABLE IF EXISTS `roles_history`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `roles_history` (
  `Id` int(11) NOT NULL,
  `Role_ID` int(11) DEFAULT NULL,
  `Total Users` int(11) DEFAULT NULL,
  `Entry_Date` datetime DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles_history`
--

LOCK TABLES `roles_history` WRITE;
/*!40000 ALTER TABLE `roles_history` DISABLE KEYS */;
/*!40000 ALTER TABLE `roles_history` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblawardimages`
--

DROP TABLE IF EXISTS `tblawardimages`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblawardimages` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Award_Image` varchar(100) DEFAULT NULL,
  `Award_Thumbnail` varchar(100) DEFAULT NULL,
  `Active` int(11) DEFAULT '1',
  `Award_ID` int(11) DEFAULT NULL,
  `Uploaded_Date` date DEFAULT NULL,
  `Current_Image` int(11) DEFAULT '0',
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=232 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblawardimages`
--

LOCK TABLES `tblawardimages` WRITE;
/*!40000 ALTER TABLE `tblawardimages` DISABLE KEYS */;
INSERT INTO `tblawardimages` VALUES (181,'decd028c-2685-4d3c-b75a-13343e7d88bc.png','decd028c-2685-4d3c-b75a-13343e7d88bc.png',1,41,'2015-07-23',1),(191,'71a01a71-8984-418c-8637-f6723f3c8a3f.png','71a01a71-8984-418c-8637-f6723f3c8a3f.png',1,51,'2015-07-23',1),(201,'df049634-39d2-4949-80d1-a5b475d4f8bb.png','df049634-39d2-4949-80d1-a5b475d4f8bb.png',1,91,'2015-07-23',1),(91,'66fda332-1bc7-4aee-ad8e-ef0c57ec4c3c.png','66fda332-1bc7-4aee-ad8e-ef0c57ec4c3c.png',1,61,'2015-07-14',1),(101,'b6d09d2c-36a8-4205-8f48-b0117f8e0e5d.png','b6d09d2c-36a8-4205-8f48-b0117f8e0e5d.png',1,53,'2015-07-15',1),(211,'58672bb3-172c-4c04-8c9e-63067c51639e.png','58672bb3-172c-4c04-8c9e-63067c51639e.png',1,101,'2015-07-23',1),(161,'79d31c1f-c48b-4634-88f3-db9632961e9b.png','79d31c1f-c48b-4634-88f3-db9632961e9b.png',1,81,'2015-07-23',1),(151,'66153b2f-ea55-41d0-a68d-e83d16dfd706.png','66153b2f-ea55-41d0-a68d-e83d16dfd706.png',1,71,'2015-07-23',1),(171,'1a4681d7-0c3d-4cda-a17a-5c233c498c4d.png','1a4681d7-0c3d-4cda-a17a-5c233c498c4d.png',1,31,'2015-07-23',1),(221,'6095cdf7-78fe-4fab-a821-e35cd5ed7354.png','6095cdf7-78fe-4fab-a821-e35cd5ed7354.png',1,111,'2015-07-23',1),(231,'21dabfc9-d1ec-435d-9936-163f6004a57d.png','21dabfc9-d1ec-435d-9936-163f6004a57d.png',1,121,'2015-07-23',1);
/*!40000 ALTER TABLE `tblawardimages` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblawards`
--

DROP TABLE IF EXISTS `tblawards`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblawards` (
  `Award_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Award_Name` varchar(100) NOT NULL,
  `Award_Desc` varchar(200) DEFAULT NULL,
  `KPIID` int(11) DEFAULT NULL,
  `Target_Value` int(11) DEFAULT NULL,
  `Award_Manual` int(11) DEFAULT '0',
  `Active` tinyint(4) DEFAULT '1',
  `AwardCategoryID` int(11) DEFAULT NULL,
  PRIMARY KEY (`Award_ID`),
  UNIQUE KEY `Award_Name` (`Award_Name`)
) ENGINE=InnoDB AUTO_INCREMENT=122 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblawards`
--

LOCK TABLES `tblawards` WRITE;
/*!40000 ALTER TABLE `tblawards` DISABLE KEYS */;
INSERT INTO `tblawards` VALUES (31,'Above and Beyond','Above and Beyond',0,0,1,1,25),(41,'Employee of the Month','Employee of the Month',0,0,1,1,25),(51,'Exemplary Customer Service','Exemplary Customer Service',0,0,1,1,25),(61,'Sales Contest Gold','Sales Contest Gold',0,0,1,1,26),(71,'Sales Contest Silver','Sales Contest Silver',0,0,1,1,26),(81,'Sales Contest Bronze','Sales Contest Bronze',0,0,1,1,26),(91,'Team Leadership','Team Leadership',0,0,1,1,25),(101,'Welcome Aboard','Welcome Aboard',0,0,1,1,25),(111,'$1M Sales Milestone','$1M Sales Milestone',361,1000000,0,1,25),(121,'Perfect Attendance - 1 year','No days absent for 1 year',351,365,0,1,25);
/*!40000 ALTER TABLE `tblawards` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblcontestlog`
--

DROP TABLE IF EXISTS `tblcontestlog`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblcontestlog` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `lastrun` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblcontestlog`
--

LOCK TABLES `tblcontestlog` WRITE;
/*!40000 ALTER TABLE `tblcontestlog` DISABLE KEYS */;
/*!40000 ALTER TABLE `tblcontestlog` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblcontestperformance`
--

DROP TABLE IF EXISTS `tblcontestperformance`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblcontestperformance` (
  `ContestID` int(11) NOT NULL,
  `UserID` int(11) NOT NULL,
  `KPI_ID` int(11) NOT NULL,
  `Value` int(11) NOT NULL,
  `LastUpdate` datetime NOT NULL,
  `CP_ID` int(11) NOT NULL AUTO_INCREMENT,
  PRIMARY KEY (`CP_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblcontestperformance`
--

LOCK TABLES `tblcontestperformance` WRITE;
/*!40000 ALTER TABLE `tblcontestperformance` DISABLE KEYS */;
/*!40000 ALTER TABLE `tblcontestperformance` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblcontestposition`
--

DROP TABLE IF EXISTS `tblcontestposition`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblcontestposition` (
  `ContestId` int(11) DEFAULT NULL,
  `Award_ID` int(11) DEFAULT NULL,
  `Position` int(11) DEFAULT NULL,
  `Points` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblcontestposition`
--

LOCK TABLES `tblcontestposition` WRITE;
/*!40000 ALTER TABLE `tblcontestposition` DISABLE KEYS */;
INSERT INTO `tblcontestposition` VALUES (131,31,0,400),(131,31,1,300),(131,31,2,200),(121,31,0,400),(121,31,1,300),(121,31,2,250),(133,41,0,100),(133,51,1,200),(133,31,2,300),(141,61,0,300),(141,53,1,200),(141,41,2,100);
/*!40000 ALTER TABLE `tblcontestposition` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblcontests`
--

DROP TABLE IF EXISTS `tblcontests`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblcontests` (
  `ContestId` int(11) NOT NULL AUTO_INCREMENT,
  `ContestName` varchar(255) NOT NULL,
  `FromDate` date DEFAULT NULL,
  `ToDate` date DEFAULT NULL,
  `KPI_ID` int(11) DEFAULT NULL,
  PRIMARY KEY (`ContestId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblcontests`
--

LOCK TABLES `tblcontests` WRITE;
/*!40000 ALTER TABLE `tblcontests` DISABLE KEYS */;
/*!40000 ALTER TABLE `tblcontests` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblcontestscores`
--

DROP TABLE IF EXISTS `tblcontestscores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblcontestscores` (
  `User_ID` int(11) NOT NULL DEFAULT '0',
  `ContestId` int(11) NOT NULL DEFAULT '0',
  `Score` int(11) DEFAULT NULL,
  `Entry_Date` datetime DEFAULT NULL,
  PRIMARY KEY (`User_ID`,`ContestId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblcontestscores`
--

LOCK TABLES `tblcontestscores` WRITE;
/*!40000 ALTER TABLE `tblcontestscores` DISABLE KEYS */;
/*!40000 ALTER TABLE `tblcontestscores` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblcontestsroles`
--

DROP TABLE IF EXISTS `tblcontestsroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblcontestsroles` (
  `ContestId` int(11) DEFAULT NULL,
  `Role_Id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblcontestsroles`
--

LOCK TABLES `tblcontestsroles` WRITE;
/*!40000 ALTER TABLE `tblcontestsroles` DISABLE KEYS */;
/*!40000 ALTER TABLE `tblcontestsroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblcontestssites`
--

DROP TABLE IF EXISTS `tblcontestssites`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblcontestssites` (
  `ContestId` int(11) DEFAULT NULL,
  `Site_Id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblcontestssites`
--

LOCK TABLES `tblcontestssites` WRITE;
/*!40000 ALTER TABLE `tblcontestssites` DISABLE KEYS */;
/*!40000 ALTER TABLE `tblcontestssites` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbldataelement`
--

DROP TABLE IF EXISTS `tbldataelement`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbldataelement` (
  `ElementID` int(11) NOT NULL AUTO_INCREMENT,
  `MatchID` int(11) DEFAULT NULL,
  `ElementName` varchar(250) DEFAULT NULL,
  `IsPicture` int(11) DEFAULT '0',
  `CreatedDate` datetime DEFAULT NULL,
  PRIMARY KEY (`ElementID`)
) ENGINE=MyISAM AUTO_INCREMENT=172 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbldataelement`
--

LOCK TABLES `tbldataelement` WRITE;
/*!40000 ALTER TABLE `tbldataelement` DISABLE KEYS */;
INSERT INTO `tbldataelement` VALUES (28,91,'Price',0,'2014-08-23 17:57:51'),(27,91,'Manufacturer',0,'2014-08-23 17:54:50'),(26,91,'Picture',1,'2014-08-23 17:54:12'),(101,71,'Picture',1,'2014-08-22 18:40:10'),(111,71,'Name',0,'2014-08-22 18:40:17'),(121,71,'Sport',0,'2014-08-22 18:40:25'),(131,71,'Sales Fact',0,'2014-08-22 18:40:35'),(141,81,'Picture',1,'2014-08-22 18:45:47'),(151,81,'Sport',0,'2014-08-22 18:45:56'),(161,81,'Pricing',0,'2014-08-22 18:46:04'),(171,81,'Location',0,'2015-07-16 21:02:34'),(29,91,'Target',0,'2014-08-23 18:01:37');
/*!40000 ALTER TABLE `tbldataelement` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblkpi`
--

DROP TABLE IF EXISTS `tblkpi`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblkpi` (
  `KPI_ID` int(11) NOT NULL AUTO_INCREMENT,
  `KPI_name` varchar(100) NOT NULL,
  `KPI_measure` varchar(100) DEFAULT NULL,
  `KPI_type` int(11) DEFAULT NULL,
  `Active` tinyint(4) DEFAULT '1',
  `KPI_Category` int(11) DEFAULT NULL,
  `KPI_Descp` varchar(500) DEFAULT NULL,
  `TipsDESC` varchar(500) DEFAULT NULL,
  `TipsLINK` varchar(500) DEFAULT NULL,
  `TypeLevel` varchar(10) DEFAULT NULL,
  `TypeAward` varchar(10) DEFAULT NULL,
  `TypeContest` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`KPI_ID`),
  UNIQUE KEY `KPI_name` (`KPI_name`)
) ENGINE=InnoDB AUTO_INCREMENT=362 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblkpi`
--

LOCK TABLES `tblkpi` WRITE;
/*!40000 ALTER TABLE `tblkpi` DISABLE KEYS */;
INSERT INTO `tblkpi` VALUES (101,'Complete the \"Welcome Aboard!\" guide for new Sales Associates','Unit',5,1,19,'There\'s a lot to know about being a great sales associate. This course will help you get off to the right start','','','Level',' ',' '),(111,'Greeting Guests 101','Points',5,1,19,'GUESS first impression,Give a smile and make eye contact with anyone waiting on the sales floor or at the CashCounter.','','','Level','Award','Contest'),(121,'Score X Points in the Awesome Associate quiz game','Points',4,1,19,'Score X points in one session to complete','','','Level','Award','Contest'),(131,'Sell X $ worth of merchandise','USD',3,1,20,'Sell this amount of merchandise at the register','','','Level','Award','Contest'),(141,'Sign up X Guests for Loyalty Card','Points',3,1,20,'Signing up X Guests for the Loyalty Card brings business.','','','Level','Award','Contest'),(151,'Complete X hours receiving and stocking','Hours',3,1,20,'The best way to learn how to win as a team is to understand the work each team member is responsible for. In this mission you will learn how the mdse is received and prepped before put on display.','','','Level',' ',' '),(161,'Score X pts: \"Who\'s Who?\" Game','Points',4,1,19,'Contribute to the team. Learn who your partners are in delivering great customer service','','','Level','Award','Contest'),(171,'Receive X Positive Customer Feedback cards','Cards',3,1,20,'Get this amount of positive feedback cards','','','Level','Award','Contest'),(181,'Score X Points in the Grocery quiz Game','Points',4,1,19,'Score X points in one session to complete','','','Level','Award','Contest'),(191,'Score X Points in the Apparel quiz game','Points',4,1,19,'Score X points in one session to complete','','','Level','Award','Contest'),(201,'Score X Points in the Sports matching game','Points',4,1,19,'Know your sports equipment','','','Level','Award','Contest'),(211,'Score X points in the Ball matching game','Points',4,1,19,'Score X points in one session to complete','','','Level','Award','Contest'),(341,'Score X points in the \"Good Walk ruined\" matching game','Points',4,1,19,'Score X points in one session to complete','','','Level','Award','Contest'),(351,'X days perfect attendance','Days',4,1,20,'X days without absence','','','Level','Award','Contest'),(361,'$1M Sales Milestone','USD',3,1,20,'Sell $1M in total merchandise','','','Level','Award','Contest');
/*!40000 ALTER TABLE `tblkpi` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblkpitemp`
--

DROP TABLE IF EXISTS `tblkpitemp`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblkpitemp` (
  `EMP_ID` int(11) NOT NULL,
  `ExtractionDate` datetime DEFAULT NULL,
  `KPI_ID` int(11) DEFAULT NULL,
  `Performance` int(11) DEFAULT NULL,
  `KPI_Type` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`EMP_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblkpitemp`
--

LOCK TABLES `tblkpitemp` WRITE;
/*!40000 ALTER TABLE `tblkpitemp` DISABLE KEYS */;
/*!40000 ALTER TABLE `tblkpitemp` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbllevel`
--

DROP TABLE IF EXISTS `tbllevel`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbllevel` (
  `Level_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Level_Name` varchar(100) DEFAULT NULL,
  `Role_ID` int(11) DEFAULT NULL,
  `Active` tinyint(1) DEFAULT '1',
  `Level_Position` tinyint(2) NOT NULL,
  `BaseHours` int(11) DEFAULT NULL,
  `Level_date` date DEFAULT NULL,
  `Points` int(11) DEFAULT NULL,
  `Reach` varchar(45) DEFAULT NULL,
  `CurrentlyIn` varchar(45) DEFAULT NULL,
  `Game` varchar(50) DEFAULT NULL,
  `ImageName` varchar(100) DEFAULT NULL,
  `ImageThumbnail` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`Level_ID`),
  KEY `Role_ID` (`Role_ID`),
  CONSTRAINT `Role_ID` FOREIGN KEY (`Role_ID`) REFERENCES `tblroles` (`Role_ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=452 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbllevel`
--

LOCK TABLES `tbllevel` WRITE;
/*!40000 ALTER TABLE `tbllevel` DISABLE KEYS */;
INSERT INTO `tbllevel` VALUES (401,'Manager',2,1,1,0,'2015-07-18',0,'81','71','11','9b277d05-67d6-4fe9-8f32-ef5fa3c0c1c7.png','9b277d05-67d6-4fe9-8f32-ef5fa3c0c1c7.png'),(411,'Sales Apprentice',171,1,1,80,'2015-07-23',300,'81','71','11','c86c40e0-ef01-4882-8bb3-4827cc77870b.png','c86c40e0-ef01-4882-8bb3-4827cc77870b.png'),(421,'Sales Assistant',171,1,2,120,'2015-07-23',500,'91','81','11','f416960a-d6fb-467f-84e1-c800b209ecc2.png','f416960a-d6fb-467f-84e1-c800b209ecc2.png'),(431,'Sales Associate',171,1,3,150,'2015-07-23',700,'141','91','11','639c03c9-b201-46a5-8d8f-d3d38c3bab77.png','639c03c9-b201-46a5-8d8f-d3d38c3bab77.png'),(441,'Sales Captain',171,1,4,400,'2015-07-23',800,'101','141','11','96baa710-6efd-4161-9025-a56d16f87a86.png','96baa710-6efd-4161-9025-a56d16f87a86.png'),(451,'Admin',1,1,1,0,'2015-07-23',0,'81','71','11','2c7ab4af-117f-4558-b7b1-2dbc9ff47cb9.png','2c7ab4af-117f-4558-b7b1-2dbc9ff47cb9.png');
/*!40000 ALTER TABLE `tbllevel` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbllevelgame`
--

DROP TABLE IF EXISTS `tbllevelgame`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbllevelgame` (
  `GameID` int(11) NOT NULL AUTO_INCREMENT,
  `GameName` varchar(50) DEFAULT NULL,
  `Active` int(4) DEFAULT '1',
  PRIMARY KEY (`GameID`)
) ENGINE=MyISAM AUTO_INCREMENT=52 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbllevelgame`
--

LOCK TABLES `tbllevelgame` WRITE;
/*!40000 ALTER TABLE `tbllevelgame` DISABLE KEYS */;
INSERT INTO `tbllevelgame` VALUES (11,'Around the World',1);
/*!40000 ALTER TABLE `tbllevelgame` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbllevelgameddl`
--

DROP TABLE IF EXISTS `tbllevelgameddl`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbllevelgameddl` (
  `GameDropdownID` int(11) NOT NULL AUTO_INCREMENT,
  `GameDropdownName` varchar(50) DEFAULT NULL,
  `GameID` int(11) DEFAULT NULL,
  `Active` int(4) DEFAULT '1',
  PRIMARY KEY (`GameDropdownID`)
) ENGINE=MyISAM AUTO_INCREMENT=252 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbllevelgameddl`
--

LOCK TABLES `tbllevelgameddl` WRITE;
/*!40000 ALTER TABLE `tbllevelgameddl` DISABLE KEYS */;
INSERT INTO `tbllevelgameddl` VALUES (141,'Moscow',11,1),(101,'Dubai',11,1),(91,'London',11,1),(81,'New York',11,1),(71,'San Francisco',11,1);
/*!40000 ALTER TABLE `tbllevelgameddl` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbllevelperformance`
--

DROP TABLE IF EXISTS `tbllevelperformance`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbllevelperformance` (
  `levelPerformanceId` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NOT NULL,
  `current_level` int(11) NOT NULL,
  `next_level` int(11) NOT NULL,
  `last_level` int(11) NOT NULL,
  `level_achieved` tinyint(4) NOT NULL,
  `achieved_date` date DEFAULT NULL,
  `target_scores` int(11) NOT NULL,
  `achieved_scores` int(11) NOT NULL,
  `popup_showed` tinyint(4) NOT NULL DEFAULT '0',
  `Worked_Hour` int(11) DEFAULT '0',
  PRIMARY KEY (`levelPerformanceId`)
) ENGINE=MyISAM AUTO_INCREMENT=542 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbllevelperformance`
--

LOCK TABLES `tbllevelperformance` WRITE;
/*!40000 ALTER TABLE `tbllevelperformance` DISABLE KEYS */;
INSERT INTO `tbllevelperformance` VALUES (191,131,231,232,0,0,NULL,1000,0,0,0),(201,141,281,282,0,1,NULL,500,0,1,0),(211,151,311,312,0,0,NULL,1000,0,0,0),(221,161,291,292,0,0,NULL,0,0,0,0),(231,171,291,292,0,0,NULL,0,0,0,0),(241,181,261,262,0,1,NULL,100,0,1,0),(251,181,231,232,261,1,NULL,1000,0,0,0),(261,191,271,272,0,1,NULL,103,0,0,0),(271,201,261,262,0,0,NULL,100,0,0,0),(281,211,261,262,0,0,NULL,100,0,0,0),(291,181,261,262,231,0,NULL,100,0,0,0),(301,221,261,262,0,0,NULL,100,0,0,0),(311,231,261,262,0,0,NULL,100,0,0,0),(321,191,261,262,271,0,NULL,712,0,0,0),(331,141,261,262,281,0,NULL,712,0,0,0),(341,241,261,262,0,0,NULL,712,0,0,0),(351,251,261,262,0,0,NULL,712,0,0,0),(361,261,261,262,0,0,NULL,712,0,0,0),(371,271,261,262,0,0,NULL,712,0,0,0),(381,281,261,262,0,0,NULL,712,0,0,0),(391,291,261,262,0,0,NULL,712,0,0,0),(401,301,401,402,0,0,NULL,0,0,0,0),(411,2,401,402,0,0,NULL,0,0,0,0),(421,1,451,452,0,0,NULL,0,0,0,0),(431,271,411,412,0,0,NULL,622,0,0,0),(441,111,411,412,0,0,NULL,622,0,0,0),(451,101,411,412,0,0,NULL,622,0,0,0),(461,121,401,402,0,0,NULL,0,0,0,0),(471,31,411,412,0,0,NULL,622,0,0,0),(481,311,401,402,0,0,NULL,0,0,0,0),(491,321,401,402,0,0,NULL,0,0,0,0),(501,11,401,402,0,0,NULL,0,0,0,0),(511,331,411,412,0,0,NULL,622,0,0,0),(521,341,411,412,0,1,NULL,622,0,1,0),(531,341,421,431,411,0,NULL,0,0,0,0),(541,351,411,412,0,0,NULL,622,0,0,0);
/*!40000 ALTER TABLE `tbllevelperformance` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbllifelines`
--

DROP TABLE IF EXISTS `tbllifelines`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbllifelines` (
  `LifeLine_ID` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` int(11) DEFAULT NULL,
  `QuizID` int(11) DEFAULT NULL,
  `DateUsed` varchar(50) DEFAULT NULL,
  `ReduceChoices_LifeLine` int(11) DEFAULT NULL,
  `ReplaceQuestion_LifeLine` int(11) DEFAULT NULL,
  `AddCounter_LifeLine` int(11) DEFAULT NULL,
  PRIMARY KEY (`LifeLine_ID`)
) ENGINE=MyISAM AUTO_INCREMENT=79 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbllifelines`
--

LOCK TABLES `tbllifelines` WRITE;
/*!40000 ALTER TABLE `tbllifelines` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbllifelines` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbllog`
--

DROP TABLE IF EXISTS `tbllog`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbllog` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `contestId` int(11) DEFAULT NULL,
  `description` varchar(500) DEFAULT NULL,
  `lastrun` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbllog`
--

LOCK TABLES `tbllog` WRITE;
/*!40000 ALTER TABLE `tbllog` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbllog` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblmap`
--

DROP TABLE IF EXISTS `tblmap`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblmap` (
  `Role_ID` int(11) DEFAULT NULL,
  `Level_ID` int(11) DEFAULT NULL,
  `Dimension_top` int(11) DEFAULT NULL,
  `Dimension_left` int(11) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblmap`
--

LOCK TABLES `tblmap` WRITE;
/*!40000 ALTER TABLE `tblmap` DISABLE KEYS */;
/*!40000 ALTER TABLE `tblmap` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblmapping`
--

DROP TABLE IF EXISTS `tblmapping`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblmapping` (
  `User_ID` int(11) NOT NULL,
  `MappingTable_ID` int(11) NOT NULL,
  `Type` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`User_ID`,`MappingTable_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblmapping`
--

LOCK TABLES `tblmapping` WRITE;
/*!40000 ALTER TABLE `tblmapping` DISABLE KEYS */;
/*!40000 ALTER TABLE `tblmapping` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblmatch`
--

DROP TABLE IF EXISTS `tblmatch`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblmatch` (
  `MatchID` int(11) NOT NULL AUTO_INCREMENT,
  `MatchName` varchar(250) DEFAULT NULL,
  `PointsForCompletation` int(11) DEFAULT NULL,
  `MaxPlaysPerDay` int(11) DEFAULT NULL,
  `NoOfDataSet` int(11) DEFAULT NULL,
  `NoOfRounds` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `MatchImage` varchar(100) DEFAULT NULL,
  `MatchImageThumbnail` varchar(100) DEFAULT NULL,
  `KPI_ID` int(11) DEFAULT NULL,
  PRIMARY KEY (`MatchID`)
) ENGINE=MyISAM AUTO_INCREMENT=92 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblmatch`
--

LOCK TABLES `tblmatch` WRITE;
/*!40000 ALTER TABLE `tblmatch` DISABLE KEYS */;
INSERT INTO `tblmatch` VALUES (91,'A good Walk Ruined',100,5,4,2,'2014-08-23 17:52:31','8cb80088-2daa-4bc9-891b-70ceda714bc1.jpeg','8cb80088-2daa-4bc9-891b-70ceda714bc1.jpeg',341),(71,'A Question Of Sport',100,20,4,2,'2014-08-22 18:39:43','8df5ac88-7044-46d9-9dc4-bb613e324910.jpg','8df5ac88-7044-46d9-9dc4-bb613e324910.jpg',201),(81,'A Load of Balls',100,5,4,4,'2014-08-22 18:45:23','d43aca57-9d3c-493b-9c61-4b6029f0716d.png','d43aca57-9d3c-493b-9c61-4b6029f0716d.png',211);
/*!40000 ALTER TABLE `tblmatch` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblmatchdatasetlevels`
--

DROP TABLE IF EXISTS `tblmatchdatasetlevels`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblmatchdatasetlevels` (
  `DataSetID` int(11) DEFAULT NULL,
  `RoleID` int(11) DEFAULT NULL,
  `LevelID` int(11) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblmatchdatasetlevels`
--

LOCK TABLES `tblmatchdatasetlevels` WRITE;
/*!40000 ALTER TABLE `tblmatchdatasetlevels` DISABLE KEYS */;
INSERT INTO `tblmatchdatasetlevels` VALUES (121,91,231),(121,101,311),(121,111,291),(121,141,261),(121,151,281),(131,91,231),(131,101,311),(131,111,291),(141,91,231),(141,101,311),(141,111,291),(151,171,411),(151,171,421),(151,171,431),(151,171,441),(161,171,411),(161,171,421),(161,171,431),(161,171,441),(171,171,411),(171,171,421),(171,171,431),(171,171,441),(181,171,441),(181,171,431),(181,171,421),(181,171,411),(191,171,411),(191,171,421),(191,171,431),(191,171,441),(201,171,411),(201,171,421),(201,171,431),(201,171,441),(211,171,411),(211,171,421),(211,171,431),(211,171,441),(221,171,411),(221,171,421),(221,171,431),(221,171,441),(231,171,441),(231,171,431),(231,171,421),(231,171,411),(241,171,411),(241,171,421),(241,171,431),(241,171,441),(84,171,441),(84,171,431),(84,171,421),(84,171,411),(83,171,411),(83,171,421),(83,171,431),(83,171,441),(85,171,411),(85,171,421),(85,171,431),(85,171,441),(86,171,411),(86,171,421),(86,171,431),(86,171,441),(87,171,411),(87,171,421),(87,171,431),(87,171,441);
/*!40000 ALTER TABLE `tblmatchdatasetlevels` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblmatchdatasets`
--

DROP TABLE IF EXISTS `tblmatchdatasets`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblmatchdatasets` (
  `DataSetID` int(11) NOT NULL AUTO_INCREMENT,
  `DataSetElementsData` varchar(500) DEFAULT NULL,
  `SiteID` int(11) DEFAULT NULL,
  `MatchID` int(11) NOT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `DataSetImage` varchar(100) DEFAULT NULL,
  `DataSetImageThumbnail` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`DataSetID`)
) ENGINE=MyISAM AUTO_INCREMENT=242 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblmatchdatasets`
--

LOCK TABLES `tblmatchdatasets` WRITE;
/*!40000 ALTER TABLE `tblmatchdatasets` DISABLE KEYS */;
INSERT INTO `tblmatchdatasets` VALUES (84,'Players needing extra spin|$31.99 – HOT DEAL!!!!|Cal',0,91,'2014-08-23 18:10:44','90d961b1-fcf9-4e7b-a34a-42086e8087ab.jpg','90d961b1-fcf9-4e7b-a34a-42086e8087ab.jpg'),(83,'Pro or very good Amateur|$48.95|Titleist|',0,91,'2014-08-23 18:00:22','c6e8bc60-390f-457d-b974-5ff67e5afabb.jpg','c6e8bc60-390f-457d-b974-5ff67e5afabb.jpg'),(151,'Quality ones made from real feathers.|Badminton|Shuttlecock|',0,71,'2014-08-22 18:42:40','deb3413d-47f5-4184-a48f-30b36f7d36c2.jpg','deb3413d-47f5-4184-a48f-30b36f7d36c2.jpg'),(161,'To size, add 1/2 inch length for fingers|Soccer|Goalie Gloves|',0,71,'2014-08-22 18:43:08','eee237b6-3d5d-451c-a337-0d42668ce16d.jpg','eee237b6-3d5d-451c-a337-0d42668ce16d.jpg'),(171,'Different pads for right and left feet|Cricket|Pads|',0,71,'2014-08-22 18:43:35','dd616e18-bade-4867-82af-d705ce126f4c.jpg','dd616e18-bade-4867-82af-d705ce126f4c.jpg'),(181,'Provides protection in a clash of heads|Rugby|Scrum Cap|',0,71,'2014-08-22 18:44:10','62610896-1f65-476b-8ca5-60d07a5be28b.jpg','62610896-1f65-476b-8ca5-60d07a5be28b.jpg'),(191,'Safer than snap-gates but cost more|Mountaineering|Screw-Gate Carabiner|',0,71,'2014-08-22 18:44:37','945a9f69-cf55-45c2-b8ab-a12371884857.jpg','945a9f69-cf55-45c2-b8ab-a12371884857.jpg'),(201,'Back Wall|$12 - $125|Soccer|',0,81,'2014-08-22 18:47:59','05ec57b2-a683-4acc-9a8d-efbdad2e89dd.jpg','05ec57b2-a683-4acc-9a8d-efbdad2e89dd.jpg'),(211,'Aisle 12 (Front)|$5 - $25|Cricket|',0,81,'2014-08-22 18:48:26','96668830-0b54-4840-9998-1db714d11c5c.jpg','96668830-0b54-4840-9998-1db714d11c5c.jpg'),(221,'Aisle 2|$30 for Tube of 6|Tennis|',0,81,'2014-08-22 18:49:03','aa219931-6b00-4df4-a6f9-81578576ccc0.jpg','aa219931-6b00-4df4-a6f9-81578576ccc0.jpg'),(231,'Basement|$30 for box of 12|Golf|',0,81,'2014-08-22 18:49:48','cf0a99ee-ca9f-4fff-869d-64e6dc500d6d.jpg','cf0a99ee-ca9f-4fff-869d-64e6dc500d6d.jpg'),(241,'Aisle 12 (Rear)|$8|Lacrosse|',0,81,'2014-08-22 19:04:20','4a983242-ecd0-4dbb-9bbc-247e377fe5ba.jpg','4a983242-ecd0-4dbb-9bbc-247e377fe5ba.jpg'),(85,'Seniors / players with slow swing speed|$44.99|Srixon|',0,91,'2014-08-23 18:12:58','c11bf00c-560a-48e7-8857-e1c973255809.jpg','c11bf00c-560a-48e7-8857-e1c973255809.jpg'),(86,'Beginners|$14.99|Noodle|',0,91,'2014-08-23 18:14:13','afc09dda-a419-442a-ae5f-73a5ce694363.jpg','afc09dda-a419-442a-ae5f-73a5ce694363.jpg'),(87,'Lady Golfers|$12.99|Wilson|',0,91,'2014-08-23 18:15:34','5b209531-b722-4e85-9cd8-9e7aaae14a6c.jpg','5b209531-b722-4e85-9cd8-9e7aaae14a6c.jpg');
/*!40000 ALTER TABLE `tblmatchdatasets` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblmatchlevels`
--

DROP TABLE IF EXISTS `tblmatchlevels`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblmatchlevels` (
  `MatchID` int(11) DEFAULT NULL,
  `RoleID` int(11) DEFAULT NULL,
  `LevelID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblmatchlevels`
--

LOCK TABLES `tblmatchlevels` WRITE;
/*!40000 ALTER TABLE `tblmatchlevels` DISABLE KEYS */;
INSERT INTO `tblmatchlevels` VALUES (51,91,231),(51,101,311),(51,111,291),(51,141,261),(51,151,281),(61,91,231),(61,101,311),(61,111,291),(71,171,411),(71,171,421),(71,171,431),(71,171,441),(81,171,411),(81,171,421),(81,171,431),(81,171,441),(91,171,411),(91,171,421),(91,171,431),(91,171,441);
/*!40000 ALTER TABLE `tblmatchlevels` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblmatchplaylog`
--

DROP TABLE IF EXISTS `tblmatchplaylog`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblmatchplaylog` (
  `LogID` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` int(11) DEFAULT NULL,
  `MatchID` int(11) DEFAULT NULL,
  `MatchTime` varchar(100) DEFAULT NULL,
  `MatchPlays` int(11) DEFAULT '0',
  PRIMARY KEY (`LogID`)
) ENGINE=MyISAM AUTO_INCREMENT=1392 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblmatchplaylog`
--

LOCK TABLES `tblmatchplaylog` WRITE;
/*!40000 ALTER TABLE `tblmatchplaylog` DISABLE KEYS */;
INSERT INTO `tblmatchplaylog` VALUES (1351,161,61,'7/15/2015',1),(1361,161,51,'7/15/2015',1),(1371,161,61,'7/15/2015',1),(1381,181,61,'7/15/2015',1),(1391,181,51,'7/15/2015',1);
/*!40000 ALTER TABLE `tblmatchplaylog` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblmessages`
--

DROP TABLE IF EXISTS `tblmessages`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblmessages` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `From_UserID` int(11) DEFAULT NULL,
  `To_UserID` int(11) DEFAULT NULL,
  `Message_Subject` varchar(100) DEFAULT NULL,
  `Message_Text` varchar(1000) DEFAULT NULL,
  `Sent_Date` datetime DEFAULT NULL,
  `IsRead` tinyint(1) DEFAULT '0',
  `IsReply` tinyint(1) DEFAULT '0',
  `RepliedMessageID` int(11) DEFAULT NULL,
  `Active` tinyint(1) DEFAULT '1',
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=1412 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblmessages`
--

LOCK TABLES `tblmessages` WRITE;
/*!40000 ALTER TABLE `tblmessages` DISABLE KEYS */;
INSERT INTO `tblmessages` VALUES (1411,341,321,'Level achieved','Jordan Brown ( jordanb ) in Acme Sales Assoc at Acme - Broad St has successfully achieved Level 1 at 7/23/2015 9:18:07 PM','2015-07-23 21:18:05',0,0,NULL,1),(1331,1,131,'hi','this is working','2015-07-08 19:01:37',0,0,NULL,1),(1401,341,1,'Level achieved','Jordan Brown ( jordanb ) in Acme Sales Assoc at Acme - Broad St has successfully achieved Level 1 at 7/23/2015 9:18:07 PM','2015-07-23 21:18:05',0,0,NULL,1),(1371,181,2,'Level achieved','Jordan sp ( jordan ) in Sales Associate at Modell\'s has successfully achieved Level 1 at 7/15/2015 7:26:36 PM','2015-07-15 19:26:35',0,0,NULL,1),(1391,141,2,'Level achieved','Stuart Silvermantwo ( stuart2 ) in Sports Associate at ACME Main St has successfully achieved Level 1 at 7/16/2015 8:02:15 PM','2015-07-16 20:02:14',0,0,NULL,1);
/*!40000 ALTER TABLE `tblmessages` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblpostlikes`
--

DROP TABLE IF EXISTS `tblpostlikes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblpostlikes` (
  `LikeID` int(11) NOT NULL AUTO_INCREMENT,
  `LikeDate` datetime DEFAULT NULL,
  `LikedBy` int(11) DEFAULT NULL,
  `PostID` int(11) DEFAULT NULL,
  PRIMARY KEY (`LikeID`),
  KEY `LikedBy` (`LikedBy`),
  KEY `PostID` (`PostID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblpostlikes`
--

LOCK TABLES `tblpostlikes` WRITE;
/*!40000 ALTER TABLE `tblpostlikes` DISABLE KEYS */;
/*!40000 ALTER TABLE `tblpostlikes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblpostrepliedlikes`
--

DROP TABLE IF EXISTS `tblpostrepliedlikes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblpostrepliedlikes` (
  `RepliedLikeID` int(11) NOT NULL AUTO_INCREMENT,
  `RepliedLikeDate` datetime DEFAULT NULL,
  `LikedBy` int(11) DEFAULT NULL,
  `LikeID` int(11) DEFAULT NULL,
  `PostID` int(11) DEFAULT NULL,
  PRIMARY KEY (`RepliedLikeID`),
  KEY `LikedByFK` (`LikedBy`),
  KEY `LikeIDFK` (`LikeID`),
  KEY `PostIDFK` (`PostID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblpostrepliedlikes`
--

LOCK TABLES `tblpostrepliedlikes` WRITE;
/*!40000 ALTER TABLE `tblpostrepliedlikes` DISABLE KEYS */;
/*!40000 ALTER TABLE `tblpostrepliedlikes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblpostreplies`
--

DROP TABLE IF EXISTS `tblpostreplies`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblpostreplies` (
  `ReplyID` int(11) NOT NULL AUTO_INCREMENT,
  `ReplyMessage` varchar(200) DEFAULT NULL,
  `RepliedBy` int(11) DEFAULT NULL,
  `ReplyDate` datetime DEFAULT NULL,
  `PostID` int(11) DEFAULT NULL,
  PRIMARY KEY (`ReplyID`),
  KEY `RepliedByFK` (`RepliedBy`),
  KEY `PostIDFK` (`PostID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblpostreplies`
--

LOCK TABLES `tblpostreplies` WRITE;
/*!40000 ALTER TABLE `tblpostreplies` DISABLE KEYS */;
/*!40000 ALTER TABLE `tblpostreplies` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblposts`
--

DROP TABLE IF EXISTS `tblposts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblposts` (
  `PostID` int(11) NOT NULL AUTO_INCREMENT,
  `PostTitle` varchar(200) DEFAULT NULL,
  `PostMessage` varchar(255) DEFAULT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `PostTypeID` int(11) DEFAULT NULL,
  `RoleID` int(11) DEFAULT NULL,
  PRIMARY KEY (`PostID`),
  KEY `CreatedByFK` (`CreatedBy`),
  KEY `PosTypeIDFK` (`PostTypeID`),
  KEY `RoleIDFK` (`RoleID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblposts`
--

LOCK TABLES `tblposts` WRITE;
/*!40000 ALTER TABLE `tblposts` DISABLE KEYS */;
/*!40000 ALTER TABLE `tblposts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblposttypes`
--

DROP TABLE IF EXISTS `tblposttypes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblposttypes` (
  `PostTypeID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(50) DEFAULT NULL,
  `CreateDate` datetime DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `ModifiedDate` datetime DEFAULT NULL,
  `ModifiedBy` int(11) DEFAULT NULL,
  PRIMARY KEY (`PostTypeID`),
  KEY `UserIDFK_C` (`CreatedBy`),
  KEY `UserIDFK_M` (`ModifiedBy`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblposttypes`
--

LOCK TABLES `tblposttypes` WRITE;
/*!40000 ALTER TABLE `tblposttypes` DISABLE KEYS */;
/*!40000 ALTER TABLE `tblposttypes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblquestionlevels`
--

DROP TABLE IF EXISTS `tblquestionlevels`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblquestionlevels` (
  `QuestionID` int(11) DEFAULT NULL,
  `RoleID` int(11) DEFAULT NULL,
  `LevelID` int(11) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblquestionlevels`
--

LOCK TABLES `tblquestionlevels` WRITE;
/*!40000 ALTER TABLE `tblquestionlevels` DISABLE KEYS */;
INSERT INTO `tblquestionlevels` VALUES (111,101,311),(121,111,291),(121,101,311),(121,91,231),(131,111,291),(131,101,311),(131,91,231),(141,111,291),(141,101,311),(141,91,231),(151,91,231),(151,101,311),(151,111,291),(151,141,261),(121,141,261),(131,141,261),(141,141,261),(161,171,431),(161,171,421),(161,171,411),(231,171,411),(241,171,411),(281,171,441),(161,171,441),(171,171,441),(171,171,431),(171,171,421),(171,171,411),(181,171,441),(181,171,431),(181,171,421),(181,171,411),(191,171,441),(191,171,431),(191,171,421),(191,171,411),(201,171,441),(201,171,431),(201,171,421),(201,171,411),(211,171,441),(211,171,431),(211,171,421),(211,171,411),(221,171,441),(221,171,431),(221,171,421),(221,171,411),(231,171,421),(231,171,431),(231,171,441),(241,171,421),(241,171,431),(241,171,441),(251,171,441),(251,171,431),(251,171,421),(251,171,411),(261,171,411),(261,171,421),(261,171,431),(261,171,441),(271,171,411),(271,171,421),(271,171,431),(271,171,441),(361,171,411),(361,171,421),(361,171,431),(361,171,441),(371,171,411),(371,171,421),(371,171,431),(371,171,441),(281,171,431),(281,171,421),(281,171,411),(291,171,441),(291,171,431),(291,171,421),(291,171,411),(301,171,441),(301,171,431),(301,171,421),(301,171,411),(311,171,441),(311,171,431),(311,171,421),(311,171,411),(321,171,441),(321,171,431),(321,171,421),(321,171,411),(341,171,441),(341,171,431),(341,171,421),(341,171,411),(331,171,441),(331,171,431),(331,171,421),(331,171,411);
/*!40000 ALTER TABLE `tblquestionlevels` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblquiz`
--

DROP TABLE IF EXISTS `tblquiz`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblquiz` (
  `QuizID` int(11) NOT NULL AUTO_INCREMENT,
  `QuizName` varchar(250) DEFAULT NULL,
  `NoOfQuestions` int(11) DEFAULT NULL,
  `TimePerQuestion` int(11) DEFAULT NULL,
  `TimesPlayablePerDay` int(11) DEFAULT NULL,
  `PointsPerQuestion` int(11) DEFAULT NULL,
  `TimeBeforePointsDeduction` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `QuizImage` varchar(100) DEFAULT NULL,
  `QuizImageThumbnail` varchar(100) DEFAULT NULL,
  `KPI_ID` int(11) DEFAULT NULL,
  PRIMARY KEY (`QuizID`)
) ENGINE=MyISAM AUTO_INCREMENT=72 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblquiz`
--

LOCK TABLES `tblquiz` WRITE;
/*!40000 ALTER TABLE `tblquiz` DISABLE KEYS */;
INSERT INTO `tblquiz` VALUES (51,'Be an Awesome Associate',4,20,5,50,5,'2014-12-01 22:34:12','f87445dd-d361-4209-b096-538453215239.jpg','f87445dd-d361-4209-b096-538453215239.jpg',121),(61,'Acme Grocery Quiz',3,25,5,20,5,'2013-11-13 21:16:57','c419205a-9354-4dd9-93ff-07572ba20c68.jpg','c419205a-9354-4dd9-93ff-07572ba20c68.jpg',181),(71,'Acme Apparel Quiz',5,25,5,20,5,'2013-11-13 21:34:01','1606fac4-a280-4076-8a38-13d9afb7d9da.jpg','1606fac4-a280-4076-8a38-13d9afb7d9da.jpg',191);
/*!40000 ALTER TABLE `tblquiz` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblquizcategory`
--

DROP TABLE IF EXISTS `tblquizcategory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblquizcategory` (
  `CategoryID` int(11) NOT NULL AUTO_INCREMENT,
  `CategoryName` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`CategoryID`)
) ENGINE=MyISAM AUTO_INCREMENT=32 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblquizcategory`
--

LOCK TABLES `tblquizcategory` WRITE;
/*!40000 ALTER TABLE `tblquizcategory` DISABLE KEYS */;
INSERT INTO `tblquizcategory` VALUES (21,'Electonics'),(31,'Sale Basic');
/*!40000 ALTER TABLE `tblquizcategory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblquizlevels`
--

DROP TABLE IF EXISTS `tblquizlevels`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblquizlevels` (
  `QuizID` int(11) DEFAULT NULL,
  `RoleID` int(11) DEFAULT NULL,
  `LevelID` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblquizlevels`
--

LOCK TABLES `tblquizlevels` WRITE;
/*!40000 ALTER TABLE `tblquizlevels` DISABLE KEYS */;
INSERT INTO `tblquizlevels` VALUES (41,91,231),(41,101,311),(41,111,291),(41,141,261),(31,101,311),(27,141,261),(27,141,341),(27,141,351),(61,171,411),(61,171,421),(61,171,431),(61,171,441),(71,171,411),(71,171,421),(71,171,431),(71,171,441),(51,171,411),(51,171,421),(51,171,431),(51,171,441);
/*!40000 ALTER TABLE `tblquizlevels` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblquizplaylog`
--

DROP TABLE IF EXISTS `tblquizplaylog`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblquizplaylog` (
  `LogID` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` int(11) DEFAULT NULL,
  `QuizID` int(11) DEFAULT NULL,
  `QuizTime` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`LogID`)
) ENGINE=MyISAM AUTO_INCREMENT=4582 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblquizplaylog`
--

LOCK TABLES `tblquizplaylog` WRITE;
/*!40000 ALTER TABLE `tblquizplaylog` DISABLE KEYS */;
INSERT INTO `tblquizplaylog` VALUES (4531,161,41,'7/13/2015'),(4541,161,41,'7/13/2015'),(4551,161,41,'7/13/2015'),(4561,161,41,'7/13/2015'),(4571,171,41,'7/13/2015'),(4581,171,41,'7/13/2015');
/*!40000 ALTER TABLE `tblquizplaylog` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblquizquestions`
--

DROP TABLE IF EXISTS `tblquizquestions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblquizquestions` (
  `QuestionID` int(11) NOT NULL AUTO_INCREMENT,
  `QuestionText` varchar(200) NOT NULL,
  `QuestionExplanation` varchar(300) DEFAULT NULL,
  `Answer1` varchar(100) NOT NULL,
  `Answer2` varchar(100) NOT NULL,
  `Answer3` varchar(100) NOT NULL,
  `Answer4` varchar(100) NOT NULL,
  `CorrectAnswer` varchar(100) NOT NULL,
  `Category` int(11) DEFAULT NULL,
  `SiteID` int(11) DEFAULT NULL,
  `QuizID` int(11) NOT NULL,
  `QuestionImage` varchar(100) DEFAULT NULL,
  `QuestionImageThumbnail` varchar(100) DEFAULT NULL,
  `ShortQuestion` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`QuestionID`)
) ENGINE=MyISAM AUTO_INCREMENT=372 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblquizquestions`
--

LOCK TABLES `tblquizquestions` WRITE;
/*!40000 ALTER TABLE `tblquizquestions` DISABLE KEYS */;
INSERT INTO `tblquizquestions` VALUES (111,'What item does a customer require with a Blu Ray player?','Must use HDMI to connect the player to TV','VGA cable','Ethernet cable','RCA cable','HDMI cable','HDMI cable',21,21,31,'14b349ca-f7ca-4f0d-9efc-35508d6963fb.jpg','14b349ca-f7ca-4f0d-9efc-35508d6963fb.jpg','blu ray'),(121,'What\'s the most important thing a sales associate should know?','even split between knowledge of the product and the person you\'re selling to','color of product','Nothing','Who cares','Product and person selling to','Product and person selling to',31,11,41,'5c06d776-c85f-4ad6-a7f4-87576ed5b832.png','5c06d776-c85f-4ad6-a7f4-87576ed5b832.png','knowledge'),(131,'If there is a sale going on, how do you make sure customers are aware?','how you ensure customers are aware of company promotions.','Shouting','Mumbling','Nothing','Setting up signage and visual displ','Setting up signage and visual displ',31,11,41,'Null','Null','role is to sell'),(141,'How do you go about greeting customers that enter the store?','helps to increase sale','who cares','By phone','HHH','personally greet each and every cus','personally greet each and every cus',31,11,41,'Null','Null','greeting'),(151,'How to manage order in your department?','well stocked store sells more','Ask other to care about','Rely on promotion','things corrects itself','Well stocked and neat & clean','Well stocked and neat & clean',31,11,41,'Null','Null','management'),(161,'What is the correct way to greet a guest?','Always greet the guest with the time of day (morning, afternoon, evening) and make them feel welcome at your store.','Hi.','Hey, wassup?','Say nothing at all','Good Afternoon. Welcome to ______.','Good Afternoon. Welcome to ______.',31,0,51,'e2190559-9f06-4403-9c11-9ed7da45b12a.jpg','e2190559-9f06-4403-9c11-9ed7da45b12a.jpg','Greet a guest'),(171,'What is the best way to ask if a customer needs help?','By asking politely, you can gain trust and confidence with the guest. When the guest is comfortable with you they will be more likely to buy from you.','You need help?','If you need help ask.','What do you need?','How can I help you?','How can I help you?',31,0,51,'ec823b38-1cd5-400e-ac8f-427be111dc2f.png','ec823b38-1cd5-400e-ac8f-427be111dc2f.png','Customer needs help ?'),(181,'What do you do if a guest needs your help but you\'re working on a task ?','Taking care of our guests is our main priority. If a guest asks you for help while you\'re doing a task, set it aside and help the guest.','Tell the customer you\'re busy','Continue to work on your task','Tell them to ask someone else','Set aside your task for a moment','Set aside your task for a moment',31,0,51,'841ae1be-e57b-4f78-94db-7d1a7ef294cd.png','841ae1be-e57b-4f78-94db-7d1a7ef294cd.png','Too busy to help'),(191,'Where are the women\'s shoes located?','Women\'s shoes are located on the 2nd Floor between the kids department and the registers','Lower Level','1st floor','3rd floor','2nd floor','2nd floor',31,0,51,'c7ef40d8-4092-455d-aefa-4ef760c3d7f7.png','c7ef40d8-4092-455d-aefa-4ef760c3d7f7.png','Women\'s shoes location'),(201,'What time should you arrive for your shift?','You should always arrive at least 10 minutes before your shift. It leaves time to pick up your check, to change etc.','The exact time of your shift','5 minutes before','5 minutes after','10 minutes before','10 minutes before',31,0,51,'0989ef72-651f-434f-82af-7b40abfe6c15.png','0989ef72-651f-434f-82af-7b40abfe6c15.png','Shift times'),(211,'Where is the mens dressing room?','On the 3rd floor, directly in front of mens jackets/coats','2nd floor','Lower Level','1st floor','3rd floor','3rd floor',31,0,51,'9c1be832-e475-4938-99cb-0cfd659d6c16.png','9c1be832-e475-4938-99cb-0cfd659d6c16.png','Dressing room location'),(221,'If you have nothing to do during your shift, what should you do?','Nothing to do at the moment? It happens. Simply alert the manager or continue with customer service activities to build sales or loyalty count.','Get guest to sign up for loyalties','Greet and help customers','Let a manager know','All these options','All these options',31,0,51,'2985d64a-da7b-4b74-975a-4e2d1e3229e6.png','2985d64a-da7b-4b74-975a-4e2d1e3229e6.png','Idle time'),(231,'Which of the following Point of Sale actions require a manager\'s authorization?','When calling for a manager for authorization, always apologize to the customer for the delay.','Remove Item','Use of Department Key','Suspend/Resume Transaction','Price Override','Price Override',31,1,61,'e9a980e1-e3f2-4043-90b0-c759e4c55fc4.jpg','e9a980e1-e3f2-4043-90b0-c759e4c55fc4.jpg','POS Policy 44a'),(241,'You are in the middle of a task when a customer asks where to find an item. What do you do?','By walking with the customer to the product, you build a rapport with the customer. If you hand the product to the customer, there is a greater chance that she will buy it.','Point her in the general direction','Tell the customer the aisle #','Politely explain you are very busy','Walk to product and hand it to her','Walk to product and hand it to her',31,1,61,'2041a4e5-de87-45b3-bd5c-00bb8f0aa5c6.jpg','2041a4e5-de87-45b3-bd5c-00bb8f0aa5c6.jpg','Customer Service #244'),(251,'How often should utility clerks do store sweep to clean the floor and return misplaced items?','The sweep is one of the main duties for a utility clerk. By performing a sweep every hour, we ensure that the store always looks like an inviting place to shop.','Once per day','At the start of every shift','Every fifteen minutes','Every hour','Every hour',31,1,61,'e923ee2b-e622-46f8-9d80-fea4869cc7da.jpg','e923ee2b-e622-46f8-9d80-fea4869cc7da.jpg','Sweep Floor'),(261,'What type of Vegetable is this?','aka Curly Cabbage. With ruffled, lacy, deeply ridged leaves, perhaps the prettiest cabbages around. Delicious in salads or stir-fried.','Napa Cabbage','Chinese Cabbage','Bok choy','Savoy Cabbage','Savoy Cabbage',31,1,61,'6ab362a8-d571-42d5-aeb8-13c11ea83944.jpg','6ab362a8-d571-42d5-aeb8-13c11ea83944.jpg','Vegetables'),(271,'A customer asks for a recommendation for a wine to go with roast beef. What would you suggest?','Cabernet Sauvignon is a red wine with strong tannins, high acidity, and powerful flavors, usually black currant. Food pairings include beef and lamb dishes, venison, and a variety of cheeses.','Pinoit Grigio','Chardonnay','Sauvignon Blanc','Cabernet Sauvignon','Cabernet Sauvignon',31,1,61,'dc7327a4-54dc-48fb-a5ff-2bc6677862fa.jpg','dc7327a4-54dc-48fb-a5ff-2bc6677862fa.jpg','Red Wine'),(281,'A customer is interested in a cashmere sweater. She asks: Is this item going to go on sale? What do you say?','As part of our 30-day return policy, customers may request a credit if the price of an item they\'ve purchased is reduced.','Offer to call before the sale','Popular item will not last until sale','I don\'t have any info on sales','If item reduced in 30 days, get credit','If item reduced in 30 days, get credit',31,1,71,'2320e335-a6be-4199-9cbe-b0cba3bb70c1.jpg','2320e335-a6be-4199-9cbe-b0cba3bb70c1.jpg','Sale Policies'),(291,'This style of collar is called a(n)','The button down is a classic, versatile look that uses buttons to fasten the collar to the shirt.','Ainsley','Golf Collar','English Spread','Button-down','Button-down',31,0,71,'57e650d7-80a2-48b9-b9b5-c2ad7eb49f78.jpg','57e650d7-80a2-48b9-b9b5-c2ad7eb49f78.jpg','Product knowledge: Shirts'),(301,'How much will our 100% cotton shirts shrink after the first wash?','All our cotton shirts are pre-shrunk. Customers should notice no shrinking. This is one of the things that makes us unique and special.','2\" in length,  1/2\" in girth','1/2\" in length, 2\" in girth','About an inch in both directions','Not at all','Not at all',31,1,71,'66cd46e3-a6e1-487c-aba8-f79ea96abe7f.jpg','66cd46e3-a6e1-487c-aba8-f79ea96abe7f.jpg','Product knowledge: Shirts'),(311,'Which of these is least important when building a relationship with your client?','The two most important pieces of information you can get from a client are 1) her interests 2) her permission for you to contact her.','What she\'d like to be contacted about','The best times to contact her','How she\'d like to be contacted','Where she lives','Where she lives',31,1,71,'a74478f8-b9ea-4bd1-b55d-435d67300855.jpg','a74478f8-b9ea-4bd1-b55d-435d67300855.jpg','Client relationships 43'),(321,'A customer walks into the store and asks to return items she purchased through the company website. What should you do?','We encourage our customers to shop through all of our channels. To make their shopping experience convenient, they can also return items through any of those channels - no matter how they originally p','Refund the purchase price in cash','Check website for return policy','Process return if store carries item','Cedit original form of payment','Cedit original form of payment',31,1,71,'78ed4852-b292-444b-b870-73011989e11f.jpg','78ed4852-b292-444b-b870-73011989e11f.jpg','Return Policy 22'),(331,'A customer wants to return a $3,000 cocktail dress 3 days after buying it. You suspect she has worn it to an event. What should you do?','Our 30-day return policy applies to all unused / undamaged merchandise no matter how expensive it is. Be sure to inspect the garment for damage.','Call your manager','Credit applied in 1 day after inspected','Tell her she can\'t return it','Process the return just like any other','Process the return just like any other',31,1,71,'ad4c62db-45ce-475c-a57a-6355b7ce91b1.jpg','ad4c62db-45ce-475c-a57a-6355b7ce91b1.jpg','Return Policy 43'),(341,'What style of shoe is this?','You can tell it\'s a wingtip because of the wing shaped countours near the toe, as well as the perforations.','Cap-toe','Loafer','Saddle shoe','Wingtip','Wingtip',31,0,71,'ed89c989-6e66-4faf-8ddb-a22afc8ec890.jpg','ed89c989-6e66-4faf-8ddb-a22afc8ec890.jpg','Product knowledge: Shoes'),(351,'A customer finds a pair of jeans she loves, but they\'re not available in her size. What do you do?','You should offer customers merchandise that we have anywhere in the chain, whether it\'s available in another store or on the web.','Tell her available size fits','Tell her to return for next delivery','Sell her on a different item','Check inventory at other stores.','Check inventory at other stores.',2,1,2,'26e436af-04ef-4160-bd44-5a75ba3b13bc.jpg','26e436af-04ef-4160-bd44-5a75ba3b13bc.jpg','Fitting assistance'),(361,'When bagging, you should always avoid doing the following:','Meat should always be bagged separately to avoid contamination by bacteria; heavy items can crush produce items and other fragile items; double bagging is sometimes very necessary; and chemicals shoul','Place meat in a separate bag','Place light items on top of tomatoes','Double bag heavy items','Put cleaning chemicals with food','Put cleaning chemicals with food',31,1,61,'9f2719d9-d077-409f-a0ed-db1317ce8492.jpg','9f2719d9-d077-409f-a0ed-db1317ce8492.jpg','Bagging Policy 37'),(371,'You see a customer take a small item off the shelf and put it in her purse. What do you do?','Never approach a shoplifter and confront them. We have procedures that must be followed and not doing so may open the company (and you) up to legal issues.','Nothing','Ask her to empty her purse','Confront her immediately','Report it to security','Report it to security',31,1,61,'34593809-ae93-4791-91cd-6bb6c45e1008.jpg','34593809-ae93-4791-91cd-6bb6c45e1008.jpg','Shoplifting Policy');
/*!40000 ALTER TABLE `tblquizquestions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblquizresulttotal`
--

DROP TABLE IF EXISTS `tblquizresulttotal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblquizresulttotal` (
  `ResultID` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` int(11) DEFAULT NULL,
  `QuizID` int(11) DEFAULT NULL,
  `Total` int(11) DEFAULT NULL,
  PRIMARY KEY (`ResultID`)
) ENGINE=InnoDB AUTO_INCREMENT=52 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblquizresulttotal`
--

LOCK TABLES `tblquizresulttotal` WRITE;
/*!40000 ALTER TABLE `tblquizresulttotal` DISABLE KEYS */;
INSERT INTO `tblquizresulttotal` VALUES (41,161,41,100),(51,171,41,100);
/*!40000 ALTER TABLE `tblquizresulttotal` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblredeem`
--

DROP TABLE IF EXISTS `tblredeem`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblredeem` (
  `Redeem_ID` int(11) NOT NULL AUTO_INCREMENT,
  `User_ID` int(11) NOT NULL,
  `Reward_ID` int(11) NOT NULL,
  `Redeem_Points` int(11) NOT NULL,
  `Redeem_Date` datetime NOT NULL,
  PRIMARY KEY (`Redeem_ID`)
) ENGINE=MyISAM AUTO_INCREMENT=71 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblredeem`
--

LOCK TABLES `tblredeem` WRITE;
/*!40000 ALTER TABLE `tblredeem` DISABLE KEYS */;
/*!40000 ALTER TABLE `tblredeem` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblreferencedata`
--

DROP TABLE IF EXISTS `tblreferencedata`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblreferencedata` (
  `ReferenceData_ID` int(11) NOT NULL,
  `Reference_Code` varchar(50) DEFAULT NULL,
  `Item_Code` varchar(50) DEFAULT NULL,
  `Description` varchar(200) DEFAULT NULL,
  `Sort_Order` int(11) DEFAULT NULL,
  `Active` tinyint(4) DEFAULT NULL,
  `Parent_ID` int(11) DEFAULT NULL,
  PRIMARY KEY (`ReferenceData_ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblreferencedata`
--

LOCK TABLES `tblreferencedata` WRITE;
/*!40000 ALTER TABLE `tblreferencedata` DISABLE KEYS */;
INSERT INTO `tblreferencedata` VALUES (1,'TYPE','AWARD','AWARD',1,1,NULL),(2,'TYPE','CONTEST','CONTEST',2,1,NULL),(3,'KPI_TYPE','Cumulative','Cumulative',1,1,NULL),(4,'KPI_TYPE','Maximum','Maximum',2,1,NULL),(5,'KPI_TYPE','Boolean','Boolean',3,1,NULL),(6,'ROLE_TYPE','Admin','Admin',1,1,NULL),(7,'ROLE_TYPE','Manager','Manager',2,1,NULL),(8,'ROLE_TYPE','Player','Player',3,1,NULL),(9,'SITE_TYPE','Store-1','Store-1',1,1,NULL),(10,'SITE_TYPE','Store-2','Store-2',2,1,NULL),(11,'SITE_TYPE','Store-3','Store-3',3,1,NULL),(12,'SITE_TYPE','Store-4','Store-4',4,1,NULL),(13,'SITE_TYPE','Store-5','Store-5',5,1,NULL),(14,'SITE_TYPE','Store-6','Store-6',6,1,NULL),(15,'SITE_TYPE','Store-7','Store-7',7,1,NULL),(16,'SITE_TYPE','Store-8','Store-8',8,1,NULL),(17,'SITE_TYPE','Store-9','Store-9',9,1,NULL),(18,'SITE_TYPE','Store-10','Store-10',10,1,NULL),(19,'KPI_CATEGORY','Training','Training',1,1,NULL),(20,'KPI_CATEGORY','Performance','Performance',2,1,NULL),(21,'KPI_CATEGORY','Manager Recognition','Manager Recognition',3,1,NULL),(22,'KPI_CATEGORY','Other','Other',4,1,NULL),(23,'AWARD_CATEGORY','Manager','Manager',1,0,NULL),(24,'AWARD_CATEGORY','Level','Level',2,1,NULL),(25,'AWARD_CATEGORY','Performance','Performance',3,1,NULL),(26,'AWARD_CATEGORY','Contest','Contest',4,1,NULL),(27,'QUIZ_CATEGORY','Policy','Policy',1,1,NULL),(28,'QUIZ_CATEGORY','Process','Process',2,1,NULL);
/*!40000 ALTER TABLE `tblreferencedata` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblrewardimages`
--

DROP TABLE IF EXISTS `tblrewardimages`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblrewardimages` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `Reward_Image` varchar(100) DEFAULT NULL,
  `Reward_Thumbnail` varchar(100) DEFAULT NULL,
  `Active` int(1) DEFAULT '1',
  `Reward_ID` int(11) DEFAULT NULL,
  `Uploaded_Date` date DEFAULT NULL,
  `Current_Image` int(1) DEFAULT '0',
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=122 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblrewardimages`
--

LOCK TABLES `tblrewardimages` WRITE;
/*!40000 ALTER TABLE `tblrewardimages` DISABLE KEYS */;
INSERT INTO `tblrewardimages` VALUES (91,'d6b29b20-4ba9-46b3-a50a-72e529b16bd7.jpg','d6b29b20-4ba9-46b3-a50a-72e529b16bd7.jpg',1,41,'2015-07-23',1),(101,'fded3885-f878-4d31-a811-5d801914949b.jpg','fded3885-f878-4d31-a811-5d801914949b.jpg',1,51,'2015-07-23',1),(71,'3acef61e-f9b0-49a8-8f25-6fbf3de5ddf0.png','3acef61e-f9b0-49a8-8f25-6fbf3de5ddf0.png',1,21,'2015-07-23',1),(81,'11c7ed4d-7441-4974-b9f3-00f4ef675d5a.jpg','11c7ed4d-7441-4974-b9f3-00f4ef675d5a.jpg',1,31,'2015-07-23',1),(111,'91f831b3-5400-47b7-8fa6-dd821961379e.png','91f831b3-5400-47b7-8fa6-dd821961379e.png',1,61,'2015-07-23',1),(121,'b76c2476-67c6-4c22-adee-c1d2724e7037.jpg','b76c2476-67c6-4c22-adee-c1d2724e7037.jpg',1,71,'2015-07-23',1);
/*!40000 ALTER TABLE `tblrewardimages` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblrewards`
--

DROP TABLE IF EXISTS `tblrewards`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblrewards` (
  `Reward_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Reward_Name` varchar(100) NOT NULL,
  `Reward_Descp` varchar(200) DEFAULT NULL,
  `Reward_Cost` int(11) DEFAULT NULL,
  `Active` tinyint(1) DEFAULT '1',
  `Reward_Type` int(11) DEFAULT '0',
  PRIMARY KEY (`Reward_ID`),
  UNIQUE KEY `Reward_Name` (`Reward_Name`)
) ENGINE=InnoDB AUTO_INCREMENT=72 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblrewards`
--

LOCK TABLES `tblrewards` WRITE;
/*!40000 ALTER TABLE `tblrewards` DISABLE KEYS */;
INSERT INTO `tblrewards` VALUES (21,'Logo T-shirt','Get your own quality T with the world famous Acme logo',25,1,1),(31,'10% Employee Discount','Get another 10% discount off any purchase in the store for a month.',2500,1,0),(41,'Give to Orphans','We will donate $500 to the Retail Orphan Initiative (RetailROI) in your name.',4000,1,1),(51,'Lunch with Manager','Have an informal lunch with your manager. Learn about how your manager makes decisions and runs the store',5000,1,1),(61,'Pick of Shifts','Choose which shifts you would like to work for the next month.  Make sure you get the time slots off work when you need them. Or for special occasions. Or just because you like to sleep late.',6000,1,1),(71,'Best Parking Spot','Streamline your commute! Park right next to the main entrance. And show off your new wheels!',7000,1,1);
/*!40000 ALTER TABLE `tblrewards` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblroles`
--

DROP TABLE IF EXISTS `tblroles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblroles` (
  `Role_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Role_Name` varchar(100) DEFAULT NULL,
  `Active` tinyint(4) DEFAULT '1',
  `ActiveUpdatedDate` date DEFAULT NULL,
  PRIMARY KEY (`Role_ID`),
  UNIQUE KEY `Role_Name` (`Role_Name`)
) ENGINE=InnoDB AUTO_INCREMENT=172 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblroles`
--

LOCK TABLES `tblroles` WRITE;
/*!40000 ALTER TABLE `tblroles` DISABLE KEYS */;
INSERT INTO `tblroles` VALUES (1,'Admin',1,'2014-08-07'),(2,'Manager',1,'2014-03-28'),(171,'Acme Sales Assoc',1,'2015-07-23');
/*!40000 ALTER TABLE `tblroles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblround`
--

DROP TABLE IF EXISTS `tblround`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblround` (
  `RoundID` int(11) NOT NULL AUTO_INCREMENT,
  `MatchID` int(11) NOT NULL,
  `RoundNumber` int(11) DEFAULT NULL,
  `RoundName` varchar(100) DEFAULT NULL,
  `NoOfDataSets` int(11) DEFAULT NULL,
  `TimePerRound` int(11) DEFAULT NULL,
  `PointsPerRound` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `ShowHint` int(11) DEFAULT '0',
  PRIMARY KEY (`RoundID`)
) ENGINE=MyISAM AUTO_INCREMENT=112 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblround`
--

LOCK TABLES `tblround` WRITE;
/*!40000 ALTER TABLE `tblround` DISABLE KEYS */;
INSERT INTO `tblround` VALUES (25,91,2,'Rookie',4,60,125,'2014-08-23 17:59:14',1),(71,71,1,'Beginner',5,60,100,'2014-08-22 18:41:04',1),(81,71,2,'Rookie',5,60,125,'2014-08-22 18:41:28',1),(91,81,1,'Beginner',5,60,100,'2014-08-22 18:46:28',1),(101,81,2,'Rookie',5,60,150,'2014-08-22 18:46:44',1),(24,91,1,'Beginner',4,60,100,'2014-08-23 17:58:37',1);
/*!40000 ALTER TABLE `tblround` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblrw_cube_gamefacts`
--

DROP TABLE IF EXISTS `tblrw_cube_gamefacts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblrw_cube_gamefacts` (
  `FactID` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` int(11) DEFAULT NULL,
  `RoleID` int(11) DEFAULT NULL,
  `LevelID` int(11) DEFAULT NULL,
  `QuizID` int(11) DEFAULT NULL,
  `QuestionID` int(11) DEFAULT NULL,
  `MatchID` int(11) DEFAULT NULL,
  `KpiID` int(11) DEFAULT NULL,
  `PointsAchieved` int(11) DEFAULT NULL,
  `ElaspedTime` int(11) DEFAULT NULL,
  `IsCorrect` int(11) DEFAULT NULL,
  `GameTime` datetime DEFAULT NULL,
  `ReduceChoices_LifeLine` int(11) DEFAULT NULL,
  `ReplaceQuestion_LifeLine` int(11) DEFAULT NULL,
  `AddCounter_LifeLine` int(11) DEFAULT NULL,
  PRIMARY KEY (`FactID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblrw_cube_gamefacts`
--

LOCK TABLES `tblrw_cube_gamefacts` WRITE;
/*!40000 ALTER TABLE `tblrw_cube_gamefacts` DISABLE KEYS */;
/*!40000 ALTER TABLE `tblrw_cube_gamefacts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblrw_kpidim`
--

DROP TABLE IF EXISTS `tblrw_kpidim`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblrw_kpidim` (
  `KpiID` int(11) NOT NULL,
  `KpiName` varchar(300) DEFAULT NULL,
  `Measure` varchar(300) DEFAULT NULL,
  `Category` varchar(200) DEFAULT NULL,
  `Description` varchar(500) DEFAULT NULL,
  `TypeLevel` varchar(10) DEFAULT NULL,
  `TypeAward` varchar(10) DEFAULT NULL,
  `TypeContest` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`KpiID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblrw_kpidim`
--

LOCK TABLES `tblrw_kpidim` WRITE;
/*!40000 ALTER TABLE `tblrw_kpidim` DISABLE KEYS */;
/*!40000 ALTER TABLE `tblrw_kpidim` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblrw_leveldim`
--

DROP TABLE IF EXISTS `tblrw_leveldim`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblrw_leveldim` (
  `LevelID` int(11) NOT NULL,
  `LevelName` varchar(200) DEFAULT NULL,
  `BaseHours` int(11) DEFAULT NULL,
  `Points` int(11) DEFAULT NULL,
  `RoleID` int(11) DEFAULT NULL,
  PRIMARY KEY (`LevelID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblrw_leveldim`
--

LOCK TABLES `tblrw_leveldim` WRITE;
/*!40000 ALTER TABLE `tblrw_leveldim` DISABLE KEYS */;
/*!40000 ALTER TABLE `tblrw_leveldim` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblrw_matchdatasetdim`
--

DROP TABLE IF EXISTS `tblrw_matchdatasetdim`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblrw_matchdatasetdim` (
  `DatasetID` int(11) NOT NULL,
  `DatasetElements` varchar(500) DEFAULT NULL,
  `SiteName` varchar(200) DEFAULT NULL,
  `MatchID` int(11) DEFAULT NULL,
  `RoleID` int(11) DEFAULT NULL,
  `LevelID` int(11) DEFAULT NULL,
  PRIMARY KEY (`DatasetID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblrw_matchdatasetdim`
--

LOCK TABLES `tblrw_matchdatasetdim` WRITE;
/*!40000 ALTER TABLE `tblrw_matchdatasetdim` DISABLE KEYS */;
/*!40000 ALTER TABLE `tblrw_matchdatasetdim` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblrw_matchdim`
--

DROP TABLE IF EXISTS `tblrw_matchdim`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblrw_matchdim` (
  `MatchID` int(11) NOT NULL,
  `KpiID` int(11) DEFAULT NULL,
  `RoleID` int(11) DEFAULT NULL,
  `LevelID` int(11) DEFAULT NULL,
  `MatchName` varchar(300) DEFAULT NULL,
  `CompletionPoints` int(11) DEFAULT NULL,
  `TimesPlayable` int(11) DEFAULT NULL,
  `NoOfDataSet` int(11) DEFAULT NULL,
  `NoOfRounds` int(11) DEFAULT NULL,
  PRIMARY KEY (`MatchID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblrw_matchdim`
--

LOCK TABLES `tblrw_matchdim` WRITE;
/*!40000 ALTER TABLE `tblrw_matchdim` DISABLE KEYS */;
/*!40000 ALTER TABLE `tblrw_matchdim` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblrw_questiondim`
--

DROP TABLE IF EXISTS `tblrw_questiondim`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblrw_questiondim` (
  `QuesID` int(11) NOT NULL,
  `Text` varchar(300) DEFAULT NULL,
  `Explanation` varchar(500) DEFAULT NULL,
  `Answer1` varchar(300) DEFAULT NULL,
  `Answer2` varchar(300) DEFAULT NULL,
  `Answer3` varchar(300) DEFAULT NULL,
  `Answer4` varchar(300) DEFAULT NULL,
  `CorrectAnswer` varchar(300) DEFAULT NULL,
  `CategoryName` varchar(200) DEFAULT NULL,
  `SiteName` varchar(200) DEFAULT NULL,
  `QuizID` int(11) DEFAULT NULL,
  `RoleID` int(11) DEFAULT NULL,
  `LevelID` int(11) DEFAULT NULL,
  PRIMARY KEY (`QuesID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblrw_questiondim`
--

LOCK TABLES `tblrw_questiondim` WRITE;
/*!40000 ALTER TABLE `tblrw_questiondim` DISABLE KEYS */;
/*!40000 ALTER TABLE `tblrw_questiondim` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblrw_quizdim`
--

DROP TABLE IF EXISTS `tblrw_quizdim`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblrw_quizdim` (
  `QuizID` int(11) NOT NULL,
  `KpiID` int(11) DEFAULT NULL,
  `RoleID` int(11) DEFAULT NULL,
  `LevelID` int(11) DEFAULT NULL,
  `QuizName` varchar(200) DEFAULT NULL,
  `NoOfQuestions` int(11) DEFAULT NULL,
  `TimePerQuestion` int(11) DEFAULT NULL,
  `TimesPlayable` int(11) DEFAULT NULL,
  `PointsQuestion` int(11) DEFAULT NULL,
  `DeductionTimeDelay` int(11) DEFAULT NULL,
  PRIMARY KEY (`QuizID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblrw_quizdim`
--

LOCK TABLES `tblrw_quizdim` WRITE;
/*!40000 ALTER TABLE `tblrw_quizdim` DISABLE KEYS */;
/*!40000 ALTER TABLE `tblrw_quizdim` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblrw_roledim`
--

DROP TABLE IF EXISTS `tblrw_roledim`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblrw_roledim` (
  `RoleID` int(11) NOT NULL,
  `RoleName` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`RoleID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblrw_roledim`
--

LOCK TABLES `tblrw_roledim` WRITE;
/*!40000 ALTER TABLE `tblrw_roledim` DISABLE KEYS */;
/*!40000 ALTER TABLE `tblrw_roledim` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblrw_userdim`
--

DROP TABLE IF EXISTS `tblrw_userdim`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblrw_userdim` (
  `UserID` int(11) NOT NULL,
  `EMPID` varchar(100) DEFAULT NULL,
  `SystemRole` varchar(50) DEFAULT NULL,
  `UserRole` int(11) DEFAULT NULL,
  `UserLevel` int(11) DEFAULT NULL,
  `UserName` varchar(500) DEFAULT NULL,
  `SiteName` varchar(500) DEFAULT NULL,
  `UserPoints` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblrw_userdim`
--

LOCK TABLES `tblrw_userdim` WRITE;
/*!40000 ALTER TABLE `tblrw_userdim` DISABLE KEYS */;
/*!40000 ALTER TABLE `tblrw_userdim` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblscores`
--

DROP TABLE IF EXISTS `tblscores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblscores` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `User_ID` int(11) NOT NULL,
  `U_Type` varchar(50) DEFAULT NULL,
  `Type_ID` int(11) DEFAULT NULL,
  `Score` int(11) DEFAULT NULL,
  `Measure` varchar(50) DEFAULT NULL,
  `Entry_Date` datetime DEFAULT NULL,
  `LevelID` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=552 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblscores`
--

LOCK TABLES `tblscores` WRITE;
/*!40000 ALTER TABLE `tblscores` DISABLE KEYS */;
INSERT INTO `tblscores` VALUES (481,161,'KPI',171,0,NULL,'2015-07-13 20:48:32',291),(491,171,'KPI',171,0,NULL,'2015-07-13 20:53:54',291),(501,151,'KPI',181,700,NULL,'2015-07-16 18:31:21',311),(511,341,'KPI',101,1,NULL,'2015-07-23 21:17:39',411),(521,341,'KPI',111,1,NULL,'2015-07-23 21:17:39',411),(531,341,'KPI',121,100,NULL,'2015-07-23 21:17:39',411),(541,341,'KPI',131,500,NULL,'2015-07-23 21:17:39',411),(551,341,'KPI',141,20,NULL,'2015-07-23 21:17:40',411);
/*!40000 ALTER TABLE `tblscores` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblsecurityanswers`
--

DROP TABLE IF EXISTS `tblsecurityanswers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblsecurityanswers` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` int(11) DEFAULT NULL,
  `Question_ID` int(11) DEFAULT NULL,
  `Answer` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=552 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblsecurityanswers`
--

LOCK TABLES `tblsecurityanswers` WRITE;
/*!40000 ALTER TABLE `tblsecurityanswers` DISABLE KEYS */;
INSERT INTO `tblsecurityanswers` VALUES (231,131,1,'1000:nHBu1JG7sb+h3kRmPS+5kuKiFWj5OD7c:LAPHY6Og1tFrDHOvS16KD7XiPxyDJak3'),(241,131,2,'1000:zvaG8j7upt+rsWsa0buKQyGmwD4hE8s5:NutRx6zjRXg12HVi83p7lMNs/ybkJ4lY'),(251,131,3,'1000:bg90u4btA5Y1fVAwrXcwQSAvX/E87mqq:iSE46lIugO/lg4DWkPKL7qvzVjR0gRML'),(261,141,1,'1000:cLtLCJI+8WHHsa0Im718knKe5mS/uY01:KB5KfFCOzTXEtVbBJPMILzpdEwRCpClF'),(271,141,2,'1000:mVFVkaW1HzakBZq3aZxGwKrbaHc7cQQz:UoOu4h7Kq+VzLBkUeAlv/KeLWuWtqE4/'),(281,141,3,'1000:ePoBcUp96kfrZymKipwWKpVgKJcd4Ci0:mkrHZf5+9IVqj+tCH08ihfsiLE5ipr7C'),(291,151,1,'1000:HYJJhHkNHDd98/jzstCussLflDRUumlk:E+yI0DZvCvvwjJ8ITcQoZvWapzxw3WNi'),(301,151,2,'1000:AthzDZnNE4vNdEwRAR+E9iXzxwGXGxuk:9oz+et6fQ6M5BMQpOoEWCa7IQbkjyHtT'),(311,151,3,'1000:qz6kOeTixC0cC9xFfW6VfoAHFKlPJ+Is:faDYc2LOcvkuXXU+zJUiK96ixBR0l7mf'),(321,161,1,'1000:EFp/K7U9UdXpAz9E1wi2SCMTbNEZ2d/4:GEUhbXr417KbXKLGvSPVSj+dLNTsow7J'),(331,161,2,'1000:C8ABe34FbAleECbNxxPbn6VzkcYa1at2:cGpCM79tQG/Uz3shvtnefuL2AkWGDI4r'),(341,161,3,'1000:kTa8D6XRTVp7AlblXeSwczg7pn+IK/eu:NK8TB+VSVWNdPKdugsWiB4es76HLF4l8'),(351,171,1,'1000:ahzmbHK6fau2yvRU57g8vrUPUkyO1mfs:nMNxWVqKYyyx0y4Th0rxemL8hbIqhBxH'),(361,171,2,'1000:iBjm90xsQEJRMeNS2eOW1VGXmwRKMes2:/W9umVemzOd35iANkS1GHLI8prq1dpn5'),(371,171,3,'1000:NluKGuJ4YqFC4E/EOLNFcgTVmF/r2UWa:g72TXpAL2LThdBfWc3V0hW/nVMito8qV'),(381,181,4,'1000:uJ/BVY3Tq4zX3QnY7XO9KMtZqOlKNqk2:vSgqN6+GnqWss2HVFfezK8nzJ+rRCtkm'),(391,181,5,'1000:a7dQchU/KG7GwSToseA/tO84+xpnhnfQ:2iKIy7Opt3popqT8j1iI6PqyQh8/SO+z'),(401,181,6,'1000:H7WakHm3AvSZ+5C2q5PbDzJLqP2V7GEw:RovBWhTIOEFHVba/lUs5eqRffxXSjAs9'),(411,11,1,'1000:hMZGB4+lprw3S5/cI90ARjwxukL+frHi:CXPqAceojJCnrdFwkqsUhvh9mc+e2c6l'),(421,11,2,'1000:5JKDztHwC/AiYz5C7EtsVruLG4fEtU/q:CpRhYluJnlGVp/qH2GpB+CPx7dgvIrQx'),(431,11,3,'1000:AO6unfp5K0boBP/GWZMPYk2iqlKNLDQt:wQwt3lXgSrsn4TxZxkLoxIk3D5rhWMyp'),(441,321,1,'1000:Ud55tz859oP3AMslQ91q7FMW4M7bstSg:e0CnKr2XN58s1uZasVFeBHoZQi2nAbGi'),(451,321,2,'1000:8KCgp1oQn3JjVqO+BxvMPmC/LDT1jUvh:xg3ZrophhBIkpXLg8N51dMnCCUdcGdZf'),(461,321,3,'1000:QjcI/C2cphQ4/FpvEkSON3KfPvdEWkXH:Jhp1avZwk+h4DvcfSOm3T9r4J17gngaZ'),(471,331,1,'1000:FMD7XUZCDrC+DNJKwBSyGLdob/gVJWL9:5w5Dotkg0cyWN5j3XI1kQLb2zWPOP9OL'),(481,331,2,'1000:TndvyCwYl1tcUwx+IL/PMkcOpEeHo9ox:c6yfmsytIRfxXApDifEd73aNiRsSqqS0'),(491,331,3,'1000:7DYRcQfvxNhaDmLJEtVO4iAuFm13OSQX:aPAdipbGhi4PvIX9CA0Iz7g5iGQOxhnN'),(501,341,1,'1000:hHu1g7NrR6+uE8dfArMYdgPPSOUBCB+j:wZVugwcFX2xJKQlJAb4c0Jr5YM4ylmBb'),(511,341,2,'1000:wezVry79NfAxAVRXfiN/AtdPK4G1p/rQ:jTilQGKJmBG5mJE1TVPj33wWgTP+ix8X'),(521,341,3,'1000:6fNcQKGSc3yjgvbPKjk2qyyDp/K7cGNH:+fkgU1t1nt5FOaq8oRgKl75HY54JcTZw'),(531,351,1,'1000:h8ZRzWnvnbAPD3eLUlPXDj4BUKOWvwV0:6Vq4ITZiJDd8CGJ/9ZtZgAsatcPnCuZQ'),(541,351,2,'1000:BhMUH9hwHktqG9hk+vIK0qqGuXYdBbls:yesUkh44d9Gv0nLhDXpBeveHkYtc1JY7'),(551,351,3,'1000:Q4cpZjauFLKhKD5KbuMHwpyEwYXYPIt/:7rfaVZu9WrP8CHtm/+ZZTfqd4Xt6U3fY');
/*!40000 ALTER TABLE `tblsecurityanswers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblsecurityquestions`
--

DROP TABLE IF EXISTS `tblsecurityquestions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblsecurityquestions` (
  `Question_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Question_Text` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`Question_ID`)
) ENGINE=MyISAM AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblsecurityquestions`
--

LOCK TABLES `tblsecurityquestions` WRITE;
/*!40000 ALTER TABLE `tblsecurityquestions` DISABLE KEYS */;
INSERT INTO `tblsecurityquestions` VALUES (1,'What is your favorite color?'),(2,'What highschool did you go to?'),(3,'What is your hometown?');
/*!40000 ALTER TABLE `tblsecurityquestions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblsite`
--

DROP TABLE IF EXISTS `tblsite`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblsite` (
  `site_id` int(11) NOT NULL AUTO_INCREMENT,
  `site_name` varchar(50) NOT NULL,
  `site_type` varchar(50) NOT NULL,
  `site_address` varchar(150) NOT NULL,
  `Active` tinyint(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (`site_id`)
) ENGINE=MyISAM AUTO_INCREMENT=32 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblsite`
--

LOCK TABLES `tblsite` WRITE;
/*!40000 ALTER TABLE `tblsite` DISABLE KEYS */;
INSERT INTO `tblsite` VALUES (1,'Acme - Broad St','Store-1','454 Broad Street\r\nPensacola, FL',1);
/*!40000 ALTER TABLE `tblsite` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbltarget`
--

DROP TABLE IF EXISTS `tbltarget`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbltarget` (
  `Target_ID` int(11) NOT NULL AUTO_INCREMENT,
  `Target_Value` int(11) DEFAULT NULL,
  `KPI_ID` int(11) DEFAULT NULL,
  `Level_ID` int(11) DEFAULT NULL,
  `Role_ID` int(11) DEFAULT NULL,
  `Active` tinyint(1) DEFAULT '1',
  `Target_Desc` varchar(500) DEFAULT NULL,
  `Points` int(11) DEFAULT NULL,
  `Target_Order` int(11) DEFAULT NULL,
  PRIMARY KEY (`Target_ID`),
  KEY `RoleID` (`Role_ID`),
  KEY `LevelID` (`Level_ID`),
  KEY `KPIID` (`KPI_ID`),
  CONSTRAINT `KPIID` FOREIGN KEY (`KPI_ID`) REFERENCES `tblkpi` (`KPI_ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `LevelID` FOREIGN KEY (`Level_ID`) REFERENCES `tbllevel` (`Level_ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `RoleID` FOREIGN KEY (`Role_ID`) REFERENCES `tblroles` (`Role_ID`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=492 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbltarget`
--

LOCK TABLES `tbltarget` WRITE;
/*!40000 ALTER TABLE `tbltarget` DISABLE KEYS */;
INSERT INTO `tbltarget` VALUES (391,1,101,411,171,1,'',100,1),(411,1,111,411,171,1,'',100,2),(421,100,121,411,171,1,'',100,3),(431,500,131,411,171,1,'',250,4),(441,20,141,411,171,1,'',200,5),(451,8,151,421,171,1,'',200,1),(461,100,161,421,171,1,'',100,2),(471,50,141,421,171,1,'',200,3),(481,2000,131,421,171,1,'',250,4),(491,10,171,421,171,1,'',200,5);
/*!40000 ALTER TABLE `tbltarget` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblteam`
--

DROP TABLE IF EXISTS `tblteam`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblteam` (
  `team_id` int(11) NOT NULL AUTO_INCREMENT,
  `team_name` varchar(50) DEFAULT NULL,
  `team_leader` int(11) DEFAULT NULL,
  PRIMARY KEY (`team_id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblteam`
--

LOCK TABLES `tblteam` WRITE;
/*!40000 ALTER TABLE `tblteam` DISABLE KEYS */;
/*!40000 ALTER TABLE `tblteam` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbluser`
--

DROP TABLE IF EXISTS `tbluser`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbluser` (
  `UserID` int(11) NOT NULL AUTO_INCREMENT,
  `U_EmpID` varchar(200) NOT NULL,
  `U_Name` varchar(50) NOT NULL,
  `U_SysRole` varchar(50) NOT NULL,
  `U_RolesID` int(11) NOT NULL,
  `U_Password` varchar(100) DEFAULT NULL,
  `U_FirstName` varchar(50) DEFAULT NULL,
  `U_LastName` varchar(20) DEFAULT NULL,
  `U_NickName` varchar(50) DEFAULT NULL,
  `Active` tinyint(4) DEFAULT '1',
  `U_Email` varchar(45) DEFAULT NULL,
  `U_SiteID` int(11) DEFAULT NULL,
  `U_TeamID` int(11) DEFAULT NULL,
  `ActiveUpdatedDate` datetime DEFAULT NULL,
  `U_EmpNo` int(11) DEFAULT NULL,
  `ManagerID` int(11) DEFAULT '0',
  `Display_Name` int(11) NOT NULL DEFAULT '1',
  `U_Points` int(11) NOT NULL DEFAULT '0',
  `LastLogin` datetime DEFAULT NULL,
  PRIMARY KEY (`UserID`),
  UNIQUE KEY `U_Name` (`U_Name`)
) ENGINE=InnoDB AUTO_INCREMENT=361 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbluser`
--

LOCK TABLES `tbluser` WRITE;
/*!40000 ALTER TABLE `tbluser` DISABLE KEYS */;
INSERT INTO `tbluser` VALUES (1,'EMP1','Admin','Admin',1,'1000:Myy1NgFm4oYRAQgcGIDAA1/KUtFEKdxH:UBGWkbfizVyOIcHLF/fXX6RyaTz56zlV','Stuart','Silverman','Stu',1,'stuart@impactsimulations.com',1,NULL,'2014-04-21 23:31:59',NULL,2,1,0,'2015-03-30 21:27:16'),(11,'EMP2','TopManager','Manager',2,'1000:h0FIgsSC0c/eKlwvsr30tHsgo6WCkS2z:XOHKDvPXaGeaiNeYw03neDnPif5oo7Eo','John','Parkin','',1,'jparkin@impactsimulations.com',1,NULL,'2015-07-23 21:09:11',NULL,0,1,0,NULL),(321,'EMP3','LindaM','Manager',2,'1000:Mvs05cSvDMkod7hFT4NAUY/dWKSfbWBl:KvEVZLZ5TXkBq1tf+1JrS0kTxRWZPJLX','Linda','McPhee','Lindy',1,'',1,NULL,'2015-07-23 21:11:15',NULL,11,1,0,NULL),(331,'EMP4','AngelaC','Player',171,'1000:tCLMrKVkJZ9fZC78HIm/KnbY6i2RS8RB:qprxyyausMaJ3jc9Tzvtvxyf6T+ew9zc','Angela','Chang','',1,'',1,NULL,'2015-07-23 21:13:20',NULL,321,1,0,'2015-07-27 17:38:38'),(341,'EMP5','JordanB','Player',171,'1000:F5Uyc5YfnuZmifSdScBUAgbRMqMfFMYt:DBBd629GyitliiIejGMBghSZ5OeW2Ioc','Jordan','Brown','',1,'',1,NULL,'2015-07-23 21:13:55',NULL,321,1,1050,'2015-07-27 17:38:47');
/*!40000 ALTER TABLE `tbluser` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbluserawardachieved`
--

DROP TABLE IF EXISTS `tbluserawardachieved`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbluserawardachieved` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` int(11) NOT NULL,
  `Award_ID` int(11) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbluserawardachieved`
--

LOCK TABLES `tbluserawardachieved` WRITE;
/*!40000 ALTER TABLE `tbluserawardachieved` DISABLE KEYS */;
/*!40000 ALTER TABLE `tbluserawardachieved` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbluserawards`
--

DROP TABLE IF EXISTS `tbluserawards`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbluserawards` (
  `userAwardsId` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) DEFAULT NULL,
  `award_id` int(11) DEFAULT NULL,
  `awarded_date` datetime DEFAULT NULL,
  `manual` tinyint(1) DEFAULT NULL,
  `awardedBy` int(11) DEFAULT NULL,
  `target_scores` int(11) DEFAULT NULL,
  `achieved_scores` int(11) DEFAULT NULL,
  `popup_showed` tinyint(1) DEFAULT '0',
  `kpi_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`userAwardsId`)
) ENGINE=MyISAM AUTO_INCREMENT=652 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbluserawards`
--

LOCK TABLES `tbluserawards` WRITE;
/*!40000 ALTER TABLE `tbluserawards` DISABLE KEYS */;
INSERT INTO `tbluserawards` VALUES (641,331,101,'2015-07-27 17:39:14',1,1,NULL,NULL,0,NULL),(651,341,101,'2015-07-27 17:39:30',1,1,NULL,NULL,0,NULL);
/*!40000 ALTER TABLE `tbluserawards` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbluserimages`
--

DROP TABLE IF EXISTS `tbluserimages`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbluserimages` (
  `U_UserIDImage` int(11) NOT NULL AUTO_INCREMENT,
  `Active` tinyint(4) NOT NULL DEFAULT '1',
  `UserID` int(11) NOT NULL,
  `U_UploadDate` date NOT NULL,
  `U_Current` tinyint(4) NOT NULL DEFAULT '0',
  `Player_Image` varchar(100) DEFAULT NULL,
  `Player_Thumbnail` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`U_UserIDImage`),
  KEY `UserID` (`UserID`)
) ENGINE=InnoDB AUTO_INCREMENT=372 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbluserimages`
--

LOCK TABLES `tbluserimages` WRITE;
/*!40000 ALTER TABLE `tbluserimages` DISABLE KEYS */;
INSERT INTO `tbluserimages` VALUES (131,1,141,'2015-07-10',0,'ed691652-0bac-4bf3-a734-6e3afac76893.jpg','ed691652-0bac-4bf3-a734-6e3afac76893.jpg'),(141,1,131,'2015-07-13',1,'2cc2000b-6ecb-4a56-afb6-39717d93d278.png','2cc2000b-6ecb-4a56-afb6-39717d93d278.png'),(151,1,171,'2015-07-13',1,'6241a169-30cc-4bdb-85bc-1b9e2df9dcff.png','6241a169-30cc-4bdb-85bc-1b9e2df9dcff.png'),(161,1,151,'2015-07-13',1,'d38f84dc-4a00-44dc-87f7-7367b61f51ae.jpg','d38f84dc-4a00-44dc-87f7-7367b61f51ae.jpg'),(181,1,181,'2015-07-16',1,'337a1730-4ceb-44b0-b876-d9965ef5d027.jpg','337a1730-4ceb-44b0-b876-d9965ef5d027.jpg'),(191,1,221,'2015-07-16',1,'7bb6c509-4306-4267-93f6-ff1f52a5322e.jpg','7bb6c509-4306-4267-93f6-ff1f52a5322e.jpg'),(201,1,231,'2015-07-16',1,'5ad0c927-3b47-4178-9d23-895bbc4330c5.jpg','5ad0c927-3b47-4178-9d23-895bbc4330c5.jpg'),(211,1,241,'2015-07-18',1,'204d9956-749a-4508-81ac-0f370a52441b.jpg','204d9956-749a-4508-81ac-0f370a52441b.jpg'),(221,1,251,'2015-07-18',1,'97c91cdf-2863-49bf-a897-e096b408461c.jpg','97c91cdf-2863-49bf-a897-e096b408461c.jpg'),(231,1,261,'2015-07-18',1,'9c4aad9b-5054-410e-9fe6-7d679d54a2e0.jpg','9c4aad9b-5054-410e-9fe6-7d679d54a2e0.jpg'),(241,1,271,'2015-07-18',1,'d2a55ef4-1a4b-4bb1-885e-6b15497897f5.jpg','d2a55ef4-1a4b-4bb1-885e-6b15497897f5.jpg'),(251,1,281,'2015-07-18',1,'dfb0117c-01b0-47ef-aa5f-6515a1e9e461.jpg','dfb0117c-01b0-47ef-aa5f-6515a1e9e461.jpg'),(261,1,291,'2015-07-18',1,'284ad515-357d-4d0a-b8a4-591059c7d876.jpg','284ad515-357d-4d0a-b8a4-591059c7d876.jpg'),(271,1,301,'2015-07-18',1,'2c2d40be-085e-4302-8265-158dd14d669d.jpg','2c2d40be-085e-4302-8265-158dd14d669d.jpg'),(281,1,2,'2015-07-23',1,'801c6561-3e57-4aa5-b369-c8fa64d842f8.jpg','801c6561-3e57-4aa5-b369-c8fa64d842f8.jpg'),(291,1,1,'2015-07-23',1,'2cdc6350-dfe7-4d73-a168-f0d84fd012a3.jpg','2cdc6350-dfe7-4d73-a168-f0d84fd012a3.jpg'),(301,1,111,'2015-07-23',1,'74af2d67-54a1-4a7e-90df-80c68be4f94a.jpg','74af2d67-54a1-4a7e-90df-80c68be4f94a.jpg'),(311,1,101,'2015-07-23',1,'35b81308-130c-46d6-89d9-5149ea5e8432.jpg','35b81308-130c-46d6-89d9-5149ea5e8432.jpg'),(321,1,121,'2015-07-23',1,'808f0700-a37b-4bd5-b181-da5b51251cc6.jpg','808f0700-a37b-4bd5-b181-da5b51251cc6.jpg'),(331,1,311,'2015-07-23',1,'1f4f41cb-faa8-43ae-aac4-30c88443a071.jpg','1f4f41cb-faa8-43ae-aac4-30c88443a071.jpg'),(341,1,11,'2015-07-23',1,'405f8eac-7ca0-43de-81e9-0f47b9c8054e.jpg','405f8eac-7ca0-43de-81e9-0f47b9c8054e.jpg'),(351,1,321,'2015-07-23',1,'099ac9b7-3e7b-447d-b511-abff2d256749.jpg','099ac9b7-3e7b-447d-b511-abff2d256749.jpg'),(361,1,331,'2015-07-23',1,'3265354f-1a3d-4547-9991-a06e1ecb53b8.jpg','3265354f-1a3d-4547-9991-a06e1ecb53b8.jpg'),(371,1,341,'2015-07-23',1,'05d48a8f-eccc-44f9-96e8-1d633cc3d33b.jpg','05d48a8f-eccc-44f9-96e8-1d633cc3d33b.jpg');
/*!40000 ALTER TABLE `tbluserimages` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblusermatchpoints`
--

DROP TABLE IF EXISTS `tblusermatchpoints`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblusermatchpoints` (
  `UserMatchPointsID` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` int(11) DEFAULT NULL,
  `MatchID` int(11) DEFAULT NULL,
  `PointsAchieved` int(11) DEFAULT NULL,
  `ElaspedTime` int(11) DEFAULT NULL,
  `IsCorrect` tinyint(4) DEFAULT NULL,
  `MatchTime` datetime DEFAULT NULL,
  PRIMARY KEY (`UserMatchPointsID`)
) ENGINE=MyISAM AUTO_INCREMENT=1572 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblusermatchpoints`
--

LOCK TABLES `tblusermatchpoints` WRITE;
/*!40000 ALTER TABLE `tblusermatchpoints` DISABLE KEYS */;
INSERT INTO `tblusermatchpoints` VALUES (1531,161,61,0,0,0,'2015-07-15 15:20:04'),(1541,161,51,0,0,0,'2015-07-15 15:20:33'),(1551,161,61,0,0,0,'2015-07-15 15:36:19'),(1561,181,61,0,0,0,'2015-07-15 19:27:05'),(1571,181,51,0,0,0,'2015-07-15 19:27:13');
/*!40000 ALTER TABLE `tblusermatchpoints` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblusermatchpointstemperory`
--

DROP TABLE IF EXISTS `tblusermatchpointstemperory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblusermatchpointstemperory` (
  `UserMatchPointsID` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` int(11) DEFAULT NULL,
  `MatchID` int(11) DEFAULT NULL,
  `PointsAchieved` int(11) DEFAULT NULL,
  `ElaspedTime` int(11) DEFAULT NULL,
  `IsCorrect` tinyint(4) DEFAULT NULL,
  `MatchTime` datetime DEFAULT NULL,
  PRIMARY KEY (`UserMatchPointsID`)
) ENGINE=MyISAM AUTO_INCREMENT=1572 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblusermatchpointstemperory`
--

LOCK TABLES `tblusermatchpointstemperory` WRITE;
/*!40000 ALTER TABLE `tblusermatchpointstemperory` DISABLE KEYS */;
INSERT INTO `tblusermatchpointstemperory` VALUES (1551,161,61,0,0,0,'2015-07-15 15:36:19'),(1571,181,51,0,0,0,'2015-07-15 19:27:13');
/*!40000 ALTER TABLE `tblusermatchpointstemperory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbluserquizpoints`
--

DROP TABLE IF EXISTS `tbluserquizpoints`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbluserquizpoints` (
  `UserQuizPointsID` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` int(11) DEFAULT NULL,
  `QuizID` int(11) DEFAULT NULL,
  `QuestionID` int(11) DEFAULT NULL,
  `PointsAchieved` int(11) DEFAULT NULL,
  `ElaspedTime` int(11) DEFAULT NULL,
  `IsCorrect` tinyint(1) DEFAULT NULL,
  `QuizTime` datetime DEFAULT NULL,
  PRIMARY KEY (`UserQuizPointsID`)
) ENGINE=MyISAM AUTO_INCREMENT=8632 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbluserquizpoints`
--

LOCK TABLES `tbluserquizpoints` WRITE;
/*!40000 ALTER TABLE `tbluserquizpoints` DISABLE KEYS */;
INSERT INTO `tbluserquizpoints` VALUES (8581,161,41,131,100,30,1,'2015-07-13 20:48:32'),(8591,161,41,131,100,30,1,'2015-07-13 20:49:00'),(8601,161,41,121,100,30,1,'2015-07-13 20:49:32'),(8611,161,41,151,100,30,1,'2015-07-13 20:50:04'),(8621,171,41,141,100,60,1,'2015-07-13 20:53:54'),(8631,171,41,151,100,60,1,'2015-07-13 20:54:15');
/*!40000 ALTER TABLE `tbluserquizpoints` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tbluserquizpointstemperory`
--

DROP TABLE IF EXISTS `tbluserquizpointstemperory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tbluserquizpointstemperory` (
  `UserQuizPointsID` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` int(11) DEFAULT NULL,
  `QuizID` int(11) DEFAULT NULL,
  `QuestionID` int(11) DEFAULT NULL,
  `PointsAchieved` int(11) DEFAULT NULL,
  `ElaspedTime` int(11) DEFAULT NULL,
  `IsCorrect` int(11) DEFAULT NULL,
  `QuizTime` datetime DEFAULT NULL,
  PRIMARY KEY (`UserQuizPointsID`)
) ENGINE=MyISAM AUTO_INCREMENT=8632 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tbluserquizpointstemperory`
--

LOCK TABLES `tbluserquizpointstemperory` WRITE;
/*!40000 ALTER TABLE `tbluserquizpointstemperory` DISABLE KEYS */;
INSERT INTO `tbluserquizpointstemperory` VALUES (8611,161,41,151,100,30,1,'2015-07-13 20:50:04'),(8631,171,41,151,100,60,1,'2015-07-13 20:54:15');
/*!40000 ALTER TABLE `tbluserquizpointstemperory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tblusertargetachieved`
--

DROP TABLE IF EXISTS `tblusertargetachieved`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tblusertargetachieved` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` int(11) NOT NULL,
  `Target_ID` int(11) NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=312 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tblusertargetachieved`
--

LOCK TABLES `tblusertargetachieved` WRITE;
/*!40000 ALTER TABLE `tblusertargetachieved` DISABLE KEYS */;
INSERT INTO `tblusertargetachieved` VALUES (271,341,391),(281,341,411),(291,341,421),(301,341,431),(311,341,441);
/*!40000 ALTER TABLE `tblusertargetachieved` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `testxml`
--

DROP TABLE IF EXISTS `testxml`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `testxml` (
  `TestID` int(11) NOT NULL,
  `TestName` varchar(50) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `testxml`
--

LOCK TABLES `testxml` WRITE;
/*!40000 ALTER TABLE `testxml` DISABLE KEYS */;
/*!40000 ALTER TABLE `testxml` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tmpcontest`
--

DROP TABLE IF EXISTS `tmpcontest`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tmpcontest` (
  `User_ID` int(11) NOT NULL,
  `U_Name` varchar(255) NOT NULL,
  `Player_Thumbnail` varchar(255) NOT NULL,
  `Role_Name` varchar(255) NOT NULL,
  `Site_Name` varchar(255) NOT NULL,
  `ContestID` int(11) NOT NULL,
  `ContestName` varchar(255) NOT NULL,
  `Score` int(11) NOT NULL,
  `KPI_measure` varchar(255) NOT NULL,
  `position` int(11) NOT NULL,
  `rank` int(11) NOT NULL,
  `times` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tmpcontest`
--

LOCK TABLES `tmpcontest` WRITE;
/*!40000 ALTER TABLE `tmpcontest` DISABLE KEYS */;
/*!40000 ALTER TABLE `tmpcontest` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `total_hours_worked`
--

DROP TABLE IF EXISTS `total_hours_worked`;
/*!50001 DROP VIEW IF EXISTS `total_hours_worked`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `total_hours_worked` AS SELECT 
 1 AS `sum(Worked_Hour)`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `total_levels`
--

DROP TABLE IF EXISTS `total_levels`;
/*!50001 DROP VIEW IF EXISTS `total_levels`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `total_levels` AS SELECT 
 1 AS `count(*)`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `total_questions`
--

DROP TABLE IF EXISTS `total_questions`;
/*!50001 DROP VIEW IF EXISTS `total_questions`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `total_questions` AS SELECT 
 1 AS `count(*)`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `total_sales`
--

DROP TABLE IF EXISTS `total_sales`;
/*!50001 DROP VIEW IF EXISTS `total_sales`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `total_sales` AS SELECT 
 1 AS `sum(score)`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `total_sites`
--

DROP TABLE IF EXISTS `total_sites`;
/*!50001 DROP VIEW IF EXISTS `total_sites`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `total_sites` AS SELECT 
 1 AS `count(*)`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `total_users`
--

DROP TABLE IF EXISTS `total_users`;
/*!50001 DROP VIEW IF EXISTS `total_users`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `total_users` AS SELECT 
 1 AS `Role`,
 1 AS `total`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `v_userlevelscores`
--

DROP TABLE IF EXISTS `v_userlevelscores`;
/*!50001 DROP VIEW IF EXISTS `v_userlevelscores`*/;
SET @saved_cs_client     = @@character_set_client;
SET character_set_client = utf8;
/*!50001 CREATE VIEW `v_userlevelscores` AS SELECT 
 1 AS `UserID`,
 1 AS `Role_ID`,
 1 AS `Level_ID`,
 1 AS `KPI_ID`,
 1 AS `Target_ID`,
 1 AS `Level_Name`,
 1 AS `KPI_name`,
 1 AS `Target_Value`,
 1 AS `score`,
 1 AS `current_percentage`,
 1 AS `Points`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `week_report`
--

DROP TABLE IF EXISTS `week_report`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `week_report` (
  `week` int(2) NOT NULL,
  `month` int(11) DEFAULT NULL,
  `year` int(11) DEFAULT NULL,
  `total_emplyees` int(11) DEFAULT NULL,
  `total_managers` int(11) DEFAULT NULL,
  `total_sales` int(11) DEFAULT NULL,
  `total_hours_worked` int(11) DEFAULT NULL,
  `total_hours_login` int(11) DEFAULT NULL,
  `total_questions` int(11) DEFAULT NULL,
  `total_quizzes` int(11) DEFAULT NULL,
  `total_levels` int(11) DEFAULT NULL,
  `total_sites` int(11) DEFAULT NULL,
  `total_roles` int(11) DEFAULT NULL,
  PRIMARY KEY (`week`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `week_report`
--

LOCK TABLES `week_report` WRITE;
/*!40000 ALTER TABLE `week_report` DISABLE KEYS */;
/*!40000 ALTER TABLE `week_report` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `year_report`
--

DROP TABLE IF EXISTS `year_report`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `year_report` (
  `year` int(5) NOT NULL,
  `total_emplyees` int(11) DEFAULT NULL,
  `total_managers` int(11) DEFAULT NULL,
  `total_sales` int(11) DEFAULT NULL,
  `total_hours_worked` int(11) DEFAULT NULL,
  `total_hours_login` int(11) DEFAULT NULL,
  `total_questions` int(11) DEFAULT NULL,
  `total_quizzes` int(11) DEFAULT NULL,
  `total_levels` int(11) DEFAULT NULL,
  `total_sites` int(11) DEFAULT NULL,
  `total_roles` int(11) DEFAULT NULL,
  PRIMARY KEY (`year`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `year_report`
--

LOCK TABLES `year_report` WRITE;
/*!40000 ALTER TABLE `year_report` DISABLE KEYS */;
/*!40000 ALTER TABLE `year_report` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'levelspropackagedbstaging'
--
/*!50106 SET @save_time_zone= @@TIME_ZONE */ ;
/*!50106 DROP EVENT IF EXISTS `AssingContestAwards` */;
DELIMITER ;;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;;
/*!50003 SET character_set_client  = utf8 */ ;;
/*!50003 SET character_set_results = utf8 */ ;;
/*!50003 SET collation_connection  = utf8_general_ci */ ;;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;;
/*!50003 SET @saved_time_zone      = @@time_zone */ ;;
/*!50003 SET time_zone             = 'SYSTEM' */ ;;
/*!50106 CREATE*/ /*!50117 DEFINER=`b4441296749150`@`%`*/ /*!50106 EVENT `AssingContestAwards` ON SCHEDULE EVERY 1 DAY STARTS '2014-11-12 23:58:00' ON COMPLETION NOT PRESERVE ENABLE DO BEGIN   
call sp_SetAwardsByContest;
END */ ;;
/*!50003 SET time_zone             = @saved_time_zone */ ;;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;;
/*!50003 SET character_set_client  = @saved_cs_client */ ;;
/*!50003 SET character_set_results = @saved_cs_results */ ;;
/*!50003 SET collation_connection  = @saved_col_connection */ ;;
DELIMITER ;
/*!50106 SET TIME_ZONE= @save_time_zone */ ;

--
-- Dumping routines for database 'levelspropackagedbstaging'
--
/*!50003 DROP PROCEDURE IF EXISTS `checkadd` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `checkadd`()
BEGIN



Declare userid INTEGER  DEFAULT 0;

Declare username VARCHAR(111);

Declare sysrole VARCHAR(111);

Declare rolename VARCHAR(111);

Declare firstname VARCHAR(111);

Declare lastname VARCHAR(111);

Declare nickname VARCHAR(111);

Declare active int(111);

Declare sitename VARCHAR(111);

Declare managername VARCHAR(111);

Declare empnumber INTEGER  DEFAULT 0;

DECLARE done INT DEFAULT 0;

DECLARE RateID INT DEFAULT 0;





 DEClARE user_insert CURSOR FOR 

 SELECT * FROM tbluser_temp;



DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1;



OPEN user_insert;



read_loop: LOOP



 IF done THEN

 LEAVE read_loop;

 END IF;





  fetch user_insert into userid,username,sysrole,rolename,firstname,lastname,nickname,active,sitename,empnumber,managername;



IF ( NOT EXISTS(SELECT * FROM tbluser WHERE U_Name = username))

	THEN

insert into tblUser(UserID,U_Name,U_LastName,U_NickName,U_Password,U_SiteID,U_SysRole,U_RolesID,Active,U_FirstName,ManagerID)



values(userid,username,lastname,nickname,NULL,(SELECT site_id from tblsite WHERE site_name=sitename),sysrole,(SELECT Role_ID from tblroles WHERE Role_Name=rolename),active,firstname,managername);







INSERT INTO tblLevelPerformance 

	(user_id,current_level,next_level,last_level,level_achieved,target_scores,achieved_scores)



	values(userid,(SELECT Level_ID FROM tblLevel 

														WHERE  tblLevel.Level_Position = 1 AND tblLevel.Role_ID = (SELECT Role_ID from tblroles WHERE Role_Name=rolename)

														),(SELECT Level_ID FROM tblLevel 

														WHERE  tblLevel.Level_Position = 2 AND tblLevel.Role_ID = (SELECT Role_ID from tblroles WHERE Role_Name=rolename)

														),0,0,0,0);



	END IF;



End LOOP read_loop;



close user_insert;



TRUNCATE TABLE tbluser_temp;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `checkdelete` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `checkdelete`()
BEGIN



Declare userids INTEGER  DEFAULT 0;

Declare username VARCHAR(111);

DECLARE done INT DEFAULT 0;





 DEClARE user_delete CURSOR FOR 

 SELECT * FROM tbluserdelete_temp;



DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1;



OPEN user_delete;



read_loop: LOOP



 IF done THEN

 LEAVE read_loop;

 END IF;



fetch user_delete into userids,username;



Delete from tbluser

where UserID = userids;





End LOOP read_loop;



close user_delete;









END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `checkupdate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `checkupdate`()
BEGIN



Declare userid INTEGER  DEFAULT 0;

Declare username VARCHAR(111);

Declare sysrole VARCHAR(111);

Declare firstname VARCHAR(111);

Declare lastname VARCHAR(111);

Declare nickname VARCHAR(111);

Declare active int(111);

Declare sitename VARCHAR(111);

Declare managername VARCHAR(111);

Declare empnumber INTEGER  DEFAULT 0;

DECLARE done INT DEFAULT 0;





 DEClARE user_update CURSOR FOR 

 SELECT * FROM tbluserupdate_temp;



DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1;



OPEN user_update;



read_loop: LOOP



 IF done THEN

 LEAVE read_loop;

 END IF;





  fetch user_update into userid,username,sysrole,firstname,lastname,nickname,active,sitename,empnumber,managername;



IF (EXISTS(SELECT * FROM tbluser WHERE U_Name = username))

	THEN



UPDATE tbluser

SET U_LastName=lastname,U_FirstName=firstname,U_NickName=nickname,U_SiteID=(SELECT site_id from tblsite WHERE site_name=sitename),U_SysRole=sysrole,

Active=active,ManagerID=managername,U_EmpNo=empnumber

WHERE U_Name = username;



	END IF;



End LOOP read_loop;



close user_update;



TRUNCATE TABLE tbluserupdate_temp;





END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_APIForPlayer` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_APIForPlayer`()
BEGIN



	Select vscore.UserID, CONCAT(tblUser.U_FirstName,' ',tblUser.U_LastName)  AS Player_Name,tblRoles.Role_Name,CONCAT('Level-',tblLevel.Level_Position) as Levelno,vscore.Level_Name,KPI_name,Target_value,score,tbluser.U_Points,tblUserImages.Player_Thumbnail,



(select (IFNULL(sum(v_UserLevelScores.current_percentage),0)) / Count(*) from v_UserLevelScores where v_UserLevelScores.Level_ID=vscore.Level_ID and v_UserLevelScores.UserID=vscore.UserID ) AS Percentage



 



,BaseHours







  ,(TIMESTAMPDIFF(HOUR,CurDate,Now())) as WorkedHours



FROM v_UserLevelScores vscore







INNER JOIN tblLevelPerformance ON vscore.Level_ID = tblLevelPerformance.current_level AND vscore.UserID = tblLevelPerformance.user_id



INNER JOIN tblUser ON vscore.UserID = tblUser.UserID



LEFT JOIN tblUserImages ON vscore.UserID = tblUserImages.UserID AND tblUserImages.U_Current = 1



INNER JOIN tblRoles ON



vscore.Role_ID = tblRoles.Role_ID 



INNER JOIN tblLevel ON vscore.Level_ID = tblLevel.Level_ID



WHERE tblLevelPerformance.level_achieved = 0



ORDER BY vscore.UserID



;











END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_AutoUpdateWorkHour` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_AutoUpdateWorkHour`(p_WorkedHour int, p_user_id int)
BEGIN
	

	UPDATE tbllevelperformance 
	SET tbllevelperformance.Worked_Hour = tbllevelperformance.Worked_Hour + p_WorkedHour
	WHERE tbllevelperformance.user_id = p_UserID
	AND tbllevelperformance.level_achieved = 0;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_CheckPassword` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_CheckPassword`(p_UserID int, p_Password varchar(50))
BEGIN



	



	SELECT UserID,U_Name FROM tblUser 



	WHERE UserID = p_UserID AND U_Password = p_Password;







END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_CheckPasswordNULL` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_CheckPasswordNULL`(p_U_Name varchar(50))
BEGIN



	SELECT UserID,U_Name FROM tblUser



	WHERE U_Name = p_U_Name AND U_Password IS NULL;







END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_CheckSecurityAnswer` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_CheckSecurityAnswer`(p_UserID int)
BEGIN



	SELECT * FROM tblSecurityAnswers



	WHERE UserID = p_UserID ;











END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_CheckTest` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_CheckTest`(p_Name Varchar(50),p_Password VARCHAR(50))
BEGIN















Select * from tblUser



				







WHERE U_Name =p_Name



and U_password =p_Password ;















END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_CheckUserName` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_CheckUserName`(p_U_Name varchar(50))
BEGIN



	SELECT UserID,U_Name FROM tblUser



	WHERE U_Name = p_U_Name;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_Contest_PlayersScore` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_Contest_PlayersScore`(p_ContestID INT)
BEGIN







SELECT user_id,



(SELECT CONCAT(tblUser.U_FirstName,' ',tblUser.U_LastName))



 AS    U_FullName,			



			 tblContestPosition.contest_id,



(SELECT tblContest.Contest_Name



FROM tblContest WHERE tblContest.Contest_ID = tblContestPosition.contest_id) as Contest_Name,



			 contest_rank,



			 contest_scores as score



 FROM tblContestPosition INNER JOIN tblContest on tblContestPosition.contest_id = tblContest.Contest_ID



  INNER JOIN tblUser ON tblUser.UserID = tblContestPosition.User_ID 



 WHERE tblContestPosition.contest_id = p_ContestID AND tblContest.Active = 1 AND tblUser.Active = 1



 ORDER BY contest_rank ASC;







END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_DeleteAssignAward` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_DeleteAssignAward`(IN `p_UserID` int,IN `p_AwardID` int)
BEGIN

	

DELETE FROM tblUserAwards WHERE tblUserAwards.user_id = p_UserID AND tblUserAwards.userAwardsId=p_AwardID;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_DeleteAwardImage` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_DeleteAwardImage`(p_ID int)
BEGIN

	

DELETE FROM tblAwardImages where ID = p_ID;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_DeleteContest` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_DeleteContest`(p_ContestID int)
BEGIN

DELETE FROM contestperformance 
WHERE ContestID = p_ContestID;

DELETE FROM tblcontestssites
WHERE ContestID = p_ContestID;

DELETE FROM tblcontestsroles
WHERE ContestID = p_ContestID;

DELETE FROM tblContest WHERE Contest_ID = p_ContestID ;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_DeleteContestPosition` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_DeleteContestPosition`(p_ContestID int)
BEGIN

DELETE FROM tblcontestposition
WHERE ContestId = p_ContestId;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_DeleteDataElement` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_DeleteDataElement`(p_ElementID int)
BEGIN

DELETE FROM tbldataelement WHERE ElementID = p_ElementID;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_DeleteDataSet` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_DeleteDataSet`(p_DataSetID int)
BEGIN

DELETE FROM tblMatchDataSets WHERE DataSetID = p_DataSetID;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_DeleteDataSetLevel` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_DeleteDataSetLevel`(p_DataSetID int)
BEGIN
	
DELETE FROM tblMatchDataSetLevels WHERE DataSetID = p_DataSetID;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_deletekpi` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_deletekpi`(kpiid int)
BEGIN

delete from tblKPI where KPI_ID = kpiid ;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_deletelevel` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_deletelevel`(p_LevelID int,p_LevelPosition int,p_RoleID int)
BEGIN
IF ( NOT EXISTS(SELECT * FROM tblLevelPerformance WHERE current_level = p_LevelID or next_level =p_LevelID or last_level =p_LevelID ))
	THEN
delete from tblLevel where Level_ID = p_LevelID;
UPDATE tbllevel
set tbllevel.Level_Position = (tbllevel.Level_Position - 1)
Where tbllevel.Role_ID = p_RoleID AND tbllevel.Level_Position > p_LevelPosition
 ;
ELSE
		CALL DuplicatePRO;
END IF;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_DeleteMatch` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_DeleteMatch`(p_MatchID int)
BEGIN
	
DELETE FROM tblmatch WHERE MatchID = p_MatchID;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_DeleteMatchLevels` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_DeleteMatchLevels`(p_MatchID INT)
BEGIN
	DELETE FROM tblmatchlevels  WHERE tblmatchlevels.MatchID = p_MatchID;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_DeleteMatchUserScore` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_DeleteMatchUserScore`(p_UserID int)
BEGIN

Delete from tblusermatchpointstemperory where UserID=p_UserID;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_DeleteMessage` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_DeleteMessage`(p_MessageID INT)
BEGIN

	DELETE FROM tblMessages WHERE ID = p_MessageID;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_DeleteQuestion` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_DeleteQuestion`(p_QuestionID int)
BEGIN

DELETE FROM tblQuizQuestions WHERE tblQuizQuestions.QuestionID = p_QuestionID;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_DeleteQuestionLevel` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_DeleteQuestionLevel`(p_QuestionID int)
BEGIN
	
DELETE FROM tblQuestionLevels WHERE tblQuestionLevels.QuestionID = p_QuestionID;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_DeleteQuiz` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_DeleteQuiz`(p_QuizID int)
BEGIN

	

DELETE FROM tblQuiz WHERE tblQuiz.QuizID = p_QuizID;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_DeleteQuizLevels` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_DeleteQuizLevels`(p_QuizID INT)
BEGIN
	DELETE FROM tblquizlevels  WHERE tblquizlevels.QuizID = p_QuizID;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_deletereward` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_deletereward`(rewardid int)
BEGIN

delete from tblRewards where Reward_ID = rewardid;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_DeleteRewardImage` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_DeleteRewardImage`(p_ID int)
BEGIN

	

DELETE FROM tblRewardImages where ID = p_ID;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_deleterole` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_deleterole`(roleid int)
BEGIN

delete from tblRoles where Role_ID = roleid;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_DeleteRound` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_DeleteRound`(p_RoundID int)
BEGIN

DELETE FROM tblround WHERE RoundID = p_RoundID;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_DeleteSecurityAnswers` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_DeleteSecurityAnswers`(p_UserID int)
BEGIN
Delete from tblSecurityAnswers where UserID = p_UserID; 
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_DeleteTarget` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_DeleteTarget`(p_TargetID int)
BEGIN

delete from tblTarget where Target_ID = p_TargetID ;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_DeleteUserImage` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_DeleteUserImage`(p_UserIDImage INT)
BEGIN

	DELETE FROM tblUserImages WHERE U_UserIDImage = p_UserIDImage;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_DeleteUserScore` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_DeleteUserScore`(p_UserID int)
BEGIN

Delete from tblUserQuizPointsTemperory where UserID=p_UserID;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_DuplicateContest` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_DuplicateContest`(p_ContestID INT)
BEGIN

DECLARE p_Cid INT;

INSERT INTO tblContests (ContestName,FromDate,ToDate,KPI_ID)
  SELECT CONCAT(ContestName, ' - Copy') AS ContestName ,FromDate,ToDate,KPI_ID
  FROM tblContests WHERE tblContests.ContestID = p_ContestID;

SET p_Cid = LAST_INSERT_ID();

INSERT INTO tblcontestssites(ContestId,Site_Id)
	SELECT p_Cid, Site_Id
    FROM tblcontestssites WHERE ContestId = p_ContestID;

INSERT INTO tblcontestsroles(ContestId,Role_Id)
	SELECT p_Cid, Role_Id
    FROM tblcontestsroles WHERE ContestId = p_ContestID;
    
INSERT INTO tblcontestposition(ContestId,Award_ID,Position,Points)
	SELECT p_Cid,Award_ID,Position,Points
    FROM tblcontestposition WHERE ContestId = p_ContestID;

INSERT INTO contestperformance
(ContestID, UserID, KPIID, Value, LastUpdated)
SELECT p_Cid AS ContestID, u.UserID, (SELECT KPI_ID FROM tblContests WHERE tblContests.ContestID = p_ContestID) AS KPIID, 0 AS Value, now() AS LastUpdated 
FROM 
	tbluser u INNER JOIN tbluserimages i ON u.UserID = i.UserID
WHERE
	u.Active = 1 AND i.U_Current = 1 AND u.U_RolesID = (SELECT Role_Id FROM tblcontestsroles WHERE ContestId = p_ContestID) AND u.U_SiteID = (SELECT Site_Id  FROM tblcontestssites WHERE ContestId = p_ContestID);

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_FillLeaderBoard` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_FillLeaderBoard`()
BEGIN

	DELETE FROM tblcontestscores;

	INSERT INTO `tblcontestscores`
	(`User_ID`,
	`ContestId`,
	`Score`,
	`Entry_Date`)
	SELECT 
		c.UserID,
		c.ContestID,
		sum(c.Value) AS Value, 
		c.LastUpdated 
	FROM 
		contestperformance c INNER JOIN tbluser u ON c.UserID = u.UserID
	GROUP BY c.UserID;

	INSERT INTO `tblcontestlog`	(`lastrun`) VALUES (current_timestamp);

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GelMilestonesDetail` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GelMilestonesDetail`(p_AwardID int)
BEGIN

	

SELECT * FROM





((SELECT SUM(Score) AS AchievedScore FROM tblScores WHERE U_Type = 'KPI' AND Type_ID = 

	(SELECT KPIID FROM tblAwards 

		WHERE Award_ID = p_AwardID)) AS AScore,

(SELECT tblTarget.Target_Value AS TargetValue FROM tblAwards 

INNER JOIN tblTarget ON

tblAwards.TargetID = tblTarget.Target_ID

WHERE Award_ID = p_AwardID) AS TValue

);



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetAllSites` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetAllSites`()
BEGIN

	

	SELECT site_id,site_name,site_type,site_address,Active FROM tblSite;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetAutomaticAwards` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetAutomaticAwards`(p_UserID INT)
BEGIN
	





select tblAwards.Award_Name,tblUserAwards.popup_showed,tblUserAwards.awarded_date,tblUserAwards.user_id,tblUserAwards.manual as Award_Manual,tblUserAwards.award_id,
( Select  IFNULL((((IFNULL(sum(tblUserAwards.achieved_scores),0)) / tblAwards.Target_Value) * 100),0) from tblUserAwards where tblUserAwards.user_id=p_UserID and tblUserAwards.award_id=tblAwards.Award_ID) AS Percentage,
(Select  IFNULL(sum(tblUserAwards.achieved_scores),0) from tblUserAwards where tblUserAwards.user_id=p_UserID  and tblUserAwards.award_id=tblAwards.Award_ID ) AS Scores,
(SELECT Award_Image FROM tblAwardImages WHERE Current_Image = 1 AND Active = 1 AND tblAwardImages.Award_ID = tblAwards.Award_ID) as Award_Image,
(Select AwardCategoryID FROM tblAwards Where tblAwards.Award_ID = tblUserAwards.award_id) as AwardCategoryID

from tblAwards,tblUserAwards

Where tblAwards.Award_ID = tblUserAwards.award_id and tblUserAwards.user_id=p_UserID
;

SELECT Award_Manual ,Target_Value,Award_ID,Award_Name,Award_Desc,AwardCategoryID,
(SELECT Award_Image FROM tblAwardImages WHERE Current_Image = 1 AND Active = 1 AND tblAwardImages.Award_ID = tblAwards.Award_ID) as Award_Image,
(Select   IFNULL(sum(tblUserAwards.achieved_scores),0) from tblUserAwards where tblUserAwards.user_id=p_UserID  and tblUserAwards.award_id=tblAwards.Award_ID  ) AS Scores,
 ( Select  IFNULL((((IFNULL(sum(tblUserAwards.achieved_scores),0)) / tblAwards.Target_Value) * 100),0) from tblUserAwards where tblUserAwards.user_id=p_UserID  and tblUserAwards.award_id=tblAwards.Award_ID ) AS Percentage 
from tblAwards;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetAward` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetAward`()
BEGIN



SELECT  Award_Name,

				Award_ID,				

				Award_Desc,

                Award_Manual,

				AwardCategoryID,

(SELECT Award_Image FROM tblAwardImages WHERE Current_Image = 1 AND Active = 1 AND tblAwardImages.Award_ID = tblAwards.Award_ID) as Award_Image,

(SELECT Award_Thumbnail FROM tblAwardImages WHERE Current_Image = 1 AND Active = 1 AND tblAwardImages.Award_ID = tblAwards.Award_ID) as Award_Thumbnail,

				tblAwards.Active,	tblAwards.KPIID,tblAwards.Target_Value,tblKPI.KPI_name,tblAwards.Active 

FROM tblAwards

LEFT JOIN tblKPI ON

tblAwards.KPIID = tblKPI.KPI_ID

AND tblKPI.Active = 1;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetAwardDetails` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetAwardDetails`(p_AwardID INT)
BEGIN

	SELECT  Award_Name,

					Award_ID,					

					Award_Desc,

					Active,

					AwardCategoryID

					

	FROM tblAwards	

	WHERE Award_ID = p_AwardID and Active = 1;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetAwardID` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetAwardID`(p_kpiID int)
BEGIN
	SELECT Award_ID
	From tblawards
	Where tblawards.KPIID = p_kpiID;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetAwardImages` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetAwardImages`()
BEGIN

SELECT ID, tblAwardImages.Award_ID, Award_Image,Award_Thumbnail, Uploaded_Date, Current_Image

FROM tblAwardImages

INNER JOIN tblAwards ON

tblAwards.Award_ID = tblAwardImages.Award_ID

WHERE tblAwards.Active = 1;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetCategory` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetCategory`()
BEGIN
Select * from tblQuizCategory;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetContest` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetContest`(p_Where VARCHAR(10000))
BEGIN

DECLARE p_Select VARCHAR(2000);
DECLARE p_Order VARCHAR(100);
DECLARE p_Inter VARCHAR(1000);
DECLARE p_FinalQuery varchar(8000);

SET p_Select = 
'SELECT a.ContestId, a.ContestName, a.FromDate, a.ToDate, a.KPI_ID, b.Role_Id, c.Site_Id
FROM tblcontests a
INNER JOIN tblcontestsroles b ON a.ContestId = b.ContestId
INNER JOIN tblcontestssites c ON a.ContestId = c.ContestId';

SET p_Inter = CONCAT(p_Select,p_Where);

SET p_Order =
' ORDER BY a.ContestId ASC';

SET @p_FinalQuery = CONCAT(p_Inter,p_Order);
PREPARE result from @p_FinalQuery;
EXECUTE result;
DEALLOCATE PREPARE result;


END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetContestID` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetContestID`(p_kpiID int)
BEGIN
	SELECT ContestId
	From tblcontests
	Where tblcontests.KPI_ID = p_kpiID;

	SELECT tblawards.Award_ID, tblawards.KPIID
	From tblawards
	Where tblawards.KPIID = p_kpiID;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetContestLeaderBoard` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetContestLeaderBoard`(p_Where VARCHAR(10000))
BEGIN

DECLARE p_Select VARCHAR(10000);
DECLARE p_Order VARCHAR(100);
DECLARE p_Inter VARCHAR(10000);
DECLARE p_FinalQuery varchar(20000);
DECLARE v_finished INTEGER DEFAULT 0;
DECLARE v_contestid INTEGER DEFAULT 0;

	DROP TABLE IF EXISTS Scores;

	DROP TABLE IF EXISTS x;

	DROP TABLE IF EXISTS y;

	CREATE TEMPORARY TABLE Scores (User_ID INT NOT NULL, U_Name VARCHAR(255) NOT NULL, Player_Thumbnail VARCHAR(255) NOT NULL, Role_Name VARCHAR(255) NOT NULL, Site_Name VARCHAR(255) NOT NULL, ContestID INT NOT NULL, ContestName VARCHAR(255) NOT NULL, Score INT NOT NULL, KPI_measure VARCHAR(255) NOT NULL);

	INSERT INTO Scores(User_ID, U_Name, Player_Thumbnail, Role_Name, Site_Name, ContestID, ContestName, Score, KPI_measure) 
	SELECT 
		t.UserID AS User_ID,
		CONCAT(u.U_FirstName,' ',u.U_LastName) AS U_Name,
		i.Player_Thumbnail,
		r.Role_Name,
		s.site_name,
		t.ContestID,
		c.ContestName,
		SUM(t.value) AS Score,
		k.KPI_measure
	FROM 
		contestperformance t
		INNER JOIN tblcontests c ON t.ContestID = c.ContestId
		INNER JOIN tblkpi k ON c.KPI_ID = k.KPI_ID
		INNER JOIN tbluser u ON t.UserID = u.UserID
		INNER JOIN tbluserimages i ON u.UserID = i.UserID AND i.U_Current = 1
		INNER JOIN tblsite s ON u.U_SiteID = s.site_id 
		INNER JOIN tblroles r ON u.U_RolesID = r.Role_ID
	GROUP BY
		t.ContestID, t.UserID;

	CREATE TEMPORARY TABLE x (User_ID INT NOT NULL,  U_Name VARCHAR(255) NOT NULL, Player_Thumbnail VARCHAR(255) NOT NULL, Role_Name VARCHAR(255) NOT NULL, Site_Name VARCHAR(255) NOT NULL, ContestID INT NOT NULL, ContestName VARCHAR(255) NOT NULL, Score INT NOT NULL, KPI_measure VARCHAR(255) NOT NULL, position INT NOT NULL);

	INSERT INTO x (User_ID, U_Name, Player_Thumbnail, Role_Name, Site_Name, ContestID, ContestName, Score, KPI_measure, position) 
	SELECT 
		Scores.User_ID,
		Scores.U_Name,
		Scores.Player_Thumbnail,
		Scores.Role_Name,
		Scores.Site_Name,
		Scores.ContestID,
		Scores.ContestName,
		Scores.Score,
		Scores.KPI_measure,
		( 
			CASE Scores.ContestName 
				WHEN @curType 
				THEN @curRow := @curRow + 1 
				ELSE @curRow := 1 AND @curType := Scores.ContestName 
			END
		) + 1 AS position		
	FROM        
		Scores,
		(SELECT @curRow := 0, @curType := '') r
	ORDER BY Scores.ContestName ASC, Scores.Score DESC; 

	CREATE TEMPORARY TABLE y (User_ID INT NOT NULL,  U_Name VARCHAR(255) NOT NULL, Player_Thumbnail VARCHAR(255) NOT NULL, Role_Name VARCHAR(255) NOT NULL, Site_Name VARCHAR(255) NOT NULL, ContestID INT NOT NULL, ContestName VARCHAR(255) NOT NULL, Score INT NOT NULL, KPI_measure VARCHAR(255) NOT NULL, position INT NOT NULL);

	INSERT INTO y (User_ID, U_Name, Player_Thumbnail, Role_Name, Site_Name, ContestID, ContestName, Score, KPI_measure, position) 
	SELECT * FROM x; 

	BEGIN
		DECLARE contest_cursor CURSOR FOR SELECT ContestID FROM x GROUP BY ContestID;
		 
		DECLARE CONTINUE HANDLER FOR NOT FOUND SET v_finished = 1;
		 

		OPEN contest_cursor;
		 
		 get_contestid: LOOP
		 
		 FETCH contest_cursor INTO v_contestid;
		 
		 IF v_finished = 1 THEN 
		 LEAVE get_contestid;
		 END IF;
		 
		 UPDATE y baseTable
			INNER JOIN
			(
			SELECT 
				User_ID,
				U_Name,
				Player_Thumbnail,
				Role_Name,
				Site_Name,
				ContestID,
				ContestName,
				@rnk:=IF(@preval <=> Score, @rnk, @row + 1) AS position,
				@row:= @row+1 AS rnk,
				@preval:=Score as Score
			FROM x
			JOIN (SELECT @rnk := 0, @preval :=null, @row := 0) r
			WHERE ContestID = v_contestid
			ORDER BY Score DESC
			) b ON baseTable.User_ID = b.User_ID
			SET
			baseTable.position = b.position
			WHERE baseTable.ContestID = v_contestid;
		 
		 END LOOP get_contestid;
		 
		CLOSE contest_cursor;

	END;

SET p_Select = 
'SELECT 
	y.User_ID,
    y.U_Name,
    y.Player_Thumbnail,
    y.Role_Name,
    y.Site_Name,
    y.ContestID,
    y.ContestName,
    CONCAT(y.position, CASE
		WHEN y.position%100 BETWEEN 11 AND 13 THEN "<p>th</p>"
		WHEN y.position%10 = 1 THEN "<p>st</p>"
		WHEN y.position%10 = 2 THEN "<p>nd</p>"
		WHEN y.position%10 = 3 THEN "<p>rd</p>"
		ELSE "<p>th</p>"
	END) AS Position,
    y.Score,
    CASE y.position 
		WHEN 1 THEN "rank" 
		WHEN 2 THEN "rank"
		WHEN 3 THEN "rank"
	END AS cssClass,
    CONCAT(y.position, CASE
		WHEN y.position%100 BETWEEN 11 AND 13 THEN "th"
		WHEN y.position%10 = 1 THEN "st"
		WHEN y.position%10 = 2 THEN "nd"
		WHEN y.position%10 = 3 THEN "rd"
		ELSE "th"
	END) AS PositionClear,
	y.KPI_measure
FROM y';

SET p_Inter = CONCAT(p_Select,p_Where);

SET p_Order =
' ORDER BY y.position';

SET @p_FinalQuery = CONCAT(p_Inter,p_Order);
PREPARE result from @p_FinalQuery;
EXECUTE result;
DEALLOCATE PREPARE result;

DROP TABLE y;

DROP TABLE x;

DROP TABLE Scores;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetContestList` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetContestList`(p_Where VARCHAR(10000))
BEGIN

DECLARE p_Select VARCHAR(10000);
DECLARE p_Order VARCHAR(100);
DECLARE p_Inter VARCHAR(10000);
DECLARE p_FinalQuery varchar(20000);
DECLARE v_finished INTEGER DEFAULT 0;
DECLARE v_contestid INTEGER DEFAULT 0;


	DROP TABLE IF EXISTS Scores;

	DROP TABLE IF EXISTS x;

	DROP TABLE IF EXISTS y;

	CREATE TEMPORARY TABLE Scores (User_ID INT NOT NULL, ContestID INT NOT NULL, ContestName VARCHAR(255) NOT NULL, Score INT NOT NULL, ToDate DATE NOT NULL);

	INSERT INTO Scores(User_ID, ContestID, ContestName, Score, ToDate)
	SELECT 
		t.UserID AS User_ID,		
		t.ContestID,
		c.ContestName,
		SUM(t.value) AS Score,
		c.ToDate
	FROM 
		contestperformance t
		INNER JOIN tblcontests c ON t.ContestID = c.ContestId
		INNER JOIN tblkpi k ON c.KPI_ID = k.KPI_ID
		INNER JOIN tbluser u ON t.UserID = u.UserID
		INNER JOIN tbluserimages i ON u.UserID = i.UserID AND i.U_Current = 1
		INNER JOIN tblsite s ON u.U_SiteID = s.site_id 
		INNER JOIN tblroles r ON u.U_RolesID = r.Role_ID
	WHERE 
		 c.ToDate >= DATE_FORMAT(NOW() - INTERVAL 5 DAY,'%Y-%m-%d') 
	GROUP BY
		t.ContestID, t.UserID;

	CREATE TEMPORARY TABLE x (User_ID INT NOT NULL, ContestID INT NOT NULL, ContestName VARCHAR(255) NOT NULL, Score INT NOT NULL, ToDate DATE NOT NULL, position INT NOT NULL);

	INSERT INTO x (User_ID, ContestID, ContestName, Score, ToDate, position) 
	SELECT 
		Scores.User_ID,
		Scores.ContestID,
		Scores.ContestName,
		Scores.Score,
		Scores.ToDate,
		( 
			CASE Scores.ContestName 
				WHEN @curType 
				THEN @curRow := @curRow + 1 
				ELSE @curRow := 1 AND @curType := Scores.ContestName 
			END
		) + 1 AS position
	FROM        
		Scores,
		(SELECT @curRow := 0, @curType := '') r
	ORDER BY Scores.ContestName ASC, Scores.Score DESC;

	CREATE TEMPORARY TABLE y (User_ID INT NOT NULL, ContestID INT NOT NULL, ContestName VARCHAR(255) NOT NULL, Score INT NOT NULL, ToDate DATE NOT NULL, position INT NOT NULL);

	INSERT INTO y (User_ID, ContestID, ContestName, Score, ToDate, position) 
	SELECT * FROM x;  

	BEGIN
		DECLARE contest_cursor CURSOR FOR SELECT ContestID FROM x GROUP BY ContestID;
		 
		DECLARE CONTINUE HANDLER FOR NOT FOUND SET v_finished = 1;
		 

		OPEN contest_cursor;
		 
		 get_contestid: LOOP
		 
		 FETCH contest_cursor INTO v_contestid;
		 
		 IF v_finished = 1 THEN 
		 LEAVE get_contestid;
		 END IF;
		 
		 UPDATE y baseTable
		INNER JOIN
		(
		SELECT 
			User_ID,			
			ContestID,
			ContestName,
			@rnk:=IF(@preval <=> Score, @rnk, @row + 1) AS position,
			@row:= @row+1 AS rnk,
			@preval:=Score as Score
		FROM x
		JOIN (SELECT @rnk := 0, @preval :=null, @row := 0) r
		WHERE ContestID = v_contestid
		ORDER BY Score DESC
		) b ON baseTable.User_ID = b.User_ID
		SET
		baseTable.position = b.position
		WHERE baseTable.ContestID = v_contestid;
		 
		 END LOOP get_contestid;
		 
		CLOSE contest_cursor;

	END;
    
    
    

SET p_Select = 
'SELECT 
	y.User_ID,
    y.ContestID,
    y.ContestName,
    CONCAT(y.position, CASE
		WHEN y.position%100 BETWEEN 11 AND 13 THEN "<p>th</p>"
		WHEN y.position%10 = 1 THEN "<p>st</p>"
		WHEN y.position%10 = 2 THEN "<p>nd</p>"
		WHEN y.position%10 = 3 THEN "<p>rd</p>"
		ELSE "<p>th</p>"
	END) AS Position,
    y.Score,
    CASE y.position 
		WHEN 1 THEN "rank1" 
		WHEN 2 THEN "rank2"
		WHEN 3 THEN "rank3"
	END AS cssClass,
    CONCAT(y.position, CASE
		WHEN y.position%100 BETWEEN 11 AND 13 THEN "th"
		WHEN y.position%10 = 1 THEN "st"
		WHEN y.position%10 = 2 THEN "nd"
		WHEN y.position%10 = 3 THEN "rd"
		ELSE "th"
	END) AS PositionClear, 
	y.ToDate
FROM y ';

SET p_Inter = CONCAT(p_Select,p_Where);

SET p_Order =
' ORDER BY y.ToDate DESC';





SET @p_FinalQuery = CONCAT(p_Inter,p_Order);
PREPARE result from @p_FinalQuery;
EXECUTE result;
DEALLOCATE PREPARE result;



DROP TABLE y;

DROP TABLE x;

DROP TABLE Scores;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetContestPlayerLeaderBoard` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetContestPlayerLeaderBoard`(p_ContestID INT, p_UserID INT)
BEGIN

DECLARE v_finished INTEGER DEFAULT 0;
DECLARE v_contestid INTEGER DEFAULT 0;
DECLARE v_rank INTEGER DEFAULT 0;
DECLARE v_timestamp timestamp DEFAULT current_timestamp;

DECLARE v_SELECT VARCHAR(20000);
DECLARE v_SELECT_V2 VARCHAR(20000);

DECLARE v_SELECT2 VARCHAR(20000);
DECLARE v_SELECT2_V2 VARCHAR(20000);
DECLARE v_SELECT2_V3 VARCHAR(20000);
DECLARE v_SELECT2_V4 VARCHAR(20000);

DECLARE v_SELECT3 VARCHAR(20000);
DECLARE v_SELECT3_V2 VARCHAR(20000);
DECLARE v_SELECT3_V3 VARCHAR(20000);
DECLARE v_SELECT3_V4 VARCHAR(20000);

DECLARE v_Inter VARCHAR(20000);

	DROP TABLE IF EXISTS Scores;

	DROP TABLE IF EXISTS x;

	CREATE TEMPORARY TABLE Scores (User_ID INT NOT NULL, U_Name VARCHAR(255) NOT NULL, Player_Thumbnail VARCHAR(255) NOT NULL, Role_Name VARCHAR(255) NOT NULL, Site_Name VARCHAR(255) NOT NULL, ContestID INT NOT NULL, ContestName VARCHAR(255) NOT NULL, Score INT NOT NULL, KPI_measure VARCHAR(255) NOT NULL);

	INSERT INTO Scores(User_ID, U_Name, Player_Thumbnail, Role_Name, Site_Name, ContestID, ContestName, Score, KPI_measure) 
	SELECT 
		t.UserID AS User_ID,
		CONCAT(u.U_FirstName,' ',u.U_LastName) AS U_Name,
		i.Player_Thumbnail,
		r.Role_Name,
		s.site_name,
		t.ContestID,
		c.ContestName,
		SUM(t.value) AS Score,
		k.KPI_measure
	FROM 
		contestperformance t
		INNER JOIN tblcontests c ON t.ContestID = c.ContestId
		INNER JOIN tblkpi k ON c.KPI_ID = k.KPI_ID
		INNER JOIN tbluser u ON t.UserID = u.UserID
		INNER JOIN tbluserimages i ON u.UserID = i.UserID AND i.U_Current = 1
		INNER JOIN tblsite s ON u.U_SiteID = s.site_id 
		INNER JOIN tblroles r ON u.U_RolesID = r.Role_ID
	GROUP BY
		t.ContestID, t.UserID; 

	CREATE TEMPORARY TABLE x (User_ID INT NOT NULL,  U_Name VARCHAR(255) NOT NULL, Player_Thumbnail VARCHAR(255) NOT NULL, Role_Name VARCHAR(255) NOT NULL, Site_Name VARCHAR(255) NOT NULL, ContestID INT NOT NULL, ContestName VARCHAR(255) NOT NULL, Score INT NOT NULL, KPI_measure VARCHAR(255) NOT NULL, position INT NOT NULL, rank INT NOT NULL);

	INSERT INTO x (User_ID, U_Name, Player_Thumbnail, Role_Name, Site_Name, ContestID, ContestName, Score, KPI_measure, position, rank) 
	SELECT 
		Scores.User_ID,
		Scores.U_Name,
		Scores.Player_Thumbnail,
		Scores.Role_Name,
		Scores.Site_Name,
		Scores.ContestID,
		Scores.ContestName,
		Scores.Score,
		Scores.KPI_measure,
		( 
			CASE Scores.ContestName 
				WHEN @curType 
				THEN @curRow := @curRow + 1 
				ELSE @curRow := 1 AND @curType := Scores.ContestName 
			END
		) + 1 AS position,
		( 
			CASE Scores.ContestName 
				WHEN @typeC 
				THEN @rowC := @rowC + 1 
				ELSE @rowC := 1 AND @typeC := Scores.ContestName 
			END
		) + 1 AS rank
	FROM        
		Scores,
		(SELECT @curRow := 0, @rowC := 0, @curType := '', @typeC := '') r
	ORDER BY Scores.ContestName ASC, Scores.Score DESC; 
	
	INSERT INTO tmpContest (User_ID, U_Name, Player_Thumbnail, Role_Name, Site_Name, ContestID, ContestName, Score, KPI_measure, position, rank, times) 
	SELECT *, v_timestamp FROM x; 	

	BEGIN
		DECLARE contest_cursor CURSOR FOR SELECT ContestID FROM x GROUP BY ContestID;
		 
		DECLARE CONTINUE HANDLER FOR NOT FOUND SET v_finished = 1;
		 
		OPEN contest_cursor;
		 
		get_contestid: LOOP
		 
		FETCH contest_cursor INTO v_contestid;
		 
		IF v_finished = 1 THEN 
		 LEAVE get_contestid;
		 END IF;
		 
		UPDATE tmpContest baseTable
		INNER JOIN
		(
		SELECT 
			User_ID,
			U_Name,
			Player_Thumbnail,
			Role_Name,
			Site_Name,
			ContestID,
			ContestName,
			@rnk:=IF(@preval <=> Score, @rnk, @row + 1) AS position,
			@row:= @row+1 AS rnk,
			@preval:=Score as Score
		FROM x
		JOIN (SELECT @rnk := 0, @preval :=null, @row := 0) r
		WHERE ContestID = v_contestid
		ORDER BY Score DESC
		) b ON baseTable.User_ID = b.User_ID
		SET
		baseTable.position = b.position
		WHERE baseTable.ContestID = v_contestid;
		 
		END LOOP get_contestid;
		 
		CLOSE contest_cursor;

	END;

	SET v_rank = (
		SELECT z.rank FROM (	
			SELECT t.User_ID, t.U_Name, t.ContestID, @rownum := @rownum + 1 AS rank 
			FROM tmpContest t, (SELECT @rownum := 0) r
			WHERE t.ContestID = p_ContestID
			ORDER BY t.position) as z
		WHERE z.User_ID = p_UserID);

IF (v_rank <= 3) THEN

	(SELECT 
		tmpContest.User_ID,
		tmpContest.U_Name,
		tmpContest.Player_Thumbnail,
		tmpContest.Role_Name,
		tmpContest.Site_Name,
		tmpContest.ContestID,
		tmpContest.ContestName,
		CONCAT(tmpContest.position, CASE
			WHEN tmpContest.position%100 BETWEEN 11 AND 13 THEN "<p>th</p>"
			WHEN tmpContest.position%10 = 1 THEN "<p>st</p>"
			WHEN tmpContest.position%10 = 2 THEN "<p>nd</p>"
			WHEN tmpContest.position%10 = 3 THEN "<p>rd</p>"
			ELSE "<p>th</p>"
		END) AS Position,
		tmpContest.Score,
		CASE tmpContest.position 
			WHEN 1 THEN "rank1" 
			WHEN 2 THEN "rank2"
			WHEN 3 THEN "rank3"
		END AS cssClass,
		CONCAT(tmpContest.position, CASE
			WHEN tmpContest.position%100 BETWEEN 11 AND 13 THEN "th"
			WHEN tmpContest.position%10 = 1 THEN "st"
			WHEN tmpContest.position%10 = 2 THEN "nd"
			WHEN tmpContest.position%10 = 3 THEN "rd"
			ELSE "th"
		END) AS PositionClear,
		tmpContest.KPI_measure
	FROM tmpContest
	WHERE tmpContest.ContestID = p_ContestID
	ORDER BY tmpContest.position
	LIMIT 3)
	UNION
	(SELECT 
		0 AS User_ID,
		'' AS U_Name,
		'' AS Player_Thumbnail,
		'' AS Role_Name,
		'' AS Site_Name,
		p_ContestID AS ContestID,
		'' AS ContestName,
		4 AS Position,
		'' AS Score,
		'divisor' AS cssClass,
		'4th' AS PositionClear,
		'' AS KPI_measure)
	UNION
	(SELECT 
		tmpContest.User_ID,
		tmpContest.U_Name,
		tmpContest.Player_Thumbnail,
		tmpContest.Role_Name,
		tmpContest.Site_Name,
		tmpContest.ContestID,
		tmpContest.ContestName,
		CONCAT(tmpContest.position, CASE
			WHEN tmpContest.position%100 BETWEEN 11 AND 13 THEN "<p>th</p>"
			WHEN tmpContest.position%10 = 1 THEN "<p>st</p>"
			WHEN tmpContest.position%10 = 2 THEN "<p>nd</p>"
			WHEN tmpContest.position%10 = 3 THEN "<p>rd</p>"
			ELSE "<p>th</p>"
		END) AS Position,
		tmpContest.Score,
		CASE tmpContest.position 
			WHEN 1 THEN "rank1" 
			WHEN 2 THEN "rank2"
			WHEN 3 THEN "rank3"
		END AS cssClass,
		CONCAT(tmpContest.position, CASE
			WHEN tmpContest.position%100 BETWEEN 11 AND 13 THEN "th"
			WHEN tmpContest.position%10 = 1 THEN "st"
			WHEN tmpContest.position%10 = 2 THEN "nd"
			WHEN tmpContest.position%10 = 3 THEN "rd"
			ELSE "th"
		END) AS PositionClear,
		tmpContest.KPI_measure
	FROM tmpContest
	WHERE tmpContest.ContestID = p_ContestID
	ORDER BY tmpContest.position
	LIMIT 3, 3);

ELSEIF (v_rank > 3) THEN
	
	SET v_SELECT = 
	'(SELECT 
		tmpContest.User_ID,
		tmpContest.U_Name,
		tmpContest.Player_Thumbnail,
		tmpContest.Role_Name,
		tmpContest.Site_Name,
		tmpContest.ContestID,
		tmpContest.ContestName,
		CONCAT(tmpContest.position, CASE
			WHEN tmpContest.position%100 BETWEEN 11 AND 13 THEN "<p>th</p>"
			WHEN tmpContest.position%10 = 1 THEN "<p>st</p>"
			WHEN tmpContest.position%10 = 2 THEN "<p>nd</p>"
			WHEN tmpContest.position%10 = 3 THEN "<p>rd</p>"
			ELSE "<p>th</p>"
		END) AS Position,
		tmpContest.Score,
		CASE tmpContest.position 
			WHEN 1 THEN "rank1" 
			WHEN 2 THEN "rank2"
			WHEN 3 THEN "rank3"
		END AS cssClass,
		CONCAT(tmpContest.position, CASE
			WHEN tmpContest.position%100 BETWEEN 11 AND 13 THEN "th"
			WHEN tmpContest.position%10 = 1 THEN "st"
			WHEN tmpContest.position%10 = 2 THEN "nd"
			WHEN tmpContest.position%10 = 3 THEN "rd"
			ELSE "th"
		END) AS PositionClear,
		tmpContest.KPI_measure
	FROM tmpContest
	WHERE tmpContest.ContestID = p_ContestID
	ORDER BY tmpContest.position
	LIMIT 3)
	UNION
	(SELECT 
		0 AS User_ID,
		"" AS U_Name,
		"" AS Player_Thumbnail,
		"" AS Role_Name,
		"" AS Site_Name,
		0 AS ContestID,
		"" AS ContestName,
		4 AS Position,
		"" AS Score,
		"divisor" AS cssClass,
		"4th" AS PositionClear,
		"" AS KPI_measure)
	UNION
	';
	
	SET v_SELECT_V2 = REPLACE(v_SELECT, 'p_ContestID', p_ContestID);
		
	IF (v_rank > 4) THEN
		
		SET v_SELECT2 = 
		'(SELECT
			tmpContest.User_ID,
			tmpContest.U_Name,
			tmpContest.Player_Thumbnail,
			tmpContest.Role_Name,
			tmpContest.Site_Name,
			tmpContest.ContestID,
			tmpContest.ContestName,
			CONCAT(tmpContest.position, CASE
				WHEN tmpContest.position%100 BETWEEN 11 AND 13 THEN "<p>th</p>"
				WHEN tmpContest.position%10 = 1 THEN "<p>st</p>"
				WHEN tmpContest.position%10 = 2 THEN "<p>nd</p>"
				WHEN tmpContest.position%10 = 3 THEN "<p>rd</p>"
				ELSE "<p>th</p>"
			END) AS Position,
			tmpContest.Score,
			CASE tmpContest.position 
				WHEN 1 THEN "rank1" 
				WHEN 2 THEN "rank2"
				WHEN 3 THEN "rank3"
			END AS cssClass,
			CONCAT(tmpcontest.position, CASE
				WHEN tmpcontest.position%100 BETWEEN 11 AND 13 THEN "th"
				WHEN tmpcontest.position%10 = 1 THEN "st"
				WHEN tmpcontest.position%10 = 2 THEN "nd"
				WHEN tmpcontest.position%10 = 3 THEN "rd"
				ELSE "th"
			END) AS PositionClear,
			tmpContest.KPI_measure
		FROM tmpcontest 
		WHERE 
			tmpcontest.rank = (select max(rank) from tmpcontest where rank < v_rank AND ContestID = p_ContestID) AND
			tmpcontest.ContestID = p_ContestID)
		UNION
		(SELECT
			tmpContest.User_ID,
			tmpContest.U_Name,
			tmpContest.Player_Thumbnail,
			tmpContest.Role_Name,
			tmpContest.Site_Name,
			tmpContest.ContestID,
			tmpContest.ContestName,
			CONCAT(tmpContest.position, CASE
				WHEN tmpContest.position%100 BETWEEN 11 AND 13 THEN "<p>th</p>"
				WHEN tmpContest.position%10 = 1 THEN "<p>st</p>"
				WHEN tmpContest.position%10 = 2 THEN "<p>nd</p>"
				WHEN tmpContest.position%10 = 3 THEN "<p>rd</p>"
				ELSE "<p>th</p>"
			END) AS Position,
			tmpContest.Score,
			CASE tmpContest.position 
				WHEN 1 THEN "rank1" 
				WHEN 2 THEN "rank2"
				WHEN 3 THEN "rank3"
			END AS cssClass,
			CONCAT(tmpcontest.position, CASE
				WHEN tmpcontest.position%100 BETWEEN 11 AND 13 THEN "th"
				WHEN tmpcontest.position%10 = 1 THEN "st"
				WHEN tmpcontest.position%10 = 2 THEN "nd"
				WHEN tmpcontest.position%10 = 3 THEN "rd"
				ELSE "th"
			END) AS PositionClear,
			tmpContest.KPI_measure 
		FROM tmpcontest 
		WHERE 
			User_ID = p_UserID AND ContestID = p_ContestID)
		UNION
		(SELECT 
			tmpContest.User_ID,
			tmpContest.U_Name,
			tmpContest.Player_Thumbnail,
			tmpContest.Role_Name,
			tmpContest.Site_Name,
			tmpContest.ContestID,
			tmpContest.ContestName,
			CONCAT(tmpContest.position, CASE
				WHEN tmpContest.position%100 BETWEEN 11 AND 13 THEN "<p>th</p>"
				WHEN tmpContest.position%10 = 1 THEN "<p>st</p>"
				WHEN tmpContest.position%10 = 2 THEN "<p>nd</p>"
				WHEN tmpContest.position%10 = 3 THEN "<p>rd</p>"
				ELSE "<p>th</p>"
			END) AS Position,
			tmpContest.Score,
			CASE tmpContest.position 
				WHEN 1 THEN "rank1" 
				WHEN 2 THEN "rank2"
				WHEN 3 THEN "rank3"
			END AS cssClass,
			CONCAT(tmpcontest.position, CASE
				WHEN tmpcontest.position%100 BETWEEN 11 AND 13 THEN "th"
				WHEN tmpcontest.position%10 = 1 THEN "st"
				WHEN tmpcontest.position%10 = 2 THEN "nd"
				WHEN tmpcontest.position%10 = 3 THEN "rd"
				ELSE "th"
			END) AS PositionClear,
			tmpContest.KPI_measure  
		FROM tmpcontest 
		WHERE 
			tmpcontest.rank = (select min(rank) from tmpcontest where rank > v_rank AND ContestID = p_ContestID) AND
			tmpcontest.ContestID = p_ContestID);';
		
		SET v_SELECT2_V2 = REPLACE(v_SELECT2, 'p_ContestID', p_ContestID);

		SET v_SELECT2_V3 = REPLACE(v_SELECT2_V2, 'p_UserID', p_UserID);

		SET v_SELECT2_V4 = REPLACE(v_SELECT2_V3, 'v_rank', v_rank);
		
		SET @v_Inter = CONCAT(v_SELECT_V2, v_SELECT2_V4);

	ELSEIF (v_rank = 4) THEN
		
		SET v_SELECT3 =
		'(SELECT
			tmpContest.User_ID,
			tmpContest.U_Name,
			tmpContest.Player_Thumbnail,
			tmpContest.Role_Name,
			tmpContest.Site_Name,
			tmpContest.ContestID,
			tmpContest.ContestName,
			CONCAT(tmpContest.position, CASE
				WHEN tmpContest.position%100 BETWEEN 11 AND 13 THEN "<p>th</p>"
				WHEN tmpContest.position%10 = 1 THEN "<p>st</p>"
				WHEN tmpContest.position%10 = 2 THEN "<p>nd</p>"
				WHEN tmpContest.position%10 = 3 THEN "<p>rd</p>"
				ELSE "<p>th</p>"
			END) AS Position,
			tmpContest.Score,
			CASE tmpContest.position 
				WHEN 1 THEN "rank1" 
				WHEN 2 THEN "rank2"
				WHEN 3 THEN "rank3"
			END AS cssClass,
			CONCAT(tmpcontest.position, CASE
				WHEN tmpcontest.position%100 BETWEEN 11 AND 13 THEN "th"
				WHEN tmpcontest.position%10 = 1 THEN "st"
				WHEN tmpcontest.position%10 = 2 THEN "nd"
				WHEN tmpcontest.position%10 = 3 THEN "rd"
				ELSE "th"
			END) AS PositionClear,
			tmpContest.KPI_measure 
		FROM tmpcontest 
		WHERE 
			User_ID = p_UserID AND ContestID = p_ContestID)
		UNION
		(SELECT 
			tmpContest.User_ID,
			tmpContest.U_Name,
			tmpContest.Player_Thumbnail,
			tmpContest.Role_Name,
			tmpContest.Site_Name,
			tmpContest.ContestID,
			tmpContest.ContestName,
			CONCAT(tmpContest.position, CASE
				WHEN tmpContest.position%100 BETWEEN 11 AND 13 THEN "<p>th</p>"
				WHEN tmpContest.position%10 = 1 THEN "<p>st</p>"
				WHEN tmpContest.position%10 = 2 THEN "<p>nd</p>"
				WHEN tmpContest.position%10 = 3 THEN "<p>rd</p>"
				ELSE "<p>th</p>"
			END) AS Position,
			tmpContest.Score,
			CASE tmpContest.position 
				WHEN 1 THEN "rank1" 
				WHEN 2 THEN "rank2"
				WHEN 3 THEN "rank3"
			END AS cssClass,
			CONCAT(tmpcontest.position, CASE
				WHEN tmpcontest.position%100 BETWEEN 11 AND 13 THEN "th"
				WHEN tmpcontest.position%10 = 1 THEN "st"
				WHEN tmpcontest.position%10 = 2 THEN "nd"
				WHEN tmpcontest.position%10 = 3 THEN "rd"
				ELSE "th"
			END) AS PositionClear,
			tmpContest.KPI_measure  
		FROM tmpcontest 
		WHERE 
			tmpcontest.rank IN (select rank from tmpcontest where rank > v_rank AND ContestID = p_ContestID) AND
			tmpcontest.ContestID = p_ContestID
		LIMIT 2);';

		SET v_SELECT3_V2 = REPLACE(v_SELECT3, 'p_ContestID', p_ContestID);

		SET v_SELECT3_V3 = REPLACE(v_SELECT3_V2, 'p_UserID', p_UserID);

		SET v_SELECT3_V4 = REPLACE(v_SELECT3_V3, 'v_rank', v_rank);

		SET @v_Inter = CONCAT(v_SELECT_V2, v_SELECT3_V4);

	END IF;	
		
	PREPARE result from @v_Inter;
	EXECUTE result;
	DEALLOCATE PREPARE result;

END IF;

DELETE FROM tmpcontest 
WHERE times = v_timestamp;

DROP TABLE x;

DROP TABLE Scores;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetContestPositions` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetContestPositions`(p_Where VARCHAR(10000))
BEGIN

DECLARE p_Select VARCHAR(2000);
DECLARE p_FinalQuery varchar(8000);

SET p_Select = 
'SELECT ContestId, Award_ID, Position, Points
FROM tblcontestposition';

SET @p_FinalQuery = CONCAT(p_Select,p_Where);
PREPARE result from @p_FinalQuery;
EXECUTE result;
DEALLOCATE PREPARE result;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetDataElement` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetDataElement`(p_Where VARCHAR(10000))
BEGIN	

DECLARE p_Select VARCHAR(2000);
DECLARE p_FinalQuery varchar(8000);

SET p_Select = 
'SELECT 
	ElementID,
    MatchID,
    ElementName,
	IsPicture,
    CreatedDate
FROM tbldataelement';

SET @p_FinalQuery = CONCAT(p_Select,p_Where);
PREPARE result from @p_FinalQuery;
EXECUTE result;
DEALLOCATE PREPARE result;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetDataSet` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetDataSet`(p_Where VARCHAR(10000), p_Status int)
BEGIN

DECLARE p_Select VARCHAR(2000);

DECLARE p_FinalQuery varchar(8000);

IF(p_Status =1)
THEN

	SET p_Select = 
		'SELECT 
			DataSetID,
			DataSetElementsData,
			SiteID,
			MatchID,
			CreatedDate,
			DataSetImage,
			DataSetImageThumbnail
		FROM tblmatchdatasets
		INNER JOIN tblmatchdatasetlevels ON tblmatchdatasets.DataSetID = tblmatchdatasetlevels.DataSetID';

	SET @p_FinalQuery = CONCAT(p_Select,p_Where);

	PREPARE result from @p_FinalQuery;

	EXECUTE result;

	DEALLOCATE PREPARE result;

END IF;

IF(p_Status =0)
THEN

	SET p_Select = 
			'SELECT 
				DataSetID,
				DataSetElementsData,
				SiteID,
				MatchID,
				CreatedDate,
				DataSetImage,
				DataSetImageThumbnail
			FROM tblmatchdatasets';

	SET @p_FinalQuery = CONCAT(p_Select,p_Where);

	PREPARE result from @p_FinalQuery;

	EXECUTE result;

	DEALLOCATE PREPARE result;

END IF;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetDataSetLevels` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetDataSetLevels`(p_DataSetID INT, p_RoleID INT)
BEGIN

	SELECT DataSetID, RoleID, LevelID FROM tblMatchDataSetLevels WHERE DataSetID = p_DataSetID AND RoleID = p_RoleID;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetDropDown` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetDropDown`(IN `p_ReferenceCode` varchar(50))
BEGIN

	

	SELECT ReferenceData_ID,Reference_Code,Item_Code,Description,Parent_ID FROM tblReferenceData 

	WHERE Reference_Code = p_ReferenceCode AND Active = 1;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetGame` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetGame`()
BEGIN

Select * from tblQuizGames;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetGamesPlayLog` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetGamesPlayLog`()
BEGIN

(SELECT 
	LogID,
	UserID,
	QuizID,
	QuizTime,
	0 AS QuizPlays
FROM tblQuizPlayLog)
UNION
(SELECT 
	LogID,
	UserID,
	MatchID AS QuizID,
	MatchTime AS QuizTime,
	MatchPlays AS QuizPlays
FROM tblMatchPlayLog)
ORDER BY 
	QuizTime DESC;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetGames_Player` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetGames_Player`(p_RoleID int,p_LevelID int)
BEGIN
	
(SELECT  
	SUM(PointsAchieved) AS QuizPoints, 
	tblQuiz.QuizID, 
	tblQuiz.QuizName,
	tblQuiz.QuizImageThumbnail,
	tblUser.UserID, 
	CONCAT(tblUser.U_FirstName,' ',tblUser.U_LastName) AS FullName,
	'Quiz' AS GameType,
	tblQuiz.CreatedDate
FROM tblUserQuizPoints
Right JOIN tblQuiz 
ON tblUserQuizPoints.QuizID = tblQuiz.QuizID
Left JOIN tblUser 
ON tblUserQuizPoints.UserID = tblUser.UserID
GROUP BY 
	QuizID,
	UserID)
UNION
(SELECT 
	UserMatchPoints.PointsAchieved AS QuizPoints, 
	tblmatch.MatchID AS QuizID, 
	tblmatch.MatchName AS QuizName,
	tblmatch.MatchImageThumbnail AS QuizImageThumbnail,
	tblUser.UserID, 
	CONCAT(tblUser.U_FirstName,' ',tblUser.U_LastName) AS FullName,
	'Match' AS GameType,
	tblmatch.CreatedDate
FROM tblmatch
LEFT JOIN
(SELECT 
	MAX(PointsAchieved) AS PointsAchieved, UserID, MatchID FROM tblusermatchpoints 
GROUP BY
	UserID, MatchID) AS UserMatchPoints ON tblmatch.MatchID = UserMatchPoints.MatchID
LEFT JOIN tblUser 
ON UserMatchPoints.UserID = tblUser.UserID)
ORDER BY
	CreatedDate DESC;

(Select 
	tblUserQuizPoints.UserQuizPointsID,
	tblUserQuizPoints.UserID,
	tblUserQuizPoints.QuizID,
	tblUserQuizPoints.QuestionID,
	tblUserQuizPoints.PointsAchieved,
	tblUserQuizPoints.ElaspedTime,
	tblUserQuizPoints.IsCorrect,
	tblUserQuizPoints.QuizTime,
	'Quiz' AS GameType
from tblUserQuizPoints)
UNION
(SELECT 
	tblusermatchpoints.UserMatchPointsID AS UserQuizPointsID,
	tblusermatchpoints.UserID,
	tblusermatchpoints.MatchID AS QuizID,
	'' AS QuestionID,
	tblusermatchpoints.PointsAchieved,
	tblusermatchpoints.ElaspedTime,
	tblusermatchpoints.IsCorrect,
	tblusermatchpoints.MatchTime AS QuizTime,
	'Match' AS GameType
FROM tblusermatchpoints)
ORDER BY
	QuizTime DESC;

(SELECT * FROM tblUserQuizPointsTemperory
INNER JOIN tblQuizQuestions 
ON tblUserQuizPointsTemperory.QuestionID= tblQuizQuestions.QuestionID)
UNION
(SELECT 
	tblUserMatchPointsTemperory.UserMatchPointsID AS UserQuizPointsID,
	tblUserMatchPointsTemperory.UserID,
	tblUserMatchPointsTemperory.MatchID AS QuizID,
	'' AS QuestionID,
	tblUserMatchPointsTemperory.PointsAchieved,
	tblUserMatchPointsTemperory.ElaspedTime,
	tblUserMatchPointsTemperory.IsCorrect,
	tblUserMatchPointsTemperory.MatchTime AS QuizTime,
	tblmatchdatasets.DataSetID,
	tblmatchdatasets.DataSetElementsData AS QuestionText,
	'' AS QuestionExplanation,
	'' AS Answer1,
	'' AS Answer2,
	'' AS Answer3,
	'' AS Answer4,
	'' AS CorrectAnswer,
	0 AS Category,
	tblmatchdatasets.SiteID,
	tblmatchdatasets.MatchID AS QuizID,
	tblmatchdatasets.DataSetImage AS QuestionImage,
	tblmatchdatasets.DataSetImageThumbnail AS QuestionImageThumbnail,
	'' AS ShortQuestion
FROM 
	tblUserMatchPointsTemperory
INNER JOIN tblmatchdatasets 
ON tblUserMatchPointsTemperory.MatchID = tblmatchdatasets.MatchID)
ORDER by
	QuizTime DESC;

(SELECT  
	SUM(PointsAchieved) AS QuizPoints, 
	tblQuiz.QuizID, 
	tblQuiz.QuizName,
	tblQuiz.QuizImageThumbnail,
	tblUser.UserID, 
	tblQuiz.TimesPlayablePerDay, 
	tblQuiz.KPI_ID,
	CONCAT(tblUser.U_FirstName,' ',tblUser.U_LastName) AS FullName,
	'Quiz' AS GameType,
	 '0' AS Mandatory,
	tblQuiz.CreatedDate
FROM tblUserQuizPoints
Right JOIN tblQuiz 
ON tblUserQuizPoints.QuizID = tblQuiz.QuizID
Left JOIN tblUser 
ON tblUserQuizPoints.UserID = tblUser.UserID
INNER JOIN tblquizlevels 
ON tblquiz.QuizID = tblquizlevels.QuizID
WHERE tblquizlevels.RoleID = p_RoleID AND tblquizlevels.LevelID =p_LevelID
GROUP BY 
	QuizID)
UNION
(SELECT 
	UserMatchPoints.PointsAchieved AS QuizPoints, 
	tblmatch.MatchID AS QuizID, 
	tblmatch.MatchName AS QuizName,
	tblmatch.MatchImageThumbnail AS QuizImageThumbnail,
	tblUser.UserID, 
	tblmatch.MaxPlaysPerDay AS TimesPlayablePerDay, 
	tblmatch.KPI_ID,
	CONCAT(tblUser.U_FirstName,' ',tblUser.U_LastName) AS FullName,
	'Match' AS GameType,
	'0' AS Mandatory,
	tblmatch.CreatedDate
FROM tblmatch
LEFT JOIN
(SELECT 
	MAX(PointsAchieved) AS PointsAchieved, UserID, MatchID FROM tblusermatchpoints 
GROUP BY
	UserID, MatchID) AS UserMatchPoints ON tblmatch.MatchID = UserMatchPoints.MatchID
LEFT JOIN tblUser 
ON UserMatchPoints.UserID = tblUser.UserID
INNER JOIN tblmatchlevels 
ON tblmatch.MatchID = tblmatchlevels.MatchID
WHERE tblmatchlevels.RoleID = p_RoleID AND tblmatchlevels.LevelID =p_LevelID
GROUP BY 
	QuizID)
ORDER BY
	CreatedDate DESC;

(Select 
	tblquiz.QuizID
FROM tblquiz 
INNER JOIN tbltarget
ON tblquiz.KPI_ID = tbltarget.KPI_ID
WHERE 
	tbltarget.Level_ID = p_LevelID AND 
	tbltarget.Role_ID= p_RoleID)
UNION
(Select 
	tblmatch.MatchID AS QuizID
FROM tblmatch 
INNER JOIN tbltarget
ON tblmatch.KPI_ID = tbltarget.KPI_ID
WHERE 
	tbltarget.Level_ID = p_LevelID AND 
	tbltarget.Role_ID= p_RoleID) ;

Select Score, tblscores.User_ID, tblscores.Type_ID
from tblScores
Where U_Type ='KPI' AND LevelID = p_LevelID ;

SELECT tblquizresulttotal.*, tbluser.U_FirstName, tbluser.U_LastName FROM tblquizresulttotal
INNER JOIN tbluser
ON tblquizresulttotal.UserID = tbluser.UserID;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetImage` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetImage`(p_UserID INT)
BEGIN

	SELECT U_Current,U_UploadDate,U_UserIDImage,tblUserImages.Active,tblUserImages.UserID,tblUser.U_Name,tblUserImages.Player_Image,tblUserImages.Player_Thumbnail

	FROM tblUserImages

	INNER JOIN tblUser ON

	tblUserImages.UserID = tblUser.UserID

	WHERE tblUser.Active = 1 AND tblUserImages.UserID = p_UserID;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetKPI` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetKPI`()
BEGIN

SELECT tblKPI.KPI_ID,tblKPI.KPI_name,

			tblKPI.KPI_measure,tblKPI.KPI_type,tblKPI.Active, tblkpi.TipsDESC, tblkpi.TipsLINK, tblReferenceData.Description AS KPI_Type_Name,tblKPI.KPI_Category ,tblKPI.KPI_Descp,tblkpi.TypeLevel
,tblkpi.TypeAward,tblkpi.TypeContest

FROM tblKPI

INNER JOIN tblReferenceData ON

tblKPI.KPI_type = tblReferenceData.ReferenceData_ID

WHERE tblReferenceData.Active = 1;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetLevelGame` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetLevelGame`()
BEGIN

	SELECT tblLevelGame.GameID,tblLevelGame.GameName, tblLevelGame.Active AS GameActive 

	FROM tblLevelGame;





END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetLevelGameDDL` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetLevelGameDDL`(p_GameID INT)
BEGIN

	SELECT tblLevelGameDDL.GameDropdownID,tblLevelGameDDL.GameDropdownName,tblLevelGameDDL.GameID,tblLevelGameDDL.Active AS GameDDLActive

	FROM tblLevelGameDDL

	WHERE tblLevelGameDDL.GameID = p_GameID;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetLevelPerformance` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetLevelPerformance`()
BEGIN
	
SELECT 
			 user_id,
(SELECT Level_Position from tblLevel WHERE tblLevelPerformance.last_level = tblLevel.Level_ID) as  previos_level,
			 (SELECT Level_Position from tblLevel WHERE tblLevelPerformance.current_level = tblLevel.Level_ID) as  current_level,
			 (SELECT Level_Position from tblLevel WHERE tblLevelPerformance.next_level = tblLevel.Level_ID) as next_level,
(SELECT tblLevel.Level_Name from tblLevel WHERE tblLevel.Level_ID = tblLevelPerformance.next_level and tblLevel.Active = 1) as nextlevel_name,
(SELECT (tblLevelGameDDL.GameDropdownName) AS Reach from tblLevel INNER JOIN tblLevelGameDDL ON tblLevel.Reach = tblLevelGameDDL.GameDropdownID WHERE tblLevel.Level_ID = tblLevelPerformance.current_level and tblLevel.Active = 1) as nextlevel,
(SELECT tblLevel.Level_Name from tblLevel WHERE tblLevel.Level_ID = tblLevelPerformance.current_level and tblLevel.Active = 1) as currentlevel_name	,
(SELECT (tblLevelGameDDL.GameDropdownName) AS CurrentlyIn from tblLevel INNER JOIN tblLevelGameDDL ON tblLevel.CurrentlyIn = tblLevelGameDDL.GameDropdownID WHERE tblLevel.Level_ID = tblLevelPerformance.current_level and tblLevel.Active = 1) as currentlevel		
 from tblLevelPerformance WHERE level_achieved = 0;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetLevelperformance_PopupShowed` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetLevelperformance_PopupShowed`()
BEGIN

Select * from tblLevelPerformance;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetLevels` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetLevels`()
BEGIN

SELECT  tblLevel.Level_ID,
				Level_Name,
				tblRoles.Role_Name,
			  tblRoles.Role_ID,
				tblLevel.Active,
				tblLevel.Level_Position,
				BaseHours,
				tblLevel.Points
FROM tblLevel
INNER JOIN tblRoles ON 
	tblLevel.Role_ID = tblRoles.Role_ID
WHERE tblRoles.Active = 1 
ORDER BY tblLevel.Level_Position ASC;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetLevelsByRole` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetLevelsByRole`(IN `p_RoleID` int)
BEGIN



SELECT  tblLevel.Level_ID,

				Level_Name,

				tblRoles.Role_Name,

			  tblRoles.Role_ID,

				tblLevel.Active,

				CONCAT('Level ',CONVERT(tblLevel.Level_Position , CHARACTER(10)))    as Level_Position,
         tbllevel.Level_Position AS lvlPosition,

				tblLevel.Level_Position AS Level_PositionID,

				BaseHours,

ImageThumbnail,
ImageName,

				tblLevel.Points,

				tblLevel.Role_ID,

CONCAT(Level_Name,' | ','Level ',CONVERT(tblLevel.Level_Position , CHARACTER(10)))    as LevelName,

	tblLevel.CurrentlyIn,

	tblLevel.Reach,

	tblLevel.Game

FROM tblLevel

INNER JOIN tblRoles ON 

	tblLevel.Role_ID = tblRoles.Role_ID



WHERE tblRoles.Active = 1 and tblLevel.Role_ID=p_RoleID

ORDER BY tblLevel.Level_Position ASC;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetLifeLines` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetLifeLines`()
BEGIN

Select * From tblLifeLines;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetManualAssignedAwards` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetManualAssignedAwards`(p_UserID INT)
BEGIN

	SELECT tblUserAwards.award_id,
tblUserAwards.userAwardsId,

 tblUserAwards.achieved_scores,tblUserAwards.target_scores,

				tblUserAwards.awarded_date,tblUserAwards.awardedBy,tblUserAwards.manual,

				tblUserAwards.userAwardsId,tblUserAwards.user_id,

				tblAwards.Award_Name,

				tblAwards.Award_ID,

				CONCAT(tblUser.U_FirstName,' ',tblUser.U_LastName) AS FullName,

				tblUserAwards.popup_showed,

				tblUserAwards.awarded_date,

				(SELECT Award_Image FROM tblAwardImages WHERE Current_Image = 1 AND Active = 1 AND tblAwardImages.Award_ID = tblUserAwards.award_id) as Award_Thumbnail

	FROM tblUserAwards 

	INNER JOIN tblAwards ON 

	tblUserAwards.award_id = tblAwards.Award_ID

	INNER JOIN tblUser ON

	tblUserAwards.user_id = tblUser.UserID

	WHERE tblUserAwards.manual = 1 AND tblUserAwards.user_id = p_UserID;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetMapDetail` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetMapDetail`()
BEGIN	







SELECT * FROM tblLevel where Active = 1;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetMatch` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetMatch`(p_Where VARCHAR(10000))
BEGIN

DECLARE p_Select VARCHAR(2000);
DECLARE p_FinalQuery varchar(8000);

SET p_Select = 
'SELECT
	MatchID,
	MatchName,
	PointsForCompletation,
	MaxPlaysPerDay,
	NoOfDataSet,
	NoOfRounds,
	CreatedDate,
	MatchImage,
	MatchImageThumbnail,
	KPI_ID
FROM 
	tblmatch ';

SET @p_FinalQuery = CONCAT(p_Select,p_Where);
PREPARE result from @p_FinalQuery;
EXECUTE result;
DEALLOCATE PREPARE result;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetMatchDataSet_Player` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetMatchDataSet_Player`(p_MatchID int, p_LevelID int, p_RoleID int, p_RoundNumber int, p_NoDataSets int, p_DataElements int)
BEGIN	

IF(p_DataElements = 2)
THEN
	SELECT 
		tblmatchdatasets.DataSetID,
    REPLACE(SUBSTRING(SUBSTRING_INDEX(DataSetElementsData, '|', 1), LENGTH(SUBSTRING_INDEX(DataSetElementsData, '|', 1 -1)) + 1), '|', '') as DataElement1,
		'' as DataElement2,
		'' as DataElement3,
		DataSetElementsData,
		SiteID,   
		MatchID,
		tblmatchdatasetlevels.LevelID,
		(select NoOfDataSet from tblMatch Where MatchID = p_MatchID) as NoDataElements,
		(select MaxPlaysPerDay from tblMatch Where MatchID = p_MatchID) as LimitGame,
		(select NoOfDataSets from tblround Where MatchID = p_MatchID LIMIT p_RoundNumber, 1) as NoDataSets,
		(select TimePerRound from tblround Where MatchID = p_MatchID LIMIT p_RoundNumber, 1) as TimePerRound,
		(select PointsPerRound from tblround Where MatchID = p_MatchID LIMIT p_RoundNumber, 1) as PointsPerRound,
		DataSetImage,
		DataSetImageThumbnail
	FROM 
		tblmatchdatasets
	INNER JOIN tblmatchdatasetlevels 
	ON tblmatchdatasets.DataSetID = tblmatchdatasetlevels.DataSetID
	WHERE 
		MatchID = p_MatchID AND 
		tblmatchdatasetlevels.RoleID = p_RoleID AND
		tblmatchdatasetlevels.LevelID = p_LevelID
	ORDER BY RAND()
	LIMIT p_NoDataSets;
END IF;

IF(p_DataElements = 3)
THEN
	SELECT 
		tblmatchdatasets.DataSetID,
    REPLACE(SUBSTRING(SUBSTRING_INDEX(DataSetElementsData, '|', 1), LENGTH(SUBSTRING_INDEX(DataSetElementsData, '|', 1 -1)) + 1), '|', '') as DataElement1,
    REPLACE(SUBSTRING(SUBSTRING_INDEX(DataSetElementsData, '|', 2), LENGTH(SUBSTRING_INDEX(DataSetElementsData, '|', 2 -1)) + 1), '|', '') as DataElement2,
		'' as DataElement3,
		DataSetElementsData,
		SiteID,   
		MatchID,
		tblmatchdatasetlevels.LevelID,
		(select NoOfDataSet from tblMatch Where MatchID = p_MatchID) as NoDataElements,
		(select MaxPlaysPerDay from tblMatch Where MatchID = p_MatchID) as LimitGame,
		(select NoOfDataSets from tblround Where MatchID = p_MatchID LIMIT p_RoundNumber, 1) as NoDataSets,
		(select TimePerRound from tblround Where MatchID = p_MatchID LIMIT p_RoundNumber, 1) as TimePerRound,
		(select PointsPerRound from tblround Where MatchID = p_MatchID LIMIT p_RoundNumber, 1) as PointsPerRound,
		DataSetImage,
		DataSetImageThumbnail
	FROM 
		tblmatchdatasets
	INNER JOIN tblmatchdatasetlevels 
	ON tblmatchdatasets.DataSetID = tblmatchdatasetlevels.DataSetID
	WHERE 
		MatchID = p_MatchID AND 
		tblmatchdatasetlevels.RoleID = p_RoleID AND
		tblmatchdatasetlevels.LevelID = p_LevelID
	ORDER BY RAND()
	LIMIT p_NoDataSets;
END IF;

IF(p_DataElements = 4)
THEN
	SELECT 
		tblmatchdatasets.DataSetID,
    REPLACE(SUBSTRING(SUBSTRING_INDEX(DataSetElementsData, '|', 1), LENGTH(SUBSTRING_INDEX(DataSetElementsData, '|', 1 -1)) + 1), '|', '') as DataElement1,
    REPLACE(SUBSTRING(SUBSTRING_INDEX(DataSetElementsData, '|', 2), LENGTH(SUBSTRING_INDEX(DataSetElementsData, '|', 2 -1)) + 1), '|', '') as DataElement2,
    REPLACE(SUBSTRING(SUBSTRING_INDEX(DataSetElementsData, '|', 3), LENGTH(SUBSTRING_INDEX(DataSetElementsData, '|', 3 -1)) + 1), '|', '') as DataElement3,
		DataSetElementsData,
		SiteID,   
		MatchID,
		tblmatchdatasetlevels.LevelID,
		(select NoOfDataSet from tblMatch Where MatchID = p_MatchID) as NoDataElements,
		(select MaxPlaysPerDay from tblMatch Where MatchID = p_MatchID) as LimitGame,
		(select NoOfDataSets from tblround Where MatchID = p_MatchID LIMIT p_RoundNumber, 1) as NoDataSets,
		(select TimePerRound from tblround Where MatchID = p_MatchID LIMIT p_RoundNumber, 1) as TimePerRound,
		(select PointsPerRound from tblround Where MatchID = p_MatchID LIMIT p_RoundNumber, 1) as PointsPerRound,
		DataSetImage,
		DataSetImageThumbnail
	FROM 
		tblmatchdatasets
	INNER JOIN tblmatchdatasetlevels 
	ON tblmatchdatasets.DataSetID = tblmatchdatasetlevels.DataSetID
	WHERE 
		MatchID = p_MatchID AND 
		tblmatchdatasetlevels.RoleID = p_RoleID AND
		tblmatchdatasetlevels.LevelID = p_LevelID
	ORDER BY RAND()
	LIMIT p_NoDataSets;
END IF;

Select * from tblusermatchpoints;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetMatchPlayLog` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetMatchPlayLog`()
BEGIN

Select * from tblMatchPlayLog;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetMatch_Player` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetMatch_Player`()
BEGIN
	
SELECT  
	SUM(PointsAchieved) AS MatchPoints, 
	tblmatch.MatchID, 
	tblmatch.MatchName,
	tblmatch.MatchImageThumbnail,
	tblUser.UserID, 
	CONCAT(tblUser.U_FirstName,	' ', tblUser.U_LastName) AS FullName
FROM tblusermatchpoints
Right JOIN tblmatch 
ON tblusermatchpoints.MatchID = tblmatch.MatchID
Left JOIN tblUser 
ON tblusermatchpoints.UserID = tblUser.UserID
GROUP BY 
	MatchID,
	UserID;

SELECT * FROM tblusermatchpoints;

SELECT * FROM tblUserMatchPointsTemperory
INNER JOIN tblmatchdatasets 
ON tblUserMatchPointsTemperory.MatchID = tblmatchdatasets.MatchID;

SELECT  
	SUM(PointsAchieved) AS MatchPoints, 
	tblmatch.MatchID, 
	tblmatch.MatchName,
	tblmatch.MatchImageThumbnail,
	tblUser.UserID, 
	tblmatch.MaxPlaysPerDay,
	tblmatch.KPI_ID,
	CONCAT(tblUser.U_FirstName,' ',tblUser.U_LastName) AS FullName
FROM 
	tblusermatchpoints
Right JOIN tblmatch 
ON tblusermatchpoints.MatchID = tblmatch.MatchID
Left JOIN tblUser 
ON tblusermatchpoints.UserID = tblUser.UserID
GROUP BY 
	MatchID;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetMessages` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetMessages`()
BEGIN

	

SELECT ID,From_UserID,To_UserID,Message_Subject,Message_Text,IsRead,IsReply,Sent_Date,Active,RepliedMessageID,

(SELECT CONCAT(tblUser.U_FirstName,' ',tblUser.U_LastName) from tblUser WHERE tblUser.UserID = tblMessages.From_UserID)  as FullName,

(SELECT tblUserImages.Player_Thumbnail FROM tblUserImages WHERE tblUserImages.UserID = tblMessages.From_UserID AND tblUserImages.U_Current = 1) AS Player_Thumbnail

 from tblMessages

ORDER BY tblMessages.Sent_Date DESC;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetPlayerLevelPercent` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetPlayerLevelPercent`(p_UserID INT)
BEGIN

	SELECT  tblLevelPerformance.levelPerformanceId, tblLevelPerformance.current_level,tblLevel.Level_Position,tblLevelPerformance.last_level,tblLevelPerformance.next_level,

				

				tblLevelPerformance.popup_showed,

				(SELECT lvl.Points FROM tblLevel lvl 

				WHERE lvl.Level_ID = tblLevelPerformance.current_level AND lvl.Active = 1) AS Bonus,

				(SELECT leve.Level_Name  FROM tblLevel leve WHERE leve.Level_ID = tblLevelPerformance.current_level) AS CurrentLevelName,

					IFNULL(((achieved_scores/target_scores) * 100),0) AS Percentage					

	FROM tblLevelPerformance

	INNER JOIN tblLevel ON

	tblLevelPerformance.current_level = tblLevel.Level_ID

	WHERE tblLevelPerformance.user_id = p_UserID AND tblLevelPerformance.level_achieved = 0;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetPoints` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetPoints`(p_UserID int)
BEGIN

Select U_Points from tblUser

Where UserId = p_UserID;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetPostByID` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetPostByID`(`p_PostID` int)
BEGIN

Select * from tblPosts where PostID = p_PostID;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetPostDetails` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetPostDetails`(p_PostID int)
BEGIN

	Select *,

(Select U_FirstName from tblUser where tblUser.UserID = RepliedBy) as RepliedByName,

(Select count(*) from tblPostRepliedLikes Where PostID = p_PostID and tblPostRepliedLikes.LikeID = ReplyID) as Likes from tblPostReplies 

Where PostID = p_PostID;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetPosts` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetPosts`(p_Where VARCHAR(10000))
BEGIN



DECLARE p_Select VARCHAR(2000); DECLARE p_Select2 VARCHAR(2000);

DECLARE p_FinalQuery varchar(8000);



SET p_Select = '



SELECT S.* From (

Select @rownum:=@rownum+1 rownum , P.PostID as ID, P.PostTitle as Topic, P.RoleID , P.CreateDate, P.CreatedBy, P.PostMessage

,(Select COUNT(*) FROM tblPostReplies WHERE tblPostReplies.PostID = P.PostID ) as Replies

,(Select COUNT(*) FROM tblPostRepliedLikes WHERE tblPostRepliedLikes.PostID = P.PostID ) as Likes

,(SELECT B.U_Name from tblPostReplies A, tblUser B WHERE A.RepliedBy = B.UserID and A.ReplyDate = (SELECT Max(ReplyDate) from tblPostReplies where tblPostReplies.PostID = P.PostID)) as LastReply

,IFNULL(TIMESTAMPDIFF (MINUTE,(SELECT Max(ReplyDate) as Maz from tblPostReplies where tblPostReplies.PostID = P.PostID),CURRENT_TIMESTAMP()),0) as LatestDate 

from tblPosts P, (SELECT @rownum:=0) R ) S  

  '; 



SET @p_Select2 = '

SELECT COUNT(*) as TotalRecords From (

Select @rownum:=@rownum+1 rownum , P.PostID as ID, P.PostTitle as Topic

,(Select COUNT(*) FROM tblPostReplies WHERE tblPostReplies.PostID = P.PostID ) as Replies

,(Select COUNT(*) FROM tblPostRepliedLikes WHERE tblPostRepliedLikes.PostID = P.PostID ) as Likes

,(SELECT B.U_Name from tblPostReplies A, tblUser B WHERE A.RepliedBy = B.UserID and A.ReplyDate = (SELECT Max(ReplyDate) from tblPostReplies where tblPostReplies.PostID = P.PostID)) as LastReply

,IFNULL(TIMESTAMPDIFF (MINUTE,(SELECT Max(ReplyDate) as Maz from tblPostReplies where tblPostReplies.PostID = P.PostID),CURRENT_TIMESTAMP()),0) as LatestDate 

from tblPosts P, (SELECT @rownum:=0) R ) S 

';



SET @p_FinalQuery = CONCAT(p_Select,p_Where);



PREPARE result from @p_FinalQuery; PREPARE result2 from @p_Select2;

EXECUTE result; EXECUTE result2;

DEALLOCATE PREPARE result; DEALLOCATE PREPARE result2;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetPostTypes` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetPostTypes`()
BEGIN

	Select * from tblPostTypes;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetQuestionLevels` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetQuestionLevels`(p_QuestionID INT, p_RoleID INT)
BEGIN

	SELECT QuestionID,RoleID,LevelID FROM tblQuestionLevels WHERE QuestionID = p_QuestionID AND RoleID = p_RoleID;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetQuiz` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetQuiz`(p_Where VARCHAR(10000))
BEGIN	

DECLARE p_Select VARCHAR(2000);
DECLARE p_FinalQuery varchar(8000);

SET p_Select = 
' SELECT 
			QuizID,
			QuizName ,
			NoOfQuestions,
			TimePerQuestion,
			TimesPlayablePerDay,
			TimeBeforePointsDeduction,
			PointsPerQuestion,
			CreatedDate,
			QuizImage,
			QuizImageThumbnail,
			KPI_ID
	  FROM tblQuiz ';

SET @p_FinalQuery = CONCAT(p_Select,p_Where);
PREPARE result from @p_FinalQuery;
EXECUTE result;
DEALLOCATE PREPARE result;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetQuizPlayLog` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetQuizPlayLog`()
BEGIN

Select * from tblQuizPlayLog;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetQuizQuestions` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetQuizQuestions`(p_Where VARCHAR(10000),p_Status int)
BEGIN





DECLARE p_Select VARCHAR(2000);

DECLARE p_FinalQuery varchar(8000);

if(p_Status =1)

then

SET p_Select = 

 ' SELECT 

			tblQuizQuestions.QuestionID,

			QuestionText ,

      ShortQuestion,

			QuestionExplanation,

			Answer1,

			Answer2,

			Answer3,

			Answer4,

			CorrectAnswer,

			Category,

			SiteID,			

			QuizID,

			QuestionImage,

			QuestionImageThumbnail

	  FROM tblQuizQuestions

		INNER JOIN tblQuestionLevels ON tblQuizQuestions.QuestionID = tblQuestionLevels.QuestionID

 ';



SET @p_FinalQuery = CONCAT(p_Select,p_Where);

PREPARE result from @p_FinalQuery;

EXECUTE result;

DEALLOCATE PREPARE result;

END IF;

IF(p_Status =0)

then

SET p_Select = 

 ' SELECT 

			tblQuizQuestions.QuestionID,

			QuestionText ,

      ShortQuestion,

			QuestionExplanation,

			Answer1,

			Answer2,

			Answer3,

			Answer4,

			CorrectAnswer,

			Category,

			SiteID,			

			QuizID,

			QuestionImage,

			QuestionImageThumbnail

	  FROM tblQuizQuestions

 ';



SET @p_FinalQuery = CONCAT(p_Select,p_Where);

PREPARE result from @p_FinalQuery;

EXECUTE result;

DEALLOCATE PREPARE result;





END IF;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetQuizQuestion_Player` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetQuizQuestion_Player`(p_QuizID int, p_RoleID int, p_LevelID int)
BEGIN	
SELECT 
   tblQuizQuestions.QuestionID,
   QuestionText ,
   ShortQuestion,
   QuestionExplanation,
   Answer1,
   Answer2,
   Answer3,
   Answer4,
   CorrectAnswer,
   Category,
   SiteID,   
   QuizID,
tblQuestionLevels.LevelID,
(select TimesPlayablePerDay from tblQuiz Where QuizID=p_QuizID) as LimitGame,
(select TimeBeforePointsDeduction from tblQuiz Where QuizID=p_QuizID) as DeductionTime,
(select NoOfQuestions from tblQuiz Where QuizID=p_QuizID) as NoQuestions,
(select TimePerQuestion from tblQuiz Where QuizID=p_QuizID) as timeQuestion,

(select PointsPerQuestion from tblQuiz Where QuizID=p_QuizID) as QuestionPoints,
   QuestionImage,
   QuestionImageThumbnail
   FROM tblQuizQuestions
  INNER JOIN tblQuestionLevels ON tblQuizQuestions.QuestionID = tblQuestionLevels.QuestionID

  WHERE QuizID = p_QuizID AND tblQuestionLevels.RoleID = p_RoleID ;

Select * from tblUserQuizPoints;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetQuiz_Player` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetQuiz_Player`(p_RoleID int,p_LevelID int)
BEGIN
	
SELECT  SUM(PointsAchieved) AS QuizPoints, tblQuiz.QuizID, tblQuiz.QuizName,tblQuiz.QuizImageThumbnail,tblUser.UserID, 
CONCAT(tblUser.U_FirstName,' ',tblUser.U_LastName) AS FullName
FROM tblUserQuizPoints
Right JOIN tblQuiz ON tblUserQuizPoints.QuizID = tblQuiz.QuizID
Left JOIN tblUser ON tblUserQuizPoints.UserID = tblUser.UserID
GROUP BY QuizID,UserID;

Select * from tblUserQuizPoints ;

select * from tblUserQuizPointsTemperory
inner join tblQuizQuestions on tblUserQuizPointsTemperory.QuestionID= tblQuizQuestions.QuestionID
ORDER BY tblUserQuizPointsTemperory.UserQuizPointsID ASC;


SELECT  SUM(PointsAchieved) AS QuizPoints, tblQuiz.QuizID, tblQuiz.QuizName,tblQuiz.QuizImageThumbnail,tblUser.UserID, tblQuiz.TimesPlayablePerDay, tblQuiz.KPI_ID,

CONCAT(tblUser.U_FirstName,' ',tblUser.U_LastName) AS FullName
FROM tblUserQuizPoints
Right JOIN tblQuiz ON tblUserQuizPoints.QuizID = tblQuiz.QuizID
Left JOIN tblUser ON tblUserQuizPoints.UserID = tblUser.UserID
INNER JOIN tblquizlevels ON tblquiz.QuizID = tblquizlevels.QuizID
WHERE tblquizlevels.RoleID = p_RoleID AND tblquizlevels.LevelID =p_LevelID
GROUP BY QuizID;

Select tblquiz.QuizID
FROM tblquiz INNER JOIN tbltarget
ON tblquiz.KPI_ID = tbltarget.KPI_ID
WHERE tbltarget.Level_ID = p_LevelID AND tbltarget.Role_ID= p_RoleID ;

Select Score, tblscores.User_ID, tblscores.Type_ID
from tblScores
Where U_Type ='KPI' AND LevelID = p_LevelID ;

SELECT * FROM tblquizresulttotal;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetRedeemPoints` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetRedeemPoints`()
BEGIN

select * from tblRedeem;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetRepliedLikeStatus` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetRepliedLikeStatus`(`p_LikeID` int,`P_LikedBy` int,`p_PostID` int)
BEGIN

	Select count(*) as TotalLikes from tblPostRepliedLikes

  Where LikeID = p_LikeID and LikedBy = p_LikedBy and PostID = p_PostID;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetReward` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetReward`()
BEGIN

Select *,
(SELECT Reward_Image FROM tblRewardImages WHERE Current_Image = 1 AND Active = 1 AND tblRewardImages.Reward_ID = tblRewards.Reward_ID) as Reward_Image,
(SELECT Reward_Thumbnail FROM tblRewardImages WHERE Current_Image = 1 AND Active = 1 AND tblRewardImages.Reward_ID = tblRewards.Reward_ID) as Reward_Thumbnail
 from tblRewards  ORDER BY tblRewards.Reward_Cost;


END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetRewardImages` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetRewardImages`()
BEGIN

	

SELECT ID, tblRewardImages.Reward_ID, Reward_Image, Reward_Thumbnail, Uploaded_Date, Current_Image

FROM tblRewardImages

INNER JOIN tblRewards ON

tblRewards.Reward_ID = tblRewardImages.Reward_ID

WHERE tblRewards.Active = 1;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetRewardUser` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetRewardUser`(p_UserID INT)
BEGIN
SELECT tblRedeem.Reward_ID,
 			tblRedeem.Redeem_Date,tblRedeem.User_ID,

				tblRewards.Reward_Name,

				tblRewards.Reward_ID,

				CONCAT(tblUser.U_FirstName,' ',tblUser.U_LastName) AS FullName,

				(SELECT Reward_Image FROM tblRewardImages WHERE Current_Image = 1 AND Active = 1 AND tblRewardImages.Reward_ID = tblRedeem.Reward_ID) as Reward_Thumbnail

	FROM tblRedeem 

	INNER JOIN tblRewards ON 

	tblRedeem.Reward_ID = tblRewards.Reward_ID

	INNER JOIN tblUser ON

	tblRedeem.User_ID = tblUser.UserID

	WHERE tblRedeem.User_ID = p_UserID;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetRoles` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetRoles`()
BEGIN



Select * from tblRoles;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetRound` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetRound`(p_Where VARCHAR(10000))
BEGIN	

DECLARE p_Select VARCHAR(2000);
DECLARE p_FinalQuery varchar(8000);

SET p_Select = 
'SELECT 
	RoundID,
    MatchID,
	RoundNumber,
    RoundName,
	NoOfDataSets,
	TimePerRound,
	PointsPerRound,
	CreatedDate,
	ShowHint
FROM tblRound';

SET @p_FinalQuery = CONCAT(p_Select,p_Where);
PREPARE result from @p_FinalQuery;
EXECUTE result;
DEALLOCATE PREPARE result;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetSecurityQuestions` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetSecurityQuestions`()
BEGIN



Select * from tblSecurityQuestions;	



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetSites_ddl` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetSites_ddl`()
BEGIN

	

SELECT site_id, concat(site_name," | ", site_type ) as site_name, site_type 

from tblSite 

WHERE Active = 1

order by site_name;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetTarget` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetTarget`()
BEGIN

SELECT Target_ID,Target_Value,tblTarget.KPI_ID,tblTarget.Level_ID,tblTarget.Role_ID,tblTarget.Active,BaseHours,tblLevel.Points, tblLevel.Level_Position, tblTarget.Points as TPoints

				,tblKPI.KPI_name,tblLevel.Level_Name,tblRoles.Role_Name,tblTarget.Target_Desc,Level_Name,CurrentlyIn,Reach,Game,ImageThumbnail,ImageName,tbltarget.Target_Order as TOrder

FROM tblTarget

INNER JOIN tblKPI ON

tblTarget.KPI_ID = tblKPI.KPI_ID

INNER JOIN tblLevel ON

tblTarget.Level_ID = tblLevel.Level_ID

INNER JOIN tblRoles ON

tblTarget.Role_ID = tblRoles.Role_ID

WHERE tblKPI.Active = 1 AND tblLevel.Active = 1 AND tblRoles.Active = 1 ORDER BY tbltarget.Target_Order ASC;


SELECT tblawards.Target_Value ,tblawards.Award_ID,tblawards.KPIID from tblawards
where tblawards.Award_Manual=0 ;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetTargetDescription` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetTargetDescription`()
BEGIN



SELECT (SELECT KPI_name from tblKPI where tblKPI.KPI_ID = tblTarget.KPI_ID) as KPIName,

(SELECT KPI_Descp from tblKPI where tblKPI.KPI_ID = tblTarget.KPI_ID) as KPIDesc,
(SELECT TipsDESC from tblKPI where tblKPI.KPI_ID = tblTarget.KPI_ID) as TipsDesc,
(SELECT TipsLINK from tblKPI where tblKPI.KPI_ID = tblTarget.KPI_ID) as TipsLink,	

				Target_ID,

				Target_Desc

 from tblTarget;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetTargetValue` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetTargetValue`(p_LevelID int,p_RoleID int)
BEGIN

Select Sum(Target_Value) from tblTarget

where Level_ID=p_LevelID AND Role_ID =p_RoleID;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetTotalPlayerScore` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetTotalPlayerScore`()
BEGIN



	SELECT Target_Value,

				 tblTarget.KPI_ID,

				 tblTarget.Role_ID,

				 tblTarget.Level_ID FROM tblTarget

where tblTarget.Level_ID  = 1;







END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetUser` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetUser`(p_Where VARCHAR(10000))
BEGIN

DECLARE p_Select VARCHAR(2000);

DECLARE p_FinalQuery varchar(8000);



SET p_Select = 

' SELECT UserID, U_EmpID, U_FirstName ,U_Points,	

(SELECT CONCAT(tblUser.U_FirstName,'' '',tblUser.U_LastName)) as FullName,

	U_Name,

	U_LastName ,

	U_NickName,

	Display_Name,

	tblUser.Active,

    tblRoles.Role_Name,

		tblUser.U_RolesID,

tblUser.U_SysRole,

tblUser.U_Email,

tblUser.U_SiteID,

tblUser.ManagerID,(Select Worked_Hour from tblLevelPerformance 

Where user_id = tblUser.UserID and level_achieved =0) as WorkedHour,

(Select current_level from tblLevelPerformance 

Where user_id = tblUser.UserID and level_achieved =0) as LevelID,

(SELECT Player_Thumbnail FROM tblUserImages WHERE UserID = tblUser.UserID AND U_Current = 1) AS Player_Thumbnail,

(Select IFNULL(tblLevel.Level_Position,0) from tblLevelPerformance 

INNER JOIN tblLevel ON tblLevelPerformance.current_level = tblLevel.Level_ID

Where user_id = tblUser.UserID and level_achieved =0) AS Level

FROM tblUser

INNER JOIN tblRoles ON

tblUser.U_RolesID = tblRoles.Role_ID ';





SET @p_FinalQuery = CONCAT(p_Select,p_Where,' AND tblRoles.Active = 1  ORDER BY FullName');

PREPARE result from @p_FinalQuery;

EXECUTE result;

DEALLOCATE PREPARE result;





END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetUserAwardScore` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetUserAwardScore`(p_UserID int)
BEGIN



	Select tblUserAwards.award_id,

(SELECT tblAwards.Award_Name FROM tblAwards where Award_ID = tblUserAwards.award_id) as AwardName,

tblUserAwards.target_scores,

tblUserAwards.achieved_scores,

(select (achieved_scores * 100 / target_scores)) as Percentage,

(Select 'yes' from tblUserAwardAchieved where  tblUserAwards.user_id=p_UserID) as achieved

from tblUserAwards



where  tblUserAwards.user_id=p_UserID and manual = 0



 

;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetUserInfoByEmail` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetUserInfoByEmail`(IN `p_Email` varchar(50))
BEGIN

	SELECT tblUser.UserID,tblUser.U_Name 

	FROM tblUser 

	WHERE tblUser.U_Email = p_Email AND tblUser.Active = 1;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetUserProgressDetail` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetUserProgressDetail`(p_UserID INT)
BEGIN



	SELECT  tblLevelPerformance.user_id,

					tblTarget.Target_ID,

					SUM(tblScores.Score),

					tblTarget.Target_Value,					

					tblLevelPerformance.target_scores,

					(tblTarget.Target_Value - SUM(tblScores.Score)) AS RemainingScore,

					IFNULL(CEIL ((SUM(tblScores.Score)/Target_Value)*100),0) as current_percentage,

					tblTarget.KPI_ID,

					tblLevelPerformance.level_achieved,

					(SELECT KPI_name from tblKPI where tblKPI.KPI_ID = tblTarget.KPI_ID) as KPIName,	

					(SELECT DATE_ADD(Level_date,INTERVAL BaseHours HOUR) from tblLevel WHERE tblLevel.Level_ID = tblLevelPerformance.current_level and tblLevelPerformance.user_id = p_UserID and tblLevel.Active = 1) as TargetDate,	

					(SELECT tblLevel.Level_Name from tblLevel WHERE tblLevel.Level_ID = tblLevelPerformance.last_level and tblLevelPerformance.user_id = p_UserID and tblLevel.Active = 1) as previouslevel_name,			

					(SELECT tblLevel.Level_Name from tblLevel WHERE tblLevel.Level_ID = tblLevelPerformance.current_level and tblLevelPerformance.user_id = p_UserID and tblLevel.Active = 1) as currentlevel_name,	

					(SELECT tblLevel.Level_Name from tblLevel WHERE tblLevel.Level_ID = tblLevelPerformance.next_level and tblLevelPerformance.user_id = p_UserID and tblLevel.Active = 1 ) as nextlevel_name,							

					(SELECT CONCAT(tblUser.U_FirstName,' ',tblUser.U_LastName) FROM tblUser WHERE tblUser.UserID = p_UserID) AS PlayerName,

				  tblTarget.Level_ID

FROM tblScores 

INNER JOIN tblTarget ON 

tblScores.Type_ID = tblTarget.KPI_ID AND tblScores.U_Type = 'KPI' and tblScores.User_ID = p_UserID

  INNER JOIN tblLevelPerformance on tblTarget.Level_ID = tblLevelPerformance.current_level

where tblLevelPerformance.user_id = p_UserID AND tblLevelPerformance.level_achieved = 0

GROUP BY tblTarget.KPI_ID ;





END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetUsersByRole` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetUsersByRole`(p_RoleID int)
BEGIN

	

SELECT UserID,

(SELECT CONCAT(tblUser.U_FirstName,' ',tblUser.U_LastName)) as FullName

 from tblUser 

where tblUser.U_RolesID = p_RoleID;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetUserScoreAdmin` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetUserScoreAdmin`(p_UserID int,p_LevelID int)
BEGIN



IF (EXISTS(SELECT * FROM tbltarget WHERE tbltarget.Level_ID = p_LevelID))
	THEN

Select v_UserLevelScores1.*,(CASE WHEN v_UserLevelScores1.current_percentage < 80 THEN 'red' WHEN v_UserLevelScores1.current_percentage > 80 AND v_UserLevelScores1.current_percentage <90 THEN 'Yellow' ELSE 'Green' END) AS PlayerStatus 

,tblLevel.Points as target_scores

,(SELECT DATE_ADD(Level_date,INTERVAL BaseHours HOUR) from tblLevel WHERE tblLevel.Level_ID = tblLevelPerformance.current_level and tblLevelPerformance.user_id = p_UserID and tblLevel.Active = 1) as TargetDate

,(SELECT tblLevel.Level_Name from tblLevel WHERE tblLevel.Level_ID = tblLevelPerformance.last_level and tblLevelPerformance.user_id = p_UserID and tblLevel.Active = 1) as previouslevel_name,	

(SELECT (tblLevelGameDDL.GameDropdownName) AS Reach from tblLevel INNER JOIN tblLevelGameDDL ON tblLevel.Reach = tblLevelGameDDL.GameDropdownID WHERE tblLevel.Level_ID = p_LevelID and tblLevel.Active = 1) as Reach,	

(SELECT (tblLevelGameDDL.GameDropdownName) AS CurrentlyIn from tblLevel INNER JOIN tblLevelGameDDL ON tblLevel.CurrentlyIn = tblLevelGameDDL.GameDropdownID WHERE tblLevel.Level_ID = p_LevelID and tblLevel.Active = 1) as CurrentlyIn,		

	(SELECT tblLevel.Level_Name from tblLevel WHERE tblLevel.Level_ID = tblLevelPerformance.current_level and tblLevelPerformance.user_id = p_UserID and tblLevel.Active = 1) as currentlevel_name,	

	(SELECT tblLevel.Level_Name from tblLevel WHERE tblLevel.Level_ID = tblLevelPerformance.next_level and tblLevelPerformance.user_id = p_UserID and tblLevel.Active = 1 ) as nextlevel_name

,(select (IFNULL(sum(current_percentage),0)) / Count(*) from v_UserLevelScores where Level_ID=v_UserLevelScores1.Level_ID and UserID=v_UserLevelScores1.UserID) as Performance 



,tblLevel.Points  as Bonus,
"0" as CheckNoProgress 

from v_UserLevelScores as  v_UserLevelScores1

LEFT OUTER JOIN tblLevelPerformance on v_UserLevelScores1.Level_ID = tblLevelPerformance.current_level

LEFT OUTER JOIN tblLevel on v_UserLevelScores1.Level_ID = tblLevel.Level_ID

where v_UserLevelScores1.Level_ID=p_LevelID and v_UserLevelScores1.UserID=p_UserID AND tblLevelPerformance.level_achieved = 0  AND tblLevelPerformance.user_id = p_UserID ORDER BY v_UserLevelScores1.KPI_name;


	ELSE

Select tbllevel.Level_Name,tbllevel.Points  as Bonus ,"1" as CheckNoProgress,tbllevel.BaseHours,tbllevel.Level_Position,tblroles.Role_Name,
(Select tbluser.U_Points from tbluser where tbluser.UserID = p_UserID) AS Points,
(Select CONCAT(tblUser.U_FirstName,' ',tblUser.U_LastName) from tbluser WHERE tbluser.UserID = p_UserID) AS PlayerName,
(SELECT (tblLevelGameDDL.GameDropdownName) AS Reach from tblLevel INNER JOIN tblLevelGameDDL ON tblLevel.Reach = tblLevelGameDDL.GameDropdownID WHERE tblLevel.Level_ID = p_LevelID and tblLevel.Active = 1) as Reach,	

(SELECT (tblLevelGameDDL.GameDropdownName) AS CurrentlyIn from tblLevel INNER JOIN tblLevelGameDDL ON tblLevel.CurrentlyIn = tblLevelGameDDL.GameDropdownID WHERE tblLevel.Level_ID = p_LevelID and tblLevel.Active = 1) as CurrentlyIn

from tbllevel INNER JOIN tblroles ON tbllevel.Role_ID =tblroles.Role_ID
Where tbllevel.Level_ID = p_LevelID;

	END IF;














	









END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetUsersInfo` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetUsersInfo`(p_Name Varchar(50),p_Password VARCHAR(50))
BEGIN







Select *,(SELECT U_Email FROM tblUser M WHERE M.UserID = tblUser.ManagerID) AS ManagerEmail,

				

				tblRoles.Role_Name as RoleName,(SELECT tblSite.site_name FROM tblSite WHERE tblSite.site_id = tblUser.U_SiteID) AS SiteName

from tblUser INNER JOIN

     tblRoles ON tblUser.U_RolesID = tblRoles.Role_ID 



WHERE U_Name =p_Name

and BINARY U_password =p_Password and tblUser.Active =1;









END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetUsersInfoByID` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetUsersInfoByID`(p_User_ID int)
BEGIN

Select
	tblUser.UserID, 
	tblUser.U_Name, 
	tblUser.U_SysRole, 
	tblUser.U_RolesID, 
	tblUser.U_Password, 
	tblUser.U_FirstName, 
	tblUser.U_LastName, 
	tblUser.U_NickName, 
	tblUser.Active, 
	tblUser.U_Email, 
	tblUser.U_SiteID, 
	tblUser.U_EmpNo, 
	tblUser.ManagerID, 
	tblUser.Display_Name, 
	tblUser.U_Points, 
	tblUser.ActiveUpdatedDate, 
	M.U_Email AS ManagerEmail,
	tblRoles.Role_Name as RoleName,
	tblSite.site_name AS SiteName
from 
	tblUser INNER JOIN tblRoles 
	ON tblUser.U_RolesID = tblRoles.Role_ID INNER JOIN tblSite 
	ON tblUser.U_SiteID = tblSite.site_id LEFT OUTER JOIN tblUser M 
	ON tblUser.ManagerID= M.UserID 
WHERE 
	tblUser.UserID = p_User_ID and 
	tblUser.Active = 1;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetUsersInfoTemp` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetUsersInfoTemp`(p_Name Varchar(50))
BEGIN

if((SELECT tbluser.U_SysRole from tbluser where tblUser.U_Name =p_Name) = 'Player' )
THEN


Select
tblUser.UserID,tblUser.U_Name,tblUser.U_SysRole,tblUser.U_RolesID,tblUser.U_Password,tblUser.U_FirstName,tblUser.U_LastName,tblUser.U_NickName,tblUser.Active,tblUser.U_Email,tblUser.U_SiteID
,tblUser.U_EmpNo,tblUser.ManagerID,tblUser.Display_Name,tblUser.U_Points,tblUser.ActiveUpdatedDate,M.U_Email AS ManagerEmail,tblRoles.Role_Name as RoleName,tblSite.site_name AS SiteName,
tblLevelPerformance.current_level,tblLevel.Level_Position,tblLevel.Level_Name,tbllevel.Points,tbllevel.ImageName



from tblUser INNER JOIN

tblRoles ON tblUser.U_RolesID = tblRoles.Role_ID 

INNER JOIN

tblSite ON tblUser.U_SiteID = tblSite.site_id

LEFT OUTER JOIN

tblUser M ON  tblUser.ManagerID= M.UserID

INNER JOIN tbllevelperformance ON 

tblLevelPerformance.user_id = tblUser.UserID

INNER JOIN tbllevel ON tblLevelPerformance.current_level = tblLevel.Level_ID



WHERE tblUser.U_Name =p_Name and tblUser.Active =1 and tblLevelPerformance.level_achieved = 0;



SELECT  tblLevel.Level_ID,
				Level_Name,
				tblRoles.Role_Name,
			  tblRoles.Role_ID,
				tblLevel.Active,
				tblLevel.Level_Position,
				BaseHours,
				tblLevel.Points
FROM tblLevel
INNER JOIN tblRoles ON 
	tblLevel.Role_ID = tblRoles.Role_ID
WHERE tblRoles.Active = 1 
ORDER BY tblLevel.Level_Position ASC;



ELSE


Select  

tblUser.UserID,tblUser.U_Name,tblUser.U_SysRole,tblUser.U_RolesID,tblUser.U_Password,tblUser.U_FirstName,tblUser.U_LastName,tblUser.U_NickName,tblUser.Active,tblUser.U_Email,tblUser.U_SiteID

,tblUser.U_EmpNo,tblUser.ManagerID,tblUser.Display_Name,tblUser.U_Points,tblUser.ActiveUpdatedDate,M.U_Email AS ManagerEmail,tblRoles.Role_Name as RoleName,tblSite.site_name AS SiteName



from tblUser INNER JOIN

tblRoles ON tblUser.U_RolesID = tblRoles.Role_ID 

INNER JOIN

tblSite ON tblUser.U_SiteID = tblSite.site_id

LEFT OUTER JOIN

tblUser M ON  tblUser.ManagerID= M.UserID


WHERE tblUser.U_Name =p_Name and tblUser.Active =1;



END IF;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetUsers_Manager` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetUsers_Manager`()
BEGIN



SELECT tblUser.UserID,tblUser.U_Name FROM tblUser WHERE tblUser.U_SysRole = 'Manager';



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_GetUserTargetScoreAdmin` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_GetUserTargetScoreAdmin`(p_UserID int,p_LevelID int)
BEGIN



Select v_UserLevelScores1.*,

(select (IFNULL(sum(current_percentage),0)) / Count(*) from v_UserLevelScores where Level_ID=v_UserLevelScores1.Level_ID and UserID=v_UserLevelScores1.UserID) as Performance ,

(Select 'yes' from tblUserTargetAchieved where Target_ID=v_UserLevelScores1.Target_ID and UserID=p_UserID) as achieved,CONCAT(tblUser.U_FirstName,' ',tblUser.U_LastName) AS FullName 

,tblRoles.Role_Name,tblLevel.Level_Name,tblLevel.Level_Position,tblUser.U_Name



from v_UserLevelScores as  v_UserLevelScores1

LEFT JOIN tblUser ON v_UserLevelScores1.UserID = tblUser.UserID

LEFT JOIN tblRoles ON v_UserLevelScores1.Role_ID = tblRoles.Role_ID

LEFT JOIN tblLevel ON v_UserLevelScores1.Level_ID = tblLevel.Level_ID

where v_UserLevelScores1.Level_ID=p_LevelID 

and v_UserLevelScores1.UserID=p_UserID





 

;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertAwardImage` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_InsertAwardImage`(p_AwardImage varchar(100),p_AwardThumbnail varchar(100),  p_AwardID int,p_CurrentImage INT)
BEGIN

INSERT INTO tblAwardImages (Award_Image,Award_Thumbnail,Award_ID,Uploaded_Date,Current_Image)

VALUES(p_AwardImage, p_AwardThumbnail, p_AwardID, CURRENT_DATE(),p_CurrentImage);

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertAwards` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_InsertAwards`(p_AwardName varchar(100),p_AwardDesc varchar (200),p_KPIID INT,p_TargetID INT,p_AwardManual INT, OUT p_AwardID INT,p_AwardCategoryID INT)
BEGIN





		INSERT INTO tblAwards(Award_Name,Award_Desc,KPIID,Target_Value,Award_Manual,AwardCategoryID)



		VALUES (p_AwardName,p_AwardDesc,p_KPIID,p_TargetID,p_AwardManual,p_AwardCategoryID);

	

	SET p_AwardID = LAST_INSERT_ID();



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertCategory` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_InsertCategory`(p_CategoryName Varchar(100))
BEGIN
IF ( NOT EXISTS(SELECT * FROM tblQuizCategory WHERE CategoryName = p_CategoryName))
	THEN
		INSERT INTO tblQuizCategory (CategoryName)
		VALUES (p_CategoryName);
	ELSE
		CALL DuplicatePRO;
	END IF; 
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertContest` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_InsertContest`(p_ContestName varchar(100),p_FromDate varchar(10), p_ToDate varchar(10), p_KPIID INT, p_RoleID INT, p_SiteID INT, out p_Cid int)
BEGIN

insert into tblContests(ContestName,FromDate,ToDate,KPI_ID )
values(p_ContestName,STR_TO_DATE(p_FromDate, '%m/%d/%Y'),STR_TO_DATE(p_ToDate, '%m/%d/%Y'),p_KPIID);

SET p_Cid = LAST_INSERT_ID();

DELETE FROM tblcontestssites WHERE ContestId = p_Cid;
INSERT INTO tblcontestssites (ContestId,Site_Id)
VALUES (p_Cid,p_SiteId);

DELETE FROM tblcontestsroles WHERE ContestId = p_Cid;
INSERT INTO tblcontestsroles (ContestId,Role_Id)
VALUES (p_Cid, p_RoleID);

IF (p_RoleID <> 0)
THEN

	INSERT INTO contestperformance
	(ContestID, UserID, KPIID, Value, LastUpdated)
		SELECT p_Cid AS ContestID, u.UserID, p_KPIID AS KPIID, 0 AS Value, now() AS LastUpdated 
		FROM 
			tbluser u INNER JOIN tbluserimages i ON u.UserID = i.UserID
		WHERE
			u.Active = 1 AND i.U_Current = 1 AND u.U_RolesID = p_RoleID AND u.U_SiteID = p_SiteId;

ELSEIF (p_RoleID = 0) THEN

	INSERT INTO contestperformance
	(ContestID, UserID, KPIID, Value, LastUpdated)
		SELECT p_Cid AS ContestID, u.UserID, p_KPIID AS KPIID, 0 AS Value, now() AS LastUpdated 
		FROM 
			tbluser u INNER JOIN tbluserimages i ON u.UserID = i.UserID
		WHERE
			u.Active = 1 AND i.U_Current = 1 AND u.U_SiteID = p_SiteId;

END IF;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertContestPerformance` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_InsertContestPerformance`(p_contestid int, p_userid int ,p_kpiid int ,p_score int ,p_importdate varchar(200))
BEGIN
IF ( NOT EXISTS(SELECT * FROM contestperformance WHERE UserID = p_userid AND ContestID = p_contestid AND KPIID = p_kpiid))
THEN
	INSERT into contestperformance(contestperformance.ContestID,contestperformance.UserID,contestperformance.KPIID,contestperformance.`Value`,contestperformance.LastUpdated)
  values(p_contestid,p_userid,p_kpiid,p_score,p_importdate);

ELSEIF(EXISTS(SELECT * FROM contestperformance WHERE UserID = p_userid AND ContestID = p_contestid AND KPIID = p_kpiid))
		THEN

UPDATE contestperformance INNER JOIN tblkpi ON contestperformance.KPIID = tblkpi.KPI_ID
SET contestperformance.`Value` = CASE 
																 WHEN tblkpi.KPI_measure LIKE '%max%'  AND contestperformance.`Value` < p_score 
																			 THEN p_score
																 WHEN tblkpi.KPI_measure NOT LIKE '%max%'
																			 THEN contestperformance.`Value` + p_score
																 ELSE 
																			 contestperformance.`Value`
																 END
WHERE contestperformance.UserID = p_userid AND contestperformance.KPIID = p_kpiid AND contestperformance.ContestID = p_contestid;


END IF;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertContestPosition` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_InsertContestPosition`(p_ContestID INT,p_Award_ID INT, p_Position INT, p_Points INT)
BEGIN

INSERT INTO tblcontestposition(ContestId,Award_ID,Position,Points)
VALUES (p_ContestId,p_Award_ID,p_Position,p_Points);

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertDataElement` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_InsertDataElement`(p_MatchID INT, p_ElementName VARCHAR(250), p_IsPicture INT)
BEGIN

	INSERT INTO tbldataelement (MatchID,ElementName,IsPicture,CreatedDate)
	VALUES (p_MatchID,p_ElementName,p_IsPicture,now());
	
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertDataSet` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_InsertDataSet`(p_DataSetElementsData VARCHAR(500), p_SiteID int, p_MatchID int, p_DataSetImage varchar(100), p_DataSetImageThumbnail varchar(100), out p_Did int)
BEGIN

	INSERT INTO tblmatchdatasets (DataSetElementsData, SiteID, MatchID, CreatedDate, DataSetImage, DataSetImageThumbnail)
	VALUES (p_DataSetElementsData, p_SiteID, p_MatchID, now(), p_DataSetImage, p_DataSetImageThumbnail);
	
SET p_Did = LAST_INSERT_ID();

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertDataSetLevels` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_InsertDataSetLevels`(p_DataSetID INT, p_RoleID INT, p_LevelID INT)
BEGIN
	
	INSERT INTO tblmatchdatasetlevels (DataSetID,RoleID,LevelID)
	VALUES (p_DataSetID, p_RoleID, p_LevelID);
	
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertGame` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_InsertGame`(p_ImageName Varchar(100),p_GameName Varchar(100))
BEGIN

IF ( NOT EXISTS(SELECT * FROM tblQuizGames WHERE GameName = p_GameName))

	THEN

		INSERT INTO tblQuizGames (GameName,CreatedDate,ImageName)

		VALUES (p_GameName,NOW(),p_ImageName);

	ELSE

		CALL DuplicatePRO;

	END IF;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertImage` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_InsertImage`(p_UserID int,p_PlayerImage varchar(100),p_PlayerThumbnail varchar(100))
BEGIN



INSERT INTO tblUserImages(UserID,U_UploadDate,Player_Image,Player_Thumbnail)



VALUES (p_UserID,Curdate(),p_PlayerImage,p_PlayerThumbnail);

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertKPI` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_InsertKPI`(p_Descp Varchar(500),p_KpiName varchar(100),p_KpiMeasure varchar(100), p_KpiType varchar(100),p_KpiCategory varchar(50), p_KpiTipsDESC varchar(500), p_KpiTipsLINK varchar(500),p_TypeLevel varchar(10),p_TypeAward varchar(10),p_TypeContest varchar(10))
BEGIN

INSERT INTO tblKPI(KPI_name,KPI_measure,KPI_type,KPI_Category,KPI_Descp,TipsDESC,TipsLINK,TypeLevel,TypeAward,TypeContest)



VALUES (p_KpiName,p_KpiMeasure,p_KpiType,p_KpiCategory,p_Descp,p_KpiTipsDESC, p_KpiTipsLINK,p_TypeLevel,p_TypeAward,p_TypeContest);



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertLevel` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_InsertLevel`(p_LevelName varchar(100),p_RoleID int, 
p_levelImage varchar(100),p_levelthumbnail varchar(100),  p_LevelPosition int, p_BaseHours int, 				p_Points int,p_CurrentlyIn varchar(45),
													 p_Reach varchar(45), p_Game varchar(50),OUT p_LevelID INT)
BEGIN

IF ( NOT EXISTS(SELECT * FROM tblLevel WHERE Level_Name = p_LevelName AND Role_ID = p_RoleID))
	THEN

insert into tblLevel(Level_Name,Role_ID, Level_Position,BaseHours,Level_date,ImageName,ImageThumbnail,Points,CurrentlyIn,Reach,Game)
values(p_LevelName,p_RoleID,p_LevelPosition,p_BaseHours,CurDate(),p_levelImage,p_levelthumbnail, p_Points,p_CurrentlyIn,p_Reach,p_Game);


SET p_LevelID = LAST_INSERT_ID();
	ELSE
		CALL DuplicatePRO;
	END IF;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertLevelGame` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_InsertLevelGame`(p_GameName varchar(50))
BEGIN

	INSERT INTO tblLevelGame (GameName)

	VALUES (p_GameName);

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertLevelGameDLL` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_InsertLevelGameDLL`(p_GameDropdownName varchar(50),p_GameID INT)
BEGIN

	INSERT INTO tblLevelGameDDL (GameDropdownName,GameID)

	VALUES (p_GameDropdownName,p_GameID);



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertLifeLine` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_InsertLifeLine`(UserID int , QuizID int, DateUsed varchar(50), 
											  ReduceChoices_LifeLine int, ReplaceQuestion_LifeLine int,
											  AddCounter_LifeLine int)
BEGIN
Insert into tbllifelines(UserID,QuizID,DateUsed,ReduceChoices_LifeLine,ReplaceQuestion_LifeLine,AddCounter_LifeLine) 
Values (UserID,QuizID,DateUsed,ReduceChoices_LifeLine,ReplaceQuestion_LifeLine,AddCounter_LifeLine);


END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertMatch` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_InsertMatch`(p_MatchName VARCHAR(250), p_PointsForCompletation INT,
														p_MaxPlaysPerDay INT, p_NoOfDataSet INT,
														p_NoOfRounds INT, p_MatchImage VARCHAR(100),
														p_MatchImageThumbnail VARCHAR(100), p_KPIID int,out p_Mid int)
BEGIN
IF ( NOT EXISTS(SELECT * FROM tblMatch WHERE MatchName = p_MatchName))
	THEN
		INSERT INTO tblmatch (MatchName,PointsForCompletation,MaxPlaysPerDay,NoOfDataSet,NoOfRounds,CreatedDate,MatchImage,MatchImageThumbnail,KPI_ID)
		VALUES (p_MatchName,p_PointsForCompletation,p_MaxPlaysPerDay,p_NoOfDataSet,p_NoOfRounds,NOW(),p_MatchImage,p_MatchImageThumbnail,p_KPIID);
	SET p_Mid = LAST_INSERT_ID();
	ELSE
		CALL DuplicatePRO;
	END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertMatchLevels` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_InsertMatchLevels`(p_MatchID INT, p_RoleID INT, p_LevelID INT)
BEGIN
	
	INSERT INTO tblmatchlevels(MatchID ,RoleID,LevelID)
	VALUES (p_MatchID,p_RoleID,p_LevelID);

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertMatchPlayLog` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_InsertMatchPlayLog`(p_UserID int, p_MatchID int, p_MatchTime varchar(100), p_MatchPlays int)
BEGIN

Insert into tblMatchPlayLog(UserID, MatchID, MatchTime, MatchPlays) Values(p_UserID, p_MatchID, p_MatchTime, p_MatchPlays);

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertMatchScore` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_InsertMatchScore`(p_UserID int, p_MatchID int, p_Points int, p_ElapsedTime int, p_IsCorrect int)
BEGIN

INSERT INTO tblUserMatchPoints(UserID, MatchID, PointsAchieved, ElaspedTime, IsCorrect, MatchTime)
VALUES (p_UserID, p_MatchID, p_Points, p_ElapsedTime, p_IsCorrect, Now());

INSERT INTO tblUserMatchPointsTemperory(UserID, MatchID, PointsAchieved, ElaspedTime, IsCorrect, MatchTime)
VALUES (p_UserID, p_MatchID, p_Points, p_ElapsedTime, p_IsCorrect, Now());


END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertMessage` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_InsertMessage`(p_FromUserID int,p_ToUserID int,p_MessageSubject varchar(100),p_MessageText varchar(500))
BEGIN



INSERT INTO tblMessages(From_UserID,To_UserID,Message_Subject,Message_Text,Sent_Date)

VALUES(p_FromUserID,p_ToUserID,p_MessageSubject,p_MessageText,CURRENT_TIMESTAMP());

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertMessageReply` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_InsertMessageReply`(p_FromUserID int,p_ToUserID int,p_MessageSubject varchar(100),p_MessageText varchar(500),p_RepliedMessageID int)
BEGIN

	

INSERT INTO tblMessages(From_UserID,To_UserID,Message_Subject,Message_Text,Sent_Date,IsRead,IsReply,RepliedMessageID)

VALUES(p_FromUserID,p_ToUserID,p_MessageSubject,p_MessageText,CURRENT_TIMESTAMP(),0,1,p_RepliedMessageID);



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertPerformance` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_InsertPerformance`(p_UserID int,p_CurrentLevel int,p_NextLevel int,p_LastLevel int,p_LevelAchieved int,p_TargetScores int,p_AchievedScores int)
BEGIN



insert into tblLevelPerformance(user_id,current_level,next_level,last_level,level_achieved,target_scores,achieved_scores)



values(p_UserID,p_CurrentLevel,p_NextLevel,p_LastLevel,p_LevelAchieved,p_TargetScores,p_AchievedScores);



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_insertPost` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_insertPost`(p_PostTitle varchar(200),p_PostMessage varchar(5000),p_CreateDate datetime,p_CreatedBy int,p_PostTypeID int,p_RoleID int)
BEGIN

INSERT INTO tblPosts (PostTitle,PostMessage,CreateDate,CreatedBy,PostTypeID,RoleID)

VALUES(p_PostTitle,p_PostMessage,CURRENT_TIMESTAMP(),p_CreatedBy,p_PostTypeID,p_RoleID);

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_insertPostReply` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_insertPostReply`(`p_ReplyMessage` varchar(200),`p_RepliedBy` int,`p_ReplyDate` date,`p_PostID` int)
BEGIN



	INSERT INTO tblPostReplies(ReplyMessage,RepliedBy,ReplyDate,PostID)

  VALUES(p_ReplyMessage,p_RepliedBy,CURRENT_TIMESTAMP(),p_PostID);



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertQuestionLevels` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_InsertQuestionLevels`(p_QuestionID INT, p_RoleID INT, p_LevelID INT)
BEGIN
	


		INSERT INTO tblQuestionLevels (QuestionID,RoleID,LevelID)
		VALUES (p_QuestionID,p_RoleID,p_LevelID);
	

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertQuestions` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_InsertQuestions`(p_QuestionText Varchar(200),p_ShortQuestion varchar(100), p_QuestionExplanation VARCHAR(300), p_Answer1 VarChar(100),p_Answer2 VarChar(100), p_Answer3 VarChar(100), p_Answer4 VarChar(100), p_CorrectAnswer VarChar(100), p_Category INT, p_SiteID INT, p_QuizID int, p_QuestionImage VARCHAR(100), p_QuestionImageThumbnail VarChar(100),out p_Qid int)
BEGIN

INSERT INTO tblQuizQuestions (QuestionText,ShortQuestion,QuestionExplanation,Answer1,Answer2,Answer3,Answer4,CorrectAnswer,Category,SiteID,QuizID,QuestionImage,QuestionImageThumbnail)
VALUES (p_QuestionText,p_ShortQuestion,p_QuestionExplanation,p_Answer1,p_Answer2,p_Answer3,p_Answer4,p_CorrectAnswer,p_Category , p_SiteID,p_QuizID,p_QuestionImage,p_QuestionImageThumbnail);
	

SET p_Qid = LAST_INSERT_ID();
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertQuiz` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_InsertQuiz`(p_QuizName VARCHAR(250), p_NoOfQuestions INT,	p_TimePerQuestion INT, p_TimesPlayablePerDay INT, 
p_TimeBeforePointsDeduction INT, p_PointsPerQuestion INT, p_QuizImage VARCHAR(100),  p_QuizImageThumbnail VARCHAR(100),
p_KPIID int,out p_Qid int)
BEGIN
IF ( NOT EXISTS(SELECT * FROM tblQuiz WHERE QuizName = p_QuizName))
	THEN
		INSERT INTO tblQuiz (QuizName,NoOfQuestions,TimePerQuestion,TimesPlayablePerDay,TimeBeforePointsDeduction,PointsPerQuestion,CreatedDate,QuizImage,QuizImageThumbnail,KPI_ID)
		VALUES (p_QuizName,p_NoOfQuestions,p_TimePerQuestion,p_TimesPlayablePerDay,p_TimeBeforePointsDeduction,p_PointsPerQuestion,NOW(),p_QuizImage,p_QuizImageThumbnail,p_KPIID);
    SET p_Qid = LAST_INSERT_ID();
	ELSE
		CALL DuplicatePRO;
	END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertQuizLevels` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_InsertQuizLevels`(p_QuizID INT, p_RoleID INT, p_LevelID INT)
BEGIN
	
		INSERT INTO tblquizlevels(QuizID ,RoleID,LevelID)
		VALUES (p_QuizID,p_RoleID,p_LevelID);

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertQuizPlayLog` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_InsertQuizPlayLog`(UserID int, QuizID int, QuizTime varchar(100))
BEGIN

Insert into tblQuizPlayLog(UserID, QuizID, QuizTime) Values(UserID, QuizID, QuizTime);

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertQuizResult` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_InsertQuizResult`(p_userid int,p_quizid int,p_total int, p_KPI int)
BEGIN
IF ( NOT EXISTS(SELECT * FROM tblquizresulttotal WHERE UserID = p_userid AND QuizID = p_quizid))
THEN
	INSERT into tblquizresulttotal(UserID,QuizID,Total)
  values(p_userid,p_quizid,p_total);

ELSEIF((SELECT Total FROM tblquizresulttotal WHERE UserID = p_userid AND QuizID = p_quizid)< p_total)
		THEN
UPDATE tblquizresulttotal
SET Total = p_total
WHERE UserID = p_userid AND QuizID = p_quizid;
END IF;




IF ( NOT EXISTS(SELECT * FROM contestperformance WHERE UserID = p_userid AND KPIID = p_KPI ))
THEN
	INSERT into contestperformance(contestperformance.ContestID,contestperformance.UserID,contestperformance.KPIID,contestperformance.`Value`,contestperformance.LastUpdated)
  values(p_contestid,p_userid,p_KPI ,p_total,p_importdate);

ELSEIF(EXISTS(SELECT * FROM contestperformance WHERE UserID = p_userid AND KPIID = p_KPI))
		THEN

UPDATE contestperformance INNER JOIN tblkpi ON contestperformance.KPIID = tblkpi.KPI_ID
SET contestperformance.`Value` = CASE 
																 WHEN tblkpi.KPI_measure LIKE '%max%'  AND contestperformance.`Value` < p_total 
																			 THEN p_total
																 WHEN tblkpi.KPI_measure NOT LIKE '%max%'
																			 THEN contestperformance.`Value` + p_total
																 ELSE 
																			 contestperformance.`Value`
																 END
WHERE contestperformance.UserID = p_userid AND contestperformance.KPIID = p_KPI ;

END IF;


END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertQuizScore` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_InsertQuizScore`(p_UserID int,p_QuizID int,p_QuestionID int,p_Points int,p_ElapsedTime int,p_IsCorrect int)
BEGIN





insert into tblUserQuizPoints(UserID,QuizID, QuestionID,PointsAchieved,ElaspedTime,IsCorrect, QuizTime)

values(p_UserID,p_QuizID,p_QuestionID,p_Points,p_ElapsedTime,p_IsCorrect,Now());







insert into tblUserQuizPointsTemperory(UserID,QuizID, QuestionID,PointsAchieved,ElaspedTime,IsCorrect, QuizTime)

values(p_UserID,p_QuizID,p_QuestionID,p_Points,p_ElapsedTime,p_IsCorrect,Now());



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertRedeemPoints` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_InsertRedeemPoints`(p_UserID int,p_RewardID int,p_Point int)
BEGIN

INSERT INTO tblRedeem(User_ID,Reward_ID,Redeem_Points,Redeem_Date)

VALUES(p_UserID,p_RewardID,p_Point,CURRENT_TIMESTAMP());

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertReward` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_InsertReward`(p_RewardType int,OUT p_RewardID INT,p_RewardDesc varchar(200),p_RewardName varchar(100),p_RewardPoints int(11))
BEGIN



INSERT INTO tblRewards(Reward_Descp,Reward_Name,Reward_Cost,Reward_Type)



VALUES (p_RewardDesc,p_RewardName,p_RewardPoints,p_RewardType);

SET p_RewardID = LAST_INSERT_ID();



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertRewardImage` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_InsertRewardImage`(p_CurrentImage int,p_RewardImage varchar(100),p_RewardThumbnail varchar(100),  p_RewardID int)
BEGIN



	

INSERT INTO tblRewardImages (Reward_Image,Reward_Thumbnail,Reward_ID,Uploaded_Date,Current_Image)

VALUES(p_RewardImage, p_RewardThumbnail, p_RewardID, CURRENT_DATE(),p_CurrentImage);



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertRole` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_InsertRole`(p_RoleName varchar(100))
BEGIN





	INSERT INTO tblRoles(Role_Name,ActiveUpdatedDate)



	VALUES (p_RoleName,Curdate());



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertRound` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_InsertRound`(p_MatchID INT, p_RoundNumber INT, p_RoundName varchar(100), 
														p_NoOfDataSets int, p_TimePerRound int, p_PointsPerRound int, p_ShowHint int)
BEGIN
	
	INSERT INTO tblround (MatchID, RoundNumber,RoundName,NoOfDataSets,TimePerRound,PointsPerRound,CreatedDate, ShowHint)
	VALUES (p_MatchID, p_RoundNumber, p_RoundName,p_NoOfDataSets,p_TimePerRound,p_PointsPerRound,now(),p_ShowHint);

	
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertScore` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_InsertScore`(p_UserID INT,p_KPIID INT,p_Score INT,p_Measure varchar(50),p_EntryDate datetime)
BEGIN

	INSERT INTO tblScores(User_ID,U_Type,Type_ID,Score, Measure,Entry_Date)

	VALUES(p_UserID,'KPI',p_KPIID,p_Score,p_Measure,p_EntryDate);



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertScoreAuto` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_InsertScoreAuto`(p_LevelID int,p_UserID int,p_KPIID int,p_Score int, p_Measure varchar(50),p_EntryDate datetime)
BEGIN
	
IF ( NOT EXISTS(SELECT * FROM tblScores WHERE Type_ID=p_KPIID AND U_Type ='KPI' AND User_ID =p_UserID AND LevelID = p_LevelID))
then
Insert into tblScores(User_ID,U_Type,Type_ID,Score,Entry_Date,LevelID,Measure)
values(p_UserID,'KPI',p_KPIID,p_Score,p_EntryDate,p_LevelID,p_Measure);


Else
IF(p_Measure = 'MAX' OR p_Measure = 'max' OR p_Measure = 'Max')
THEN

SET @var = (Select Score from tblscores WHERE  Type_ID=p_KPIID AND U_Type ='KPI' AND User_ID =p_UserID AND LevelID = p_LevelID);

IF(p_Score > @var)
THEN
Update tblScores
Set Score= p_Score
Where Type_ID=p_KPIID AND U_Type ='KPI' AND User_ID =p_UserID AND LevelID = p_LevelID;
END IF;

ELSE
Update tblScores
Set Score= Score + p_Score
Where Type_ID=p_KPIID AND U_Type ='KPI' AND User_ID =p_UserID AND LevelID = p_LevelID;

END IF;

End IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertScoreAward` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_InsertScoreAward`(p_UserID int,p_KPIID int,p_Score int, p_Measure varchar(50),p_AwardID int)
BEGIN
		
IF ( NOT EXISTS(SELECT * FROM tblUserAwards WHERE award_id = p_AwardID  AND user_id =p_UserID))
then
Insert into tblUserAwards(award_id,user_id,achieved_scores,awarded_date,kpi_id,manual,popup_showed)
values(p_AwardID,p_UserID,p_Score,NOW(),p_KPIID,0,0);


Else
IF(p_Measure = 'MAX' OR p_Measure = 'max' OR p_Measure = 'Max')
THEN

SET @var = (Select tblUserAwards.achieved_score FROM tblUserAwards WHERE award_id = p_AwardID  AND user_id =p_UserID);

IF(p_Score > @var)
THEN
Update tblUserAwards
Set tblUserAwards.achieved_scores= p_Score
Where award_id=p_AwardID  AND user_id =p_UserID;
END IF;

ELSE
Update tblUserAwards
Set tblUserAwards.achieved_scores= tblUserAwards.achieved_scores + p_Score
Where award_id=p_AwardID  AND user_id =p_UserID;
END IF;

End IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertSecurityAnswers` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_InsertSecurityAnswers`(p_UserID int, p_Question int, p_Answer varchar(200), p_Password varchar(50),p_Email varchar(50),p_SecurityType int)
BEGIN

	DECLARE CONTINUE HANDLER FOR SQLEXCEPTION 

    BEGIN

        ROLLBACK;        

    END;



	START TRANSACTION;



		UPDATE tblUser 

		SET tblUser.U_Password = p_Password

		WHERE tblUser.UserID = p_UserID;



			



		IF (p_SecurityType = 1)

		THEN

			UPDATE tblUser 

			SET tblUser.U_Email = p_Email

			WHERE tblUser.UserID = p_UserID;

		ELSE

			

				INSERT INTO tblSecurityAnswers

				(UserID,Question_ID,Answer)

				VALUES

				(p_UserID,p_Question,p_Answer);

			

							

		END IF;

	

	COMMIT;

	



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertSecurityAnswersTemp` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_InsertSecurityAnswersTemp`(p_UserID int, p_Question int, p_Answer varchar(200))
BEGIN
	


			

			IF ( NOT EXISTS (SELECT * FROM tblSecurityAnswers WHERE UserID = p_UserID and Question_ID = p_Question))
			THEN

				INSERT INTO tblSecurityAnswers
				(UserID,Question_ID,Answer)
				VALUES
				(p_UserID,p_Question,p_Answer);

			ELSE
				UPDATE tblSecurityAnswers
				SET 	Answer = p_Answer
				WHERE UserID =  p_UserID and Question_ID = p_Question;
			END IF;
							
		
	
	
	

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertSite` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_InsertSite`(p_SiteName VARCHAR(50),p_SiteType VARCHAR(50), p_SiteAddress VARCHAR(150))
BEGIN

	IF ( NOT EXISTS(SELECT * FROM tblSite WHERE site_name = p_SiteName AND site_type = p_SiteType))

	THEN

		INSERT INTO tblSite (site_name,site_type,site_address)

		VALUES (p_SiteName,p_SiteType,p_SiteAddress);

	ELSE

		CALL DuplicatePRO;

	END IF;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertTarget` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_InsertTarget`(p_TargetValue int,p_KpiID int,p_LevelID int,p_RoleID int, p_Description varchar(500),p_Points int,p_Order INT)
BEGIN







IF (SELECT Target_id FROM tblTarget WHERE  Target_Value=p_TargetValue  AND Role_ID=p_RoleID AND KPI_ID=p_KpiID AND Level_ID=p_LevelID) IS NULL THEN



INSERT INTO tblTarget(Target_Value,KPI_ID,Level_ID,Role_ID,Target_Desc,Points,Target_Order)



VALUES(p_TargetValue,p_KpiID,p_LevelID,p_RoleID,p_Description,p_Points,p_Order);

	

END IF;







END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertUser` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_InsertUser`(p_CurrentLevel int,p_NextLevel int,p_LastLevel int,p_LevelAchieved int, p_U_Name varchar(50) , p_U_EmpID varchar(200) , p_U_LastName varchar(50) , p_U_NickName varchar(50) , p_U_Password varchar(50) , p_U_Email varchar(50) , p_U_SiteID INT , p_U_SysRole varchar(50), p_U_RolesID INT , p_Active tinyint(1), p_U_FirstName varchar(50),p_ManagerID INT)
BEGIN

 



DECLARE CONTINUE HANDLER FOR SQLEXCEPTION 

    BEGIN

        ROLLBACK;

				CALL DuplicatePro;

				

    END;



	START TRANSACTION;

	insert into tblUser(U_EmpID,U_Name,U_LastName,U_NickName,U_Password,U_Email,U_SiteID,U_SysRole,U_RolesID,Active,U_FirstName,ManagerID)



	values(p_U_EmpID,p_U_Name,p_U_LastName,p_U_NickName,NULL,p_U_Email,p_U_SiteID,p_U_SysRole,p_U_RolesID,p_Active,p_U_FirstName,p_ManagerID);

	IF(LAST_INSERT_ID() <> 0)

	then

		insert into tblLevelPerformance(user_id,current_level,next_level,last_level,level_achieved,target_scores,achieved_scores)



		values(LAST_INSERT_ID(),p_CurrentLevel,p_NextLevel,p_LastLevel,p_LevelAchieved,(Select IFNULL(Sum(Target_Value),'0') from tblTarget

		where Role_ID =p_U_RolesID AND Level_ID=p_CurrentLevel),0);

	End if;

COMMIT;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_InsertUserAwards` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_InsertUserAwards`(IN `p_user_id` int,IN `p_award_id` int,IN `p_manual` tinyint,IN `p_awardedBy` int)
BEGIN

	

			INSERT INTO tblUserAwards ( user_id,award_id,awarded_date,manual,awardedBy)

      VALUES (p_user_id,p_award_id,NOW(),p_manual,p_awardedBy);

	

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_instertRepliedLike` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_instertRepliedLike`(p_LikedBy int, p_LikeID int, p_PostID int)
BEGIN

	INSERT INTO tblPostRepliedLikes (RepliedLikeDate,LikedBy,LikeID,PostID)

Values(CURRENT_DATE(),p_LikedBy,p_LikeID,p_PostID);



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_levels_UpdateTargets` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_levels_UpdateTargets`(p_TargetID INT,p_TargetValue int,p_KpiID INT,p_Points int,p_Order INT)
BEGIN

	

UPDATE tblTarget

SET Target_Value = p_TargetValue,

    KPI_ID = p_KpiID,

		Points = p_Points,	

		Target_Order = p_Order

WHERE Target_ID = p_TargetID ;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_level_UpdateLevelInfo` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_level_UpdateLevelInfo`(p_BaseHours int, p_Points int, p_LevelID int,

  p_LevelName varchar(50), p_CurrentlyIn varchar(45),

 p_Reach varchar(45), p_Game varchar(50),p_levelImage varchar(100),p_levelthumbnail varchar(100))
BEGIN



UPDATE tblLevel 

SET BaseHours = p_BaseHours,

		Level_Name = p_LevelName,

		Points = p_Points,

		CurrentlyIn = p_CurrentlyIn,

		Reach = p_Reach,

		Game = p_Game,
    
    ImageName =p_levelImage,
    
    ImageThumbnail =p_levelthumbnail



WHERE Level_ID = p_LevelID;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_MatchLevels` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_MatchLevels`(p_MatchID INT)
BEGIN
	SELECT
	tblRoles.Role_ID,
	tblRoles.Role_Name,
	tblLevel.Level_ID,
	tblLevel.Level_Name,
	tblLevel.Level_Position,
	(Select 'yes' from tblmatchlevels where tblmatchlevels.LevelID=tblLevel.Level_ID and MatchID =p_MatchID) as Allow
	FROM
	tblRoles
	INNER JOIN tblLevel ON tblLevel.Role_ID = tblRoles.Role_ID
	WHERE
	tblRoles.Active = 1 and tblLevel.Active=1
	ORDER BY tblRoles.Role_ID,tblLevel.Level_Position;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_PasswordRequest` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_PasswordRequest`(p_UserNameID varchar(50))
BEGIN
UPDATE tblUser
SET U_Password = NULL
Where U_Name = p_UserNameID;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_PerformanceUdpate` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_PerformanceUdpate`()
BEGIN
	
	IF ( NOT EXISTS(SELECT * FROM temp_KPIdata))
	THEN
	CREATE Table temp_KPIdata(
				 EMP_ID INT NOT NULL,
				 DateTaken DATETIME,
				 KPI_ID INT,
				 PerformanceValue INT,
				 Type VARCHAR(200)
				 );
	ELSE
			CALL DuplicatePRO;

	END IF;

	
	

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_Player_GetAward` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_Player_GetAward`(p_UserID INT)
BEGIN



	



IF EXISTS(SELECT * from tblUserAwards WHERE tblUserAwards.achieved_scores = tblUserAwards.target_scores and target_scores>=0 and awarded_date is null and tblUserAwards.user_id=p_UserID)

then

SET SQL_SAFE_UPDATES=0;

   update tblUserAwards

   set awarded_date=NOW()

   Where tblUserAwards.achieved_scores = tblUserAwards.target_scores  and tblUserAwards.user_id=p_UserID;

SELECT tblUserAwards.achieved_scores,tblUserAwards.target_scores,

				tblUserAwards.awarded_date,tblUserAwards.awardedBy,tblUserAwards.manual,

				tblUserAwards.userAwardsId,tblUserAwards.user_id,

				tblAwards.Award_Name,

				tblAwards.Award_Desc,tblAwards.Award_ID,

				tblAwards.AwardCategoryID,

(SELECT Award_Image FROM tblAwardImages WHERE Current_Image = 1 AND Active = 1 AND tblAwardImages.Award_ID = tblAwards.Award_ID) as Award_Image

	FROM tblUserAwards 

	INNER JOIN tblAwards ON 

	tblUserAwards.award_id = tblAwards.Award_ID

WHERE tblUserAwards.user_id = p_UserID;



else



SELECT tblUserAwards.achieved_scores,tblUserAwards.target_scores,

				tblUserAwards.awarded_date,tblUserAwards.awardedBy,tblUserAwards.manual,

				tblUserAwards.userAwardsId,tblUserAwards.user_id,

				tblAwards.Award_Name,

				tblAwards.Award_Desc,tblAwards.Award_ID,

				tblAwards.AwardCategoryID,

(SELECT Award_Image FROM tblAwardImages WHERE Current_Image = 1 AND Active = 1 AND tblAwardImages.Award_ID = tblAwards.Award_ID) as Award_Image

	FROM tblUserAwards 

	INNER JOIN tblAwards ON 

	tblUserAwards.award_id = tblAwards.Award_ID

WHERE tblUserAwards.user_id = p_UserID;  

END IF ;

End ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_Player_GetContest` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_Player_GetContest`()
BEGIN



SELECT   tblUser.UserID,

				 Contest_ID,

				 Contest_Name,     

				 Contest_Graphics,

				 Contest_Graphics_Ext,

				 Contest_StartDate,

				 Contest_EndDate,			 

				 tblContest.Active,

				 tblContest.Contest_Descp,

				 tblContest.Role_ID

 FROM tblContest 

INNER JOIN tblUser ON

tblContest.Role_ID = tblUser.U_RolesID

WHERE  tblContest.Active = 1

  and (CURDATE() BETWEEN  tblContest.Contest_StartDate and tblContest.Contest_EndDate) and tblContest.Role_ID <> ''



UNION

SELECT   tblUser.UserID,

				 Contest_ID,

				 Contest_Name,     

				 Contest_Graphics,

				 Contest_Graphics_Ext,

				 Contest_StartDate,

				 Contest_EndDate,			 

				 tblContest.Active,

				 tblContest.Contest_Descp,

				 tblContest.Role_ID

 FROM tblContest

INNER JOIN tblUser ON

tblContest.Site_ID = tblUser.U_SiteID

WHERE tblContest.Active = 1

 and (CURDATE() BETWEEN  tblContest.Contest_StartDate and tblContest.Contest_EndDate) and tblContest.Role_ID <> '';

 



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_PopupShowed` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_PopupShowed`(p_UserID INT,p_LevelID INT)
BEGIN



DECLARE CONTINUE HANDLER FOR SQLEXCEPTION 

    BEGIN

        ROLLBACK;        

    END;



	START TRANSACTION;

	UPDATE tblLevelPerformance 

	SET popup_showed = 1,

			level_achieved = 1 

	WHERE user_id = p_UserID 

	AND current_level = p_LevelID;



	INSERT INTO tblLevelPerformance 

	(user_id,current_level,next_level,last_level,level_achieved,target_scores,achieved_scores)



	values(p_UserID,(SELECT Level_ID FROM tblLevel 

														WHERE  tblLevel.Level_Position = 

																						(SELECT (levels.Level_Position + 1) 

																							FROM tblLevel levels 

																							WHERE levels.Level_ID =p_LevelID 

																						) AND tblLevel.Role_ID = (SELECT U_RolesID FROM tblUser WHERE UserID = p_UserID)

														),(SELECT Level_ID FROM tblLevel 

														WHERE  tblLevel.Level_Position = 

																						(SELECT (levels.Level_Position + 2) 

																							FROM tblLevel levels 

																							WHERE levels.Level_ID =p_LevelID 

																						) AND tblLevel.Role_ID = (SELECT U_RolesID FROM tblUser WHERE UserID = p_UserID)

														),p_LevelID,0,0,0);



	UPDATE tblUser SET U_Points = U_Points + (SELECT Points FROM tblLevel WHERE Level_ID = p_LevelID AND Active = 1 )

	WHERE UserID = p_UserID;





COMMIT;

	



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_QuizData` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_QuizData`()
BEGIN

Select *from tblQuizQuestions INNER JOIN tblLevel ON

tblQuizQuestions.LevelID = tblLevel.Level_ID

INNER JOIN tblRoles ON

tblQuizQuestions.RoleID = tblRoles.Role_ID;

Select * from tblQuizGames;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_QuizLevels` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_QuizLevels`(p_QuizID INT)
BEGIN
	SELECT
tblRoles.Role_ID,
tblRoles.Role_Name,
tblLevel.Level_ID,
tblLevel.Level_Name,
tblLevel.Level_Position,

(Select 'yes' from tblquizlevels where tblquizlevels.LevelID=tblLevel.Level_ID and QuizID =p_QuizID) as Allow
FROM
tblRoles
INNER JOIN tblLevel ON tblLevel.Role_ID = tblRoles.Role_ID
WHERE
tblRoles.Active = 1 and tblLevel.Active=1
ORDER BY tblRoles.Role_ID,tblLevel.Level_Position;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_ReportSumPoints` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_ReportSumPoints`(p_UserID int,p_Points int)
BEGIN



Update tblUser

set U_Points = p_Points

Where tblUser.UserID = p_UserID;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_RolesLevels` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_RolesLevels`(p_QuestionID int)
BEGIN
	SELECT
tblRoles.Role_ID,
tblRoles.Role_Name,
tblLevel.Level_ID,
tblLevel.Level_Name,
tblLevel.Level_Position,

(Select 'yes' from tblQuestionLevels where tblQuestionLevels.LevelID=tblLevel.Level_ID and QuestionID=p_QuestionID ) as Allow
FROM
tblRoles
INNER JOIN tblLevel ON tblLevel.Role_ID = tblRoles.Role_ID
WHERE
tblRoles.Active = 1 and tblLevel.Active=1
ORDER BY tblRoles.Role_ID,tblLevel.Level_Position;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_RolesLevelsMatchDataSet` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_RolesLevelsMatchDataSet`(p_DataSetID int)
BEGIN
	SELECT
		tblRoles.Role_ID,
		tblRoles.Role_Name,
		tblLevel.Level_ID,
		tblLevel.Level_Name,
		tblLevel.Level_Position,
		(SELECT 'yes' FROM tblMatchDataSetLevels where tblMatchDataSetLevels.LevelID = tblLevel.Level_ID and DataSetID = p_DataSetID ) as Allow
	FROM
		tblRoles
	INNER JOIN tblLevel ON tblLevel.Role_ID = tblRoles.Role_ID
	WHERE
		tblRoles.Active = 1 and tblLevel.Active=1
	ORDER BY tblRoles.Role_ID, tblLevel.Level_Position;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_SetAwardsByContest` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_SetAwardsByContest`()
BEGIN

	DECLARE v_finished INTEGER DEFAULT 0;
	DECLARE v_contestid INTEGER DEFAULT 0;	
	
	DROP TABLE IF EXISTS ScoresTmp;
	DROP TABLE IF EXISTS xTmp;
	DROP TABLE IF EXISTS yTmp;
    DROP TABLE IF EXISTS uTmp;
    
    
	CREATE TEMPORARY TABLE ScoresTmp (User_ID INT NOT NULL, U_Name VARCHAR(255) NOT NULL, Player_Thumbnail VARCHAR(255) NOT NULL, Role_Name VARCHAR(255) NOT NULL, Site_Name VARCHAR(255) NOT NULL, ContestID INT NOT NULL, ContestName VARCHAR(255) NOT NULL, Score INT NOT NULL, KPI_measure VARCHAR(255) NOT NULL);

	INSERT INTO ScoresTmp (User_ID, U_Name, Player_Thumbnail, Role_Name, Site_Name, ContestID, ContestName, Score, KPI_measure) 
	SELECT 
		t.UserID AS User_ID,
		CONCAT(u.U_FirstName,' ',u.U_LastName) AS U_Name,
		i.Player_Thumbnail,
		r.Role_Name,
		s.site_name,
		t.ContestID,
		c.ContestName,
		SUM(t.value) AS Score,
		k.KPI_measure
	FROM 
		contestperformance t
		INNER JOIN tblcontests c ON t.ContestID = c.ContestId
		INNER JOIN tblkpi k ON c.KPI_ID = k.KPI_ID
		INNER JOIN tbluser u ON t.UserID = u.UserID
		INNER JOIN tbluserimages i ON u.UserID = i.UserID AND i.U_Current = 1
		INNER JOIN tblsite s ON u.U_SiteID = s.site_id 
		INNER JOIN tblroles r ON u.U_RolesID = r.Role_ID
	GROUP BY
		t.ContestID, t.UserID;  

	CREATE TEMPORARY TABLE xTmp (User_ID INT NOT NULL,  U_Name VARCHAR(255) NOT NULL, Player_Thumbnail VARCHAR(255) NOT NULL, Role_Name VARCHAR(255) NOT NULL, Site_Name VARCHAR(255) NOT NULL, ContestID INT NOT NULL, ContestName VARCHAR(255) NOT NULL, Score INT NOT NULL, KPI_measure VARCHAR(255) NOT NULL, position INT NOT NULL);

	INSERT INTO xTmp (User_ID, U_Name, Player_Thumbnail, Role_Name, Site_Name, ContestID, ContestName, Score, KPI_measure, position) 
	SELECT 
		ScoresTmp.User_ID,
		ScoresTmp.U_Name,
		ScoresTmp.Player_Thumbnail,
		ScoresTmp.Role_Name,
		ScoresTmp.Site_Name,
		ScoresTmp.ContestID,
		ScoresTmp.ContestName,
		ScoresTmp.Score,
		ScoresTmp.KPI_measure,
		( 
			CASE ScoresTmp.ContestName 
				WHEN @curType 
				THEN @curRow := @curRow + 1 
				ELSE @curRow := 1 AND @curType := ScoresTmp.ContestName 
			END
		) + 1 AS position		
	FROM        
		ScoresTmp,
		(SELECT @curRow := 0, @curType := '') r
	ORDER BY ScoresTmp.ContestName ASC, ScoresTmp.Score DESC; 

	CREATE TEMPORARY TABLE yTmp (User_ID INT NOT NULL,  U_Name VARCHAR(255) NOT NULL, Player_Thumbnail VARCHAR(255) NOT NULL, Role_Name VARCHAR(255) NOT NULL, Site_Name VARCHAR(255) NOT NULL, ContestID INT NOT NULL, ContestName VARCHAR(255) NOT NULL, Score INT NOT NULL, KPI_measure VARCHAR(255) NOT NULL, position INT NOT NULL);

	INSERT INTO yTmp (User_ID, U_Name, Player_Thumbnail, Role_Name, Site_Name, ContestID, ContestName, Score, KPI_measure, position) 
	SELECT * FROM xTmp; 

	BEGIN		

		DECLARE contest_cursor CURSOR FOR SELECT ContestID FROM xTmp GROUP BY ContestID;
		 
		DECLARE CONTINUE HANDLER FOR NOT FOUND SET v_finished = 1;
		 
		OPEN contest_cursor;
		 
		get_contestid: LOOP
		 
		FETCH contest_cursor INTO v_contestid;
		 
			IF v_finished = 1 THEN 
				LEAVE get_contestid;
			END IF;
			 
			UPDATE yTmp baseTable
				INNER JOIN
				(
				SELECT 
					User_ID,
					U_Name,
					Player_Thumbnail,
					Role_Name,
					Site_Name,
					ContestID,
					ContestName,
					@rnk:=IF(@preval <=> Score, @rnk, @row + 1) AS position,
					@row:= @row+1 AS rnk,
					@preval:=Score as Score
				FROM xTmp
				JOIN (SELECT @rnk := 0, @preval :=null, @row := 0) r
				WHERE ContestID = v_contestid
				ORDER BY Score DESC
				) b ON baseTable.User_ID = b.User_ID
				SET
				baseTable.position = b.position
				WHERE baseTable.ContestID = v_contestid;
		 
		END LOOP get_contestid;
		 
		CLOSE contest_cursor;

	END;	

	BLOCK1: BEGIN
		DECLARE v_finished_a INTEGER DEFAULT 0;
		DECLARE v_contestid_a INTEGER DEFAULT 0;

		DECLARE contestawards_cursor CURSOR FOR 
			SELECT ContestID FROM tblcontests WHERE ToDate = DATE_FORMAT(NOW(),'%Y-%m-%d') ORDER BY ToDate ASC;
		DECLARE CONTINUE HANDLER FOR NOT FOUND 
			SET v_finished_a := 1;
		 
		OPEN contestawards_cursor;
		get_contestid_a: LOOP

			FETCH contestawards_cursor INTO v_contestid_a;
            
            IF v_finished_a  = 1 THEN
				LEAVE get_contestid_a;
			END IF;

			 INSERT INTO tbllog (contestid,description,lastrun) values (v_contestid_a, 'ContestLoop',now());

			BLOCK2: BEGIN
			
				DECLARE v_award_done INTEGER DEFAULT 0;
				DECLARE v_award INTEGER DEFAULT 0;
				DECLARE v_position INTEGER DEFAULT 0;
				DECLARE v_points INTEGER DEFAULT 0;

				DECLARE curAward CURSOR FOR 
					SELECT Award_ID, Position + 1 AS Position, Points FROM tblcontestposition WHERE ContestID = v_contestid_a;
				DECLARE CONTINUE HANDLER FOR NOT FOUND 
					SET v_award_done = 1;

				OPEN curAward; 
				cur_award_loop: LOOP

					FETCH curAward INTO v_award, v_position, v_points;
					
					IF v_award_done = 1 THEN
						LEAVE cur_award_loop;
					END IF; 
							
					 INSERT INTO tbllog (contestid,description,lastrun) values (v_contestid_a, CONCAT('AwardLoop', v_award),now());

					INSERT INTO tblUserAwards (user_id, award_id, awarded_date, manual, awardedBy)
					SELECT 
						yTmp.User_ID, v_award AS Award_ID, now() AS awarded_date, 1 AS manual, 1 AS awardedBy
					FROM yTmp 
					WHERE
						yTmp.ContestID = v_contestid_a AND yTmp.position = v_position
					ORDER BY 
						yTmp.position;

					BLOCK3: BEGIN

						DECLARE v_points_done INTEGER DEFAULT 0;
						DECLARE v_userid INTEGER DEFAULT 0;						

						DECLARE curPoints CURSOR FOR 
							SELECT yTmp.User_ID FROM yTmp WHERE yTmp.ContestID = v_contestid_a AND yTmp.position = v_position ORDER BY yTmp.position;
						DECLARE CONTINUE HANDLER FOR NOT FOUND 
							SET v_points_done = 1;

						OPEN curPoints; 
						cur_points_loop: LOOP

							FETCH curPoints INTO v_userid;
							
							IF v_points_done = 1 THEN
								LEAVE cur_points_loop;
							END IF; 
							
							 INSERT INTO tbllog (contestid,description,lastrun) values (v_contestid_a, CONCAT('UserID', v_userid),now());

							CREATE TEMPORARY TABLE uTmp (User_ID INT NOT NULL, U_Points INT NOT NULL);
							INSERT INTO uTmp (User_ID, U_Points)					
							SELECT UserID,  (usr.U_Points + v_points) FROM tblUser usr WHERE usr.UserID = v_userid;                    
							
							UPDATE tblUser myUsr SET myUsr.U_Points = (SELECT usrTemp.U_Points FROM uTmp usrTemp WHERE usrTemp.User_ID = v_userid) WHERE myUsr.UserID = v_userid;
							
							DROP TABLE uTmp;

						END LOOP cur_points_loop;	

						CLOSE curPoints;

					END BLOCK3;	

			END LOOP cur_award_loop;

			CLOSE curAward;

			END BLOCK2;	
	
		END LOOP get_contestid_a;

		CLOSE contestawards_cursor;

	END BLOCK1;


	DROP TABLE yTmp;

	DROP TABLE xTmp;

	DROP TABLE ScoresTmp;

 END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_TeamPerformance` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_TeamPerformance`(p_ManagerID INT)
BEGIN

	SELECT *,(CASE WHEN a.Likelihood < 80 THEN 'red' WHEN a.Likelihood < 90 AND a.Likelihood > 80 THEN 'Yellow' WHEN a.Likelihood > 90 AND a.Likelihood < 100 THEN 'Green' WHEN a.Likelihood = 100 THEN 'blue' WHEN a.Likelihood > 100 THEN 'Green' END) AS PlayerStatus FROM

	(SELECT vscore.*,CONCAT(tblUser.U_FirstName,' ',tblUser.U_LastName)  AS PlayerName,tblRoles.Role_Name,tblLevel.Level_Position,tblUserImages.Player_Thumbnail,tbluser.U_Points,

(select (IFNULL(sum(v_UserLevelScores.current_percentage),0)) / Count(*) from v_UserLevelScores where v_UserLevelScores.Level_ID=vscore.Level_ID and v_UserLevelScores.UserID=vscore.UserID ) AS Percentage

 

,BaseHours,



 (( (((BaseHours-Worked_Hour)/BaseHours)*100)/(100-   (select (IFNULL(sum(a.current_percentage),0)) / Count(*) from v_UserLevelScores a where a.Level_ID=vscore.Level_ID and a.UserID=vscore.UserID ))) *100) as Likelihood

   ,(BaseHours-Worked_Hour) as remainingHours



FROM v_UserLevelScores vscore



INNER JOIN tblLevelPerformance ON vscore.Level_ID = tblLevelPerformance.current_level AND vscore.UserID = tblLevelPerformance.user_id

INNER JOIN tblUser ON vscore.UserID = tblUser.UserID

LEFT JOIN tblUserImages ON vscore.UserID = tblUserImages.UserID AND tblUserImages.U_Current = 1

INNER JOIN tblRoles ON

vscore.Role_ID = tblRoles.Role_ID 

INNER JOIN tblLevel ON vscore.Level_ID = tblLevel.Level_ID

WHERE tblLevelPerformance.level_achieved = 0 AND (Select tblUser.Active from tblUser Where tblUser.UserID = vscore.UserID) = 1 AND (SELECT tblUser.ManagerID  FROM tblUser WHERE tblUser.UserID = vscore.UserID) = p_ManagerID

GROUP BY vscore.UserID,vscore.Level_ID ORDER BY Likelihood) a;









END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_UpdateAward` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_UpdateAward`(p_ID int,p_CurrentImage int,p_AwardID INT,p_AwardName VARCHAR (100),p_AwardDesc VARCHAR (200),p_KPIID INT,p_TargetID INT,p_AwardManual INT,p_Active TINYINT(4),p_AwardCategoryID INT)
BEGIN

UPDATE tblAwards

SET Award_Name = p_AwardName,

	Award_Desc = p_AwardDesc,	

	KPIID = p_KPIID,

	Target_Value = p_TargetID,

	Award_Manual=p_AwardManual,

    Active = p_Active,

		AwardCategoryID = p_AwardCategoryID

WHERE Award_ID = p_AwardID ;



UPDATE tblAwardImages 

SET Current_Image = p_CurrentImage 

WHERE ID = p_ID;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_UpdateCategory` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_UpdateCategory`(p_CategoryName varchar(100),p_CategoryID int)
BEGIN
Update tblQuizCategory
set CategoryName=p_CategoryName
where CategoryID=p_CategoryID;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_UpdateContest` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_UpdateContest`(p_ContestID INT,p_ContestName VARCHAR (100),p_FromDate varchar(10),p_ToDate varchar(10), p_KPIID INT, p_RoleID INT, p_SiteID INT)
BEGIN

UPDATE tblContests
SET ContestName = p_ContestName,
FromDate = STR_TO_DATE(p_FromDate, '%m/%d/%Y'),
ToDate= STR_TO_DATE(p_ToDate, '%m/%d/%Y'),
KPI_ID = p_KPIID
WHERE ContestId = p_ContestID;

DELETE FROM tblcontestssites
WHERE ContestID = p_ContestID;

INSERT INTO tblcontestssites(ContestId,Site_Id)
VALUES (p_ContestID,p_SiteId);

DELETE FROM tblcontestsroles
WHERE ContestID = p_ContestID;

INSERT INTO tblcontestsroles(ContestId,Role_Id)
VALUES (p_ContestID, p_RoleID);


END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_UpdateDataElement` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_UpdateDataElement`(p_ElementID INT, p_MatchID INT, p_ElementName VARCHAR(250), p_IsPicture INT)
BEGIN

UPDATE tbldataelement
SET MatchID = p_MatchID,
	ElementName = p_ElementName,
	IsPicture = p_IsPicture
WHERE ElementID = p_ElementID;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_UpdateDataSet` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_UpdateDataSet`(p_DataSetID int, p_DataSetElementsData VARCHAR(500), p_SiteID int, p_MatchID int, p_DataSetImage varchar(100), p_DataSetImageThumbnail varchar(100))
BEGIN

UPDATE tblmatchdatasets
SET
	DataSetID = p_DataSetID, 
	DataSetElementsData = p_DataSetElementsData,
	SiteID = p_SiteID,
	MatchID = p_MatchID,
	DataSetImage = p_DataSetImage,
	DataSetImageThumbnail = p_DataSetImageThumbnail
WHERE DataSetID = p_DataSetID;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_UpdateGame` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_UpdateGame`(p_ImageName Varchar(100),p_GameID int,p_GameName Varchar(100))
BEGIN

Update tblQuizGames

Set GameName = p_GameName,

ImageName=p_ImageName

Where Gameid = p_GameID;





END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_UpdateImage` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_UpdateImage`(p_Current TinyInt(4),p_UserIDImage int(11),p_Active TINYINT(4))
BEGIN

UPDATE tblUserImages

SET 

    Active = p_Active,

	U_Current=p_Current



WHERE U_UserIDImage = p_UserIDImage ;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_UpdateKPI` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_UpdateKPI`(p_Descp Varchar(500),p_KpiID INT,p_KpiName VARCHAR(100),p_KpiMeasure VARCHAR(100),p_KpiType VARCHAR(100), p_Active TINYINT(4),p_KpiCategory varchar(50), p_KpiTipsDESC varchar(500), p_KpiTipsLINK varchar(500),p_TypeLevel varchar(10),p_TypeAward varchar(10),p_TypeContest varchar(10))
BEGIN

UPDATE tblKPI 

SET KPI_name = p_KpiName,

		KPI_measure = p_KpiMeasure, 

		KPI_type = p_KpiType,

		Active = p_Active,

		KPI_Category = p_KpiCategory,

		KPI_Descp=p_Descp,

		TipsDESC = p_KpiTipsDESC,
		
		TipsLINK = p_KpiTipsLink,

    TypeLevel = p_TypeLevel ,

    TypeAward = p_TypeAward,

    TypeContest = p_TypeContest



WHERE KPI_ID = p_KpiID;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_UpdateLevel` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_UpdateLevel`(p_LevelID INT,p_LevelName VARCHAR(100),p_RoleID INT,p_Active TINYINT(4), p_LevelPosition int, p_BaseHours int,  p_Dimension_top int, p_Dimension_left int,p_CurrentlyIn varchar(45),p_Reach varchar(45), p_Country varchar(50))
BEGIN



DECLARE CONTINUE HANDLER FOR SQLEXCEPTION 

    BEGIN

        ROLLBACK;        

    END;



	START TRANSACTION;



UPDATE tblLevel 

SET Level_Name = p_LevelName,

		Role_ID = p_RoleID,

		Level_Position = p_LevelPosition,

		Active = p_Active,

    BaseHours = p_BaseHours,

		Dimension_top = p_Dimension_top,

		Dimension_left = p_Dimension_left,

		CurrentlyIn = p_CurrentlyIn,

		Reach = p_Reach,

		Country = p_Country

WHERE Level_ID =p_LevelID;





COMMIT;

		

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_UpdateLevelGame` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_UpdateLevelGame`(p_GameName varchar(50),p_Active INT,p_GameID INT)
BEGIN

	UPDATE tblLevelGame 

	SET GameName = p_GameName,

			Active = p_Active

	WHERE GameID = p_GameID;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_UpdateLevelGameDDL` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_UpdateLevelGameDDL`(p_GameDropdownName varchar(50),p_GameID INT, p_Active INT, p_GameDropdownID INT)
BEGIN

	UPDATE tblLevelGameDDL 

	SET GameDropdownName = p_GameDropdownName,

			GameID = p_GameID,

			Active = p_Active

	WHERE GameDropdownID = p_GameDropdownID;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_UpdateLevelperformance` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_UpdateLevelperformance`(p_UserID INT,p_LevelID INT)
BEGIN

UPDATE tblLevelPerformance 
	SET level_achieved = 1 
	WHERE user_id = p_UserID 
	AND current_level = p_LevelID;

IF ( NOT EXISTS(SELECT * FROM tblLevelPerformance WHERE tblLevelPerformance.user_id = p_UserID and 
																tblLevelPerformance.current_level=(SELECT Level_ID FROM tblLevel 
																WHERE  tblLevel.Level_Position = 
																						(SELECT (levels.Level_Position + 1) 
																							FROM tblLevel levels 
																							WHERE levels.Level_ID =p_LevelID 
																						) AND tblLevel.Role_ID = (SELECT U_RolesID FROM tblUser WHERE UserID = p_UserID)
																)))
	THEN
	INSERT INTO tblLevelPerformance 
	(user_id,current_level,next_level,last_level,level_achieved,target_scores,achieved_scores)

	values(p_UserID,(SELECT Level_ID FROM tblLevel 
														WHERE  tblLevel.Level_Position = 
																						(SELECT (levels.Level_Position + 1) 
																							FROM tblLevel levels 
																							WHERE levels.Level_ID =p_LevelID 
																						) AND tblLevel.Role_ID = (SELECT U_RolesID FROM tblUser WHERE UserID = p_UserID)
														),(SELECT Level_ID FROM tblLevel 
														WHERE  tblLevel.Level_Position = 
																						(SELECT (levels.Level_Position + 2) 
																							FROM tblLevel levels 
																							WHERE levels.Level_ID =p_LevelID 
																						) AND tblLevel.Role_ID = (SELECT U_RolesID FROM tblUser WHERE UserID = p_UserID)
														),p_LevelID,0,0,0);

	UPDATE tblUser SET U_Points = U_Points + (SELECT Points FROM tblLevel WHERE Level_ID = p_LevelID AND Active = 1 )
	WHERE UserID = p_UserID;

	END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_UpdateLevelperformance_PopupShowed` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_UpdateLevelperformance_PopupShowed`(p_UserID INT,p_LevelID INT)
BEGIN

UPDATE tblLevelPerformance 
	SET popup_showed = 1
	WHERE user_id = p_UserID 
	AND current_level = p_LevelID;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_UpdateLevelPosition` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_UpdateLevelPosition`(p_xml VARCHAR(1000))
BEGIN



DECLARE i INT DEFAULT 1;

DECLARE xml VARCHAR(1000);

SET xml = p_xml;



WHILE i < LENGTH(xml)

DO

UPDATE tblLevel

SET Level_Position = (ExtractValue(xml, '//levelposition[$i]'))

WHERE Level_ID  = (ExtractValue(xml, '//levelid[$i]'));



SET i = i + 1 ;

 END WHILE;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_UpdateLoginTime` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_UpdateLoginTime`(p_userid int)
BEGIN

update tblUser

set LastLogin = Now()

Where UserID =p_userid;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_UpdateMatch` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_UpdateMatch`(p_MatchID INT, p_MatchName varchar(250), p_PointsForCompletation int(11),
													p_MaxPlaysPerDay int(11), p_NoOfDataSet int,
													p_NoOfRounds int, p_MatchImage varchar(100),
													p_MatchImageThumbnail varchar(100), p_KPIID INT)
BEGIN
UPDATE tblmatch
SET MatchName = p_MatchName,
	PointsForCompletation = p_PointsForCompletation,
	MaxPlaysPerDay = p_MaxPlaysPerDay,
	NoOfDataSet = p_NoOfDataSet,
	NoOfRounds = p_NoOfRounds,
	MatchImage = p_MatchImage,
	MatchImageThumbnail = p_MatchImageThumbnail,
	KPI_ID = p_KPIID
WHERE MatchID = p_MatchID;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_UpdateMessageStatus` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_UpdateMessageStatus`(p_MessageID int)
BEGIN



UPDATE tblMessages SET IsRead = 1

WHERE tblMessages.ID = p_MessageID;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_UpdatePassword` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_UpdatePassword`(p_UserID int,p_NewPassword varchar(100))
BEGIN

	

	UPDATE tblUser 

	SET tblUser.U_Password = p_NewPassword

	WHERE tblUser.UserID = p_UserID;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_UpdatePoints` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_UpdatePoints`(p_Points INT, p_UserID INT)
BEGIN

	UPDATE tblUser

SET 

        U_Points=p_Points

WHERE UserID = p_UserID ;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_UpdateQuestions` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_UpdateQuestions`(p_QuestionID INT,p_ShortQuestion Varchar(100),p_QuestionText Varchar(200), p_QuestionExplanation VARCHAR(300), p_Answer1 VarChar(100),p_Answer2 VarChar(100), p_Answer3 VarChar(100), p_Answer4 VarChar(100), p_CorrectAnswer VarChar(100), p_Category INT, p_SiteID INT, p_QuizID int, p_QuestionImage VARCHAR(100), p_QuestionImageThumbnail VarChar(100))
BEGIN
UPDATE tblQuizQuestions
SET QuestionText =p_QuestionText,
		QuestionExplanation = p_QuestionExplanation,
		Answer1=p_Answer1,
		Answer2=p_Answer2,
		Answer3=p_Answer3,
		Answer4=p_Answer4,
		CorrectAnswer =p_CorrectAnswer,
		Category=p_Category,
		SiteID = p_SiteID,		
		QuizID= p_QuizID,
		QuestionImage=p_QuestionImage,
		QuestionImageThumbnail = p_QuestionImageThumbnail,
ShortQuestion=p_ShortQuestion

WHERE QuestionID= p_QuestionID;


END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_UpdateQuiz` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_UpdateQuiz`(p_QuizID INT, p_QuizName VARCHAR(250), p_NoOfQuestions INT, 
													p_TimePerQuestion INT, p_TimesPlayablePerDay INT, 
													p_TimeBeforePointsDeduction INT, p_PointsPerQuestion INT, 
													p_QuizImage VARCHAR(100),  p_QuizImageThumbnail VARCHAR(100),
													p_KPIID INT)
BEGIN
UPDATE tblQuiz
SET QuizName = p_QuizName,
		NoOfQuestions = p_NoOfQuestions ,
		TimePerQuestion = p_TimePerQuestion,
		TimesPlayablePerDay = p_TimesPlayablePerDay,
		TimeBeforePointsDeduction = p_TimeBeforePointsDeduction,
		PointsPerQuestion = p_PointsPerQuestion,
		QuizImage = p_QuizImage,
		QuizImageThumbnail=p_QuizImageThumbnail,
		KPI_ID = p_KPIID
Where QuizID = p_QuizID;


END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_UpdateReward` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_UpdateReward`(p_RewardType int,p_RewardDescp varchar(200),p_RewardID INT, p_RewardName Varchar(100),p_Active TINYINT(4),p_RewardPoints int(11), p_CurrentImage int(1),p_ID int)
BEGIN



UPDATE tblRewards 

SET Reward_Name = p_RewardName,

		Active = p_Active,

Reward_Cost =p_RewardPoints,

Reward_Descp=p_RewardDescp,

Reward_Type=p_RewardType

WHERE Reward_ID = p_RewardID;



UPDATE tblRewardImages 

SET Current_Image = p_CurrentImage 

WHERE ID = p_ID;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_UpdateRole` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_UpdateRole`(p_RoleID INT,p_RoleName VARCHAR(100),p_Active TINYINT(4),p_ActiveStatus int)
BEGIN

if(p_ActiveStatus =1)

then

UPDATE tblRoles 

SET Role_Name = p_RoleName,

		Active =  p_Active,

       ActiveUpdatedDate =CURRENT_TIMESTAMP()

WHERE Role_ID = p_RoleID;

END IF;



if(p_ActiveStatus =0)

then

UPDATE tblRoles 

SET Role_Name = p_RoleName,

		Active =  p_Active

WHERE Role_ID = p_RoleID;

END IF;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_UpdateRound` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_UpdateRound`(p_MatchID INT, p_RoundID INT, p_RoundNumber int, p_RoundName VARCHAR(250),
														p_NoOfDataSets int, p_TimePerRound int, p_PointsPerRound int, p_ShowHint int)
BEGIN

UPDATE tblround
SET
	MatchID = p_MatchID,
	RoundNumber = p_RoundNumber,
	RoundName = p_RoundName,
	NoOfDataSets = p_NoOfDataSets,
	TimePerRound = p_TimePerRound,
	PointsPerRound = p_PointsPerRound,
	ShowHint = p_ShowHint
WHERE `RoundID` = p_RoundID;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_UpdateScoreManual` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_UpdateScoreManual`(p_Current int,p_UserID int,p_KPIID int,p_Score int)
BEGIN
DECLARE CONTINUE HANDLER FOR SQLEXCEPTION 
    BEGIN
        ROLLBACK;        
    END;

	START TRANSACTION;
IF ( NOT EXISTS(SELECT * FROM tblScores WHERE Type_ID=p_KPIID AND U_Type ='KPI' AND User_ID =p_UserID AND LevelID = p_Current))
then
Insert into tblScores(User_ID,U_Type,Type_ID,Score,Entry_Date,LevelID)
values(p_UserID,'KPI',p_KPIID,p_Score,NOW(),p_Current);

Else
Update tblScores
Set Score= p_Score
Where Type_ID=p_KPIID AND U_Type ='KPI' AND User_ID =p_UserID AND LevelID = p_Current;


End IF;
commit;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_UpdateSite` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_UpdateSite`(p_SiteID INT,p_SiteName VARCHAR(50),p_SiteType VARCHAR(50), p_SiteAddress VARCHAR(150),p_Active tinyint)
BEGIN

	

	UPDATE tblSite

	SET site_name = p_SiteName,

			site_type = p_SiteType,

			site_address = p_SiteAddress,

			Active = p_Active

	WHERE site_id = p_SiteID;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_UpdateTarget` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_UpdateTarget`(p_TargetID INT,p_TargetValue int,p_KpiID INT,p_LevelID INT,p_RoleID INT,p_Active TINYINT,p_Description varchar(500))
BEGIN

UPDATE tblTarget

SET Target_Value = p_TargetValue,

    KPI_ID = p_KpiID,

    Level_ID = p_LevelID,

	Role_ID = p_RoleID,

    Active = p_Active,

		Target_Desc = p_Description



WHERE Target_ID = p_TargetID ;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_UpdateUser` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_UpdateUser`(p_DisplayName int,p_UserID INT,p_UserName VARCHAR (100),p_UserLastName varchar(20),p_UserNickName varchar(50))
BEGIN

UPDATE tblUser

SET U_FirstName = p_UserName,

	U_LastName  = p_UserLastName,

	U_NickName=p_UserNickName,

    Display_Name=p_DisplayName



WHERE UserID = p_UserID ;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_UpdateUserManualAward_Popup` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_UpdateUserManualAward_Popup`(p_UserID int, p_AwardID int)
BEGIN

	

UPDATE tblUserAwards SET popup_showed = 1 WHERE tbluserawards.user_id= p_UserID AND tbluserawards.award_id = p_AwardID;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_UpdateUserMass` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_UpdateUserMass`(p_CurrentLevel int,p_NextLevel int,p_UserID INT , p_SiteID INT , p_SysRole varchar(50) , p_RolesID INT , p_Active tinyint(4),p_ManagerID INT)
BEGIN

DECLARE CONTINUE HANDLER FOR SQLEXCEPTION 

    BEGIN

        ROLLBACK;        

    END;



	START TRANSACTION;

		UPDATE tblUser

		SET 

				U_SiteID = p_SiteID ,

				U_SysRole = p_SysRole ,

				U_RolesID = p_RolesID ,

				Active = p_Active,

				ManagerID = p_ManagerID,

				ActiveUpdatedDate = CURRENT_TIMESTAMP()

		WHERE UserID = p_UserID ;

		IF ( NOT EXISTS(SELECT * FROM tblLevelPerformance WHERE user_id = p_UserID and current_level = p_CurrentLevel))

		THEN



		Set @previous =(select last_level from tblLevelPerformance 

										where  user_id=p_UserID AND (SELECT Role_ID FROM tblLevel WHERE Level_ID IN (SELECT Level_ID FROM tblLevel WHERE Role_ID = p_RolesID) LIMIT 1) = p_RolesID and level_achieved =0);



		update tblLevelPerformance

		set level_achieved =1

		where  user_id=p_UserID AND (SELECT Role_ID FROM tblLevel WHERE Level_ID IN (SELECT Level_ID FROM tblLevel WHERE Role_ID = p_RolesID) LIMIT 1) = p_RolesID and level_achieved =0;



			

				Insert into tblLevelPerformance(user_id,current_level,next_level,last_level,level_achieved,target_scores,achieved_scores)

				Values(p_UserID,p_CurrentLevel,p_NextLevel,IFNULL(@previous,'0'),0,(Select IFNULL(Sum(Target_Value),'0') from tblTarget

				where Role_ID =p_RolesID AND Level_ID=p_CurrentLevel),0);

			

		End IF;





Commit;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_UpdateUser_Admin` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_UpdateUser_Admin`(p_Hours int,p_Points int,p_previousLevel int,p_CurrentLevel int,p_NextLevel int,p_LastLevel int,p_LevelAchieved int,p_UserID INT , p_U_LastName varchar(50) , p_U_EmpID varchar(200) , p_U_NickName varchar(50) , p_U_Email varchar(50) , p_U_SiteID INT , p_U_SysRole varchar(50) , p_U_RolesID INT , p_Active tinyint(1), p_U_FirstName varchar(50),p_ActiveUpdateStatus INT , p_ManagerID INT)
BEGIN

DECLARE CONTINUE HANDLER FOR SQLEXCEPTION 

    BEGIN

        ROLLBACK;        

    END;



	START TRANSACTION;

	

IF(p_ActiveUpdateStatus = 1)

THEN

UPDATE tblUser

SET U_EmpID = p_U_EmpID,

		U_LastName = p_U_LastName ,

		U_NickName = p_U_NickName ,		

		U_Email = p_U_Email ,

		U_SiteID = p_U_SiteID ,

		U_SysRole = p_U_SysRole ,

		U_RolesID = p_U_RolesID ,

		Active = p_Active,

		U_FirstName = p_U_FirstName,

		ActiveUpdatedDate = CURRENT_TIMESTAMP(),

		ManagerID = p_ManagerID,

		U_Points=p_Points

WHERE UserID = p_UserID ;



Update tblLevelPerformance

Set Worked_Hour=p_Hours

Where user_id=p_UserID and level_achieved=0;



ELSE

UPDATE tblUser

SET U_EmpID = p_U_EmpID,

		U_LastName = p_U_LastName ,

		U_NickName = p_U_NickName ,		

		U_Email = p_U_Email ,

		U_SiteID = p_U_SiteID ,

		U_SysRole = p_U_SysRole ,

		U_RolesID = p_U_RolesID ,

		Active = p_Active,

		U_FirstName = p_U_FirstName,

		ManagerID = p_ManagerID,

        U_Points=p_Points

WHERE UserID = p_UserID ;



update tblLevelPerformance

set level_achieved =1

where  tblLevelPerformance.current_level=p_previousLevel and user_id=p_UserID;



insert into tblLevelPerformance(user_id,current_level,next_level,last_level,level_achieved,target_scores,achieved_scores)

values(p_UserID,p_CurrentLevel,p_NextLevel,p_LastLevel,p_LevelAchieved,(Select IFNULL(Sum(Target_Value),'0') from tblTarget

where Role_ID =p_U_RolesID AND Level_ID=p_CurrentLevel),0);



Update tblLevelPerformance

Set Worked_Hour=p_Hours

Where user_id=p_UserID and level_achieved=0;





END IF;

Commit;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_UpdateWorkedHours` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_UpdateWorkedHours`(p_hours int, p_user int)
BEGIN

UPDATE tbllevelperformance
SET tbllevelperformance.Worked_Hour = tbllevelperformance.Worked_Hour + p_hours
WHERE tbllevelperformance.user_id = p_user
AND tbllevelperformance.level_achieved =0;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_Update_UserAwardAchieved` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_Update_UserAwardAchieved`(p_UserID INT,p_AwardID INT)
BEGIN





	







IF ( NOT EXISTS(SELECT * FROM tblUserAwards WHERE user_id=p_UserID AND award_id =p_AwardID ))

then





INSERT INTO tblUserAwards ( user_id,award_id,manual,popup_showed)

      VALUES (p_UserID,p_AwardID,0,0);












End IF;

















END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_Update_UserAwardAchievedpopup` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_Update_UserAwardAchievedpopup`(p_UserID INT,p_AwardID INT)
BEGIN

Update tblUserAwards



Set popup_showed=1,awarded_date=NOW()



WHERE user_id=p_UserID AND award_id =p_AwardID;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_Update_UserTargetAchieved` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_Update_UserTargetAchieved`(p_UserID INT,p_TargetID INT)
BEGIN

IF ( NOT EXISTS(SELECT * FROM tblUserTargetAchieved WHERE tblUserTargetAchieved.UserID = p_UserID and tblUserTargetAchieved.Target_ID=p_TargetID))
	THEN
	INSERT INTO tblUserTargetAchieved(UserID,Target_ID)
	values(p_UserID,p_TargetID);

	UPDATE tblUser SET U_Points = U_Points + (SELECT Points FROM tblTarget WHERE Target_ID = p_TargetID)
	WHERE UserID = p_UserID;

ELSE

CALL DuplicatePRO;

	END IF;

END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!50003 DROP PROCEDURE IF EXISTS `sp_UserQuizScore` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8 */ ;
/*!50003 SET character_set_results = utf8 */ ;
/*!50003 SET collation_connection  = utf8_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`b4441296749150`@`%` PROCEDURE `sp_UserQuizScore`(UserID int)
BEGIN



SELECT

tblQuizGames.GameId,

tblQuizGames.GameName,imageName,



(Select max(DateTime) from tblUserQuizScore where game_id=tblQuizGames.GameId and user_id=UserID) 

as DateTime,



(Select ifnull(sum(AchievedScore),0) from v_UserQuizScore where game_id=tblQuizGames.GameId 

and user_id=UserID 

LIMIT 1)  as YourBest,



(Select  ifnull(Max(AchievedScore),0) from v_UserQuizScore where game_id=tblQuizGames.GameId 

LIMIT 1) 

as TopScorer,



(Select Username from v_UserQuizScore where game_id=tblQuizGames.GameId and 

AchievedScore=(Select  ifnull(Max(AchievedScore),0) from v_UserQuizScore 

where game_id=tblQuizGames.GameId LIMIT 1) LIMIT 1) as TopScorerName



FROM

tblQuizGames

ORDER BY

tblQuizGames.GameId ASC;



END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Final view structure for view `login_duration`
--

/*!50001 DROP VIEW IF EXISTS `login_duration`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`b4441296749150`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `login_duration` AS select `s`.`Id` AS `start_id`,`s`.`entry_date` AS `start_date`,`f`.`Id` AS `finish_id`,`f`.`entry_date` AS `finish_date`,((`f`.`entry_date` - `s`.`entry_date`) / 100) AS `duration_minutes`,(((`f`.`entry_date` - `s`.`entry_date`) / 100) / 60) AS `duration_hours` from (`event_report` `s` join `event_report` `f`) where ((`s`.`userid` = 55) and (`f`.`userid` = 55) and (`s`.`description` = 'login') and (`f`.`description` = 'logout')) order by `s`.`Id`,((`f`.`entry_date` - `s`.`entry_date`) / 100) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `total_hours_worked`
--

/*!50001 DROP VIEW IF EXISTS `total_hours_worked`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`b4441296749150`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `total_hours_worked` AS select sum(`tbllevelperformance`.`Worked_Hour`) AS `sum(Worked_Hour)` from `tbllevelperformance` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `total_levels`
--

/*!50001 DROP VIEW IF EXISTS `total_levels`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`b4441296749150`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `total_levels` AS select count(0) AS `count(*)` from `tbllevel` where (`tbllevel`.`Active` = 1) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `total_questions`
--

/*!50001 DROP VIEW IF EXISTS `total_questions`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`b4441296749150`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `total_questions` AS select count(0) AS `count(*)` from `tblquizquestions` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `total_sales`
--

/*!50001 DROP VIEW IF EXISTS `total_sales`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`b4441296749150`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `total_sales` AS select sum(`v_userlevelscores`.`score`) AS `sum(score)` from `v_userlevelscores` where (`v_userlevelscores`.`KPI_ID` = 69) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `total_sites`
--

/*!50001 DROP VIEW IF EXISTS `total_sites`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`b4441296749150`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `total_sites` AS select count(0) AS `count(*)` from `tblsite` where (`tblsite`.`Active` = 1) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `total_users`
--

/*!50001 DROP VIEW IF EXISTS `total_users`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`b4441296749150`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `total_users` AS select `tblroles`.`Role_Name` AS `Role`,count(`tbluser`.`UserID`) AS `total` from (`tbluser` left join `tblroles` on((`tbluser`.`U_RolesID` = `tblroles`.`Role_ID`))) group by `tblroles`.`Role_Name` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `v_userlevelscores`
--

/*!50001 DROP VIEW IF EXISTS `v_userlevelscores`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8 */;
/*!50001 SET character_set_results     = utf8 */;
/*!50001 SET collation_connection      = utf8_general_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`b4441296749150`@`%` SQL SECURITY DEFINER */
/*!50001 VIEW `v_userlevelscores` AS select `tbluser`.`UserID` AS `UserID`,`tbltarget`.`Role_ID` AS `Role_ID`,`tbltarget`.`Level_ID` AS `Level_ID`,`tbltarget`.`KPI_ID` AS `KPI_ID`,`tbltarget`.`Target_ID` AS `Target_ID`,`tbllevel`.`Level_Name` AS `Level_Name`,`tblkpi`.`KPI_name` AS `KPI_name`,`tbltarget`.`Target_Value` AS `Target_Value`,(select ifnull(sum(`tblscores`.`Score`),0) AS `score` from `tblscores` where ((`tblscores`.`Type_ID` = `tbltarget`.`KPI_ID`) and (`tblscores`.`LevelID` = `tbltarget`.`Level_ID`) and (`tblscores`.`User_ID` = `tbluser`.`UserID`) and (`tblscores`.`U_Type` = 'KPI'))) AS `score`,ceiling((((select ifnull(sum(`tblscores`.`Score`),0) AS `score` from `tblscores` where ((`tblscores`.`Type_ID` = `tbltarget`.`KPI_ID`) and (`tblscores`.`User_ID` = `tbluser`.`UserID`) and (`tblscores`.`LevelID` = `tbltarget`.`Level_ID`) and (`tblscores`.`U_Type` = 'KPI'))) / `tbltarget`.`Target_Value`) * 100)) AS `current_percentage`,`tbltarget`.`Points` AS `Points` from (((`tbltarget` join `tbllevel` on((`tbltarget`.`Level_ID` = `tbllevel`.`Level_ID`))) join `tblkpi` on((`tbltarget`.`KPI_ID` = `tblkpi`.`KPI_ID`))) join `tbluser` on((`tbltarget`.`Role_ID` = `tbluser`.`U_RolesID`))) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2015-07-27 15:38:24
