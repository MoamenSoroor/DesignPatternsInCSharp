namespace CommandPattern
{
    public class RadioIncreaseVolumeCommand : ICommand
    {
        private readonly Radio radio;

        public RadioIncreaseVolumeCommand(Radio radio)
        {
            this.radio = radio;
        }

        public void Execute()
        {
            radio.IncreaseVolume();
        }

        public void Undo()
        {

            radio.DecreaseVolume();
        }

        public override string ToString()
        {
            return $"Increase Volume Command";
        }
    }



}
