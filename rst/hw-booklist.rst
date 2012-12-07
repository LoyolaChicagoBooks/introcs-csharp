.. index::
   double: homework; booklist
   double: homework; OOP

.. _booklist:

Book List Assignment
======================
 
**Objectives**:

-  Complete a simple data storing class (Book), with fields for title, author, and
   year of publication.
-  Complete a class with a Collection (BookList) that uses the public methods 
   of another class you wrote (Book), and select various data from the list.
-  Complete a testing program (TestBookList), that creates a
   BookList, adds Books to the BookList, and tests BookList
   methods clearly and completely for a user looking at the output
   of the program and *not* the source code..

Copy stub files from the project :repsrc:`books_homework_stub` to your own
project.  
Stubs for the assignment files are 
:repsrc:`book.cs <books_homework_stub/book.cs>`, 
:repsrc:`book_list.cs <books_homework_stub/book_list.cs>`, and
:repsrc:`test_book_list.cs <books_homework_stub/test_book_list.cs>`, 

Some of the method stubs included are only to be fleshed out if you are doing
the corresponding extra credit option.  They include a comment,
just inside the method, ``// code for extra credit``.  
There are also extra files used by the extra credit portion.
They are discussed
in the Extra Credit section at the end of the assignment.

Complete the first line in each file to show your names. At the top of
the Book class include any comments about help in *all* of the classes.

Create methods one at a time, and test them.  Complete :file:`book.cs` first,
preferably testing along the way.  Then add methods to
:file:`book_list.cs`, and concurrently add and run tests in :file:`test_book_list.cs`.
Though you are only required to have
a class to test the final result, you are strongly encouraged to flesh out
:file:`test_book.cs`, so it does not depend on BookList.  Then when you get to 
BookList you can have more confidence that any problems you have are from the latest
part you wrote, not parts written earlier in the class Book.

Remember to have each individual submit a **log**, :file:`log.txt`, 
in the same format as the last assignment. 

Book class
--------------

See the stub file provided. It should have instance fields for the
author, title, and year (published).
 
Complete the constructor::

    public Book(string title, string author, int year)

that initializes the fields. 
(Be careful, as we have discussed in class, when using the same names
for these parameters as the instance variables!)

It should have three standard (one line) getter methods::

    public string GetTitle()
    
    public string GetAuthor()
    
    public int GetYear()
    
and ::

    public override string ToString()

``ToString`` should return a *single* string spread across three lines,
with no newline at the end.
For example if the ``Book`` fields were
"C# Yellow Book", "Rob Miles", and 2011, the string should appear,
when printed, as

.. code-block:: none

   Title: C# Yellow Book
   Author: Rob Miles
   Year: 2011

The ``override`` in the heading is important so the compiler knows that this 
is the official method for the system to used implicitly to convert the object 
to a string.

Remember the use of @ with multi-line string literals.

BookList class
------------------

It has just one instance variable, already declared::

   private List<Book> list;

It has a constructor (already written - creating an empty List)::

    public BookList() 

It should have public methods:

.. literalinclude:: ../source/examples/books_homework_stub/book_list.cs
   :start-after:  AddBook chunk
   :end-before: {
       
The regular version should just leave the final ``return true;``
The extra credit version is more elaborate. 

Further methods:

.. literalinclude:: ../source/examples/books_homework_stub/book_list.cs
   :start-after:  PrintList chunk
   :end-before: {

.. literalinclude:: ../source/examples/books_homework_stub/book_list.cs
   :start-after:  PrintTitlesByAuthor chunk
   :end-before: {

.. literalinclude:: ../source/examples/books_homework_stub/book_list.cs
   :start-after:  PrintBooksInYears chunk
   :end-before: {

For instance if the list included books published in 1807, 1983, 2004,
1948, 1990, and 2001, the statement ::

   PrintBooksInYears(1940, 1990);
   
would list the books from 1983, 1948, and 1990.

TestBookList class
----------------------

It should have a ``Main`` program that creates a BookList, adds some books
to it (more than in the skeleton!), and convincingly displays tests of
each of BookList's methods that exercise all paths through your code.
Check for one-off errors in PrintBookYears. With all the methods that
print something, the results are easy to see. Do print a label, as in
the skeleton, before printing output from each method test, so that the
user of the program can see the correctness of the test 
*without any knowledge of the source code*!

Grading Rubric
--------------------

Book class.  Requires the constructor.  Then

- [1 point] public Book(string title, string author, int year)
- [1] public string GetTitle()
- [1] public string GetAuthor()
- [1] public int GetYear()
- [2] public override string ToString()
 
BookList class

- [2] public bool AddBook(Book book)
- [2] public void PrintList()
- [2] public void PrintTitlesByAuthor(string author)
- [2] public void PrintBooksInYears(int firstYear, int lastYear)

TestBookList

- [2] Supply data to screen indicating what test is being done with what
  data and what results, so it is clear that each test works without
  looking at the source code.
- [5] Convincingly display tests of each of BookList's methods that
  exercise all paths through your code. 

Overall:

- [4] Make your code easy to read - follow indenting standards, use
  reasonable identifier names....  Do not duplicate code when
  you could call a method already written.


Extra Credit 
-------------------------------

You may do any of the numbered options, except that the last one 
requires you to do the previous one first.

To get full credit for any particular option, tests for it must be 
*fully integrated* into TestBookList!

#.  [2 points] Complete 

    .. literalinclude:: ../source/examples/books_homework_stub/book_list.cs
       :start-after:  ToString chunk
       :end-before: {

    Also *change* the ``PrintList`` method body to the one line::
    
        Console.Write(this);
    
    (The ``Write`` and ``WriteLine`` methods print objects by using their `
    `ToString`` methods.)
    
    Be sure to make this addition to TestBookList: 
    Test the ``ToString`` method by converting the
    resulting BookList description string to upper case before printing it
    (which should produce a different result than the regular mixed case of
    the ``PrintList`` method test).

#.  [4 points] 

    In the Book class, a new constructor:

    .. literalinclude:: ../source/examples/books_homework_stub/book.cs
       :start-after:  Book chunk
       :end-before: {
    
    In class BookList, a new constructor:
    
    .. literalinclude:: ../source/examples/books_homework_stub/book_list.cs
       :start-after:  BookList chunk
       :end-before: {
    
    For testing we included special files in the right format:
    :repsrc:`books_homework_stub/books.txt` and :repsrc:`books_homework_stub/morebooks.txt`.
    
    You will also want to include a reference to :repsrc:`fio/fio.cs`, so the text files are
    easy to find.

#.  [4 points] 

    In class Book:

    .. literalinclude:: ../source/examples/books_homework_stub/book.cs
       :start-after:  IsEqual chunk

    It is essential to have the ``IsEqual`` method working in Book before any of
    the new code in BookList, which all depends on the definition of ``IsEqual``
    for a Book.
    
    NOTE: We chose the name ``IsEqual`` to distinguish it from the
    more general ``Equals`` override that you could write.
    The ``Equals`` override allows for a parameter of any object type. With
    skills from Comp 271 you you be able to write the ``Equals`` override.
    
    In class BookList:
    
    .. literalinclude:: ../source/examples/books_homework_stub/book_list.cs
       :start-after:  Contains chunk
       :end-before: {

    Caution: Do NOT try to use the ``List`` method ``Contains``: Because we
    did *not* override the ``Equals`` method to specialize it for Books, the ``List``
    method ``Contains`` will *fail*. You need to do a litle bit more
    work and write your own version with a loop.
    
    Change the ``AddBook`` method from the regular assignment, so it 
    satisfies this documentation:
    
    .. literalinclude:: ../source/examples/books_homework_stub/book_list.cs
       :start-after:  Revised AddBook
       :end-before: }

    In TestBookList you need to react to the return value, too.
        
#.  [2 points] This one requires the previous elaboration of ``AddBook``. 
    In BookList:    
        
    .. literalinclude:: ../source/examples/books_homework_stub/book_list.cs
       :start-after:  AddAll chunk
       :end-before: {

    You might want to code it first without worrying about the correct
    return value; then do the complete version. There are multiple
    approach to determining the return value, some much easier than
    others!
    
    To fully test in TestBookList, you need to react to the return value, too.
