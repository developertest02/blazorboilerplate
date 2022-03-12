using BlazorBoilerplate.Infrastructure.Storage.DataInterfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBoilerplate.Infrastructure.Storage.DataModels
{
    public partial class Exercise : IAuditable, ISoftDelete
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "FieldRequired")]
        [MaxLength(128)]
        public string Name { get; set; }

        [Required(ErrorMessage = "FieldRequired")]
        [MaxLength(128)]
        public string Description { get; set; }

    }
}
