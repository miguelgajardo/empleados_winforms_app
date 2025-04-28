-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 28-04-2025 a las 19:08:15
-- Versión del servidor: 10.4.32-MariaDB
-- Versión de PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `bd_empleados`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_departamentos`
--

CREATE TABLE `tbl_departamentos` (
  `codigo_departamento` int(4) NOT NULL,
  `nombre_departamento` varchar(80) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `tbl_departamentos`
--

INSERT INTO `tbl_departamentos` (`codigo_departamento`, `nombre_departamento`) VALUES
(9900, 'Sistemas'),
(9977, 'Gestión');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tbl_empleados`
--

CREATE TABLE `tbl_empleados` (
  `rut` varchar(9) NOT NULL,
  `nombre` varchar(20) NOT NULL,
  `apellido` varchar(20) NOT NULL,
  `codigo_departamento` int(4) NOT NULL,
  `sueldo` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `tbl_empleados`
--

INSERT INTO `tbl_empleados` (`rut`, `nombre`, `apellido`, `codigo_departamento`, `sueldo`) VALUES
('175559990', 'Manuel', 'Blanco', 9900, 500000);

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `tbl_departamentos`
--
ALTER TABLE `tbl_departamentos`
  ADD PRIMARY KEY (`codigo_departamento`);

--
-- Indices de la tabla `tbl_empleados`
--
ALTER TABLE `tbl_empleados`
  ADD PRIMARY KEY (`rut`),
  ADD KEY `codigo_departamento` (`codigo_departamento`);

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `tbl_empleados`
--
ALTER TABLE `tbl_empleados`
  ADD CONSTRAINT `tbl_empleados_ibfk_1` FOREIGN KEY (`codigo_departamento`) REFERENCES `tbl_departamentos` (`codigo_departamento`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
