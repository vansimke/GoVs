﻿/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/

using System;
using System.Collections;
using System.Text;
using System.Reflection;
using Microsoft.VsSDK.UnitTestLibrary;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using allibeccom.GoEditor;

namespace GoEditor_UnitTests
{
    [TestClass()]
    public class PackageTest
    {
        [TestMethod()]
        public void CreateInstance()
        {
            GoEditorPackage package = new GoEditorPackage();
        }

        [TestMethod()]
        public void IsIVsPackage()
        {
            GoEditorPackage package = new GoEditorPackage();
            Assert.IsNotNull(package as IVsPackage, "The object does not implement IVsPackage");
        }

    }
}
