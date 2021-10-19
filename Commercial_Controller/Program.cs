using System;
using System.Collections.Generic;

namespace Commercial_Controller
{
    class Program
    {
        public int columnID = 1;
        public int elevatorID = 1;
        public int FloorRequestButtonID = 1;
        public int callButtonID = 1;

        static void Main(string[] args)
        {
            // int scenarioNumber = Int32.Parse(args[0]);
            // Scenarios scenarios = new Scenarios();
            // scenarios.run(scenarioNumber);
            List<int> floors = new List<int> {1, 2,3};
            Column c1 = new Column("1", 2, floors, false);

        }
    }
}
