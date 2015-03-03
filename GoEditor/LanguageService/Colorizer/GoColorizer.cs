using allibeccom.GoEditor.Tokens;
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
        private Tokenizer tokenizer;

        private enum STATE
        {
            NORMAL,
            BLOCK_COMMENT
        }

        public GoColorizer(IVsTextLines textLines, Tokenizer tokenizer)
        {
            this.textLines = textLines;
            this.tokenizer = tokenizer;
        }

        public void CloseColorizer()
        {

        }

        public int ColorizeLine(int iLine, int iLength, IntPtr pszText, int iState, uint[] pAttributes)
        {
            string text = Marshal.PtrToStringAuto(pszText);

            STATE initialState = GetLineStartState(iLine);
            STATE endState = STATE.NORMAL;
            if (initialState == STATE.BLOCK_COMMENT || text.IndexOf("/*") > -1)
            {
                if (text.IndexOf("*/") == -1 ||
                    (text.IndexOf("/*") > text.IndexOf("*/")))
                {
                    endState = STATE.BLOCK_COMMENT;
                }
            }

            stateMap[iLine] = endState;

            List<Token> tokens = tokenizer.GetTokens(text);

            for (var i = 0; i < tokens.Count; i++)
            {
                var t = tokens[i];
                DEFAULTITEMS color = DEFAULTITEMS.COLITEM_TEXT;

                if (initialState == STATE.BLOCK_COMMENT)
                {
                    if (i < tokens.Count - 1)
                    {
                        if (t.Literal == "*/")
                        {
                            initialState = STATE.NORMAL;
                        }
                    }
                    color = DEFAULTITEMS.COLITEM_COMMENT;
                }
                else
                {
                    color = GetColorableTypeForToken(t);
                }
                for (var j = 0; j < t.Literal.Length; j++)
                {
                    pAttributes[t.Position + j] = (uint)color;
                }
            }

            return VSConstants.S_OK;
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
        private STATE GetLineStartState(int lineNumber)
        {
            STATE result = STATE.NORMAL;
            if (lineNumber > 0)
            {
                if (stateMap.ContainsKey(lineNumber - 1))
                {
                    result = stateMap[lineNumber - 1];
                }
            }

            return result;
        }


        private readonly Token.TokenType[] COMMENT_TOKENS = new Token.TokenType[]
        {
            Token.TokenType.COMMENT, 
        };

        private DEFAULTITEMS GetColorableTypeForToken(Token token)
        {
            DEFAULTITEMS result = DEFAULTITEMS.COLITEM_TEXT;
            if (COMMENT_TOKENS.Contains(token.TypeAsToken))
            {
                result = DEFAULTITEMS.COLITEM_COMMENT;
            }

            return result;
        }
    }
}
