namespace CommandPattern
{


    public class CeillingFan
    {
        private  FanState currentState;

        public FanState CurrentState => currentState;

        public CeillingFan()
        {
            currentState = FanState.Off;
        }

        public void Off()
        {
            currentState = FanState.Off;
        }

        public void Low()
        {
            currentState = FanState.High;
        }

        public void Medium()
        {
            currentState = FanState.Meduim;
        }


        public void High()
        {
            currentState = FanState.Low;
        }


    }



    public enum FanState
    {
        Off=0,High,Meduim,Low
    }

}
