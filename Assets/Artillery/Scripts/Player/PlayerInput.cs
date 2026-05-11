using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

namespace Artillery.Scripts.Player
{
    public class PlayerInput : MonoBehaviour
    {
        public Action<float, float> OnValueUpdated;

        public float force { get; private set; } = 10;
        public float angle { get; private set; } = 45;

        [SerializeField] private float initForce = 10, initAngle = 45;

        [SerializeField] private Slider forceSlider;
        [SerializeField] private Slider angleSlider;

        [SerializeField] private TMP_Text forceValueText;
        [SerializeField] private TMP_Text angleValueText;

        private void Start()
        {
            forceSlider.value = initForce;
            angleSlider.value = initAngle;
            UpdateUI();
            OnValueUpdated(force, angle); // Init
        }

        public void UpdateForce(float force)
        {
            this.force = force;
            OnValueUpdated?.Invoke(this.force, this.angle);
            UpdateUI();
        }

        public void UpdateAngle(float angle)
        {
            this.angle = angle;
            OnValueUpdated?.Invoke(this.force, this.angle);
            UpdateUI();
        }

        private void UpdateUI()
        {
            forceValueText.text = (force / forceSlider.maxValue).ToString("P0");
            angleValueText.text = angle.ToString() + '°';
        }
    }
}