-- MySQL Script generated by MySQL Workbench
-- Tue Mar 24 16:56:59 2020
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema bdd_revues
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema bdd_revues
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `bdd_revues` DEFAULT CHARACTER SET utf8mb4;
USE `bdd_revues` ;
 
-- -----------------------------------------------------
-- Table `bdd_revues`.`revues`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bdd_revues`.`revues` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nom` VARCHAR(45) NULL,
  `annee` DATE NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `bdd_revues`.`articles`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bdd_revues`.`articles` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `titre` VARCHAR(45) NULL,
  `contenu` VARCHAR(200) NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `bdd_revues`.`auteurs`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bdd_revues`.`auteurs` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nom` VARCHAR(45) NULL,
  `prenom` VARCHAR(45) NULL,
  `email` VARCHAR(45) NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `bdd_revues`.`ecrit`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bdd_revues`.`ecrit` (
  `auteurs_id` INT NOT NULL,
  `articles_id` INT NOT NULL,
  PRIMARY KEY (`auteurs_id`, `articles_id`),
  INDEX `fk_auteurs_has_articles_articles1_idx` (`articles_id` ASC) ,
  INDEX `fk_auteurs_has_articles_auteurs1_idx` (`auteurs_id` ASC) ,
  CONSTRAINT `fk_auteurs_has_articles_auteurs1`
    FOREIGN KEY (`auteurs_id`)
    REFERENCES `bdd_revues`.`auteurs` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_auteurs_has_articles_articles1`
    FOREIGN KEY (`articles_id`)
    REFERENCES `bdd_revues`.`articles` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `bdd_revues`.`numero`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bdd_revues`.`numero` (
  `articles_id` INT NOT NULL,
  `revues_id` INT NOT NULL,
  `page_debut` INT NULL,
  `page_fin` INT NULL,
  PRIMARY KEY (`articles_id`, `revues_id`),
  INDEX `fk_articles_has_revues_revues1_idx` (`revues_id` ASC) ,
  INDEX `fk_articles_has_revues_articles1_idx` (`articles_id` ASC, `page_debut` ASC, `page_fin` ASC) ,
  CONSTRAINT `fk_articles_has_revues_articles1`
    FOREIGN KEY (`articles_id` , `page_debut` , `page_fin`)
    REFERENCES `bdd_revues`.`articles` (`id` , `id` , `id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_articles_has_revues_revues1`
    FOREIGN KEY (`revues_id`)
    REFERENCES `bdd_revues`.`revues` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
