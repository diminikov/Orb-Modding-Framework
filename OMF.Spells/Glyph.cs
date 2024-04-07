using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace OMF
{
    public class Glyph
    {
        private static List<GlyphSO> _AddedGlyphs = new();

        /// <summary>
        /// Function to register a glyph with OMF
        /// </summary>
        /// <param name="glyph"> GlyphSO to register</param>
        public static void RegisterGlyph(GlyphSO glyph)
        {
            //TODO: Add better validation
            if (_AddedGlyphs.Count > 0 && _AddedGlyphs.Find(x => x.GetGuid() == glyph.GetGuid()))
            {
                Debug.Log("Trying to add identical glyph");
                return;
            }
            _AddedGlyphs.Add(glyph);
        }

        /// <summary>
        /// Function to insert all registered glyphs into OoC. Do not use this!
        /// </summary>
        public static void AddRegisteredGlyphs()
        {
            GameManager GameManager = OMFUtils.GetManager<GameManager>();
            SpellManager SpellManager = OMFUtils.GetManager<SpellManager>();

            GameManager.allGlyphs.isStatic = false;
            SpellManager.allSpellGlyphs.isStatic = false;
            foreach (var glyph in _AddedGlyphs)
            {
                if (GameManager.allGlyphs.Find(x => x.GetGuid() == glyph.GetGuid()))
                {
                    Debug.Log("Trying to add identical glyph");
                    continue;
                }

                glyph.RegisterObject();

                GameManager.allGlyphs.Add(glyph);
                SpellManager.allSpellGlyphs.Add(glyph);

            }
            GameManager.allGlyphs.isStatic = true;
            SpellManager.allSpellGlyphs.isStatic = true;

        }

        /// <summary>
        /// Gets the glyph with the specified name
        /// </summary>
        /// <param name="name">Name of the glyph</param>
        /// <returns></returns>
        public static GlyphSO GetGlyphSO(string name)
        {
            GlyphSO glyph = GlyphSO.All.Find(x => x.displayName == name);

            if (glyph != null)
            {
                return glyph;
            }
            else
            {
                Debug.Log("Failed to find Spell Type: " + name);
                return null;
            }
        }

        /// <summary>
        /// Gets the glyph with the specified name
        /// </summary>
        /// <param name="name">Name of the glyph</param>
        /// <returns></returns>
        public static GlyphTypeSO GetGlyphTypeSO(string name)
        {
            GlyphTypeSO glyphType = GlyphTypeSO.All.Find(x => x.displayName == name);

            if (glyphType != null)
            {
                return glyphType;
            }
            else
            {
                Debug.Log("Failed to find Spell Type: " + name);
                return null;
            }
        }
    }

}
