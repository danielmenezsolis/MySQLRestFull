using Microsoft.AspNetCore.Mvc;
using RestFull.DataConnec;
using RestFull.Model;
using System.Net;

namespace RestFull.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public List<Usuarios> Get()
        {
            UserData use = new UserData();
            return use.Listar();
        }

        [HttpGet("{id}")]
        public List<Usuarios> Get(int id)
        {
            UserData use = new UserData();
            return use.Listar(id);
        }

        [HttpPost]
        public void Post(Usuarios usuario)
        {
            UserData use = new UserData();
            use.Insertar(usuario);
        }
        [HttpPut]
        public void Put(Usuarios usuario)
        {
            UserData use = new UserData();
            use.Actualizar(usuario);
        }

    }
}
