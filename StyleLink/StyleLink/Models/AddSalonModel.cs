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

    [Display(Name = Names.ProfileImage)]
    [Required(ErrorMessage = Messages.ProfileImageIsMandatory)]
    public string ProfileImageTest { get; set; }

    [Display(Name = Names.Images)]
    [Required(ErrorMessage = Messages.ImagesAreMandatory)]
    public List<string> ImagesTest { get; set; } = new();

    //todo: 
    [Display(Name = Names.ProfileImage)]
    [Required(ErrorMessage = Messages.ProfileImageIsMandatory)]
    public List<byte[]> Images { get; set; } = new();

    [Display(Name = Names.Images)]
    [Required(ErrorMessage = Messages.ImagesAreMandatory)]
    public string ProfileImage { get; set; }

    public WorkProgramModel WorkProgram { get; set; }

    public List<AddHairStylistModel> Hairstylists { get; set; } = new();
}