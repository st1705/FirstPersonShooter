using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public float health = 50;
    public GameObject explotion;

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
        Destroy(Instantiate(explotion, transform.position, transform.rotation), 5f);
    }
}
