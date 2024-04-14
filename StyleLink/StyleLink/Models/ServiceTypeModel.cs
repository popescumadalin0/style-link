using Microsoft.EntityFrameworkCore;
using StyleLink.Constants;
using System.ComponentModel.DataAnnotations;

namespace StyleLink.Models;

[PrimaryKey(nameof(Name))]
public class ServiceTypeModel
{
    [Display(Name = Names.ServiceTypeName)]
    [Required(ErrorMessage = Messages.ServiceTypeNameIsMandatory)]
    public string Name { get; set; }
}