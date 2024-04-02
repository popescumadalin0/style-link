using System;

namespace StyleLink.Models;

public class ServiceModel
{
    public Guid Id { get; set; }

    public string ServiceCategory { get; set; }

    public string ServiceName { get; set; }

    public DateTime MinServiceDuration { get; set; }

    public DateTime MaxServiceDuration { get; set; }

    public int MinPrice { get; set; }

    public int MaxPrice { get; set; }

    public string Currency { get; set; }

}