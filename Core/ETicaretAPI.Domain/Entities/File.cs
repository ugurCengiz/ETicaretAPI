using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretAPI.Domain.Entities.Common;

namespace ETicaretAPI.Domain.Entities
{
    public class File :BaseEntity
    {
        [NotMapped] 
        public override DateTime UpdatedDate { get; set; }

        public string FileName { get; set; }
        public string Path { get; set; }

    }
}
