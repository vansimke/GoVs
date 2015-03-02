using Microsoft.VisualStudio;
using Microsoft.VisualStudio.TextManager.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace allibeccom.GoEditor.LanguageService.Colorizer
{
    public class GoColorizer : IVsColorizer
    {
        private IVsTextLines textLines;

        private Dictionary<int, STATE> stateMap = new Dictionary<int, STATE>();

        private enum STATE
        {
            NORMAL,
            BLOCK_COMMENT
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
            var state = GetInitialStateForLine(iLine);
            string text = Marshal.PtrToStringAuto(pszText);
            
            for (int position = 0; position < iLength; position++)
            {
                int tokenLength;
                DEFAULTITEMS tokenType;

                if (state == STATE.NORMAL)
                {
                    state = FindNextToken(position, text, out tokenLength, out tokenType);
                }
                else
                {
                    state = ContinueBlockComment(position, text, out tokenLength, out tokenType);
                }

                for (var i = 0; i < tokenLength; i++)
                {
                    pAttributes[position + i] = (uint)tokenType;
                }
                position += tokenLength;
            }
            stateMap[iLine] = state;

            return VSConstants.S_OK;
        }

        private STATE GetInitialStateForLine(int line)
        {
            STATE result = stateMap.ContainsKey(line - 1) ? stateMap[line - 1] : STATE.NORMAL;

            return result;
        }

        private STATE FindNextToken(int position, string text, out int tokenLength, out DEFAULTITEMS tokenType)
        {
            STATE result;

            int remainingCharacters = text.Length - position;
            if (remainingCharacters >= 2) {
                if (text.Substring(position, 2) == "//") 
                {
                    tokenLength = text.Length - position;
                    tokenType = DEFAULTITEMS.COLITEM_COMMENT;
                    result = STATE.NORMAL;
                }
                else if (text.Substring(position, 2) == "/*") 
                {
                    result = ContinueBlockComment(position, text, out tokenLength, out tokenType);
                }
                else
                {
                    tokenLength = 1;
                    tokenType = DEFAULTITEMS.COLITEM_TEXT;
                    result = STATE.NORMAL;
                }
            }
            else 
            {
                tokenLength = 1;
                tokenType = DEFAULTITEMS.COLITEM_TEXT;
                result = STATE.NORMAL;
            }

            return result;
        }

        private STATE ContinueBlockComment(int position, string text, out int tokenLength, out DEFAULTITEMS tokenType)
        {
            STATE newState;
            if (text.Length < 2)
            {
                tokenLength = text.Length - position;
                tokenType = DEFAULTITEMS.COLITEM_COMMENT;
                newState = STATE.BLOCK_COMMENT;
            }
            else
            {
                int endIndex = text.IndexOf("*/", position);
                if (endIndex == -1)
                {
                    tokenLength = text.Length - position;
                    tokenType = DEFAULTITEMS.COLITEM_COMMENT;
                    newState = STATE.BLOCK_COMMENT;
                }
                else
                {
                    tokenLength = endIndex - position + 2;
                    tokenType = DEFAULTITEMS.COLITEM_COMMENT;
                    newState = STATE.NORMAL;
                }
            }

            return newState;
        }

        public int GetStartState(out int piStartState)
        {
            piStartState = (int)DEFAULTITEMS.COLITEM_TEXT;
            return VSConstants.S_OK;
        }

        public int GetStateAtEndOfLine(int iLine, int iLength, IntPtr pText, int iState)
        {
            iState = (int)(stateMap.ContainsKey(iLine) ? stateMap[iLine] : STATE.NORMAL);
            return VSConstants.S_OK;
        }

        public int GetStateMaintenanceFlag(out int pfFlag)
        {
            pfFlag = 0;
            return VSConstants.S_OK;
        }
    }
}
