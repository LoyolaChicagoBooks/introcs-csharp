using System;
namespace CSProject
{
   
   /**
    * Response to try to go to a new room.
    */
   public class Goer : Response
   {
      public string CommandName {get; private set;}
      private Game game;
      
      /**
        * Try to go to one direction. If there is an exit, enter the new
        * room, otherwise print an error message.
        * Return false(does not end game)
        */
      public bool Execute(Command command)
      {
         if(!command.hasSecondWord()) {
            // if there is no second word, we don't know where to go...
            Console.WriteLine("Go where?");
            return false;
         }
         string direction = command.SecondWord;
         // Try to leave current room.
         Room nextRoom = game.CurrentRoom.getExit(direction);
         if (nextRoom == null) {
            Console.WriteLine("There is no door!");
         }
         else {
            game.CurrentRoom = nextRoom;
            Console.WriteLine(nextRoom.getLongDescription());
         }
         return false;
      }
   
      public string Help()
      {
         return @"Enter
    go direction
to exit the current room in the specified direction.
The direction should be in the list of exits for the current room.";
      }
   
      /**
        * Constructor for objects of class Goer
        */    
      public Goer(Game game)
      {
         this.game = game;
         CommandName = "go";
      }
   }
}
