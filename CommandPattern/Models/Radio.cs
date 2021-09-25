using System;

namespace CommandPattern
{
    public class Radio //: IOnBehavoir
    {
        private int volume = 0;
        private int channel = 1;

        const int MaxVolume = 4;
        const int MaxChannel = 100;

        public int Volume { get => volume; }
        public int Channel { get => channel; }

        public void On()
        {
            Console.WriteLine("Radio On");
        }

        public void Off()
        {
            Console.WriteLine("Radio Off");
        }

        public void IncreaseVolume()
        {

            volume = (volume == MaxVolume ? MaxVolume : volume + 1);
            Console.WriteLine($"Increase Volume to {volume}");
        }

        public void DecreaseVolume()
        {
            volume = (volume == 0 ? 0 : volume - 1);
            Console.WriteLine($"Decrease Volume to {volume}");
        }

    }



}
