using Game_Store.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Store.Application.UseCases.Commands
{
    public class DeleteGameCommand: IRequest<Game>
    {
        public Guid Id { get; set; }
    }
}
