using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ligninger : MonoBehaviour
{
    Assignment Ligning = new Assignment(Assignment.Difficulty.EASY);
    movement movement;
    public string Svar;
    public InputField Input;

    // Use this for initialization
    void Start ()
    {
        
        GetComponent<TextMesh>().text = Ligning.Create();
        Svar = Ligning.correctAnswer;
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(Ligning.correctAnswer);
	}
    void LockInput(InputField input)
    {
       if (input.text = Svar)
       {
            movement.pickups = 1;
            SceneManager.LoadSceneAsync("MacDonals");
       }
    }
    
}
