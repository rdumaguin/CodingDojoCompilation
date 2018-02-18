CREATE DATABASE  IF NOT EXISTS `wedding_planner` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `wedding_planner`;
-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: wedding_planner
-- ------------------------------------------------------
-- Server version	5.7.20-log

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
-- Table structure for table `rsvps`
--

DROP TABLE IF EXISTS `rsvps`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `rsvps` (
  `RsvpId` int(11) NOT NULL AUTO_INCREMENT,
  `WeddingId` int(11) NOT NULL,
  `UserId` int(11) NOT NULL,
  `CreatedAt` datetime DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`RsvpId`),
  KEY `fk_weddings_planned_has_users_users1_idx` (`UserId`),
  KEY `fk_weddings_planned_has_users_weddings_planned1_idx` (`WeddingId`),
  CONSTRAINT `fk_weddings_planned_has_users_users1` FOREIGN KEY (`UserId`) REFERENCES `users` (`UserId`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_weddings_planned_has_users_weddings_planned1` FOREIGN KEY (`WeddingId`) REFERENCES `weddings_planned` (`WeddingId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rsvps`
--

LOCK TABLES `rsvps` WRITE;
/*!40000 ALTER TABLE `rsvps` DISABLE KEYS */;
INSERT INTO `rsvps` VALUES (21,4,18,'2018-01-29 22:07:46','2018-01-29 22:07:46'),(26,1,19,'2018-01-29 22:17:13','2018-01-29 22:17:13'),(29,1,17,'2018-01-29 23:01:18','2018-01-29 23:01:18');
/*!40000 ALTER TABLE `rsvps` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `UserId` int(11) NOT NULL AUTO_INCREMENT,
  `FirstName` varchar(255) DEFAULT NULL,
  `LastName` varchar(255) DEFAULT NULL,
  `Email` varchar(255) DEFAULT NULL,
  `Password` varchar(255) DEFAULT NULL,
  `CreatedAt` datetime DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`UserId`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (17,'asdf','asdf','asdf@cs.com','AQAAAAEAACcQAAAAEIMAYKt0mUQd4Nfm3abQG3ruQ+lt4LKODsZ9/CTMv297Om0BqlP12l3Pcr8gMEThZQ==','2018-01-29 19:05:38','2018-01-29 19:05:38'),(18,'qwer','qwer','qwer@cs.com','AQAAAAEAACcQAAAAEFAEc6q1AFawXUVK0r1MySWkRl+OBh+fZuo8tfB21PQL7qQGdPKAD5xSJfU4PisDbw==','2018-01-29 19:16:24','2018-01-29 19:16:24'),(19,'zxcv','zxcv','zxcv@cs.com','AQAAAAEAACcQAAAAEIR7IH8hp/+ahxgCLJ/RUZMVbGmhcvpX3QknUoURePlvhtqEAn7k1jzU6aCVAXMdrA==','2018-01-29 22:17:10','2018-01-29 22:17:10');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `weddings_planned`
--

DROP TABLE IF EXISTS `weddings_planned`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `weddings_planned` (
  `WeddingId` int(11) NOT NULL AUTO_INCREMENT,
  `WedderOne` varchar(255) DEFAULT NULL,
  `WedderTwo` varchar(255) DEFAULT NULL,
  `Date` datetime DEFAULT NULL,
  `Address` varchar(255) DEFAULT NULL,
  `UserId` int(11) NOT NULL,
  `CreatedAt` datetime DEFAULT NULL,
  `UpdatedAt` datetime DEFAULT NULL,
  PRIMARY KEY (`WeddingId`),
  KEY `fk_weddings_planned_users1_idx` (`UserId`),
  CONSTRAINT `fk_weddings_planned_users1` FOREIGN KEY (`UserId`) REFERENCES `users` (`UserId`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `weddings_planned`
--

LOCK TABLES `weddings_planned` WRITE;
/*!40000 ALTER TABLE `weddings_planned` DISABLE KEYS */;
INSERT INTO `weddings_planned` VALUES (1,'asdf','qwer','2018-02-01 00:00:00','Seattle',18,'2018-01-29 19:16:59','2018-01-29 19:16:59'),(3,'zxcv','asdf','2019-01-01 00:00:00','Redmond',17,'2018-01-29 21:33:52','2018-01-29 21:33:52'),(4,'wert','sdfg','2019-01-02 00:00:00','Bothell',17,'2018-01-29 22:07:26','2018-01-29 22:07:26');
/*!40000 ALTER TABLE `weddings_planned` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-01-29 23:38:21
