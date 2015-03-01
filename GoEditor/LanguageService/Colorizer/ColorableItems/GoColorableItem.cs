using Microsoft.VisualStudio;
using Microsoft.VisualStudio.TextManager.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allibeccom.GoEditor.LanguageService.Colorizer.ColorableItems
{
    public class GoColorableItem : IVsColorableItem
    {
        protected string name;
        protected string displayName;
        protected COLORINDEX foreColor;
        protected COLORINDEX backColor;
        protected FONTFLAGS fontFlags;

        public int GetDefaultColors(COLORINDEX[] piForeground, COLORINDEX[] piBackground)
        {
            if (piForeground != null)
            {
                piForeground[0] = foreColor;
            }
            if (piBackground != null)
            {
                piBackground[0] = backColor;
            }
            return VSConstants.S_OK;
        }

        public int GetDefaultFontFlags(out uint pdwFontFlags)
        {
            pdwFontFlags = (uint)fontFlags;
            return VSConstants.S_OK;
        }

        public int GetDisplayName(out string pbstrName)
        {
            pbstrName = displayName;
            return VSConstants.S_OK;
        }
    }
}
