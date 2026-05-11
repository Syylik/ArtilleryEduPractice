using System;
using UnityEngine;

namespace Artillery.Scripts
{
    public class Projectile : MonoBehaviour
    {
        private Vector2 _velocity;
        private float _gravity;
        private bool _isMoving;

        public void Launch(Vector2 startPos, float angle, float force, float gravity)
        {
            transform.position = startPos;
            
            float rad = angle * Mathf.Deg2Rad;

            float vx = force * Mathf.Cos(rad);
            float vy = force * Mathf.Sin(rad);
            _velocity = new Vector2(vx, vy);
            _gravity = gravity;
            _isMoving = true;
        }

        private void Update()
        {
            if(!_isMoving) return;

            _velocity.y -= _gravity * Time.deltaTime;
            transform.position += (Vector3)(_velocity * Time.deltaTime);
        }
    }
}