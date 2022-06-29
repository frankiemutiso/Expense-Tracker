using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xpense.Data;
using Xpense.DTOs;
using Xpense.Extensions;
using Xpense.Models;

namespace Xpense.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ExpensesController : ControllerBase
    {
        private readonly ExpenseContext _context;
        public ExpensesController(ExpenseContext context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllExpenseAsync()
        {
            var username = User.GetUsername();

            var expenses = await _context.UserExpenses
                                        .Where(x => x.Username == username)
                                        .Select(expense => new ExpenseReadModel
                                        {
                                            Id = expense.Id,
                                            ExpenseDescription = expense.ExpenseDescription,
                                            ExpenseAmount = expense.ExpenseAmount,
                                            DateCreated = expense.DateCreated,
                                            CategoryId = expense.CategoryId
                                        })
                                        .OrderByDescending(expense => expense.DateCreated)
                                        .ToListAsync();

            return Ok(new
            {
                data = expenses,
                count = expenses.Count
            });
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetExpensesByCategoryAsync([FromQuery] Guid categoryId)
        {
            if (string.IsNullOrWhiteSpace(categoryId.ToString()))
            {
                return BadRequest(new { Message = "The category id is required" });
            }

            var username = User.GetUsername();

            var expenses = await _context.UserExpenses
                                        .Where(x => x.CategoryId == categoryId && x.Username == username)
                                        .Select(expense => new ExpenseReadModel
                                        {
                                            Id = expense.Id,
                                            ExpenseDescription = expense.ExpenseDescription,
                                            ExpenseAmount = expense.ExpenseAmount,
                                            DateCreated = expense.DateCreated,
                                            CategoryId = expense.CategoryId
                                        })
                                        .OrderByDescending(expense => expense.DateCreated)
                                        .ToListAsync();

            return Ok(new
            {
                data = expenses,
                count = expenses.Count
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExpenseByIdAsync([FromRoute] Guid id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                return BadRequest(new { Message = "The id of the expense is required" });
            }

            var username = User.GetUsername();
            var expense = await _context.UserExpenses.FindAsync(id);

            if (expense == null)
            {
                return NotFound(new { Message = $"The expense with the id '{id}' does not exist" });
            }

            return Ok(new ExpenseReadModel
            {
                Id = expense.Id,
                ExpenseDescription = expense.ExpenseDescription,
                ExpenseAmount = expense.ExpenseAmount,
                DateCreated = expense.DateCreated,
                CategoryId = expense.CategoryId
            });
        }

        [HttpPost]
        public async Task<IActionResult> PostExpenseAsync([FromBody] ExpenseWriteModel model)
        {
            if (string.IsNullOrWhiteSpace(model.ExpenseDescription))
            {
                return BadRequest(new { Message = "The description of the expense is required" });
            }

            if (model.ExpenseAmount < 0)
            {
                return BadRequest(new { Message = "The amount of the expense is required" });
            }

            if (string.IsNullOrWhiteSpace(model.CategoryId.ToString()))
            {
                return BadRequest(new { Message = "The category id is required" });
            }

            var username = User.GetUsername();

            UserExpense expense = new UserExpense
            {
                Id = new Guid(),
                ExpenseDescription = model.ExpenseDescription,
                ExpenseAmount = model.ExpenseAmount,
                CategoryId = model.CategoryId,
                Username = username
            };

            await _context.UserExpenses.AddAsync(expense);
            await _context.SaveChangesAsync();

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpenseAsync([FromRoute] Guid id, [FromBody] ExpenseWriteModel model)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                return BadRequest(new { Message = "The expense id is required" });
            }

            if (string.IsNullOrWhiteSpace(model.ExpenseDescription))
            {
                return BadRequest(new { Message = "The name of the expense is required" });
            }

            if (model.ExpenseAmount < 0)
            {
                return BadRequest(new { Message = "The amount of the expense is required" });
            }

            if (string.IsNullOrWhiteSpace(model.CategoryId.ToString()))
            {
                return BadRequest(new { Message = "The category id is required" });
            }
            var username = User.GetUsername();

            var expense = await _context.UserExpenses
                                        .Where(u => u.Username == username)
                                        .FirstOrDefaultAsync(x => x.Id == id);

            if (expense == null)
            {
                return NotFound(new { Message = $"The expense withe the id '{id}' does not exist" });
            }

            // update
            expense.ExpenseDescription = model.ExpenseDescription;
            expense.ExpenseAmount = model.ExpenseAmount;
            expense.CategoryId = model.CategoryId;
            expense.DateUpdated = DateTimeOffset.UtcNow;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpenseAsync([FromRoute] string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return BadRequest(new { Message = "The expense id is required" });
            }

            var expense = await _context.UserExpenses.FindAsync(id);

            if (expense == null)
            {
                return NotFound(new { Message = $"The expense withe the id '{id}' does not exist" });
            }

            // delete
            expense.IsDeleted = true;
            expense.DateDeleted = DateTimeOffset.UtcNow;

            return NoContent();
        }
    }

}