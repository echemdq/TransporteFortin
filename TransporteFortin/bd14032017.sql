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
-- Table structure for table `accesos`
--

DROP TABLE IF EXISTS `accesos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `accesos` (
  `idaccesos` int(11) NOT NULL AUTO_INCREMENT,
  `acceso` varchar(100) NOT NULL,
  PRIMARY KEY (`idaccesos`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `accesos`
--

LOCK TABLES `accesos` WRITE;
/*!40000 ALTER TABLE `accesos` DISABLE KEYS */;
INSERT INTO `accesos` VALUES (1,'ABM FLETEROS'),(2,'ABM CLIENTES'),(3,'ABM EMPRESAS'),(4,'ABM PROVEEDORES'),(5,'EMITIR ORDEN DE CARGA'),(6,'CONSULTAR ORDEN DE CARGA'),(7,'ABM USUARIOS');
/*!40000 ALTER TABLE `accesos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `accesosusuario`
--

DROP TABLE IF EXISTS `accesosusuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `accesosusuario` (
  `idaccesosusuario` int(11) NOT NULL AUTO_INCREMENT,
  `idusuarios` int(11) NOT NULL,
  `idaccesos` int(11) NOT NULL,
  PRIMARY KEY (`idaccesosusuario`),
  KEY `fkidusuarios_idx` (`idusuarios`),
  KEY `fkidaccesos_idx` (`idaccesos`),
  CONSTRAINT `fkidaccesos` FOREIGN KEY (`idaccesos`) REFERENCES `accesos` (`idaccesos`) ON UPDATE CASCADE,
  CONSTRAINT `fkidusuarios` FOREIGN KEY (`idusuarios`) REFERENCES `usuarios` (`idusuarios`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `accesosusuario`
--

LOCK TABLES `accesosusuario` WRITE;
/*!40000 ALTER TABLE `accesosusuario` DISABLE KEYS */;
INSERT INTO `accesosusuario` VALUES (2,3,3),(3,3,2),(4,7,2),(5,8,2),(19,9,3),(20,9,4),(21,9,7),(22,9,6),(23,9,5),(24,9,2),(25,9,1);
/*!40000 ALTER TABLE `accesosusuario` ENABLE KEYS */;
UNLOCK TABLES;

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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
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
-- Table structure for table `conceptos`
--

DROP TABLE IF EXISTS `conceptos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `conceptos` (
  `codigo` int(11) NOT NULL,
  `descripcion` varchar(100) DEFAULT NULL,
  `doc` varchar(1) DEFAULT NULL,
  PRIMARY KEY (`codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `conceptos`
--

LOCK TABLES `conceptos` WRITE;
/*!40000 ALTER TABLE `conceptos` DISABLE KEYS */;
INSERT INTO `conceptos` VALUES (1,'Anticipo en Efectivo','D'),(2,'Nota de debito varias','D'),(3,'Debito por ajustes','D'),(4,'Nota de Credito','C'),(5,'Credito por ajuste','C'),(7,'Alquiler Acoplado','D'),(8,'Pago Alquiler Acoplado','C'),(9,'Seguro de Carga','D'),(10,'Pago','D'),(11,'Otros Debitos','D'),(12,'ENTREGA A CUENTA','C'),(13,'CANCELACION DE COMISION','C'),(14,'PAGO EN DESTINO','D'),(15,'IVA','D'),(16,'CREDITO POR PAGO EN DESTINO','C'),(17,'IVA','C'),(18,'pago de factura','C'),(19,'SUSPENDIDO','D'),(20,'cheque rechazado','D'),(945,'Débito por Anticipo','D'),(946,'Débito por Combustible','D'),(947,'Débito por Anulación O.C.','D'),(948,'Débito por Comisión','D'),(949,'Débito por Orden de Carga','D'),(995,'Crédito','C'),(996,'Crédito por Combustible','C'),(997,'Crédito por Anulación O.C.','C'),(999,'Crédito por Orden de Carga','C');
/*!40000 ALTER TABLE `conceptos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `configuraciones`
--

DROP TABLE IF EXISTS `configuraciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `configuraciones` (
  `idconfiguraciones` int(11) NOT NULL AUTO_INCREMENT,
  `detalle` varchar(45) NOT NULL,
  `valor` varchar(45) NOT NULL,
  PRIMARY KEY (`idconfiguraciones`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `configuraciones`
--

LOCK TABLES `configuraciones` WRITE;
/*!40000 ALTER TABLE `configuraciones` DISABLE KEYS */;
INSERT INTO `configuraciones` VALUES (1,'porcentaje','6');
/*!40000 ALTER TABLE `configuraciones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `contadores`
--

DROP TABLE IF EXISTS `contadores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `contadores` (
  `idcontadores` int(11) NOT NULL AUTO_INCREMENT,
  `detalle` varchar(45) NOT NULL,
  `nro` int(11) NOT NULL,
  `ptoventa` int(11) NOT NULL,
  PRIMARY KEY (`idcontadores`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contadores`
--

LOCK TABLES `contadores` WRITE;
/*!40000 ALTER TABLE `contadores` DISABLE KEYS */;
INSERT INTO `contadores` VALUES (2,'ocarga',22,13),(4,'ocarga',13,7),(5,'ocombustible',3,7),(6,'ocumbustible',0,13);
/*!40000 ALTER TABLE `contadores` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ctacteclientes`
--

DROP TABLE IF EXISTS `ctacteclientes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ctacteclientes` (
  `idctacteclientes` int(11) NOT NULL AUTO_INCREMENT,
  `idclientes` int(11) NOT NULL,
  `idconceptos` int(11) NOT NULL,
  `descripcion` varchar(150) DEFAULT NULL,
  `ptoventa` int(11) NOT NULL,
  `idordenescarga` int(11) DEFAULT NULL,
  `debe` decimal(10,2) NOT NULL,
  `haber` decimal(10,2) NOT NULL,
  `fecha` datetime NOT NULL,
  `idrecibos` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`idctacteclientes`),
  KEY `fkidclientes_idx` (`idclientes`),
  KEY `fkidconceptos_idx` (`idconceptos`),
  CONSTRAINT `fkidclientes` FOREIGN KEY (`idclientes`) REFERENCES `clientes` (`idclientes`) ON UPDATE CASCADE,
  CONSTRAINT `fkidconceptos` FOREIGN KEY (`idconceptos`) REFERENCES `conceptos` (`codigo`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ctacteclientes`
--

LOCK TABLES `ctacteclientes` WRITE;
/*!40000 ALTER TABLE `ctacteclientes` DISABLE KEYS */;
INSERT INTO `ctacteclientes` VALUES (1,1,949,'GS - Orden de Carga',7,15,2820.00,0.00,'2017-03-14 00:00:00',0),(2,1,15,'GS - IVA',7,15,2820.00,0.00,'2017-03-14 00:00:00',0),(3,1,949,'GS - Orden de Carga',7,16,780.00,0.00,'2017-03-14 00:00:00',0),(4,1,15,'GS - IVA',7,16,74.00,0.00,'2017-03-14 00:00:00',0),(5,1,997,'GS - Orden de Carga anulacion',7,16,0.00,780.00,'2017-03-14 20:26:37',0),(6,1,17,'GS - IVA anulacion',7,16,0.00,74.00,'2017-03-14 20:26:37',0);
/*!40000 ALTER TABLE `ctacteclientes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ctactefleteros`
--

DROP TABLE IF EXISTS `ctactefleteros`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ctactefleteros` (
  `idctactefleteros` int(11) NOT NULL AUTO_INCREMENT,
  `idfleteros` int(11) NOT NULL,
  `idempresas` int(11) NOT NULL,
  `fecha` datetime NOT NULL,
  `fecactual` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `idconceptos` int(11) NOT NULL,
  `descripcion` varchar(150) NOT NULL,
  `ptoventa` int(11) NOT NULL,
  `idordenescarga` int(11) DEFAULT NULL,
  `debe` decimal(10,2) NOT NULL,
  `haber` decimal(10,2) NOT NULL,
  `idrecibos` int(11) DEFAULT NULL,
  `idordenescombustible` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`idctactefleteros`),
  KEY `fkidf_idx` (`idfleteros`),
  KEY `fkide_idx` (`idempresas`),
  KEY `fkidc_idx` (`idconceptos`),
  KEY `fkidoc_idx` (`idordenescarga`),
  KEY `fkidr_idx` (`idrecibos`),
  CONSTRAINT `fkidc` FOREIGN KEY (`idconceptos`) REFERENCES `conceptos` (`codigo`) ON UPDATE CASCADE,
  CONSTRAINT `fkidf` FOREIGN KEY (`idfleteros`) REFERENCES `fleteros` (`idfleteros`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=44 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ctactefleteros`
--

LOCK TABLES `ctactefleteros` WRITE;
/*!40000 ALTER TABLE `ctactefleteros` DISABLE KEYS */;
INSERT INTO `ctactefleteros` VALUES (2,2,1,'2017-03-06 00:00:00','2017-03-07 01:06:59',999,'GS - Orden de Carga',7,9,0.00,97800.00,0,0),(3,2,1,'2017-03-06 00:00:00','2017-03-07 01:06:59',17,'GS - IVA',7,9,0.00,125.00,0,0),(4,2,1,'2017-03-06 00:00:00','2017-03-07 01:06:59',948,'GS - Comision',7,9,5868.00,0.00,0,0),(5,2,1,'2017-03-06 00:00:00','2017-03-07 22:10:45',999,'GS - Orden de Carga',0,4,0.00,225.00,0,0),(6,2,1,'2017-03-06 00:00:00','2017-03-07 22:10:45',17,'GS - IVA',0,4,0.00,20.00,0,0),(7,2,1,'2017-03-06 00:00:00','2017-03-07 22:10:45',948,'GS - Comision',0,4,13.50,0.00,0,0),(8,2,1,'2017-03-07 19:37:41','2017-03-07 22:37:41',947,'GS - Orden de Carga anulacion',0,4,225.00,0.00,0,0),(9,2,1,'2017-03-07 19:37:41','2017-03-07 22:37:41',15,'GS - IVA anulacion',0,4,20.00,0.00,0,0),(10,2,1,'2017-03-07 19:37:41','2017-03-07 22:37:41',997,'GS - Comision anulacion',0,4,0.00,13.50,0,0),(11,2,1,'2017-03-07 00:00:00','2017-03-07 22:45:27',999,'GS - Orden de Carga',7,11,0.00,777.00,0,0),(12,2,1,'2017-03-07 00:00:00','2017-03-07 22:45:27',17,'GS - IVA',7,11,0.00,10.00,0,0),(13,2,1,'2017-03-07 00:00:00','2017-03-07 22:45:27',948,'GS - Comision',7,11,46.62,0.00,0,0),(14,2,1,'2017-03-07 19:46:20','2017-03-07 22:46:20',947,'GS - Orden de Carga anulacion',7,11,777.00,0.00,0,0),(15,2,1,'2017-03-07 19:46:20','2017-03-07 22:46:20',15,'GS - IVA anulacion',7,11,10.00,0.00,0,0),(16,2,1,'2017-03-07 19:46:20','2017-03-07 22:46:20',997,'GS - Comision anulacion',7,11,0.00,46.62,0,0),(18,3,0,'2017-03-08 00:00:00','2017-03-08 22:35:39',999,'GS - Orden de Carga',7,13,0.00,123.00,0,0),(19,3,0,'2017-03-08 00:00:00','2017-03-08 22:35:39',948,'GS - Comision',7,13,6.15,0.00,0,0),(20,3,2,'2017-03-08 00:00:00','2017-03-08 22:36:43',999,'GS - Orden de Carga',7,14,0.00,2583.00,0,0),(21,3,2,'2017-03-08 00:00:00','2017-03-08 22:36:43',948,'GS - Comision',7,14,154.98,0.00,0,0),(22,3,2,'2017-03-09 18:30:29','2017-03-09 21:30:29',7,'Carga Manual - 10',7,NULL,100.00,0.00,NULL,0),(23,3,2,'2017-03-09 18:31:37','2017-03-09 21:31:37',7,'Carga Manual - proabndo',7,NULL,2600.02,0.00,NULL,0),(24,3,2,'2017-03-09 18:33:02','2017-03-09 21:33:02',13,'Carga Manual - opoa',7,NULL,0.00,272.75,NULL,0),(25,3,2,'2017-03-09 18:34:34','2017-03-09 21:34:34',7,'Carga Manual - ',7,NULL,1.00,0.00,NULL,0),(26,2,1,'2017-03-09 00:00:00','2017-03-09 23:16:06',946,'GS - Orden de Combustible',7,0,10.50,0.00,0,1),(27,2,1,'2017-03-13 00:00:00','2017-03-13 23:21:43',946,'GS - Orden de Combustible',7,0,105.00,0.00,0,2),(28,2,1,'2017-03-13 00:00:00','2017-03-14 00:02:33',946,'GS - Orden de Combustible',7,0,796.43,0.00,0,3),(29,2,1,'2017-03-14 00:00:00','2017-03-14 23:03:23',999,'GS - Orden de Carga',7,15,0.00,7824.00,0,0),(30,2,1,'2017-03-14 00:00:00','2017-03-14 23:03:23',17,'GS - IVA',7,15,0.00,100.00,0,0),(31,2,1,'2017-03-14 00:00:00','2017-03-14 23:03:23',948,'GS - Comision',7,15,469.44,0.00,0,0),(32,2,1,'2017-03-14 00:00:00','2017-03-14 23:10:48',999,'GS - Orden de Carga',7,16,0.00,420.00,0,0),(33,2,1,'2017-03-14 00:00:00','2017-03-14 23:10:48',17,'GS - IVA',7,16,0.00,16.00,0,0),(34,2,1,'2017-03-14 00:00:00','2017-03-14 23:10:48',948,'GS - Comision',7,16,25.20,0.00,0,0),(38,2,1,'2017-03-14 20:26:37','2017-03-14 23:26:37',947,'GS - Orden de Carga anulacion',7,16,420.00,0.00,0,0),(39,2,1,'2017-03-14 20:26:37','2017-03-14 23:26:37',15,'GS - IVA anulacion',7,16,16.00,0.00,0,0),(40,2,1,'2017-03-14 20:26:37','2017-03-14 23:26:37',997,'GS - Comision anulacion',7,16,0.00,25.20,0,0),(41,3,0,'2017-03-14 20:28:54','2017-03-14 23:28:54',947,'GS - Orden de Carga anulacion',7,13,123.00,0.00,0,0),(42,3,0,'2017-03-14 20:28:54','2017-03-14 23:28:54',997,'GS - Comision anulacion',7,13,0.00,6.15,0,0);
/*!40000 ALTER TABLE `ctactefleteros` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ctacteproveedores`
--

DROP TABLE IF EXISTS `ctacteproveedores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ctacteproveedores` (
  `idctacteproveedores` int(11) NOT NULL AUTO_INCREMENT,
  `idproveedores` int(11) NOT NULL,
  `idordenescombustible` int(11) DEFAULT NULL,
  `idrecibos` int(11) DEFAULT '0',
  `fecha` datetime NOT NULL,
  `idconceptos` int(11) NOT NULL,
  `descripcion` varchar(150) DEFAULT NULL,
  `debe` decimal(10,2) NOT NULL,
  `haber` decimal(10,2) NOT NULL,
  `ptoventa` int(11) NOT NULL,
  PRIMARY KEY (`idctacteproveedores`),
  KEY `fkidconcep_idx` (`idconceptos`),
  KEY `fkidprov_idx` (`idproveedores`),
  CONSTRAINT `fkidconcep` FOREIGN KEY (`idconceptos`) REFERENCES `conceptos` (`codigo`) ON UPDATE CASCADE,
  CONSTRAINT `fkidprov` FOREIGN KEY (`idproveedores`) REFERENCES `proveedores` (`idproveedores`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ctacteproveedores`
--

LOCK TABLES `ctacteproveedores` WRITE;
/*!40000 ALTER TABLE `ctacteproveedores` DISABLE KEYS */;
INSERT INTO `ctacteproveedores` VALUES (1,2,2,0,'2017-03-13 00:00:00',996,'GS - Orden de Combustible',0.00,105.00,7),(2,2,3,0,'2017-03-13 00:00:00',996,'GS - Orden de Combustible',0.00,796.43,7),(4,2,0,0,'2017-03-13 22:59:16',946,'Carga Manual - pruebaaa',756.68,0.00,7),(5,2,0,0,'2017-03-13 22:59:34',13,'Carga Manual - prueba',0.00,96.35,7);
/*!40000 ALTER TABLE `ctacteproveedores` ENABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `empresas`
--

LOCK TABLES `empresas` WRITE;
/*!40000 ALTER TABLE `empresas` DISABLE KEYS */;
INSERT INTO `empresas` VALUES (1,'EMPRESA PRUEBA','DOMPRUEBA','LOCPRUEBA','tel1','tel2','cel1','A','compr'),(2,'prueba','pru','pru',NULL,NULL,NULL,NULL,NULL);
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
  `cuit` varchar(13) DEFAULT NULL,
  `idtiposiva` int(11) NOT NULL,
  PRIMARY KEY (`idfleteros`),
  UNIQUE KEY `documento_UNIQUE` (`documento`),
  KEY `fkidempresas_idx` (`idempresas`),
  KEY `fkidtiposcamion_idx` (`idtiposcamion`),
  KEY `idiva_idx` (`idtiposiva`),
  CONSTRAINT `fkidtiposcamion` FOREIGN KEY (`idtiposcamion`) REFERENCES `tiposcamion` (`idtiposcamion`) ON UPDATE CASCADE,
  CONSTRAINT `idiva` FOREIGN KEY (`idtiposiva`) REFERENCES `tiposiva` (`idtiposiva`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `fleteros`
--

LOCK TABLES `fleteros` WRITE;
/*!40000 ALTER TABLE `fleteros` DISABLE KEYS */;
INSERT INTO `fleteros` VALUES (2,'1234','A11','A21','A31',71,'11','21','31','A@A.COM1',1,'AA1',2,'aq1111','aq1211','30-71078591-1',5),(3,'1233123','ASDAS','ASDASD','ADASD',213,'asd','123','213','',2,'',1,'','','  -        -',1);
/*!40000 ALTER TABLE `fleteros` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ordenescarga`
--

DROP TABLE IF EXISTS `ordenescarga`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ordenescarga` (
  `idordenescarga` int(11) NOT NULL AUTO_INCREMENT,
  `nrocarga` int(11) NOT NULL,
  `idsucursales` int(11) NOT NULL,
  `idclientes` int(11) NOT NULL,
  `idfleteros` int(11) NOT NULL,
  `idempresas` int(11) NOT NULL,
  `porcuentade` varchar(100) DEFAULT NULL,
  `productos` varchar(100) DEFAULT NULL,
  `origen` varchar(100) DEFAULT NULL,
  `destino` varchar(100) DEFAULT NULL,
  `valordeclarado` decimal(10,2) DEFAULT NULL,
  `valorizado` varchar(1) NOT NULL DEFAULT '0',
  `idunidades` int(11) NOT NULL,
  `cantidad` int(11) DEFAULT NULL,
  `valorunidad` decimal(10,2) DEFAULT NULL,
  `tipocomision` varchar(1) DEFAULT NULL,
  `valorcomision` decimal(10,2) DEFAULT NULL,
  `pagodestino` varchar(1) DEFAULT NULL,
  `totalviaje` decimal(10,2) DEFAULT NULL,
  `ivaviaje` decimal(10,2) DEFAULT NULL,
  `comision` decimal(10,2) DEFAULT NULL,
  `importecliente` decimal(10,2) DEFAULT NULL,
  `observaciones` varchar(300) DEFAULT NULL,
  `valorunidadcte` decimal(10,2) DEFAULT NULL,
  `ivacliente` decimal(10,2) DEFAULT NULL,
  `ptoventa` int(11) DEFAULT NULL,
  `puesto` int(11) DEFAULT NULL,
  `anulado` varchar(1) DEFAULT '0',
  `fecanula` datetime DEFAULT NULL,
  `fecha` datetime DEFAULT NULL,
  `fecactual` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `idusuarios` int(11) NOT NULL,
  PRIMARY KEY (`idordenescarga`),
  KEY `fksucursales_idx` (`idsucursales`),
  KEY `fkclientes_idx` (`idclientes`),
  KEY `fkfleteros_idx` (`idfleteros`),
  KEY `fkempresas_idx` (`idempresas`),
  KEY `fkunidades_idx` (`idunidades`),
  KEY `fkusuarios_idx` (`idusuarios`),
  CONSTRAINT `fkclientes` FOREIGN KEY (`idclientes`) REFERENCES `clientes` (`idclientes`) ON UPDATE CASCADE,
  CONSTRAINT `fkfleteros` FOREIGN KEY (`idfleteros`) REFERENCES `fleteros` (`idfleteros`) ON UPDATE CASCADE,
  CONSTRAINT `fksucursales` FOREIGN KEY (`idsucursales`) REFERENCES `sucursales` (`idsucursales`) ON UPDATE CASCADE,
  CONSTRAINT `fkunidades` FOREIGN KEY (`idunidades`) REFERENCES `unidades` (`idunidades`) ON UPDATE CASCADE,
  CONSTRAINT `fkusuarios` FOREIGN KEY (`idusuarios`) REFERENCES `usuarios` (`idusuarios`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ordenescarga`
--

LOCK TABLES `ordenescarga` WRITE;
/*!40000 ALTER TABLE `ordenescarga` DISABLE KEYS */;
INSERT INTO `ordenescarga` VALUES (1,20,1,1,2,1,'a','a','a','a',100.00,'0',2,0,0.00,'p',0.00,'0',0.00,0.00,0.00,0.00,'prueba ORDEN DE CARGA ANULADA  ORDEN DE CARGA ANULADA ',0.00,0.00,0,0,'1','2017-03-01 19:42:31','2017-02-21 00:00:00','2017-02-22 01:04:26',1),(2,21,2,1,2,1,'peapeoras','qpoiaspodia','asdpoa','poaksd',100.00,'0',2,0,0.00,'p',0.00,'0',0.00,0.00,0.00,0.00,'',0.00,0.00,7,2,'0',NULL,'2017-03-06 00:00:00','2017-03-06 22:49:52',1),(3,22,2,1,2,1,'asddddd','asd','sdddsa','asd',150.00,'0',2,0,0.00,'p',0.00,'0',0.00,0.00,0.00,0.00,'',0.00,0.00,7,2,'0',NULL,'2017-03-06 00:00:00','2017-03-06 22:52:46',9),(4,1,2,1,2,1,'','','','',0.00,'1',2,15,15.00,'p',6.00,'0',225.00,20.00,13.50,225.00,'',15.00,20.00,7,2,'0',NULL,'2017-03-06 00:00:00','2017-03-06 23:32:21',9),(5,2,2,1,2,1,'','','','',0.00,'1',2,1,10.00,'p',6.00,'0',10.00,0.00,0.60,10.00,'',10.00,0.00,7,2,'0',NULL,'2017-03-06 00:00:00','2017-03-07 00:31:14',9),(6,3,2,1,2,1,'retira','prod','ori','dest',150.00,'1',2,10,666.00,'p',6.00,'0',6660.00,100.00,399.60,6500.00,'',650.00,0.00,7,2,'0',NULL,'2017-03-06 00:00:00','2017-03-07 01:03:57',9),(7,4,2,1,2,1,'retira','prod','ori','dest',150.00,'1',2,10,666.00,'p',6.00,'0',6660.00,100.00,399.60,6500.00,'',650.00,0.00,7,2,'0',NULL,'2017-03-06 00:00:00','2017-03-07 01:04:25',9),(8,5,2,1,2,1,'lasdlkaslda','jhasdkjas','lkasdlkj','pjaslk',5555.00,'1',2,150,652.00,'p',6.00,'0',97800.00,125.00,5868.00,54750.00,'',365.00,0.00,7,2,'0',NULL,'2017-03-06 00:00:00','2017-03-07 01:06:01',9),(9,6,2,1,2,1,'lasdlkaslda','jhasdkjas','lkasdlkj','pjaslk',5555.00,'1',2,150,652.00,'p',6.00,'0',97800.00,125.00,5868.00,54750.00,'',365.00,0.00,7,2,'0',NULL,'2017-03-06 00:00:00','2017-03-07 01:06:59',9),(10,7,2,1,2,1,'ezequiel','prueba','mdp','bahia',100.00,'1',2,10,100.00,'p',6.00,'0',1000.00,10.00,60.00,1500.00,'',150.00,15.00,7,2,'0',NULL,'2017-03-07 00:00:00','2017-03-07 21:16:45',9),(11,8,2,1,2,1,'','','','',0.00,'1',2,1,777.00,'p',6.00,'0',777.00,10.00,46.62,777.00,' ORDEN DE CARGA ANULADA ',777.00,90.00,7,2,'1','2017-03-07 19:46:20','2017-03-07 00:00:00','2017-03-07 22:45:27',9),(13,10,2,1,3,0,'','','','',0.00,'1',2,1,123.00,'p',5.00,'0',123.00,0.00,6.15,123.00,' ORDEN DE CARGA ANULADA ',123.00,0.00,7,2,'1','2017-03-14 20:28:54','2017-03-08 00:00:00','2017-03-08 22:32:57',9),(14,11,2,1,3,2,'','','','',0.00,'1',2,21,123.00,'p',6.00,'0',2583.00,0.00,154.98,6741.00,'',321.00,0.00,7,2,'0',NULL,'2017-03-08 00:00:00','2017-03-08 22:36:43',9),(15,12,2,1,2,1,'','','','',0.00,'1',2,12,652.00,'p',6.00,'0',7824.00,100.00,469.44,2820.00,'',235.00,150.00,7,2,'0',NULL,'2017-03-14 00:00:00','2017-03-14 23:03:23',9),(16,13,2,1,2,1,'','','','',0.00,'1',2,12,35.00,'p',6.00,'0',420.00,16.00,25.20,780.00,' ORDEN DE CARGA ANULADA ',65.00,74.00,7,2,'1','2017-03-14 20:26:37','2017-03-14 00:00:00','2017-03-14 23:04:32',9);
/*!40000 ALTER TABLE `ordenescarga` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ordenescombustible`
--

DROP TABLE IF EXISTS `ordenescombustible`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ordenescombustible` (
  `idordenescombustible` int(11) NOT NULL AUTO_INCREMENT,
  `nro` int(11) NOT NULL,
  `fecha` datetime NOT NULL,
  `idproveedores` int(11) NOT NULL,
  `idfleteros` int(11) NOT NULL,
  `preciocombustible` decimal(10,2) NOT NULL,
  `litros` decimal(10,2) NOT NULL,
  `ptoventa` int(11) NOT NULL,
  PRIMARY KEY (`idordenescombustible`),
  KEY `fkidproveedores_idx` (`idproveedores`),
  KEY `fkidfleteros_idx` (`idfleteros`),
  CONSTRAINT `fkidfleteros` FOREIGN KEY (`idfleteros`) REFERENCES `fleteros` (`idfleteros`) ON UPDATE CASCADE,
  CONSTRAINT `fkidproveedores` FOREIGN KEY (`idproveedores`) REFERENCES `proveedores` (`idproveedores`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ordenescombustible`
--

LOCK TABLES `ordenescombustible` WRITE;
/*!40000 ALTER TABLE `ordenescombustible` DISABLE KEYS */;
INSERT INTO `ordenescombustible` VALUES (1,1,'2017-03-09 00:00:00',2,2,10.50,1.00,7),(2,2,'2017-03-13 00:00:00',2,2,10.50,10.00,7),(3,3,'2017-03-13 00:00:00',2,2,10.50,75.85,7);
/*!40000 ALTER TABLE `ordenescombustible` ENABLE KEYS */;
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
INSERT INTO `proveedores` VALUES (1,'PROV PRUEB','DOM PRUEB','MAR DEL PLATA',7600,'123456','654321','','A@A.COM','CONT PRUE','30-71078591-7',1,'coment prueba',4.00),(2,'PROV PRU','ASD','ASD',123,'123','123','123','ASD','','  -        -',1,'',10.50);
/*!40000 ALTER TABLE `proveedores` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `puestos`
--

DROP TABLE IF EXISTS `puestos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `puestos` (
  `idpuestos` int(11) NOT NULL AUTO_INCREMENT,
  `puesto` varchar(45) NOT NULL,
  `idsucursales` int(11) NOT NULL,
  PRIMARY KEY (`idpuestos`),
  KEY `fkidsuc_idx` (`idsucursales`),
  CONSTRAINT `fkidsuc` FOREIGN KEY (`idsucursales`) REFERENCES `sucursales` (`idsucursales`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `puestos`
--

LOCK TABLES `puestos` WRITE;
/*!40000 ALTER TABLE `puestos` DISABLE KEYS */;
INSERT INTO `puestos` VALUES (1,'xx',1),(2,'ezepuesto',2);
/*!40000 ALTER TABLE `puestos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `recibos`
--

DROP TABLE IF EXISTS `recibos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `recibos` (
  `idrecibos` int(11) NOT NULL AUTO_INCREMENT,
  `fecha` datetime NOT NULL,
  `concepto` int(11) NOT NULL,
  `nro` int(11) NOT NULL,
  `importe` decimal(10,2) NOT NULL,
  `idfleteros` int(11) NOT NULL,
  `comentarios` varchar(150) DEFAULT NULL,
  `ptoventa` int(11) NOT NULL,
  PRIMARY KEY (`idrecibos`),
  KEY `fkidflet_idx` (`idfleteros`),
  CONSTRAINT `fkidflet` FOREIGN KEY (`idfleteros`) REFERENCES `fleteros` (`idfleteros`) ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recibos`
--

LOCK TABLES `recibos` WRITE;
/*!40000 ALTER TABLE `recibos` DISABLE KEYS */;
/*!40000 ALTER TABLE `recibos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sucursales`
--

DROP TABLE IF EXISTS `sucursales`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sucursales` (
  `idsucursales` int(11) NOT NULL AUTO_INCREMENT,
  `sucursal` varchar(100) NOT NULL,
  `ptoventa` int(11) NOT NULL,
  PRIMARY KEY (`idsucursales`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sucursales`
--

LOCK TABLES `sucursales` WRITE;
/*!40000 ALTER TABLE `sucursales` DISABLE KEYS */;
INSERT INTO `sucursales` VALUES (1,'MAR DEL PLATA',13),(2,'ROSARIO',7);
/*!40000 ALTER TABLE `sucursales` ENABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tiposcamion`
--

LOCK TABLES `tiposcamion` WRITE;
/*!40000 ALTER TABLE `tiposcamion` DISABLE KEYS */;
INSERT INTO `tiposcamion` VALUES (1,'full'),(2,'simple');
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
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;
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
  `idunidades` int(11) NOT NULL AUTO_INCREMENT,
  `detalle` varchar(45) NOT NULL,
  PRIMARY KEY (`idunidades`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `unidades`
--

LOCK TABLES `unidades` WRITE;
/*!40000 ALTER TABLE `unidades` DISABLE KEYS */;
INSERT INTO `unidades` VALUES (1,'pallet'),(2,'kgs');
/*!40000 ALTER TABLE `unidades` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `usuarios` (
  `idusuarios` int(11) NOT NULL AUTO_INCREMENT,
  `usuario` varchar(45) NOT NULL,
  `contrasena` varchar(45) NOT NULL,
  PRIMARY KEY (`idusuarios`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuarios`
--

LOCK TABLES `usuarios` WRITE;
/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` VALUES (1,'eze','eze'),(2,'gua','gua'),(3,'fer','fer'),(4,'EZEQUIEL','EZEQUIEL'),(5,'PRUEBA','PRUEBA'),(6,'a','a'),(7,'aa','aa'),(8,'bb','bb'),(9,'cc','asd');
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;
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

-- Dump completed on 2017-03-14 20:39:58
