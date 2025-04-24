using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETAP.Application.DTOs.Activities;
using FluentValidation;

namespace ETAP.Application.Validators.Activities
{
public class CreateActivityRequestValidator : AbstractValidator<CreateActivityRequest>
{
    public CreateActivityRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Etkinlik başlığı boş olamaz.")
            .MaximumLength(100).WithMessage("Etkinlik başlığı en fazla 100 karakter olabilir.");

        RuleFor(x => x.Description)
            .MaximumLength(1000).WithMessage("Açıklama en fazla 1000 karakter olabilir.");

        RuleFor(x => x.Location)
            .NotEmpty().WithMessage("Konum alanı boş olamaz.");

        RuleFor(x => x.StartDate)
            .LessThan(x => x.EndDate)
            .WithMessage("Başlangıç tarihi bitiş tarihinden önce olmalıdır.");

        RuleFor(x => x.Category)
            .GreaterThan(0).WithMessage("Geçerli bir kategori seçilmelidir.");

        RuleFor(x => x.OrganizationId)
            .NotEmpty().WithMessage("Organizasyon ID boş olamaz.");

        RuleFor(x => x.OrganizerId)
            .NotEmpty().WithMessage("Organizatör ID boş olamaz.");
    }
}
}