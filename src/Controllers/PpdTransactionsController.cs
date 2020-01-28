using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WlmPropertyAPI.Models;

namespace WlmPropertyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PpdTransactionsController : ControllerBase
    {
        private readonly WLMPropertyContext _context;

        public PpdTransactionsController(WLMPropertyContext context)
        {
            _context = context;
        }

        // GET: api/PpdTransactions
        [HttpGet]
        public async Task<ActionResult<PpdTransaction>> GetPpdTransactions()
        {
            return await _context.PpdTransactions.FirstAsync(p => p.Postcode == "GU51 5TU");
        }

        // GET: api/PpdTransactions/Cheshire
        [HttpGet("{County}")]
        public async Task<ActionResult<PpdTransaction>> GetPpdTransaction(String County)
        {
            var ppdTransaction = await _context.PpdTransactions.FirstAsync(p => p.County == County);

            if (ppdTransaction == null)
            {
                return NotFound();
            }

            return ppdTransaction;
        }

        // PUT: api/PpdTransactions/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutPpdTransaction(Guid id, PpdTransaction ppdTransaction)
        //{
        //    if (id != ppdTransaction.TransactionUniqueIdentifier)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(ppdTransaction).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PpdTransactionExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/PpdTransactions
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPost]
        //public async Task<ActionResult<PpdTransaction>> PostPpdTransaction(PpdTransaction ppdTransaction)
        //{
        //    _context.PpdTransactions.Add(ppdTransaction);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (PpdTransactionExists(ppdTransaction.TransactionUniqueIdentifier))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtAction("GetPpdTransaction", new { id = ppdTransaction.TransactionUniqueIdentifier }, ppdTransaction);
        //}

        // DELETE: api/PpdTransactions/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<PpdTransaction>> DeletePpdTransaction(Guid id)
        //{
        //    var ppdTransaction = await _context.PpdTransactions.FindAsync(id);
        //    if (ppdTransaction == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.PpdTransactions.Remove(ppdTransaction);
        //    await _context.SaveChangesAsync();

        //    return ppdTransaction;
        //}

        //private bool PpdTransactionExists(Guid id)
        //{
        //    return _context.PpdTransactions.Any(e => e.TransactionUniqueIdentifier == id);
        //}
    }
}
