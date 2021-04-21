using System;
using System.Linq;
using IpInfo;
using nVideo.DATA.ControllerModels;
using nVideo.Models;

#nullable enable

namespace nVideo.DATA.Validation
{
    public enum Result
    {
        Success,
        Faliure
    }
    
    public class Either
    {
        public object Object { get; set; }
        public string Error { get; set; }
        public Exception? Exception { get; set; }
        public Result Result { get; set; }

        public Either(object valadate)
        {
            Object = valadate;
        }

        public void Assert(string val, Func<string, bool> predicate, string error)
        {
            if (Result == Result.Faliure)
                return;

            if (val == null || predicate == null) {
                Exception = new ArgumentNullException();
                Result = Result.Faliure;
                return;
            }

            if (!predicate(val))
            {
                Result = Result.Faliure;
                Exception = new Exception(error);
                Error = error;
                return;
            }

            Result = Result.Success;
        }
    }
    
    public static class Validator
    {
        public static Either ValidateProfile(object val)
        {
            if (val is UserProfile model)
            {
                var monad = new Either(model);
                
                monad.Assert(model.Name, 
                    name => name.Length < 20,
                    "Line length exceeded");
                
                monad.Assert(model.LastName, 
                    lastName => lastName.Length < 20,
                    "Line length exceeded");
                
                monad.Assert(model.Age.ToString(), 
                    age => Convert.ToInt32(age) > 1 && Convert.ToInt32(age) < 110,
                    "Incorrect Age");
                
                monad.Assert(model.Phone,
                    phone => phone.All(char.IsDigit) && phone.Length < 20,
                    "Max length 20");
                
                monad.Assert(model.City, 
                    city => city.All(char.IsLetter),
                    "Must contain only letter");

                return monad;
            }
            // val is not profile
            var either = new Either(val)
            {
                Error = "val is not UserProfile",
                Result = Result.Faliure,
                Exception = new ArgumentException("val is not UserProfile")
            };
            
            return either;
        }
        
    }
}