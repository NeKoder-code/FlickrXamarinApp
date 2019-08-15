using System.Threading.Tasks;
using Refit;

namespace XFTestApp
{
    interface IFlickrGetPhotos
    {
        [Get("/services/rest/?method=flickr.photos.search&api_key={api_key}&min_upload_date={min_upload_date}&format=json&nojsoncallback=1")]
        Task<Photos> GetPhotos(string api_key, string min_upload_date);
    }
}