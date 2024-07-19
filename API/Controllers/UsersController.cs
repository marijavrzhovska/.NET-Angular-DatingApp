using Microsoft.AspNetCore.Mvc;
using API.Entities;
using API.Data;
using Microsoft.EntityFrameworkCore;

namespace API;
[ApiController]
[Route("api/[Controller]")] // /api/users
public class UsersController(DataContext context) : ControllerBase{
    //endpoints
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers(){
        var users = await context.Users.ToListAsync();
        return users;
    }

    [HttpGet("{id:int}")] // /api/users/id
    public async Task<ActionResult<AppUser>> GetUser(int id){
        var user = await context.Users.FindAsync(id);
        if(user == null) return NotFound();
        return user;
    }
}
