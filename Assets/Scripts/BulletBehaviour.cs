using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [Header("Bullets Props")]

    public float bulletSpeed = 20f;
    public float missileRadius = 0f;
    public int turretDamageAmount = 5;

    [Header("Missile Props")]
    public int missileDamageAmount = 3;

    private Transform Target;
    public GameObject particle;
    //private bool isTargetHit = false;

    public void attachTarget(Transform _target)
    {
        Target = _target;
    }

    //Draw Missile range
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, missileRadius);
    }

    void damageEnemy(Transform enemy)
    {
        PawnBehaviour tempEnemy = enemy.GetComponent<PawnBehaviour>();
        if (tempEnemy != null)
        {
            if (missileRadius > 0f)
            {
                tempEnemy.takeDamage(missileDamageAmount);
            }
            else 
                tempEnemy.takeDamage(turretDamageAmount);
        }
        //Destroy(enemy.gameObject);
    }

    void Explode()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, missileRadius);
        foreach (Collider enemy in enemies)
        {
            if (enemy.tag == "Enemy")
            {
                damageEnemy(enemy.transform);
            }
        }
    }

    void targetHit()
    {
        //Debug.Log("Target Hit");
        if (missileRadius > 0f)
        {
            Explode();
        }
        else
        {
            damageEnemy(Target);
        }
        Instantiate(particle, transform.position, particle.transform.rotation);
        Destroy(gameObject);
    }


    void Update()
    {
        if(Target==null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = Target.position - transform.position;
        if (dir.magnitude <= bulletSpeed * Time.deltaTime)
        {
            targetHit();
            return;
        }
        transform.Translate(dir.normalized * bulletSpeed * Time.deltaTime, Space.World);
        transform.LookAt(Target);
    }
}
