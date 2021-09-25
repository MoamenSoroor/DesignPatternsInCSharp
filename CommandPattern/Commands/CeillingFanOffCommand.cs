namespace CommandPattern
{
    public class CeillingFanOffCommand : ICommand
    {
        private readonly CeillingFan fan;

        private FanState previousState;

        public CeillingFanOffCommand(CeillingFan fan)
        {
            this.fan = fan;
            previousState = fan.CurrentState;
        }

        public void Execute()
        {
            previousState = fan.CurrentState;
            
            fan.Off();
        }

        public void Undo()
        {
            switch (previousState)
            {
                case FanState.Off:
                    fan.Off();
                    break;
                case FanState.High:
                    fan.High();
                    break;
                case FanState.Meduim:
                    fan.Medium();
                    break;
                case FanState.Low:
                    fan.Low();
                    break;
                default:
                    break;
            }
        }

        public override string ToString()
        {
            return $"Fan High Command";
        }
    }

}
