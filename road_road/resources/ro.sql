-- MySQL dump 10.13  Distrib 8.0.28, for Win64 (x86_64)
--
-- Host: localhost    Database: ro
-- ------------------------------------------------------
-- Server version	8.0.31

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `brigades`
--

DROP TABLE IF EXISTS `brigades`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `brigades` (
  `id_brigade` int NOT NULL,
  `name_of_brigade` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_brigade`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `brigades`
--

LOCK TABLES `brigades` WRITE;
/*!40000 ALTER TABLE `brigades` DISABLE KEYS */;
/*!40000 ALTER TABLE `brigades` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `genders`
--

DROP TABLE IF EXISTS `genders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `genders` (
  `id_gender` int NOT NULL,
  `name_of_gender` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_gender`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `genders`
--

LOCK TABLES `genders` WRITE;
/*!40000 ALTER TABLE `genders` DISABLE KEYS */;
INSERT INTO `genders` VALUES (1,'мужской');
/*!40000 ALTER TABLE `genders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `highways`
--

DROP TABLE IF EXISTS `highways`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `highways` (
  `id_highway` int NOT NULL,
  `name_of_highway` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_highway`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `highways`
--

LOCK TABLES `highways` WRITE;
/*!40000 ALTER TABLE `highways` DISABLE KEYS */;
/*!40000 ALTER TABLE `highways` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `materials`
--

DROP TABLE IF EXISTS `materials`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `materials` (
  `id_material` int NOT NULL,
  `name_of_material` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_material`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `materials`
--

LOCK TABLES `materials` WRITE;
/*!40000 ALTER TABLE `materials` DISABLE KEYS */;
/*!40000 ALTER TABLE `materials` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `objects`
--

DROP TABLE IF EXISTS `objects`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `objects` (
  `id_object` int NOT NULL,
  `name_of_object` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_object`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `objects`
--

LOCK TABLES `objects` WRITE;
/*!40000 ALTER TABLE `objects` DISABLE KEYS */;
/*!40000 ALTER TABLE `objects` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `place`
--

DROP TABLE IF EXISTS `place`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `place` (
  `id_place` int NOT NULL,
  `id_town` int DEFAULT NULL,
  `id_highway` int DEFAULT NULL,
  `id_street` int DEFAULT NULL,
  `place_discription` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_place`),
  KEY `id_town_idx` (`id_town`),
  KEY `id_highway_idx` (`id_highway`),
  KEY `id_street_idx` (`id_street`),
  CONSTRAINT `id_highway` FOREIGN KEY (`id_highway`) REFERENCES `highways` (`id_highway`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `id_street` FOREIGN KEY (`id_street`) REFERENCES `streets` (`id_street`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `id_town` FOREIGN KEY (`id_town`) REFERENCES `towns` (`id_town`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `place`
--

LOCK TABLES `place` WRITE;
/*!40000 ALTER TABLE `place` DISABLE KEYS */;
/*!40000 ALTER TABLE `place` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `positions`
--

DROP TABLE IF EXISTS `positions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `positions` (
  `id_position` int NOT NULL,
  `name_of_position` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_position`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `positions`
--

LOCK TABLES `positions` WRITE;
/*!40000 ALTER TABLE `positions` DISABLE KEYS */;
/*!40000 ALTER TABLE `positions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `roles` (
  `id_role` int NOT NULL,
  `name_of_role` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_role`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `roles`
--

LOCK TABLES `roles` WRITE;
/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` VALUES (1,'администратор');
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `streets`
--

DROP TABLE IF EXISTS `streets`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `streets` (
  `id_street` int NOT NULL,
  `name_of_street` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_street`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `streets`
--

LOCK TABLES `streets` WRITE;
/*!40000 ALTER TABLE `streets` DISABLE KEYS */;
/*!40000 ALTER TABLE `streets` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tasks`
--

DROP TABLE IF EXISTS `tasks`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tasks` (
  `id_task` int NOT NULL,
  `id_type_task` int DEFAULT NULL,
  `id_object` int DEFAULT NULL,
  `id_place` int DEFAULT NULL,
  `id_material` int DEFAULT NULL,
  `id_technic` int DEFAULT NULL,
  `id_briade` int DEFAULT NULL,
  `date_time_begin` datetime DEFAULT NULL,
  `date_time_end` datetime DEFAULT NULL,
  PRIMARY KEY (`id_task`),
  KEY `id_type_task_idx` (`id_type_task`),
  KEY `id_object_idx` (`id_object`),
  KEY `id_place_idx` (`id_place`),
  KEY `id_material_idx` (`id_material`),
  KEY `id_technic_idx` (`id_technic`),
  KEY `id_brigade_task_idx` (`id_briade`),
  CONSTRAINT `id_brigade_task` FOREIGN KEY (`id_briade`) REFERENCES `brigades` (`id_brigade`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `id_material` FOREIGN KEY (`id_material`) REFERENCES `materials` (`id_material`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `id_object` FOREIGN KEY (`id_object`) REFERENCES `objects` (`id_object`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `id_place` FOREIGN KEY (`id_place`) REFERENCES `place` (`id_place`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `id_technic` FOREIGN KEY (`id_technic`) REFERENCES `technics` (`id_technic`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `id_type_task` FOREIGN KEY (`id_type_task`) REFERENCES `type_task` (`id_type_task`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tasks`
--

LOCK TABLES `tasks` WRITE;
/*!40000 ALTER TABLE `tasks` DISABLE KEYS */;
/*!40000 ALTER TABLE `tasks` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `technics`
--

DROP TABLE IF EXISTS `technics`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `technics` (
  `id_technic` int NOT NULL,
  `id_type_of_technic` int DEFAULT NULL,
  `name_of_technic` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_technic`),
  KEY `id_type_of_technic_idx` (`id_type_of_technic`),
  CONSTRAINT `id_type_of_technic` FOREIGN KEY (`id_type_of_technic`) REFERENCES `type_of_technic` (`id_type_of_technic`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `technics`
--

LOCK TABLES `technics` WRITE;
/*!40000 ALTER TABLE `technics` DISABLE KEYS */;
/*!40000 ALTER TABLE `technics` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `towns`
--

DROP TABLE IF EXISTS `towns`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `towns` (
  `id_town` int NOT NULL,
  `name_of_town` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_town`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `towns`
--

LOCK TABLES `towns` WRITE;
/*!40000 ALTER TABLE `towns` DISABLE KEYS */;
/*!40000 ALTER TABLE `towns` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `type_of_technic`
--

DROP TABLE IF EXISTS `type_of_technic`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `type_of_technic` (
  `id_type_of_technic` int NOT NULL,
  `name_type_of_technic` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_type_of_technic`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `type_of_technic`
--

LOCK TABLES `type_of_technic` WRITE;
/*!40000 ALTER TABLE `type_of_technic` DISABLE KEYS */;
/*!40000 ALTER TABLE `type_of_technic` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `type_task`
--

DROP TABLE IF EXISTS `type_task`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `type_task` (
  `id_type_task` int NOT NULL,
  `name_type_task` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_type_task`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `type_task`
--

LOCK TABLES `type_task` WRITE;
/*!40000 ALTER TABLE `type_task` DISABLE KEYS */;
/*!40000 ALTER TABLE `type_task` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `id_user` int NOT NULL,
  `id_role` int DEFAULT NULL,
  `id_gender` int DEFAULT NULL,
  `date_of_bers` date DEFAULT NULL,
  `second_name` varchar(45) DEFAULT NULL,
  `first_name` varchar(45) DEFAULT NULL,
  `last_name` varchar(45) DEFAULT NULL,
  `telephone` varchar(45) DEFAULT NULL,
  `e-mail` varchar(45) DEFAULT NULL,
  `photo` varchar(45) DEFAULT NULL,
  `login` varchar(45) DEFAULT NULL,
  `password` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_user`),
  KEY `id_role_idx` (`id_role`),
  KEY `id_gender_user_idx` (`id_gender`),
  CONSTRAINT `id_gender_user` FOREIGN KEY (`id_gender`) REFERENCES `genders` (`id_gender`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `id_role` FOREIGN KEY (`id_role`) REFERENCES `roles` (`id_role`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,1,1,NULL,'дмитриевна','анна',NULL,NULL,NULL,NULL,'1','1');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `workers`
--

DROP TABLE IF EXISTS `workers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `workers` (
  `id_worker` int NOT NULL,
  `id_position` int DEFAULT NULL,
  `id_gender` int DEFAULT NULL,
  `id_brigade` int DEFAULT NULL,
  `date_of_bers` date DEFAULT NULL,
  `second_name` varchar(45) DEFAULT NULL,
  `first_name` varchar(45) DEFAULT NULL,
  `last_name` varchar(45) DEFAULT NULL,
  `telephon` varchar(45) DEFAULT NULL,
  `e-mail` varchar(45) DEFAULT NULL,
  `photo` longtext,
  `login` varchar(45) DEFAULT NULL,
  `password` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id_worker`),
  KEY `id_psition_idx` (`id_position`),
  KEY `id_gender_idx` (`id_gender`),
  KEY `id_brigade_idx` (`id_brigade`),
  CONSTRAINT `id_brigade` FOREIGN KEY (`id_brigade`) REFERENCES `brigades` (`id_brigade`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `id_gender` FOREIGN KEY (`id_gender`) REFERENCES `genders` (`id_gender`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `id_psition` FOREIGN KEY (`id_position`) REFERENCES `positions` (`id_position`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `workers`
--

LOCK TABLES `workers` WRITE;
/*!40000 ALTER TABLE `workers` DISABLE KEYS */;
/*!40000 ALTER TABLE `workers` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-02-15 19:11:17
