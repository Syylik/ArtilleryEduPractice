using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
struct ObstaclePoint
{
    public Vector3 position;
    public Vector3 rotation;
    public Vector3 scale;

    public void Record(Vector3 position, Vector3 rotation, Vector3 scale)
    {
        this.position = position;
        this.rotation = rotation;
        this.scale = scale;
    }

    public void Reset()
    {
        position = Vector3.zero;
        rotation = Vector3.zero;
        scale = Vector3.one;
    }
}

public class MovingObstacle : MonoBehaviour
{
    [SerializeField] private List<ObstaclePoint> _points;

    [SerializeField] private float timeBtwPoints = 0.5f;
    private float _time = 0f;

    private ObstaclePoint prevPoint;
    private ObstaclePoint point;

    private Transform _cachedTransform;

    private void Start()
    {
        _cachedTransform = transform;
        SetTransformData(_points[0]);
        StartCoroutine(MoveCycle());
    }

    private IEnumerator MoveCycle()
    {
        for (int i = 0; i < _points.Count;)
        {
            prevPoint = _points[Mathf.Max(i - 1, 0)];
            point = _points[i];
            while (_time < timeBtwPoints)
            {
                _time += Time.deltaTime;
                LerpMove(prevPoint, point, _time);
                yield return null;
            }
            // prevPoint = _points[i - 1];
            _time = 0;
            i++;
        
        }




        // prevPoint = _points[_points.Count - 1];
        // for(int i = _points.Count - 1; i > 0; i--)
        // {
        //     while(time < timeBtwPoints)
        //     {
        //         LerpMove(prevPoint, _points[i], time);
        //         time += Time.deltaTime;
        //     }
        //     prevPoint = _points[i];
        //     time = 0;
        // }
    }

    private void LerpMove(ObstaclePoint prevPoint, ObstaclePoint newPoint, float time)
    {
        _cachedTransform.position = Vector3.Lerp(prevPoint.position, newPoint.position, time / timeBtwPoints);
        _cachedTransform.rotation = Quaternion.Euler(Vector3.Lerp(prevPoint.rotation, newPoint.rotation, time / timeBtwPoints));
        _cachedTransform.localScale = Vector3.Lerp(prevPoint.scale, newPoint.scale, time / timeBtwPoints);
    }

    private void SetTransformData(ObstaclePoint point)
    {
        _cachedTransform.position = point.position;
        _cachedTransform.rotation = Quaternion.Euler(point.rotation);
        _cachedTransform.localScale = point.scale;
    }

    private void SetTransformData(Vector3 position, Vector3 rotation, Vector3 scale)
    {
        _cachedTransform.position = position;
        _cachedTransform.rotation = Quaternion.Euler(rotation);
        _cachedTransform.localScale = scale;
    }
}
