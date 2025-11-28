using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using EnsolTest.Converters;

namespace EnsolTest.Dtos
{
    public class MaterialMaster
    {
        public string? OV_MTYP { get; set; }
        public string? OV_MSG { get; set; }
        [JsonConverter(typeof(SingleArrayJsonConverter<DATA1Object>))]
        public DATA1Object[] DATA1 { get; set; } = Array.Empty<DATA1Object>();
        [JsonConverter(typeof(SingleArrayJsonConverter<DATA2Object>))]
        public DATA2Object[] DATA2 { get; set; } = Array.Empty<DATA2Object>();
    }

    public class MMHeader
    {
        public string? IV_FLAG { get; set; }
        public string? IV_WERKS { get; set; }
        [JsonConverter(typeof(SapDatsConverter))]
        public DateTime? IV_FRDAT { get; set; }
        [JsonConverter(typeof(SapDatsConverter))]
        public DateTime? IV_TODAT { get; set; }
    }

    public class DATA1Object
    {
        public string? MATNR { get; set; }
        public string? MEINS { get; set; }
        public string? MATKL { get; set; }
        public string? MTART { get; set; }
        public string? WERKS { get; set; }
        public string? LVORM { get; set; }
        public string? VPRSV { get; set; }
        public string? BKLAS { get; set; }
        public decimal? STPRS { get; set; }
        public decimal? VERPR {  get; set; }
        public string? WAERS { get; set; }
        public string? ZFLAG { get; set; }
        public string? PRCTR { get; set; }
        public string? KLTXT { get; set; }
    }

    public class DATA2Object
    {
        public string? MATNR { get; set; }
        public string? MAKTX { get; set; }
        public string? MAKTG { get; set; }
        public string? SPRAS { get; set; }
        public string? LAISO { get; set; }
    }
}
