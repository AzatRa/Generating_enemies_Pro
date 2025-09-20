using System;
using System.Drawing;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    private Renderer _renderer;
    private Transform _target;

    public event Action<Enemy> CollidedWithTarget;
    public Renderer Renderer => _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        Vector3 direction = (_target.position - transform.position).normalized;
        transform.Translate(direction * _speed * Time.deltaTime, Space.World);
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Target>(out _))
        {
            CollidedWithTarget?.Invoke(this);
        }
    }
}
