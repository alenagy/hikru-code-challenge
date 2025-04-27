using FluentValidation;
using HikruCodeChallenge.Application.Positions.Commands;

namespace HikruCodeChallenge.Application.Positions.Validators
{
    public class CreatePositionValidator : AbstractValidator<CreatePositionCommand>
    {
        public CreatePositionValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(1000).WithMessage("Description cannot exceed 1000 characters.");

            RuleFor(x => x.Location)
                .NotEmpty().WithMessage("Location is required.");

            RuleFor(x => x.Budget)
                .GreaterThan(0).WithMessage("Budget must be greater than zero.");

            RuleFor(x => x.RecruiterId)
                .NotEmpty().WithMessage("RecruiterId is required.");

            RuleFor(x => x.DepartmentId)
                .NotEmpty().WithMessage("DepartmentId is required.");
        }
    }
}
