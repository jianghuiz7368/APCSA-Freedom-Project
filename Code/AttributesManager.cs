using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttributesManager : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;
    public int attack;
    public GameObject enemy;
    public float fadeOutDuration = 1.5f; // Adjust the duration as needed
    public Slider HealthBar;

    private void Start()
    {
        HealthBar.minValue = 0;
        HealthBar.maxValue = maxHealth;
    }

    private void Update()
    {
        HealthBar.value = health;
    }
    public void TakeDamage(int amount)
    {
        health -= amount;
        Animator anim = GetComponent<Animator>();
        if (health <= 0)
        {
            //play death animation
            anim.SetTrigger("die");
            StartCoroutine(FadeOutAndDestroy());
        }
        else
        {
            //play get hit animation
            anim.SetTrigger("Hit");
        }
    }

    private IEnumerator FadeOutAndDestroy()
    {
        Renderer renderer = enemy.GetComponent<Renderer>();
        Color originalColor = renderer.material.color;

        // Gradually reduce the alpha value to make the enemy disappear
        float timer = 0f;
        while (timer < fadeOutDuration)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, timer / fadeOutDuration);
            renderer.material.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        Destroy(enemy);
    }

    public void DealDamage(GameObject target)
    {
        //do damage
        var atm = target.GetComponent<AttributesManager>();
        if (atm != null)
        {
            atm.TakeDamage(attack);
        }

        //take damage

    }
}