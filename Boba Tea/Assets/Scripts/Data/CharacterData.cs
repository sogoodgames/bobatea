using UnityEngine;

[CreateAssetMenu(fileName = "Data_Character", menuName = "BobaTea/ScriptableObjects/Character", order = 1)]
public class CharacterData : ScriptableObject 
{
    // ------------------------------------------------------------------------
    // Variables
    // ------------------------------------------------------------------------
    public string Name;
    public DrinkRequestData[] DrinkRequests;

    // TODO: actual progression data
    public int Progression; // index in drink requests of where we are
}