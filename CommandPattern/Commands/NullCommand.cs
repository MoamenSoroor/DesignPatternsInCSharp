namespace CommandPattern
{
    // Null Object Pattern
    public class NullCommand : ICommand
    {
        public void Execute()
        {

        }

        public void Undo()
        {

        }

        public override string ToString()
        {
            return $"No Command";
        }
    }


}
