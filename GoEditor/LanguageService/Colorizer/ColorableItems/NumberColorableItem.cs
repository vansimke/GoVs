using Microsoft.VisualStudio.TextManager.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allibeccom.GoEditor.LanguageService.Colorizer.ColorableItems
{
    public class NumberColorableItem : GoColorableItem
    {
        public NumberColorableItem()
        {
            this.backColor = COLORINDEX.CI_SYSPLAINTEXT_BK;
            this.foreColor = COLORINDEX.CI_SYSPLAINTEXT_FG;
            this.name = "Go - Number";
            this.displayName = "Go - Number";
            this.fontFlags = FONTFLAGS.FF_DEFAULT;
        }
    }
}
