using System.Collections.Generic;

namespace GameREFACTOR.Data
{
    public class Validator
    {
        public bool IsValid { get; private set; }

        public List<string> ValidationErrors { get; private set; }
        
        public Validator()
        {
            IsValid = true;
            ValidationErrors = new List<string>();
        }

        public void Invalidate(string reason)
        {
            ValidationErrors.Add(reason);
            IsValid = false;
        }
    }
    
    public static class ValidatorExtensions {
        public static bool Validate (this object target) {
            var validator = new Validator();
            var eventName = Notification.Validate(target.GetType());
            Global.Events.Publish(eventName, validator, target);
            return validator.IsValid;
        }
    }
}