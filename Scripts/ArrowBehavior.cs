using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowBehavior : MonoBehaviour
{
	public float power;
	Rigidbody rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		rb.AddRelativeForce(Vector3.up * 20.0f, ForceMode.VelocityChange); 
	}


}
