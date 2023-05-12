using CQRSAkademiPlusPostgre.CQRSPattern.Commands;
using CQRSAkademiPlusPostgre.DAL;

namespace CQRSAkademiPlusPostgre.CQRSPattern.Handler
{
    public class UpdateEmployeeCommandHandler
    {
        private readonly Context _context;

        public UpdateEmployeeCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(UpdateEmployeeCommand command)
        {
            var values = _context.Employees.Find(command.EmployeeID);
            values.EmployeeSurname = command.EmployeeSurname;
            values.EmployeeName = command.EmployeeName;
            values.EmployeeSalary = command.EmployeeSalary;
            values.EmployeeAge = command.EmployeeAge;
            values.EmployeeTitle = command.EmployeeTitle;
            values.EmployeeCity = command.EmployeeCity;
            _context.SaveChanges();
        }
    }
}
