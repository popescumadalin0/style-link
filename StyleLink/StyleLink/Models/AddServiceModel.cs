using StyleLink.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StyleLink.Models;

public class AddServiceModel
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Display(Name = Names.ServiceName)]
    [Required(ErrorMessage = Messages.ServiceNameIsMandatory)]
    public string Name { get; set; }

    [Display(Name = Names.Price)]
    [Required(ErrorMessage = Messages.PriceIsMandatory)]
    public int Price { get; set; }

    [Display(Name = Names.Currency)]
    [Required(ErrorMessage = Messages.CurrencyIsMandatory)]
    public string Currency { get; set; }

    [Display(Name = Names.Time)]
    [Required(ErrorMessage = Messages.TimeIsMandatory)]
    public DateTime Time { get; set; }

    public ServiceTypeModel ServiceType { get; set; }
}