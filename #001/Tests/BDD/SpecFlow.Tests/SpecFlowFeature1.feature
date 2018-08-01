功能: SpecFlowFeature1
	为了避免愚蠢的错误
	作为一个数学白痴
	我想知道两个数的和

@mytag
场景: 第二个测试两个数字
	假如 第二个测试我已经输入第一个数10到计算器
	而且 第二个测试我已经输入第二个数20到计算器
	当 第二个测试我点击求和
	那么 第二个测试结果应该显示30
场景: 测试第二个彩蛋
	假如 第二个测试我已经输入第一个数33到计算器
	而且 第二个测试我已经输入第二个数33到计算器
	当 第二个测试我点击求和
	那么 第二个测试结果应该显示-1


	

# 参考：https://cucumber.io/docs/reference

# 原例子：
# Feature: SpecFlowFeature1
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