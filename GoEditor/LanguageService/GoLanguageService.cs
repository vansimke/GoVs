using allibeccom.GoEditor.LanguageService.Colorizer;
using allibeccom.GoEditor.LanguageService.Colorizer.ColorableItems;
using allibeccom.GoEditor.LanguageService.WindowManager;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.TextManager.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace allibeccom.GoEditor.LanguageService
{
    public class GoLanguageService : IVsLanguageInfo, IVsProvideColorableItems//, IVsLanguageDebugInfo, IVsLanguageBlock
    {
        private IVsColorableItem[] colorableItems;

        public GoLanguageService()
        {
            this.colorableItems = new IVsColorableItem[]
            {
                new NormalColorableItem(),
                new CommentColorableItem(),
                new KeywordColorableItem(),
                new NumberColorableItem(),
                new StringColorableItem(),
                new IdentifierColorableItem()
            };
        }

        public int GetCodeWindowManager(IVsCodeWindow pCodeWin, out IVsCodeWindowManager ppCodeWinMgr)
        {
            ppCodeWinMgr = new GoWindowManager(pCodeWin);
            return VSConstants.S_OK;
        }

        public int GetColorizer(IVsTextLines pBuffer, out IVsColorizer ppColorizer)
        {
            ppColorizer = new GoColorizer(pBuffer);
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

        public int GetColorableItem(int iIndex, out IVsColorableItem ppItem)
        {
            int result = VSConstants.E_INVALIDARG;

            ppItem = null;
            if (iIndex >= 0 && iIndex < colorableItems.Length)
            {
                ppItem = colorableItems[iIndex];
                result = VSConstants.S_OK; 
            }
            return result;
        }

        public int GetItemCount(out int piCount)
        {
            piCount = colorableItems.Length - 1;
            return VSConstants.S_OK;
        }
    }
}
