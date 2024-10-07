using System;
using Microsoft.AspNetCore;
using GameMovie.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameMovie.Entities;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly MyFirstDbContext _context;

    public TestController(MyFirstDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<Movie>> AddMovie([FromBody] Movie movie)
    {
        if (movie == null)
        {
            return BadRequest("Movie cannot be null.");
        }

        _context.Movies.Add(movie);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAll), new { id = movie.Id }, movie);
    }
    [HttpGet]
    public async Task<ActionResult<List<Movie>>> GetAll()
    {
        var movies = await _context.Movies.ToListAsync();
        return Ok(movies);
    }
}


