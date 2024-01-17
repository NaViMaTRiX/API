namespace API.Mappers;

using DTOs;
using Models;

public static class CommentMappers
{
    public static CommentDto ToCommentDto(this Comment commentModel)
    {
        return new CommentDto
        {
            Id = commentModel.Id,
            Title = commentModel.Title,
            Content = commentModel.Content,
            CreatedOn = commentModel.CreatedOn,
            StockId = commentModel.StockId,
        };
    }

    public static Comment ToCommentFromCreateDTO(this CreateCommentRequestDto commentDto)
    {
        return new Comment
        {
            Content = commentDto.Content,
            Title = commentDto.Content,
            CreatedOn = commentDto.CreatedOn,
            StockId = commentDto.StockId,
        };
    }
}