using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DepartmentService.Utils.Common;
using DepartmentService.InternalModels.DTOs;
using DepartmentService.InternalModels.Entities;
using DepartmentService.Services;

namespace DepartmentService.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/departments")]
public class DepartmentsController : ControllerBase
{
    [HttpGet]
    public ActionResult<ApiResponse<IEnumerable<DepartmentDto>>> GetAll()
    {
        var data = DepartmentStore.Departments.Select(DepartmentDto.FromEntity).ToList();
        return Ok(ApiResponse<IEnumerable<DepartmentDto>>.Ok(data));
    }

    [HttpGet("{id:int}")]
    public ActionResult<ApiResponse<DepartmentDto>> GetById(int id)
    {
        var department = DepartmentStore.Departments.FirstOrDefault(x => x.Id == id);
        if (department is null)
        {
            return NotFound(ApiResponse<DepartmentDto>.Fail("Department not found"));
        }

        return Ok(ApiResponse<DepartmentDto>.Ok(DepartmentDto.FromEntity(department)));
    }

    [HttpPost]
    public ActionResult<ApiResponse<DepartmentDto>> Create([FromBody] CreateDepartmentDto dto)
    {
        var id = Interlocked.Increment(ref DepartmentStore.DepartmentSeed);
        var department = new DepartmentEntity
        {
            Id = id,
            Name = dto.Name,
            Description = dto.Description,
            HeadOfDepartment = dto.HeadOfDepartment,
            Email = dto.Email,
            Phone = dto.Phone,
            Location = dto.Location,
            Services = dto.Services,
            IsActive = true
        };

        DepartmentStore.Departments.Add(department);
        return CreatedAtAction(nameof(GetById), new { id }, ApiResponse<DepartmentDto>.Ok(DepartmentDto.FromEntity(department), "Department created"));
    }

    [HttpPut("{id:int}")]
    public ActionResult<ApiResponse<DepartmentDto>> Update(int id, [FromBody] UpdateDepartmentDto dto)
    {
        var department = DepartmentStore.Departments.FirstOrDefault(x => x.Id == id);
        if (department is null)
        {
            return NotFound(ApiResponse<DepartmentDto>.Fail("Department not found"));
        }

        department.Name = dto.Name;
        department.Description = dto.Description;
        department.HeadOfDepartment = dto.HeadOfDepartment;
        department.Email = dto.Email;
        department.Phone = dto.Phone;
        department.Location = dto.Location;
        department.Services = dto.Services;
        department.IsActive = dto.IsActive;
        return Ok(ApiResponse<DepartmentDto>.Ok(DepartmentDto.FromEntity(department), "Department updated"));
    }

    [HttpDelete("{id:int}")]
    public ActionResult<ApiResponse<string>> Delete(int id)
    {
        var department = DepartmentStore.Departments.FirstOrDefault(x => x.Id == id);
        if (department is null)
        {
            return NotFound(ApiResponse<string>.Fail("Department not found"));
        }

        DepartmentStore.Departments.Remove(department);
        return Ok(ApiResponse<string>.Ok("Department deleted"));
    }
}


