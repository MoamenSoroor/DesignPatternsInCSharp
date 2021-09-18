namespace CommandPattern
{
    public class RadioDecreaseVolumeCommand : ICommand
    {
        private readonly Radio radio;

        public RadioDecreaseVolumeCommand(Radio radio)
        {
            this.radio = radio;
        }

        public void Execute()
        {
            radio.DecreaseVolume();
        }

        public void Undo()
        {
            radio.IncreaseVolume();
        }


        public override string ToString()
        {
            return $"Decrease Volume Command";
        }
    }



}
