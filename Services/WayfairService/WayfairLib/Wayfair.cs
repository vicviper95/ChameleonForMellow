using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Chameleon.DTOs.Wayfair;
using GraphQL;


namespace Chameleon.Services.WayfairService.WayfairLib
{
    public class Wayfair
	{
        private WayfairPO wayfairPo;
        public Wayfair()
        {
            this.wayfairPo = new WayfairPO();
        }
	    public WayfairPO PoProcess
        {
            get
            {
                return this.wayfairPo;
            }
        }
    }
}
