using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private List<Transform> _waypoints = new List<Transform>();

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(SpawnObjectAtWaypointPosition());
        }
    }

    private IEnumerator SpawnObjectAtWaypointPosition()
    {
        foreach (Transform _waypoint in _waypoints)
        {
            GameObject objSpawned = Instantiate(_prefab, _waypoint.position, Quaternion.identity);
            yield return new WaitForSeconds(2);
            Destroy(objSpawned);
        }
    }
}
