﻿using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BlogEngine.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SecretSanta.Business.Tests
{
    public class TestBase : SecretSanta.Data.Tests.TestBase
    {
        // Justification: Set by TestInitialize
#nullable disable // CS8618: Non-nullable field is uninitialized. Consider declaring as nullable.
        protected IMapper Mapper { get; private set; }
#nullable enable

        [TestInitialize]
        public override void InitializeTests()
        {
            base.InitializeTests();
            Mapper = AutomapperProfileConfiguration.CreateMapper();
        }
    }
}
