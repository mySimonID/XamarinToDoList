using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using XamarinToDoList.Models;
using XamarinToDoList.Services;

namespace MasterDetail.Services
{
  public class mongoDB : IDataStore<Item>
  {
    const string webService = "http://192.168.1.9:49160";

    public mongoDB() {}

    public async Task<bool> AddItemAsync(Item item)
    {
      try
      {
        string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(item);

        var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

        Uri uri = new Uri(string.Format(webService + "/new", string.Empty));

        HttpClient client = new HttpClient();

        var response = await client.PostAsync(uri, httpContent);

      }
      catch (Exception ex)
      {
        Console.WriteLine("Error: " + ex.Message);
      }

      return await Task.FromResult(true);
    }

    public async Task<bool> UpdateItemAsync(Item item)
    {
  
      var newItem = new ItemJSON
      {
        _id = item.Id,
        Text = item.Text,
        Description = item.Description
      };
      
      string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(newItem);
      var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

      Uri uri = new Uri(string.Format(webService + "/save/" + newItem._id, newItem));

      HttpClient client = new HttpClient();

      var response = await client.PostAsync(uri, httpContent);
      //
      return await Task.FromResult(true);
    }

    public async Task<bool> DeleteItemAsync(string id)
    {
      try
      {

        var ignore = new ItemJSON();

        string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(ignore);

        var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

        Uri uri = new Uri(string.Format(webService + "/delete/" + id, string.Empty));

        HttpClient client = new HttpClient();

        var response = await client.PostAsync(uri, httpContent);

      }
      catch (Exception ex)
      {
        Console.WriteLine("Error: " + ex.Message);
      }

      return await Task.FromResult(true);
    }

    public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
    {
      try
      {
  
        Uri uri = new Uri(string.Format(webService, string.Empty));

        HttpClient client = new HttpClient();

        HttpResponseMessage response = await client.GetAsync(uri);

        if (response.IsSuccessStatusCode)
        {
          string content = await response.Content.ReadAsStringAsync();

          return await Task.FromResult(JsonConvert.DeserializeObject<List<Item>>(content));

        }
      }
      catch (Exception ex)
      {
        Console.WriteLine("Error: " + ex.Message);
      }

      return await Task.FromResult(new List<Item>());
    }
  }
}
