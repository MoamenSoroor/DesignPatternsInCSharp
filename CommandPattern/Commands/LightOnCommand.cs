namespace CommandPattern
{
    public class LightOnCommand : ICommand
    {
        private readonly RoomLight light;

        public LightOnCommand(RoomLight light)
        {
            this.light = light;
        }

        public void Execute()
        {
            light.On();
        }

        public void Undo()
        {
            light.Off();
        }
        public override string ToString()
        {
            return $"Light On Command";
        }
    }



}
