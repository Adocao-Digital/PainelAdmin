-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 03/12/2024 às 05:10
-- Versão do servidor: 10.4.32-MariaDB
-- Versão do PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `ccz`
--
CREATE DATABASE IF NOT EXISTS `ccz` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `ccz`;

-- --------------------------------------------------------

--
-- Estrutura para tabela `funcionarios`
--

CREATE TABLE `funcionarios` (
  `id_funcionario` int(11) NOT NULL,
  `dataAdmissao_funcionario` date NOT NULL,
  `nome_funcionario` varchar(20) NOT NULL,
  `sobrenome_funcionario` varchar(100) NOT NULL,
  `cpf_funcionario` varchar(14) NOT NULL,
  `email_fnucionario` varchar(100) NOT NULL,
  `senha_funcionario` varchar(100) NOT NULL,
  `telefone_funcionario` varchar(11) NOT NULL,
  `perfil` enum('Usuario','Funcionario') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estrutura para tabela `petadocao`
--

CREATE TABLE `petadocao` (
  `id_petAdocao` int(11) NOT NULL,
  `nome_petAdocao` varchar(20) NOT NULL,
  `foto_petAdocao` varchar(255) NOT NULL,
  `descricao_petAdocao` varchar(500) NOT NULL,
  `status_petAdocao` enum('Disponível','Indisponível') NOT NULL,
  `especie_petAdocao` enum('Cachorro','Gato') NOT NULL,
  `idade_petAdocao` enum('Filhote','Adulto','Idoso') NOT NULL,
  `porte_petAdocao` enum('Pequeno','Médio','Grande') NOT NULL,
  `sexo_petAdocao` enum('Macho','Fêmea') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `petadocao`
--

INSERT INTO `petadocao` (`id_petAdocao`, `nome_petAdocao`, `foto_petAdocao`, `descricao_petAdocao`, `status_petAdocao`, `especie_petAdocao`, `idade_petAdocao`, `porte_petAdocao`, `sexo_petAdocao`) VALUES
(1, 'Amora', 'img/cachorro1.webp', 'Dócil e muito amigável, gosta de brincar e se da bem com gatos.', 'Disponível', 'Cachorro', 'Adulto', 'Médio', 'Macho'),
(2, 'Bruce', 'img/cachorro2.webp', 'Dócil e muito amigável, gosta de brincar e se da bem com gatos.', 'Disponível', 'Cachorro', 'Adulto', 'Médio', 'Macho'),
(3, 'Chiquinha', 'img/cachorro3.webp', 'Filhote muito doce, provável porte médio para grande.', 'Disponível', 'Cachorro', 'Filhote', 'Grande', 'Fêmea'),
(4, 'Zéquinha', 'img/cachorro4.webp', 'Está a algum tempo sem família e sonha muito com um lar amoroso.', 'Disponível', 'Cachorro', 'Adulto', 'Médio', 'Macho'),
(5, 'Toninho Rodrigues', 'img/cachorro5.webp', 'Porte médio e brincalhão, gosta de outros cachorros.', 'Disponível', 'Cachorro', 'Adulto', 'Médio', 'Macho'),
(6, 'Lilia', 'img/cachorro6.webp', 'Um anjinho que gosta de ser filha única e muito carinho.', 'Disponível', 'Cachorro', 'Adulto', 'Médio', 'Fêmea');

-- --------------------------------------------------------

--
-- Estrutura para tabela `petusuario`
--

CREATE TABLE `petusuario` (
  `id_petUsuario` int(11) NOT NULL,
  `nome_petUsuario` varchar(20) NOT NULL,
  `especie_petUsuario` varchar(15) NOT NULL,
  `idade_petUsuario` varchar(2) NOT NULL,
  `porte_petUsuario` varchar(8) NOT NULL,
  `sexo_petUsuario` varchar(10) NOT NULL,
  `peso_petUsuario` varchar(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estrutura para tabela `publicacoes`
--

CREATE TABLE `publicacoes` (
  `id_publicacao` int(11) NOT NULL,
  `data_publicacao` date NOT NULL,
  `titulo_publicacao` varchar(20) NOT NULL,
  `fk_id_funcionario` int(11) NOT NULL,
  `conteudo_publicacao` text NOT NULL,
  `imagem_publicacao` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estrutura para tabela `usuarios`
--

CREATE TABLE `usuarios` (
  `id_usuario` int(11) NOT NULL,
  `nome_usuario` varchar(20) NOT NULL,
  `sobrenome_usuario` varchar(100) NOT NULL,
  `datanasc_usuario` date NOT NULL,
  `cpf_usuario` varchar(14) NOT NULL,
  `sexo` varchar(16) NOT NULL,
  `email_usuario` varchar(100) NOT NULL,
  `senha_usuario` varchar(100) NOT NULL,
  `telefone_usuario` varchar(100) NOT NULL,
  `perfil` enum('Usuario','Funcionario') NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `usuarios`
--

INSERT INTO `usuarios` (`id_usuario`, `nome_usuario`, `sobrenome_usuario`, `datanasc_usuario`, `cpf_usuario`, `sexo`, `email_usuario`, `senha_usuario`, `telefone_usuario`, `perfil`) VALUES
(1, 'JHONATAN', 'DE JESUS', '1998-04-29', '031.988.079-64', 'Masculino', 'asdasd@aosidjasdoj', '$2y$10$xjPuCTN6SuOQQsBUovoko.J.n6t5y5zpYWwKhWFbvCffqXGRbRusO', '43984446926', 'Usuario'),
(2, 'JHONATAN', 'DE JESUS', '1998-04-29', '45349893858', 'Masculino', 'zombegamer@hotmail.com', '$2y$10$3Vd02Ddw2dbtheA/.frd6uPmk.Pu4T8bCk2yBOEY18wDZqCZHNZeC', '43984446926', 'Usuario'),
(5, 'JHONATAN', 'DE JESUS', '1998-04-29', '11122244488', 'Masculino', 'jhonatanjau98@gmail.com', '$2y$10$xQchC9hbOBsG7KsFblzsZ.zb5r5rFjHRQRSwiYIiefWxtiugPlN2K', '43984446926', 'Funcionario'),
(7, 'JHONATAN', 'DE JESUS', '1221-12-12', '453 . 498 . 93', 'Masculino', '1231@hotmasil', '$2y$10$rhF6ZgLxvMLCCgZT4Quinuuj7XvDetQC3K8UuycnDgYKdcGY2zQrm', '43984446926', 'Usuario');

-- --------------------------------------------------------

--
-- Estrutura para tabela `usuario_pets`
--

CREATE TABLE `usuario_pets` (
  `id_usuario` int(11) NOT NULL,
  `id_petUsuario` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Índices para tabelas despejadas
--

--
-- Índices de tabela `funcionarios`
--
ALTER TABLE `funcionarios`
  ADD PRIMARY KEY (`id_funcionario`),
  ADD UNIQUE KEY `id_funcionario` (`id_funcionario`),
  ADD UNIQUE KEY `cpf_funcionario` (`cpf_funcionario`),
  ADD UNIQUE KEY `email_unique` (`email_fnucionario`),
  ADD UNIQUE KEY `UNIQUE` (`sobrenome_funcionario`(14));

--
-- Índices de tabela `petadocao`
--
ALTER TABLE `petadocao`
  ADD PRIMARY KEY (`id_petAdocao`);

--
-- Índices de tabela `petusuario`
--
ALTER TABLE `petusuario`
  ADD PRIMARY KEY (`id_petUsuario`);

--
-- Índices de tabela `publicacoes`
--
ALTER TABLE `publicacoes`
  ADD PRIMARY KEY (`id_publicacao`),
  ADD KEY `fk_id_funcionario` (`fk_id_funcionario`);

--
-- Índices de tabela `usuarios`
--
ALTER TABLE `usuarios`
  ADD PRIMARY KEY (`id_usuario`),
  ADD UNIQUE KEY `UNIQUE` (`email_usuario`),
  ADD UNIQUE KEY `email_unico` (`email_usuario`),
  ADD UNIQUE KEY `cpf_usuario` (`cpf_usuario`);

--
-- Índices de tabela `usuario_pets`
--
ALTER TABLE `usuario_pets`
  ADD KEY `id_petUsuario` (`id_petUsuario`),
  ADD KEY `id_usuario` (`id_usuario`);

--
-- AUTO_INCREMENT para tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `funcionarios`
--
ALTER TABLE `funcionarios`
  MODIFY `id_funcionario` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `petadocao`
--
ALTER TABLE `petadocao`
  MODIFY `id_petAdocao` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT de tabela `petusuario`
--
ALTER TABLE `petusuario`
  MODIFY `id_petUsuario` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `publicacoes`
--
ALTER TABLE `publicacoes`
  MODIFY `id_publicacao` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `usuarios`
--
ALTER TABLE `usuarios`
  MODIFY `id_usuario` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- Restrições para tabelas despejadas
--

--
-- Restrições para tabelas `publicacoes`
--
ALTER TABLE `publicacoes`
  ADD CONSTRAINT `publicacoes_ibfk_1` FOREIGN KEY (`fk_id_funcionario`) REFERENCES `funcionarios` (`id_funcionario`);

--
-- Restrições para tabelas `usuario_pets`
--
ALTER TABLE `usuario_pets`
  ADD CONSTRAINT `usuario_pets_ibfk_1` FOREIGN KEY (`id_petUsuario`) REFERENCES `petusuario` (`id_petUsuario`) ON DELETE CASCADE ON UPDATE NO ACTION,
  ADD CONSTRAINT `usuario_pets_ibfk_2` FOREIGN KEY (`id_usuario`) REFERENCES `usuarios` (`id_usuario`) ON DELETE CASCADE ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
