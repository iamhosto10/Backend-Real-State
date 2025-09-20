using Microsoft.AspNetCore.Mvc;
using Million.RealEstate.Application;
using Million.RealEstate.Domain;

namespace Million.RealEstate.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PropertyImagesController : ControllerBase
{
    private readonly IPropertyImageRepository _repo;
    public PropertyImagesController(IPropertyImageRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        var properties = await _repo.GetAllAsync(ct);
        return Ok(properties);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id, CancellationToken ct)
    {
        var image = await _repo.GetByIdAsync(id, ct);
        if (image == null) return NotFound();
        return Ok(image);
    }

    [HttpGet("by-property/{propertyId}")]
    public async Task<IActionResult> GetByProperty(string propertyId, CancellationToken ct)
    {
        var images = await _repo.GetByPropertyAsync(propertyId, ct);
        return Ok(images);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] PropertyImage image, CancellationToken ct)
    {
        var created = await _repo.AddAsync(image, ct);
        return CreatedAtAction(nameof(GetById), new { id = created.IdPropertyImage }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] PropertyImage image, CancellationToken ct)
    {
        if (id != image.IdPropertyImage) return BadRequest("ID mismatch");
        await _repo.UpdateAsync(image, ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        await _repo.DeleteAsync(id, ct);
        return NoContent();
    }
}
