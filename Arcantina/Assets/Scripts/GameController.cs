
using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    int todays_points = 0;
    int points_total;

     Char1 character_1;
     Char2 character_2;
     Char3 character_3;

     
    void Start() {
        character_1 = GetComponentInChildren<Char1>();
        

    
    }

    void Update() {
        if(character_1.isTurn && character_1.isFinished) {

            todays_points += character_1.Points(todays_points);
            character_1.isTurn = false; 
            character_2.isTurn = true;
            
        }

        if(character_2.isTurn && character_2.isFinished) {
            todays_points += character_2.Points(todays_points);
            character_2.isTurn = false;
            character_3.isTurn = true;
        }
        
        if(character_3.isTurn && character_3.isFinished) {
            todays_points += character_3.Points(todays_points);
            character_3.isTurn = false;
            todays_points += points_total;
        }
    }
}