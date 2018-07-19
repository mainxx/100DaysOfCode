# 测试设计的初探

1. TDD：测试驱动开发（Test-Driven Development）
2. BDD：行为驱动开发（Behavior Driven Development）
3. ATDD：验收测试驱动开发（Acceptance Test Driven Development）
4. DDD：领域驱动开发（Domain Drive Design）

通过下面一幅图就可以发现对于测试也有不同的层次和流程：

　　从图中可以发现，最下面的是**单元测试**（**白盒测试**），主要用于测试开发人员编写的代码是否正确，这部分工作都是开发人员自己来做的。通常而言，一个单元测试是用于判断某个特定条件（或者场景）下某个特定函数的行为。再往上，就是**BDD**（**灰盒测试、黑盒测试**），主要用于测试代码是否符合客户的需求，这里的BDD更加侧重于代码的功能逻辑。

　　从左边的范畴也可以看出，测试的范围也是逐层扩大，从单元测试的类到BDD里面的服务、控制器等，再到最上层的模拟实际操作场景的**Selenium**（Selenium也是一个用于Web应用程序测试的工具。Selenium测试直接运行在浏览器中，就像真正的用户在操作一样。）对于包括UI界面的测试。

![1](img\img1.png)

## [TDD]

[TDD]指的是[Test Drive Development]，很明显的意思是**测试驱动开发**，也就是说我们可以从测试的角度来检验整个项目。大概的流程是先针对每个功能点抽象出接口代码，然后编写单元测试代码，接下来实现接口，运行单元测试代码，循环此过程，直到整个单元测试都通过。这一点和敏捷开发有类似之处。

>它是一种测试先于编写代码的思想用于指导软件开发。测试驱动开发是敏捷开发中的一项核心实践和技术，也是一种设计方法论。TDD的原理是在开发功能代码之前，先编写单元测试用例代码，测试代码确定需要编写什么产品代码。

TDD的好处自然不用多说，它能让你减少程序逻辑方面的错误，尽可能的减少项目中的bug，开始接触编程的时候我们大都有过这样的体验，可能你觉得完成得很完美，自我感觉良好，但是实际测试或者应用的时候才发现里面可能存在一堆bug，或者存在设计问题，或者更严重的逻辑问题，而TDD正好可以帮助我们尽量减少类似事件的发生。而且现在大行其道的一些模式对TDD的支持都非常不错，比如MVC和MVP等。

但是并不是所有的项目都适合TDD这种模式的，我觉得必须具备以下几个条件。

* **需求必须足够清晰**
* **程序员对整个需求有足够的了解**

如果这个条件不满足，那么执行的过程中难免失控。当然，要达到这个目标也是需要做一定功课的，这要求我们前期的**需求分析**以及**HLD**和**LLD**都要做得足够的细致和完善。

其次，取决于项目的复杂度和依赖性，对于一个业务模型及其复杂、内部模块之间的相互依赖性非常强的项目，采用TDD反而会得不尝失，这会导致程序员在拆分接口和写测试代码的时候工作量非常大。另外，由于模块之间的依赖性太强，我们在写测试代码的时候可能不采取一些桥接模式来实现，这样势必加大了程序员的工作量。

* 特点
1. 有利于更加专注软件设计；
2. 清晰地了解软件的需求；
3. 很好的诠释了代码即文档。

* 相关文章
1. 初步认识TDD:<https://www.cnblogs.com/wfsovereign/p/4198209.html>
2. TDD和BDD及DDD的解说:<https://blog.csdn.net/bennes/article/details/47973129>
3. TDD 已死？让我们再聊聊TDD:<http://blog.jobbole.com/110560/>

## [BDD]

* 特点
1. 缩小团队成员之间沟通差距
2. 促进对客户需求的理解,并促进对实际需求的持续沟通

[Behavior Driven Development]，行为驱动开发是一种敏捷软件开发的技术，它鼓励软件项目中的开发者、QA和非技术人员或商业参与者之间的协作。

BDD是一种敏捷软件开发的技术。它对TDD的理念进行了扩展，在TDD中侧重点偏向开发，通过测试用例来规范约束开发者编写出质量更高、bug更少的代码。而BDD更加侧重设计，其要求在设计测试用例的时候对系统进行定义，倡导使用通用的语言将系统的行为描述出来，将系统设计和测试用例结合起来，从而以此为驱动进行开发工作。

BDD的通用语言是一种近乎自然语言的描述软件的形式。传统的开发模式中，客户很难从技术层面理解问题，开发人员很难从业务需求考虑问题，基于这种通用语言形式可以尽可能的避免客户和开发者在沟通上的障碍，实现客户和开发者同时定义系统的需求。避免了因为理解需求不充分而带来的不必必要的工作量。

BDD描述的行为就像一个个的故事(Story)，系统业务专家、开发者、测试人员一起合作，分析软件的需求，然后将这些需求写成一个个的故事。开发者负责填充这些故事的内容，测试者负责检验这些故事的结果。通常，会使用一个故事的模板来对故事进行描述

```cucumber
# 关键字：
# Feature(功能)
# Scenario(场景)
# Given(假如), When(当), Then(那么), And(而且), But(但是)[Steps]
# Background (背景)
# ScenarioOutline(场景大纲)
# Examples(例子)

# example：

Feature: calculator
    In order to avoid silly mistakes
    As a math idiot
    I want to be told the sum of two numbers
@mytag
Scenario: Add two numbers
    Given I have entered 50 into the calculator
    And I have entered 70 into the calculator
    When I press add
    Then the result should be 120 on the screen

# 中文例子：

功能: 计算器
    为了避免愚蠢的错误
    作为一个数学白痴
    我想知道两个数的和

@mytag
场景: 添加两个数字
    假如 我已经输入了第一个数50到计算器
    而且 我已经输入了第二个数70到计算器
    当 我点击求和
    那么 结果应该显示120
```

### 常见的BDD框架：

* C – Cspec
* C++ – CppSpec, Spec-CPP
* .Net – NBehave, NSpecify, SpecFlow
* Groovy – GSpec, easyb, Cuke4Duke
* PHP – PHPSpec
* Python – Specipy
* Ruby – RSpec, Shoulda, Cucumber

**与Java相关的BDD测试工具**：

1. JBehave – Java annotations based, Test frameworks agnostic
2. Cuke4duke – Cucumber support for JVM
3. JDave – RSpec (Ruby) inspired, Mojo 2 & Hamcrest based
4. beanSpec – Java based
5. easyb – Java based, Specifications written in Groovy
6. instinct – BDD framework for Java, providing annotations for contexts. Inspired by Rspec
7. BDoc - Extracts behaviour from unit tests

> 来自Leo_wlCnBlogs：<https://www.cnblogs.com/Leo_wl/p/4780678.html>

## HLD & LLD (High Level Design & Low Level Design)

* HLD：高层次设计High Level Design,概要设计
* LLD：低级别设计Low Level Design,详细设计
1. 高层次设计（HLD）是整个系统的设计-包括**系统架构**和**数据库设计**。 它描述了该系统的各个模块和功能之间的关系。 **数据流**，**流程图**和**数据结构**下HLD覆盖。
2. 低级别设计（LLD）就像是详细的HLD。 它定义了用于该系统的每个部件的**实际逻辑**。 **类图**与**类**之间的所有**方法**和**关系**。 程序规范是根据LLD覆盖。

[TDD]:(https://baike.baidu.com/item/TDD/9064369)
[Test Drive Development]:(https://zh.wikipedia.org/zh-hans/%E6%B5%8B%E8%AF%95%E9%A9%B1%E5%8A%A8%E5%BC%80%E5%8F%91)
[BDD]:(https://baike.baidu.com/item/BDD/10735732?fr=aladdin)
[Behavior Driven Development]:(https://zh.wikipedia.org/wiki/%E8%A1%8C%E4%B8%BA%E9%A9%B1%E5%8A%A8%E5%BC%80%E5%8F%91)

## .net下的测试框架及相关库

1. [xUnit.net]是一个免费的，开源的，以社区为中心的.NET Framework单元测试工具。
2. [MSTest]是微软自己写的一套开源的,测试工具,目前是V2版本.Github:<https://github.com/Microsoft/testfx>
3. [NUnit]是所有.Net语言的单元测试框架。最初从JUnit移植，当前的生产版本3已经完全重写了许多新功能并支持各种.NET平台。
4. [SpecFlow]是一个可以将业务需求绑定到.NET代码的工具,并且开源,用于管理和自动执行人类可读的验收测试.是[Cucumber]家族的一部分.
5. [Shouldly]是一个断言框架，它专注于在断言失败时提供很好的错误消息，同时简单而简洁。Github:<https://github.com/shouldly/shouldly>
6. [Cucumber]是一种支持行为驱动开发（BDD）的工具。遵循[Gherkin]语法规则.

例子：<https://github.com/mainxx/100DaysOfCode/tree/master/%23001>

* 相关文章
1. 舍弃Nunit拥抱Xunit:<https://www.cnblogs.com/cuiyansong/p/4521124.html>
2. BDD原则与实践:<https://docs.cucumber.io/bdd/>

### 关于ATDD及DDD.下次再探索

[xUnit.net]:(https://xunit.github.io/)
[MSTest]:(https://msdn.microsoft.com/en-us/library/ms243147.aspx)
[NUnit]:(http://nunit.org/)
[Shouldly]:(http://docs.shouldly-lib.net/)
[SpecFlow]:(https://specflow.org/)
[Cucumber]:(https://docs.cucumber.io/)
[Gherkin]:(https://docs.cucumber.io/gherkin/reference/)