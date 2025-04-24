using ETAP.Application.DTOs.Activities;
using FluentValidation;

namespace ETAP.Application.Validators.Activities
{
    public class UpdateActivityRequestValidator : AbstractValidator<UpdateActivityRequest>
    {
        public UpdateActivityRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Güncellenecek etkinliğin ID'si boş olamaz.");

            RuleFor(x => x.Title)
                .NotEmpty().MaximumLength(100);

            RuleFor(x => x.Description)
                .MaximumLength(1000);

            RuleFor(x => x.Location)
                .NotEmpty();

            RuleFor(x => x.StartDate)
                .LessThan(x => x.EndDate).WithMessage("Başlangıç tarihi, bitiş tarihinden önce olmalı.");

            RuleFor(x => x.Category)
                .GreaterThan(0);

            RuleFor(x => x.OrganizationId).NotEmpty();
            RuleFor(x => x.OrganizerId).NotEmpty();
        }
    }
}