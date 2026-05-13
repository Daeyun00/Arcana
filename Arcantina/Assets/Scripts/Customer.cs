using System.Collections.Generic;
using UnityEngine;
//melegszex
public abstract class Customer : MonoBehaviour
{
    public RECIPES recipe_name;
    public string tale;
    public Object front;
    public Object behind;

    /*public Customer(RECIPES recipe_name, string tale, Object front, Object behind){
        this.recipe_name = recipe_name;
        this.tale = tale;
        this.front = front;
        this.behind = behind;
    }*/
    
    public abstract int points();
    

}
