using StyleLink.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace StyleLink.Models;

public class AddServiceModel
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Display(Name = Names.ServiceName)]
    [Required(ErrorMessage = Messages.ServiceNameIsMandatory)]
    public string Name { get; set; }

    [Display(Name = Names.ServiceTypeName)]
    [Required(ErrorMessage = Messages.ServiceTypeNameIsMandatory)]
    public string ServiceType { get; set; }
}