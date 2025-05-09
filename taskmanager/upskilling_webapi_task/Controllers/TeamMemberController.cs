using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using upskilling_webapi_task.Models;

namespace upskilling_webapi_task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamMemberController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        
        public TeamMemberController(ApplicationDbContext context)
        {
            _context = context;   
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TeamMember>>> GetTeamMembers()
        {
            
            return await _context.TeamMembers.ToListAsync();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<TeamMember>> GetTeamMember(int id)
        {
            
            var teamMember = await _context.TeamMembers.FindAsync(id);

            if (teamMember == null)
            {
                
                return NotFound();
            }

            return teamMember;
        }

        
        [HttpPost]
        public async Task<ActionResult<TeamMember>> CreateTeamMember(TeamMember teamMember)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TeamMembers.Add(teamMember);
            await _context.SaveChangesAsync();

            
            return CreatedAtAction(nameof(GetTeamMember), new { id = teamMember.MemberId }, teamMember);
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeamMember(int id, TeamMember teamMember)
        {
            if (id != teamMember.MemberId)
            {
                
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                
                return BadRequest(ModelState);
            }

            _context.Entry(teamMember).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamMemberExists(id))
                {
                    
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeamMember(int id)
        {
            
            var teamMember = await _context.TeamMembers.FindAsync(id);
            if (teamMember == null)
            {
                
                return NotFound();
            }

            _context.TeamMembers.Remove(teamMember);
            await _context.SaveChangesAsync();
            

            return NoContent();
        }

        private bool TeamMemberExists(int id)
        {
            return _context.TeamMembers.Any(e => e.MemberId == id);
        }
    }
} 