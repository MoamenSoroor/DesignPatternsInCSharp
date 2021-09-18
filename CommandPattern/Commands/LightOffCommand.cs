namespace CommandPattern
{
    public class LightOffCommand : ICommand
    {
        private readonly RoomLight light;

        public LightOffCommand(RoomLight light)
        {
            this.light = light;
        }

        public void Execute()
        {
            this.light.Off();
        }

        public void Undo()
        {
            this.light.On();
        }

        public override string ToString()
        {
            return $"Light Off Command";
        }
    }



}
