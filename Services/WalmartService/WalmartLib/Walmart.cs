using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.Services.WalmartService.WalmartLib
{
    public class Walmart
    {
        private WalmartOrderProcess walmartOrderProcess;

        public Walmart()
        {
            this.walmartOrderProcess = new WalmartOrderProcess();
        }
        public WalmartOrderProcess OrderProcess
        {
            get
            {
                return this.walmartOrderProcess;
            }
        }
    }
}
