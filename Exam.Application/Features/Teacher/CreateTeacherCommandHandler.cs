using AutoMapper;
using CSharpFunctionalExtensions;
using Exam.Application.Abstractions.Commands;
using Exam.Application.Abstractions.Error;
using Exam.Application.Abstractions.Repository;
using Exam.Domain.Entities;
using MediatR;

namespace Exam.Application.Features.Teacher
{
    public class CreateTeacherCommandHandler(IRepository<TeacherEntity> repository, IMapper mapper) : ICommandHandler<CreateTeacherCommand, Unit>
    {
        private readonly IRepository<TeacherEntity> _repository = repository;
        private readonly IMapper _mapper = mapper;
        public async Task<Result<Unit, IDomainError>> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
        {
            TeacherEntity entity = _mapper.Map<TeacherEntity>(request);
            await _repository.AddAsync(entity, cancellationToken);
            return Result.Success<Unit, IDomainError>(Unit.Value);
        }
    }
}
