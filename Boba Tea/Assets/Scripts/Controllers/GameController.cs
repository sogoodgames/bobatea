using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Assertions;

// controls game opening/ closing and meta app states
public class GameController : MonoBehaviour
{
    // ------------------------------------------------------------------------
    // Variables
    // ------------------------------------------------------------------------
    public GameData GameData;

    // TODO: test- might remove later
    public CardGameController CardGameController;
    public CharacterData TEST_StartCharacter;
    public SpellData[] TEST_StartSpells;

    // ------------------------------------------------------------------------
    // Functions
    // ------------------------------------------------------------------------
    void Awake () {
        GameData.Init();

        // TODO: TEST -- forcing game to start at card game, remove later
        CardGameController.StartGame(
            TEST_StartCharacter,
            TEST_StartCharacter.DrinkRequests[0],
            TEST_StartSpells
        );
    }
}