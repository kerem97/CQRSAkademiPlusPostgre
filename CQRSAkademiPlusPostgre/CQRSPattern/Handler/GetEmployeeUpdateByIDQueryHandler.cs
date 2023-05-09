using CQRSAkademiPlusPostgre.CQRSPattern.Queries;
using CQRSAkademiPlusPostgre.CQRSPattern.Results;
using CQRSAkademiPlusPostgre.DAL;

namespace CQRSAkademiPlusPostgre.CQRSPattern.Handler
{
    public class GetEmployeeUpdateByIDQueryHandler
    {
        private readonly Context _context;

        public GetEmployeeUpdateByIDQueryHandler(Context context)
        {
            _context = context;
        }
        public GetEmployeeUpdateQueryResult Handle(GetEmployeeUpdateByIDQuery query)
        {
            var values = _context.Employees.Find(query.Id);
            return new GetEmployeeUpdateQueryResult
            {
                EmployeeAge = values.EmployeeAge,
                EmployeeCity = values.EmployeeCity,
                EmployeeID = values.EmployeeID,
                EmployeeName = values.EmployeeName,
                EmployeeSurname = values.EmployeeSurname,
                EmployeeSalary = values.EmployeeSalary,
                EmployeeTitle = values.EmployeeTitle
            };
        }
    }
}
