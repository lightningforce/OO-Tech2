// <copyright file="FruitDataServiceTest.cs">Copyright ©  2016</copyright>
using System;
using System.Data;
using FruitStoreSystem2;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FruitStoreSystem2.Tests
{
    /// <summary>This class contains parameterized unit tests for FruitDataService</summary>
    [PexClass(typeof(FruitDataService))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class FruitDataServiceTest
    {
        /// <summary>Test stub for getFruitSeedData(String)</summary>
        [PexMethod]
        public DataTable getFruitSeedDataTest([PexAssumeUnderTest]FruitDataService target, string fruitType)
        {
            DataTable result = target.getFruitSeedData(fruitType);
            return result;
            // TODO: add assertions to method FruitDataServiceTest.getFruitSeedDataTest(FruitDataService, String)
        }
    }
}
