using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretsBehaviour : MonoBehaviour
{
    public Transform TargetToAim;

    public Transform bulletModel;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 20f;


    [Header("Gun Props")]

    public float GunRange = 5f;
    public string enemyTag = "Enemy";
    public Transform RotatePart;
    public float RotateSpeed = 5f;

    public float fireRate = 2f;
    public float fireCountdown = 0f;

    private void Start()
    {
        InvokeRepeating("TargetUpdate", 0f, 0.25f);
    }

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, GunRange); 
    }

    void TargetUpdate()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float minDis = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < minDis)
            {
                minDis = distanceToEnemy;
                nearestEnemy = enemy;
            }
            if (nearestEnemy != null && minDis <= GunRange)
                TargetToAim = nearestEnemy.transform;
            else TargetToAim = null;
        }
    }

    void Shoot()
    {
        GameObject bullet = (GameObject)Instantiate(bulletModel.gameObject, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        BulletBehaviour bulletTemp = bullet.GetComponent<BulletBehaviour>();
        if (bulletTemp != null)
        {
            bulletTemp.attachTarget(TargetToAim);
        }
        Debug.Log("Firing...");
    }

    void Update()
    {
        if (TargetToAim == null)
            return;
        Vector3 dir = TargetToAim.position - RotatePart.position;
        Quaternion lookDir = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(RotatePart.rotation, lookDir, Time.deltaTime*RotateSpeed).eulerAngles;
        RotatePart.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }
        fireCountdown -= Time.deltaTime;

    }
}
