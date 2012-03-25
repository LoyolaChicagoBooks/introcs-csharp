using System;
using System.IO;
using System.Collections.Generic;

namespace CSProject
{
   
   /**
    * A "Room" represents one location in the scenery of the game.  It is 
    * connected to other rooms via exits.  For each existing exit, the room 
    * stores a reference to the neighboring room.
    * 
    * Derived from work of  Michael Kolling and David J. Barnes
    */
   public class Room
   {
      public string Description { get; private set; }

      private Dictionary<string, Room> exits; // stores exits of this room.
   
      /**
        * Create a room described by description. Initially, it has
        * no exits.  The description is something like "in a kitchen" or
        * "in an open court yard".
        */
      public Room (string description)
      {
         Description = description;
         exits = new Dictionary<string, Room> ();
      }
       
      /**
        * Create rooms and their interconnections by taking room names, exit 
        * data and descriptions from a text file.  
        * Return a map of room names to rooms.  File format for each room: 
        *   First line:  room name (one word)
        *   Second line: pairs of exit direction and neighbor room name 
        *   Remaining paragraph: room description, blank line terminated  */
      public static Dictionary<string, Room> createRooms (string fileName)
      {
         StreamReader reader = FileUtil.GetDataReader(fileName);
         // Map to return
         Dictionary<string, Room> rooms = new Dictionary<string, Room> ();
          
         // temporary Map to delay recording exits until all rooms exist
         Dictionary<string, string> exitStrings =
                                       new Dictionary<string, string> ();
          
         while (!reader.EndOfStream) {
            string name = reader.ReadLine ();
            string exitPairs = reader.ReadLine ();
            // You could also substitute your lab's ReadParagraph for the two
            //   lines below if you want to format each paragraph line yourself.
            string description = FileUtil.LineWrap(reader);
            reader.ReadLine(); // assume empty line after description
            rooms [name] = new Room (description);
            exitStrings [name] = exitPairs;
         }
         reader.Close ();
         // need rooms before you can map exits
         // go back and use exitPairs to map exits:
         foreach (string name in rooms.Keys) {
            Room room = rooms [name];
            string[] parts = FileUtil.SplitWhite(exitStrings[name]);
            for (int i = 0; i < parts.Length; i += 2) {
               room.setExit (parts [i], rooms [parts [i + 1]]);
            }
         }
         return rooms;
      }
   
      /**
        * Define an exit from this room.
        *  Going to the exit in this direction 
        *  leads to neighbor room.
        */
      public void setExit (string direction, Room neighbor)
      {
         exits [direction] = neighbor;
      }
      
      /**
        * Return a description of the room in the form:
        *     You are in the kitchen.
        *     Exits: north west
        */
      public string getLongDescription ()
      {
         return "You are " + Description + ".\n" + getExitstring ();
      }
   
      /**
        * Return a string describing the room's exits, for example
        * "Exits: north west".
        */
      private string getExitstring ()
      {
         string s = "Exits: ";
         foreach (string e in exits.Keys) {
            s += e + ' ';
         }
         return s;
      }
   
      /**
        * Return the room that is reached if we go from this room in direction
        * "direction". If there is no room in that direction, return null.
        */
      public Room getExit (string direction)
      {
         if (exits.ContainsKey (direction)) {
            return exits [direction];
         }
         return null; 
      }
   }
}
