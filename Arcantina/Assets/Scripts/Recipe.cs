using System;
using System.Collections;
using System.Collections.Generic;

public class Recipe {
    
    COOKING_TIME cooking_time;
    BOTTLE preferred_bottle;

    public Recipe( COOKING_TIME cooking_time, BOTTLE preferred_bottle) {
        this.preferred_bottle = preferred_bottle;
        this.cooking_time = cooking_time;
    }

    public static Recipe recipe_factory(RECIPES name) {
        switch (name) {
            case RECIPES.PISS1: return new Recipe(COOKING_TIME.LIGHT, BOTTLE.BOTTLE2);
            default: return new Recipe(COOKING_TIME.LONG, BOTTLE.BOTTLE1);  
        }
        
    }




}