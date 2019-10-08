using FluentValidation;
using Post_Surfer.Contract.V1.Requests;

namespace Post_Surfer.Validators
{
    public class CreateTagRequestValidators:AbstractValidator<CreateTagRequest>
    {
        public CreateTagRequestValidators()
        {
            RuleFor(x => x.TagName)
                .NotEmpty()
                .Matches("^[a-zA-Z0-9 ]*$");
        }
    }
}
