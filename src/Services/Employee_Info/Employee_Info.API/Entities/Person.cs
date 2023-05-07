using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Employee_Info.API.Entities
{
    public class Person
    {
        
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;

        [JsonPropertyName("employee_id")]
        public string? Employee_id { get; set; }

        [JsonPropertyName("first_name")]
        public string? First_name { get; set; }

        [JsonPropertyName("last_name")]
        public string? Last_name { get; set; }

        [JsonPropertyName("mobile_no")]
        public string? Mobile_no { get; set; }

        [JsonPropertyName("email_id")]
        public string? Email_id { get; set; }

        [JsonPropertyName("org_Unit")]
        public string? Org_unit { get; set; }

        [JsonPropertyName("org_team")]
        public string? Org_Team { get; set; }

        [JsonPropertyName("shape_role")]
        public string? Shape_Role  { get; set; }

        [JsonPropertyName("location")]
        public string? Location  { get; set; }

        [JsonPropertyName("type")]
        public string Type => "BSH.OPS.Tools.MasterData.Person";

        [JsonPropertyName("documentType")]
        public string DocumentType => "BSH.OPS.Tools.MasterData.Person";

    }
}
