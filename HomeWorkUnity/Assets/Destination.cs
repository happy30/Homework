using UnityEngine;
using System.Collections;

public class Destination : MonoBehaviour {

    NavMeshAgent nav;
    public Transform dest;

	// Use this for initialization
	void Start ()
    {
        nav = GetComponent<NavMeshAgent>();

	}
	
	// Update is called once per frame
	void Update ()
    {
        nav.SetDestination(dest.position);
	}
}
