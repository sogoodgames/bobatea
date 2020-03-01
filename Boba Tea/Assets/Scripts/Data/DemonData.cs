using UnityEngine;

[CreateAssetMenu(fileName = "Data_Demon", menuName = "BobaTea/ScriptableObjects/Demon", order = 1)]
public class DemonData : ScriptableObject 
{
    // ------------------------------------------------------------------------
    // Variables
    // ------------------------------------------------------------------------
    public string Name;
    public Flavor Flavor;
    public int Hunger; // # of points required to remove

    // TODO: effect when active
    // TODO: effect on defeat
}