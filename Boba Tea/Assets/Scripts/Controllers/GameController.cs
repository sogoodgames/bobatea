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

    public CardGameController CardGameController;

    // TODO: test- remove later
    public CharacterData TEST_StartCharacter;
    public SpellData[] TEST_StartSpells;

    // ------------------------------------------------------------------------
    // Functions
    // ------------------------------------------------------------------------
    void Awake () {
        GameData.Init();

        // TODO: TEST -- forcing game to start at card game, remove later
        // TODO: TEST -- forcing input ingredients to player's entire deck
        CardGameController.StartGame(
            TEST_StartCharacter,
            TEST_StartCharacter.DrinkRequests[0],
            TEST_StartSpells,
            GameData.PlayerData.Ingredients
        );
    }
}