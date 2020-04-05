using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class CardGameUI : MonoBehaviour
{
    // ------------------------------------------------------------------------
    // Variables
    // ------------------------------------------------------------------------
    public RectTransform SpellCardsParent;

    public GameObject SpellCardPrefab;

    public int MaxSpellCards = 4;

    // ------------------------------------------------------------------------
    // Functions
    // ------------------------------------------------------------------------
    public void StartGame (
        SpellData[] spells,
        IngredientData[] startingHand
    ) {
        PopulateSpellCards(spells);
    }

    // ------------------------------------------------------------------------
    private void PopulateSpellCards (SpellData[] spelldata) {
        Assert.IsTrue(spelldata.Length <= MaxSpellCards);

        foreach(SpellData spell in spelldata) {
            GameObject spellObj =
                Instantiate(SpellCardPrefab, SpellCardsParent) as GameObject;

            SpellCardUI spellUI;
            if((spellUI = spellObj.GetComponent<SpellCardUI>()) != null) {
                spellUI.Init(spell);
            } else {
                Assert.IsNotNull(spellUI);
            }
        }
    }

    // ------------------------------------------------------------------------
    private void PopulateHand (IngredientData[] ingredients) {
        Assert.IsTrue(ingredients.Length == CardGameController.c_handSize);
    }
}