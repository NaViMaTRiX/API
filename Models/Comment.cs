﻿using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    using Helper;
    
    [Table("Comments")]
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public int? StockId { get; set; }
        
        public Stock? Total { get; set; }
    }
}
