using System;
using System.Collections.Generic;
using System.Text;

namespace Chameleon.DTOs.Wayfair
{

     public class InvalidRes
     {
         public Error[] errors { get; set; }
         public object[] data { get; set; }
     }

     public class Error
     {
         public string message { get; set; }
         public Extensions extensions { get; set; }
         public Location[] locations { get; set; }
         public string category { get; set; }
     }

     public class Extensions
     {
         public string category { get; set; }
     }

     public class Location
     {
         public int line { get; set; }
         public int column { get; set; }
     }

    
}
