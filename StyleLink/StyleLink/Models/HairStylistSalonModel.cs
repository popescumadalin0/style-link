using StyleLink.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace StyleLink.Models;

public class HairStylistSalonModel
{
    public string ServiceId { get; set; }

    [Display(Name = Names.Price)]
    [Required(ErrorMessage = Messages.PriceIsMandatory)]
    public int Price { get; set; }

    [Display(Name = Names.Currency)]
    [Required(ErrorMessage = Messages.CurrencyIsMandatory)]
    public string Currency { get; set; }

    [Display(Name = Names.Time)]
    [Required(ErrorMessage = Messages.TimeIsMandatory)]
    public DateTime Time { get; set; }
}