CREATE DATABASE  IF NOT EXISTS `transportefortin` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `transportefortin`;
-- MySQL dump 10.13  Distrib 5.5.16, for Win32 (x86)
--
-- Host: localhost    Database: transportefortin
-- ------------------------------------------------------
-- Server version	5.1.68-community

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
-- Table structure for table `clientes`
--

DROP TABLE IF EXISTS `clientes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `clientes` (
  `idclientes` int(11) NOT NULL AUTO_INCREMENT,
  `cliente` varchar(100) NOT NULL,
  `direccion` varchar(75) DEFAULT NULL,
  `localidad` varchar(55) DEFAULT NULL,
  `cp` int(11) DEFAULT NULL,
  `telefono` varchar(45) DEFAULT NULL,
  `celular` varchar(45) DEFAULT NULL,
  `fax` varchar(45) DEFAULT NULL,
  `mail` varchar(75) DEFAULT NULL,
  `contacto` varchar(45) DEFAULT NULL,
  `cuit` varchar(13) DEFAULT NULL,
  `idtiposiva` int(11) NOT NULL,
  `comentario` varchar(205) DEFAULT NULL,
  PRIMARY KEY (`idclientes`),
  KEY `fkidtiposiva_idx` (`idtiposiva`),
  CONSTRAINT `fkidtiposiva` FOREIGN KEY (`idtiposiva`) REFERENCES `tiposiva` (`idtiposiva`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `clientes`
--

LOCK TABLES `clientes` WRITE;
/*!40000 ALTER TABLE `clientes` DISABLE KEYS */;
INSERT INTO `clientes` VALUES (1,'EZEQUIEL FERNANDO VAZQUEZ','PRINGLES 1656','MAR DEL PLATA',7600,'4892488','155822091','','ECHE.MDQ@HOTMAIL.COM','FERNANDO VAZQUEZ','20-37178051-4',6,'Probando grabado de sistema');
/*!40000 ALTER TABLE `clientes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `empresas`
--

DROP TABLE IF EXISTS `empresas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `empresas` (
  `idempresas` int(11) NOT NULL AUTO_INCREMENT,
  `empresa` varchar(75) NOT NULL,
  `direccion` varchar(75) DEFAULT NULL,
  `localidad` varchar(75) DEFAULT NULL,
  `telefono` varchar(55) DEFAULT NULL,
  `telefono2` varchar(55) DEFAULT NULL,
  `celular` varchar(55) DEFAULT NULL,
  `mail` varchar(75) DEFAULT NULL,
  `comentario` varchar(205) DEFAULT NULL,
  PRIMARY KEY (`idempresas`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `empresas`
--

LOCK TABLES `empresas` WRITE;
/*!40000 ALTER TABLE `empresas` DISABLE KEYS */;
/*!40000 ALTER TABLE `empresas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `fleteros`
--

DROP TABLE IF EXISTS `fleteros`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `fleteros` (
  `idfleteros` int(11) NOT NULL AUTO_INCREMENT,
  `documento` varchar(45) NOT NULL,
  `fletero` varchar(75) NOT NULL,
  `direccion` varchar(45) DEFAULT NULL,
  `localidad` varchar(75) DEFAULT NULL,
  `cp` int(11) DEFAULT NULL,
  `telefono` varchar(45) DEFAULT NULL,
  `celular` varchar(45) DEFAULT NULL,
  `fax` varchar(45) DEFAULT NULL,
  `mail` varchar(75) DEFAULT NULL,
  `idempresas` int(11) NOT NULL,
  `camion` varchar(45) DEFAULT NULL,
  `idtiposcamion` int(11) NOT NULL,
  `chapacamion` varchar(45) DEFAULT NULL,
  `chapaacoplado` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`idfleteros`),
  UNIQUE KEY `documento_UNIQUE` (`documento`),
  KEY `fkidempresas_idx` (`idempresas`),
  KEY `fkidtiposcamion_idx` (`idtiposcamion`),
  CONSTRAINT `fkidempresas` FOREIGN KEY (`idempresas`) REFERENCES `empresas` (`idempresas`) ON UPDATE CASCADE,
  CONSTRAINT `fkidtiposcamion` FOREIGN KEY (`idtiposcamion`) REFERENCES `tiposcamion` (`idtiposcamion`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `fleteros`
--

LOCK TABLES `fleteros` WRITE;
/*!40000 ALTER TABLE `fleteros` DISABLE KEYS */;
/*!40000 ALTER TABLE `fleteros` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `proveedores`
--

DROP TABLE IF EXISTS `proveedores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `proveedores` (
  `idproveedores` int(11) NOT NULL AUTO_INCREMENT,
  `proveedor` varchar(105) NOT NULL,
  `direccion` varchar(75) DEFAULT NULL,
  `localidad` varchar(75) DEFAULT NULL,
  `cp` int(11) DEFAULT NULL,
  `telefono` varchar(45) DEFAULT NULL,
  `celular` varchar(45) DEFAULT NULL,
  `fax` varchar(45) DEFAULT NULL,
  `mail` varchar(75) DEFAULT NULL,
  `contacto` varchar(75) DEFAULT NULL,
  `cuit` varchar(13) DEFAULT NULL,
  `idtiposiva` int(11) NOT NULL,
  `comentario` varchar(200) DEFAULT NULL,
  `valor` decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`idproveedores`),
  KEY `fktiposiva_idx` (`idtiposiva`),
  CONSTRAINT `fktiposiva` FOREIGN KEY (`idtiposiva`) REFERENCES `tiposiva` (`idtiposiva`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `proveedores`
--

LOCK TABLES `proveedores` WRITE;
/*!40000 ALTER TABLE `proveedores` DISABLE KEYS */;
INSERT INTO `proveedores` VALUES (1,'PROV PRUEB','DOM PRUEB','MAR DEL PLATA',7600,'123456','654321','','A@A.COM','CONT PRUE','30-71078591-7',1,'coment prueba',4.00);
/*!40000 ALTER TABLE `proveedores` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tiposcamion`
--

DROP TABLE IF EXISTS `tiposcamion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tiposcamion` (
  `idtiposcamion` int(11) NOT NULL AUTO_INCREMENT,
  `detalle` varchar(45) NOT NULL,
  PRIMARY KEY (`idtiposcamion`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tiposcamion`
--

LOCK TABLES `tiposcamion` WRITE;
/*!40000 ALTER TABLE `tiposcamion` DISABLE KEYS */;
/*!40000 ALTER TABLE `tiposcamion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tiposiva`
--

DROP TABLE IF EXISTS `tiposiva`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tiposiva` (
  `idtiposiva` int(11) NOT NULL AUTO_INCREMENT,
  `detalle` varchar(45) NOT NULL,
  `tipo` varchar(45) NOT NULL,
  PRIMARY KEY (`idtiposiva`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tiposiva`
--

LOCK TABLES `tiposiva` WRITE;
/*!40000 ALTER TABLE `tiposiva` DISABLE KEYS */;
INSERT INTO `tiposiva` VALUES (1,'RESPONSABLE INSCRIPTO','I'),(2,'RESPONSABLE NO INSCRIPTO','R'),(3,'EXENTO','E'),(4,'NO RESPONSABLE','N'),(5,'CONSUMIDOR FINAL','F'),(6,'RESPONSABLE MONOTRIBUTO','M'),(7,'SUJETO NO CATEGORIZADO','S');
/*!40000 ALTER TABLE `tiposiva` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `unidades`
--

DROP TABLE IF EXISTS `unidades`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `unidades` (
  `idunidades` int(11) NOT NULL,
  `detalle` varchar(45) NOT NULL,
  PRIMARY KEY (`idunidades`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `unidades`
--

LOCK TABLES `unidades` WRITE;
/*!40000 ALTER TABLE `unidades` DISABLE KEYS */;
/*!40000 ALTER TABLE `unidades` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping routines for database 'transportefortin'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-02-01 19:20:01
