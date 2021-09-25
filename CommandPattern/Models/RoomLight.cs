using System;

namespace CommandPattern
{
    //public interface IOnBehavoir
    //{
    //    void On();
    //    void Undo();
    //}

    public class RoomLight //: IOnBehavoir
    {
        // 
        public void On()
        {
            Console.WriteLine("RoomLight On");
        }

        public void Off()
        {
            Console.WriteLine("RoomLight Off");
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }



}
