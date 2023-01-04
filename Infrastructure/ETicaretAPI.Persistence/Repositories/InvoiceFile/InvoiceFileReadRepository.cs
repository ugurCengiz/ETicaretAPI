using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Persistence.Contexts;

namespace ETicaretAPI.Persistence.Repositories
{
    public class InvoiceFileReadRepository: ReadRepository<Domain.Entities.InvoiceFile>,IInvoiceFileReadRepository
    {
        public InvoiceFileReadRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}
