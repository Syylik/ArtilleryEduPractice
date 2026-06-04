using Artillery.Scripts.Player;
using UnityEngine;

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

        [SerializeField] private float effectMagnitude = 0.42f;
        
        [SerializeField] private float bulletCount;
        [SerializeField] private float muzzleRotOffset = 45f;
        [SerializeField] private Transform muzzleRotateOrigin;

        private void OnEnable() => input.OnValueUpdated += UpdateMuzzle;

        private void UpdateMuzzle(float force, float angle)
        {
            // muzzle.RotateAround();
            muzzle.localRotation = Quaternion.Euler(0, 0, angle - muzzleRotOffset);
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
            CameraEffect.Instance.Shake(0.1f, effectMagnitude);
        }

        private void OnDisable() => input.OnValueUpdated -= UpdateMuzzle;
    }
}