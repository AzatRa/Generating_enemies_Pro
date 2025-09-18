using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private ColorChanger _colorChanger;
    [SerializeField] private Enemy _prefab;
    [SerializeField] private int _poolCapasity = 50;
    [SerializeField] private int _poolMaxSize = 100;

    private ObjectPool<Enemy> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Enemy>(
            createFunc: () => Instantiate(_prefab),
            actionOnGet: (obj) => obj.gameObject.SetActive(true),
            actionOnRelease: (obj) => obj.gameObject.SetActive(false),
            actionOnDestroy: (obj) => Destroy(obj.gameObject),
            collectionCheck: true,
            defaultCapacity: _poolCapasity,
            maxSize: _poolMaxSize);
    }

    public void Spawn(Transform transform)
    {
        float rotationAngle = 360f;

        Enemy enemy = _pool.Get();
        enemy.transform.position = transform.position;
        enemy.transform.rotation = Quaternion.Euler(0, Random.Range(0, rotationAngle), 0);
        _colorChanger.Change(enemy);
        enemy.gameObject.SetActive(true);
        enemy.CollidedWithWall += OnEnemyCollision;
    }

    private void OnEnemyCollision(Enemy enemy)
    {
        enemy.CollidedWithWall -= OnEnemyCollision;
        _pool.Release(enemy);
    }

    private Enemy Get()
    {
        return _pool.Get();
    }

    private void Release(Enemy obj)
    {
        _pool.Release(obj);
    }
}
