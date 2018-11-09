using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    // Tillader brugeren at få en opgave og evt. få rettet den.
    // Samtidig må brugeren se sit antal af korrekte svar
    private Assignment task = new Assignment(Assignment.Difficulty.INSANE);

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
