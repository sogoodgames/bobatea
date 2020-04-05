using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Assertions;

// Stores all game data scriptable objects
// But instances on load so that we don't accidentally modify game data
// when running from the editor
public class GameData : MonoBehaviour
{
    // ------------------------------------------------------------------------
    // Variables
    // ------------------------------------------------------------------------
    [SerializeField]
    private PlayerData m_playerData;
    [SerializeField]
    private List<CharacterData> m_characters;
    [SerializeField]
    private List<SpellData> m_spells;
    [SerializeField]
    private List<DemonData> m_demons;
    [SerializeField]
    private List<IngredientData> m_ingredients;

    private PlayerData m_playerDataInstanced;
    private List<CharacterData> m_charactersInstanced;
    private List<SpellData> m_spellsInstanced;
    private List<DemonData> m_demonsInstanced;
    private List<IngredientData> m_ingredientsInstanced;

    private bool m_initialized;

    // ------------------------------------------------------------------------
    // Properties
    // ------------------------------------------------------------------------
    public PlayerData PlayerData {
        get {
            return m_playerDataInstanced;
        }
    }

    public List<CharacterData> Characters {
        get {
            if(!m_initialized) {Assert.IsTrue(m_initialized); return null;}
            return m_charactersInstanced;
        }
    }

    public List<SpellData> Spells {
        get {
            if(!m_initialized) {Assert.IsTrue(m_initialized); return null;}
            return m_spellsInstanced;
        }
    }

    public List<DemonData> Demons {
        get {
            if(!m_initialized) {Assert.IsTrue(m_initialized); return null;}
            return m_demonsInstanced;
        }
    }

    public List<IngredientData> Ingredients {
        get {
            if(!m_initialized) {Assert.IsTrue(m_initialized); return null;}
            return m_ingredientsInstanced;
        }
    }

    // ------------------------------------------------------------------------
    // Functions
    // ------------------------------------------------------------------------
    public void Init () {
        m_playerDataInstanced = Instantiate(m_playerData);

        m_charactersInstanced = new List<CharacterData>();
        foreach(CharacterData c in m_characters) {
            m_charactersInstanced.Add(Instantiate(c));
        }

        m_demonsInstanced = new List<DemonData>();
        foreach(DemonData c in m_demons) {
            m_demonsInstanced.Add(Instantiate(c));
        }

        m_ingredientsInstanced = new List<IngredientData>();
        foreach(IngredientData c in m_ingredients) {
            m_ingredientsInstanced.Add(Instantiate(c));
        }

        m_spellsInstanced = new List<SpellData>();
        foreach(SpellData c in m_spells) {
            m_spellsInstanced.Add(Instantiate(c));
        }

        m_initialized = true;
    }
}