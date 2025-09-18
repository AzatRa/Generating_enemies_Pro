using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPro : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private float _spawnInterval = 2f;
    [SerializeField] private List<Transform> _positions = new();
    private float _timer;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _spawnInterval)
        {
            _spawner.Spawn(PositionSelection());
            _timer = 0f;
        }
    }

    private Transform PositionSelection()
    {
        return _positions[Random.Range(0, _positions.Count)];
    }
}
