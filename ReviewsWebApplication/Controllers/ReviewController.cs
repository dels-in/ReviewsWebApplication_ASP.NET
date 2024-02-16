using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Review.Domain.Services;
using ReviewsWebApplication.Models;

namespace ReviewsWebApplication.Controllers;

[ApiController]
[Route("[controller]")]
public class ReviewController : ControllerBase
{
    private readonly ILogger<ReviewController> _logger;
    private readonly IReviewService _reviewService;
    private readonly IMapper _mapper;

    public ReviewController(ILogger<ReviewController> logger, IReviewService reviewService, IMapper mapper)
    {
        _logger = logger;
        _reviewService = reviewService;
        _mapper = mapper;
    }

    /// <summary>
    /// ��������� ���� ������� �� ��������
    /// </summary>
    /// <returns></returns>
    [HttpGet("TryGetAll")]
    public async Task<ActionResult<List<ReviewViewModel>>> TryGetAllAsync()
    {
        try
        {
            var result = await _reviewService.GetAllAsync();
            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message, e);
            return BadRequest(new { Error = e.Message });
        }
    }

    /// <summary>
    /// ��������� ������
    /// </summary>
    /// <returns></returns>
    [HttpGet("TryGetByProductId")]
    public async Task<ActionResult<List<ReviewViewModel>>> TryGetByProductIdAsync(int productId)
    {
        try
        {
            var result = await _reviewService.GetByProductIdAsync(productId);
            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message, e);
            return BadRequest(new { Error = e.Message });
        }
    }

    /// <summary>
    /// Add review 
    /// </summary>
    /// <returns></returns>
    [HttpPost("TryAdd")]
    public async Task<ActionResult<List<ReviewViewModel>>> TryAddAsync(AddReviewViewModel newReviewViewModel)
    {
        try
        {
            var newReview = _mapper.Map<AddReview>(newReviewViewModel);
            var result = await _reviewService.TryAddAsync(newReview);
            if (result)
                return Ok();
            return BadRequest(result);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message, e);
            return BadRequest(new { Error = e.Message });
        }
    }

    /// <summary>
    /// �������� ������ �� id
    /// </summary>
    /// <returns></returns>
    [Authorize]
    [HttpDelete("TryDelete")]
    public async Task<ActionResult<List<ReviewViewModel>>> TryDeleteAsync(int id)
    {
        try
        {
            var result = await _reviewService.TryDeleteAsync(id);
            if (result)
                return Ok();
            return BadRequest(result);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message, e);
            return BadRequest(new { Error = e.Message });
        }
    }
}