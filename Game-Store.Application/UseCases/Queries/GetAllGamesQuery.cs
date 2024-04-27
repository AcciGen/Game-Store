using Game_Store.Domain.Entities;
using MediatR;


namespace Game_Store.Application.UseCases.Queries
{
    public class GetAllGamesQuery:IRequest<List<Game>>
    {

    }
}
