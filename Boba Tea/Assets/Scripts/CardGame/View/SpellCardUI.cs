using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

using TMPro;

public class SpellCardUI : MonoBehaviour
{
    // ------------------------------------------------------------------------
    // Variables
    // ------------------------------------------------------------------------
    public TextMeshProUGUI SpellNameText;
    public TextMeshProUGUI CooldownText;

    private SpellData m_spell;

    // ------------------------------------------------------------------------
    // Functions
    // ------------------------------------------------------------------------
    public void Init (SpellData spell) {
        Assert.IsFalse(string.IsNullOrEmpty(spell.name));

        m_spell = spell;

        SpellNameText.text = m_spell.Name;
        CooldownText.text = "0";
    }
}