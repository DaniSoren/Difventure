using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(-moveHorizontal*Time.deltaTime, 0.0f, -moveVertical*Time.deltaTime);
        Vector3 rotate = new Vector3(moveHorizontal*Time.deltaTime,0.0f, 0.0f);

        transform.Translate(movement*2);
        transform.Rotate(rotate);

    }
}
