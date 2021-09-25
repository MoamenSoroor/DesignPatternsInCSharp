namespace CommandPattern
{
    // invoker
    public class SimpleRemoteControl
    {
        private ICommand onSlot;

        private ICommand offSlot;

        public SimpleRemoteControl()
        {
            onSlot = new NullCommand();
            offSlot = new NullCommand();

        }



        public void SetCommands(ICommand onCommand,ICommand offCommand)
        {
            onSlot = onCommand;
            offSlot = offCommand;
        }


        public void PressOnSlotButton()
        {
            onSlot.Execute();
        }

        public void PressOffSlotButton()
        {
            offSlot.Execute();
        }

        public override string ToString()
        {
            return $@"Simple Remote State:
    On Slot: {onSlot,40} Off Slot: {offSlot,40}
";
        }


    }





}
