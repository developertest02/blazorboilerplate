using BlazorBoilerplate.Theme.Material.Shared.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorBoilerplate.Shared.Dto.Db;
using BlazorBoilerplate.Shared.Models;
using System.ComponentModel;
using Breeze.Sharp;
using BlazorBoilerplate.Shared.Interfaces;

namespace BlazorBoilerplate.Theme.Material.Demo.Pages
{
    public partial class ExercisesPagingBasePage : ItemsTableBase<Exercise>
    {
        protected ExerciseFilter exerciseFilter = new();

        protected List<SelectItem<Guid?>> Creators = new();
        protected List<SelectItem<Guid?>> Editors = new();
        protected override async Task OnInitializedAsync()
        {
            await LoadFilters();

            queryParameters = exerciseFilter;

            exerciseFilter.PropertyChanged += FilterPropertyChanged;
        }

        private async void FilterPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            orderByDescending = "CreatedOn";

            isBusy = true;

            await LoadFilters(e.PropertyName);

            apiClient.ClearEntitiesCache();

            await Reload();

            isBusy = false;
        }

        private async Task LoadFilters(string propertyName = null)
        {
            var tasks = new Dictionary<string, Task>();

            if (propertyName != nameof(exerciseFilter.CreatedById))
                tasks.Add("GetTodoCreators", apiClient.GetExerciseCreators(exerciseFilter));

            if (propertyName != nameof(exerciseFilter.ModifiedById))
                tasks.Add("GetTodoEditors", apiClient.GetExerciseEditors(exerciseFilter));

            await Task.WhenAll(tasks.Values.ToArray());

            foreach (var task in tasks)
            {
                if (task.Key == "GetExerciseCreators")
                {
                    var t = (Task<QueryResult<ApplicationUser>>)task.Value;

                    if (!t.IsFaulted)
                    {
                        Creators = t.Result.Select(i => new SelectItem<Guid?> { Id = i.Id, DisplayValue = i.UserName }).ToList();

                        Creators.Insert(0, new SelectItem<Guid?> { Id = null, DisplayValue = "-" });
                    }
                    else
                        viewNotifier.Show(t.Exception.GetBaseException().Message, ViewNotifierType.Error, L["Operation Failed"]);
                }
                else if (task.Key == "GetExerciseEditors")
                {
                    var t = (Task<QueryResult<ApplicationUser>>)task.Value;

                    if (!t.IsFaulted)
                    {
                        Editors = t.Result.Select(i => new SelectItem<Guid?> { Id = i.Id, DisplayValue = i.UserName }).ToList();

                        Editors.Insert(0, new SelectItem<Guid?> { Id = null, DisplayValue = "-" });
                    }
                    else
                        viewNotifier.Show(t.Exception.GetBaseException().Message, ViewNotifierType.Error, L["Operation Failed"]);
                }
            }
        }

        protected override Task OnSearch(string text)
        {
            exerciseFilter.Query = text;

            return Task.CompletedTask;
        }

        protected async void Update(Todo todo)
        {
            try
            {
                todo.IsCompleted = !todo.IsCompleted;

                await apiClient.SaveChanges();

                viewNotifier.Show($"{todo.Title} updated", ViewNotifierType.Success, L["Operation Successful"]);
            }
            catch (Exception ex)
            {
                viewNotifier.Show(ex.GetBaseException().Message, ViewNotifierType.Error, L["Operation Failed"]);
            }
        }

        public override void Dispose()
        {
            exerciseFilter.PropertyChanged -= FilterPropertyChanged;

            base.Dispose();
        }
    }
}
