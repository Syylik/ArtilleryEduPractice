using UnityEngine;

namespace Artillery.Scripts.ShootSystem
{
    public class Projectile : MonoBehaviour
    {
        private Vector2 _velocity;

        public void Launch(Vector2 startPos, float force, float angle)
        {
            transform.position = startPos;
            
            float rad = angle * Mathf.Deg2Rad;

            float vx = force * Mathf.Cos(rad);
            float vy = force * Mathf.Sin(rad);
            _velocity = new Vector2(vx, vy);
            
            GetComponent<Rigidbody2D>().velocity = _velocity;
        }
    }
}