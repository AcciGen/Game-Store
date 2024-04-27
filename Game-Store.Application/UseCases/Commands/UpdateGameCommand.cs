using Game_Store.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Store.Application.UseCases.Commands
{
    public class UpdateGameCommand: IRequest<Game>
    {
        public string Name { get; set; }
        public IFormFile Poster { get; set; }
        public float Price { get; set; }
        public IFormFile Trailer { get; set; }
        public List<IFormFile> Photos { get; set; }
        public string Description { get; set; }
        public List<string> Genres { get; set; }
        public IFormFile RatingsGuide { get; set; }
        public DateTimeOffset ReleaseDate { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public string Platform { get; set; }
        public long SoldCount { get; set; }
    }
}
