using MediatorAkademiPlusPostgre.DAL;
using MediatorAkademiPlusPostgre.MediatorDesignPattern.Queries;
using MediatorAkademiPlusPostgre.MediatorDesignPattern.Results;
using MediatR;

namespace MediatorAkademiPlusPostgre.MediatorDesignPattern.Handlers
{
    public class GetProductByIDQueryHandler : IRequestHandler<GetProductUpdateByIDQuery, GetProductByIDQueryResult>
    {
        private readonly Context _context;

        public GetProductByIDQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<GetProductByIDQueryResult> Handle(GetProductUpdateByIDQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Products.FindAsync(request.Id);
            return new GetProductByIDQueryResult
            {
                CategoryID = values.CategoryID,
                ProductBrand = values.ProductBrand,
                ProductName = values.ProductName,
                ProductPrice = values.ProductPrice,
                ProductID = values.ProductID,
                ProductStock = values.ProductStock,

            };
        }
    }
}
