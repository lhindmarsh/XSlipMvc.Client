using Microsoft.EntityFrameworkCore;

using XSlipMvc.Client.Domain.Entities;

namespace XSlipMvc.Client.Infrastructure.Persistence.Context
{
    public class XSlipContext : DbContext
    {
        //Server Name=(localdb)\MSSQLLocalDB
        //ConnectionString=Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=development-XSlip;Integrated Security=True;Trust Server Certificate=True

        public XSlipContext(DbContextOptions<XSlipContext> options) : base(options)
        { }

        DbSet<Expense> Expenses { get; set; }
    }
}