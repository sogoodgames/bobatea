using System;
using System.Collections.Generic;

using UnityEngine;

[Serializable]
public class FlavorAmount {
    public Flavor Flavor;
    public int Min;
    public int Max;
}

[CreateAssetMenu(fileName = "Data_DrinkRequest", menuName = "BobaTea/ScriptableObjects/DrinkRequest", order = 1)]
public class DrinkRequestData : ScriptableObject 
{
    // ------------------------------------------------------------------------
    // Variables
    // ------------------------------------------------------------------------
    public List<Tag> Tags;
    public List<FlavorAmount> Flavors;
    public List<IngredientData> Ingredients;
}