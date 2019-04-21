using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SolutionManagement.SKUManager;
using Xunit;

namespace SolutionManagerTests
{
    public class SKUManagerTests
    {
        private ISkuManager skuManager;

        public SKUManagerTests()
        {
            this.skuManager = new SKUManager();
        }

        [Fact]
        public async Task CanCheckSKULimits()
        {
        }
    }
}
