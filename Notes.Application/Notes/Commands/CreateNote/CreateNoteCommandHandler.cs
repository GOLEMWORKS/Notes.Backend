using System;
using MediatR;
using System.Threading;
using System.Threading.Channels;
using Notes.Domain;
using Notes.Application.Interfaces;

namespace Notes.Application.Notes.Commands.CreateNote
{
    internal class CreateNoteCommandHandler
        :IRequestHandler<CreateNoteCommand, Guid>
    {
        private readonly INotesDbContext _dbContext;

        public CreateNoteCommandHandler(INotesDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Guid> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            var note = new Note
            {
                UserId = request.UserID,
                Title = request.Title,
                Details = request.Details,
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                EditDate = null
            };

            return note.Id;
        }
    }
}
