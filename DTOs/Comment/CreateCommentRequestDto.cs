namespace API.DTOs;

public class CreateCommentRequestDto
{
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public int? StockId { get; set; }
}