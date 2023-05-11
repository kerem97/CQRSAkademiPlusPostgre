using CQRSAkademiPlusPostgre.CQRSPattern.Results;
using CQRSAkademiPlusPostgre.DAL;

namespace CQRSAkademiPlusPostgre.CQRSPattern.Handler
{
    public class GetProductQueryHandler
    {
        private readonly Context _context;

        public GetProductQueryHandler(Context context)
        {
            _context = context;
        }
        public List<GetProductQueryResult> Handle()
        {
            var values = _context.Products.Select(x => new GetProductQueryResult
            {
                ProductName=x.ProductName,
                ProductPrice=x.ProductPrice,
                ProductCategory=x.ProductCategory,
                ProductBrand=x.ProductBrand,
                ProductStock=x.ProductStock,
                ProductStockType=x.ProductStockType,
                Barcode=x.Barcode,
                LastUseDate=x.LastUseDate,
                ShelfNumber=x.ShelfNumber,
                
                
            }).ToList();
            return values;
        }

    }
}
