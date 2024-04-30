using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using StyleLink.Constants;

namespace StyleLink.Models;

public class UpdateUserModel
{
    public Guid Id { get; set; }

    [Display(Name = Names.EmailAddress)]
    [Required(ErrorMessage = Messages.EmailAddressIsMandatory)]
    [EmailAddress(ErrorMessage = Messages.EmailAddressIsInvalid)]
    public string Email { get; set; }

    [Display(Name = Names.FirstName)]
    [Required(ErrorMessage = Messages.FirstNameIsMandatory)]
    public string FirstName { get; set; }

    [Display(Name = Names.LastName)]
    [Required(ErrorMessage = Messages.LastNameIsMandatory)]
    public string LastName { get; set; }

    [Display(Name = Names.PhoneNumber)]
    [Required(ErrorMessage = Messages.PhoneNumberIsMandatory)]
    [RegularExpression(Values.PhoneNumberRegex, ErrorMessage = Messages.PhoneNumberNotValidMessage)]
    public string PhoneNumber { get; set; }

    [Display(Name = Names.ProfileImage)]
    [Required(ErrorMessage = Messages.ProfileImageIsMandatory)]
    public IFormFile ProfileImage { get; set; }

    public string ProfileImageDisplay { get; set; }
}