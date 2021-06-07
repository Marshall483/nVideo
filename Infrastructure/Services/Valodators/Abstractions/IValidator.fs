namespace Validators.Abstractions

type IValidator<'TValidatee> =  
    abstract member Validate: 'TValidtee -> Option<'TValidtee>

