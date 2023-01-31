using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;

namespace iWarehouse.API.Providers
{
    public class DateTimeModelBinderProvider : ModelBinderProvider
    {
        readonly DateTimeModelBinder binder = new DateTimeModelBinder();

        public override IModelBinder GetBinder(HttpConfiguration configuration, Type modelType)
        {
            if (DateTimeModelBinder.CanBindType(modelType))
            {
         
                return binder;
            
            }

            return null;
        }
    }

    public class DateTimeModelBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            ValidateBindingContext(bindingContext);
            //var modelKindName = ModelNames.CreatePropertyModelName(bindingContext.ModelName, nameof(Device.Kind));
            //var modelTypeValue = bindingContext.ValueProvider.GetValue(modelKindName).FirstValue;

            if (!bindingContext.ValueProvider.ContainsPrefix(bindingContext.ModelName) ||
                !CanBindType(bindingContext.ModelType))
            {
                return false;
            }

            var modelName = bindingContext.ModelName;
            var attemptedValue = bindingContext.ValueProvider
                .GetValue(modelName).AttemptedValue;

            try
            {
                bindingContext.Model = DateTime.ParseExact(attemptedValue, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch (FormatException e)
            {
                bindingContext.ModelState.AddModelError(modelName, e);
            }

            return true;
        }

        private static void ValidateBindingContext(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException("bindingContext");
            }

            if (bindingContext.ModelMetadata == null)
            {
                throw new ArgumentException("ModelMetadata cannot be null", "bindingContext");
            }
        }

        public static bool CanBindType(Type modelType)
        {
            return modelType == typeof(DateTime) || modelType == typeof(DateTime?);
        }
    }
}

