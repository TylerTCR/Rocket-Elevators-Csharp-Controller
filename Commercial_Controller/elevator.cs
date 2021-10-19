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
        public Door door;
        public List<int> floorRequestList;
        public List<int> completedRequestsList;

        // Constructor
        public Elevator(string _elevatorID)
        {
            this.ID = _elevatorID;
            this.status = "idle";
            this.currentFloor = 1;
            this.direction = null;
            this.door = new Door(Convert.ToInt32(ID));
            this.floorRequestList = new List<int>();
            this.completedRequestsList = new List<int>();
        }

        // Move function
        public void move()
        {
            // While the elevator's floor request list is not empty
            while (this.floorRequestList.Count != 0) {
                int[] tempArray = this.floorRequestList.ToArray();
                int destination = tempArray[0];
                if (this.currentFloor < destination) {
                    this.direction = "up";
                    sortFloorList(tempArray);
                    if (this.door.status == "opened") {this.door.status = "closed";}
                    this.status = "moving";
                    
                    // Move the elevator up until it reaches the floor
                    while (this.currentFloor != destination) {
                        this.currentFloor++;
                        Console.WriteLine("Floor: {0}", this.currentFloor);
                    }
                // If the elevator's current floor is higher than the destination
                } else if (this.currentFloor > destination) {
                    this.direction = "down";
                    sortFloorList(tempArray);
                    if (this.door.status == "opened") {this.door.status = "closed";}
                    this.status = "moving";

                    // Move the elevator down until it reaches the floor
                    while (this.currentFloor != destination) {
                        this.currentFloor--;
                        Console.WriteLine("Floor: {0}", this.currentFloor);
                    }
                }
                // Set elevator's status to stopped
                this.status = "stopped";
                // Open the doors
                this.door.status = "opened";
                // Add the destination to completed request list
                this.completedRequestsList.Add(destination);
                // Remove the first floor in the request list
                this.floorRequestList.RemoveAt(0);
            }
        }

        // Sort the request list in either ascending or descending order
        public void sortFloorList(int[] requestList) {
            if (this.direction == "up") {
                Array.Sort(requestList);
            } else {
                Array.Sort(requestList);
                Array.Reverse(requestList);
            }
        }
        
        // Add a new request to the floor request list, then set the direction
        public void addNewRequest(int requestedFloor) {
            if (!(this.floorRequestList.Contains(requestedFloor)) ) {
                floorRequestList.Add(requestedFloor);
            }

            if (this.currentFloor < requestedFloor) {
                this.direction = "up";
            } else if (this.currentFloor > requestedFloor) {
                this.direction = "down";
            }
        }
    }
}