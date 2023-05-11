using CQRSAkademiPlusPostgre.CQRSPattern.Commands;
using CQRSAkademiPlusPostgre.DAL;

namespace CQRSAkademiPlusPostgre.CQRSPattern.Handler
{
    public class CreateProductCommandHandler
    {
        private readonly Context _context;

        public CreateProductCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handler(CreateProductCommand command)
        {
            _context.Products.Add(new Product
            {
                Barcode = command.Barcode,
                LastUseDate = command.LastUseDate,
                ProductBrand = command.ProductBrand,
                ProductCategory = command.ProductCategory,
                ProductName = command.ProductName,
                ProductPrice = command.ProductPrice,
                ProductStock = command.ProductStock,
                ProductStockType = command.ProductStockType,
                Publisher = command.Publisher,
                ShelfNumber = command.ShelfNumber,
                Tax = command.Tax

            });
            _context.SaveChanges();
        }
    }
}
