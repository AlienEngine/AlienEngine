using System;
using System.Collections.Generic;

namespace AlienEngine.Core.Rendering.Fonts
{
    public class FontKerningConfiguration
    {
        /// <summary>
        /// Kerning rules for particular characters
        /// </summary>
        private Dictionary<char, FontCharacterKerningRule> CharacterKerningRules = new Dictionary<char, FontCharacterKerningRule>();

        /// <summary>
        /// When measuring the bounds of glyphs, and performing kerning calculations, 
        /// this is the minimum alpha level that is necessray for a pixel to be considered
        /// non-empty. This should be set to a value on the range [0,255]
        /// </summary>
		public byte AlphaEmptyPixelTolerance = 0;


        /// <summary>
        /// Sets all characters in the given string to the specified kerning rule.
        /// </summary>
        /// <param name="chars"></param>
        /// <param name="rule"></param>
        public void BatchSetCharacterKerningRule(String chars, FontCharacterKerningRule rule)
        {
            foreach (var c in chars)
            {
                CharacterKerningRules[c] = rule;
            }
        }

        /// <summary>
        /// Sets the specified character kerning rule.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="rule"></param>
        public void SetCharacterKerningRule(char c, FontCharacterKerningRule rule)
        {
            CharacterKerningRules[c] = rule;
        }

        public FontCharacterKerningRule GetCharacterKerningRule(char c)
        {
            if (CharacterKerningRules.ContainsKey(c))
            {
                return CharacterKerningRules[c];
            }

            return FontCharacterKerningRule.Normal;
        }

        /// <summary>
        /// Given a pair of characters, this will return the overriding 
        /// CharacterKerningRule.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public FontCharacterKerningRule GetOverridingCharacterKerningRuleForPair(String str)
        {
            if (str.Length < 2)
            {
                return FontCharacterKerningRule.Normal;
            }

            char c1 = str[0];
            char c2 = str[1];

            if (GetCharacterKerningRule(c1) == FontCharacterKerningRule.Zero || GetCharacterKerningRule(c2) == FontCharacterKerningRule.Zero)
            {
                return FontCharacterKerningRule.Zero;
            }
            else if (GetCharacterKerningRule(c1) == FontCharacterKerningRule.NotMoreThanHalf || GetCharacterKerningRule(c2) == FontCharacterKerningRule.NotMoreThanHalf)
            {
                return FontCharacterKerningRule.NotMoreThanHalf;
            }

            return FontCharacterKerningRule.Normal;
        }

        public FontKerningConfiguration()
        {
			SetCharacterKerningRule('^', FontCharacterKerningRule.NotMoreThanHalf);
			SetCharacterKerningRule('_', FontCharacterKerningRule.NotMoreThanHalf);
            SetCharacterKerningRule('\"', FontCharacterKerningRule.NotMoreThanHalf);
            SetCharacterKerningRule('\'', FontCharacterKerningRule.NotMoreThanHalf);
        }
    }
}
