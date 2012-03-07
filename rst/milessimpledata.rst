Comments on Miles Simple Data
=============================== 

Miles Chapter 2 on Simple Data Processing is also well written.  
Start by reading through section 2.3.1, ending on page 38.  As you *read it*, 
note the specific comments below.   The chapter does not mention the Mono tool,
csharp, which makes it very easy to test simple data operations. 

Page 27
	The table is for reference, context, and completeness:  
	You do NOT need to memorize all the types, particularly now!  
	Mostly used are int and char, and possibly long for really big numbers.

Page 28  
	We will mostly stick to double for convenience.  
	Using smaller versions is only important if you have enormous collections of data.  
	You do not need to use the E notation – though you may see it.

Page 29  
	This is another table for reference/completeness.  
	The only escape code we are likely to use are \\n, \\\\, \\".

Page 30
	Unicode is nice if you want different languages and special symbols, but we will not use it.

Page 33
	The precedence table is very misleading:
	It does not distinguish operands with the SAME precedence:
	Operators \* and /, have the same precedence. 
	The binary operations + and - have the same precedence.
	
	This is the same precedence as in normal math.  See the related section added below
	about another useful operator related to division, the remainder operator, %.
	It has the same precedence as \* and /. 

Page 34-35:   
	The idea of casting numbers is important, 
	that the same abstract number may have different representations, 
	and some are more or less accurate.  
	In practice the main cast for us will be int to double.  
	Make sure you realize that casting double to int is NOT the same as rounding; instead
	it removes the fractional part whether high, .999, low, 0.1, or in the middle, .5.


