﻿using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
    public class UpdateCastCommandHandler : IRequestHandler<UpdateCastCommand>
    {
        private readonly MovieContext _context;
        public UpdateCastCommandHandler(MovieContext context)
        {
            _context = context;
        }
        public async Task Handle(UpdateCastCommand request, CancellationToken cancellationToken)
        {
            var value = await _context.Casts.FindAsync(request.CastId);
            value.Surname = request.Surname;
            value.Name = request.Name;
            value.Title = request.Title;
            value.ImageUrl = request.ImageUrl;
            value.Overview = request.Overview;
            value.Biography = request.Biography;
            await _context.SaveChangesAsync();
        }
    }
}
