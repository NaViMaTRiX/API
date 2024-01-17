namespace API.Controllers;

using Data;
using DTOs;
using Microsoft.AspNetCore.Mvc;
using Mappers;
using Microsoft.EntityFrameworkCore;

[Route("api/v1/comment")]
public class CommentController : ControllerBase
{
    private readonly AppDbContext _context;
    public CommentController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var comments = await _context.Comments.ToListAsync();
        var commentModel = comments.Select(s => s.ToCommentDto());
        return Ok(comments);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var comment = await _context.Comments.FindAsync(id);
        if (comment is null)
        {
            return NotFound();
        }
        return Ok(comment.ToCommentDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCommentRequestDto commentDto)
    {
        var commentModel = commentDto.ToCommentFromCreateDTO();
        await _context.Comments.AddAsync(commentModel);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = commentModel.Id }, commentModel.ToCommentDto());
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentRequentDto updateComment)
    {
        var commentModel = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);

        if (commentModel is null)
        {
            return NotFound();
        }

        commentModel.Title = updateComment.Title;
        commentModel.Content = updateComment.Content;
        commentModel.CreatedOn = updateComment.CreatedOn;
        commentModel.StockId = updateComment.StockId;

        await _context.SaveChangesAsync();
        return Ok(commentModel.ToCommentDto());
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var commentModel = await _context.Comments.FirstOrDefaultAsync(c => c.Id == id);

        if (commentModel is null)
        {
            return NotFound();
        }

        _context.Comments.Remove(commentModel);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}