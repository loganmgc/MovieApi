﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MovieApi.Application.Features.MediatorDesignPattern.Commands.CastCommands;
using MovieApi.Persistence.Context;

namespace MovieApi.Application.Features.MediatorDesignPattern.Handlers.CastHandlers
{
    public class RemoveCastQueryHandler : IRequestHandler<RemoveCastCommand>
    {
        private readonly MovieContext _context;

        public RemoveCastQueryHandler(MovieContext context)
        {
            _context = context;
        }

        public async Task Handle(RemoveCastCommand request, CancellationToken cancellationToken)
        {
            var value = await _context.Casts.FindAsync(request.CastId);
            _context.Casts.Remove(value);
            await _context.SaveChangesAsync();
        }
    }
}
