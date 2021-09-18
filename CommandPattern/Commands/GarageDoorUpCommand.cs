namespace CommandPattern
{
    public class GarageDoorUpCommand : ICommand
    {
        private readonly GarageDoor door;

        public GarageDoorUpCommand(GarageDoor door)
        {
            this.door = door;
        }

        public void Execute()
        {
            door.DoorUp();
        }

        public void Undo()
        {
            door.DoorDown();
        }


        public override string ToString()
        {
            return $"Door Up Command";
        }
    }



}
