using BlazorBoilerplate.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SourceGenerators;
namespace BlazorBoilerplate.Shared.Models
{
    public partial class ExerciseFilter : QueryParameters, IDateTimeFilter
    {
        [AutoNotify]
        private DateTime? _from;

        [AutoNotify]
        private DateTime? _to;

        [AutoNotify]
        private Guid? _createdById;

        [AutoNotify]
        private Guid? _modifiedById;

        [AutoNotify]
        private string? _name;

        [AutoNotify]
        private string _query;
    }
}
