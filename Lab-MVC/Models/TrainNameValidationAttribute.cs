using Lab_MVC.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Unity.Attributes;

namespace Lab_MVC.Models
{
    public class TrainNameValidationAttribute: ValidationAttribute
    {        
        /// <summary>
        /// 建構式，傳入可被格式化的訊息
        /// </summary>
        public TrainNameValidationAttribute() : base("{0}Message")
        {
            // 類別繼承 ValidationAttribute            
        }
    
        [Dependency]
        public ITrainRepository TrainRepository { get; set; }

        /// <summary>
        /// 自訂驗證規則
        /// </summary>
        /// <param name="value">要驗證的值</param>
        /// <param name="validationContext">可操作validation的參數</param>
        /// <returns>驗證是否成功</returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // 繼承 ValidationAttribute
            //if (value != null)
            //{
            //    if (TrainRepository.TheNameIsExist(value.ToString()))
            //    {
            //        string errorMessage = base.FormatErrorMessage("火車已存在");

            //        return new ValidationResult(errorMessage);
            //    }
            //}
            //else
            //{
            //    if (TrainRepository.TheNameIsExist(value.ToString()))
            //    {
            //        string errorMessage = base.FormatErrorMessage("火車已存在");

            //        return new ValidationResult(errorMessage);
            //    }
            //}

            return ValidationResult.Success;
        }
    }
}