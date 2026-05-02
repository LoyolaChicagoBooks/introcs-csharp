Chapter Review Questions
=========================

#.  Where in a class are instance variables declared?

#.  For most instance variables, what is the modifier used that does not
    appear at the beginning of a local variable declaration?
   
#.  What is the lifetime of an instance variable:   
    When does it come into existence, and how long does it last?
   
#.  Why do we generally make an instance variable ``private``?

#.  In what code can an instance variable be seen and used?

#.  Must instance variables and methods always be preceded by
    an explicit object reference and ``.``?

#.  Can we refer to an instance variable in a part of the code 
    where there is no current object?

#.  In what kind of method in a class definition are instance variables never
    accessible?

#.  What is the purpose of a constructor?   
    
#.  How is the heading of a constructor different from a regular method?

#.  How are parameters to a constructor generally used?

#.  If you do not explicitly assign a value to an instance variable in a
    constructor, does the instance variable have a value?

#.  If we want users to be able to see the value of a private instance variable
    from outside of the class, how do we do it?
    
#.  What is the general name of the category of methods that return
    instance state values?
    
#.  Instance variables are usually visible from inside instance methods for
    the class.  What is the exception?  In the exceptional case, what is
    the workaround to allow access to the instance variable?
    
#.  Sometimes you need to refer explicitly to the current object.  How
    do you do it?
 
#.  Sometimes you want to let users outside the class modify the value 
    of a private instance variable.  How do you do it?
    
#.  What is the general name of the category of public methods whose sole purpose
    is to set a part of instance state to a new specified value?    
       
#.  If a class has one or more setter methods, is the object type 
    immutable?
   
#.  What is the return type for a setter method?
 
#.  If you want to set an instance variable in a method, should you declare
    that instance variable in the method?
    
#.  A method with what signature allows you to control how the string 
    concatenation operate (``+``) generates a string from the object?
    
#.  If you write an override the ``ToString`` method in a class, should the method
    print the string?   If not, what should it do with the resulting string?
    
#.  What is ``this``?

#.  Can aliased objects cause problems when created for an immutable object? 
    Mutable object?

#.  In a class with instance methods you can always design the class so variables
    are instance variables and not local variables.  When should you
    use local variables instead?
    
#. If an instance method has a formal parameter of the same type as the
   class being defined,
   can you refer to a private instance variable in the parameter object?  
   May you change it?
   How do you distinguish an instance variable for the current object from the
   corresponding instance variable for the parameter object?





    
