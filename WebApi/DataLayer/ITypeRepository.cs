using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface ITypeRepository
    {
        List<DataLayer.Models.Type> GetAllTypes();

        int InsertTypes(DataLayer.Models.Type t);

        int UpdateTypes(DataLayer.Models.Type t);
    }
}
