using DataTables.AspNet.Core;
using DataTables.AspNet.Mvc5;
using System.Collections.Generic;
using System.Linq;

namespace BrownsIntranetApps.Presentation.Helpers
{
    public static class DataTableServerSideHelper<TEntity> where TEntity : class
    {
        public static DataTablesResponse ProcessData(List<TEntity> dataToProcess, IDataTablesRequest request)
        {
            if (request == null) return null;
            var filteredData = dataToProcess;
            if (request.Search.Value.Trim() != "")
            {
                filteredData = GlobalFilterData(dataToProcess, request);
            }

            filteredData = ColumnFilterData(filteredData, request);
            filteredData = SortData(filteredData, request);
            var paginatedData = PaginateData(filteredData, request);

            DataTablesResponse response = DataTablesResponse.Create(request, dataToProcess.Count, filteredData.Count, paginatedData);
            return response;
        }

        private static object PaginateData(List<TEntity> dataToPaginate, IDataTablesRequest request)
        {
            var length = 0;
            length = request.Length == -1 ? dataToPaginate.Count : request.Length;
            var results = dataToPaginate;
            results = results.Skip(request.Start).Take(length).ToList();
            return results;
        }

        private static List<TEntity> SortData(List<TEntity> dataSort, IDataTablesRequest request)
        {
            var results = dataSort;
            foreach (var column in request.Columns.Where(d => d.IsSortable && d.Sort != null))
            {
                if (column.Sort.Direction == SortDirection.Ascending)
                {
                    results = results.OrderBy(d => GetPropertyValue(d, column.Name)).ToList();
                }
            }
            return results;
        }

        private static List<TEntity> ColumnFilterData(List<TEntity> dataToFilter, IDataTablesRequest request)
        {
            var results = dataToFilter;
            var filteredResults = new List<TEntity>();

            foreach (var column in request.Columns.Where(d => d.IsSearchable && !string.IsNullOrEmpty(d.Search?.Value)))
            {
                results = results.Where(
                    d => GetPropertyValue(d, column.Name) != null)
                        .Where(d => GetPropertyValue(d, column.Name)
                        .ToString()
                        .ToLower()
                        .Contains(column.Search.Value.ToLower()))
                        .ToList();
            }
            return results;
        }

        private static List<TEntity> GlobalFilterData(List<TEntity> dataToFilter, IDataTablesRequest request)
        {
            var results = dataToFilter;
            var filteredResults = new HashSet<TEntity>();
            foreach (var column in request.Columns)
            {
                var fResults = results.Where(d => GetPropertyValue(d, column.Name) != null).Where(d => GetPropertyValue(d, column.Name)
                                                                                           .ToString()
                                                                                           .ToLower()
                                                                                           .Contains(request.Search.Value.ToLower()))
                                                                                        .ToList();
                if (!fResults.Any()) continue;
                foreach (var result in fResults)
                {
                    filteredResults.Add(result);
                }
            }
            return filteredResults.ToList();
        }

        private static object GetPropertyValue(object obj, string propertyName)
        {
            var propertyNames = propertyName.Split('.');
            for (var i = 0; i < propertyNames.Length; i++)
            {
                if (obj != null)
                {
                    var propertyInfo = obj.GetType().GetProperty(propertyNames[i]);
                    obj = propertyInfo?.GetValue(obj);
                }
            }
            return obj;
        }
    }
}