using System.Collections.Generic;

using UnityEngine;

[CreateAssetMenu(fileName = "Data_Player", menuName = "BobaTea/ScriptableObjects/Player", order = 1)]
public class PlayerData : ScriptableObject 
{
    // ------------------------------------------------------------------------
    // Variables
    // ------------------------------------------------------------------------
    public string Name;
    public IngredientData[] Ingredients;

    // TODO: progression data - ingredients should be progression data
}