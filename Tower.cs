using System.Collections;
using UnityEngine;

public class Tower : MonoBehaviour
{

    public int damage = 1;
    public int sell;
    public float attackSpeed = 1f;
    private float attackCountDown = 0f;

    //public Transform target;
    public GameObject target;
    public float range = 15f;

    public string enemyTag = "Enemy";

    public GameObject bulletPrefab;
    public Transform firePoint;

    void Start()
    {
        InvokeRepeating("ClosestTarget", 0f, 0.5f);
    }

    void ClosestTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < shortestDistance)
            {
                nearestEnemy = enemy;
                shortestDistance = distance;
            }
        }

        if(shortestDistance <= range && nearestEnemy != null)
        {
            target = nearestEnemy;
        }
        else
        {
            target = null;
        }
    }

    private void Update()
    {
        if (target == null)
            return;

        if(attackCountDown <= 0f)
        {
            shoot();
            attackCountDown = 1f / attackSpeed;
        }

        attackCountDown -= Time.deltaTime;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void shoot()
    {
        GameObject bulletGO = (GameObject) Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.getInfo(target, damage);
    }
}