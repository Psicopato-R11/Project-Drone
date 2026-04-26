using System.Collections.Generic;
using UnityEngine;

public class WaypointContainer : MonoBehaviour
{
    public List<Transform> Waypoints;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        foreach(Transform tr in gameObject.GetComponentsInChildren<Transform>())
        Waypoints.Add(tr);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
