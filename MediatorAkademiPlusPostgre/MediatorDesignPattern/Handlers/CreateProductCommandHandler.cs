using MediatorAkademiPlusPostgre.DAL;
using MediatorAkademiPlusPostgre.MediatorDesignPattern.Commands;
using MediatR;

namespace MediatorAkademiPlusPostgre.MediatorDesignPattern.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly Context _context;

        public CreateProductCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            _context.Products.Add(new Product
            {
                CategoryID = request.CategoryID,
                ProductBrand = request.ProductBrand,
                ProductName = request.ProductName,
                ProductStock = request.ProductStock,
                ProductPrice = request.ProductPrice,
            });
            await _context.SaveChangesAsync();
        }
    }
}
