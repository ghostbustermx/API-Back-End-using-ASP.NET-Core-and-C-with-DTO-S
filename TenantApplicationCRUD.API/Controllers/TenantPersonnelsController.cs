using AutoMapper;
using TenantApplicationCRUD.API.Models;
using TenantApplicationCRUD.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenantApplicationCRUD.API.Controllers
{
    [ApiController]
    [Route("api/genders/{genderId}/tenantPersonnel")]
    public class TenantPersonnelsController : ControllerBase
    {
        private readonly ITenantApplicationCRUDRepository _tenantApplicationCRUDRepository;
        private readonly IMapper _mapper;

        public TenantPersonnelsController(ITenantApplicationCRUDRepository tenantApplicationCRUDRepository,
            IMapper mapper)
        {
            _tenantApplicationCRUDRepository = tenantApplicationCRUDRepository ??
                throw new ArgumentNullException(nameof(tenantApplicationCRUDRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public ActionResult<IEnumerable<TenantPersonnelDto>> GetTenantPersonnelsForGender(Guid genderId)
        {
            if (!_tenantApplicationCRUDRepository.GenderExists(genderId))
            {
                return NotFound();
            }

            var tenantPersonnels = _tenantApplicationCRUDRepository.GetTenantPersonnels(genderId);
            return Ok(_mapper.Map<IEnumerable<TenantPersonnelDto>>(tenantPersonnels));
        }

        [HttpGet("{tenantPersonnelId}")]
        public ActionResult<TenantPersonnelDto> GetTenantPersonnelForGender(Guid genderId, Guid tenantPersonnelId)
        {
            if (!_tenantApplicationCRUDRepository.GenderExists(genderId))
            {
                return NotFound();
            }

            var tenantPersonnel = _tenantApplicationCRUDRepository.GetTenantPersonnel(genderId, tenantPersonnelId);

            if (tenantPersonnel == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TenantPersonnelDto>(tenantPersonnel));
        }
    }
}
