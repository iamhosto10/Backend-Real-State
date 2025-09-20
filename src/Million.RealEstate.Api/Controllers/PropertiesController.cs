using Microsoft.AspNetCore.Mvc;
using Million.RealEstate.Application;
using Million.RealEstate.Domain;

namespace Million.RealEstate.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PropertiesController : ControllerBase
{
    private readonly IPropertyRepository _repo;
    public PropertiesController(IPropertyRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        var properties = await _repo.GetAllAsync(ct);
        return Ok(properties);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id, CancellationToken ct)
    {
        var property = await _repo.GetByIdAsync(id, ct);
        if (property == null) return NotFound();
        return Ok(property);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Property property, CancellationToken ct)
    {
        var created = await _repo.AddAsync(property, ct);
        return CreatedAtAction(nameof(GetById), new { id = created.IdProperty }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] Property property, CancellationToken ct)
    {
        if (id != property.IdProperty) return BadRequest("ID mismatch");
        await _repo.UpdateAsync(property, ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        await _repo.DeleteAsync(id, ct);
        return NoContent();
    }

    [HttpGet("by-owner/{ownerID}")]
    public async Task<IActionResult> GetByProperty(string ownerId, CancellationToken ct)
    {
        var properties = await _repo.GetByOwnerAsync(ownerId, ct);
        return Ok(properties);
    }

}
