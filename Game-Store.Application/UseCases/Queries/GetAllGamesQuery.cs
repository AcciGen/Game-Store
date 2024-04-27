using Game_Store.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Store.Application.UseCases.Queries
{
    public class GetAllGamesQuery:IRequest<List<Game>>
    {

    }
}
