using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
    private int currentWaypointIndex = 2;

    [SerializeField] private float _speed = 5f;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private List<Transform> _waypoints = new List<Transform>();

    private void OnMouseDown()
    {
        if (gameObject.name == "Point A")
        {
            StartCoroutine(SpawnObjectAtWaypointPosition());
        }

        if (gameObject.name == "Point B")
        {
            StartCoroutine(ObjMovementTowardsWaypoint());
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

    private IEnumerator ObjMovementTowardsWaypoint()
    {
        foreach (Transform _waypoint in _waypoints)
        {
            GameObject objSpawned = Instantiate(_prefab, _waypoint.position, Quaternion.identity);

            objSpawned.transform.position = Vector3.MoveTowards(objSpawned.transform.position, _waypoint.position, _speed * Time.deltaTime);
            yield return new WaitForSeconds(2);
        }
    }
}
