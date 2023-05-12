using MediatorAkademiPlusPostgre.MediatorDesignPattern.Results;
using MediatR;

namespace MediatorAkademiPlusPostgre.MediatorDesignPattern.Queries
{
    public class GetProductUpdateByIDQuery : IRequest<GetProductByIDQueryResult>
    {
        public GetProductUpdateByIDQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
