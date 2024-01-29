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


  
<!-- 
* Links you used today (websites, videos, etc)
* Things you tried, progress you made, etc
* Challenges, a-ha moments, etc
* Questions you still have
* What you're going to try next
-->
