using Game_Store.Application.Abstractions;
using Game_Store.Domain.Entities;
using Game_Store.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Game_Store.Application.UseCases.Queries
{
    public class GetGameByNameQueryHandler:IRequestHandler<GetGameByNameQuery,Game>
    {
        private readonly IAppDbContext _appDbContext;
        public GetGameByNameQueryHandler(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;    
        }
        public async Task<Game> Handle(GetGameByNameQuery request, CancellationToken cancellationToken) 
        {
            var game = await _appDbContext.Games.FirstOrDefaultAsync(x => x.Name == request.GameName);

            if (game == null)
            {
                throw new NotFoundException("Game not found");
            }
            else
            {
                return game;
            }
        }
    }
}
