using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnBehaviour : MonoBehaviour
{
    private Transform destination;
    public float speed = 5f;
    private int it = 0;
    //public int defaultHealth = 2;
    public int health = 10;

    void Start()
    {
        destination = Checkpoints.points[it];
    }

    void nextCheck()
    {
        it++;
        destination = Checkpoints.points[it];
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            DestroyEnemy();
        }
    }
    
    void DestroyEnemy()
    {
        Destroy(gameObject);
        Stats.cash += 50;
    }

    void Update()
    {
        Vector3 dir = destination.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, destination.position) <= 0.1f)
        {
            //nextCheck();
            it++;
            if (it == 19)
            {
                Destroy(gameObject);
                Stats.lives--;
                it = 0;
            }
            destination = Checkpoints.points[it];

            //Debug.Log(Checkpoints.points.Length);
        }
    }
}
