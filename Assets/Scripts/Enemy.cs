using System;
using System.Drawing;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Renderer))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    private Renderer _renderer;

    public Transform target;
    public event Action<Enemy> CollidedWithTarget;
    public Renderer Renderer => _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        transform.Translate(direction * _speed * Time.deltaTime, Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Target>(out _))
        {
            CollidedWithTarget?.Invoke(this);
        }
    }
}
