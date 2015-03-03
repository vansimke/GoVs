using allibeccom.GoEditor.LanguageService.Colorizer;
using allibeccom.GoEditor.LanguageService.WindowManager;
using allibeccom.GoEditor.Tokens;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.TextManager.Interop;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allibeccom.GoEditor.LanguageService
{
    public class GoLanguageService : IVsLanguageInfo//, IVsLanguageDebugInfo, IVsLanguageBlock
    {
        Tokenizer tokenizer = new Tokenizer();

        public GoLanguageService()
        {

        }

        public int GetCodeWindowManager(IVsCodeWindow pCodeWin, out IVsCodeWindowManager ppCodeWinMgr)
        {
            ppCodeWinMgr = new GoWindowManager(pCodeWin);
            return VSConstants.S_OK;
        }

        public int GetColorizer(IVsTextLines pBuffer, out IVsColorizer ppColorizer)
        {
            ppColorizer = new GoColorizer(pBuffer, tokenizer);
            return VSConstants.S_OK;
        }

        public int GetFileExtensions(out string pbstrExtensions)
        {
            pbstrExtensions = ".go";
            return VSConstants.S_OK;
        }

        public int GetLanguageName(out string bstrName)
        {
            bstrName = "Google Go";
            return VSConstants.S_OK;
        }
    }
}
