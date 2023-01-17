using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
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
            objSpawned.SetActive(false);
        }
    }

    private IEnumerator ObjMovementTowardsWaypoint()
    {
        if (gameObject.name == "Point B")
        {
            GameObject objSpawned = Instantiate(_prefab, gameObject.transform.position, Quaternion.identity);
            objSpawned.transform.position = _waypoints[0].position;

            for (int i = 0; i < _waypoints.Count - 1; i++)
            {
                yield return LerpCoroutine(objSpawned, _waypoints[i].position, _waypoints[i + 1].position);
            }
            objSpawned.SetActive(false);
        }
    }

    private IEnumerator LerpCoroutine(GameObject objToLerp, Vector3 start, Vector3 end)
    {
        float t = 0f;

        while (t <= 1f)
        {
            objToLerp.transform.position = Vector3.Lerp(start, end, t);
            t += Time.deltaTime / 2;
            yield return null; // We have to wait for the next frame
        }

        objToLerp.transform.position = end;
    }
}
