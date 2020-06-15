using System;
using Newtonsoft.Json;

namespace XamarinToDoList.Models
{
  public class Item
  {
    [JsonProperty("_id")]
    public string Id { get; set; }
    public string Text { get; set; }
    public string Description { get; set; }
  }

  public class ItemJSON
  {
    public string _id { get; set; }
    public string Text { get; set; }
    public string Description { get; set; }
  }
}