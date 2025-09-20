using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverByPoints : MonoBehaviour
{
    [SerializeField] private List<Transform> _points = new();
    [SerializeField] private float _speed;
    [SerializeField] private float _rotateSpeed;

    private Transform _nextPoint = null;
    private Queue<Transform> _pointsQueue = new();
    private float _minDistance = 0.1f;

    private void Start()
    {
        foreach (Transform point in _points)
        {
            _pointsQueue.Enqueue(point);
        }

        _nextPoint = _pointsQueue.Dequeue();
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * _rotateSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _nextPoint.position) < _minDistance)
        {
            _pointsQueue.Enqueue(_nextPoint);
            _nextPoint = _pointsQueue.Dequeue();
        }

        Move(_nextPoint);
    }

    private void Move(Transform point)
    {
        Vector3 direction = (point.position - transform.position).normalized;
        transform.Translate(direction * _speed * Time.deltaTime, Space.World);
    }
}
