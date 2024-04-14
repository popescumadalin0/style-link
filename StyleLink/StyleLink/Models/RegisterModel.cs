using System.ComponentModel.DataAnnotations;
using StyleLink.Constants;

namespace StyleLink.Models;

public class RegisterModel
{
    [Display(Name = Names.FirstName)]
    [Required(ErrorMessage = Messages.FirstNameIsMandatory)]
    public string FirstName { get; set; }

    [Display(Name = Names.LastName)]
    [Required(ErrorMessage = Messages.LastNameIsMandatory)]
    public string LastName { get; set; }

    [Display(Name = Names.EmailAddress)]
    [Required(ErrorMessage = Messages.EmailAddressIsMandatory)]
    [EmailAddress(ErrorMessage = Messages.EmailAddressIsInvalid)]
    public string Email { get; set; }

    [Display(Name = Names.PhoneNumber)]
    [Required(ErrorMessage = Messages.PhoneNumberIsMandatory)]
    [RegularExpression(Values.PhoneNumberRegex, ErrorMessage = Messages.PhoneNumberNotValidMessage)]
    public string PhoneNumber { get; set; }

    [Display(Name = Names.Password)]
    [Required(ErrorMessage = Messages.PasswordIsMandatory)]
    [DataType(DataType.Password)]
    [RegularExpression(Values.PasswordRegex, ErrorMessage = Messages.PasswordNotValidMessage)]
    public string Password { get; set; }

    [Display(Name = Names.PasswordConfirmation)]
    [Required(ErrorMessage = Messages.PasswordConfirmationIsMandatory)]
    [DataType(DataType.Password)]
    [Compare(nameof(Password), ErrorMessage = Messages.PasswordAndPasswordConfirmationDismatch)]
    public string ConfirmPassword { get; set; }

    [Range(typeof(bool), Values.BooleanTrueValue, Values.BooleanTrueValue, ErrorMessage = Messages.AcceptTermsAndConditions)]
    public bool AgreeWithTermsAndConditions { get; set; }

    //todo: add image
    public byte[] ProfileImage { get; set; }
}