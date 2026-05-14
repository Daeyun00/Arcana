using System;
using System.Collections;
using System.Collections.Generic;

public class Recipe {
    
    public COOKING_TIME cooking_time;
    public BOTTLE preferred_bottle;
    public RECIPES name;

    public Recipe( COOKING_TIME cooking_time, BOTTLE preferred_bottle, RECIPES name) {
        this.preferred_bottle = preferred_bottle;
        this.cooking_time = cooking_time;
        this.name = name;
    }

    public static Recipe recipe_factory(RECIPES name) {
        switch (name) {
            case RECIPES.HEALING: return new Recipe(COOKING_TIME.LIGHT, BOTTLE.BOTTLE2, RECIPES.HEALING);
            case RECIPES.LOVE: return new Recipe(COOKING_TIME.LONG, BOTTLE.BOTTLE1, RECIPES.LOVE);
            case RECIPES.AMNESIA: return new Recipe(COOKING_TIME.MEDIUM, BOTTLE.BOTTLE1, RECIPES.AMNESIA);
            default: return new Recipe(COOKING_TIME.LIGHT, BOTTLE.BOTTLE1, RECIPES.HEALING);  
        }
        
    }




}