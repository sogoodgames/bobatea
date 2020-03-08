using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Assertions;

public class CardGameController : MonoBehaviour
{
    // ------------------------------------------------------------------------
    // Variables
    // ------------------------------------------------------------------------
    public GameController GameController;
    public CardGameUI CardGameUI;

    private CharacterData m_character;
    private DrinkRequestData m_request;

    // ------------------------------------------------------------------------
    // Functions
    // ------------------------------------------------------------------------
    public void StartGame (
        CharacterData character,
        DrinkRequestData request,
        SpellData[] spells
    ) {
        m_character = character;
        m_request = request;
        
        // populate all UI
        CardGameUI.StartGame(spells);
    }
}