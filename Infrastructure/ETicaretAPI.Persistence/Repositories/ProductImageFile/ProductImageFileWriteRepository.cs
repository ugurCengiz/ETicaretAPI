using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Contexts;

namespace ETicaretAPI.Persistence.Repositories
{
    public class ProductImageFileWriteRepository : WriteRepository<ProductImageFile> , IProductImageFileWriteRepository
    {
        public ProductImageFileWriteRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}
