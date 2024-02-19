namespace API.Mappers;

using DTOs;
using DTOs.Comment;
using Models;

public static class CommentMappers
{
    public static CommentDto ToCommentDto(this Comment commentDto)
    {
        return new CommentDto
        {
            Id = commentDto.Id,
            Title = commentDto.Title,
            Content = commentDto.Content,
            CreatedOn = commentDto.CreatedOn,
            CreateBy = commentDto.AppUser.UserName,
            StockId = commentDto.StockId
        };
    }

    public static Comment ToCommentFromCreate(this CreateCommentDto commentDto, int stockId)
    {
        return new Comment
        {
            Title = commentDto.Title,
            Content = commentDto.Content,
            StockId = stockId
        };
    }
    
    public static Comment ToCommentFromUpdate(this UpdateCommentRequestDto commentDto)
    {
        return new Comment
        {
            Title = commentDto.Title,
            Content = commentDto.Content
        };
    }
}