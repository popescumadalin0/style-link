using System.ComponentModel;

namespace StyleLink.Enums;

public enum AppointmentStatus
{
    None = 0,

    [Description("Neconfirmat")]
    Pending,

    [Description("Confirmat")]
    Confirmed,

    [Description("Finalizat")]
    Finished
}