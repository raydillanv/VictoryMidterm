using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float health = 100f;
    public float damage = 10f;

    public Slider healthBar;
    public GameObject HealthFill;

    public Enemy EnemyRef;
    
    public bool isDead = false;
    
    public GameObject YouLose;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthBar.maxValue = health;
        healthBar.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            if (Keyboard.current.spaceKey.wasPressedThisFrame || Mouse.current.leftButton.wasPressedThisFrame)
            {
                EnemyRef.takeDamage(damage);
            }
        }


        
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.value = health;

        if (health <= 0)
        {
            isDead = true;
            HealthFill.SetActive(false);
            YouLose.SetActive(true);
        }
    }
    
    
}
