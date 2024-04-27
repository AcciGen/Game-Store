using Game_Store.Application.Abstractions;
using Game_Store.Domain.Entities;
using Game_Store.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Store.Application.UseCases.Commands
{
    public class UpdateGameCommandHandler : IRequestHandler<CreateGameCommand, Game>
    {
        private readonly IAppDbContext _context;

        private readonly IHostEnvironment _hostEnvironment;
        public UpdateGameCommandHandler(IAppDbContext context, IHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
            
        }

        public async Task<Game> Handle(CreateGameCommand request, CancellationToken cancellationToken)
        {
            var game = await _context.Games.FirstOrDefaultAsync(x => x.Name == request.Name);

            if (game is null)
                throw new NotFoundException("Game Not Found!");

            var posterFile = request.Poster;
            var trailerFile = request.Trailer;
            List<IFormFile> photosFile = request.Photos;
            var ratingsGuideFile = request.RatingsGuide;

            string posterPath = "";
            string posterName = "";

            string trailerPath = "";
            string trailerName = "";

            string photoPath = "";
            string photoName = "";
            List<string> photosPaths = new List<string>(); // To hold all photo paths

            string ratingsGuidePath = "";
            string ratingsGuideName = "";

            try
            {
                // Poster file
                posterName = Guid.NewGuid().ToString() + Path.GetExtension(posterFile.FileName);
                posterPath = Path.Combine(_hostEnvironment.ContentRootPath, $"{request.Name}/Poster", posterName);

                using (var posterStream = new FileStream(posterPath, FileMode.Create))
                {
                    await posterFile.CopyToAsync(posterStream);
                }

                // Trailer file
                trailerName = Guid.NewGuid().ToString() + Path.GetExtension(trailerFile.FileName);
                trailerPath = Path.Combine(_hostEnvironment.ContentRootPath, $"{request.Name}/Trailer", trailerName);

                using (var trailerStream = new FileStream(trailerPath, FileMode.Create))
                {
                    await trailerFile.CopyToAsync(trailerStream);
                }

                // Photos file
                foreach (var photoFile in photosFile)
                {
                    photoName = Guid.NewGuid().ToString() + Path.GetExtension(photoFile.FileName);
                    photoPath = Path.Combine(_hostEnvironment.ContentRootPath, $"{request.Name}/Photos", photoName);

                    using (var photoStream = new FileStream(photoPath, FileMode.Create))
                    {
                        await photoFile.CopyToAsync(photoStream);
                    }

                    photosPaths.Add($"/{request.Name}/Photos/{photoName}"); // Add photo path to the list
                }

                // RatingsGuide file
                ratingsGuideName = Guid.NewGuid().ToString() + Path.GetExtension(ratingsGuideFile.FileName);
                ratingsGuidePath = Path.Combine(_hostEnvironment.ContentRootPath, $"{request.Name}/RatingsGuide", ratingsGuideName);

                using (var ratingsGuideStream = new FileStream(ratingsGuidePath, FileMode.Create))
                {
                    await ratingsGuideFile.CopyToAsync(ratingsGuideStream);
                }
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync($"Error: {ex.Message}");
            }

            game.Name = request.Name;
            game.Poster = $"/{request.Name}/Poster/{posterName}";
            game.Price = request.Price;
            game.Trailer = $"/{request.Name}/Trailer/{trailerName}";
            game.Photos = photosPaths; // Assign list of photo paths
            game.Description = request.Description;
            game.Genres = request.Genres;
            game.RatingsGuide = $"/{request.Name}/RatingsGuide/{ratingsGuideName}";
            game.ReleaseDate = request.ReleaseDate;
            game.Developer = request.Developer;
            game.Publisher = request.Publisher;
            game.Platform = request.Platform;
            game.SoldCount = request.SoldCount;

            var entry = _context.Games.Update(game);

            await _context.SaveChangesAsync();

            return entry.Entity;
        }
    }
}
