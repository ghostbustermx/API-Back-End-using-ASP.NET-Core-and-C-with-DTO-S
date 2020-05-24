using TenantApplicationCRUD.API.DbContexts;
using TenantApplicationCRUD.API.Entities;
using TenantApplicationCRUD.API.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenantApplicationCRUD.API.Services
{
    public class TenantApplicationCRUDRepository : ITenantApplicationCRUDRepository, IDisposable
    {
        private readonly DbContexto _context;

        public TenantApplicationCRUDRepository(DbContexto context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddTenantPersonnel(Guid genderId, TenantPersonnel tenantPersonnel)
        {
            if (genderId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(genderId));
            }

            if (tenantPersonnel == null)
            {
                throw new ArgumentNullException(nameof(tenantPersonnel));
            }

            tenantPersonnel.GenderId = genderId;
            _context.TenantPersonnels.Add(tenantPersonnel);
        }

        public void DeleteTenantPersonnel(TenantPersonnel tenantPersonnel)
        {
            _context.TenantPersonnels.Remove(tenantPersonnel);
        }

        public TenantPersonnel GetTenantPersonnel(Guid genderId, Guid tenantPersonnelId)
        {
            if (genderId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(genderId));
            }

            if (tenantPersonnelId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(tenantPersonnelId));
            }

            return _context.TenantPersonnels
              .Where(c => c.GenderId == genderId && c.Id == tenantPersonnelId).FirstOrDefault();
        }
        public IEnumerable<TenantPersonnel> GetTenantPersonnels(Guid genderId)
        {
            if (genderId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(genderId));
            }

            return _context.TenantPersonnels
                        .Where(c => c.GenderId == genderId)
                        .OrderBy(c => c.LastName).ToList();
        }
        public void UpdateTenantPersonnel(TenantPersonnel tenantPersonnel)
        {
            // no code in this implementation
        }

        public void AddGender(Gender gender)
        {
            if (gender == null)
            {
                throw new ArgumentNullException(nameof(gender));
            }

            // the repository fills the id (instead of using identity columns)
            gender.Id = Guid.NewGuid();

            foreach (var tenantPersonnel in gender.TenantPersonnels)
            {
                tenantPersonnel.Id = Guid.NewGuid();
            }

            _context.Genders.Add(gender);
        }

        public bool GenderExists(Guid genderId)
        {
            if (genderId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(genderId));
            }

            return _context.Genders.Any(a => a.Id == genderId);
        }

        public void DeleteGender(Gender gender)
        {
            if (gender == null)
            {
                throw new ArgumentNullException(nameof(gender));
            }

            _context.Genders.Remove(gender);
        }

        public Gender GetGender(Guid genderId)
        {
            if (genderId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(genderId));
            }

            return _context.Genders.FirstOrDefault(a => a.Id == genderId);
        }

        public IEnumerable<Gender> GetGenders()
        {
            return _context.Genders.ToList<Gender>();
        }

        public IEnumerable<Gender> GetGenders(GendersResourceParameters gendersResourceParameters)
        {
            if (gendersResourceParameters == null)
            {
                throw new ArgumentNullException(nameof(gendersResourceParameters));
            }

            if (string.IsNullOrWhiteSpace(gendersResourceParameters.MainCategory)
                && string.IsNullOrWhiteSpace(gendersResourceParameters.SearchQuery))
            {
                return GetGenders();
            }

            var collection = _context.Genders as IQueryable<Gender>;

            if (!string.IsNullOrWhiteSpace(gendersResourceParameters.MainCategory))
            {
                var mainCategory = gendersResourceParameters.MainCategory.Trim();
                collection = collection.Where(a => a.Name == mainCategory);
            }

            if (!string.IsNullOrWhiteSpace(gendersResourceParameters.SearchQuery))
            {
                var searchQuery = gendersResourceParameters.SearchQuery.Trim();
                collection = collection.Where(a => a.Name.Contains(searchQuery)
                    || a.Name.Contains(searchQuery));
            }

            return collection.ToList();
        }

        public IEnumerable<Gender> GetGenders(IEnumerable<Guid> genderIds)
        {
            if (genderIds == null)
            {
                throw new ArgumentNullException(nameof(genderIds));
            }

            return _context.Genders.Where(a => genderIds.Contains(a.Id))
                .OrderBy(a => a.Name)
                .ToList();
        }

        public void UpdateGender(Gender gender)
        {
            // no code in this implementation
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }
    }
}
