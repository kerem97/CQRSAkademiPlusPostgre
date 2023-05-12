using MediatR;

namespace MediatorAkademiPlusPostgre.MediatorDesignPattern.Commands
{
    public class RemoveProductCommand : IRequest
    {
        public int Id { get; set; }

        public RemoveProductCommand(int id)
        {
            Id = id;
        }
    }
}
