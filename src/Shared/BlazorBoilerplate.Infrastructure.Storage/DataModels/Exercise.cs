using BlazorBoilerplate.Infrastructure.Storage.DataInterfaces;
using BlazorBoilerplate.Infrastructure.Storage.Permissions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBoilerplate.Infrastructure.Storage.DataModels
{
    //[Permissions(Actions.Delete)]
    public partial class Exercise : IAuditable, ISoftDelete
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
