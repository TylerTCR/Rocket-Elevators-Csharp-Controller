namespace Commercial_Controller
{
    //Button on a floor or basement to go back to lobby
    public class CallButton
    {
        public int ID;
        public string status;
        public int floor;
        public string direction;

        public CallButton(int _ID, int _floor, string _direction)
        {
            this.ID = _ID;
            this.status = "off";
            this.floor = _floor;
            this.direction = _direction;
            
        }
    }
}