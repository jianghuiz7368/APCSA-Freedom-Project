# Entry 3
##### 2/5/24

I am currently in between **step 2 and 3 in the Engineering Design Process**. I am researching and brainstorming on what can I use to create my project. During the pass few weeks, I've been trying to make something in 2D instead of 3D to determine which one would I use for my actual game. I watched several videos and tutorials on how to make my sprite move and attack.I usd this [video](https://www.youtube.com/watch?v=w9NmPShzPpE&t=300s) to help me learn how to make my sprite mov in 2D. Ater watching the video, I learned that the steps are pretty similar to what I did in 3D. All you had to do is to add all the components like `rigidBody` and `colliders`, and then the `start`, and `update` method is basically the same as what I did in 3D which I wrote about in blog 2. The only difference I saw was in the `FixedUpdate` method.
```CSharp
private void FixedUpdate()
{
    if (moveHorizontal > 0.1f || moveHorizontal < -0.1f)
    {
        rb2D.AddForce(new Vector2(moveHorizontal * moveSpeed, 0f), ForceMode2D.Impulse);
    }
}
```
The `rb2D.AddForce` method is something new which I learned during the video. This method is used for applying force to a 2D rigidbody. `Vector2` is like a x and y axis so it determines how far you want it to move horizontally and vertically. So in the code I made the x axis into `moveHorizontal * moveSpeed` and the y axis into 0 because for this line of code I just want to get the sprite to move left and right but not jumping. After that, `ForceMode2D` allow me to choose what kind of force I want to use to apply to my sprite. I chosed `Impulse` force because it applies an instantaneous force. 

When I'm done with making my sprite move, I started to make my combat features. For this part, I used this [video](https://www.youtube.com/watch?v=1QfxdUpVh5I&t=29s) to help me. The first thing I tried was to make the player attack by doing:
  ```CSharp
  void Update{
  
 	 if(timeBtwAttack <= 0){
  		if(Input.GetKey(KeyCode.Space)){
  			Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll()
 		 }
  	}
  }
  ```
  This code will check if the time between an attack is less or equal to 0 and if it is true then you can attack by pressing space. The `OverlapCircleAll();` is a function that 
  creates an invisible cirlce and any enemy inside it will be dealt damage. I learned something called `Gizmos` which I found on this [website](https://docs.unity3d.com/ScriptReference/Gizmos.html), they are used to give visual debugging or setup aids in the Scene view. There are many properties that you can use with it like `color`, `exposure`, etc. There are also methods that you can use like `DrawWireSphere` which draws a wireframe sphere with center and radius.

I want to use the `Gizmos` to help visualize the range and shape of the player's attack
```CSharp
void OnDrawGizmosSelected(){
  Gizmos.color = Color.red;
  Gizmos.DrawWireSphere(attackPos.position, attackRange)
}
```
`OnDrawGizmosSelected` will draw the `Gizmos` when the player is selected and then the Gizmos will appear red in the form of a sphere which takes in the position of the attack(attackPos) and the radius(attackRange).

For skills, I think I've learned **Growth Mindset** and **How to Google** because I am always trying to improve so I asked many people who had experience with using **Unity** to give me feedback on my project. Those feedback didn't upset but instead I take them into consideration and try to make my project better. Furthermore, I had to do a lots of research since I still have a lot to learn about unity and it's my first time trying out Unity in 2D so I had to search for many useful tutorials and websites.

[Previous](entry02.md) | [Next](entry04.md)

[Home](../README.md)
