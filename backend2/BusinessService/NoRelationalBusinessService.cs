using backend2.DataService;
using backend2.Models;

namespace backend2.BusinessService
{
    public class NoRelationalBusinessService
    {
        private NoRelationalDataService _noRelationalDataService;

        public NoRelationalBusinessService(NoRelationalDataService noRelationalDataService)
        {
            _noRelationalDataService = noRelationalDataService;
        }

        public List<Relational> GetObjects()
        {
            return _noRelationalDataService.GetObjects();
        }

        public List<NoRelational> GetNoRelationalObjects()
        {
            return _noRelationalDataService.GetNoRelationalObjects();
        }

        public Relational? GetObject(long id)
        {
            return _noRelationalDataService.GetObject(id);
        }

        public Relational? AddObject(Relational obj)
        {
            return _noRelationalDataService.AddObject(obj);
        }

        public Relational? UpdateObject(Relational obj)
        {
            return _noRelationalDataService.UpdateObject(obj);
        }

        public void DeleteObject(long id)
        {
            _noRelationalDataService.DeleteObject(id);
        }
    }
}