using Microsoft.AspNetCore.Mvc;
using Million.RealEstate.Application;
using Million.RealEstate.Domain;

namespace Million.RealEstate.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OwnersController : ControllerBase
{
    private readonly IOwnerRepository _repo;
    public OwnersController(IOwnerRepository repo) => _repo = repo;

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        var owners = await _repo.GetAllAsync(ct);
        return Ok(owners);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id, CancellationToken ct)
    {
        var owner = await _repo.GetByIdAsync(id, ct);
        if (owner == null) return NotFound();
        return Ok(owner);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Owner owner, CancellationToken ct)
    {
        var created = await _repo.AddAsync(owner, ct);
        return CreatedAtAction(nameof(GetById), new { id = created.IdOwner }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] Owner owner, CancellationToken ct)
    {
        if (id != owner.IdOwner) return BadRequest("ID mismatch");
        await _repo.UpdateAsync(owner, ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id, CancellationToken ct)
    {
        await _repo.DeleteAsync(id, ct);
        return NoContent();
    }
}
