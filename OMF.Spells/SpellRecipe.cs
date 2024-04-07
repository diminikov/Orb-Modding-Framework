using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OMF
{
    public class SpellRecipe
    {
        private static List<SpellRecipeSO> _AddedSpellRecipies = new();

        /// <summary>
        /// Function to register a spell recipe with OMF
        /// </summary>
        /// <param name="spellRecipe"> SpellRecipeSO to register</param>
        public static void RegisterSpellRecipe(SpellRecipeSO spellRecipe)
        {
            //TODO: Add better validation
            if (_AddedSpellRecipies.Count > 0 && _AddedSpellRecipies.Find(x => x.GetGuid() == spellRecipe.GetGuid()))
            {
                Debug.Log("Trying to add identical spell");
                return;
            }
            _AddedSpellRecipies.Add(spellRecipe);
        }

        /// <summary>
        /// Function to insert all registered spells into OoC. Do not use this!
        /// </summary>
        public static void AddRegisteredSpellRecipes()
        {
            GameManager GameManager = OMFUtils.GetManager<GameManager>();

            GameManager.allSpells.isStatic = false;
            foreach (var spellRecipe in _AddedSpellRecipies)
            {
                if (GameManager.allSpells.Find(x => x.GetGuid() == spellRecipe.GetGuid()))
                {
                    Debug.Log("Trying to add identical spell");
                    continue;
                }

                spellRecipe.RegisterObject();

                GameManager.allSpells.Add(spellRecipe);

            }
            GameManager.allSpells.isStatic = true;
        }

    }

}
