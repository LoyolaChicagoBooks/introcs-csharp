using System;
using System.IO;
using System.Collections.Generic;

// Names:
// Help from:
/* Help details:
*/

namespace Books
{

   /** A class that maintains information on a book. */
   public class Book
   {
      private String title;
      private String author;
      private int year;  // of publication

      public Book(String title, String author, int year)
      { //code

      }

      /** Return the title. */
      public String GetTitle()
      {  // code
   
         return "Not coded"; //just so skeleton compiles
      }

      /** Return the author. */
      public String GetAuthor()
      {

         return "Not coded"; //just so skeleton compiles
      }

      /** Return the year of publication. */
      public int Getyear()
      {  // copy code from before!

         return 0; //just so skeleton compiles
      }

      /** Return a multi-line String labeling all Book information. */
      public override string ToString()
      {  // code

         return "Not coded"; //just so skeleton compiles
      }

      ////////////////////////////////////
      // Extra credit methods hereafter //
      ////////////////////////////////////

      /** Construct a Book, taking data from reader.
         * Read through three lines that contain the
         * title, author, and year of publication, respectively.
         * There may be an extra blank line at the beginning.
         * If so ignore it.
         * Nothing beyond the line with the year is read. */
      public Book(StreamReader reader)
      {  // code for extra credit!

      }

      /** Return true if all the corresponding fields in this Book
         * and in aBook are equal.  Return false otherwise.  */
      public bool Equals(Book aBook)
      {// code for extra credit, before BookList changes

         return true; //so skeleton compiles
      }
   }
}
