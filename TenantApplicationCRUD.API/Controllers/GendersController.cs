using AutoMapper;
using TenantApplicationCRUD.API.Helpers;
using TenantApplicationCRUD.API.Models;
using TenantApplicationCRUD.API.ResourceParameters;
using TenantApplicationCRUD.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TenantApplicationCRUD.API.Controllers
{
    [ApiController]
    [Route("api/genders")]
    //[Route("api/[controller]")]
    public class GendersController : ControllerBase
    {
        private readonly ITenantApplicationCRUDRepository _tenantApplicationCRUDRepository;
        private readonly IMapper _mapper;

        public GendersController(ITenantApplicationCRUDRepository tenantApplicationCRUDRepository,
            IMapper mapper)
        {
            _tenantApplicationCRUDRepository = tenantApplicationCRUDRepository ?? throw new ArgumentNullException(nameof(tenantApplicationCRUDRepository));
            _mapper = mapper;
        }

        [HttpGet()]
        [HttpHead]
        public ActionResult<IEnumerable<GenderDto>> GetGenders([FromQuery] GendersResourceParameters gendersResourceParameters)
        {
            var genders = _tenantApplicationCRUDRepository.GetGenders(gendersResourceParameters);
            return Ok(_mapper.Map<IEnumerable<GenderDto>>(genders));
        }

        [HttpGet("{genderId}", Name = "GetGender")]
        public IActionResult GetGender(Guid genderId)
        {
            var gender = _tenantApplicationCRUDRepository.GetGender(genderId);

            if (gender == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<GenderDto>(gender));
        }

        [HttpPost]
        public ActionResult<GenderDto> CreateGender(GenderForCreationDto gender)
        {
            var genderEntity = _mapper.Map<Entities.Gender>(gender);
            _tenantApplicationCRUDRepository.AddGender(genderEntity);
            _tenantApplicationCRUDRepository.Save();

            var genderToReturn = _mapper.Map<GenderDto>(genderEntity);
            return CreatedAtRoute("GetGender",
                new { genderId = genderToReturn.Id }, genderToReturn);
        }
    }
}
