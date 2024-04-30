using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using StyleLink.Models;

namespace StyleLink.Services.Interfaces;

public interface IImageConvertorService
{
    Task<byte[]> ConvertFileFormToByteArrayAsync(IFormFile formFile);
    Task<ICollection<byte[]>> ConvertFileFormsToByteArraysAsync(ICollection<IFormFile> formFiles);

    Task<IFormFile> ConvertByteArrayToFileFormAsync(ImageDto input);

    Task<ICollection<IFormFile>>
         ConvertByteArraysToFileFormsAsync(ICollection<ImageDto> inputs);

    Task<string> ConvertFormFileToImageAsync(IFormFile fileForm);

    Task<List<string>> ConvertFormFilesToImagesAsync(ICollection<IFormFile> fileForms);
}