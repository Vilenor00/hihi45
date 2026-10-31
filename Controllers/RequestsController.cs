using hihi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hihi.Controllers
{
            [ApiController]
            [Route("api/[controller]")]
            public class RequestsController : ControllerBase
        {
            private readonly AppDbContext _context;

            public RequestsController(AppDbContext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<IActionResult> GetRequests(
                [FromQuery] string? format = null,
                [FromQuery] bool simulateError = false)
            {
                try
                {
                    if (!string.IsNullOrEmpty(format) && format.ToLower() != "json")
                    {
                        return BadRequest(new { error = $"Формат '{format}' не поддерживается. Используйте json." });
                    }
                    if (simulateError)
                    {
                        throw new Exception("Симуляция внутренней ошибки сервера по запросу.");
                    }
                    bool canConnect = await _context.Database.CanConnectAsync();
                    if (!canConnect)
                    {
                        return StatusCode(500, new { error = "Ошибка подключения к базе данных." });
                    }
                    var result = _context.Requests
                        .Join(
                            _context.Clients,
                            r => r.IdClient,
                            c => c.Id,
                            (r, c) => new
                            {
                                id = r.Id,
                                title_client = $"{r.Title} - {c.Login}",
                                content = r.Content,
                                formatted_date = r.CreatedAt.ToString("dd.MM.yyyy")
                            }
                        )
                        .ToList();
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new { error = "Внутренняя ошибка сервера", details = ex.Message });
                }
            }
        }
    }