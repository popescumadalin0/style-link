using System;

namespace StyleLink.Models;

public class HairStylistModel
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string ProfileImageTest { get; set; }

    public byte[] ProfileImage { get; set; }
}