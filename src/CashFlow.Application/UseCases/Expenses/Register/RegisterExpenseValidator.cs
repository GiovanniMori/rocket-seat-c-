using CashFlow.Communication.Requests;
using CashFlow.Exception;
using FluentValidation;

namespace CashFlow.Application;

public class RegisterExpenseValidator : AbstractValidator<RequestRegisterExpenseJson>
{
    public RegisterExpenseValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage(ResourceErrorMessages.TITLE_REQUIRED);
        RuleFor(x => x.Amount).GreaterThan(0).WithMessage("Amount must be greater than 0");
        RuleFor(x => x.Date)
            .LessThanOrEqualTo(DateTime.Now)
            .WithMessage("Date must be less than or equal to today");
        RuleFor(x => x.PaymentType).IsInEnum().WithMessage("Payment type is invalid");
    }
}
