.. index:: beginxcode

.. _beginxcode:

iOS Application Structure 
=================

	When programming a iOS application there are three main components that make it up, AppDelegate, ViewController, and interface files.
AppDelegate is the main file that is always running in the background. The AppDelegate is great for declaring local variables and
setting your credentials to a third party service API (Dropbox,Cloud, etc...). ViewController are where most of the coding takes place.
ViewControllers are what you build to present your concept to your audience. ViewController gives the developer the ability to organize
there code in a simple and uncomplicated way to code and still provide excellent performance experience. The interface files are for designing 
interface that will hold the data you are present from the ViewController. Thanks to Xcode, developers using Xcode or Xamarin studio can design
beautiful and simple interfaces with the drag and drop function in Xcode, which is used by Xamarin Studio too. Even though the end result of these
compliers are the same, there are some differences in the format of the projects and structures.     
   

Native iOS Version
--------------------------------------
-Shown in order of hierarchy

*THE APP 
	-AppDelegate(.h/.m)
	-main.m
		-ViewControllers
			-.h files (H-eader)
			-.m files (M-ain)
			-.xib files (X-code I-nterface B-uilder)

Xamarin Studio Version 
--------------------------------------
-Shown in order of hierarchy

-In Xamarin Studio, all the components and local variables are declared within the same file!

*THE APP
	-AppDelegate(.cs)
	-Main.cs
		-ViewController
			-.designers.cs (Header)
			-.cs (Main)
			-.xib files (X-code I-nterface B-uilder)
			