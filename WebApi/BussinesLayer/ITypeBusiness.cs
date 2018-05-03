using System.Collections.Generic;

namespace BussinesLayer
{
    public interface ITypeBusiness
    {
        List<DataLayer.Models.Type> GetAllTypes();

        bool InsertTypes(DataLayer.Models.Type t);

        bool UpdateTypes(DataLayer.Models.Type t);

        List<DataLayer.Models.Type> GetAllTypeNames();
    }
}