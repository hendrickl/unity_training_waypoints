using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
    [SerializeField] private List<Transform> _waypoints = new List<Transform>();

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(SpawnObject());
        }
    }

    private IEnumerator SpawnObject()
    {
        foreach (Transform _waypoint in _waypoints)
        {
            gameObject.transform.position = _waypoint.position;
            yield return new WaitForSeconds(2);
        }
        Destroy(gameObject);
    }
}
