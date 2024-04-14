using StyleLink.Constants;
using System.ComponentModel.DataAnnotations;

namespace StyleLink.Models;

public class WorkProgramModel
{
    [Display(Name = Names.Monday)]
    [Required(ErrorMessage = Messages.MondayProgramIsMandatory)]
    public string Monday { get; set; }

    [Display(Name = Names.Tuesday)]
    [Required(ErrorMessage = Messages.TuesdayProgramIsMandatory)]
    public string Tuesday { get; set; }

    [Display(Name = Names.Wednesday)]
    [Required(ErrorMessage = Messages.WednesdayProgramIsMandatory)]
    public string Wednesday { get; set; }

    [Display(Name = Names.Thursday)]
    [Required(ErrorMessage = Messages.ThursdayProgramIsMandatory)]
    public string Thursday { get; set; }

    [Display(Name = Names.Friday)]
    [Required(ErrorMessage = Messages.FridayProgramIsMandatory)]
    public string Friday { get; set; }

    [Display(Name = Names.Saturday)]
    [Required(ErrorMessage = Messages.SaturdayProgramIsMandatory)]
    public string Saturday { get; set; }

    [Display(Name = Names.Sunday)]
    [Required(ErrorMessage = Messages.SundayProgramIsMandatory)]
    public string Sunday { get; set; }
}