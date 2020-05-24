using TenantApplicationCRUD.API.Entities;
using TenantApplicationCRUD.API.ResourceParameters;
using System;
using System.Collections.Generic;


namespace TenantApplicationCRUD.API.Services
{
    public interface ITenantApplicationCRUDRepository
    {
        IEnumerable<TenantPersonnel> GetTenantPersonnels(Guid genderId);
        TenantPersonnel GetTenantPersonnel(Guid genderId, Guid tenantPersonnelId);
        void AddTenantPersonnel(Guid genderId, TenantPersonnel tenantPersonnelId);
        void UpdateTenantPersonnel(TenantPersonnel tenantPersonnel);
        void DeleteTenantPersonnel(TenantPersonnel tenantPersonnel);
        IEnumerable<Gender> GetGenders();
        IEnumerable<Gender> GetGenders(GendersResourceParameters gendersResourceParameters);
        Gender GetGender(Guid genderId);
        IEnumerable<Gender> GetGenders(IEnumerable<Guid> genderIds);
        void AddGender(Gender gender);
        void DeleteGender(Gender gender);
        void UpdateGender(Gender gender);
        bool GenderExists(Guid genderId);
        bool Save();
    }
}
