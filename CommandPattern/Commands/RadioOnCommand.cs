namespace CommandPattern
{
    public class RadioOnCommand : ICommand
    {
        private readonly Radio radio;

        public RadioOnCommand(Radio radio)
        {
            this.radio = radio;
        }

        public void Execute()
        {
            radio.On();
        }

        public void Undo()
        {

            radio.Off();
        }

        public override string ToString()
        {
            return $"Radio On Command";
        }
    }

}
