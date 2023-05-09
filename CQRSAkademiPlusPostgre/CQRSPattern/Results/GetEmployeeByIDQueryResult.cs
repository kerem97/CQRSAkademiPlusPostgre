namespace CQRSAkademiPlusPostgre.CQRSPattern.Results
{
    public class GetEmployeeByIdQueryResult
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
      
        public string EmployeeCity { get; set; }
    }
}
