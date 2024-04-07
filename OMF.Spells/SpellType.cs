using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace OMF 
{ 
    public static class SpellType
    {
        private static List<SpellTypeSO> _AddedSpellTypes = new();

        /// <summary>
        /// Function to register a spell type with OMF
        /// </summary>
        /// <param name="spellType"> SpellTypeSO to register</param>
        public static void RegisterSpellType(SpellTypeSO spellType)
        {
            //TODO: Add better validation
            if (_AddedSpellTypes.Count > 0 && _AddedSpellTypes.Find(x => x.GetGuid() == spellType.GetGuid()))
            {
                Debug.Log("Trying to add identical resource");
                return;
            }
            _AddedSpellTypes.Add(spellType);
        }

        /// <summary>
        /// Function to insert all registered spell type into OoC. Do not use this!
        /// </summary>
        public static void AddRegisteredSpellTypes()
        {
            GameManager GameManager = OMFUtils.GetManager<GameManager>();

            GameManager.allSpellTypes.isStatic = false;
            foreach (var spellType in _AddedSpellTypes)
            {
                if (GameManager.allSpellTypes.Find(x => x.GetGuid() == spellType.GetGuid()))
                {
                    Debug.Log("Trying to add identical resource");
                    continue;
                }

                spellType.RegisterObject();

                GameManager.allSpellTypes.Add(spellType);

            }
            GameManager.allSpellTypes.isStatic = true;

        }

        /// <summary>
        /// Gets the spell type with the specified name
        /// </summary>
        /// <param name="name">Name of the resource</param>
        /// <returns></returns>
        public static SpellTypeSO GetSpellTypeSO(string name)
        {
            SpellTypeSO res = SpellTypeSO.All.Find(x => x.displayName == name);

            if (res != null)
            {
                return res;
            }
            else
            {
                Debug.Log("Failed to find Spell Type: " + name);
                return null;
            }
        }
    }

}

