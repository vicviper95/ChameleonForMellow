using Chameleon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chameleon.Services.SuiteTalkerService.SuiteTalkLib
{
    public class SuiteTalker
    {
        private SalesOrderProcess _salesOrderProcess;
        private InventoryrProcess _inventoryrProcess;
        public SuiteTalker(bool isProduct, KOALAContext kc)
        {
            _salesOrderProcess = new SalesOrderProcess(isProduct, kc);
            _inventoryrProcess = new InventoryrProcess(isProduct, kc);

        }
        public SalesOrderProcess salesOrderProcess {
            get
            {
                return _salesOrderProcess;
            }
        }
        public InventoryrProcess inventoryProcess
        {
            get
            {
                return _inventoryrProcess;
            }
        }
    }
}
        
    

