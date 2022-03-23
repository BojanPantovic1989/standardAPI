
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace standardAPI.Models
{
    [Keyless]
    [Table("currencies")]
    public class FxRate
    {
        [Column("currency_code")]
        public string CurrencyCode { get; set; } = string.Empty;
        public string Rate { get; set; } = string.Empty;
    }

}
