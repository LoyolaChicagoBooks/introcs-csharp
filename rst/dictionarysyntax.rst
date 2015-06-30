Dictionary Syntax
====================

We have explored several ways of storing a collection of the same type of data:

- arrays: built-in syntax, unchanging size of the collection
- List: generic class type, allows the size of the collection to grow

Both approaches allow reference to data elements using a 
numerical index between square brackets, as in ``words[i]``.  
The index provides an order for the elements,
but there is no meaning to the index beyond the sequence order.

Often, we want to look up data based on a more meaningful key, as in a 
dictionary: given a word,
you can look up the definition.

C# uses the type name ``Dictionary``, but with greater generality than in
nontechnical use. In a regular dictionary, you start with a word, 
and look up the definition.  The generalization is to have some piece of
data that leads you to (or *maps* to) another piece of data.  
The computer science jargon is that a *key* leads you to a *value*.
In a normal dictionary, these are both likely to be strings, but in the
C# generalization, the possible types of key and value are much more extensive.
Hence the generic ``Dictionary`` type requires you to specify 
both a type for the key and a type for the value.
    
We can initialize an English-Spanish dictionary ``e2sp`` with ::

    Dictionary<string, string> e2sp = new Dictionary<string, string>();
    
That is quite a mouthful!  The C# ``var`` syntax is handy to shorten it::

    var e2sp = new Dictionary<string, string>();

The general generic type syntax is 

   ``Dictionary<`` **keyType**\ ``,`` **valueType** ``>``
   
If you are counting the number of repetitions of words in a document, you are likely to want 
a ``Dictionary`` mapping each word to its number of repetitions so far::

    var wordCount = new Dictionary<string, int>();
    
If your friends all have a personal list of phone numbers, you might look them up
with a dictionary with a string name for the key and a ``List`` of personal phone number
strings for the value.  The type could be ``Dictionary<string, List<string>>``.  
This example illustrates how one generic type can be built on another.

There is no restriction on the value type.  There is one important technical 
restriction on the key type: it should be immutable. This has to do with the implementation
referenced in :ref:`dictionary-efficiency`.

.. index::
   dictionary; key lookup [ ]
   single: [ ]; dictionary key lookup
   
Similar to an array or ``List``,  
you can assign and reference elements of a ``Dictionary``, 
using square bracket notation.  The difference is that the reference is through a key, 
not a sequential index, as in::

    e2sp["one"] = "uno";
    e2sp["two"] = "dos";
    
Csharp displays dictionaries in its own special form, 
as a sequence of pairs {key, value}.  Again, this is *special* to csharp.  
Here is a longer csharp sequence, broken up with our comments:

..  code-block:: none

    csharp> Dictionary<string, string> e2sp = new Dictionary<string, string>();
    csharp> e2sp;
    {}
    csharp> e2sp["one"] = "uno";
    csharp> e2sp["two"] = "dos"; 
    csharp> e2sp["three"] = "tres";
    csharp> e2sp.Count;
    3   
    csharp> e2sp;                
    {{ "one", "uno" }, { "two", "dos" }, { "three", "tres" }}
    csharp> Console.WriteLine("{0}, {1}, {2}...", e2sp["one"], 
          > e2sp["two"], e2sp["three"]);
    uno, dos, tres...

.. index:: dictionary; Keys
   Keys property

If you want to iterate through a whole ``Dictionary``, you will want the syntax below,
with ``foreach`` and the property ``Keys``:

..  code-block:: none

    csharp> foreach (string s in e2sp.Keys) {
          >    Console.WriteLine(s);
          > }
    one
    two
    three
    
The documentation for ``Dictionary`` says
that you cannot depend on the order of processing with ``foreach``, though the present 
implementation remembers the order in which keys were added.


.. index:: example; ContainsKey
   dictionary; ContainsKey example
   ContainsKey example


It is often useful to know if a key is already in a ``Dictionary``:
Note the method ``ContainsKey``:

..  code-block:: none

    csharp> e2sp.ContainsKey("seven");
    false
    csharp> e2sp.ContainsKey("three"); 
    true

The method Remove takes a key as parameter.  Like a ``List`` and other
collections, a ``Dictionary`` has a ``Clear`` method:

..  code-block:: none

    csharp> e2sp.Count;
    3
    csharp> e2sp.Remove("two");
    true
    csharp> e2sp.Count;
    2
    csharp> e2sp.Clear();
    csharp> e2sp.Count;
    0
