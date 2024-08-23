using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ToDoListManager : IToDoListService
    {
        IToDoListDal _toDoListDal;
        public ToDoListManager(IToDoListDal toDoListDal)
        {
            _toDoListDal = toDoListDal;
        }
        public void TAdd(ToDoList entity)
        {
            _toDoListDal.Insert(entity);
        }

        public void TDelete(ToDoList entity)
        {
            _toDoListDal.Delete(entity);
        }

        public ToDoList TGetById(int id)
        {
            return _toDoListDal.GetById(id);
        }

        public List<ToDoList> TGetList()
        {
            return _toDoListDal.GetList();
        }

        public List<ToDoList> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(ToDoList entity)
        {
           _toDoListDal.Update(entity);
        }
    }
}
