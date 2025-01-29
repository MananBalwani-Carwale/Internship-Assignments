using BusinessAccessLayer.Service;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.DTO;
using DataAccessLayer.Entity;
using AutoMapper;
namespace PresentationLayer.Controller
{
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
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] FilterDTO filterDTO)
        {
            FilterEntity filterEntity = _mapper.Map<FilterDTO, FilterEntity>(filterDTO);
            //call for service method
            IEnumerable<StockEntity> stockEntities = await _stockService.GetAllService(filterEntity);
            IEnumerable<StockDTO> stocks = _mapper.Map<IEnumerable<StockEntity>, IEnumerable<StockDTO>>(stockEntities);
            stocks = stocks.Select(item => 
            {
                item.IsValueForMoney = _stockService.GetIsValueForMoney(item.Kms, item.Price);
                return item;
            }).ToList();
            return Ok(stocks);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            StockEntity stockEntity = await _stockService.GetByIdService(id);
            if(stockEntity == null)
                return NotFound();
            StockDTO stockDTO = _mapper.Map<StockEntity, StockDTO>(stockEntity);
            stockDTO.IsValueForMoney = _stockService.GetIsValueForMoney(stockDTO.Kms, stockDTO.Price);
            return Ok(stockDTO);
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateStockDTO createStockDTO)
        {
            StockEntity stockEntity = _mapper.Map<CreateStockDTO, StockEntity>(createStockDTO);
            await _stockService.AddService(stockEntity);
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateStockDTO updateStockDTO)
        {
            StockEntity stock = await _stockService.GetByIdService(updateStockDTO.Id);
            if(stock == null)
                return NotFound();
            StockEntity stockEntity = _mapper.Map<UpdateStockDTO, StockEntity>(updateStockDTO);
            await _stockService.UpdateService(stockEntity);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            StockEntity stock = await _stockService.GetByIdService(id);
            if(stock == null)
                return NotFound();
            await _stockService.DeleteService(id);
            return NoContent();
        }
    }
}