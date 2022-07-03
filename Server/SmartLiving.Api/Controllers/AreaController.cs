﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SmartLiving.Domain.DataTransferObjects;
using SmartLiving.Domain.Supervisors.Interfaces;
using SmartLiving.Library.Constants;
using SmartLiving.Library.DataTypes;

namespace SmartLiving.Api.Controllers
{
    namespace SmartLiving.Api.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class AreaController : BaseController
    {
        private readonly ISupervisor _supervisor;

        public AreaController(ISupervisor supervisor)
        {
            _supervisor = supervisor;
        }

        //GET: api/Area/GetAllAreas
        [HttpGet("[action]")]
        public ActionResult<IEnumerable<AreaGetDto>> GetAllAreas()
        {
            try
            {
                var allItems = _supervisor.GetAllAreas();

                if (allItems.Any())
                    return Ok(allItems);
                return NotFound();
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        //GET: api/Area/GetPagedList
        [HttpGet("[action]")]
        public ActionResult<PagedList<AreaGetDto>> GetPagedList(int pageIndex = 1, int pageSize = SystemConstants.PageSizeDefault)
        {
            try
            {
                var areaPagedList = _supervisor.GetPagedList<AreaGetDto>(_supervisor.GetAllAreas().ToList() ,pageIndex, pageSize);

                if (areaPagedList.Any())
                    return Ok(areaPagedList);
                return NotFound();
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        //GET: api/Area/{id}
        [HttpGet("{id}", Name = "GetAreaById")]
        public ActionResult<AreaGetDto> GetAreaById(int id)
        {
            try
            {
                var area = _supervisor.GetAreaById(id);

                if (area != null)
                    return Ok(area);
                return NotFound();
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        //POST: api/Area
        [HttpPost]
        public ActionResult<AreaGetDto> CreateArea([FromBody] AreaGetDto model)
        {
            try
            {
                if (model == null || !ModelState.IsValid) return BadRequest();

                model = _supervisor.CreateArea(model);

                return CreatedAtRoute(nameof(GetAreaById), new {id = model.Id}, model);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        //PUT: api/Area/{id}
        [HttpPut("{id}")]
        public ActionResult<AreaGetDto> UpdateArea(int id, [FromBody] AreaGetDto model)
        {
            try
            {
                if (model == null || !ModelState.IsValid) return BadRequest();

                if (_supervisor.GetAreaById(id) == null) return NotFound();

                model.Id = id;

                return _supervisor.UpdateArea(model) ? NoContent() : StatusCode(500);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        //PATCH: api/Area/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialUpdateArea(int id, [FromBody] JsonPatchDocument<AreaGetDto> patchDoc)
        {
            try
            {
                var model = _supervisor.GetAreaById(id);
                if (model == null) return NotFound();

                patchDoc.ApplyTo(model, ModelState);

                if (!TryValidateModel(model))
                {
                    return ValidationProblem(ModelState);
                }

                model.Id = id;

                return _supervisor.UpdateArea(model) ? NoContent() : StatusCode(500);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }

        //DELETE: api/Area/id
        [HttpDelete("{id}")]
        public ActionResult DeleteArea(int id)
        {
            try
            {
                if (_supervisor.GetAreaById(id) == null) return NotFound();

                return _supervisor.DeleteArea(id) ? NoContent() : StatusCode(500);
            }
            catch (Exception e)
            {
                return HandleException(e);
            }
        }
    }
}
}
