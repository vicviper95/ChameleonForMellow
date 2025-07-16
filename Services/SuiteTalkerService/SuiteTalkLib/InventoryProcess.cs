using Chameleon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.Services.SuiteTalkerService.SuiteTalkLib
{
    public class InventoryrProcess : SuiteTalkerUtil
    {
        private readonly KOALAContext _kc = new KOALAContext();
        public InventoryrProcess(bool isProduction, KOALAContext kc) : base(isProduction)
        {
            _kc = kc;
        }

    }
}
