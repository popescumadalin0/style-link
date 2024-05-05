using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using StyleLink.Models;
using StyleLink.Services.Interfaces;

namespace StyleLink.Services;

public class ImageConvertorService : IImageConvertorService
{
    public async Task<byte[]> ConvertFileFormToByteArrayAsync(IFormFile formFile)
    {
        if (formFile.Length > 1024 * 1000 || !formFile.ContentType.Contains("image/"))
        {
            throw new Exception("File must be pdf type max 1 MB. Ignored.");
        }

        using var ms = new MemoryStream();

        await formFile.CopyToAsync(ms);

        return ms.ToArray();
    }

    public async Task<ICollection<byte[]>> ConvertFileFormsToByteArraysAsync(ICollection<IFormFile> formFiles)
    {
        var result = new List<byte[]>();
        foreach (var formFile in formFiles)
        {
            var byteArr = await ConvertFileFormToByteArrayAsync(formFile);
            result.Add(byteArr);
        }

        return result;
    }
    public async Task<IFormFile> ConvertByteArrayToFileFormAsync(ImageDto input)
    {
        var stream = new MemoryStream(input.Content);

        IFormFile file = new FormFile(stream, 0, stream.Length, input.Name, input.FileName)
        {
            Headers = new HeaderDictionary(),
            ContentType = "image/jpeg",
        };

        return file;
    }

    public async Task<ICollection<IFormFile>> ConvertByteArraysToFileFormsAsync(ICollection<ImageDto> inputs)
    {
        var result = new List<IFormFile>();
        foreach (var input in inputs)
        {
            var fileForm = await ConvertByteArrayToFileFormAsync(input);
            result.Add(fileForm);
        }

        return result;
    }
    public async Task<string> ConvertFormFileToImageAsync(IFormFile fileForm)
    {
        var byteData = await ConvertFileFormToByteArrayAsync(fileForm);
        var imreBase64Data = Convert.ToBase64String(byteData);
        var imgDataURL = $"data:image/png;base64,{imreBase64Data}";

        return imgDataURL;
    }

    public async Task<List<string>> ConvertFormFilesToImagesAsync(ICollection<IFormFile> fileForms)
    {
        var result = new List<string>();
        foreach (var fileForm in fileForms)
        {
            var fileString = await ConvertFormFileToImageAsync(fileForm);
            result.Add(fileString);
        }

        return result;
    }
}