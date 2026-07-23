using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserBankAccount.Models;
using UserBankAccount.Data;

[Route("api/[controller]")]
[ApiController]
public class BankController : ControllerBase
{
    private readonly APIDbContext _context;
    public BankController(APIDbContext context)
    {
        _context = context;
    }

    // GET: api/Bank
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Bank>>> GetBanks()
    {
        return await _context.Banks.ToListAsync();
    }

    // GET: api/Bank/5
    [HttpGet("{bankid}")]
    public async Task<ActionResult<Bank>> GetBank(int bankid)
    {
        var bank = await _context.Banks.FindAsync(bankid);

        if (bank == null)
        {
            return NotFound();
        }

        return bank;
    }

    // PUT: api/Bank/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{bankid}")]
    public async Task<IActionResult> PutBank(int? bankid, Bank bank)
    {
        if (bankid != bank.BankId)
        {
            return BadRequest();
        }

        _context.Entry(bank).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BankExists(bankid))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Bank
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Bank>> PostBank(Bank bank)
    {
        _context.Banks.Add(bank);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetBank", new { bankid = bank.BankId }, bank);
    }

    // DELETE: api/Bank/5
    [HttpDelete("{bankid}")]
    public async Task<IActionResult> DeleteBank(int? bankid)
    {
        var bank = await _context.Banks.FindAsync(bankid);
        if (bank == null)
        {
            return NotFound();
        }

        _context.Banks.Remove(bank);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool BankExists(int? bankid)
    {
        return _context.Banks.Any(e => e.BankId == bankid);
    }
}
