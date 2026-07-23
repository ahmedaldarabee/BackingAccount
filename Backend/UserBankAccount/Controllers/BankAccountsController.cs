using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserBankAccount.Models;
using UserBankAccount.Data;

[Route("api/[controller]")]
[ApiController]
public class BankAccountsController : ControllerBase
{
    private readonly APIDbContext _context;
    public BankAccountsController(APIDbContext context)
    {
        _context = context;
    }

    // GET: api/BankAccount
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BankAccount>>> GetBankAccount()
    {
        return await _context.BankAccounts.ToListAsync();
    }

    // GET: api/BankAccount/5
    [HttpGet("{bankaccountid}")]
    public async Task<ActionResult<BankAccount>> GetBankAccount(int bankaccountid)
    {
        var bankaccount = await _context.BankAccounts.FindAsync(bankaccountid);

        if (bankaccount == null)
        {
            return NotFound();
        }

        return bankaccount;
    }

    // PUT: api/BankAccount/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{bankaccountid}")]
    public async Task<IActionResult> PutBankAccount(int? bankaccountid, BankAccount bankaccount)
    {
        if (bankaccountid != bankaccount.BankAccountID)
        {
            return BadRequest();
        }

        _context.Entry(bankaccount).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BankAccountExists(bankaccountid))
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

    // POST: api/BankAccount
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<BankAccount>> PostBankAccount(BankAccount bankaccount)
    {
        _context.BankAccounts.Add(bankaccount);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetBankAccount", new { bankaccountid = bankaccount.BankAccountID }, bankaccount);
    }

    // DELETE: api/BankAccount/5
    [HttpDelete("{bankaccountid}")]
    public async Task<IActionResult> DeleteBankAccount(int? bankaccountid)
    {
        var bankaccount = await _context.BankAccounts.FindAsync(bankaccountid);
        if (bankaccount == null)
        {
            return NotFound();
        }

        _context.BankAccounts.Remove(bankaccount);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool BankAccountExists(int? bankaccountid)
    {
        return _context.BankAccounts.Any(e => e.BankAccountID == bankaccountid);
    }
}
