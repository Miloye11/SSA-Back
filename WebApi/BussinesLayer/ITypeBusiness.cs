using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer
{
    public interface ITypeBusiness
    {
        List<DataLayer.Models.Type> GetAllTypes();

        bool InsertTypes(DataLayer.Models.Type t);

        bool UpdateTypes(DataLayer.Models.Type t);
    }
}
