-- ===========================
-- HeroLevelConfigReader 的数据
-- 默认Menu: Game/Tool/xlsx->lua
-- autho:曾峰
-- email:zengfeng75@qq.com
-- qq:593705098
-- http://blog.ihaiu.com
-- ---------------------------



local M = HeroLevelConfigReader



-- 读取数据
function M:ReadConfigs()
	self:ParseLine(1, {int, "string", int, int, int, int, int, int, int, int, int, int, int, int, int, int, int})
	self:ParseLine(2, {等级id, "英雄名称", 品质, 等级, 需要碎片id, 碎片消耗, 金币消耗, 水晶经验, 生命值, 伤害, 物理防御, 魔法防御, 物理攻击, 魔法攻击, 攻击距离, 攻击速度, 移动速度})
	self:ParseLine(3, {level_id, "name", quality, level, piece_id, piece_num, gold, cystal_exp, hp, damage, physical_defence, magic_defence, physical_attack, magic_attack, attack_dist, attack_speed, movement_speed})
	self:ParseLine(4, {1001001, "后裔", 2, 1, 1001, 0, 0, 0, 600, 60, 6, 6, 6, 6, 500, 1.5, 300})
	self:ParseLine(5, {1001002, "后裔", 2, 2, 1001, 2, 5, 4, 700, 70, 7, 7, 7, 7, 500, 1, 300})
	self:ParseLine(6, {1001003, "后裔", 2, 3, 1001, 4, 20, 5, 800, 80, 8, 8, 8, 8, 500, 1, 300})
	self:ParseLine(7, {1001004, "后裔", 2, 4, 1001, 10, 50, 6, 900, 90, 9, 9, 9, 9, 500, 1, 300})
	self:ParseLine(8, {1001005, "后裔", 2, 5, 1001, 20, 150, 10, 1000, 100, 10, 10, 10, 10, 500, 1, 300})
	self:ParseLine(9, {1001006, "后裔", 2, 6, 1001, 50, 400, 25, 1100, 110, 11, 11, 11, 11, 500, 1, 300})
	self:ParseLine(10, {1001007, "后裔", 2, 7, 1001, 100, 1000, 50, 1200, 120, 12, 12, 12, 12, 500, 1, 300})
	self:ParseLine(11, {1001008, "后裔", 2, 8, 1001, 200, 2000, 100, 1300, 130, 13, 13, 13, 13, 500, 1, 300})
	self:ParseLine(12, {1001009, "后裔", 2, 9, 1001, 400, 4000, 200, 1400, 140, 14, 14, 14, 14, 500, 1, 300})
	self:ParseLine(13, {1001010, "后裔", 2, 10, 1001, 800, 8000, 400, 1500, 150, 15, 15, 15, 15, 500, 1, 300})
	self:ParseLine(14, {1001011, "后裔", 2, 11, 1001, 1000, 10000, 500, 1600, 160, 16, 16, 16, 16, 500, 1, 300})
	self:ParseLine(15, {1001012, "后裔", 2, 12, 1001, 1100, 11000, 550, 1700, 170, 17, 17, 17, 17, 500, 1, 300})
	self:ParseLine(16, {1001013, "后裔", 2, 13, 1001, 1200, 12000, 600, 1800, 180, 18, 18, 18, 18, 500, 1, 300})
	self:ParseLine(17, {1001014, "后裔", 2, 14, 1001, 1300, 13000, 650, 1900, 190, 19, 19, 19, 19, 500, 1, 300})
	self:ParseLine(18, {1001015, "后裔", 2, 15, 1001, 1400, 14000, 700, 2000, 200, 20, 20, 20, 20, 500, 1, 300})
	self:ParseLine(19, {1002001, "女娲", 2, 1, 1002, 0, 0, 0, 600, 60, 16, 16, 16, 16, 300, 1, 300})
	self:ParseLine(20, {1002002, "女娲", 2, 2, 1002, 2, 5, 4, 700, 70, 17, 17, 17, 17, 300, 1, 300})
	self:ParseLine(21, {1002003, "女娲", 2, 3, 1002, 4, 20, 5, 800, 80, 18, 18, 18, 18, 300, 1, 300})
	self:ParseLine(22, {1002004, "女娲", 2, 4, 1002, 10, 50, 6, 900, 90, 19, 19, 19, 19, 300, 1, 300})
	self:ParseLine(23, {1002005, "女娲", 2, 5, 1002, 20, 150, 10, 1000, 100, 20, 20, 20, 20, 300, 1, 300})
	self:ParseLine(24, {1002006, "女娲", 2, 6, 1002, 50, 400, 25, 1100, 110, 21, 21, 21, 21, 300, 1, 300})
	self:ParseLine(25, {1002007, "女娲", 2, 7, 1002, 100, 1000, 50, 1200, 120, 22, 22, 22, 22, 300, 1, 300})
	self:ParseLine(26, {1002008, "女娲", 2, 8, 1002, 200, 2000, 100, 1300, 130, 23, 23, 23, 23, 300, 1, 300})
	self:ParseLine(27, {1002009, "女娲", 2, 9, 1002, 400, 4000, 200, 1400, 140, 24, 24, 24, 24, 300, 1, 300})
	self:ParseLine(28, {1002010, "女娲", 2, 10, 1002, 800, 8000, 400, 1500, 150, 25, 25, 25, 25, 300, 1, 300})
	self:ParseLine(29, {1002011, "女娲", 2, 11, 1002, 1000, 10000, 500, 1600, 160, 26, 26, 26, 26, 300, 1, 300})
	self:ParseLine(30, {1002012, "女娲", 2, 12, 1002, 1100, 11000, 550, 1700, 170, 27, 27, 27, 27, 300, 1, 300})
	self:ParseLine(31, {1002013, "女娲", 2, 13, 1002, 1200, 12000, 600, 1800, 180, 28, 28, 28, 28, 300, 1, 300})
	self:ParseLine(32, {1002014, "女娲", 2, 14, 1002, 1300, 13000, 650, 1900, 190, 29, 29, 29, 29, 300, 1, 300})
	self:ParseLine(33, {1002015, "女娲", 2, 15, 1002, 1400, 14000, 700, 2000, 200, 30, 30, 30, 30, 300, 1, 300})
	self:ParseLine(34, {1003001, "夸父", 2, 1, 1003, 0, 0, 0, 600, 60, 26, 26, 26, 26, 100, 1, 300})
	self:ParseLine(35, {1003002, "夸父", 2, 2, 1003, 2, 5, 4, 700, 70, 27, 27, 27, 27, 100, 1, 300})
	self:ParseLine(36, {1003003, "夸父", 2, 3, 1003, 4, 20, 5, 800, 80, 28, 28, 28, 28, 100, 1, 300})
	self:ParseLine(37, {1003004, "夸父", 2, 4, 1003, 10, 50, 6, 900, 90, 29, 29, 29, 29, 100, 1, 300})
	self:ParseLine(38, {1003005, "夸父", 2, 5, 1003, 20, 150, 10, 1000, 100, 30, 30, 30, 30, 100, 1, 300})
	self:ParseLine(39, {1003006, "夸父", 2, 6, 1003, 50, 400, 25, 1100, 110, 31, 31, 31, 31, 100, 1, 300})
	self:ParseLine(40, {1003007, "夸父", 2, 7, 1003, 100, 1000, 50, 1200, 120, 32, 32, 32, 32, 100, 1, 300})
	self:ParseLine(41, {1003008, "夸父", 2, 8, 1003, 200, 2000, 100, 1300, 130, 33, 33, 33, 33, 100, 1, 300})
	self:ParseLine(42, {1003009, "夸父", 2, 9, 1003, 400, 4000, 200, 1400, 140, 34, 34, 34, 34, 100, 1, 300})
	self:ParseLine(43, {1003010, "夸父", 2, 10, 1003, 800, 8000, 400, 1500, 150, 35, 35, 35, 35, 100, 1, 300})
	self:ParseLine(44, {1003011, "夸父", 2, 11, 1003, 1000, 10000, 500, 1600, 160, 36, 36, 36, 36, 100, 1, 300})
	self:ParseLine(45, {1003012, "夸父", 2, 12, 1003, 1100, 11000, 550, 1700, 170, 37, 37, 37, 37, 100, 1, 300})
	self:ParseLine(46, {1003013, "夸父", 2, 13, 1003, 1200, 12000, 600, 1800, 180, 38, 38, 38, 38, 100, 1, 300})
	self:ParseLine(47, {1003014, "夸父", 2, 14, 1003, 1300, 13000, 650, 1900, 190, 39, 39, 39, 39, 100, 1, 300})
	self:ParseLine(48, {1003015, "夸父", 2, 15, 1003, 1400, 14000, 700, 2000, 200, 40, 40, 40, 40, 100, 1, 300})

end
