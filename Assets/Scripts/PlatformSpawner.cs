using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _platforms;
    [SerializeField]
    private GameBorders _gameBorders;
    [SerializeField]
    private int _count = 10;
    [SerializeField]
    private float _distanceBetweenPlatforms = 3.4f;
    private float _height;

    private Queue<GameObject> _spawnedPlatforms = new Queue<GameObject>();
    private Vector3 _originPosition;
    public void Restart()
    {
        while(_spawnedPlatforms.Count!=0)
        {
            Destroy(_spawnedPlatforms.Dequeue().gameObject);
        }
         _height = _originPosition.y;
        for (int i = 0; i < _count; i++)
        {
            Spawn();
        }
    }
    void Start()
    {
        _originPosition = transform.position;
        Restart();
    }

    // Update is called once per frame
    void Update()
    {
        if (_spawnedPlatforms.Peek().IsDestroyed())
        {
            _spawnedPlatforms.Dequeue();
            Spawn();
        }
        else if (_gameBorders.IntersectsLowerBorder(_spawnedPlatforms.Peek().transform))
        {
            DestroyImmediate(_spawnedPlatforms.Peek().gameObject);
            _spawnedPlatforms.Dequeue();
            Spawn();
        }
    }

    private void Spawn()
    {
        float randomX = Random.Range(_gameBorders.LeftBorderPosition.x, _gameBorders.RightBorderPosition.x);
        GameObject o = _platforms[Random.Range(0, _platforms.Length)];
        
        _spawnedPlatforms.Enqueue(Instantiate(o, new Vector3(randomX, _height), Quaternion.identity, transform));
        _height += _distanceBetweenPlatforms;
    }
}
