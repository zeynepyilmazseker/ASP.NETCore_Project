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
    public class WriterUserManager : IWriterUserService
    {
        IWriterUserDal _writerUserDal;

        public WriterUserManager(IWriterUserDal writerUserDal)
        {
            _writerUserDal = writerUserDal;
        }

        public void TAdd(WriterUser entity)
        {
            _writerUserDal.Insert(entity);
        }

        public void TDelete(WriterUser entity)
        {
            _writerUserDal.Delete(entity);
        }

        public WriterUser TGetById(int id)
        {
            return _writerUserDal.GetById(id);
        }

        public List<WriterUser> TGetList()
        {
            return _writerUserDal.GetList();    
        }

        public List<WriterUser> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(WriterUser entity)
        {
           _writerUserDal.Update(entity);
        }
    }
}
