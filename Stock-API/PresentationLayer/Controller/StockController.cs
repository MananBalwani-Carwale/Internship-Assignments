using BusinessAccessLayer.Service;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.DTO;
using DataAccessLayer.Entity;
using AutoMapper;

namespace PresentationLayer.Controller;

/*
This is the controller for the Stocks
*/
[ApiController]
[Route("[controller]")]
public class StockController : ControllerBase
{
    private IStockService _stockService;
    private IMapper _mapper;
    
    public StockController(IStockService stockService, IMapper mapper)
    {
        _stockService = stockService;
        _mapper = mapper;
    }

    /*
    This method returns all the stocks
    */
    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] FilterDTO filterDTO)
    {
        FilterEntity filterEntity = _mapper.Map<FilterDTO, FilterEntity>(filterDTO);
        IEnumerable<StockDTO> stocks;
        //call for service method
        try
        {
            IEnumerable<StockEntity> stockEntities = await _stockService.GetAllService(filterEntity);
            stocks = _mapper.Map<IEnumerable<StockEntity>, IEnumerable<StockDTO>>(stockEntities);
            stocks = stocks.Select(item => 
            {
                item.IsValueForMoney = _stockService.GetIsValueForMoney(item.Kms, item.Price);
                return item;
            }).ToList();
        }
        catch(Exception exception)
        {
            Console.WriteLine(exception);
            return new ObjectResult(new { error = "Internal Server Error", message = exception.Message })
            {
                StatusCode = 500
            };
        }
        return Ok(stocks);
    }

    /*
    This method returns a stock based on the id if exist
    */
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        StockDTO stockDTO;
        try
        {
            StockEntity stockEntity = await _stockService.GetByIdService(id);
            stockDTO = _mapper.Map<StockEntity, StockDTO>(stockEntity);
            stockDTO.IsValueForMoney = _stockService.GetIsValueForMoney(stockDTO.Kms, stockDTO.Price);
        }
        catch(Exception exception)
        {
            Console.WriteLine(exception);
            return new ObjectResult(new { error = "Internal Server Error", message = exception.Message })
            {
                StatusCode = 500
            };
        }
        return Ok(stockDTO);
    }

    /*
    This method adds a stock
    */
    [HttpPost]
    public async Task<IActionResult> AddAsync(CreateStockDTO createStockDTO)
    {
        StockEntity stockEntity = _mapper.Map<CreateStockDTO, StockEntity>(createStockDTO);
        try
        {
            await _stockService.AddService(stockEntity);
        }
        catch(Exception exception)
        {
            Console.WriteLine(exception);
            return new ObjectResult(new { error = "Internal Server Error", message = exception.Message })
            {
                StatusCode = 500
            };
        }
        return NoContent();
    }

    /*
    This method updates an existing stock else returns
    */
    [HttpPut]
    public async Task<IActionResult> UpdateAsync(UpdateStockDTO updateStockDTO)
    {
        StockEntity stockEntity = _mapper.Map<UpdateStockDTO, StockEntity>(updateStockDTO);
        try
        {
            StockEntity stock = await _stockService.GetByIdService(stockEntity.Id);
            if(stock == null)
            {
                throw new Exception("Cannot find stock");
            }
            await _stockService.UpdateService(stockEntity);
        }
        catch(Exception exception)
        {
            Console.WriteLine(exception);
            if(exception.Message.Equals("Cannot find stock"))
            {
                return new ObjectResult(new { error = "Internal Server Error", message = exception.Message })
                {
                    StatusCode = 404
                };
            }
            return new ObjectResult(new { error = "Internal Server Error", message = exception.Message })
            {
                StatusCode = 500
            };
        }
        return NoContent();
    }

    /*
    This method deletes the existing stock else returns
    */
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        StockEntity stock = await _stockService.GetByIdService(id);
        if(stock == null)
            return NotFound();
        try
        {
            await _stockService.DeleteService(id);
        }
        catch(Exception exception)
        {
            Console.WriteLine(exception);
            if(exception.Message.Equals("Cannot find stock"))
            {
                return new ObjectResult(new { error = "Internal Server Error", message = exception.Message })
                {
                    StatusCode = 404
                };
            }
            return new ObjectResult(new { error = "Internal Server Error", message = exception.Message })
            {
                StatusCode = 500
            };
        }
        return NoContent();
    }
}