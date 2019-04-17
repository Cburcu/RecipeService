using System;

namespace RecipeService.Exceptions
{
    public class ExceptionsCodes : Exception
    {
        public static ExceptionsCodes Succeccful = new ExceptionsCodes(200,"Successful Operation");
        public static ExceptionsCodes BadRequest = new ExceptionsCodes(400, "Wrong JSON Object");
        public static ExceptionsCodes InternalError = new ExceptionsCodes(500, "Internal Error Occurred");
        public static ExceptionsCodes NoContent = new ExceptionsCodes(204, "No Content Found");
        public static ExceptionsCodes Created = new ExceptionsCodes(201, "Recipe created");
        public static ExceptionsCodes DuplicatedContent = new ExceptionsCodes(409, "Recipe Duplicated");

        public string message;
        public int statusCode;

        public ExceptionsCodes(int statusCode, string message)
        {
            this.statusCode = statusCode;
            this.message = message;
        }

    }
}
