using System.Collections.Generic;
using System.Linq;
using static System.Environment;

namespace CommandPattern
{
    // invoker
    public class RemoteControlWithUndoRedo
    {
        private List<ICommand> onSlots;
        private List<ICommand> offSlots;
        
        private Stack<ICommand> undoStack;
        private Stack<ICommand> redoStack;

        public int UndoCount => undoStack.Count;
        public int RedoCount => redoStack.Count;

        public RemoteControlWithUndoRedo(int size)
        {
            
            onSlots = new List<ICommand>(size);
            offSlots = new List<ICommand>(size);
            undoStack = new Stack<ICommand>();
            redoStack = new Stack<ICommand>();

            for (int i = 0; i < size; i++)
            {
                onSlots.Add(new NullCommand());
                offSlots.Add(new NullCommand());
            }

        }


        public void SetCommands(int slot, ICommand onCommand, ICommand offCommand)
        {
            onSlots[slot] = onCommand;
            offSlots[slot] = offCommand;
            
            undoStack.Clear();
            redoStack.Clear();
        }


        public void PressOnSlotButton(int slot)
        {
            onSlots[slot].Execute();
            undoStack.Push(onSlots[slot]);
            redoStack.Clear();
        }

        public void PressOffSlotButton(int slot)
        {
            offSlots[slot].Execute();
            undoStack.Push(offSlots[slot]);
            redoStack.Clear();
        }

        public void PressUndoButton()
        {
            if(undoStack.Count > 0 )
            {
                var command = undoStack.Pop();
                command.Execute();
                redoStack.Push(command);
            }
        }

        public void PressRedoButton()
        {

            if (redoStack.Count > 0)
            {
                var command = redoStack.Pop();
                command.Execute();
                undoStack.Push(command);
            }
        }

        public override string ToString()
        {
            return $@"Remote Control Slots:
{string.Join(NewLine,Enumerable.Zip(onSlots,offSlots).Select((pair,i) => $"Slot[{i}]=> On: {pair.First,-30} Off:{pair.Second,-30}"))}
";
        }


    }





}
