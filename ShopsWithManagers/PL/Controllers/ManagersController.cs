using BLL.Interfaces;
using BLL.Models;
using PL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using AutoMapper;
using System.Collections.Generic;
using DAL;

namespace PL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManagersController : ControllerBase
    {
        private readonly IManagerService _managerService;
        private readonly IMapper _mapper;

        public ManagersController(IManagerService managerService, IMapper mapper)
        {
            _managerService = managerService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("get-specific-manager")]
        public IActionResult GetManager(int managerId)
        {
            var specificManager = new ManagerViewModel();

            try
            {
                var manager = _managerService.GetManager(managerId);
                specificManager = _mapper.Map<ManagerViewModel>(manager);
            }
            catch (Exception ex) 
            {
                return BadRequest(new
                {
                    Message = ex.Message
                });
            }

            return new OkObjectResult(new { Manager = specificManager });
            
        }

        [HttpGet]
        [Route("all-managers")]
        public AllManagersResponseViewModel GetManagers(int currentPage, int pageSize, bool? isTimeFilterEnabled, int? shopId, string status)
        {
            var managerFilters = new ManagerFilters
            {
                IsTimeFilterEnabled = isTimeFilterEnabled,
                ShopId = shopId,
                Status = status
            };

            var allManagers = _managerService.GetManagers(currentPage - 1, pageSize, managerFilters);

            return _mapper.Map<AllManagersResponseViewModel>(allManagers);
        }

        [HttpPost]
        [Route("add-manager")]
        public IActionResult Post(ManagerViewModel managerViewModel)
        {
            try
            {
                var manager = _mapper.Map<ManagerModel>(managerViewModel);

                _managerService.AddManager(manager);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new
                {
                    Message = ex.Message
                });
            }

            return Ok(new { Message = "Manager created successfully" });
        }

        [HttpDelete]
        [Route("dismiss")]
        public IActionResult DismissFromWork([FromQuery]int managerId)
        {
            try
            {
                _managerService.DismissFromWork(managerId);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new
                {
                    Message = ex.Message
                });
            }

            return Ok();
        }

        [HttpPatch]
        [Route("get-job")]
        public IActionResult EmployManagerIntoShop(ManagerControllerPatchRequestParams requestParams)
        {
            try
            {
                _managerService.EmployManagerIntoShop(requestParams.ManagerId, requestParams.ShopId);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new
                {
                    Message = ex.Message
                });
            }

            return Ok();
        }
    }
}
