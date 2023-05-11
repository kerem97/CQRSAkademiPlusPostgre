using CQRSAkademiPlusPostgre.CQRSPattern.Queries;
using CQRSAkademiPlusPostgre.CQRSPattern.Results;
using CQRSAkademiPlusPostgre.DAL;

namespace CQRSAkademiPlusPostgre.CQRSPattern.Handler
{
    public class GetProductByIDQueryHandler
    {
        private readonly Context _context;

        public GetProductByIDQueryHandler(Context context)
        {
            _context = context;
        }

        public GetProductByIDQueryResult Handle(GetProductByIDQuery query)
        {
            var values = _context.Products.Find(query.Id);
            return new GetProductByIDQueryResult
            {
                ProductName = values.ProductName,
                ProductCategory = values.ProductCategory,
                ProductID = values.ProductID,
                Barcode = values.Barcode,
                LastUseDate = values.LastUseDate,
                ProductBrand = values.ProductBrand,
                ProductPrice = values.ProductPrice,
                ProductStock = values.ProductStock,
                ProductStockType = values.ProductStockType,
                Publisher = values.Publisher,
                ShelfNumber = values.ShelfNumber,
                Tax = values.Tax,
            };
        }
    }
}
