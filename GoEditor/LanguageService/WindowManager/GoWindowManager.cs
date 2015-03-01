using Microsoft.VisualStudio;
using Microsoft.VisualStudio.TextManager.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allibeccom.GoEditor.LanguageService.WindowManager
{
    public class GoWindowManager : IVsCodeWindowManager
    {
        private IVsCodeWindow codeWindow;

        public GoWindowManager(IVsCodeWindow codeWindow)
        {
            this.codeWindow = codeWindow;
        }

        public int AddAdornments()
        {
            return VSConstants.S_OK;
        }

        public int OnNewView(IVsTextView pView)
        {
            return VSConstants.S_OK;
        }

        public int RemoveAdornments()
        {
            return VSConstants.S_OK;
        }
    }
}
