namespace API.Repository;

using Data;
using DTOs;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using Models;

public class CommentRepository : ICommentRepository
{
    private readonly AppDbContext _context;
    public CommentRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<Comment>> GetAllAsync()
    {
        return await _context.Comments.ToListAsync();
    }

    public async Task<Comment?> GetByIdAsync(int id)
    {
        return await _context.Comments.FindAsync(id);
    }

    public async Task<Comment> CreateAsync(Comment commentModel)
    {
        await _context.Comments.AddAsync(commentModel);
        await _context.SaveChangesAsync();
        return commentModel;
    }

    public async Task<Comment?> UpdateAsync(int id, Comment commentModel)
    {
        var existsComment = await _context.Comments.FindAsync(id);

        if (existsComment is null)
        {
            return null;
        }

        existsComment.Title = commentModel.Title;
        existsComment.Content = commentModel.Content;
        existsComment.CreatedOn = commentModel.CreatedOn;
        existsComment.StockId = commentModel.StockId;

        await _context.SaveChangesAsync();
        return existsComment;
    }

    public async Task<Comment?> DeleteAsync(int id)
    {
        var existsComment = await _context.Comments.FindAsync(id);

        if (existsComment is null)
        {
            return null;
        }

        _context.Comments.Remove(existsComment);
        await _context.SaveChangesAsync();
        return existsComment;
    }
}