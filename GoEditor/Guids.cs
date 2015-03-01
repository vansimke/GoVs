// Guids.cs
// MUST match guids.h
using System;

namespace allibeccom.GoEditor
{
    static class GuidList
    {
        public const string guidGoEditorPkgString = "6881dbd2-188e-44ea-a553-75f71eb37e0a";
        public const string guidGoEditorCmdSetString = "ee4bc813-6fed-4d3e-a80a-8d8b21b43072";

        public static readonly Guid guidGoEditorCmdSet = new Guid(guidGoEditorCmdSetString);
    };
}