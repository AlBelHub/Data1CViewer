using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Data1C.Model
{
    public class Book
    {
        [JsonProperty("Code")]
        [Display(Name = "КОД")]
        public string? BookCode { get; set; }
        [JsonProperty("Description")]
        [Display(Name = "Описание")]
        public string? BookDescription { get; set; }
        [JsonProperty("Автор")]
        [Display(Name = "Автор")]
        public string? Author { get; set; }
        [JsonProperty("АвторскийЗнак")]
        [Display(Name = "Авторский знак")]
        public string? AuthorMark { get; set; }
        [JsonProperty("ГодИздания")]
        [Display(Name = "Год издания")]
        public string? ProdYear { get; set; }
        
        [JsonProperty("ИздательствоПредставление")]
        [Display(Name = "Издательство")]
        public string? Publisher { get; set; }
        [JsonProperty("МестоИзданияПредставление")]
        [Display(Name = "Место издания")]
        public string? Location { get; set; }
        
        [JsonProperty("ДатаПоследнихИзменений")]
        [Display(Name = "Дата последних изменений")]
        public DateTime DateOfLastChanges { get; set; }
        [JsonProperty("ДатаСозданияЗаписи")]
        [Display(Name = "Дата создания")]
        public DateTime DateOfCreation { get; set; }
    }
}
