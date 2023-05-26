using backend2.Models;
using Newtonsoft.Json;

namespace backend2.DataService
{
    public class NoRelationalDataService
    {
        private Context _context;

        public NoRelationalDataService(Context context){
            _context = context;
        }

        private List<NoRelational> Deserialize(string childs)
        {
            return JsonConvert.DeserializeObject<List<NoRelational>>(childs) ?? new List<NoRelational>();
        }

        private string Serialize(List<NoRelational> childs)
        {
            return JsonConvert.SerializeObject(childs) ?? string.Empty;
        }

        // Create a list of relational objects using Breadth-First Search algorithm
        public List<Relational> GetObjects()
        {
            List<Relational> relational_list = new List<Relational>();
            List<NoRelational> noRelational_list = GetNoRelationalObjects();
            var queue = new Queue<(NoRelational obj, long parentId)>();     
            foreach (var noRelational in noRelational_list)
            {
                queue.Enqueue((noRelational, -1));
                while (queue.Count > 0)
                {
                    var (current, parentId) = queue.Dequeue();
                    relational_list.Add(new Relational
                    {
                        Id = current.Id,
                        Name = current.Name,
                        Value = current.Value,
                        ParentId = parentId
                    });
                    
                    if (!string.IsNullOrEmpty(current.Childs))
                    {
                        var nestedChilds = Deserialize(current.Childs);
                        foreach (var nestedChild in nestedChilds)
                        {
                            queue.Enqueue((nestedChild, current.Id));
                        }
                    }
                }
            }
            return relational_list;
        }

        public Relational? GetObject(long id)
        {
            List<Relational> relational_list = GetObjects();
            return relational_list.FirstOrDefault(x => x.Id == id);
        }

        public List<NoRelational> GetNoRelationalObjects()
        {
            return _context.NoRelational.ToList();
        }


        // return the relational object and its parent with the given id
        public (NoRelational?, long) FindObject(long id)
        {
            List<NoRelational> childs = GetNoRelationalObjects();
            return FindObjectInHierarchy(childs, id);
        }

        private (NoRelational?, long) FindObjectInHierarchy(List<NoRelational> childs, long id, long parentID = -1)
        {
            foreach (var child in childs)
            {
                if (child.Id == id)
                {
                    return (child, parentID);
                }
                else if (!string.IsNullOrEmpty(child.Childs))
                {
                    var childList = Deserialize(child.Childs);
                    (NoRelational? obj, long parentId) = FindObjectInHierarchy(childList, id, child.Id);
                    if (obj != null)
                    {
                        return (obj, parentId);
                    }
                }
            }
            return (null, -1);
        }

        public Relational? AddObject(Relational obj)
        {
            NoRelational _obj = new NoRelational
            {
                Id = obj.Id,
                Name = obj.Name,
                Value = obj.Value,
                Childs = string.Empty
            };

            if (obj.ParentId == -1)
            {
                _context.NoRelational.Add(_obj);
                _context.SaveChanges();
                return obj;
            }

            AddObjectToHierarchy(GetNoRelationalObjects(), obj);
            _context.SaveChanges();
            return obj;
        }

        public void AddObjectToHierarchy(List<NoRelational> childs, Relational obj)
        {
            foreach (var child in childs)
            {
                List<NoRelational> childList = Deserialize(child.Childs);
                if (child.Id == obj.ParentId)
                {
                    childList.Add(new NoRelational
                    {
                        Id = obj.Id,
                        Name = obj.Name,
                        Value = obj.Value,
                        Childs = Serialize(new List<NoRelational>())
                    });
                    child.Childs = Serialize(childList);
                    break;
                }
                else if (childList.Count > 0)
                {
                    AddObjectToHierarchy(childList, obj);
                    child.Childs = Serialize(childList);
                }
            }
        }
        
        public NoRelational DeleteObject(long childId, long parentId = -1)
        {
            List<NoRelational> childs = GetNoRelationalObjects();
            var obj = childs.FirstOrDefault(x => x.Id == childId);
            if (obj != null)
            {
                _context.NoRelational.Remove(obj);
            }
            else
            {
                if (parentId == -1)
                {
                    obj = DeleteObjectFromHierarchy(childs, childId);
                }
                else
                {
                    obj = DeleteChildFromHierarchy(childs, childId, parentId);
                }
            }
            _context.SaveChanges();
            return obj;
        }

        public NoRelational DeleteObjectFromHierarchy(List<NoRelational> childs, long id)
        {
            foreach (var child in childs)
            {
                List<NoRelational> childList = Deserialize(child.Childs);
                var removedChild = childList.FirstOrDefault(_child => _child.Id == id);
                if (removedChild != null)
                {
                    childList.Remove(removedChild);
                    child.Childs = Serialize(childList);
                    return removedChild;
                }
                else if (childList.Count > 0)
                {
                    var removedFromChild = DeleteObjectFromHierarchy(childList, id);
                    if (removedFromChild != null)
                    {
                        child.Childs = Serialize(childList);
                        return removedFromChild;
                    }
                }
            }
            return null;
        }

        public NoRelational DeleteChildFromHierarchy(List<NoRelational> childs, long childId, long parentId)
        {
            foreach (var child in childs)
            {
                List<NoRelational> childList = Deserialize(child.Childs);
                if (child.Id == parentId)
                {
                    var removedChild = childList.FirstOrDefault(_child => _child.Id == childId);
                    if (removedChild != null)
                    {
                        childList.Remove(removedChild);
                        child.Childs = Serialize(childList);
                        return removedChild;
                    }
                }
                else if (childList.Count > 0)
                {
                    var removedFromChild = DeleteChildFromHierarchy(childList, childId, parentId);
                    if (removedFromChild != null)
                    {
                        child.Childs = Serialize(childList);
                        return removedFromChild;
                    }
                }
            }
            return null;
        }

        public Relational UpdateObject(Relational obj)
        {
            List<NoRelational> childs = GetNoRelationalObjects();

            if (obj.ParentId == -1)
            {
                NoRelational _obj = childs.FirstOrDefault(x => x.Id == obj.Id);
                if (_obj != null)
                {
                    _obj.Name = obj.Name;
                    _obj.Value = obj.Value;
                }
            }
            else
            {
                (NoRelational? _obj, long parentId) = UpdateObjectInHierarchy(childs, obj);
                if (_obj != null)
                {
                    DeleteObject(_obj.Id, parentId); // Delete previous object
                }
            }
            _context.SaveChanges();
            return obj;
        }

        public (NoRelational, long) UpdateObjectInHierarchy(List<NoRelational> childs, Relational obj)
        {
            foreach (var child in childs)
            {
                List<NoRelational> childList = Deserialize(child.Childs);
                if (child.Id == obj.ParentId)
                {
                    var newChild = new NoRelational
                    {
                        Id = obj.Id,
                        Name = obj.Name,
                        Value = obj.Value,
                        Childs = ""
                    };

                    var existingChild = childList.FirstOrDefault(_child => _child.Id == obj.Id);
                    if (existingChild != null)
                    {
                        newChild.Childs = existingChild.Childs;
                        childList.Add(newChild);
                        child.Childs = Serialize(childList);
                        return (existingChild, child.Id);
                    }
                    else
                    {
                        // Find object in hierarchy and delete it from the previous parent
                        var (found, index) = FindObject(obj.Id);
                        if (found != null)
                        {
                            
                            newChild.Childs = found.Childs;
                            childList.Add(newChild);
                        }
                        child.Childs = Serialize(childList);
                        return (found, index);
                    }
                }
                else if (childList.Count > 0)
                {
                    var (found, index) = UpdateObjectInHierarchy(childList, obj);
                    if (found != null)
                    {
                        child.Childs = Serialize(childList);
                        return (found, index);
                    } 
                }
            }
            return (null, 0);
        }
    }
}