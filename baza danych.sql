-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 87.98.236.134:3306
-- Czas generowania: 26 Lis 2022, 16:16
-- Wersja serwera: 10.5.15-MariaDB-0+deb11u1
-- Wersja PHP: 8.0.19

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `db_79640`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `users`
--

CREATE TABLE `users` (
  `login` varchar(24) NOT NULL,
  `haslo` varchar(36) NOT NULL,
  `nick` varchar(32) CHARACTER SET utf8mb4 COLLATE utf8mb4_polish_ci NOT NULL,
  `tag` varchar(6) NOT NULL,
  `addfriend` varchar(64) NOT NULL,
  `owner` varchar(36) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `users`
--

INSERT INTO `users` (`login`, `haslo`, `nick`, `tag`, `addfriend`, `owner`) VALUES
('Dt', '123', 'Dante', '#56137', 'Dante#56137', '342835467215836564182781334846346147'),
('Mk', '123', 'Mokotowski', '#51483', 'Mokotowski#51483', '548125817125131256876657528536361747'),
('Bt', '123', 'Batir', '#98876', 'Batir#98876', '588165344723411428154584375543438655'),
('Ku', '123', 'Kubanczyk', '#68043', 'Kubanczyk#68043', '813762336265413263331778626166856362');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `znajomi`
--

CREATE TABLE `znajomi` (
  `owner` varchar(36) NOT NULL,
  `friends` varchar(2555) NOT NULL DEFAULT '[]',
  `oczekujace` varchar(2555) NOT NULL DEFAULT '[]',
  `odebrane` varchar(2555) NOT NULL DEFAULT '[]'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Zrzut danych tabeli `znajomi`
--

INSERT INTO `znajomi` (`owner`, `friends`, `oczekujace`, `odebrane`) VALUES
('342835467215836564182781334846346147', '[Mokotowski#51483]', '[]', '[]'),
('548125817125131256876657528536361747', '[Dante#56137,Kubanczyk#68043]', '[]', '[]'),
('588165344723411428154584375543438655', '[]', '[]', '[]'),
('813762336265413263331778626166856362', '[Mokotowski#51483]', '[]', '[]');

--
-- Indeksy dla zrzutów tabel
--

--
-- Indeksy dla tabeli `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`owner`);

--
-- Indeksy dla tabeli `znajomi`
--
ALTER TABLE `znajomi`
  ADD PRIMARY KEY (`owner`);

--
-- Ograniczenia dla zrzutów tabel
--

--
-- Ograniczenia dla tabeli `znajomi`
--
ALTER TABLE `znajomi`
  ADD CONSTRAINT `znajomi_ibfk_1` FOREIGN KEY (`owner`) REFERENCES `users` (`owner`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
