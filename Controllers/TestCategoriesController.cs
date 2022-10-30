using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DoAn.Entities;
using DoAn.Services;
using DoAn.Models.ViewModels;
using DoAn.Models.Interfaces;

namespace DoAn.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestCategoriesController : ControllerBase
{
    private readonly ICategory categoryRepo;

    public TestCategoriesController(ICategory CategoryRepo)
    {
        categoryRepo = CategoryRepo;
    }
    [HttpGet]
    public async Task<ActionResult> GetCategories()
    {
        
        try
        {
            return Ok(categoryRepo.GetCategories());
        }
        catch (Exception)
        {

            return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from database");
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<CategoryItem>> GetCategory(int id)
    {
        try
        {
            var result =await categoryRepo.GetCategory(id);
            if (result == null) return NotFound();
            return result;
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error retrieving data from the database");
        }
    }
    [HttpPost]
    public async Task<ActionResult<Category>> CreateCategory(Category cat)
    {
        try
        {
            var createCat = await categoryRepo.AddCategory(cat);

            return CreatedAtAction(nameof(GetCategory),
                        new { id = createCat.CategoryID }, createCat);
        }
        catch(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                ex);
        }
        
    }
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteEmployee(int id)
    {
        try
        {
            var employeeToDelete = await categoryRepo.GetCategory(id);

            if (employeeToDelete == null)
            {
                return NotFound($"Employee with Id = {id} not found");
            }

            await categoryRepo.DeleteCategory(id);

            return Ok($"Employee with Id = {id} deleted");
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error deleting employee record");
        }
    }


    [HttpPut("{id:int}")]
    public async Task<ActionResult<Category>> UpdateEmployee(int id, Category cat)
    {
        try
        {
            if (id != cat.CategoryID)
                return BadRequest("Employee ID mismatch");

            var employeeToUpdate = await categoryRepo.GetCategory(id);

            if (employeeToUpdate == null)
            {
                return NotFound($"Employee with Id = {id} not found");
            }

            return await categoryRepo.UpdateCategory(cat);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Error updating employee record");
        }
    }

}
   

   

