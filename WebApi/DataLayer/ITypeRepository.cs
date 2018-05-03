using System.Collections.Generic;

namespace DataLayer
{
    public interface ITypeRepository
    {
        List<DataLayer.Models.Type> GetAllTypes();

        int InsertTypes(DataLayer.Models.Type t);

        int UpdateTypes(DataLayer.Models.Type t);

        List<DataLayer.Models.Type> GetAllTypeNames();
    }
}