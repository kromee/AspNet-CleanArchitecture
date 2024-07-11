using System.Security.Cryptography.X509Certificates;
using AspNet_CleanArchitecture.Application.Photos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNet_CleanArchitecture.Application.Interfaces;


public interface IPhotoService{
    Task<PhotoUploadResult> AddPhoto (IFormFile file);
    Task<string> deletePhoto (string PublicId);
    
    

}