using Microsoft.AspNetCore.Mvc;
using backend2.BusinessService;
using backend2.Models;

namespace backend2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoRelationalController: ControllerBase
    {
        private NoRelationalBusinessService _noRelationalBusinessService;

        public NoRelationalController(NoRelationalBusinessService noRelationalBusinessService)
        {
            _noRelationalBusinessService = noRelationalBusinessService;
        }

        [HttpGet("[action]")]
        public List<Relational> GetObjects()
        {
            return _noRelationalBusinessService.GetObjects();
        }

        [HttpGet("[action]")]
        public List<NoRelational> GetNoRelationalObjects()
        {
            return _noRelationalBusinessService.GetNoRelationalObjects();
        }

        [HttpGet("[action]/{id}")]
        public Relational? GetObject(long id)
        {
            return _noRelationalBusinessService.GetObject(id);
        }


        [HttpPost("[action]")]
        public Relational AddObject(Relational obj)
        {
            return _noRelationalBusinessService.AddObject(obj);
        }

        [HttpPut("[action]")]
        public Relational UpdateObject(Relational obj)
        {
            return _noRelationalBusinessService.UpdateObject(obj);
        }

        [HttpDelete("[action]/{id}")]
        public void DeleteObject(long id)
        {
            _noRelationalBusinessService.DeleteObject(id);
        }
        
    }
}