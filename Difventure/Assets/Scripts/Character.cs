using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    // Tillader brugeren at f� en opgave og evt. f� rettet den.
    // Samtidig m� brugeren se sit antal af korrekte svar
    private Assignment task = new Assignment(Assignment.Difficulty.INSANE);

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
