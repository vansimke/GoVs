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
            throw new NotImplementedException();
        }

        public int OnNewView(IVsTextView pView)
        {
            throw new NotImplementedException();
        }

        public int RemoveAdornments()
        {
            throw new NotImplementedException();
        }
    }
}
