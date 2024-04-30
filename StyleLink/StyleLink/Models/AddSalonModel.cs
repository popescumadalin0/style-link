using Microsoft.AspNetCore.Http;
using StyleLink.Constants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StyleLink.Models;

public class AddSalonModel
{
    [Display(Name = Names.SalonName)]
    [Required(ErrorMessage = Messages.LastNameIsMandatory)]
    public string SalonName { get; set; }

    [Display(Name = Names.Address)]
    [Required(ErrorMessage = Messages.AddressIsMandatory)]
    public string Address { get; set; }

    [Display(Name = Names.GoogleMapsAddress)]
    [Required(ErrorMessage = Messages.GoogleMapsAddressIsMandatory)]
    public string GoogleMapsAddress { get; set; }

    [Display(Name = Names.Images)]
    [Required(ErrorMessage = Messages.ImagesAreMandatory)]
    public ICollection<IFormFile> Images { get; set; }

    public ICollection<string> ImagesDisplay { get; set; }

    [Display(Name = Names.ProfileImage)]
    [Required(ErrorMessage = Messages.ProfileImageIsMandatory)]
    public IFormFile ProfileImage { get; set; }

    public string ProfileImageDisplay { get; set; }

    public WorkProgramModel WorkProgram { get; set; }

    public List<string> Hairstylists { get; set; } = new();

    public List<string> Services { get; set; } = new();
}