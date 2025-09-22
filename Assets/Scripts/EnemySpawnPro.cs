using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPro : MonoBehaviour
{
    [SerializeField] private List<Spawner> _spawners;
    [SerializeField] private float _spawnInterval = 2f;

    private void Start()
    {
        StartCoroutine(WaitForSpawn());
    }

    private IEnumerator WaitForSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnInterval);
            SelectSpawner().Spawn();
        }
    }

    private Spawner SelectSpawner()
    {
        return _spawners[Random.Range(0, _spawners.Count)];
    }
}
