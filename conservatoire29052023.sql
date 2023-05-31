-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1
-- Généré le : lun. 29 mai 2023 à 13:48
-- Version du serveur : 10.4.24-MariaDB
-- Version de PHP : 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `conservatoire4`
--

-- --------------------------------------------------------

--
-- Structure de la table `eleve`
--

CREATE TABLE `eleve` (
  `IDELEVE` int(11) NOT NULL,
  `NIVEAU` int(11) NOT NULL,
  `BOURSE` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `eleve`
--

INSERT INTO `eleve` (`IDELEVE`, `NIVEAU`, `BOURSE`) VALUES
(4, 1, 0),
(5, 2, 0),
(6, 3, 1),
(7, 4, 1),
(8, 1, 0),
(9, 2, 1),
(10, 3, 0),
(11, 4, 1),
(12, 1, 0),
(13, 2, 1),
(14, 3, 0),
(15, 4, 1),
(20, 2, 1),
(21, 2, 1);

-- --------------------------------------------------------

--
-- Structure de la table `heure`
--

CREATE TABLE `heure` (
  `TRANCHE` char(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `heure`
--

INSERT INTO `heure` (`TRANCHE`) VALUES
('10h-11h'),
('10h-12h'),
('11h-12h'),
('13h-14h'),
('13h-15h'),
('14h-15h'),
('15h-16h'),
('15h-17h'),
('16h-17h'),
('17h-18h'),
('17h-19h'),
('18h-19h');

-- --------------------------------------------------------

--
-- Structure de la table `inscription`
--

CREATE TABLE `inscription` (
  `IDPROF` int(11) NOT NULL,
  `IDELEVE` int(11) NOT NULL,
  `NUMSEANCE` int(11) NOT NULL,
  `DATEINSCRIPTION` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `inscription`
--

INSERT INTO `inscription` (`IDPROF`, `IDELEVE`, `NUMSEANCE`, `DATEINSCRIPTION`) VALUES
(1, 4, 1, '2023-04-06'),
(1, 7, 4, '2023-05-24'),
(1, 8, 1, '2023-04-06'),
(1, 11, 1, '2023-05-23'),
(1, 12, 1, '2023-04-06'),
(1, 15, 1, '2023-05-23');

-- --------------------------------------------------------

--
-- Structure de la table `instrument`
--

CREATE TABLE `instrument` (
  `LIBELLE` char(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `instrument`
--

INSERT INTO `instrument` (`LIBELLE`) VALUES
('Accordéon'),
('Basse'),
('Batterie'),
('Flûte'),
('Guitare'),
('Harpe'),
('Piano'),
('Saxophone'),
('Trompette'),
('Violon');

-- --------------------------------------------------------

--
-- Structure de la table `jour`
--

CREATE TABLE `jour` (
  `JOUR` char(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `jour`
--

INSERT INTO `jour` (`JOUR`) VALUES
('jeudi'),
('lundi'),
('mardi'),
('mercredi'),
('samedi'),
('vendredi');

-- --------------------------------------------------------

--
-- Structure de la table `login`
--

CREATE TABLE `login` (
  `id` int(5) NOT NULL,
  `indentifiant` varchar(30) DEFAULT NULL,
  `mdp` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Déchargement des données de la table `login`
--

INSERT INTO `login` (`id`, `indentifiant`, `mdp`) VALUES
(1, 'GuilhermeAdmin', 'aa36dc6e81e2ac7ad03e12fedcb6a2c0'),
(2, 'GuilhermeAdmin', '746ea4028f2c438b5798afdd9ae74479');

-- --------------------------------------------------------

--
-- Structure de la table `niveau`
--

CREATE TABLE `niveau` (
  `NIVEAU` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `niveau`
--

INSERT INTO `niveau` (`NIVEAU`) VALUES
(1),
(2),
(3),
(4);

-- --------------------------------------------------------

--
-- Structure de la table `payer`
--

CREATE TABLE `payer` (
  `IDPROF` int(11) NOT NULL,
  `IDELEVE` int(11) NOT NULL,
  `NUMSEANCE` int(11) NOT NULL,
  `LIBELLE` char(32) NOT NULL,
  `DATEPAIEMENT` date NOT NULL,
  `PAYE` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `payer`
--

INSERT INTO `payer` (`IDPROF`, `IDELEVE`, `NUMSEANCE`, `LIBELLE`, `DATEPAIEMENT`, `PAYE`) VALUES
(1, 4, 1, 'avril-juin', '2000-01-01', 0),
(1, 4, 1, 'janvier-avril', '2023-04-27', 1),
(1, 4, 1, 'septembre-décembre', '2022-11-21', 1);

-- --------------------------------------------------------

--
-- Structure de la table `personne`
--

CREATE TABLE `personne` (
  `ID` int(11) NOT NULL,
  `NOM` char(32) DEFAULT NULL,
  `PRENOM` char(32) DEFAULT NULL,
  `TEL` varchar(14) DEFAULT NULL,
  `MAIL` char(32) DEFAULT NULL,
  `ADRESSE` char(32) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `personne`
--

INSERT INTO `personne` (`ID`, `NOM`, `PRENOM`, `TEL`, `MAIL`, `ADRESSE`) VALUES
(1, 'Dupont', 'Edouard', '0123456789', 'edouard.dupont@example.com', '12 rue de la Paix'),
(2, 'Martin', 'Marie', '0234567890', 'marie.martin@example.com', '24 avenue des Champs-Élysées'),
(3, 'Durand', 'Pierre', '0345678901', 'pierre.durand@example.com', '36 rue du Faubourg Saint-Honoré'),
(4, 'Lefebvre', 'Sophie', '0456789012', 'sophie.lefebvre@example.com', '48 boulevard Haussmann'),
(5, 'Leroy', 'Antoine', '0567890123', 'antoine.leroy@example.com', '60 avenue Montaigne'),
(6, 'Moreau', 'Isabelle', '0678901234', 'isabelle.moreau@example.com', '72 rue de Rivoli'),
(7, 'Petit', 'François', '0789012345', 'francois.petit@example.com', '84 boulevard des Invalides'),
(8, 'Roux', 'Émilie', '0890123456', 'emilie.roux@example.com', '96 rue de la Pompe'),
(9, 'Sauvage', 'Thierry', '0901234567', 'thierry.sauvage@example.com', '108 avenue des Ternes'),
(10, 'Simon', 'Camille', '0123456789', 'camille.simon@example.com', '120 rue de la Roquette'),
(11, 'Tanguy', 'Lucie', '0234567890', 'lucie.tanguy@example.com', '132 avenue des Gobelins'),
(12, 'Thomas', 'Guillaume', '0345678901', 'guillaume.thomas@example.com', '144 rue Saint-Antoine'),
(13, 'Vidal', 'Caroline', '0456789012', 'caroline.vidal@example.com', '156 boulevard Saint-Germain'),
(14, 'Boucher', 'Alexandre', '0567890123', 'alexandre.boucher@example.com', '168 avenue de Clichy'),
(15, 'Chevalier', 'Sophie', '0678901234', 'sophie.chevalier@example.com', '180 rue de la Convention'),
(16, 'nomtest', 'prenomtest', 'teltest', 'mailtest', 'adressetest'),
(17, 'test2', 'test2', 'test2', 'test2@test', 'test2 test2'),
(18, 'test3', 'test3', 'test3', 'test3@test3', 'test3 test3'),
(19, 'test3', 'test3', 'test3', 'test3@test3', 'test3 test3'),
(20, 'test4', 'test4', '85465416', 'foahbfg', 'oiahngfa'),
(21, 'test4', 'test4', '85465416', 'foahbfg', 'oiahngfa');

-- --------------------------------------------------------

--
-- Structure de la table `prof`
--

CREATE TABLE `prof` (
  `IDPROF` int(11) NOT NULL,
  `INSTRUMENT` char(32) NOT NULL,
  `SALAIRE` double(6,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `prof`
--

INSERT INTO `prof` (`IDPROF`, `INSTRUMENT`, `SALAIRE`) VALUES
(1, 'Basse', 1000.00),
(2, 'Batterie', 1200.00),
(3, 'Piano', 1400.00),
(17, 'Basse', 1000.00),
(19, 'Trompette', 1100.00);

-- --------------------------------------------------------

--
-- Structure de la table `seance`
--

CREATE TABLE `seance` (
  `IDPROF` int(11) NOT NULL,
  `NUMSEANCE` int(11) NOT NULL,
  `TRANCHE` char(32) NOT NULL,
  `JOUR` char(32) NOT NULL,
  `NIVEAU` int(11) NOT NULL,
  `CAPACITE` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `seance`
--

INSERT INTO `seance` (`IDPROF`, `NUMSEANCE`, `TRANCHE`, `JOUR`, `NIVEAU`, `CAPACITE`) VALUES
(1, 1, '10h-11h', 'lundi', 1, 10),
(1, 4, '11h-12h', 'mardi', 4, 3),
(2, 2, '10h-11h', 'mardi', 2, 10),
(3, 3, '10h-11h', 'vendredi', 4, 5);

-- --------------------------------------------------------

--
-- Structure de la table `trim`
--

CREATE TABLE `trim` (
  `LIBELLE` char(32) NOT NULL,
  `DATEFIN` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `trim`
--

INSERT INTO `trim` (`LIBELLE`, `DATEFIN`) VALUES
('avril-juin', '2023-06-21'),
('janvier-avril', '2023-04-23'),
('septembre-décembre', '2022-12-17');

-- --------------------------------------------------------

--
-- Doublure de structure pour la vue `veleve`
-- (Voir ci-dessous la vue réelle)
--
CREATE TABLE `veleve` (
`id` int(11)
,`nom` char(32)
,`prenom` char(32)
,`tel` varchar(14)
,`mail` char(32)
,`adresse` char(32)
,`niveau` int(11)
,`bourse` int(11)
);

-- --------------------------------------------------------

--
-- Doublure de structure pour la vue `vprof`
-- (Voir ci-dessous la vue réelle)
--
CREATE TABLE `vprof` (
`id` int(11)
,`nom` char(32)
,`prenom` char(32)
,`tel` varchar(14)
,`mail` char(32)
,`adresse` char(32)
,`instrument` char(32)
,`salaire` double(6,2)
);

-- --------------------------------------------------------

--
-- Structure de la vue `veleve`
--
DROP TABLE IF EXISTS `veleve`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `veleve`  AS SELECT `personne`.`ID` AS `id`, `personne`.`NOM` AS `nom`, `personne`.`PRENOM` AS `prenom`, `personne`.`TEL` AS `tel`, `personne`.`MAIL` AS `mail`, `personne`.`ADRESSE` AS `adresse`, `eleve`.`NIVEAU` AS `niveau`, `eleve`.`BOURSE` AS `bourse` FROM (`personne` join `eleve` on(`personne`.`ID` = `eleve`.`IDELEVE`))  ;

-- --------------------------------------------------------

--
-- Structure de la vue `vprof`
--
DROP TABLE IF EXISTS `vprof`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `vprof`  AS SELECT `personne`.`ID` AS `id`, `personne`.`NOM` AS `nom`, `personne`.`PRENOM` AS `prenom`, `personne`.`TEL` AS `tel`, `personne`.`MAIL` AS `mail`, `personne`.`ADRESSE` AS `adresse`, `prof`.`INSTRUMENT` AS `instrument`, `prof`.`SALAIRE` AS `salaire` FROM (`personne` join `prof` on(`personne`.`ID` = `prof`.`IDPROF`))  ;

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `eleve`
--
ALTER TABLE `eleve`
  ADD PRIMARY KEY (`IDELEVE`),
  ADD KEY `I_FK_ELEVE_NIVEAU` (`NIVEAU`);

--
-- Index pour la table `heure`
--
ALTER TABLE `heure`
  ADD PRIMARY KEY (`TRANCHE`);

--
-- Index pour la table `inscription`
--
ALTER TABLE `inscription`
  ADD PRIMARY KEY (`IDPROF`,`IDELEVE`,`NUMSEANCE`),
  ADD KEY `I_FK_INSCRIPTION_ELEVE` (`IDELEVE`),
  ADD KEY `I_FK_INSCRIPTION_SEANCE` (`IDPROF`,`NUMSEANCE`),
  ADD KEY `fk_numSeance` (`NUMSEANCE`);

--
-- Index pour la table `instrument`
--
ALTER TABLE `instrument`
  ADD PRIMARY KEY (`LIBELLE`);

--
-- Index pour la table `jour`
--
ALTER TABLE `jour`
  ADD PRIMARY KEY (`JOUR`);

--
-- Index pour la table `login`
--
ALTER TABLE `login`
  ADD PRIMARY KEY (`id`);

--
-- Index pour la table `niveau`
--
ALTER TABLE `niveau`
  ADD PRIMARY KEY (`NIVEAU`),
  ADD KEY `NIVEAU` (`NIVEAU`);

--
-- Index pour la table `payer`
--
ALTER TABLE `payer`
  ADD PRIMARY KEY (`IDPROF`,`IDELEVE`,`NUMSEANCE`,`LIBELLE`),
  ADD KEY `I_FK_PAYER_INSCRIPTION` (`IDPROF`,`IDELEVE`,`NUMSEANCE`),
  ADD KEY `I_FK_PAYER_TRIM` (`LIBELLE`),
  ADD KEY `fk_paye_eleve` (`IDELEVE`),
  ADD KEY `fk_paye_numSeance` (`NUMSEANCE`);

--
-- Index pour la table `personne`
--
ALTER TABLE `personne`
  ADD PRIMARY KEY (`ID`);

--
-- Index pour la table `prof`
--
ALTER TABLE `prof`
  ADD PRIMARY KEY (`IDPROF`),
  ADD KEY `I_FK_PROF_INSTRUMENT` (`INSTRUMENT`);

--
-- Index pour la table `seance`
--
ALTER TABLE `seance`
  ADD PRIMARY KEY (`IDPROF`,`NUMSEANCE`),
  ADD KEY `I_FK_SEANCE_JOUR` (`JOUR`),
  ADD KEY `I_FK_SEANCE_NIVEAU` (`NIVEAU`),
  ADD KEY `I_FK_SEANCE_PROF` (`IDPROF`),
  ADD KEY `fk_tranche` (`TRANCHE`),
  ADD KEY `NUMSEANCE` (`NUMSEANCE`);

--
-- Index pour la table `trim`
--
ALTER TABLE `trim`
  ADD PRIMARY KEY (`LIBELLE`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `login`
--
ALTER TABLE `login`
  MODIFY `id` int(5) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT pour la table `personne`
--
ALTER TABLE `personne`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT pour la table `seance`
--
ALTER TABLE `seance`
  MODIFY `NUMSEANCE` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `eleve`
--
ALTER TABLE `eleve`
  ADD CONSTRAINT `fk_idEleve` FOREIGN KEY (`IDELEVE`) REFERENCES `personne` (`ID`),
  ADD CONSTRAINT `fk_niveau` FOREIGN KEY (`NIVEAU`) REFERENCES `niveau` (`NIVEAU`);

--
-- Contraintes pour la table `inscription`
--
ALTER TABLE `inscription`
  ADD CONSTRAINT `fk_insc_eleve` FOREIGN KEY (`IDELEVE`) REFERENCES `eleve` (`IDELEVE`),
  ADD CONSTRAINT `fk_inscr_prof` FOREIGN KEY (`IDPROF`) REFERENCES `prof` (`IDPROF`),
  ADD CONSTRAINT `fk_inscr_seance` FOREIGN KEY (`NUMSEANCE`) REFERENCES `seance` (`NUMSEANCE`);

--
-- Contraintes pour la table `payer`
--
ALTER TABLE `payer`
  ADD CONSTRAINT `fk_paye_eleve` FOREIGN KEY (`IDELEVE`) REFERENCES `eleve` (`IDELEVE`),
  ADD CONSTRAINT `fk_paye_lib` FOREIGN KEY (`LIBELLE`) REFERENCES `trim` (`LIBELLE`),
  ADD CONSTRAINT `fk_paye_prof` FOREIGN KEY (`IDPROF`) REFERENCES `prof` (`IDPROF`),
  ADD CONSTRAINT `fk_paye_seance` FOREIGN KEY (`NUMSEANCE`) REFERENCES `seance` (`NUMSEANCE`);

--
-- Contraintes pour la table `prof`
--
ALTER TABLE `prof`
  ADD CONSTRAINT `fk_idProf` FOREIGN KEY (`IDPROF`) REFERENCES `personne` (`ID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_refInstrument` FOREIGN KEY (`INSTRUMENT`) REFERENCES `instrument` (`LIBELLE`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Contraintes pour la table `seance`
--
ALTER TABLE `seance`
  ADD CONSTRAINT `fk_jour` FOREIGN KEY (`JOUR`) REFERENCES `jour` (`JOUR`),
  ADD CONSTRAINT `fk_prof` FOREIGN KEY (`IDPROF`) REFERENCES `prof` (`IDPROF`),
  ADD CONSTRAINT `fk_tranche` FOREIGN KEY (`TRANCHE`) REFERENCES `heure` (`TRANCHE`),
  ADD CONSTRAINT `seance_ibfk_1` FOREIGN KEY (`NIVEAU`) REFERENCES `niveau` (`NIVEAU`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
