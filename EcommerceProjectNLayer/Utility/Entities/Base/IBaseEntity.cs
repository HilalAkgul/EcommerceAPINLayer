using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Base
{
    public class IBaseEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedDateTime { get; set; }
        public int CreatedBy { get; set; }


    }
}

