CREATE DATABASE  IF NOT EXISTS `login_and_registration` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `login_and_registration`;
-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: login_and_registration
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
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `first_name` varchar(255) DEFAULT NULL,
  `last_name` varchar(255) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `pw_hash` varchar(255) DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'Kath','Lynn','Kath@Lynn.com','AQAAAAEAACcQAAAAEBFDeFKO+WwJZuyaKGfUiRcAHgdjJ6kykgCH5bvuajGOxqmZbKK9FgpGkNrtzuDqgw==','2018-01-10 19:08:32','2018-01-10 19:08:32'),(2,'Rommel','Dumaguin','rommel@cs.com','AQAAAAEAACcQAAAAEPo0lqx0sk4bdZucgbJeaqVe7gk/RE2/JMmXNVM3ATCAMeIy7AK66GBx7kC8iVYsKg==','2018-01-10 19:36:32','2018-01-10 19:36:32'),(3,'Jane','Doe','jane@cs.com','AQAAAAEAACcQAAAAEGfB1RLN1YPoYd12t2+x9lC9nFIGM3rHwQtHt9F8Afs/nVZrnogubVyClfIiOSnKXQ==','2018-01-10 20:59:21','2018-01-10 20:59:21'),(4,'John','Doe','john@cs.com','AQAAAAEAACcQAAAAEBMrlYyS+ua7xeNLWG6ZXmJfL7EpUyeqsEIPOoUisQjWedV8f5Hn2om3T2duovAmaQ==','2018-01-10 20:59:48','2018-01-10 20:59:48'),(5,'Shawn','Don','shawn@cs.com','AQAAAAEAACcQAAAAEHyD9293//1hRdF/wNclYCZJ+KFnoqGJSDIWlmc3JG9o+sxGBdAxZKQMv2+46LXaHQ==','2018-01-10 21:03:00','2018-01-10 21:03:00');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-01-10 21:08:08
