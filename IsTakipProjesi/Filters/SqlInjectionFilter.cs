using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.RegularExpressions;

namespace IsTakipProjesi.Filters
{
    public class SqlInjectionFilter : IActionFilter
    {
        private static readonly string[] SqlInjectionKeywords = new[]
        {
            "SELECT", "INSERT", "DELETE", "UPDATE", "DROP", "EXEC", "UNION", "xp_"
        };

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var request = context.HttpContext.Request;

            if (request.Method == "POST")
            {
                var formValues = request.Form.SelectMany(f => f.Value);
                foreach (var value in formValues)
                {
                    if (ContainsSqlInjection(value))
                    {
                        context.Result = new BadRequestObjectResult("SQL INJECTION DENEMESİ ALGILANGI.");
                        return;
                    }
                }
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // İşlem tamamlandığında yapılacak bir şey yok
        }

        private bool ContainsSqlInjection(string input)
        {
            foreach (var keyword in SqlInjectionKeywords)
            {
                if (Regex.IsMatch(input, @"\b" + keyword + @"\b", RegexOptions.IgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
