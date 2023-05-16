using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundcheck : MonoBehaviour
{

	public Transform playerpos;

	public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
	transform.position = playerpos.position + offset;        
    }
}
