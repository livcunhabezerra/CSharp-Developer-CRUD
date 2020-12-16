CREATE DATABASE `ecommerce` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;

CREATE TABLE `produto` (
  `ID` varchar(36) NOT NULL,
  `Codigo` varchar(30) NOT NULL,
  `Descricao` varchar(200) NOT NULL,
  `Preco` varchar(45) DEFAULT NULL,
  `Status` tinyint(1) NOT NULL,
  `IdDepartamento` varchar(36) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `Codigo_UNIQUE` (`Codigo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;