using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Infrastructure;
using WebLesson1.DTOs;
using WebLesson1.Models;

namespace WebLesson1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PCsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PCsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetPCs()
        {
            var PCs = await _context.PCs
                .Select(p => new PCResponseDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Stock = p.Stock,
                }).ToListAsync();
            return Ok(PCs);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPC(int id)
        {
            var pc = await _context.PCs
                .Where(p => p.Id == id)
                .Select(p => new PCResponseDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Stock = p.Stock,
                    ComponentNames = p.PCComponents.Select(PCcomp => PCcomp.Component.Name).ToList(),
                }).FirstOrDefaultAsync();
            if (pc == null) { return NotFound(); }
            return Ok(pc);
        }
        [HttpGet("{id}/components")]
        public async Task<IActionResult> GetPCComponents(int id)
        {
            var pc = await _context.PCs.FindAsync(id);
            if (pc == null) return NotFound(pc);
            var components = await _context.PCComponents
                .Where(pc => pc.PCId == id)
                .Select(pc => new PCComponentDTO
                {
                    Code = pc.ComponentCode,
                    Name = pc.Component.Name,
                    Description = pc.Component.Description,
                    Amount = pc.Amount
                }).ToListAsync();   
            return Ok(components);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePC(PCCreateDTO pc)
        {
            var newPc = new PC
            {
                Name = pc.Name,
                Weight = pc.Weight,
                Warranty = pc.Warranty,
                Stock = pc.Stock,
            };
            _context.PCs.Add(newPc);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPC), new {id = newPc.Id}, newPc);
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePC(int id, PCUpdateDTO newPc)
        {
            var pc = await _context.PCs.FindAsync(id);
            if (pc == null) return NotFound("No such pc");
            pc.Name = newPc.Name;
            pc.Weight = newPc.Weight;
            pc.Warranty = newPc.Warranty;
            pc.Stock = newPc.Stock;
            await _context.SaveChangesAsync();
            return Ok(pc);
        }
        [HttpDelete("{int:id}")]
        public async Task<IActionResult> DeletePC(int id)
        {
            var pc = await _context.PCs.FindAsync(id);
            if (pc == null) return NotFound("No such pc");
            _context.PCs.Remove(pc);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
