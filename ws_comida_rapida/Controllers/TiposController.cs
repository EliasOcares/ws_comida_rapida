using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ws_comida_rapida.Models;
using ws_comida_rapida.Models.ViewModel;

namespace ws_comida_rapida.Controllers
{
    public class TiposController : ApiController
    {
        bd_comida_rapidaEntities bd = new bd_comida_rapidaEntities();
        public IEnumerable<TipoViewModel> Get()
        {
            // LINQ - Sintaxis Integrada
            IEnumerable<TipoViewModel> tipos = (from tipo in bd.Tipos
                                                select new TipoViewModel()
                                                {
                                                    id = tipo.id,
                                                    nombre = tipo.nombre
                                                }).ToList();
            return tipos;
        }
    }
}
