using System;
using UnityEngine;

namespace Artillery.Scripts.ShootSystem
{
    public class Trajectory : MonoBehaviour
    {
        [SerializeField] private int pointCount = 100;
        [SerializeField] private Transform startPoint;
        
        private LineRenderer line;
        private Vector3[] points = new Vector3[100];
        
        private void Awake() => line = GetComponent<LineRenderer>();

        public void UpdateTrajectory(float force, float angle)
        {
            line.positionCount = pointCount;
            float angleRad = angle * Mathf.Deg2Rad; 
            Vector2 velocity = new Vector2(force * Mathf.Cos(angleRad), force * Mathf.Sin(angleRad));
            for (int i = 0; i < pointCount; i++)
            {
                float time = i * 0.1f;
                
                points[i] = (Vector2)startPoint.position + velocity * time + Physics2D.gravity * time * time / 2;
            }
            line.SetPositions(points);
        }
    }
}
