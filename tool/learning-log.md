# Tool Learning Log

Tool: **Unity**

Project: **Freedom Project**

---

10/23/23: Brainstorming
* Looked up example games that were created using unity.
* I used the example games I saw as a inspiration on what I want my project to be like.





10/27/23: Setting up
* Today I started to look for tutorials on Unity. I first used this [website](https://learn.unity.com/tutorial/install-the-unity-hub-and-editor#) to install unity into the computer and set up my unity account
* Installed UnityHub: a place for managing Unity projects, installing Editor versions, licensing, and installing add-on components.
* Followed the tutorial on this [website](https://learn.unity.com/tutorial/get-ready-for-unity-essentials?pathwayId=5f7bcab4edbc2a0023e9c38f&missionId=5f77cc6bedbc2a4a1dbddc46&projectId=612f9602edbc2a1b588a3af3#612f5ac2edbc2a1b5806927e) to learn about Unity and add my first project.



10/29/23: Tinkering
* When I first opened up the editor screen, I was confused due to all of the buttons on the screen.
* This [website](https://learn.unity.com/tutorial/get-started-in-the-unity-editor?labelRequired=true&pathwayId=5f7bcab4edbc2a0023e9c38f&missionId=5f77cc6bedbc2a4a1dbddc46&projectId=612f5bfdedbc2a1b4376ce65#6375344eedbc2a3b09474963) teached me how to add 3D shapes like cubes and spheres.
* I tried to change the size of the shape, moving it around and rotating it with my mouse.
* I was really confused on how to add code to the shapes that I created so I went back to the website and found a beginner script tutorial [video](https://www.youtube.com/watch?time_continue=5&v=Z0Z7xc18CcA&embeds_referring_euri=https%3A%2F%2Flearn.unity.com%2F&embeds_referring_origin=https%3A%2F%2Flearn.unity.com&source_ve_path=MzY4NDIsMjM4NTE&feature=emb_title) and in the video I saw him adding a script file to a cube so I followed what he did and I sucessfully added a empty file where I can write my script for my scene.
* You will use the Package Manager window to install, remove, and update packages that add functionality to the Unity Editor. 
* A useful feature of the Package Manager is the My Assets section, which catalogs assets you have imported from other sources.
* You have to import the documentation into your package manager in order to use that specific function.

11/13/23
* Today I tried to make the sphere that I created interactive. I want to make it move whenever the user press left or right by adding C Sharp scripts as a component of the sphere.
* I used videos from this [channel](https://www.youtube.com/@IndividualKex) to help me
* I followed the tutorials, however my code did not work as intended. The code was supposed to get the sphere's axis and when the user press left the axis will show -1 but it doesn't show anything.

11/27/23
* I tried to fix the error of the code and noticed that I had the wrong class name.
* It got rid of some of the error but there are still some that remain.

12/3/23
* I got rid of the errors by comparing my code to the [video](https://www.youtube.com/watch?v=4DPWvv7dh5E)
```csharp
  public class Player : MonoBehaviour
  {
	 int moveDir;
  
    void Update() 
	{
	   moveDir = (int)Input.GetAxisRaw( "Horizontal");
	   Debug.Log (moveDir);
	}
```
* This code will make the cordinate increase by 1 when you press the right arrow, and decrease by 1 when you press the left arrow.
* The sphere is still unable to move like this.

12/10/23
* In order for the sphere to move I need to update's position every time the coordinate change
* By following the same tutorial, I learned that I need to get the `rigidBody` component and to do so we do:
```csharp
void Awake() {
   ridgidBody = GetComponent<Rigidbody>();
} 
```
After doing that, I learned about the difference between `Update()` method and `FixedUpdate()` method. The difference is that `Update` can only run once per frame and `FixedUpdate` can run however time you want. It could be once, zero, or several times per frame. [website](https://stackoverflow.com/questions/34447682/what-is-the-difference-between-update-fixedupdate-in-unity) 

* I added a `FixedUpdate` method into my code:
```csharp
  void FixedUpdate(){
		rigidBody.velocity = new Vector3 (moveDir, rigidBody.velocity.y, 0);
	}
```
This sets the `ridgidBody`'s velocity into the input direction and the ball can finally move.

* I tried to change the sphere's moving speed by multiplying the velocity by a number: `rigidBody.velocity = new Vector3 (moveDir*10, rigidBody.velocity.y, 0);`
and the ball did move faster than before.`

1/8/24
- Today I tried to make my object jump.
- I used this [video](https://www.youtube.com/watch?v=CieCJ2mNTXE&t=929s) to help me
- In order to make my object jump, I first need to make my floor 3D so I changed it into a cube.
- Second thing I did was to add an if statement:
 ```java
  if(input.GetButtonDown("Jump"){
  	jump();
  }
```
- I added this into the `Update` function
- Then I created a `jump` function that sets the upward velocity of the object into a variable that I created, `jumpSpeed`

```java
void jump(){
	ridgitBody.velocity = new Vector3(ridgitBody.velocity.x, jumpSpeed, 0);
{
```
The object is able to jump with this code but, it allows the user to jump forever if they press the jump button over non-stop.

1/15/24

* In order to stop the ball from jumping infinitely, I need to make a ground check so that the it will know that it's touching the ground.
* need to create a boolean

  1/21/24

  * I used this [website](https://learn.unity.com/tutorial/modifying-gravity-color-size-lifetime-of-particle-systems#5f08702cedbc2a00229c9ac8) to learn how to add particles to my objects
  * I want to make paricles show up whenever the object moves or jumps so I watched a video on it. [video](https://www.youtube.com/watch?time_continue=2&v=ZPbInUXqVzg&embeds_referring_euri=https%3A%2F%2Fwww.bing.com%2F&embeds_referring_origin=https%3A%2F%2Fwww.bing.com&source_ve_path=Mjg2NjY&feature=emb_logo)
    I need to create 2 events
    `public UnityEvents onBeginMovingLeft` and `public UnityEvents onBeginMovingRight`
    After that I need an if statement to check if the object is moving left or right
    ```csharp
    set{
     if (_moveX != value){
           if(value > 0 && _moveX <= 0)
    		onBeginMovingLeft?.Invoke();
           else if(value < 0 && _moveX >= 0)
    		onBeginMovingRight?.Invoke();
    	   _moveX=value;
   	 }
    ```
Then all I need to do is just add the particles into the events in the drop down menu and it there will be particles when the object moves.

1/29/24

* Today I want to try to make something in 2D
* I used this [video](https://www.youtube.com/watch?v=1QfxdUpVh5I&t=29s) to help me
* The first thing I tried was to make the player attack by doing:
  ```CSharp
  void Update{
  
 	 if(timeBtwAttack <= 0){
  		if(Input.GetKey(KeyCode.Space)){
  			Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll()
 		 }
  	}
  }
  ```
  This code will check if the time between an attack is less or equal to 0 and if it is true then you can attack by pressing space. The OverlapCircleAll(); is a function that creates an invisible cirlce and any enemy inside it will be dealt damage.

2/4/24

Today I learned something called `Gizmos`, they are used to give visual debugging or setup aids in the Scene view. I found it on this [website](https://docs.unity3d.com/ScriptReference/Gizmos.html)

* There are many properties that you can use with it like `color`, and `exposure`.
* There are also methods that you can use like `DrawWireSphere` and more
* I want to use the `Gizmos` to help visualize the range and shape of the player's attack
```CSharp
void OnDrawGizmosSelected(){
  Gizmos.color = Color.red;
  Gizmos.DrawWireSphere(attackPos.position, attackRange)
}
```
`OnDrawGizmosSelected` will draw the `Gizmos` when the player is selected and then the Gizmos will appear red in the form of a sphere which takes in the position of the attack(attackPos) and the radius(attackRange).

2/26/24

Today I began learning how to build my own map
* I used this [video](https://www.youtube.com/watch?v=gHU5RQWbmWE) to help me
* By following the tutorial, I wrote down the first part of the code that allows me to generate my dungeon which I need for my map
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
My goal is to have many rooms and whenever the player go through a door a new room gets generated. This code checks if the room is already visited and sets the start value of each room like it's size and start position.


3/2/24
Today, I continue on the process of making my dungeon map using this [tutorial](https://www.youtube.com/watch?v=gHU5RQWbmWE). I am going to work on making the map loop so that it form some kind of maze.

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
After I initalize the board as a list of cells, I must create this board with all the cells that it must have. So, I made a nested for loop to go through all the size at x and y. The `currentCell` variable is used to keep track of which position I'm at so it is initialized to equal to the starting position. 

`Stack` is a special type of collection that stores elements in LIFO style (Last In First Out). So, the last thing gets added, the first thing gets removed. I can use this to keep track of the paths I'm currently at. 


3/10/24

Today I continue my code for the maze generater [(video)](https://www.youtube.com/watch?v=gHU5RQWbmWE&t=951s).
* Last time I created the grid for all the cells and a variable to keep track of the current user position.
* Now I need to check the cells around the current cell to see if it has been visited
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
The `CheckNeighbors` method is going to return a list of neighbor for the cell that the player is currently in. But first we have to check if the cells had already been visited before. Only the ones that had not been visited should be put as neighbor of the current cell.

For all of the direction, I have a if statement to check if they have been visited before. The first part of the if statement for each of them is to check if there is a cell that existed in that direction and then the second part will check whether it has been visited before. If it had not been visited them it's position will be added into the list of neighbor cells.

3/23/24
* Today I will be finishing the maze generator [tutorial](https://www.youtube.com/watch?v=gHU5RQWbmWE&t=1284s)
* Last time I checked for if there is neighbor rooms around the current room
* Now I want to check for if there is no neighbor rooms
```CSharp
    if (neighbors.Count == 0)
            {
                if (path.Count == 0)
                {
                    break;
                }
                else
                {
                    currentCell = path.Pop();
                }
            }
            else
            {
                path.Push(currentCell);

                int newCell = neighbors[Random.Range(0, neighbors.Count)];

                if (newCell > currentCell)
                {
                    
```
This code checks if there are no neighbors then the loop for checking whether the room has been visited will stop and if path does not equal to 0 then the current room would be equal to the last cell that is added to the path. However if the neighbor count does not equal to 0 then the current room will be added to the path and then the next room will be chosen randomly from those neighbor rooms that are stored in path. 

* The next step is to check which direction would the next room be at (left, right, up or down)

3/31/24

* Today I worked on the camera movement of the player so that the player can rotate their camera in the game
<img width="468" alt="image" src="https://github.com/jianghuiz7368/apcsa-freedom-project/assets/91745147/fa6a6959-e1a1-47a6-9f75-d41b800fec6e">

* This code allow the user to move their camera based on the position of their mouse and the sensativity. It also prevents the player from looking above 90 degrees or below -90 degree because if there are no limits then their head would be able to turn in 360 degrees. 
* There is one mistake in this because when I press play, the player just disappears and I can't find it anymore.

4/7/24
Today I tried character movements
* In order to move the player, I need a `transform` for my oreientation and a variable for my speed.
* Then I need a place to store my input(horizontally and vertically)
* <img width="380" alt="image" src="https://github.com/jianghuiz7368/apcsa-freedom-project/assets/91745147/ca382da0-aa34-4b20-8e5b-f6b51fd984bb">

The `myInput` method collects the keyboard input and then I called it in the `update` method so the direction would update every time a new input is stored. The `movePlayer` method makes the player walk in the direction that their looking at. Then it sets the speed by using `AddForce`.

  
            
<!-- 
* Links you used today (websites, videos, etc)
* Things you tried, progress you made, etc
* Challenges, a-ha moments, etc
* Questions you still have
* What you're going to try next
-->
