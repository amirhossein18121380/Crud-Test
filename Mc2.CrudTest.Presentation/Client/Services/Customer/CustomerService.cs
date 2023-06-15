namespace Mc2.CrudTest.Presentation.Client.Services.Customer;

using Mc2.CrudTest.Presentation.Client.Dtos.Customer;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class CustomerService : ICustomerService
{

    private readonly HttpClient _httpClient;
    public CustomerService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    //public async Task Initialize()
    //{
    //    Customer = await _localStorageService.GetItem<Models.Customer>(null);
    //}

    public async Task<AddCustomerResponseDto> AddCustomer(AddCustomerRequestDto request)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Customers/AddCustomer", request);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<AddCustomerResponseDto>();
    }

    public async Task<GetCustomersByPageResponseDto> GetAllCustomers(/*GetCustomersByPageRequestDto request*/)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Post, "//api/Customers/GetAllCustomers");
        request.Headers.Add("Accept", "text/plain");
        var content = new StringContent("{\n  \"pageNumber\": \"1\",\n  \"pageSize\": \"10\",\n  \"filters\": \"<string>\",\n  \"sortOrder\": \"<string>\"\n}", null, "application/json");
        request.Content = content;
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        //Console.WriteLine(await response.Content.ReadAsStringAsync());
        return await response.Content.ReadFromJsonAsync<GetCustomersByPageResponseDto>();
    }

    public async Task<bool> DeleteCustomer(ulong customerId)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Delete, "//api/Customers/DeleteCustomer");
        request.Headers.Add("Accept", "text/plain");
        var content = new StringContent("{\n  \"id\": \"customerId\"  \n}", null, "application/json");
        request.Content = content;
        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        //Console.WriteLine(await response.Content.ReadAsStringAsync());
        if (response.EnsureSuccessStatusCode().IsSuccessStatusCode == false)
        {
            return false;
        }
        return true;
    }

    public async Task<UpdateDto> UpdateCustomer(UpdateDto request)
    {
        var response = await _httpClient.PutAsJsonAsync("api/Customers/UpdateCustomer", request);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<UpdateDto>();
    }
}

