# 21-points

Your task:
Make a simple game where:
the game generates a grid 4x4 with values between 1 and 11.
the player can choose which cells to pick to collect 21 points.
Ex: picking 3 cells with 3, 7, and 11 gives the player 21 points.
those cells should work as toggles (single click selects a given cell and a second click deselects the cell)
if the player exceeds 21 points (selects cells worth more than 21 points) he loses the value of selected cells divided by 2.
Ex: a player picks cells with the following numbers 4, 6, 3, and 10 which gives the sum of 23, the game will divide that value by 2 which equals 11 (we’re using int values here). This value (11) will be subtracted from the player's score.
the game finishes when the player scores 60 points.
The whole project can be made using only UI components.
You need 2 screens: gameplay and summary after which you can reset the scene or load it again.
Make it a mobile game that works in portrait mode - 1080x1920
Additional requirements:
Singletons are not allowed.
Avoid using too many GetComponents.
The quality of the solution will be considered.
Add comments where you think it will be necessary.
Separate logic from displaying - very simplistic MVC.
Consider using Unity Events.
