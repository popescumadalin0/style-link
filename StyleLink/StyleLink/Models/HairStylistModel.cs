using Microsoft.AspNetCore.Http;
using System;

namespace StyleLink.Models;

public class HairStylistModel
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string ProfileImage { get; set; }
}