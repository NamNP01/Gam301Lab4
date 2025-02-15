using UnityEngine;
using UnityEngine.VFX;

public class Projectile : MonoBehaviour
{
    public float speed = 5f;
    public int damage = 1;
    private GameObject target;

    public VisualEffect explosionEffect; // Thay đổi từ GameObject sang VisualEffect

    public void SetTarget(GameObject targetEnemy)
    {
        target = targetEnemy;
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 direction = target.transform.position - transform.position;
            direction.z = 0;
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);

            if (Vector3.Distance(transform.position, target.transform.position) <= 0.1f)
            {
                if (target.TryGetComponent(out EnemyHealth enemyHealth))
                {
                    enemyHealth.TakeDamage(damage);
                }

                // Kích hoạt hiệu ứng VFX thay vì Instantiate Prefab
                if (explosionEffect != null)
                {
                    VisualEffect vfxInstance = Instantiate(explosionEffect, transform.position, Quaternion.identity);
                    vfxInstance.Play();
                    Destroy(vfxInstance.gameObject, 2f); // Hủy sau 2 giây để tránh rác bộ nhớ
                }

                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
