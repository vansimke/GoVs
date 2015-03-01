using Microsoft.VisualStudio.TextManager.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allibeccom.GoEditor.LanguageService.Colorizer.ColorableItems
{
    public class StringColorableItem : GoColorableItem
    {
        public StringColorableItem()
        {
            this.backColor = COLORINDEX.CI_SYSPLAINTEXT_BK;
            this.foreColor = COLORINDEX.CI_MAROON;
            this.name = "Go - String";
            this.displayName = "Go - String";
            this.fontFlags = FONTFLAGS.FF_DEFAULT;
        }
    }
}
