using API.Data;
using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace API.Repository;

public class PortfolioRepository : IPortfolioRepository
{
    private readonly AppDbContext _context;
    public PortfolioRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<Stock>> GetUserPortfolio(AppUser appUser)
    {
        return await _context.Portfolios.Where(p => p.AppUserId == appUser.Id)
            .Select(stock => new Stock
            {
                Id = stock.StockId,
                Symbol = stock.Stock.Symbol,
                CompanyName = stock.Stock.CompanyName,
                Purchase = stock.Stock.Purchase,
                LastDiv = stock.Stock.LastDiv,
                Industry = stock.Stock.Industry,
                MarketCap = stock.Stock.MarketCap
            }).ToListAsync();
    }

    public async Task<Portfolio> CreatePortfolio(Portfolio portfolio)
    {
        await _context.Portfolios.AddAsync(portfolio);
        await _context.SaveChangesAsync();
        return portfolio;
    }
}