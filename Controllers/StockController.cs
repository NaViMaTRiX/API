namespace API.Controllers;

using DTOs;
using DTOs.Stock;
using Helper;
using Interfaces;
using Mappers;
using Microsoft.AspNetCore.Mvc;

[Route("api/v1/stock")]
public class StockController : ControllerBase
{
    private readonly IStockRepository _stockRepository;
    public StockController(IStockRepository stockRepository)
    {
        _stockRepository = stockRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var stocks = await _stockRepository.GetAllAsync(query);
        var stockDto = stocks.Select(s => s.ToStockDto());
        
        return Ok(stockDto);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var stock = await _stockRepository.GetByIdAsync(id);

        if (stock is null)
        {
            return NotFound("Stock not exist!");
        }

        return Ok(stock.ToStockDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var stockModel = stockDto.ToStockFromCreateDTO();
        
        await _stockRepository.CreateAsync(stockModel);
        
        return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDto());
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStockRequestDto updateStock)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var stockModel = await _stockRepository.UpdateAsync(id, updateStock);

        if (stockModel is null)
        {
            return NotFound("Stock not exist!");
        }
        
        return Ok(stockModel.ToStockDto());
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var stockModel = await _stockRepository.DeleteAsync(id);

        if (stockModel is null)
        {
            return NotFound("Stock is not exist!");
        }
        return NoContent();
    }
}