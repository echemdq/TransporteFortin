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
-- Table structure for table `contadores`
--

DROP TABLE IF EXISTS `contadores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `contadores` (
  `idcontadores` int(11) NOT NULL AUTO_INCREMENT,
  `detalle` varchar(45) NOT NULL,
  `nro` int(11) NOT NULL,
  PRIMARY KEY (`idcontadores`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `contadores`
--

LOCK TABLES `contadores` WRITE;
/*!40000 ALTER TABLE `contadores` DISABLE KEYS */;
INSERT INTO `contadores` VALUES (1,'ocarga',18);
/*!40000 ALTER TABLE `contadores` ENABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `empresas`
--

LOCK TABLES `empresas` WRITE;
/*!40000 ALTER TABLE `empresas` DISABLE KEYS */;
INSERT INTO `empresas` VALUES (1,'EMPRESA PRUEBA','DOMPRUEBA','LOCPRUEBA','tel1','tel2','cel1','A','compr');
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
  CONSTRAINT `fkidempresas` FOREIGN KEY (`idempresas`) REFERENCES `empresas` (`idempresas`) ON UPDATE CASCADE,
  CONSTRAINT `fkidtiposcamion` FOREIGN KEY (`idtiposcamion`) REFERENCES `tiposcamion` (`idtiposcamion`) ON UPDATE CASCADE,
  CONSTRAINT `idiva` FOREIGN KEY (`idtiposiva`) REFERENCES `tiposiva` (`idtiposiva`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `fleteros`
--

LOCK TABLES `fleteros` WRITE;
/*!40000 ALTER TABLE `fleteros` DISABLE KEYS */;
INSERT INTO `fleteros` VALUES (2,'1234','A11','A21','A31',71,'11','21','31','A@A.COM1',1,'AA1',2,'aq1111','aq1211','30-71078591-1',5);
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
  `valorizado` varchar(1) NOT NULL,
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
  PRIMARY KEY (`idordenescarga`),
  KEY `fksucursales_idx` (`idsucursales`),
  KEY `fkclientes_idx` (`idclientes`),
  KEY `fkfleteros_idx` (`idfleteros`),
  KEY `fkempresas_idx` (`idempresas`),
  KEY `fkunidades_idx` (`idunidades`),
  CONSTRAINT `fkclientes` FOREIGN KEY (`idclientes`) REFERENCES `clientes` (`idclientes`) ON UPDATE CASCADE,
  CONSTRAINT `fkempresas` FOREIGN KEY (`idempresas`) REFERENCES `empresas` (`idempresas`) ON UPDATE CASCADE,
  CONSTRAINT `fkfleteros` FOREIGN KEY (`idfleteros`) REFERENCES `fleteros` (`idfleteros`) ON UPDATE CASCADE,
  CONSTRAINT `fksucursales` FOREIGN KEY (`idsucursales`) REFERENCES `sucursales` (`idsucursales`) ON UPDATE CASCADE,
  CONSTRAINT `fkunidades` FOREIGN KEY (`idunidades`) REFERENCES `unidades` (`idunidades`) ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ordenescarga`
--

LOCK TABLES `ordenescarga` WRITE;
/*!40000 ALTER TABLE `ordenescarga` DISABLE KEYS */;
INSERT INTO `ordenescarga` VALUES (1,13,1,1,2,1,'yo','el','mdp','lala',0.00,'0',2,0,0.00,'p',0.00,'0',0.00,0.00,0.00,0.00,'',0.00,0.00,0,0,'0',NULL,'2017-02-16 00:00:00'),(2,16,1,1,2,1,'papa','aaa','pepe','lele',150075.00,'1',2,12,9775.00,'p',6.00,'0',117300.00,0.00,7038.00,202380.00,'',16865.00,0.00,0,0,'0',NULL,'2017-02-16 00:00:00'),(3,17,1,1,2,1,'assaas','asd','asas','assa',977.56,'1',2,1,99675.00,'p',6.00,'0',996.75,0.00,59.81,1567.85,'',156785.00,0.00,0,0,'0',NULL,'2017-02-16 00:00:00'),(4,18,1,1,2,1,'lalalalal','www','alalalalal','oaslsla',952.69,'1',2,1,12.25,'p',6.00,'0',12.25,0.00,0.74,13.75,'',13.75,0.00,0,0,'0',NULL,'2017-02-16 00:00:00');
/*!40000 ALTER TABLE `ordenescarga` ENABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
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
-- Table structure for table `sucursales`
--

DROP TABLE IF EXISTS `sucursales`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sucursales` (
  `idsucursales` int(11) NOT NULL AUTO_INCREMENT,
  `sucursal` varchar(100) NOT NULL,
  PRIMARY KEY (`idsucursales`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sucursales`
--

LOCK TABLES `sucursales` WRITE;
/*!40000 ALTER TABLE `sucursales` DISABLE KEYS */;
INSERT INTO `sucursales` VALUES (1,'mdp');
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

-- Dump completed on 2017-02-16 21:16:24
