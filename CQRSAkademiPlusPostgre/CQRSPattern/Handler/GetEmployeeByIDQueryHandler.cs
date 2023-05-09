using CQRSAkademiPlusPostgre.CQRSPattern.Queries;
using CQRSAkademiPlusPostgre.CQRSPattern.Results;
using CQRSAkademiPlusPostgre.DAL;

namespace CQRSAkademiPlusPostgre.CQRSPattern.Handler
{
    public class GetEmployeeByIDQueryHandler
    {
        private readonly Context _context;

        public GetEmployeeByIDQueryHandler(Context context)
        {
            _context = context;
        }
        public GetEmployeeByIdQueryResult Handle(GetEmployeeByIDQuery query)
        {
            var values = _context.Employees.Find(query.Id);
            return new GetEmployeeByIdQueryResult
            {
                EmployeeCity = values.EmployeeCity,
                EmployeeID = values.EmployeeID,
                EmployeeName = values.EmployeeName,
                EmployeeSurname = values.EmployeeSurname,
            };
        }
    }
}
