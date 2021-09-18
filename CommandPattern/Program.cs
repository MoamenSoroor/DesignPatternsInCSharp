using System;
using System.Linq;

namespace CommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestSimpleRemote();
            //TestRemoteControlWithUndo();
            TestRemoteControlWithUndoRedo();
        }

        private static void TestSimpleRemote()
        {

            Console.WriteLine("================= Test Simple Remote =================");
            var light = new RoomLight();
            var door = new GarageDoor();
            var radio = new Radio();

            ICommand lightOnCommand = new LightOnCommand(light);
            ICommand lightOffCommand = new LightOffCommand(light);
            
            ICommand doorUpCommand = new GarageDoorUpCommand(door);
            ICommand doorDownCommand = new GarageDoorDownCommand(door);
            
            //ICommand radioOnCommand = new RadioOnCommand(radio);
            //ICommand radioOffCommand = new RadioOffCommand(radio);


            SimpleRemoteControl remote = new SimpleRemoteControl();


            WaitMessage("Set Remote Slot to Light On and Off");
            remote.SetCommands(lightOnCommand, lightOffCommand);
            Console.WriteLine(remote);


            WaitMessage("Remote sets light On");
            remote.PressOnSlotButton();

            WaitMessage("Remote sets light Off");
            remote.PressOffSlotButton();


            WaitMessage("Set Remote Slot to Door Up and Down.");
            remote.SetCommands(doorUpCommand, doorDownCommand);


            WaitMessage("Door Up");
            remote.PressOnSlotButton();


            WaitMessage("Door Down.");
            remote.PressOffSlotButton();


            //remote.SetCommands(radioOnCommand, radioOffCommand);
            //remote.PressOnSlotButton();
            //remote.PressOffSlotButton();


            WaitMessage("end the program.");

        }
        
        private static void TestRemoteControlWithUndo()
        {

            Console.WriteLine("================= Test RemoteControl with Undo Functionality =================");
            var light = new RoomLight();
            var door = new GarageDoor();
            var radio = new Radio();

            ICommand lightOnCommand = new LightOnCommand(light);
            ICommand lightOffCommand = new LightOffCommand(light);

            ICommand doorUpCommand = new GarageDoorUpCommand(door);
            ICommand doorDownCommand = new GarageDoorDownCommand(door);

            ICommand radioOnCommand = new RadioOnCommand(radio);
            ICommand radioOffCommand = new RadioOffCommand(radio);


            RemoteControlWithUndo remote = new RemoteControlWithUndo(3);


            WaitMessage("Setup Slops of the RemoteControl");
            remote.SetCommands(0,lightOnCommand, lightOffCommand);
            remote.SetCommands(1,doorUpCommand, doorDownCommand);
            remote.SetCommands(2,radioOnCommand, radioOffCommand);

            Console.WriteLine(remote);


            WaitMessage("Remote sets light On then off");
            remote.PressOnSlotButton(0);
            remote.PressOffSlotButton(0);


            WaitMessage("garage door up then down");
            remote.PressOnSlotButton(1);
            remote.PressOffSlotButton(1);


            WaitMessage("radio on then off");
            remote.PressOnSlotButton(2);
            remote.PressOffSlotButton(2);


            WaitMessage("Undo All Operations");
            // undo all operations
            int undoCount = remote.UndoCount;
            for (int i = 0; i < undoCount; i++)
            {
                remote.PressUndoButton();
            }

            WaitMessage("end the program.");

        }

        private static void TestRemoteControlWithUndoRedo()
        {

            Console.WriteLine("================= Test RemoteControl with Undo Functionality =================");
            var light = new RoomLight();
            var door = new GarageDoor();
            var radio = new Radio();

            ICommand lightOnCommand = new LightOnCommand(light);
            ICommand lightOffCommand = new LightOffCommand(light);

            ICommand doorUpCommand = new GarageDoorUpCommand(door);
            ICommand doorDownCommand = new GarageDoorDownCommand(door);

            ICommand radioOnCommand = new RadioOnCommand(radio);
            ICommand radioOffCommand = new RadioOffCommand(radio);


            RemoteControlWithUndoRedo remote = new RemoteControlWithUndoRedo(3);


            WaitMessage("Setup Slops of the RemoteControl");
            remote.SetCommands(0, lightOnCommand, lightOffCommand);
            remote.SetCommands(1, doorUpCommand, doorDownCommand);
            remote.SetCommands(2, radioOnCommand, radioOffCommand);

            Console.WriteLine(remote);


            WaitMessage("Remote sets light On then off");
            remote.PressOnSlotButton(0);
            remote.PressOffSlotButton(0);


            WaitMessage("garage door up then down");
            remote.PressOnSlotButton(1);
            remote.PressOffSlotButton(1);


            WaitMessage("radio on then off");
            remote.PressOnSlotButton(2);
            remote.PressOffSlotButton(2);


            WaitMessage("Undo All Operations");
            // undo all operations
            int undoCount = remote.UndoCount;
            for (int i = 0; i < undoCount; i++)
                remote.PressUndoButton();

            WaitMessage("Redo All Operations");
            // undo all operations
            int redoCount = remote.RedoCount;
            for (int i = 0; i < redoCount; i++)
                remote.PressRedoButton();

            WaitMessage("end the program.");

        }





        private static void WaitMessage(string message)
        {
            Console.WriteLine($"Press << Enter >> to {message}.");
            Console.ReadLine();
        }

    }



}
