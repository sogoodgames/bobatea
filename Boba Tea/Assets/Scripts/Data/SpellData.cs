using UnityEngine;

[CreateAssetMenu(fileName = "Data_Spell", menuName = "BobaTea/ScriptableObjects/Spell", order = 1)]
public class SpellData : ScriptableObject 
{
    // ------------------------------------------------------------------------
    // Variables
    // ------------------------------------------------------------------------
    public string Name;
    public int Cost; // point cost to activate
    public int Cooldown; // # rounds before use again

    // TODO: activated effect
}