# 项目情况说明

该解决方案下有四个项目（文件夹）：

* Source_of_AreaCalc
  这是.sln文件所在的文件夹，包括了程序的主要结构。这个项目是以WPF问模板创建的，所有与界面展示的代码均在其中。

* Tools_For_Translation
  在后续的重构中，原本主程序中的一些功能得到了整合，形成了一个Tool类。因此这个项目是一个类库项目，类库中声明了一个名叫Tool的方法类（即以方法而非属性为主体的类）。这些方法包括了：检测用户输入是否有效，实现厘米与英寸相互转换。

* Doc_For_Tools
  这是为了生成SandCastle帮助文档而建立的一个项目。根目录下的Doc_For_Tools.chm正是其生成的产物之一。
  
  * Doc_For_Tools.chm
    基于Tools_For_Translation类库生成的帮助文档。（英文写的老师您别看漏了）对Tool类下的三个方法做了简单的介绍。

* Tools_For_TranslationTests1
  这是代码单元测试生成的项目。这里只测试了Tools_For_Translation中Tool类的check_input方法。

# 团队分工情况

* 周毅恒：
  编写了代码的主要框架

* 周远哲：
  整合了Tool类的方法，重构代码
  生成了chm说明文档

* 徐诗博：
  进行代码单元测试

# 项目地址

```
https://github.com/Zeny-12306/The-3rd-homework
```


