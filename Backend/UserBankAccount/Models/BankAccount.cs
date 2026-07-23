using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserBankAccount.Models
{
    public class BankAccount {

        [Key]
        public int BankAccountID { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public int AccountNumber { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string AccountHolder { get; set; }

        [Required]
        public int BankId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string FSC { get; set; }
    }
}
