using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.Entities
{
    public abstract class Entity : IEntity
    {
        public string Id { get; set; }
        public bool IsDeleted { get; protected set; }
    }
}
