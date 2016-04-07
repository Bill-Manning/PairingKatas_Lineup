# Lineup

The lineup project is a "solver" based program meant for use in a Pairing Kata.

#Setup

You are the coach of the Seattle Monsters, a local beer league softball team. You have 16 players on your team and you have to set line ups for each game in your schedule. You've evaluated each of your players, and have assigned them a rank per position (1 is that player's worst position, 10 is that player's best.) For sake of this thing, you can assume that a player who is ranked the same as another are equivalently skilled.  A 10 is a 10.

You have a 15 game schedule, which players have varying availability for. All players have told you ahead of time whether or not they are available to play in each game.

You have an extremely strict league, and must create a lineup that adheres to league rules.  If you cannot make a lineup that meets those rules, you have to forfeit the game!

##The Goal

Write a command-line application which creates valid lineups, taking into account players availability. It should write out those lineups to the current director, in the following format.

Filename: Game {Game Number} - {Opponent}.txt
 Inning {Inning Number}
  {Position} - {Player}
  {Position} - {Player}
  {Position} - {Player}
  {Position} - {Player}
(repeat for all games / innings)

###Data
Data to support this can be found in CSV files in the Data folder.

+ *Schedule.csv* gives you your game schedule information. Game Number and Opponent
+ *Player.csv* gives you player information, Name and Gender.
+ *PlayerGameAvailability.csv* indicates which games players are *UNAVAILABLE* for. (You can assume available, if they are not in that list.)  Game Number, and Name
+ *PlayerPositions.csv* gives you the ranking of each player per position. Name, Rank, Position.

A direct representation of this data is already loaded into a Domain class for you, though you are not required to use it.

###League Rules

Your league demands lineups that adhere to the following rules.

+ A game is made up of 7 and only 7 innings. Ties are allowed, so extra innings are not necessary.
+ Every lineup is made up of one player per position per inning. Players not assigned are considered "sitting out."
+ You must field a player in all positions.
+ Each inning's lineup must have at least 3 women, and at least 3 men. 
+ No player can play the same position more than 2 innings in a row.
+ No player may sit out for more than one consecutive inning.

###Extra Credit Options

1. Valid lineups are great, but are hardly ideal. Find a way to get the best players on the field to increase your chances of winning!

2. Players hate it when they sit out a lot (even if they suck). Find a way to minimize the number of times any player sits out.

3. When the Monsters play the Wizards, it's gonna be a blowout. To make the game more competitive and fun, when playing the Wizards, optimize to allow for positional improvement (i.e., let them play their worst position, rather than their best.)