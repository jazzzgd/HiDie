using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public float speed;
    private Rigidbody2D _rb;

    //Вызывается при создании пули, установки скорости, а после удаляет объект.
    void Start()
    {
        if (_rb == null) 
        {
            _rb = GetComponent<Rigidbody2D>();
        }
        
        _rb.velocity = transform.right * speed;
        Destroy(gameObject, 3f);
    }

    //Вызывается при столкновении пули с вражеским объектом, или бочкой, в конце метод дестрой удаляет пулю из сцены.
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.TryGetComponent(out EnemyHealth enemyHealth)) 
        {
            enemyHealth.TakeDamage(damage);
        } 
        else if (col.gameObject.TryGetComponent(out BoomBarrelHealth barrelHealth)) 
        {
            barrelHealth.GetDamage(damage);
        }

        Destroy(gameObject);
    }
}
