using DataLayer;
using System.Collections.Generic;

namespace BussinesLayer
{
    public class TypeBusiness : ITypeBusiness
    {
        private ITypeRepository typeRepository;

        public TypeBusiness(ITypeRepository typeRepository)
        {
            // inicijalizacija repozitorijuma "ubrizgavanjem" kroz konstruktor
            this.typeRepository = typeRepository;
        }

        // metoda koja vraća listu svih tipova ako ih uopšte ima u bazi
        public List<DataLayer.Models.Type> GetAllTypes()
        {
            List<DataLayer.Models.Type> types = this.typeRepository.GetAllTypes();
            if (types.Count > 0)
            {
                return types;
            }
            else
            {
                return null;
            }
        }

        //Metoda koja vraca imena svih tipova ako ih ima u bazi
        public List<DataLayer.Models.Type> GetAllTypeNames()
        {
            List<DataLayer.Models.Type> types = this.typeRepository.GetAllTypeNames();
            if (types.Count > 0)
            {
                return types;
            }
            else
            {
                return null;
            }
        }

        //metoda koja ubacuje podatke u tabelu tipova
        public bool InsertTypes(DataLayer.Models.Type t)
        {
            if (this.typeRepository.InsertTypes(t) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //metoda koja vrsi update tabele tipova
        public bool UpdateTypes(DataLayer.Models.Type t)
        {
            bool result = false;
            if (t.Type_Id != 0 && this.typeRepository.UpdateTypes(t) > 0)
            {
                result = true;
            }
            return result;
        }
    }
}