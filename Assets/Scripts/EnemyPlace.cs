using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlace : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _path;

    private Transform[] _points;

    void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _points.Length; i++)
        {
            _points[i] = _path.GetChild(i).transform;
        }

        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        int spawnCount = _points.Length;
        var waitForTwoSeconds = new WaitForSeconds(2);

        for (int i = 0; i < spawnCount; i++)
        {
            GameObject gameObject = Instantiate(_enemy, _points[i].position, Quaternion.identity);
            yield return waitForTwoSeconds;
        }

        Debug.Log("Готово");
    }
}
