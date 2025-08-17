using DevFramework.Core.CrossCuttingConcerns.Validation.FluentValidation;
using FluentValidation;
using PostSharp.Aspects;
using PostSharp.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.Aspects.Postsharp.ValidationAspects
{
    [PSerializable]
    public class FluentValidationAspect:OnMethodBoundaryAspect
    {
        public FluentValidationAspect() { }
        Type _validatorType;
        public FluentValidationAspect(Type validatorType)
        {
            _validatorType = validatorType;
        }
        public override void OnEntry(MethodExecutionArgs args)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);   //ProductValidatorü alıoz
            var entityType =  _validatorType.BaseType.GetGenericArguments()[0];     //girilen AbstractValidatorun ilk tipini al AbstractValidator<Product> alioz
            var entities = args.Arguments.Where(t=>t.GetType()==entityType);

            foreach (var entity in entities)
            {
                ValidatorTool.FluentValidate(validator,entity);
            }
        }
    }
}
