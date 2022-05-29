// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using Xpense.Data;

// namespace Xpense.Controllers
// {
//     [ApiController]
//     [Route("api/v1/[controller]")]
//     public class UserExpensesController : ControllerBase
//     {
//         private readonly ExpenseContext _context;
//         public UserExpensesController(ExpenseContext context)
//         {
//             _context = context;
//         }

//         [HttpGet]
//         public async Task<IActionResult> GetAllExpenseAsync()
//         {
//             return Ok();
//         }

//         [HttpPost]
//         public async Task<IActionResult> PostExpenseAsync()
//         {
//             return Ok();
//         }

//         [HttpPut("{id}")]
//         public async Task<IActionResult> PutExpenseAsync([FromRoute] string id)
//         {
//             if (string.IsNullOrWhiteSpace(id))
//             {
//                 return BadRequest(new { Message = "The expense id is required" });
//             }

//             return Ok();

//         }

//         [HttpDelete("{id}")]
//         public async Task<IActionResult> DeleteExpenseAsync([FromRoute] string id)
//         {
//             if (string.IsNullOrWhiteSpace(id))
//             {
//                 return BadRequest(new { Message = "The expense id is required" });
//             }

//             return Ok();
//         }
//     }

// }