-- phpMyAdmin SQL Dump
-- version 4.7.5
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: 2018-06-26 06:19:41
-- 服务器版本： 5.7.19-log
-- PHP Version: 7.1.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `user`
--

-- --------------------------------------------------------

--
-- 表的结构 `data`
--

CREATE TABLE `data` (
  `id` int(10) NOT NULL,
  `name` varchar(15) COLLATE utf8_bin NOT NULL,
  `sex` varchar(10) COLLATE utf8_bin DEFAULT NULL,
  `phone` int(20) DEFAULT NULL,
  `dizhi` varchar(20) COLLATE utf8_bin DEFAULT NULL,
  `datatime` varchar(15) COLLATE utf8_bin DEFAULT NULL,
  `bumen` varchar(20) COLLATE utf8_bin DEFAULT NULL,
  `img` varchar(100) COLLATE utf8_bin DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- 转存表中的数据 `data`
--

INSERT INTO `data` (`id`, `name`, `sex`, `phone`, `dizhi`, `datatime`, `bumen`, `img`) VALUES
(1, '3', '男', 3, '4444444', '2018年4月22日', '技术部', 'D:\\cpp\\c#\\main\\main\\bin\\Debug\\img\\636656187950953898.jpg'),
(2, '444', '男', 444, '44', '2018年5月15日', '技术部', 'D:\\cpp\\c#\\main\\main\\bin\\Debug\\img\\636656190073543618.png'),
(3, '111111', '男', 111111, '1111111111', '2018年5月10', '技术部', 'D:\\cpp\\c#\\main\\main\\bin\\Debug\\img\\636656187950953898.jpg'),
(4, '21321432', '男', 222, '222222', '2018年5月9日', '人事部', 'D:\\cpp\\c#\\main\\main\\bin\\Debug\\img\\636656189754818219.jpg'),
(5, 'dfhaohf', '男', 555555, '555555', '2018年5月8日', '资源部', 'D:\\cpp\\c#\\main\\main\\bin\\Debug\\img\\636656190073543618.png'),
(6, 'wzd', '男', 66777, '666666', '2018年6月26日', '资源部', 'D:\\cpp\\c#\\main\\main\\bin\\Debug\\img\\636656193013244856.jpg'),
(7, 'wdd', '男', 77777, '77776666', '2018年6月26日', '人事部', 'D:\\cpp\\c#\\main\\main\\bin\\Debug\\img\\636656194462130230.png');

-- --------------------------------------------------------

--
-- 表的结构 `users`
--

CREATE TABLE `users` (
  `id` int(10) NOT NULL,
  `user` varchar(20) COLLATE utf8_bin NOT NULL,
  `password` varchar(50) COLLATE utf8_bin DEFAULT NULL,
  `role` varchar(20) COLLATE utf8_bin DEFAULT NULL,
  `email` varchar(20) COLLATE utf8_bin DEFAULT NULL,
  `problem` varchar(30) COLLATE utf8_bin DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- 转存表中的数据 `users`
--

INSERT INTO `users` (`id`, `user`, `password`, `role`, `email`, `problem`) VALUES
(1, 'wuzuoda', 'c81e728d9d4c2f636f067f89cc14862c', '管理员', '1132890172@qq.com', 'JJJ'),
(2, 'wudada', 'a87ff679a2f3e71d9181a67b7542122c', '员工', '2581498693@qq.com', 'KKK'),
(3, 'wu', 'c4ca4238a0b923820dcc509a6f75849b', '员工', '', 'LLL'),
(4, '243920161', '202cb962ac59075b964b07152d234b70', '员工', '', '猴哥'),
(5, '111111', 'c81e728d9d4c2f636f067f89cc14862c', '员工', NULL, 'KKK'),
(6, 'wzd', 'c4ca4238a0b923820dcc509a6f75849b', '员工', NULL, 'kkk'),
(7, 'wdd', 'c4ca4238a0b923820dcc509a6f75849b', '员工', NULL, 'LLL');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `data`
--
ALTER TABLE `data`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `name` (`name`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `user` (`user`);

--
-- 在导出的表使用AUTO_INCREMENT
--

--
-- 使用表AUTO_INCREMENT `data`
--
ALTER TABLE `data`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- 使用表AUTO_INCREMENT `users`
--
ALTER TABLE `users`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
