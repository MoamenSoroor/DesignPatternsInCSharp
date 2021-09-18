namespace CommandPattern
{
    public class RadioOffCommand : ICommand
    {
        private readonly Radio radio;

        public RadioOffCommand(Radio radio)
        {
            this.radio = radio;
        }

        public void Execute()
        {
            radio.Off();
        }

        public void Undo()
        {
            radio.On();
        }

        public override string ToString()
        {
            return $"Radio Off Command";
        }
    }



}
