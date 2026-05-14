
using System;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    int todays_points = 0;
    static int points_total;
    [SerializeField] Char1 character_1;
    [SerializeField] Char2 character_2;
    [SerializeField] Char3 character_3;

    void Awake() {
        character_2.enabled = false;
        character_3.enabled = false;
    }
    void Start() {
    }

    void Update() {
        if(character_1.isTurn && character_1.isFinished) {
            todays_points = character_1.Points(todays_points);
            character_1.animator.Play("Bye_E");
            character_1.enabled = false; 
            character_2.enabled = true;
            character_2.isTurn = true;
            character_1.isTurn = false;
        }

        if(character_2.isTurn && character_2.isFinished) {
            todays_points = character_1.Points(todays_points);
            character_2.animator.Play("Bye_J");
            character_2.enabled = false; 
            character_3.enabled = true;
            character_3.isTurn = true;
            character_2.isTurn = false;
        }
        
        if(character_3.isTurn && character_3.isFinished) {
            todays_points = character_3.Points(todays_points);
            character_3.animator.Play("Bye_BL");
            character_3.isTurn = false;
            todays_points += points_total;
            SceneManager.LoadScene("Level_1");
        }
    }
}