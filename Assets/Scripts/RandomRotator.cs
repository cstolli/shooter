using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

	public float tumble;
	private Vector3 randomAngularVelocity;
	public Rigidbody asteroid;

	// Use this for initialization
	void Start () {
		asteroid = GetComponent<Rigidbody>();
		randomAngularVelocity = Random.insideUnitSphere;
	}
	
	// Update is called once per frame
	void Update () {
		asteroid.angularVelocity =  randomAngularVelocity * tumble;
	}
}
