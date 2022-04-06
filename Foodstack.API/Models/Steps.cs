using System.Text.Json.Serialization;

namespace Foodstack.API.Models;

public class Step
{
  [JsonPropertyName("step")]
  public string? IndividualStep { get; set; }
}

public class Steps
{
  [JsonPropertyName("name")]
  public string? Name { get; set; }

  [JsonPropertyName("steps")]
  public List<Step>? StepList { get; set; }
}