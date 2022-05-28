using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xpense.Data;
using Xpense.DTOs;
using Xpense.Models;

namespace Xpense.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class ExpenseCategoriesController : ControllerBase
    {
        private readonly ExpenseContext _context;

        public ExpenseCategoriesController(ExpenseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            var categories = await _context.ExpenseCategories.ToListAsync();

            List<CategoryReadModel> res = new List<CategoryReadModel>();

            foreach (var item in categories)
            {
                res.Add(new CategoryReadModel
                {
                    Id = item.Id,
                    CategoryName = item.CategoryName,
                });
            }

            return Ok(res);
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest(new { Message = "Category id is required" });
            }

            var category = await _context.ExpenseCategories.FindAsync(id);

            if (category == null)
            {
                return NotFound(new { Message = "Category with the id '{id}' does not exist" });
            }

            return Ok(new CategoryReadModel
            {
                Id = category.Id,
                CategoryName = category.CategoryName
            });
        }

        [HttpPost]
        public async Task<IActionResult> PostCategoriesAsync([FromBody] CategoryWriteModel model)
        {
            if (string.IsNullOrWhiteSpace(model.CategoryName))
            {
                return BadRequest(new { Message = "Category name is required" });
            }

            var req = new ExpenseCategory
            {
                CategoryName = model.CategoryName,
            };

            await _context.ExpenseCategories.AddAsync(req);
            await _context.SaveChangesAsync();

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditCategoryAsync([FromRoute] string id, [FromBody] CategoryWriteModel model)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest(new { Message = "The category id is required" });
            }

            ExpenseCategory category = await _context.ExpenseCategories.FindAsync(id);

            if (category == null)
            {
                return NotFound(new { Message = $"The category with the id '{id}' does not exist" });
            }

            //update
            category.CategoryName = model.CategoryName;
            category.DateUpdated = DateTimeOffset.UtcNow;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest(new { Message = "The category id is required" });
            }

            ExpenseCategory category = await _context.ExpenseCategories.FindAsync(id);

            if (category == null)
            {
                return NotFound(new { Message = $"The category with the id '{id}' does not exist" });
            }

            category.DateDeleted = DateTimeOffset.UtcNow;
            category.IsDeleted = true;

            await _context.SaveChangesAsync();

            return Ok(new { Message = $"Category with id '{id}' was deleted successfully" });
        }


    }
}