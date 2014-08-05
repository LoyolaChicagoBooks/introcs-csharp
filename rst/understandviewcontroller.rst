.. index:: understandingviewcontroller

.. _understandingviewcontroller:

Understanding the View Controllers
=================

View controllers are the foundation of applications and is were a developer would code with the
help of the interface files to display the data, object in a game, list of a parts of a car, and 
so on. View Controller are hard to get right, because they have to be effective and the interface
has to be friendly enough so that a person that has never heard of technology could be able to
use it. This aspect is master after years of practice and errors.  

The parts of the View Controller
--------------------------------------


The viewDidLoad is the function that is automatically ran once the application has completely loaded the view controller from the 
previous view controller or main window.

.. literalinclude:: ../source/ios/DemoNative/DemoNative/ViewController.m
   :start-after: begin-vc-viewDidLoad
   :end-before: end-vc-viewDidLoad
   
The Xamarin Studio version of the viewDidLoad function.

.. literalinclude:: ../source/ios/Demo/Demo/DemoViewController.cs
   :start-after: begin-vc-xamarin
   :end-before: end-vc-xamarin
   
Some other methods that can be called in the delegate controller is:

-(void)viewWillAppear:(BOOL)animated;

viewWillAppear is called when a top view is being dismissed and this function would allow for 
developers to refresh the content in the view controller before it is visible to the users. 

-(void)viewWillDisappear:(BOOL)animated;

viewWillDisappear is called when the current ViewController is about to disappear from the view of the users
view. This allows developers the chances to refresh data or delete objects without the user knowing.

-(void)viewDidAppear:(BOOL)animated;

viewDidAppear runs once the view is completely loaded onto the screen.

-(void)viewDidDisappear:(BOOL)animated;

viewDidDisappear runs once the view is completely removed from the screen.
   

	