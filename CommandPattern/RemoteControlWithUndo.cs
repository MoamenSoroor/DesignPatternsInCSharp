using System.Collections.Generic;
using System.Linq;
using static System.Environment;

namespace CommandPattern
{
    // invoker
    public class RemoteControlWithUndo
    {
        private List<ICommand> onSlots;
        private List<ICommand> offSlots;
        
        private Stack<ICommand> undoStack;

        public int UndoCount => undoStack.Count;

        public RemoteControlWithUndo(int size)
        {
            

            onSlots = new List<ICommand>(size);
            offSlots = new List<ICommand>(size);
            undoStack = new Stack<ICommand>();

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
        }


        public void PressOnSlotButton(int slot)
        {
            onSlots[slot].Execute();
            undoStack.Push(onSlots[slot]);
        }

        public void PressOffSlotButton(int slot)
        {
            offSlots[slot].Execute();
            undoStack.Push(offSlots[slot]);

        }

        public void PressUndoButton()
        {
            if(undoStack.Count > 0 )
            {
                var action = undoStack.Pop();
                action.Execute();
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
