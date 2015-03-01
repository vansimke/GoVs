using Microsoft.VisualStudio.TextManager.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allibeccom.GoEditor.LanguageService.Colorizer.ColorableItems
{
    public class KeywordColorableItem : GoColorableItem
    {
        public KeywordColorableItem()
        {
            this.backColor = COLORINDEX.CI_SYSPLAINTEXT_BK;
            this.foreColor = COLORINDEX.CI_BLUE;
            this.name = "Go - Keyword";
            this.displayName = "Go - Keyword";
            this.fontFlags = FONTFLAGS.FF_DEFAULT;
        }
    }
}
