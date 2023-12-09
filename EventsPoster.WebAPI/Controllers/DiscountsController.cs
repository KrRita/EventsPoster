using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AutoMapper.Configuration;
using EventsPoster.BL.Discounts;
using EventsPoster.BL.Discounts.Entities;
using EventsPoster.Service.Controllers.Entities;

namespace EventsPoster.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountsProvider _discountsProvider;
        private readonly IDiscountsManager _discountsManager;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public DiscountController(IDiscountsProvider discountsProvider, IDiscountsManager discountsManager, IMapper mapper, ILogger logger)
        {
            _discountsManager = discountsManager;
            _discountsProvider = discountsProvider;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet] //discounts/
        public IActionResult GetAllDiscounts()
        {
            var discounts = _discountsProvider.GetDiscounts();
            return Ok(new DiscountsListResponce()
            {
                Discounts = discounts.ToList()
            });
        }

        [HttpGet]
        [Route("filter")] //discounts/filter?filter.Percent=0,3
        public IActionResult GetFilteredDiscounts([FromQuery] DiscountsFilter filter)
        {
            var discounts = _discountsProvider.GetDiscounts(_mapper.Map<DiscountModelFilter>(filter));
            return Ok(new DiscountsListResponce()
            {
                Discounts = discounts.ToList()
            });
        }

        [HttpGet]
        [Route("{id}")] //discounts/{id}
        public IActionResult GetDiscountInfo([FromRoute] Guid id)
        {
            try
            {
                var discount = _discountsProvider.GetDiscountInfo(id);
                return Ok(discount);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString()); //stack trace + message
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateDiscount([FromBody] CreateDiscountRequest request) //automatic validation
        {
            try
            {
                var discount = _discountsManager.CreateDiscount(_mapper.Map<CreateDiscountModel>(request));
                return Ok(discount);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateDiscountInfo([FromRoute] Guid id, UpdateDiscountRequest request)
        {
            //validator for request
            try
            {
                var discount = _discountsManager.UpdateDiscount(id, _mapper.Map<UpdateDiscountModel>(request));
                return Ok(discount);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteDiscount([FromRoute] Guid id)
        {
            try
            {
                _discountsManager.DeleteDiscount(id);
                return Ok();
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(ex.Message);
            }
        }
    }
}
