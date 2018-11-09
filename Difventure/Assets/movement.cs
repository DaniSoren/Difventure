using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{

    Animator Anim;
    public float speed = 6f;
    public bool pickuptrue = false;
    // Use this for initialization
    void Start ()
    {
        Anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(-moveHorizontal*Time.deltaTime, 0.0f, -moveVertical*Time.deltaTime);
      

        transform.Translate(movement*speed);
        

        Animating(moveHorizontal, moveVertical);
    }
    void Animating(float moveHorizontal, float moveVertical)
    {
        bool walking = moveHorizontal != 0f || moveVertical != 0f;

        Anim.SetBool ("IsWalking", walking);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            pickuptrue = true;
        }
    }
}
