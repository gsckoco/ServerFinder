# ************************************************************
# Sequel Ace SQL dump
# Version 20062
#
# https://sequel-ace.com/
# https://github.com/Sequel-Ace/Sequel-Ace
#
# Host: localhost (MySQL 8.3.0)
# Database: serverfinder
# Generation Time: 2024-03-06 17:32:00 +0000
# ************************************************************


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
SET NAMES utf8mb4;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE='NO_AUTO_VALUE_ON_ZERO', SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


# Dump of table tbl_Company
# ------------------------------------------------------------

DROP TABLE IF EXISTS `tbl_Company`;

CREATE TABLE `tbl_Company` (
  `id` int NOT NULL AUTO_INCREMENT,
  `companyName` varchar(50) NOT NULL,
  `website` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

LOCK TABLES `tbl_Company` WRITE;
/*!40000 ALTER TABLE `tbl_Company` DISABLE KEYS */;

INSERT INTO `tbl_Company` (`id`, `companyName`, `website`)
VALUES
	(1,'Contabo','https://contabo.com'),
	(2,'Hetzner','https://hetzner.com'),
	(3,'Ionos','https://www.ionos.co.uk/');

/*!40000 ALTER TABLE `tbl_Company` ENABLE KEYS */;
UNLOCK TABLES;


# Dump of table tbl_Processors
# ------------------------------------------------------------

DROP TABLE IF EXISTS `tbl_Processors`;

CREATE TABLE `tbl_Processors` (
  `id` int NOT NULL AUTO_INCREMENT,
  `processorName` varchar(50) NOT NULL,
  `pCores` int NOT NULL,
  `eCores` int NOT NULL,
  `pThreads` int NOT NULL,
  `eThreads` int NOT NULL,
  `baseFreq` int NOT NULL DEFAULT '1000',
  `brand` varchar(20) NOT NULL DEFAULT 'Intel',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

LOCK TABLES `tbl_Processors` WRITE;
/*!40000 ALTER TABLE `tbl_Processors` DISABLE KEYS */;

INSERT INTO `tbl_Processors` (`id`, `processorName`, `pCores`, `eCores`, `pThreads`, `eThreads`, `baseFreq`, `brand`)
VALUES
	(1,'Ryzen 5 3600',6,0,12,0,1000,'AMD'),
	(2,'Ryzen 7 7700',8,0,16,0,1000,'AMD'),
	(3,'Ryzen 9 7950X3D',16,0,32,0,1000,'AMD'),
	(4,'EPYC 9454P',48,0,96,0,1000,'AMD'),
	(5,'Core i5-13500',6,8,12,8,1000,'Intel'),
	(6,'Core i9-13900',8,16,16,16,1000,'Intel'),
	(7,'Xeon Gold 5412U',24,0,48,0,1000,'Intel'),
	(8,'Altra Q80-30',80,0,80,0,1000,'Ampere'),
	(9,'4 vCPU',4,0,4,0,1000,'Virtual'),
	(10,'6 vCPU',6,0,6,0,1000,'Virtual'),
	(11,'8 vCPU',8,0,8,0,1000,'Virtual'),
	(12,'12 vCPU',12,0,12,0,1000,'Virtual'),
	(13,'16 vCPU',16,0,16,0,1000,'Virtual'),
	(14,'24 vCPU',24,0,24,0,1000,'Virtual'),
	(15,'2 vCPU',2,0,2,0,1000,'Virtual'),
	(16,'10 vCPU',10,0,10,0,1000,'Virtual'),
	(17,'18 vCPU',18,0,18,0,1000,'Virtual'),
	(18,'1 vCPU',1,0,1,0,1000,'Virtual');

/*!40000 ALTER TABLE `tbl_Processors` ENABLE KEYS */;
UNLOCK TABLES;


# Dump of table tbl_Rates
# ------------------------------------------------------------

DROP TABLE IF EXISTS `tbl_Rates`;

CREATE TABLE `tbl_Rates` (
  `currency` varchar(3) NOT NULL,
  `rate` float NOT NULL,
  PRIMARY KEY (`currency`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

LOCK TABLES `tbl_Rates` WRITE;
/*!40000 ALTER TABLE `tbl_Rates` DISABLE KEYS */;

INSERT INTO `tbl_Rates` (`currency`, `rate`)
VALUES
	('AED',3.98797),
	('AFN',78.726),
	('ALL',104.1),
	('AMD',438.627),
	('ANG',1.95727),
	('AOA',899.594),
	('ARS',917.804),
	('AUD',1.66915),
	('AWG',1.95658),
	('AZN',1.83575),
	('BAM',1.95764),
	('BBD',2.19284),
	('BDT',119.196),
	('BGN',1.95653),
	('BHD',0.409074),
	('BIF',3113.48),
	('BMD',1.08578),
	('BND',1.45982),
	('BOB',7.50424),
	('BRL',5.38342),
	('BSD',1.08606),
	('BTC',0.0000171139),
	('BTN',90.03),
	('BWP',14.8775),
	('BYN',3.55426),
	('BYR',21281.3),
	('BZD',2.18913),
	('CAD',1.47582),
	('CDF',3007.62),
	('CHF',0.958963),
	('CLF',0.038464),
	('CLP',1061.36),
	('CNY',7.81435),
	('COP',4286.23),
	('CRC',558.038),
	('CUC',1.08578),
	('CUP',28.7732),
	('CVE',110.372),
	('CZK',25.3366),
	('DJF',192.965),
	('DKK',7.45401),
	('DOP',63.8916),
	('DZD',146.154),
	('EGP',33.5525),
	('ERN',16.2867),
	('ETB',61.6399),
	('EUR',1),
	('FJD',2.44111),
	('FKP',0.854987),
	('GBP',0.854496),
	('GEL',2.87708),
	('GGP',0.854987),
	('GHS',13.8474),
	('GIP',0.854987),
	('GMD',73.8061),
	('GNF',9336.09),
	('GTQ',8.4821),
	('GYD',227.221),
	('HKD',8.49608),
	('HNL',26.8211),
	('HRK',7.63315),
	('HTG',143.99),
	('HUF',393.736),
	('IDR',17091.7),
	('ILS',3.89665),
	('IMP',0.854987),
	('INR',90.0099),
	('IQD',1422.64),
	('IRR',45635.4),
	('ISK',149.111),
	('JEP',0.854987),
	('JMD',168.864),
	('JOD',0.769789),
	('JPY',162.818),
	('KES',155.267),
	('KGS',97.1009),
	('KHR',4413.3),
	('KMF',493.515),
	('KPW',977.199),
	('KRW',1450.85),
	('KWD',0.333984),
	('KYD',0.905081),
	('KZT',486.864),
	('LAK',22677.9),
	('LBP',97255.6),
	('LKR',334.626),
	('LRD',208.471),
	('LSL',20.6958),
	('LTL',3.20603),
	('LVL',0.656779),
	('LYD',5.24616),
	('MAD',10.9259),
	('MDL',19.3098),
	('MGA',4891.72),
	('MKD',61.6681),
	('MMK',2280.72),
	('MNT',3692.1),
	('MOP',8.75132),
	('MRU',43.3331),
	('MUR',49.7399),
	('MVR',16.7126),
	('MWK',1828.28),
	('MXN',18.4075),
	('MYR',5.14121),
	('MZN',68.9446),
	('NAD',20.7352),
	('NGN',1694.92),
	('NIO',39.9689),
	('NOK',11.4752),
	('NPR',144.047),
	('NZD',1.78431),
	('OMR',0.417972),
	('PAB',1.08605),
	('PEN',4.10246),
	('PGK',4.14403),
	('PHP',60.7202),
	('PKR',303.357),
	('PLN',4.31183),
	('PYG',7939.73),
	('QAR',3.95306),
	('RON',4.97169),
	('RSD',117.194),
	('RUB',99.4956),
	('RWF',1389.15),
	('SAR',4.07214),
	('SBD',9.20303),
	('SCR',14.8021),
	('SDG',652.555),
	('SEK',11.2704),
	('SGD',1.45778),
	('SHP',1.3765),
	('SLE',24.6345),
	('SLL',24634.5),
	('SOS',620.523),
	('SRD',38.3531),
	('STD',22473.5),
	('SVC',9.50325),
	('SYP',14117.1),
	('SZL',20.5981),
	('THB',38.8735),
	('TJS',11.8814),
	('TMT',3.8111),
	('TND',3.38384),
	('TOP',2.5746),
	('TRY',34.3),
	('TTD',7.3641),
	('TWD',34.2982),
	('TZS',2768.75),
	('UAH',41.7076),
	('UGX',4252.14),
	('USD',1.08578),
	('UYU',42.3016),
	('UZS',13603.4),
	('VEF',3912450),
	('VES',39.1262),
	('VND',26821.5),
	('VUV',130.83),
	('WST',2.9891),
	('XAF',656.596),
	('XAG',0.045842),
	('XAU',0.00051),
	('XCD',2.93438),
	('XDR',0.818697),
	('XOF',656.596),
	('XPF',119.332),
	('YER',271.878),
	('ZAR',20.5997),
	('ZMK',9773.35),
	('ZMW',25.875),
	('ZWL',349.621);

/*!40000 ALTER TABLE `tbl_Rates` ENABLE KEYS */;
UNLOCK TABLES;


# Dump of table tbl_Servers
# ------------------------------------------------------------

DROP TABLE IF EXISTS `tbl_Servers`;

CREATE TABLE `tbl_Servers` (
  `id` int NOT NULL AUTO_INCREMENT,
  `serverName` varchar(50) NOT NULL,
  `ram` int NOT NULL,
  `isEcc` tinyint(1) NOT NULL,
  `storage` varchar(1024) NOT NULL DEFAULT '',
  `totalStorage` int NOT NULL DEFAULT '1024',
  `connectionSpeed` int NOT NULL DEFAULT '1000',
  `bandwidth` int NOT NULL DEFAULT '1000',
  `isCustomisable` tinyint(1) NOT NULL,
  `link` varchar(255) NOT NULL,
  `company` int NOT NULL,
  `processor` int NOT NULL,
  `processorCount` int NOT NULL DEFAULT '1',
  `price` decimal(18,2) NOT NULL,
  `currency` varchar(3) NOT NULL,
  `price_gbp` decimal(18,2) NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`id`),
  KEY `IX_tbl_Servers_company` (`company`),
  KEY `IX_tbl_Servers_processor` (`processor`),
  CONSTRAINT `FK_tbl_Servers_tbl_Company` FOREIGN KEY (`company`) REFERENCES `tbl_Company` (`id`),
  CONSTRAINT `FK_tbl_Servers_tbl_Processors` FOREIGN KEY (`processor`) REFERENCES `tbl_Processors` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

LOCK TABLES `tbl_Servers` WRITE;
/*!40000 ALTER TABLE `tbl_Servers` DISABLE KEYS */;

INSERT INTO `tbl_Servers` (`id`, `serverName`, `ram`, `isEcc`, `storage`, `totalStorage`, `connectionSpeed`, `bandwidth`, `isCustomisable`, `link`, `company`, `processor`, `processorCount`, `price`, `currency`, `price_gbp`)
VALUES
	(3,'AX41-NVME',64,0,'',1024,1000,1000,1,'https://www.hetzner.com/dedicated-rootserver/ax41-nvme/configurator/#/',2,1,1,37.30,'EUR',31.87),
	(4,'AX52',64,0,'N/A',2048,1000,1000,1,'https://www.hetzner.com/dedicated-rootserver/ax52/configurator/',2,2,1,59.00,'EUR',50.42),
	(5,'AX102',128,1,'',3932,1000,1000,1,'https://www.hetzner.com/dedicated-rootserver/ax102/configurator/',2,3,1,104.00,'EUR',88.87),
	(6,'AX162-R',256,1,'',3932,1000,1000,1,'https://www.hetzner.com/dedicated-rootserver/ax162-r/configurator/',2,4,1,199.00,'EUR',170.04),
	(7,'AX162-S',128,1,'',7864,1000,1000,1,'https://www.hetzner.com/dedicated-rootserver/ax162-s/configurator/',2,4,1,199.00,'EUR',170.04),
	(8,'EX44',64,0,'N/A',1024,1000,1000,1,'https://www.hetzner.com/dedicated-rootserver/ex44/configurator/',2,5,1,39.00,'EUR',33.33),
	(9,'EX101',64,1,'',3932,1000,1000,1,'https://www.hetzner.com/dedicated-rootserver/ex101/configurator/',2,6,1,84.00,'EUR',71.78),
	(10,'EX130-R',256,1,'N/A',3932,1000,1000,1,'https://www.hetzner.com/dedicated-rootserver/ax162-r/configurator/',2,7,1,134.00,'EUR',114.50),
	(11,'EX130-S',128,1,'N/A',7864,1000,1000,1,'https://www.hetzner.com/dedicated-rootserver/ax162-s/configurator/',2,7,1,134.00,'EUR',114.50),
	(13,'RX170',128,1,'N/A',1920,1000,1000,1,'https://www.hetzner.com/dedicated-rootserver/rx170/configurator/',2,8,1,169.00,'EUR',144.41),
	(14,'RX220',256,1,'N/A',7864,1000,1000,1,'https://www.hetzner.com/dedicated-rootserver/rx220/configurator/',2,2,1,219.00,'EUR',187.13),
	(15,'Cloud VPS 1',6,0,'',100,1000,1000,1,'https://contabo.com/en/vps/cloud-vps-1/',1,9,1,4.50,'EUR',3.85),
	(16,'Cloud VPS 2',16,0,'',200,1000,1000,1,'https://contabo.com/en/vps/cloud-vps-2/',1,10,1,9.50,'EUR',8.12),
	(17,'Cloud VPS 3',24,0,'N/A',300,1000,1000,1,'https://contabo.com/en/vps/cloud-vps-3/',1,11,1,14.00,'EUR',11.96),
	(18,'Cloud VPS 4',48,0,'n/a',400,1000,1000,1,'https://contabo.com/en/vps/cloud-vps-4/',1,12,1,26.00,'EUR',22.22),
	(19,'Cloud VPS 5',64,0,'',500,1000,1000,1,'https://contabo.com/en/vps/cloud-vps-5/',1,13,1,33.50,'EUR',28.63),
	(20,'Cloud VPS 6',120,0,'',600,1000,1000,1,'https://contabo.com/en/vps/cloud-vps-6/',1,14,1,61.50,'EUR',52.55),
	(21,'Storage VPS 1',3,0,'N/A',800,1000,1000,0,'https://contabo.com/en/storage-vps/storage-vps-1/',1,15,1,4.50,'EUR',3.85),
	(22,'Storage VPS 2',8,0,'N/A',800,1000,1000,0,'https://contabo.com/en/storage-vps/storage-vps-2/',1,9,1,9.50,'EUR',8.12),
	(23,'Storage VPS 3',12,0,'',2457,1000,1000,0,'https://contabo.com/en/storage-vps/storage-vps-3/',1,10,1,14.00,'EUR',11.96),
	(25,'Storage VPS 4',24,0,'',3276,1000,1000,0,'https://contabo.com/en/storage-vps/storage-vps-4/',1,16,1,26.00,'EUR',22.22),
	(26,'Storage VPS 5',32,0,'',4096,1000,1000,0,'https://contabo.com/en/storage-vps/storage-vps-5/',1,12,1,33.50,'EUR',28.63),
	(27,'Storage VPS 6',60,0,'',4608,1000,1000,0,'https://contabo.com/en/storage-vps/storage-vps-6/',1,10,1,61.50,'EUR',52.55),
	(28,'VPS Linux XS',1,0,'',10,1000,1000,0,'https://www.ionos.co.uk/server-configurator?__sendingdata=1&cart.action=add-bundle&cart.bundle=tariff-core-vps-linux-xs-bundle&packageselection=servers%2Fvps&linkId=ct.btn.order.tariff-core-vps-linux-xs&selected.datacenter=core-vps-datacenter-lhr',3,18,1,1.00,'GBP',1.00),
	(29,'VPS Linux S',2,0,'',80,1000,1000,0,'https://www.ionos.co.uk/server-configurator?__sendingdata=1&cart.action=add-bundle&cart.bundle=tariff-core-vps-linux-s-bundle&packageselection=servers%2Fvps&linkId=ct.btn.order.tariff-core-vps-linux-s&selected.datacenter=core-vps-datacenter-lhr',3,15,1,4.00,'GBP',4.00),
	(30,'VPS Linux M',4,0,'',160,1000,1000,0,'https://www.ionos.co.uk/server-configurator?__sendingdata=1&cart.action=add-bundle&cart.bundle=tariff-core-vps-linux-m-bundle&packageselection=servers%2Fvps&linkId=ct.btn.order.tariff-core-vps-linux-m&selected.datacenter=core-vps-datacenter-lhr',1,15,1,8.00,'GBP',8.00),
	(31,'VPS Linux L',8,0,'',240,1000,1000,0,'https://www.ionos.co.uk/server-configurator?__sendingdata=1&cart.action=add-bundle&cart.bundle=tariff-core-vps-linux-l-bundle&packageselection=servers%2Fvps&linkId=ct.btn.order.tariff-core-vps-linux-l&selected.datacenter=core-vps-datacenter-lhr',3,9,1,14.00,'GBP',14.00),
	(32,'VPS Linux XL',16,0,'',320,1000,1000,0,'https://www.ionos.co.uk/server-configurator?__sendingdata=1&cart.action=add-bundle&cart.bundle=tariff-core-vps-linux-xl-bundle&packageselection=servers%2Fvps&linkId=ct.btn.order.tariff-core-vps-linux-xl&selected.datacenter=core-vps-datacenter-lhr',3,11,1,26.00,'GBP',26.00),
	(33,'VPS Linux XXL',24,0,'',640,1000,1000,0,'https://www.ionos.co.uk/server-configurator?__sendingdata=1&cart.action=add-bundle&cart.bundle=tariff-core-vps-linux-xxl-bundle&packageselection=servers%2Fvps&linkId=ct.btn.order.tariff-core-vps-linux-xxl&selected.datacenter=core-vps-datacenter-lhr',3,12,1,48.00,'GBP',48.00);

/*!40000 ALTER TABLE `tbl_Servers` ENABLE KEYS */;
UNLOCK TABLES;



/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
