# Rocket-Elevators-Csharp-Controller
This is Tyler's Rocket Elevators' Commercial Controller coded in c#.

A brief run-down on how the controller works; When someone at the lobby presses a floor they want to go to, it will find the best column and elevator within that column to pick up the person and take them to the floor they want. However, if someone is at another floor and they call an elevator, it will find the best elevator within that column to take them to the lobby.

### Installation

As long as you have **.NET 5.0** installed on your computer, nothing more needs to be installed:

The code to run the scenarios is included in the Commercial_Controller folder, and can be executed there with:

`dotnet run <SCENARIO-NUMBER>`

### Running the tests

To test this controller with scenarios, make sure to be at the root of the repository and run:

`dotnet test`

To get more details about each test, simply add the `-v n` flag at the end like so: 

`dotnet test -v n`