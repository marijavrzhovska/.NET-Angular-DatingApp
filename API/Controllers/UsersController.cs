using Microsoft.AspNetCore.Mvc;
using API.Entities;
using API.Data;

namespace API;
[ApiController]
[Route("api/[Controller]")] // /api/users
public class UsersController(DataContext context) : ControllerBase{
    //endpoints
    [HttpGet]
    public ActionResult<IEnumerable<AppUser>> GetUsers(){
        var users = context.Users.ToList();
        return users;
    }

    [HttpGet("{id:int}")] // /api/users/id
    public ActionResult<AppUser> GetUser(int id){
        var user = context.Users.Find(id);
        if(user == null) return NotFound();
        return user;
    }
}
