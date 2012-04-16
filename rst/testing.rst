Testing
============

Now that we have learned a bit about classes, we're going to use the same feature
to support *unit testing*. Unit testing is a concept that will become part of just
about everything you do in future programming-focused courses, so we want to make sure
that you understand the idea and begin to make use of it in all of your work.

The notion of unit testing is straightforward in principle. When you write a program
in general, the program comprises what are properly known as units of development. 
Each language has its own definition of what units are but most modern programming
languages view the *class* concept as the core unit of testing. Once we have a class,
we can test it and all of the parts associated with it, especially its methods.


Assertions
-------------

A key notion of testing is the ability to make a logical assertion about something
that generally must hold *true* if the test is to pass. 

Assertions are not a standard language feature in C#. Instead, there are a number of
classes that provide functions for assertion handling. In the framework we are using for
unit testing (NUnit), a class named Assert supports assertion testing.

In our tests, we make use of an assertion method, ``Assert.IsTrue()`` to determine
whether an assertion is successful. If the variable or expression passed to this
method is *false*, the assertion fails.

Here are some examples of assertions:

- Assert.IsTrue(true): The assertion is successful, because the boolean value *true* 
  is true.
  
- Assert.IsTrue(false): The assertion is not successful, because the boolean value
  *false* is true.
  
- Assert.IsFalse(false): This assertion is succeesful, because the test for whether
  *false* is equal to *false* is true.
  
- Assert.IsTrue(5 > 0): success

- Assert.IsTrue(0 > 5): failure

There are many available assertion methods. In our tests, we use ``Assert.IsTrue()``,
which works for everything we want to test. Other assertion methods do their magic
rather similarly, because every assertion method ultimately must determine whether
what is being tested is true or false. 

Attributes
============

Besides assertions, a building block of testing (in C# and beyond) comes in the form
of attributes. Attributes are an additional piece of information that can be attached 
to classes, variables, and methods in C#. There are two attributes of interest to us:

- [TestFixture]: This indicates that a class is being used for testing purposes. 

- [Test]: This indicates that a method is one of the methods in a class being used
  for testing purposes.
  
Without these annotations, classes and methods will *not* be used for testing purposes.
This allows a class to have some methods that are used for testing while other methods
are ignored.



.. literalinclude:: ../projects/Music/Rational/RationalTests.cs
   :start-after: snip-ConstructorTest-begin
   :end-before: snip-ConstructorTest-end
   :linenos:


.. literalinclude:: ../projects/Music/Rational/RationalTests.cs
   :start-after: snip-ParseTest-begin
   :end-before: snip-ParseTest-end
   :linenos:


.. literalinclude:: ../projects/Music/Rational/RationalTests.cs
   :start-after: snip-BasicArithmeticTest-begin 
   :end-before: snip-BasicArithmeticTest-end
   :linenos:


.. literalinclude:: ../projects/Music/Rational/RationalTests.cs
   :start-after: snip-BasicComparisonTests-begin
   :end-before: snip-BasicComparisonTests-end
   :linenos:


.. literalinclude:: ../projects/Music/Rational/RationalTests.cs
   :start-after: snip-BasicConversionTests-begin
   :end-before: snip-BasicConversionTests-end
   :linenos:
