using System.Collections;
using UnityEngine;

public class CameraEffect : MonoBehaviour
{
    public static CameraEffect Instance {get; private set; }
    private Vector3 _originalPosition;

    private void Awake()
    {
        if(Instance == null) Instance = this;
        else Destroy(this);

        _originalPosition = transform.localPosition;
    }

    public void Shake(float duration, float magnitude)
    {
        StartCoroutine(ShakeCoroutine(duration, magnitude));
    }

    private IEnumerator ShakeCoroutine(float duration, float magnitude)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = _originalPosition + new Vector3(x, y, 0);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = _originalPosition;
    }
}
