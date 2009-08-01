﻿//-----------------------------------------------------------------------
// <copyright file="EnumColumnValueTests.cs" company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Isam.Esent.Interop;
using Microsoft.Isam.Esent.Interop.Vista;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InteropApiTests
{
    /// <summary>
    /// Tests for JET_ENUMCOLUMNVALUE conversion.
    /// </summary>
    [TestClass]
    public class EnumColumnValueTests
    {
        /// <summary>
        /// Test conversion of a single value
        /// </summary>
        [TestMethod]
        [Priority(0)]
        public void TestConversion()
        {
            var native = new NATIVE_ENUMCOLUMNVALUE
            {
                cbData = 1,
                err = (int) JET_wrn.ColumnTruncated,
                itagSequence = 2,
                pvData = new IntPtr(3),
            };

            var managed = new JET_ENUMCOLUMNVALUE();
            managed.SetFromNativeEnumColumnValue(native);

            Assert.AreEqual(1, managed.cbData);
            Assert.AreEqual(JET_wrn.ColumnTruncated, managed.err);
            Assert.AreEqual(2, managed.itagSequence);
            Assert.AreEqual(new IntPtr(3), managed.pvData);
        }
    }
}