# Entry 4
##### 3/11/24

I am currently in between **step 4 and step 5 of the Engineering Design Process**. I am figuring what I want my project to look like and then creating it. For now, I've thought about the idea of my map should be dungeon themed. After having the basic idea of what my project should look like, I began to create the map for my game.

Over the past few days I used this [video](https://www.youtube.com/watch?v=gHU5RQWbmWE) to help me create the map and write down the code for it. By following the tutorial in the video, I wrote down the first part of the code that allows me to generate my dungeon which I need for my map:

```CSharp
 public class DungeonGenerator : MonoBehaviour
{
  public class Cell
  {
    public bool visited = false;
    public bool[] status = new bool[4];
  }
  public Vector2 size;
  public int startPos = 0;
```
My goal for the map is to have many rooms and whenever the player go through a door a new room gets generated. This code initialize all the values like the boolean for if the room is already visited and the size and start position of each room.

After making the class and initializing the variables, I need to make the code that generates a new room whenever the user goes through a door. 

```CSharp
void MazeGenerator()
{
  board = new List<Cell>();

  for (int i = 0; i < size.x; i++)
  {
    for (int j = 0; j < size.y; j++)
    {
	board.Add(new Cell());
    }
  }

  int currentCell = startPos;
  Stack<int> path = new Stack<int>();
  int k = 0;

  while (k<1000)
  {
    k++;
    board[currentCell].visited = true;
    if(currentCell == board.Count - 1)
    {
      break;
    }
```
In this code, I first initalize the board as a list of cells. Then I need to create this board with all the cells that it must have. So, I made a nested for loop to go through all the size at x and y. The `currentCell` variable is used to keep track of which position I'm at so it is initialized to equal to the starting position. 

From this [website](https://www.geeksforgeeks.org/c-sharp-stack-with-examples/), I learned that `Stack` is a special type of collection that stores elements in LIFO style (Last In First Out). So, the last thing gets added, the first thing gets removed. I can use this to keep track of the paths I'm currently at. 

Now that I have the code to generate a new room, I need to make sure that the rooms around the room that the player is currently at is not a room that they've already visited. Therefore, I need to check all the neighbor of the room that the player is currently at.
```CSharp
 List<int> CheckNeighbors(int cell)
    {
        List<int> neighbors = new List<int>();

        //check up neighbor
        if (cell - size.x >= 0 && !board[(cell-size.x)].visited)
        {
            neighbors.Add((cell - size.x));
        }
        //check down neighbor
        if (cell + size.x < board.Count && !board[(cell + size.x)].visited)
        {
            neighbors.Add((cell + size.x));
        }
        //check right neighbor
        if ((cell+1) % size.x != 0 && !board[(cell +1)].visited)
        {
            neighbors.Add((cell +1));
        }
        //check left neighbor
        if (cell % size.x != 0 && !board[(cell - 1)].visited)
        {
            neighbors.Add((cell -1));
        }
        return neighbors;
    }
}
```
The `CheckNeighbors` method is going to return a list of neighbor for the cell that the player is currently in. But before that, I have to check if the neighbor of the cell had already been visited before. Only the ones that had not been visited should be put as neighbor of the current cell. In order to check the neighbor of the cell from all directions, I have a if statement to check whether they have been visited before in each direction. The first part of the if statement for each of them is to check if there is a cell that existed in that direction and then the second part will check whether it has been visited before. If it had not been visited them it's position will be added into the list of neighbor cells.

As for skills, I think I've learned `Time Management` and `Growth mindset`. When I was doing this part of the project, I am very clear on what my goal is for each week so by managing my time in a good way allow me to finish what I need for each week. I've also reached out for help from those around me that have experience in using unity. I've recieved many feedbacks which I can use to improve my project.


Text

[Previous](entry03.md) | [Next](entry05.md)

[Home](../README.md)
