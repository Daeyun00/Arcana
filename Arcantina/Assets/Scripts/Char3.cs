using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char3 : MonoBehaviour
{
    //VARIABLES
    [SerializeField] RECIPES recipeName;
    Recipe recipe;
    [SerializeField] public Animator animator;
    public bool isFinished = false;
    public bool isTurn = false;
    public bool startCook = false;
    public RECIPES selectedRecipe;
    public COOKING_TIME cookedfor = COOKING_TIME.RAW;
    [SerializeField] private SpriteRenderer cooktimer;
    private float timer;
    private BOTTLE selectedBottle = BOTTLE.EMPTY;

    RoomController cameraChange;

    //FUNCTIONS UwU
    void Start() {
        recipe = Recipe.recipe_factory(recipeName);
        cameraChange = GetComponent<RoomController>();
        animator.Play("Forward_BL");//REPLACE
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
                        stopCooking();
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
        }
    }

    public int Points(int point) {
        if(selectedRecipe == recipe.name) {
            point += 1;
        }
        if(selectedBottle == recipe.preferred_bottle) {
            point += 1;
        }
        if(cookedfor == recipe.cooking_time) {
            point += 1;
        }

        return point;
    }

    private void SetColor(SpriteRenderer sprite, Color color) {
        sprite.color = color;
    }

    public void stopCooking() {
        if(isTurn && startCook && cookedfor != COOKING_TIME.RAW) {
            startCook = false;
            cameraChange.Camera_to_Bottling_room();
        }
    }

    public void selectRecipe_1() {
        if (isTurn) {
            selectedRecipe = RECIPES.HEALING;
            System.Console.WriteLine(selectedRecipe);
            startCook = true;
            cameraChange.Camera_to_Cooking_room();
        }
    }
    
    //BOTTLE_BUTTONS
    public void Bottle1() {
        if(cookedfor != COOKING_TIME.RAW && !startCook) {
            selectedBottle = BOTTLE.BOTTLE1;
            cameraChange.Camera_to_Waiting_room();
            isFinished = true;
        }
    }
    public void Bottle2() {
        if(cookedfor != COOKING_TIME.RAW && !startCook) {
            selectedBottle = BOTTLE.BOTTLE2;
            cameraChange.Camera_to_Waiting_room();
            isFinished = true;
        }
    }
    public void Bottle3() {
        if(cookedfor != COOKING_TIME.RAW && !startCook) {
            selectedBottle = BOTTLE.BOTTLE3;
            cameraChange.Camera_to_Waiting_room();
            isFinished = true;
        }
    }

}
