using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sniksnak : MonoBehaviour
{
    int textnumber = 1;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnMouseDown();
        }
    }
    private void OnMouseDown()
    {
        switch (textnumber)
        {
            case 1:

                textnumber++;
                break;
            case 2:

                textnumber++;
                break;
            case 3:

                textnumber++;
                break;
            case 4:
                SceneManager.LoadSceneAsync("MacDonals");
                break;
            default:
                break;
        }
    }
}

