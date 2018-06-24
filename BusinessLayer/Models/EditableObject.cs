using System;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.Models
{
    public abstract class EditableObject
    {
        [Key]
        public Guid UniqueId { get; set; }
    }
}
