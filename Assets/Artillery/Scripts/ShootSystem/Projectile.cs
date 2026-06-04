using UnityEngine;

namespace Artillery.Scripts.ShootSystem
{
    public class Projectile : MonoBehaviour
    {
        private Vector2 _velocity;
        [SerializeField] private int damage = 1;
        [SerializeField] private GameObject destroyEffect;

        public void Launch(Vector2 startPos, float force, float angle)
        {
            transform.position = startPos;
            
            float rad = angle * Mathf.Deg2Rad;

            float vx = force * Mathf.Cos(rad);
            float vy = force * Mathf.Sin(rad);
            _velocity = new Vector2(vx, vy);
            
            GetComponent<Rigidbody2D>().velocity = _velocity;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.collider.TryGetComponent<Health>(out Health health))
            {
                health.TakeDamage(damage);
            }
            Destroy(Instantiate(destroyEffect, transform.position, Quaternion.identity), 1f);
            CameraEffect.Instance.Shake(0.15f, 0.15f);
            Destroy(gameObject);
        }
    }
}