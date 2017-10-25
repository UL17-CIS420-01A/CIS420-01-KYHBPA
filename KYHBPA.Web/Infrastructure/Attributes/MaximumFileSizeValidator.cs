using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace KYHBPA
{
    public class MaximumFileSizeValidator
        : ValidationAttribute, IClientValidatable
    {
        private string _errorMessage = "{0} can not be larger than {1} MB";

        /// <summary>
        /// Maximum file size in MB
        /// </summary>
        public double MaximumFileSize { get; private set; }

        /// <inheritdoc />
        /// <param name="maximumFileSize">Maximum file size in MB</param>
        public MaximumFileSizeValidator(
            double maximumFileSize)
        {
            MaximumFileSize = maximumFileSize;
        }

        public override bool IsValid(
            object value)
        {
            if (value.IsNull())
            {
                return true;
            }

            if (!IsValidMaximumFileSize((value as HttpPostedFileBase).ContentLength))
            {
                ErrorMessage = string.Format(_errorMessage, "{0}", MaximumFileSize);
                return false;
            }

            return true;
        }

        public override string FormatErrorMessage(
            string name)
        {
            return string.Format(_errorMessage, name, MaximumFileSize);
        }

        public System.Collections.Generic.IEnumerable<ModelClientValidationRule> GetClientValidationRules(
              ModelMetadata metadata
            , ControllerContext context)
        {
            var clientValidationRule = new ModelClientValidationRule()
            {
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
                ValidationType = "maximumfilesize"
            };

            clientValidationRule.ValidationParameters.Add("size", MaximumFileSize);

            return new[] { clientValidationRule };
        }

        private bool IsValidMaximumFileSize(
            int fileSize)
        {
            return (ConvertBytesToMegabytes(fileSize) <= MaximumFileSize);
        }

        private double ConvertBytesToMegabytes(
           int bytes)
        {
            return (bytes / 1024f) / 1024f;
        }
    }
}