

namespace Chameleon.Services.AmazonService.AmazonLib
{
    public class Amazon
    {
       private AmazonPoProcess _amazonPoProcess;
       public Amazon()
       {
            _amazonPoProcess = new AmazonPoProcess();      
       }
       
       public AmazonPoProcess PoProcess
        {
            get
            {
                return _amazonPoProcess;
            }
        }


    }
}
