using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public float health = 200f;
    public float damage = 15f;
    
    public Slider healthBar;

    public Player PlayerRef;

    public bool isDead = false;
    public GameObject HealthFill;
    
    public GameObject YouWin;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthBar.maxValue = health;
        healthBar.value = health;
        InvokeRepeating("DealDamage", 2f, 2f);
        InvokeRepeating("PassiveHeal", 4f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            CancelInvoke("PassiveHeal");
            CancelInvoke("DealDamage");
        }
    }

    public void takeDamage(float damage)
    {
        health -= damage;
        healthBar.value = health;

        if (health <= 0)
        {
            isDead = true;
            HealthFill.SetActive(false);
            YouWin.SetActive(true);
        }
    }

    public void DealDamage()
    {
        PlayerRef.TakeDamage(damage);
    }

    public void PassiveHeal()
    {
        health += 20f;
        healthBar.value = health;
    }
}
