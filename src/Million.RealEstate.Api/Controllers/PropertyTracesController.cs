using Microsoft.AspNetCore.Mvc;
using Million.RealEstate.Application;
using Million.RealEstate.Domain;

namespace Million.RealEstate.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PropertyTracesController : ControllerBase
{
    private readonly IPropertyTraceRepository _repo;
    public PropertyTracesController(IPropertyTraceRepository repo) => _repo = repo;

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id, CancellationToken ct)
    {
        var trace = await _repo.GetByIdAsync(id, ct);
        if (trace == null) return NotFound();
        return Ok(trace);
    }

    [HttpGet("by-property/{propertyId}")]
    public async Task<IActionResult> GetByProperty(string propertyId, CancellationToken ct)
    {
        var traces = await _repo.GetByPropertyAsync(propertyId, ct);
        return Ok(traces);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PropertyTrace trace, CancellationToken ct)
    {
        var created = await _repo.AddAsync(trace, ct);
        return CreatedAtAction(nameof(GetById), new { id = created.IdPropertyTrace }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] PropertyTrace trace, CancellationToken ct)
    {
        if (id != trace.IdPropertyTrace) return BadRequest("ID mismatch");
        await _repo.UpdateAsync(trace, ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        await _repo.DeleteAsync(id, ct);
        return NoContent();
    }
}
