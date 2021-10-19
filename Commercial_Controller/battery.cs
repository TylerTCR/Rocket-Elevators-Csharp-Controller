using System;
using System.Collections;
using System.Collections.Generic;

namespace Commercial_Controller
{
    public class Battery
    {
        // Properties of Battery
        public int ID = 1;
        public int columnID = 1;
        public string status;
        public List<Column> columnsList;
        public List<FloorRequestButton> floorRequestButtonList;

        // Constructor
        public Battery(int _ID, int _amountOfColumns, int _amountOfFloors, int _amountOfBasements, int _amountOfElevatorPerColumn)
        {
            this.ID = _ID;
            this.status = "online";
            this.columnsList = new List<Column>();
            this.floorRequestButtonList = new List<FloorRequestButton>();

            if (_amountOfBasements > 0) {
                this.createBasementFloorRequestButtons(_amountOfBasements);
                this.createBasementColumn(_amountOfBasements, _amountOfElevatorPerColumn);
                _amountOfColumns--;
            }

            this.createFloorRequestButtons(_amountOfFloors);
            this.createColumns(_amountOfColumns, _amountOfFloors, _amountOfBasements, _amountOfElevatorPerColumn);
        }

        public Column findBestColumn(int _requestedFloor)
        {
            foreach (Column column in this.columnsList) {
                // Loop through each floor in that column's servedFloors list
                for (int i = 0; i < column.servedFloors.Count; i+= 1) {
                    if (column.servedFloors[i] == _requestedFloor) {
                        return column;
                    }
                }
            }
            return null;
        }

        //Simulate when a user presses a button at the lobby
        public (Column, Elevator) assignElevator(int requestedFloor, string direction)
        {
            // Determine the chosen column
            Column chosenColumn = this.findBestColumn(requestedFloor);
            // Determine the chosen elevator within the column
            Elevator chosenElevator = chosenColumn.findElevator(1, direction);
            // Add the request to the elevator's new request list
            chosenElevator.addNewRequest(requestedFloor);
            // Time to move the elevator
            chosenElevator.move();

            /*Hashtable temp = new Hashtable();
            temp.Add("chosenColumn", chosenColumn);
            temp.Add("chosenElevator", chosenElevator);*/
            return (chosenColumn, chosenElevator);
        }

        public void createBasementColumn(int amountOfBasements, int elevatorsPerColumn)
        {
            List<int> servedFloors = new List<int>();
            int floor = -1;

            // Get the floor levels the column will serve 
            for (int i = 0; i < amountOfBasements; i++) {
                servedFloors.Add(floor);
                floor--;
            }

            Column column = new Column(columnID.ToString(), elevatorsPerColumn, servedFloors, true);
            this.columnsList.Add(column);
            columnID++;
        }

        public void createColumns(int amountOfColumns, int amountOfFloors, int amountOfBasements, int amountOfElevatorPerColumn)
        {
            decimal temp = amountOfFloors / amountOfColumns;
            int amountOfFloorsPerColumn = Convert.ToInt32(Math.Ceiling(temp));
            int floor = 1;

            // For each column and each floor within the column, add a floor to the servedFloors list
            for (int i = 0; i < amountOfColumns; i++) {
                List<int> servedFloors = new List<int>();
                for (int j = 0; j < amountOfFloorsPerColumn; j++) {
                    if (floor <= amountOfFloors) {
                        servedFloors.Add(floor);
                        floor++;
                    }
                }

                // Create a column then add it to the list of columns
                Column column = new Column(columnID.ToString(), amountOfElevatorPerColumn, servedFloors, false);
                this.columnsList.Add(column);
            } // Outer for-loop
        }

        public void createBasementFloorRequestButtons(int amountOfBasements)
        {
            int buttonFloor = -1, floorRequestButtonID = 1;
            // For each basement, create a floor request button
            for (int i = 0; i < amountOfBasements; i++) {
                FloorRequestButton floorRequestButton = new FloorRequestButton(floorRequestButtonID, buttonFloor, "down");
                this.floorRequestButtonList.Add(floorRequestButton);
                buttonFloor--;
                floorRequestButtonID++;
            }
        }

        public void createFloorRequestButtons(int amountOfFloors)
        {
            int buttonFloor = 1, floorRequestButtonID = 1;

            // For each above ground floor, create a floor request button
            for (int i = 0; i < amountOfFloors; i++) {
                FloorRequestButton floorRequestButton = new FloorRequestButton(floorRequestButtonID, buttonFloor, "up");
                this.floorRequestButtonList.Add(floorRequestButton);
                buttonFloor++;
                floorRequestButtonID++;
            }
        }
    }
}
