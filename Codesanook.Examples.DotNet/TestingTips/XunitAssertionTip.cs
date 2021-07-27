﻿using Xunit;

namespace Codesanook.Examples.DotNet.TestingTips
{
    public class XunitAssertionTips
    {
        [Fact]
        public void AssertCollectionAndOrderNotMatter()
        {
            var resultValues = new[] { "A", "B" };
            var expectedValues = new[] { "B", "A" };
            Assert.All(resultValues, r => Assert.Contains(r, expectedValues));
        }
    }
}
