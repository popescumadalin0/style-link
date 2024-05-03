using StyleLink.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace StyleLink.Models;

public class HairStylistSalonModel
{
    public string ServiceId { get; set; }

    [Display(Name = Names.ServiceUsed)]
    [Required]
    public bool IsUsed { get; set; }

    [Display(Name = Names.Price)]
    [Required(ErrorMessage = Messages.PriceIsMandatory)]
    public int Price { get; set; }

    [Display(Name = Names.Currency)]
    [Required(ErrorMessage = Messages.CurrencyIsMandatory)]
    public string Currency { get; set; }

    [Display(Name = Names.Time)]
    [Required(ErrorMessage = Messages.TimeIsMandatory)]
    [DataType(DataType.Time)]
    public TimeOnly Time { get; set; }
}