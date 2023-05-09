﻿using CQRSAkademiPlusPostgre.CQRSPattern.Commands;
using CQRSAkademiPlusPostgre.CQRSPattern.Handler;
using CQRSAkademiPlusPostgre.CQRSPattern.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CQRSAkademiPlusPostgre.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly GetEmployeeQueryHandler _getEmployeeQueryHandler;
        private readonly GetEmployeeByIDQueryHandler _getEmployeeByIDQueryHandler;
        private readonly CreateEmployeeCommandHandler _createEmployeeCommandHandler;
        private readonly RemoveEmployeeCommandHandler _removeEmployeeCommandHandler;
        private readonly GetEmployeeUpdateByIDQueryHandler _getEmployeeUpdateByIDQueryHandler;

        public EmployeeController(GetEmployeeQueryHandler getEmployeeQueryHandler, GetEmployeeByIDQueryHandler getEmployeeByIDQueryHandler, CreateEmployeeCommandHandler createEmployeeCommandHandler, RemoveEmployeeCommandHandler removeEmployeeCommandHandler, GetEmployeeUpdateByIDQueryHandler getEmployeeUpdateByIDQueryHandler)
        {
            _getEmployeeQueryHandler = getEmployeeQueryHandler;
            _getEmployeeByIDQueryHandler = getEmployeeByIDQueryHandler;
            _createEmployeeCommandHandler = createEmployeeCommandHandler;
            _removeEmployeeCommandHandler = removeEmployeeCommandHandler;
            _getEmployeeUpdateByIDQueryHandler = getEmployeeUpdateByIDQueryHandler;
        }

        public IActionResult Index()
        {
            var values = _getEmployeeQueryHandler.Handle();
            return View(values);
        }

        public IActionResult DetailEmployee(int id)
        {
            var values = _getEmployeeByIDQueryHandler.Handle(new GetEmployeeByIDQuery(id));
            return View(values);
        }
        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(CreateEmployeeCommand command)
        {
            _createEmployeeCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteEmployee(int id)
        {
            _removeEmployeeCommandHandler.Handle(new RemoveEmployeeCommand(id));
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateEmployee(int id)
        {
            var values = _getEmployeeByIDQueryHandler.Handle(new GetEmployeeByIDQuery(id));
            return View(values);
        }

    }
}
