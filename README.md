# Turtle Challenge

## Assumptions

1. Settings of the game is a Json file (settings.json) and moves are just a line in a txt file
2. Maze start at 0,0 from bottom/left

### Setup

1. setings.txt has a size of 4x5 (from 0 to 4 X axis and from 0 to 5 Y axis) // startPoint 0,0 // exitPoint 2,5 // direction 0 (North) and three mines 0,3 / 4,2 / 4,5


### Moves

1. "r" rotation
2. "m" moves forward one tile

## Run

```dotnet run settings.json success.txt
dotnet run settings.json nowhere.txt
dotnet run settings.json hitmine.txt
dotnet run settings.json outofbonds.txt
