-- -----------------------------------------------------
-- Schema calculadoradb
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `calculadoradb` ;

-- -----------------------------------------------------
-- Schema calculadoradb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `calculadoradb` ;
USE `calculadoradb` ;

-- -----------------------------------------------------
-- Table `calculadoradb`.`calculos`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `calculadoradb`.`calculos` ;

CREATE TABLE IF NOT EXISTS `calculadoradb`.`calculos` (
  `id` INT NOT NULL,
  `expresion` VARCHAR(250) NOT NULL,
  `resultado` VARCHAR(250) NOT NULL,
  `fecha` TIMESTAMP NOT NULL,
  PRIMARY KEY (`id`))
;
