using UnityEngine;

public class Enemy:MonoBehaviour
{

    public string name = "Warrior";
    public int health = 1;

    public void takeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
            Destroy(gameObject);

    }
    
}
