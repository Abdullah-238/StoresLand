using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace StoresLand_API.TypesServices
{
    public class TypeDTO
    {
        public int? TypeID { get; set; }
        public string TypeNameAr { get; set; }

        public string TypeNameEn { get; set; }

        public TypeDTO(int? typeid, string typenamear, string typenameen)
        {
            this.TypeID = typeid;
            this.TypeNameAr = typenamear;
            this.TypeNameEn = typenameen;

        }
    }
    public class clsType
    {
        public static async Task<TypeDTO> AddType(TypeDTO typeDTO)
        {
            try
            {
                var response = await clsUtil.httpClient.PostAsJsonAsync("Types/AddType", typeDTO);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<TypeDTO>();
                }
                else
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    clsUtil.WriteExceptionError($"Status Code: {response.StatusCode}, Body: {responseBody}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex.Message);
                return null;
            }
        }

        public static async Task<TypeDTO> UpdateType(int? typeID, TypeDTO typeDTO)
        {
            try
            {
                var response = await clsUtil.httpClient.PutAsJsonAsync($"Types/UpdateType/{typeID}", typeDTO);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<TypeDTO>();
                }
                else
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    clsUtil.WriteExceptionError($"Status Code: {response.StatusCode}, Body: {responseBody}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex.Message);
                return null;
            }
        }

        public static async Task<bool> DeleteType(int? typeID)
        {
            try
            {
                var response = await clsUtil.httpClient.DeleteAsync($"Types/DeleteType/{typeID}");

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    clsUtil.WriteExceptionError($"Status Code: {response.StatusCode}, Body: {responseBody}");
                    return false;
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex.Message);
                return false;
            }
        }

        public static async Task<TypeDTO> GetType(int? typeID)
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"Types/GetType/{typeID}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<TypeDTO>();
                }
                else
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    clsUtil.WriteExceptionError($"Status Code: {response.StatusCode}, Body: {responseBody}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex.Message);
                return null;
            }
        }

        public static async Task<List<TypeDTO>> GetAllTypes()
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync("Types/GetAllTypes");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<TypeDTO>>();
                }
                else
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    clsUtil.WriteExceptionError($"Status Code: {response.StatusCode}, Body: {responseBody}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex.Message);
                return null;
            }
        }

        public static async Task<List<string>> GetAllTypesAr()
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync("Types/GetAllTypesAr");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<string>>();
                }
                else
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    clsUtil.WriteExceptionError($"Status Code: {response.StatusCode}, Body: {responseBody}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex.Message);
                return null;
            }
        }

        public static async Task<List<string>> GetAllTypesEn()
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync("Types/GetAllTypesEn");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<string>>();
                }
                else
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    clsUtil.WriteExceptionError($"Status Code: {response.StatusCode}, Body: {responseBody}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex.Message);
                return null;
            }
        }

        public static async Task<TypeDTO> FindTypeAr(string typeNameAr)
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"Types/FindTypeAr/{typeNameAr}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<TypeDTO>();
                }
                else
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    clsUtil.WriteExceptionError($"Status Code: {response.StatusCode}, Body: {responseBody}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex.Message);
                return null;
            }
        }

        public static async Task<TypeDTO> FindTypeEn(string typeNameEn)
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"Types/FindTypeEn/{typeNameEn}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<TypeDTO>();
                }
                else
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    clsUtil.WriteExceptionError($"Status Code: {response.StatusCode}, Body: {responseBody}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex.Message);
                return null;
            }
        }


        public static async Task<string> GetTypeNameArByTypeID(int? TypeID)
        {
            string TypeName = null;
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"Types/GetTypeNameArByTypeID/{TypeID}");

                if (response.IsSuccessStatusCode)
                {
                    TypeName = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    clsUtil.WriteExceptionError($"Status Code: {response.StatusCode}, Body: {responseBody}");
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex.Message);
            }
            return TypeName;

        }

        public static async Task<string> GetTypeNameEnByTypeID(int? TypeID)
        {
            string TypeName = null;

            try
            {
                var response = await clsUtil.httpClient.GetAsync($"Types/GetTypeNameEnByTypeID/{TypeID}");

                if (response.IsSuccessStatusCode)
                {
                    TypeName = await response.Content.ReadAsStringAsync();
                }
                else
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    clsUtil.WriteExceptionError($"Status Code: {response.StatusCode}, Body: {responseBody}");
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex.Message);
            }

            return TypeName;

        }

        public static async Task<int?> GetTypeIDByTypeNameEn(string TypeNameEn)
        {
            int? TypeID = null;
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"Types/GetTypeIDByTypeNameEn/{TypeNameEn}");

                if (response.IsSuccessStatusCode)
                {
                    TypeID = await response.Content.ReadFromJsonAsync<int?>();
                }
                else
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    clsUtil.WriteExceptionError($"Status Code: {response.StatusCode}, Body: {responseBody}");
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex.Message);
            }
            return TypeID;
        }

        public static async Task<int?> GetTypeIDByTypeNameAr(string TypeNameAr)
        {
            int? TypeID = null;
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"Types/GetTypeIDByTypeNameAr/{TypeNameAr}");

                if (response.IsSuccessStatusCode)
                {
                    TypeID = await response.Content.ReadFromJsonAsync<int?>();
                }
                else
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    clsUtil.WriteExceptionError($"Status Code: {response.StatusCode}, Body: {responseBody}");
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex.Message);
            }
            return TypeID;
        }


    }

}

