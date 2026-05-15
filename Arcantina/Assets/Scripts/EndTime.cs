using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndTime : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI LAJOS;
    void Start() {
        Debug.Log("You carried over: " + GameController.points_total + " points!");
        LAJOS.text = "Összes pont: " + GameController.points_total;
    }
    public void exit() {
        Application.Quit();
        Debug.Log("The game is quitting!");
    }
}
