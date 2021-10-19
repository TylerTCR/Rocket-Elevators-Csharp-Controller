using System;
using System.Threading;
using System.Collections.Generic;

namespace Commercial_Controller
{
    public class Elevator
    {
        public string ID;
        public string status;
        public int currentFloor;
        public string direction;
        public object door;
        public List<int> floorRequestList;
        public List<int> completedRequestList;

        // Constructor
        public Elevator(string _elevatorID)
        {
            this.ID = _elevatorID;
            this.status = "idle";
            this.currentFloor = 1;
            this.direction = null;
            this.door = new Door(Convert.ToInt32(ID));
            this.floorRequestList = new List<int>();
            this.completedRequestList = new List<int>();
        }

        // Move function
        public void move()
        {
            int[] tempArray = this.floorRequestList.ToArray();
            // While the elevator's request is not empty
            while (tempArray.Length != 0) {
                int destination = tempArray[0];
                this.status = "moving";
                if (this.currentFloor < tempArray[0]) {
                    this.direction = "up";
                    sortFloorList(tempArray);
                    
                    while (this.currentFloor)
                }
            }
        }
        
    }
}