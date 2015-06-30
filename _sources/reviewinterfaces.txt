Chapter Review Questions
=========================

For these review questions, assume ``Foo`` is an interface type that you
have access to.

#.  Suppose you are writing a new class that you want to satisfy 
    an existing interface:
    
    a.  Is matching the signatures required by the interface enough?
    #.  What else do you need in the new class heading?
 
#.  With interface type ``Foo`` can you:

    a. Declare a formal parameter of type ``Foo``?
    #. Declare a list of type ``List<Foo>``?
    #. Declare an array of type ``Foo[]``?
    #. Create a new object with ``new Foo()``?
  
#.  If you have an array of type ``Foo[]``, then each element is
    an object which has an underlying class type.  Must each element
    have the *same* underlying class type?
    
#.  An interface type ``Foo`` has what heading (simplest)?

#.  An interface type definition includes the signatures of all the methods
    for that interface.  What is included after each signature?
    
#.  May an interface definition include a constructor?

#.  May a class satisfying an interface have further methods not listed
    in the interface?
    
#.  Identify the legal interface declarations, and say what is wrong with
    any other code. ::
        
            public interface A
            {
                void f(List<int> L) 
                {
                    L.Add(7);
                }
            }
        
    ::
        
            public interface B
            {
                void f(List<int> L);
            }
       
    ::
        
            public interface C
            {
                void f(List<int> L);
                int g(int x);
            }
       
    ::
        
            public interface D
            {
                D(int a);
                void f(List<int> L);
            }
       
    ::
        
            public class E
            {
                int g(int x);
            }
       
#.  Which of these class definitions make the class implement the legal
    interface C above?  Explain the problem with any that do not.  
    ::    
    
            public class CA 
            {
                public void f(List<int> L)
                {
                    L.Add(7);
                }
            
                public int g(int x)
                {
                   return x*x;
                }
            }
    
    ::    
        
            //  Same as CA, except with heading     
            public class CB : C
            // ...

    ::    
    
            public class CC : C 
            {
                public void f(List<int> L)
                {
                    L.Add(7);
                }
            
                public void g(int x)
                {
                   Console.WriteLine(x*x);
                }
            }

    ::    
    
            public class CD : C 
            {
                public void f(List<int> L)
                {
                    L.Add(7);
                }            
            }
    
    ::    
    
            public class CE : C 
            {
                private int a;
            
                public CE(int a)
                {
                   this.a = a;
                }
            
                public void f(List<int> L)
                {
                    L.Add(a);
                }
            
                public void h(int x)
                {
                   Console.WriteLine(a*x*x);
                }

                public int g(int x)
                {
                   return x*a;
                }
            }
    
    
        



