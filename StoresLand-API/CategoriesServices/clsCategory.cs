using StoresLand_API.CitiesServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace StoresLand_API.Categories
{
    public class CategoryDTO
    {
        public int? CategoryID { get; set; }
        public string CategoryNameAr { get; set; }
        public string CategoryNameEn { get; set; }

        public CategoryDTO(int? categoryid, string categorynamear, string categorynameen)
        {
            this.CategoryID = categoryid;
            this.CategoryNameAr = categorynamear;
            this.CategoryNameEn = categorynameen;

        }
    }

    public class clsCategory
    {

        public static async Task<List<CategoryDTO>> GetAllCategories()
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync("Category/GetAllCategories");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<CategoryDTO>>();
                }
                else
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    return null;
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex);
                return null;
            }
        }


        public static async Task<List<string>> GetAllCategoryAvailableByNameAr(int? typeID)
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"Category/GetAllCategoryAvailableByNameAr/{typeID}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<string>>();
                }
                else
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    return null;
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex);
                return null;
            }
        }

        public static async Task<List<string>> GetAllCategoryAvailableByNameEn(int? typeID)
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"Category/GetAllCategoryAvailableByNameEn/{typeID}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<string>>();
                }
                else
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    return null;
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex);
                return null;
            }
        }

        //public static async Task<List<string>> GetAllCategoryEn()
        //{
        //    try
        //    {
        //        var response = await clsUtil.httpClient.GetAsync("Category/GetAllCategoryEn");

        //        if (response.IsSuccessStatusCode)
        //        {
        //            return await response.Content.ReadFromJsonAsync<List<string>>();
        //        }
        //        else
        //        {
        //            string responseBody = await response.Content.ReadAsStringAsync();
        //            clsUtil.WriteExceptionError($"Status Code: {response.StatusCode}, Body: {responseBody}");
        //            return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        clsUtil.WriteExceptionError(ex.Message);
        //        return null;
        //    }
        //}

        //public static async Task<List<string>> GetAllCategoryAr()
        //{
        //    try
        //    {
        //        var response = await clsUtil.httpClient.GetAsync("Category/GetAllCategoryAr");

        //        if (response.IsSuccessStatusCode)
        //        {
        //            return await response.Content.ReadFromJsonAsync<List<string>>();
        //        }
        //        else
        //        {
        //            string responseBody = await response.Content.ReadAsStringAsync();
        //            clsUtil.WriteExceptionError($"Status Code: {response.StatusCode}, Body: {responseBody}");
        //            return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        clsUtil.WriteExceptionError(ex.Message);
        //        return null;
        //    }
        //}

        //public static async Task<string> GetCategoryNameArByCategoryID(int? categoryID)
        //{
        //    string CategoryName = "";

        //    try
        //    {
        //        var response = await clsUtil.httpClient.GetAsync($"Category/GetCategoryNameArByCategoryID/{categoryID}");

        //        if (response.IsSuccessStatusCode)
        //        {
        //            CategoryName = await response.Content.ReadAsStringAsync();
        //        }
        //        else
        //        {
        //            string responseBody = await response.Content.ReadAsStringAsync();
        //            clsUtil.WriteExceptionError($"Status Code: {response.StatusCode}, Body: {responseBody}");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        clsUtil.WriteExceptionError(ex.Message);
        //    }
        //    return CategoryName;

        //}

        //public static async Task<string> GetCategoryNameEnByCategoryID(int? categoryID)
        //{
        //    string CategoryName = "";

        //    try
        //    {
        //        var response = await clsUtil.httpClient.GetAsync($"Category/GetCategoryNameEnByCategoryID/{categoryID}");

        //        if (response.IsSuccessStatusCode)
        //        {
        //            CategoryName =  await response.Content.ReadAsStringAsync();
        //        }
        //        else
        //        {
        //            string responseBody = await response.Content.ReadAsStringAsync();
        //            clsUtil.WriteExceptionError($"Status Code: {response.StatusCode}, Body: {responseBody}");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        clsUtil.WriteExceptionError(ex.Message);
        //    }

        //    return CategoryName;
        //}


        //public static async Task<int?> GetCategoryIDByCategoryNameEn(string CategoryNameEn)
        //{
        //    int? CategoryID = null;
        //    try
        //    {
        //        var response = await clsUtil.httpClient.GetAsync($"Category/GetCategoryIDByCategoryNameEn/{CategoryNameEn}");

        //        if (response.IsSuccessStatusCode)
        //        {
        //            CategoryID = await response.Content.ReadFromJsonAsync<int?>();
        //        }
        //        else
        //        {
        //            string responseBody = await response.Content.ReadAsStringAsync();
        //            clsUtil.WriteExceptionError($"Status Code: {response.StatusCode}, Body: {responseBody}");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        clsUtil.WriteExceptionError(ex.Message);
        //    }
        //    return CategoryID;
        //}

        //public static async Task<int?> GetCategoryIDByCategoryNameAr(string CategoryNameAr)
        //{
        //    int? CategoryID = null;
        //    try
        //    {
        //        var response = await clsUtil.httpClient.GetAsync($"Category/GetCategoryIDByCategoryNameAr/{CategoryNameAr}");

        //        if (response.IsSuccessStatusCode)
        //        {
        //            CategoryID = await response.Content.ReadFromJsonAsync<int?>();
        //        }
        //        else
        //        {
        //            string responseBody = await response.Content.ReadAsStringAsync();
        //            clsUtil.WriteExceptionError($"Status Code: {response.StatusCode}, Body: {responseBody}");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        clsUtil.WriteExceptionError(ex.Message);
        //    }
        //    return CategoryID;
        //}


    }
}
