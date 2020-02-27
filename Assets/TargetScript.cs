using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public float health = 50;

    public void TakeDamage(float amount)
    {
        //Check if dead
        health -= amount;
        if(health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        //Destroy obeject and spawn particles and play sound
        Destroy(gameObject);
    }
}
