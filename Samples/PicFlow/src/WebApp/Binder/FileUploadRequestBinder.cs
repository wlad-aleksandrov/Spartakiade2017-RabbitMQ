using System;
using System.Collections.Generic;
using System.Linq;
using FP.Spartakiade2017.PicFlow.WebApp.Models;
using Nancy;
using Nancy.ModelBinding;

namespace FP.Spartakiade2017.PicFlow.WebApp.Binder
{
    public class FileUploadRequestBinder : IModelBinder
    {
        public object Bind(NancyContext context, Type modelType, object instance, BindingConfig configuration,
            params string[] blackList)
        {
            var imageRequest = (instance as ImageRequest) ?? new ImageRequest();

            var form = context.Request.Form;
                        
            imageRequest.File = GetFileByKey(context, "file");
            imageRequest.Message = form.message;
            imageRequest.PostImage = form.postimage == "true";
            imageRequest.EventOverlay = form.eventoverlay.Value;
            if (form.resolutions.HasValue)
            {
                foreach (var item in form.resolutions.Value.ToString().Split(','))
                {
                    imageRequest.Resolutions.Add(Convert.ToInt32(item));
                }
            }

            return imageRequest;
        }

        public bool CanBind(Type modelType)
        {
            return modelType == typeof(ImageRequest);
        }

        private HttpFile GetFileByKey(NancyContext context, string key)
        {
            IEnumerable<HttpFile> files = context.Request.Files;
            return files?.FirstOrDefault(x => x.Key == key);
        }
    }
}
