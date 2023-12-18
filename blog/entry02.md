# Entry 2
##### 12/11/23

I am currently on step 2 of the **Engineering Design Process: Researching the tool**. Since my last blog, I've been researching on how to fix the error that occured when I'm trying to make my game object move around when the player presses the left or right arrow key on their keyboard. There was a lot of errors at first but soon I noticed that I've written the wrong class name. When I changed the class name to what it should be, the amount of error lessened. After doing that, I watched a [tutorial](https://www.youtube.com/watch?v=4DPWvv7dh5E) that includes making an object move. I compared my code with the one in the video and I decided to remove some of my code to see if it'll work. I made the code that remains exactly the same as the video:
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
This code is not supposed to make the object move. It's purpose is to get the axis of the object and it works exact way that I want it to me. This code will make the cordinate increase by 1 when you press the right arrow, and decrease by 1 when you press the left arrow.

In order for the sphere to move I need to update's position every time the coordinate change and by following the same tutorial, I learned that I need to get the rigidBody component and to do so I did:
```csharp
void Awake() {
   ridgidBody = GetComponent<Rigidbody>();
} 
```
After writing the code that gets the position of the object, I know I would need a code to update the position of the object. Therefore, did some research and I learned about the difference between Update() method and FixedUpdate() method. The difference is that Update can only run once per frame and FixedUpdate can run however time you want. It could be once, zero, or several times per frame which I learned from this [website](https://stackoverflow.com/questions/34447682/what-is-the-difference-between-update-fixedupdate-in-unity) I want to update the position multiple times so I added a FixedUpdate() method:
```csharp
void FixedUpdate(){
		rigidBody.velocity = new Vector3 (moveDir, rigidBody.velocity.y, 0);
	}
```
This sets the ridgidBody's velocity into the input direction and the object can finally move. So when the user press left the object will go left and the same goes for the right. Furthermore, I want to test out if the object can go faster so I multiplied the velocity by 10: `rigidBody.velocity = new Vector3 (moveDir*10, rigidBody.velocity.y, 0);` and the object did move faster than before.

Since the winter break is coming soon, I want to use this time to create character and map models for my combat game. I also want to learn how to give character hit points and make be able to fight base on the player' control.

For skills, I learned **Problem Decomposition** and **Attention to Detail**. During my debugging process, I had to get rid of some of my code and break it into small parts. By doing this I was able to identify what my code is missing and understand what each part is supposed to do. Paying attention to small details like the name of each class was a big help for me to fix this error.





[Previous](entry01.md) | [Next](entry03.md)

[Home](../README.md)
