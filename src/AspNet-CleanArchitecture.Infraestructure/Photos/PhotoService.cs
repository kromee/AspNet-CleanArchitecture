using AspNet_CleanArchitecture.Application.Interfaces;
using AspNet_CleanArchitecture.Application.Photos;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;

namespace AspNet_CleanArchitecture.Infrastructure.Photos;

public class PhotoService : IPhotoService
{
    private readonly Cloudinary _cloudinary;
public PhotoService(IOptions<CloudinarySettings> config){

    var account = new Account(
        config.Value.CloudName,
        config.Value.ApiKey,
        config.Value.ApiSecret
    );

    _cloudinary = new Cloudinary(account);


}


    public async Task<PhotoUploadResult> AddPhoto(IFormFile file)
    {
        if (file.Length>0){
            await using var stream=
             file.OpenReadStream();

           var uploadParams =  new ImageUploadParams{
                File = new FileDescription(file.Name, stream),
                Transformation = new Transformation().Height(500).Height(500).Crop("fill")

             };

          var uploadResult =   await _cloudinary.UploadAsync(uploadParams);
             if (uploadResult.Error is not null){
                throw new Exception(uploadResult.Error.Message);
             } 

             return new PhotoUploadResult{
                PublicId = uploadResult.PublicId.ToString(),
                Url = uploadResult.SecureUrl.ToString ()
             };


        }
            return null!;
        
    }

    public async Task<string> deletePhoto(string PublicId)
    {
        var deleteParams = new DeletionParams(PublicId);
        var result = await _cloudinary.DestroyAsync(deleteParams);
         
         return result.Result == "ok"? result.Result : null!;

    }
}