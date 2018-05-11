using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MedeiApp.Models;

namespace MedeiApp.WebService
{
    public interface IRestService
    {
        Task<List<Study>> RefreshDataAsync();

        Task SaveStudyItemAsync(Study item, bool isNewItem);

        Task DeleteStudyItemAsync(string id);
    }
}
