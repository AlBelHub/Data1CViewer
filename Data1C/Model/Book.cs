using Newtonsoft.Json;

namespace Data1C.Model
{
    public class Book
    {
        [JsonProperty("Code")]
        public string? BookCode { get; set; }
        [JsonProperty("Description")]
        public string? BookDescription { get; set; }
        [JsonProperty("Автор")]
        public string? Author { get; set; }
        [JsonProperty("АвторскийЗнак")]
        public string? AuthorMark { get; set; }
        [JsonProperty("ГодИздания")]
        public string? ProdYear { get; set; }
        
        [JsonProperty("ИздательствоПредставление")]
        public string? Publisher { get; set; }
        [JsonProperty("МестоИзданияПредставление")]
        public string? Location { get; set; }
        
        [JsonProperty("ДатаПоследнихИзменений")]
        public DateTime DateOfLastChanges { get; set; }
        [JsonProperty("ДатаСозданияЗаписи")]
        public DateTime DateOfCreation { get; set; }
    }
}
