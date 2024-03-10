using System.ComponentModel;

namespace StyleLink.Enums;

public enum AppointmentStatus
{
    None = 0,

    [Description("Confirmat")]
    Confirmed,

    [Description("Finalizat")]
    Finished
}