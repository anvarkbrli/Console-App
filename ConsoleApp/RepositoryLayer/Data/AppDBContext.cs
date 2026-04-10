using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Data
{
    public class AppDBContext<T>
    {
        public static List<T> datas;
        static AppDBContext()
        {
            datas = new List<T>();
        }
    }
}
