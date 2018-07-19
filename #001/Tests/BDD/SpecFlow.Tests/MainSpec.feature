功能: MainSpec
	为了避免愚蠢的错误
	作为一个数学白痴
	我想知道两个数的和

@Add
场景: 添加两个数字
	假如 我已经输入了第一个数50到计算器
	而且 我已经输入了第二个数70到计算器
	当 我点击求和
	那么 结果应该显示120
@AddV2
场景: 新的求和需求
	假如 我已经输入了第一个数30到计算器
	而且 我已经输入了第二个数25到计算器
	当 点击新的求和
	那么 结果应该显示55
	但是 我输入了大于50的数到计算器
	当 点击新的求和则抛出AddException异常
	假如 我输入两个数的和大于80
	当 点击新的求和则抛出SumException异常
	

# 参考：https://cucumber.io/docs/reference

# 原例子：
# Feature: MainSpec
# 	In order to avoid silly mistakes
#	As a math idiot
#	I want to be told the sum of two numbers

# @mytag
# Scenario: Add two numbers
#	Given I have entered 50 into the calculator
#	And I have entered 70 into the calculator
#	When I press add
#	Then the result should be 120 on the screen

# 关键字：
# Feature(功能)
# Scenario(场景)
# Given(假如), When(当), Then(那么), And(而且), But(但是)[Steps]
# Background (背景)
# ScenarioOutline(场景大纲)
# Examples(例子)