using StyleLink.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StyleLink.Models;

public class AddHairStylistModel
{
    public Guid Id { get; set; } = Guid.NewGuid();

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

    [Display(Name = Names.Images)]
    [Required(ErrorMessage = Messages.ImagesAreMandatory)]
    public string? ProfileImageTest { get; set; } = default!;

    [Display(Name = Names.Images)]
    [Required(ErrorMessage = Messages.ImagesAreMandatory)]
    public byte[] ProfileImage { get; set; } = default!;

    [Display(Name = Names.PhoneNumber)]
    [Required(ErrorMessage = Messages.PhoneNumberIsMandatory)]
    [RegularExpression(Values.PhoneNumberRegex, ErrorMessage = Messages.PhoneNumberNotValidMessage)]
    public string PhoneNumber { get; set; }

    public List<string> Services { get; set; } = new();
}