using UnityEngine;

public class Bullet : MonoBehaviour
{

    private GameObject target;
    private int towerDamage;

    public float speed = 70f;

    public void getInfo(GameObject enemy, int damage)
    {
        target = enemy;
        towerDamage = damage;
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = target.transform.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    void HitTarget()
    {
        Enemy enemy = target.GetComponent<Enemy>();
        enemy.takeDamage(towerDamage);

        Destroy(gameObject);
    }
}
