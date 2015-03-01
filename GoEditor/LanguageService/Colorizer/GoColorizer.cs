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

        public GoColorizer(IVsTextLines textLines)
        {
            this.textLines = textLines;
        }

        public void CloseColorizer()
        {
            throw new NotImplementedException();
        }

        public int ColorizeLine(int iLine, int iLength, IntPtr pszText, int iState, uint[] pAttributes)
        {
            throw new NotImplementedException();
        }

        public int GetStartState(out int piStartState)
        {
            throw new NotImplementedException();
        }

        public int GetStateAtEndOfLine(int iLine, int iLength, IntPtr pText, int iState)
        {
            throw new NotImplementedException();
        }

        public int GetStateMaintenanceFlag(out int pfFlag)
        {
            throw new NotImplementedException();
        }
    }
}
