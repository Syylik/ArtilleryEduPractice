using Artillery.Scripts.Player;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Artillery.Scripts.ShootSystem
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private Transform muzzle;
        [SerializeField] private Trajectory trajectory;

        [SerializeField] private PlayerInput input;
        
        [SerializeField] private Projectile projectilePrefab;
        [SerializeField] private Transform shootPoint;

        [SerializeField] private float shootRate = 0.5f;
        private float _timeToNextShoot;
        
        [SerializeField] private float bulletCount;

        private void OnEnable() => input.OnValueUpdated += UpdateMuzzle;

        private void UpdateMuzzle(float force, float angle)
        {
            muzzle.localRotation = Quaternion.Euler(new Vector3(0, 0, angle));
            trajectory.UpdateTrajectory(force, angle);
        }

        public void TryShootClick()
        {
            TryShoot(input.force, input.angle);
        }

        public bool TryShoot(float force, float angle)
        {
            if(bulletCount <= 0 || _timeToNextShoot > Time.time) return false;
            else
            {
                bulletCount--;
                _timeToNextShoot = Time.time + (1 / shootRate);
                Shoot(force, angle);
                return true;
            }
        }

        public void Shoot(float force, float angle)
        {
            Projectile projectile = Instantiate(projectilePrefab);
            projectile.Launch(shootPoint.position, force, angle);
        }

        private void OnDisable() => input.OnValueUpdated -= UpdateMuzzle;
    }
}