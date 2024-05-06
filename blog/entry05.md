# Entry 5
##### 5/1/24

I am currently on **step 5 and 6 of the Engineering Design Process**. I am creating the Minimum Viable Product(MVP) of my freedom project and testing if it works. For the most part, I've been working on the melee system of my game where the player will be able to attack the enemy using a weapon and the enemy will have AI that make them chase the player when the player is in range. In order for the melee system to work, the player first need to be able to wield the weapon so I followed this [tutorial](https://www.youtube.com/watch?v=aNZw588BQBo&t=69s) and wrote a code that allow the player to attack with the weapon:

```CSharp
public void SwordAttack()
    {
        IsAttacking = true;
        CanAttack = false;
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger("Attack");
        AudioSource ac = GetComponent<AudioSource>();
        ac.PlayOneShot(SwordAttackSound);
        StartCoroutine(ResetAttackCooldown());

    }
```
This is mainly to set up all the component when the player is attacking. When the player is currently attacking the code stops the player from attacking again before the animation is done. It contains the sound effect that will play each time when the sword swings and also triggers the animaton "attack" which tells the game to perform the animation. This function is called in the `update()` so it will be called over and over again
```CSharp
void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(CanAttack) 
            {
                SwordAttack();
            }
        }
    }
```
Inside `Update()`, it checks if the user clicks the left button on their mouse and if they did then it will check for it the `CanAttack` variable is true. If both are true, then it will call the `SwordAttack()` function. At last, there will be two functions to reset the attacks:
```CSharp
IEnumerator ResetAttackCooldown()
    {
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true;
    }

    IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(1.0f);
        IsAttacking = false;
    }
```
Coroutines are a feature in Unity (and other game engines) that allow you to pause the execution of a method and then continue from where it left off after a specific amount of time [(source)](https://docs.unity3d.com/Manual/Coroutines.html). The coroutines ensure that after a player initiates an attack, there is a cooldown period during which the player cannot attack again, and after the cooldown, the player can attack again.

As for skills, I've learned `Time Management` and `Growth Mindset`. During the process of making the MVP, I had a lot of things that I wanted to add to my game however, I know that I won't be able to do that before the deadline. Therefore, I made all the functions that are essential to my game and paused on the development of the functions that are more time consuming. I also reached out to many people that have experience with `Unity` and asked a lot of question. Using their answers and feedback I was able to understand my mistakes and include parts that I'm missing.

[Previous](entry04.md) | [Next](entry06.md)

[Home](../README.md)
