using Microsoft.VisualStudio;
using Microsoft.VisualStudio.TextManager.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allibeccom.GoEditor.LanguageService.Colorizer
{
    public class GoColorizer : IVsColorizer
    {
        private IVsTextLines textLines;

        private enum State
        {
            NORMAL,
            COMMENT,
            KEYWORD,
            NUMBER,
            STRING,
            IDENTIFIER
        }

        public GoColorizer(IVsTextLines textLines)
        {
            this.textLines = textLines;
        }

        public void CloseColorizer()
        {
            
        }

        public int ColorizeLine(int iLine, int iLength, IntPtr pszText, int iState, uint[] pAttributes)
        {
            var state = (State)iState;
            for (var i = 0; i < iLength; i++) {
                pAttributes[i] = (int)DEFAULTITEMS.COLITEM_COMMENT;
            }
            return VSConstants.S_OK;
        }

        public int GetStartState(out int piStartState)
        {
            piStartState = (int)State.NORMAL;
            return VSConstants.S_OK;
        }

        public int GetStateAtEndOfLine(int iLine, int iLength, IntPtr pText, int iState)
        {
            iState = (int)State.COMMENT;
            return VSConstants.S_OK;
        }

        public int GetStateMaintenanceFlag(out int pfFlag)
        {
            pfFlag = 1;
            return VSConstants.S_OK;
        }
    }
}
