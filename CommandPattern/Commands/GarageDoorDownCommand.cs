namespace CommandPattern
{
    public class GarageDoorDownCommand : ICommand
    {
        private readonly GarageDoor door;

        public GarageDoorDownCommand(GarageDoor door)
        {
            this.door = door;
        }

        public void Execute()
        {
            door.DoorDown();
        }

        public void Undo()
        {
            door.DoorUp();
        }

        public override string ToString()
        {
            return $"Door Down Command";
        }

    }



}
