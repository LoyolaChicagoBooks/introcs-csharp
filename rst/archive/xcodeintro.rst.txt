.. index:: xcode intro

.. _xcodeintro:

Xcode Intro
=================

Xcode is the native compiler for designing and creating iOS device applications.
The compiler is a all in one program, unlike Xamarin Studio, xcode has the interface builder
and the code editor combine which allows for fast debugging time. Xcode is free to have, 
programmers can design and program applications and test them on the iOS simulator. To 
test your applications on a real iOS device, you would have to sign up in the Apple 
Developer portal, and pay the $99 subscription fee. Once your account is create you would
be able to do live runs of the application to see how it feels and handle in a real iOS 
environment.   

.. note:: 

   Xcode is only for Mac users

Xcode uses Objective-C as its main language, in addition to being able to complier 
other C languages.  

Installing Xcode
--------------------------

Before installing Xcode make sure that your laptop operating system is up to date. In 
addition from experience please close all other applications that are running in the
background. (Makes installation a lot faster!)  

Xcode Version 5.0.1 (5A2053) takes up about 5 GB of storage. 

- Open the "App Store" on your Mac
	
- Enter "Xcode" in the search bar at the top right corner
	
- Click "Install"
	
Depending on the status of your computer and the hardware configurations, this process
could take up to a hour or two depending on your internet connection. 
 
Installing Xamarin Studio
--------------------------

To install Xamarin Studio proceed to https://xamarin.com/download. Once you have reached that
page please fill out the "Tell us a bit about yourself" and click the proceed to download. As soon
as the download has completed, open up the installer help program and follow instruction from there.
 
Reasoning for this section
--------------------------

The reason behind writing this section is to exercise the principles that are presented
in the pervious 18 chapters. To exercise these principles this chapter will show you how to
start a project in both C# and Objective-C though Xamarin Studio and Apple's Xcode to run on
the iOS platform.  
	
Creating a project
--------------------------

Creating a project is fast and simple. To create a project go to:

File > New > Project

Under the iOS Area there are two selections.

The first selection is the Application area.

- "Master-Detail Application" This template provides a starting point for a master-detail application. It provides a user interface configured with a navigation controller to display a list of items and also a split view on iPad.

- "OpenGL Game" The template provides a starting point for an OpenGL ES-based game. It provides a view into which you render your OpenGL ES scene, and a timer to allow you to animate the view.

- "Page-Based Application" This template provides starting point for a page-based application that uses a page view controller.

- "Single View Application" This template provides a starting point for an application that uses a single view. It provides a view controller that manages the view, and a storyboard or nib file that contains the view.

- "Tabbed Application" This template provides a starting point for an application that uses a tab bar. It provides a user interface configured with a tab bar controller, and view controller for the tab bar items.

- "Utility Application" This templates provides a starting point for a utility application that has a main view and an alternate view. For iPhone, it sets up an Info button to flip the main view to the alternate view. For iPad, it sets up an Info bar button that shows the alternate view in a popover.

- "Empty Application" This template provides a starting point for any application. It provides just an application delegate and a window.

- "SpriteKit Game" This template provides a starting point for a SpriteKit Game.

The second selection is the Framework & Library are.

- "Cocoa Touch Static Library" This template builds a static library that links against the Foundation framework.

If you want to start from the beginning with little pre programmed parts, then I would 
recommended that you select the "Single View Application", all it gives you is the main view
and you have to program the rest of the components. 

Demo vs. DemoNative (Download Links)
-----------------------------------------------

Heres the link to the bitbucket pages that contain all the source code for this chapter. Demo and DemoNative are 
the same application, but programmed in two different languages with two different compilers. This will allow you to
understand the differences between them faster and at the same time teacher you the basics behind Objective-C programming
and application development.   

https://bitbucket.org/josullivan1/comp170-xcode-xamarin-ios

I would recommend download and following with the actually code. In additon I would suggest that you take some
time to play around with the code in Xcode and Xamarin Studio to get a better feel for it.
 

