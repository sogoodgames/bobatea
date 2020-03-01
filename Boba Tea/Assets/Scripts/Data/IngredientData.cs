using UnityEngine;

[CreateAssetMenu(fileName = "Data_Ingredient", menuName = "BobaTea/ScriptableObjects/Ingredient", order = 1)]
public class IngredientData : ScriptableObject 
{
    // ------------------------------------------------------------------------
    // Variables
    // ------------------------------------------------------------------------
    public string Name;
    public IngredientCategory Category;
    public Flavor Flavor;
    public int Value; // # points contributed to category
    public int Amount; // # of instances of this card in a deck

    // TODO: activated effect
}