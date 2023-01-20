using System;   
using System.Threading.Tasks;
using System.Threading;
using Notes.Domain;
using Notes.Application.Common.Exceptions;
using MediatR;
using Notes.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Notes.Application.Notes.Commands.UpdateNote
{
    internal class UpdateNodeCommandHandler
        : IRequestHandler<UpdateNoteCommand>
    {
        public readonly INotesDbContext _dbContext;

        public UpdateNodeCommandHandler(INotesDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Notes.FirstOrDefaultAsync(note =>
                    note.Id == request.Id, cancellationToken);
            if (entity == null || entity.UserId != request.UserId ) 
            {
                throw new NotFoundException(nameof(Note), request.Id);
            }

            entity.Details = request.Details;
            entity.Title = request.Title;
            entity.EditDate = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }   
    }
}
