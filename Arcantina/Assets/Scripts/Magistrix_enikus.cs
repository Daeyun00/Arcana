
using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Magistrix_enikus : MonoBehaviour {
    //VARIABLES
    public Animator animator;
    [SerializeField] public RECIPES recipeName;
    private Recipe recipe;
    [SerializeField] private TextMeshProUGUI speechText;
    [SerializeField] private GameObject TextBubble;
    [SerializeField] private Camera CookCamera;
    [SerializeField] private Camera PrepCamera;
    [SerializeField] private Camera BottleCamera;
    [SerializeField] private Camera WaitingCamera;
    static String tell = "MMMMMM MEN KISSING MMMMMM AKSFOENH";

    //CONTROL THINGIES BECAUSE I DONT KNOW HOW TO SEPARATE THESE SO EVERYTHING IS IN ONE FILE YEY :DDD
    public bool isfinished = false;
    public bool isturn = true;
    public bool startCook = false;
    public RECIPES selectedRecipe;
    public COOKING_TIME cookedfor = COOKING_TIME.RAW;
    [SerializeField] private SpriteRenderer cooktimer;
    private float timer;
    private BOTTLE selectedBottle;


    //FUNCTIONS
    void Start() {
        recipe = Recipe.recipe_factory(recipeName);
        animator.Play("Forward_E");
        speechText.text = tell;
    }

    void Update() {
        //COOKING UWU
        if (startCook) {
            if (startCook) {
                timer += Time.deltaTime;
                if (timer >= 25f) {
                    if (cookedfor != COOKING_TIME.CHARRED) {
                        cookedfor = COOKING_TIME.CHARRED;
                        SetColor(cooktimer, Color.black);
                        startCook = false;
                    }
                }
                else if (timer >= 20f) {
                    if (cookedfor != COOKING_TIME.LONG) {
                        cookedfor = COOKING_TIME.LONG;
                        SetColor(cooktimer, Color.red);
                    }
                }
                else if (timer >= 15f) {
                    if (cookedfor != COOKING_TIME.MEDIUM) {
                        cookedfor = COOKING_TIME.MEDIUM;
                        SetColor(cooktimer, Color.yellow);
                    }
                }
                else if (timer >= 10f) {
                    if (cookedfor != COOKING_TIME.LIGHT) {
                        cookedfor = COOKING_TIME.LIGHT;
                        SetColor(cooktimer, Color.cyan);
                    }
                }
            }
            //Debug.Log(timer);
        }
        //COOKING ENDS HERE BTW :333
        if (isfinished) {
            points();
            BottleCamera.enabled = false;
            WaitingCamera.enabled = true;
        }
    }
    

    public int points() {
        return 0;
    }

    public void selectRecipe_1() {
        if (isturn) {
            selectedRecipe = RECIPES.PISS1;
            System.Console.WriteLine(selectedRecipe);
            startCook = true;
            PrepCamera.enabled = false;
            CookCamera.enabled = true;

        }
    }
    private void SetColor(SpriteRenderer sprite, Color color) {
        sprite.color = color;
    }

    public void stopCooking() {
        if(isturn && startCook && cookedfor != COOKING_TIME.RAW) {
            startCook = false;
            CookCamera.enabled = false;
            BottleCamera.enabled = true;

        }
    }

    public void setBottle_1() {
        selectedBottle = BOTTLE.BOTTLE1;
        isfinished = true;
    }
    public void setBottle_2() {
        selectedBottle = BOTTLE.BOTTLE2;
        isfinished = true;
    }
    public void setBottle_3() {
        selectedBottle = BOTTLE.BOTTLE3;
        isfinished = true;
    }

    
}