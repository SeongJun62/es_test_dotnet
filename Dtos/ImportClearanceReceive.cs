using EnsolTest.Converters;
using System.Text.Json.Serialization;

namespace EnsolTest.Dtos
{
    public class ImportClearanceReceive
    {
        public string? BUKRS { get; set; }
        [JsonConverter(typeof(SingleArrayJsonConverter<ERP_SAP_I_RETURN_Object>))]
        public ERP_SAP_I_RETURN_Object[]? ERP_SAP_I_RETURN {  get; set; } = Array.Empty<ERP_SAP_I_RETURN_Object>();
    }

    public class ERP_SAP_I_RETURN_Object
    {
        public string? ZDEDN {  get; set; }
        public string? ZG2CODE { get; set; }

        public string? ZCOMPUTERCODE { get; set; }

        public string? TYPE { get; set; }

        public string? MESSAGE { get; set; }

        public string? ZIFDATE { get; set; }

        public string? ZIFTIME { get; set; }

        public string? ZIFUSERID { get; set; }

    }
}
