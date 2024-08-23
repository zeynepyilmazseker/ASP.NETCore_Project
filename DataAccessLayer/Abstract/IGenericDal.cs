using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        void Insert(T item);
        void Delete(T item);
        void Update(T item);
        List<T> GetList();
        T GetById(int id);
        List<T> GetByFilter(Expression<Func<T,bool>>filter);
    }
}


//Func<T, bool> kısmı, bir T türündeki nesne alıp bool döndüren bir fonksiyon olduğunu belirtir.
//Yani, verilen nesne belirli bir koşulu sağlıyorsa true, aksi halde false döner.
//Expression<Func<T, bool>> ise
//bu fonksiyonu bir ifade ağacı (expression tree) olarak paketler.
//Bu sayede, ORM (Object - Relational Mapping) araçları (örneğin, Entity Framework) bu ifadeyi veri tabanına uygun bir SQL sorgusuna çevirebilir.
//List<T> GetByFilter(...):

//Bu metod, T türündeki nesnelerden oluşan bir liste döner.
//Metod, verilen filter ifadesine uyan tüm T nesnelerini veri tabanından çeker ve bir liste halinde geri döner.