using UnityEngine;

public class MoveInCircle : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _rotationCenter;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _rotateSpeed;

    private void Start()
    {
        _offset = transform.position - _rotationCenter;
    }

    private void Update()
    {
        transform.position = _rotationCenter + _offset;
        transform.RotateAround(_rotationCenter, Vector3.up, _speed * Time.deltaTime);
        transform.Rotate(Vector3.up * _rotateSpeed * Time.deltaTime);
        _offset = transform.position - _rotationCenter;
    }
}
