using Microsoft.AspNetCore.Mvc;
using WiseBank.Src.Entities;

namespace WiseBank.Src.Controllers;

[ApiController]
[Route("[controller]")]
public class BankAccountController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<WeatherForecast>> CreateAsync()
    {
        await Task.FromResult("");
        return CreatedAtAction("GetById", new { id = 1 }, new WeatherForecast());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<WeatherForecast>> GetByIdAsync([FromRoute] int id)
    {
        await Task.FromResult("");
        return Ok(new WeatherForecast());
    }

    [HttpPost("{id}/Deposit")]
    public async Task<ActionResult<WeatherForecast>> DepositAsync([FromRoute] int id)
    {
        await Task.FromResult("");
        return CreatedAtAction("GetById", new { id = 1 }, new WeatherForecast());
    }

    [HttpPost("{id}/Withdraw")]
    public async Task<ActionResult> WithdrawAsync([FromRoute] int id)
    {
        await Task.FromResult("");
        return CreatedAtAction("GetById", new { id = 1 }, new WeatherForecast());
    }

    [HttpPost("{id}/Transfer")]
    public async Task<ActionResult> TransferAsync([FromRoute] int id)
    {
        await Task.FromResult("");
        return CreatedAtAction("GetById", new { id = 1 }, new WeatherForecast());
    }
}