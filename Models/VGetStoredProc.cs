using System;
using System.Collections.Generic;

#nullable disable

namespace Chameleon.Models
{
    public partial class VGetStoredProc
    {
        public string Name { get; set; }
        public int ObjectId { get; set; }
        public int? PrincipalId { get; set; }
        public int SchemaId { get; set; }
        public int ParentObjectId { get; set; }
        public string Type { get; set; }
        public string TypeDesc { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public bool IsMsShipped { get; set; }
        public bool IsPublished { get; set; }
        public bool IsSchemaPublished { get; set; }
    }
}
