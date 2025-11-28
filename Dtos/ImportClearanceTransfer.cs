using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using EnsolTest.Converters;

namespace EnsolTest.Dtos
{
    public class ImportClearanceTransfer
    {
        public ICTHeader? Header { get; set; }
        [JsonConverter(typeof(SingleArrayJsonConverter<IT_HEAD_Object>))]
        public IT_HEAD_Object[]? IT_HEAD {  get; set; } = Array.Empty<IT_HEAD_Object>();
        [JsonConverter(typeof(SingleArrayJsonConverter<IT_ITEM_Object>))]
        public IT_ITEM_Object[]? IT_ITEM { get; set; } = Array.Empty<IT_ITEM_Object>();
        [JsonConverter(typeof(SingleArrayJsonConverter<IT_CONT_Object>))]
        public IT_CONT_Object[]? IT_CONT { get; set; } = Array.Empty<IT_CONT_Object>();
        [JsonConverter(typeof(SingleArrayJsonConverter<IT_ITEM_EQ_Obejct>))]
        public IT_ITEM_EQ_Obejct[]? IT_ITEM_EQ { get; set; } = Array.Empty<IT_ITEM_EQ_Obejct>();
        [JsonConverter(typeof(SingleArrayJsonConverter<IT_FINFO_Object>))]
        public IT_FINFO_Object[]? IT_FINFO { get; set; } = Array.Empty<IT_FINFO_Object>();

    }

    public class ICTHeader
    {
        public string? IV_BUKRS { get; set; }
    }

    public class IT_HEAD_Object
    {
        public string? ZDEDN { get; set; }
        public string? ZAYANO { get; set; }
        public string? ZINTEID { get; set; }
        public string? CORGAG { get; set; }
        public string? CORGAGNM { get; set; }
        [JsonConverter(typeof(SapDatsConverter))]
        public DateTime? APPDAT {  get; set; }
        public string? ZMUYBS { get; set; }
        public string? CORGOF { get; set; }
        public string? ZMCUST { get; set; }
        public string? ZIETYPE { get; set; }
        public string? ZIEMARK { get; set; }
        public string? ZNOTE { get; set; }
        public string? ZEMPID { get; set; }
        public string? ZORDTYPE { get; set; }
        public string? ZUNSBS { get; set; }
        public string? ZSENDCTESYS { get; set; }
        public string? ZUNJIG { get; set; }
        public string? ZINTAYANO { get; set; }
        public string? ZINTPROCNO { get; set; }
        public string? ZRELATECD { get; set; }
        public string? ZTRHBTY { get; set; }
        public string? ZPKTYPE { get; set; }
        public string? INCO1 { get; set; }
        public string? CUSTYPE { get; set; }
        public string? ZMBLNO { get; set; }
        public string? LIFNR { get; set; }
        public string? ZERNAM { get; set; }
        public string? SHCON { get; set; }
        public string? SHPORT { get; set; }
        public string? SHPORTX { get; set; }
        public string? ARCON { get; set; }
        public string? ARPORT { get; set; }
        public string? ARPORTX { get; set; }
        public string? ZDEDN_SPL { get; set; }
        public string? ZREQPS { get; set; }
        [JsonConverter(typeof(SapDatsConverter))]
        public DateTime? ZARRDAT { get; set; }
        public string? ZHBLNO { get; set; }
        public string? ZEQUIP { get; set; }
        [JsonConverter(typeof(SapDatsConverter))]
        public DateTime? ZASDAT { get; set; }

    }

    public class IT_ITEM_Object
    {
        public string? ZDEDN { get; set; }
        public string? ZPOSNR { get; set; }
        public string? ZAYANO { get; set; }
        public string? ZINTEID { get; set; }
        public string? ZSEQNO { get; set; }
        public string? MATNR { get; set; }
        public string? ZNETPR { get; set; }
        public string? ZKWMENG3_CN { get; set; }
        public string? ZNETWR3_CN { get; set; }
        public string? ZJNMSE { get; set; }
        public string? ZHG_WAERS { get; set; }
        public string? ZLSTDSTCT { get; set; }
        public string? ZKWMENG1_CN { get; set; }
        public string? ZKWMENG_CN { get; set; }
        public string? ZNOTE { get; set; }
        public string? ZEXTEND2 { get; set; }
        public string? ZEXTEND1 { get; set; }
        public string? ORDER_NO1 { get; set; }
        public string? ORDER_NO2 { get; set; }
        public string? ZINTPROCSEQ { get; set; }
        public string? ZLASTDEST { get; set; }
        public string? ZITEMNTGEW { get; set; }
        public string? ZFTAAYN { get; set; }
        public string? ZFTANO { get; set; }
        public string? WERKS { get; set; }

    }

    public class IT_CONT_Object
    {
        public string? ZDEDN { get; set; }
        public string? ZSEQNO { get; set; }
        public string? CTSIZE { get; set; }
        public string? CTCNT { get; set; }
        public string? VOLUM { get; set; }
        public string? VOLEH { get; set; }
        public string? CTNUM { get; set; }
        public string? BRGEW { get; set; }
        public string? GEWEI { get; set; }
    }

    public class IT_ITEM_EQ_Obejct
    {
        public string? ZDEDN { get; set; }
        public string? POSNR { get; set; }
        public string? ZNUM { get; set; }
        public string? HSCODE { get; set; }
        public string? ZPMYNG { get; set; }
        public string? ZPMYNG_E { get; set; }
        public string? ZMAKTX { get; set; }
        public string? MENGE { get; set; }
        public string? MEINS { get; set; }
        public string? ZMEINS { get; set; }
        public string? NETPR { get; set; }
        public string? NETWR { get; set; }
        public string? WAERS { get; set; }
        public string? NTGEW { get; set; }
        public string? GEWEI { get; set; }
        public string? ZLAND { get; set; }
        public string? ZFLG { get; set; }
        public string? SPLITNO { get; set; }
    }
    public class IT_FINFO_Object
    {
        public string? ZDEDN { get; set; }
        public string? DOC_ID { get; set; }
        public string? OBJECT_ID { get; set; }
        public string? OBJ_TYPE { get; set; }
        public string? OBJ_DESCR { get; set; }
        public string? DOC_SIZE { get; set; }
        public string? FEXTENSION { get; set; }
    }

    public class ICTResponse
    {

    }

    public class ICTReturn
    {
        public string? RETURN_CODE { get; set; }
        public string? RETURN_MSG { get; set; }
    }
}
