﻿using Exam.Application.Abstractions.Commands;
using Exam.Application.Abstractions.Error;
using Exam.Application.Abstractions.Repository;
using MediatR;

namespace Exam.Application.Features.Teacher.CreateTeacher
{
    public class CreateTeacherCommandHandler(IRepository<TeacherEntity> repository, IMapper mapper, IUnitOfWork unitOfWork) : ICommandHandler<CreateTeacherCommand, Unit>
    {
        private readonly IRepository<TeacherEntity> _repository = repository;
        private readonly IMapper _mapper = mapper;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<Unit, IDomainError>> Handle(CreateTeacherCommand request, CancellationToken cancellationToken)
        {
            TeacherEntity entity = _mapper.Map<TeacherEntity>(request);
            await _repository.AddAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success<Unit, IDomainError>(Unit.Value);
        }
    }
}
