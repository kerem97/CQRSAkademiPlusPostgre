using CQRSAkademiPlusPostgre.CQRSPattern.Commands;
using CQRSAkademiPlusPostgre.CQRSPattern.Handler;
using CQRSAkademiPlusPostgre.CQRSPattern.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CQRSAkademiPlusPostgre.Controllers
{
    public class ProductController : Controller
    {
        private readonly GetProductQueryHandler _getProductQueryHandler;
        private readonly CreateProductCommandHandler _createProductCommandHandler;
        private readonly RemoveProductCommandHandler _removeProductCommandHandler;
        private readonly GetProductByIDQueryHandler _getProductByIDQueryHandler;
        public ProductController(GetProductQueryHandler getProductQueryHandler, CreateProductCommandHandler createProductCommandHandler, RemoveProductCommandHandler removeProductCommandHandler, GetProductByIDQueryHandler getProductByIDQueryHandler)
        {
            _getProductQueryHandler = getProductQueryHandler;
            _createProductCommandHandler = createProductCommandHandler;
            _removeProductCommandHandler = removeProductCommandHandler;
            _getProductByIDQueryHandler = getProductByIDQueryHandler;
        }

        public IActionResult Index()
        {
            var values = _getProductQueryHandler.Handle();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(CreateProductCommand command)
        {
            _createProductCommandHandler.Handler(command);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteProduct(int id)
        {
            _removeProductCommandHandler.Handle(new RemoveProductCommand(id));
            return RedirectToAction("Index");
        }
        public IActionResult DetailProduct(int id)
        {
            var values = _getProductByIDQueryHandler.Handle(new GetProductByIDQuery(id));
            return View(values);
        }
        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var values = _getProductByIDQueryHandler.Handle(new GetProductByIDQuery(id));
            return View(values);
        }


    }
}
