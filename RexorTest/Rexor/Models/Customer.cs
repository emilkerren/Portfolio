using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Rexor.Models
{
    public class Customer : IValidatableObject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "PartitionKey must be greater than 0.")]
        public int RebateId { get; set; }
        [Required]
        [Display(Name="Customer Name")]
        [StringLength(maximumLength:10, ErrorMessage ="Must be between 3 and 10 characters", MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        public DateTime DateAdded { get; private set; } = DateTime.Now;
        public int? AmountBought { get; set; } = 1000;
        public bool? IsSelected { get; set; } = false;
        public Customer()
        {

        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (RebateId == 0)
            {
                yield return new ValidationResult(
                    "PartitionKey cannot be 0.",
                    new[] { nameof(RebateId) }
                );
            }
        }

    }
}
