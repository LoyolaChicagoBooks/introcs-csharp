.. index::
   double: assignment; booklist
   double: assignment; OOP
   double:  OOP; assignment

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

Stubs for the assignment files are :file:`Book.cs`, :file:`BookList.cs` and 
:file:`TestBookList.cs` in the
project :file:`HW/Books`. 

Some of the method stubs included are only to be fleshed out if you are doing
the corresponding extra credit option.  They include a comment,
just inside the method, ``// code for extra credit``.  
There are also extra files used by the extra credit portion.
They are discussed
in the Extra Credit section at the end of the assignment.

Complete the first line in each file to show your names. At the top of
the Book class include any comments about help in *all* of the classes.

Create these classes one at a time and test as you finish
each class or even as you finish each method.  Though you are only required to have
a class to test the final result, you are strongly encouraged to write a simple
testing class for Book, that does not depend on BookList, so when you get to 
BookList you can have more confidence that any problems you have are from the latest
part you wrote, not earlier parts that you refer to.

Remember to have each team member submit a log also, 
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
    
and one method to format all the information as a string::
    
    public override string ToString()

``ToString`` should return a single string spread across three lines,
with no newline at the end.
For example if the ``Book`` fields were
"C# Yellow Book", "Rob Miles", and 2011, the string should appear,
when printed, as

     | Title: C# Yellow Book
     | Author: Rob Miles
     | Year: 2011

The ``override`` in the heading is important so the compiler knows that this 
is the official method for the system to used implicitly to convert the object 
to a string.

BookList class
------------------

It has just one instance variable, already declared::

   private List<Book> list;

It has a constructor (already written - creating an empty List)::

    public BookList() 

It should have public methods::

   /** Add a book to the list. 
     * The regular assignment version always returns true. */
   public bool AddBook(Book book)
   
The regular version should just leave the final ``return true;``
The extra credit version is more elaborate. 

Further methods::

   /** List the full descriptions of each book, 
     * with each book separated by a blank line. */
   public void PrintList()

   /** List the titles (only!) of each book in the list
     * by the specified author, one per line. */
   public void PrintTitlesByAuthor(string author)

   /** List the full descriptions of each book printed 
     * in the range of years specified,
     * with descriptions separated by a blank line. */
   public void PrintBooksInYears(int firstYear, int lastYear)

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
without any knowledge of the source code!

Grading Rubric
--------------------

Book class.  Requires the constructor.  Then

- [1 point] public Book(string title, string author, int year)
- [1] public string GetTitle()
- [1] public string GetAuthor()
- [1] public int GetYear()
- [2] public overload string ToString()
 
BookList class

- [2] public bool AddBook(Book book)
- [2] public void PrintList()
- [2] public void PrintTitlesByAuthor(string author)
- [2] public void PrintBooksInYears(int firstYear, int lastYear)

TestBookList

- [2] supply data to screen indicating what test is being done with what
  data and what results, so it is clear that each test works without
  looking at the source code
- [5] convincingly display tests of each of BookList's methods that
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

#.  [2 points] Complete the ToString method for the BookList class that returns (not prints)
    the content described by the PrintlList method above as a single string
    (including a final newline). Also *change* the PrintList method body to
    the one line::
    
        Console.Write(this);
    
    (The Write and WriteLine methods print objects by using their ToString
    methods.)
    
    In your testing class, test the ToString method by converting the
    resulting BookList description string to upper case before printing it
    (which should produce a different result than the regular mixed case of
    the PrintList method test).

#.  [4 points]

    In the Book class, a new constructor::

        /** Construct a Book, taking data from reader.
          * Read through three lines that contain the
          * title, author, and year of publication, respectively.
          * There may be an extra blank line at the beginning. 
          * If so ignore it. 
          * Nothing beyond the line with the year is read. */
        public Book(StreamReader reader)

    I made it easy to open a data file with ``FileUtil.GetDataReader``, copied from
    your recent lab, as in::
    
        StreamReader reader = FileUtil.GetDataReader("books.txt");
    
    This way you do not need a special run option in MonoDevelop.
    
    In class BookList, a new constructor::
    
        /** Construct a new BookList using Book data read from
          * reader.  The data coming from reader will contain groups
          * of three line descriptions useful for the Book constructor
          * that reads from stream.  Each three-line book description
          * may or may not be preceded by an empty line. */
        public BookList(StreamReader reader)
    
    I also included files in the right format for testing:
    :file:`books.txt` and :file:`morebooks.txt`.

#.  [4 points] 

    In class Book::

        /** Return true if all the corresponding fields in this Book
          * and in aBook are equal.  Return false otherwise.  */          
        public bool Equals(Book aBook)
    
    It is essential to have the Equals method working in Book before any of
    the new code in BookList, which all depends on the definition of Equals
    for a Book.
    
    NOTE: This is *not* the most general version of Equals you could write.
    The more general one allows for a parameter of any object type. With
    skills from Comp 271 you you be able to write the more general version.
    
    In class BookList::
    
        /** Test if aBook is contained in this BookList.
          * Return true if book is equal to a Book in the list, 
          * false otherwise. */
        public bool Contains(Book book)

    Caution: Do NOT try to use the ``List`` method ``Contains``: Because we
    only defined a specialized version of Equals for Books, the ``List``
    method ``Contains`` will *fail*. You need to write your own version with a
    loop.
    
    Change the AddBook method from the regular assignment, so it 
    satisfies this documentation::
    
        /** Adds aBook to the list if aBook is 
          * not already in the list.
          * Return true if aBook is added, 
          * and false if it was already in the list. */
        public bool AddBook(Book aBook) 
        
    In TestBookList you need to react to the return value, too.
        
#.  [2 points] This one requires the previous elaboration of AddBook. 
    In BookList::    
        
         /** Add all the Books in books to this BookList.
           * Return true if the current list was changed. 
           * Return false if each Book in books is a 
           * duplicate of a Book in the current list. */
         public bool AddAll(BookList books)
     
    You might want to code it first without worrying about the correct
    return value; then do the complete version. There is more than one
    approach to determining the return value!
    
    In TestBookList you need to react to the return value, too.
