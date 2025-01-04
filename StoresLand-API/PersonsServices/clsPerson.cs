using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace StoresLand_API.Persons
{
    public class Person
    {
        public int? PersonID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public Person(int? personid, string name, string phone, string email, string password, bool isactive)
        {
            this.PersonID = personid;
            this.Name = name;
            this.Phone = phone;
            this.Email = email;
            this.Password = password;
            this.IsActive = isactive;

        }
    }
    public class clsPerson
    {
        public static async Task<Person> AddPerson(Person personDTO)
        {
            try
            {
                var response = await clsUtil.httpClient.PostAsJsonAsync("Persons/AddPerson", personDTO);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<Person>();
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

        public static async Task<Person> UpdatePerson(int? personID, Person personDTO)
        {
            try
            {
                var response = await clsUtil.httpClient.PutAsJsonAsync($"Persons/UpdatePerson/{personID}", personDTO);

                if (response.IsSuccessStatusCode)
                {

                    var addedCustomers = await response.Content.ReadFromJsonAsync<Person>();
                    if (addedCustomers != null)
                    return addedCustomers;
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

            return null;
        }

        public static async Task<bool> DeletePerson(int? personID)
        {
            try
            {
                var response = await clsUtil.httpClient.DeleteAsync($"Persons/DeletePerson/{personID}");

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

        public static async Task<Person> GetPerson(int? personID)
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"Persons/GetPerson/{personID}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<Person>();
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

        public static async Task<List<Person>> GetAllPersons()
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync("Persons/GetAllPersons");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<Person>>();
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

        public static async Task<bool> IsPersonExists(int? personID)
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"Persons/Exists/{personID}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<bool>();
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

        public static async Task<bool> IsPersonExistsByEmail(string email)
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"Persons/ExistsByEmail/{email}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<bool>();
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

        public static async Task<bool> IsPersonExistsByPhone(string phone)
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"Persons/ExistsByPhone/{phone}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<bool>();
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

        public static async Task<Person> FindPersonByEmailAndPassword(string email, string password)
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"Persons/FindPersonByEmailAndPassword/{email}/{password}" );

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<Person>();
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

        public static async Task<bool> UpdatePass(string email, string password)
        {
            try
            {
                var response = await clsUtil.httpClient.GetAsync($"Persons/UpdatePass/{email}/{password}");

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                clsUtil.WriteExceptionError(ex.Message);
            }

            return false;
        }

    }
}
