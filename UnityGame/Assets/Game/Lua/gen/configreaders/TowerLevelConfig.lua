-- ======================================
-- 该文件自动生成,，不要修改，否则会替换
-- 默认Menu: Game/Tool/xlsx->lua
-- auth: 曾峰
-- http://blog.ihaiu.com
-- --------------------------------------			

TowerLevelConfig = class("TowerLevelConfig", {
 	-- 等级id
 	-- type:int
 	-- sample:3001002
 	level_id = 0,

 	-- 英雄名称
 	-- type:string
 	-- sample:机关1
 	name = nil,

 	-- 品质
 	-- type:int
 	-- sample:2
 	quality = 0,

 	-- 等级
 	-- type:int
 	-- sample:2
 	level = 0,

 	-- 需要碎片id
 	-- type:int
 	-- sample:3001
 	piece_id = 0,

 	-- 碎片消耗
 	-- type:int
 	-- sample:2
 	piece = 0,

 	-- 金币消耗
 	-- type:int
 	-- sample:5
 	gold = 0,

 	-- 水晶经验
 	-- type:int
 	-- sample:4
 	cystal_exp = 0,

 	-- 生命值
 	-- type:int
 	-- sample:700
 	hp = 0,

 	-- 伤害
 	-- type:int
 	-- sample:70
 	damage = 0,

 	-- 物理防御
 	-- type:int
 	-- sample:7
 	physical_defence = 0,

 	-- 魔法防御
 	-- type:int
 	-- sample:7
 	magic_defence = 0,

 	-- 物理攻击
 	-- type:int
 	-- sample:7
 	physical_attack = 0,

 	-- 魔法攻击
 	-- type:int
 	-- sample:7
 	magic_attack = 0,

 	-- 攻击距离
 	-- type:int
 	-- sample:500
 	attack_dist = 0,

 	-- 攻击速度
 	-- type:int
 	-- sample:1
 	attack_speed = 0,

 	-- 移动速度
 	-- type:int
 	-- sample:0
 	movement_speed = 0,


})


local M = TowerLevelConfig 

-- 获取键值
function M:GetKey()
 	return self.level_id
end
-- 构造方法
function M:ctor({level_id, name, quality, level, piece_id, piece, gold, cystal_exp, hp, damage, physical_defence, magic_defence, physical_attack, magic_attack, attack_dist, attack_speed, movement_speed})
 	self.level_id = level_id
 	self.name = name
 	self.quality = quality
 	self.level = level
 	self.piece_id = piece_id
 	self.piece = piece
 	self.gold = gold
 	self.cystal_exp = cystal_exp
 	self.hp = hp
 	self.damage = damage
 	self.physical_defence = physical_defence
 	self.magic_defence = magic_defence
 	self.physical_attack = physical_attack
 	self.magic_attack = magic_attack
 	self.attack_dist = attack_dist
 	self.attack_speed = attack_speed
 	self.movement_speed = movement_speed

	-- 自定义解析
	self:Parse()
end


-- 加载扩展
-- 扩展只会第一次生成，该文件存在就不再生成。你可以再里面扩展自己功能
require "gen/configreaders/TowerLevelConfig_Extend"
