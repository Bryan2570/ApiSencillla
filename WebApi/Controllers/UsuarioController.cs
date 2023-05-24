using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.data;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class UsuarioController : ApiController
    {
        // GET: api/Usuario
        public List<Usuario> Get()
        {
            return UsuarioData.Listar();        
        }

        //obtenemos un usuario en especifico
        public Usuario Get(int id)
        {
            return UsuarioData.Obtener(id);
        }


        // POST: api/Usuario
        public bool Post([FromBody]Usuario oUsuario)
        {
            return UsuarioData.Registrar(oUsuario);
        }

        // PUT: api/Usuario/5
        public bool Put([FromBody]Usuario oUsuario)
        {
            return UsuarioData.Modificar(oUsuario);
        }

        // DELETE: api/Usuario/5
        public bool Delete(int id)
        {
            return UsuarioData.Eliminar(id);
        }
    }
}
