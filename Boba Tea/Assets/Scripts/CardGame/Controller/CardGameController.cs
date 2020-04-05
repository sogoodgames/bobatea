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

    // tuning
    public static readonly int c_handSize = 5;

    // session variables
    private CharacterData m_character;
    private DrinkRequestData m_request;
    private Deck<IngredientData> m_ingredients;

    // ------------------------------------------------------------------------
    // Functions
    // ------------------------------------------------------------------------
    public void StartGame (
        CharacterData character,
        DrinkRequestData request,
        SpellData[] spells,
        IngredientData[] ingredients
    ) {
        Assert.IsTrue(ingredients.Length >= c_handSize);

        m_character = character;
        m_request = request;

        // shuffle ingredients and draw starting hand
        m_ingredients = new Deck<IngredientData>();
        foreach(IngredientData ingredient in ingredients) {
            m_ingredients.Push(ingredient);
        }
        m_ingredients.Shuffle();

        IngredientData[] startingHand = new IngredientData[c_handSize];
        for(int i = 0; i < c_handSize; i++) {
            startingHand[i] = m_ingredients.Pop();
        }
        
        // populate all UI
        CardGameUI.StartGame(spells, startingHand);
    }
}