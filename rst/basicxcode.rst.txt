.. index:: basicxcode

.. _basicxcode:

Basic Xcode Programming
=================

NSLog
--------------------------

NSLog() is the same as the Console.WriteLine() function in C#.

When you want to write to the console using NSLog all you do is:

	* NSLog(@"This is a test"); Writes "This is a test"
	
IF Statements
--------------------------

The if statement method in objective C is almost the same as the if statement in C#.

::
   if (...Parameters...) {


   } else {


   }	

An example of how to use if statement in Xcode vs. Xamarin Studio.

Examples from the Demo/DemoNative projects

Xcode:

.. literalinclude:: ../source/ios/DemoNative/DemoNative/ViewController.m
   :start-after: begin-actnButtonClick2-viewDidLoad
   :end-before: end-actnButtonClick2-viewDidLoad

Xamarin Studio:
	
.. literalinclude:: ../source/ios/Demo/Demo/DemoViewController.cs
   :start-after: begin-actnButtonClick2-xamarin
   :end-before: end-actnButtonClick2-xamarin
   	
NSString
--------------------------

NSString is a simple line of data, for example "This is a test". But if you want to combine two
string together to make a sentence you have to use the [NSString stringWithFormat: ...]; method.

For example::

   NSString *stringone = @"This is a test";

   NSString *stringtwo = @"and you passed the test!";

   NSString *thestring = [NSString stringWithFormat:@"%@ %@",stringone,stringtwo];

This example writes "This is a test and you passed the test!"

Some string rules of insertion:

%@ allows for string to be inserted

%i allows for int to be inserted

%f allows for double to be inserted

NSArray
--------------------------

NSArray is like the List method in C#.

Xcode version:

	* NSArray *array = [[NSArray alloc] initWithObjects:@"Row 0",@"Row 1",@"Row 2", nil];
	
Xamarin Studio version:
	
	* List<string> list = new List<string>();
	  list.Add("Row 0");
	  list.Add("Row 1");
	  list.Add("Row 2");
	  


UIAlertView
--------------------------

UIAlertView is on an iOS device is the popup that informs the user if they are running out of space
of their device or the prompt that comes up when one is trying enter their password to buy something
on the itunes store or app store.

To create a UIAlertView in Xcode, you first have to declare the object or component in this example that 
would be:

	* UIAlertView *alert = ....
	
Next you would want to set the parameters for that popup prompt. When you set you parameter you
are set the title of the popup prompt, the message, and the options that the user has to deal with
the content of the message. 

	* UIAlertView *alert = [[UIAlertView alloc] initWithTitle:@"alert title" message:@"Hello World!" delegate:self cancelButtonTitle:@"OK" otherButtonTitles:nil];
	
Once, your done building the prompt popup all you have todo is to tell the component to show 
itself, by on the next line writing [alert show];

The completed code Xcode version:

.. literalinclude:: ../source/ios/DemoNative/DemoNative/ViewController.m
   :start-after: begin-action-viewDidLoad
   :end-before: end-action-viewDidLoad
   
The Xamarin Studio version

.. literalinclude:: ../source/ios/Demo/Demo/DemoViewController.cs
   :start-after: begin-action-xamarin
   :end-before: end-action-xamarin
	
	
UITableView
--------------------------

The UITableView is a tableview to where a developer can display and list rows of data, for example
names in a contact book, a list of recipes, etc. 

Xcode:

First to start a UITableView, you need to first make a IBOutlet.

    * IBOutlet UITableView *tableviewMe;
    
Then, you have to call the delegate for that UITableView. 

	* @interface ViewController : UIViewController <UITableViewDataSource,UITableViewDelegate> {    

Next you want to create the array to which the table will read from.

.. literalinclude:: ../source/ios/DemoNative/DemoNative/ViewController.m
   :start-after: begin-vc-viewDidLoad
   :end-before: end-vc-viewDidLoad
   
The [tableviewMe reloadData]; line is the method that refreshes and displays the data.

In this selection in the project you would return a number of sections that you would want to 
have in the UITableVIew. Multi sections allows for a better organization of your content. 

.. literalinclude:: ../source/ios/DemoNative/DemoNative/ViewController.m
   :start-after: begin-numberOfSectionsInTableView-viewDidLoad
   :end-before: end-numberOfSectionsInTableView-viewDidLoad
   
Xamarin Studio:

.. literalinclude:: ../source/ios/Demo/Demo/DemoViewController.cs
   :start-after: begin-NumberOfSections
   :end-before: end-NumberOfSections
   
In this code below, the function run the number of times of selections and returns the number
of row that are in that selection per a table.

.. literalinclude:: ../source/ios/DemoNative/DemoNative/ViewController.m
   :start-after: begin-numberOfRowsInSection-viewDidLoad
   :end-before: end-numberOfRowsInSection-viewDidLoad
   
Xamarin Studio:

.. literalinclude:: ../source/ios/Demo/Demo/DemoViewController.cs
   :start-after: begin-RowsInSection
   :end-before: end-RowsInSection

For each section, the function below will return a string for each of the headers of the table
sections.

.. literalinclude:: ../source/ios/DemoNative/DemoNative/ViewController.m
   :start-after: begin-titleForHeaderInSection-viewDidLoad
   :end-before: end-titleForHeaderInSection-viewDidLoad
   
Xamarin Studio:

.. literalinclude:: ../source/ios/Demo/Demo/DemoViewController.cs
   :start-after: begin-TitleForHeader
   :end-before: end-TitleForHeader
   
For each section, the function below will return a string for each of the footers of the table
sections.

.. literalinclude:: ../source/ios/DemoNative/DemoNative/ViewController.m
   :start-after: begin-titleForFooterInSection-viewDidLoad
   :end-before: end-titleForFooterInSection-viewDidLoad
   
Xamarin Studio:

.. literalinclude:: ../source/ios/Demo/Demo/DemoViewController.cs
   :start-after: begin-TitleForFooter
   :end-before: end-TitleForFooter
   
The function below, sets up the cell in each row and section, and return it to the UITableView
to be display. To change the content of the different table cells, use a if statement to check
what section and table rows you are currently in.

.. literalinclude:: ../source/ios/DemoNative/DemoNative/ViewController.m
   :start-after: begin-cellForRowAtIndexPath-viewDidLoad
   :end-before: end-cellForRowAtIndexPath-viewDidLoad
   
Xamarin Studio:

.. literalinclude:: ../source/ios/Demo/Demo/DemoViewController.cs
   :start-after: begin-GetCell
   :end-before: end-GetCell
   
Once something is tapped on the function below, it will be called and a if statement will be need to
pick what actions should be taken. 
   
.. literalinclude:: ../source/ios/DemoNative/DemoNative/ViewController.m
   :start-after: begin-didSelectRowAtIndexPath-viewDidLoad
   :end-before: end-didSelectRowAtIndexPath-viewDidLoad
   
Xamarin Studio:

.. literalinclude:: ../source/ios/Demo/Demo/DemoViewController.cs
   :start-after: begin-RowSelected
   :end-before: end-RowSelected


Presenting a View Controller
--------------------------

Presenting a View Controller is an important part of being a good programmer in building an iOS application,
because presenting view controllers allows the developer to have more space to show their content, and at the
same time give it some character.

* Presenting a ViewController is simple.

	1)First, import the ViewController into the class if you in Xcode. If your using Xamarin Studio all you have todo
	is make sure that the two ViewControllers have same namespace.
	
	2)Next, Declare the ViewController, which consists of the name of the ViewController the name of the ViewController's
	interface files unless its a custom view and the custom parameter if you want when working with Xcode. Xamarin Studio treats
	ViewController as a object so all you would have to do it call the ViewController and create a "new ViewController".
	
	3)Finally, just call the current ViewController and tell it to present the new ViewController that you have configured.
	 
Xcode 	

.. literalinclude:: ../source/ios/DemoNative/DemoNative/ViewController.m
   :start-after: begin-vc-header
   :end-before: end-vc-header

.. literalinclude:: ../source/ios/DemoNative/DemoNative/ViewController.m
   :start-after: begin-presentView-viewDidLoad
   :end-before: end-presentView-viewDidLoad
      
Once your done with present data and you want the user to go back to the original ViewController run this line in the new ViewController
you would dismiss the ViewController.

.. literalinclude:: ../source/ios/DemoNative/DemoNative/LoginController.m
   :start-after: begin-login-dismiss
   :end-before: end-login-import
  
Xamarin Studio

.. literalinclude:: ../source/ios/Demo/Demo/DemoViewController.cs
   :start-after: begin-presentView-xamarin
   :end-before: end-presentView-xamarin
   
.. literalinclude:: ../source/ios/Demo/Demo/LoginController.cs
   :start-after: begin-dismiss-xamarin
   :end-before: end-dismiss-xamarin
   