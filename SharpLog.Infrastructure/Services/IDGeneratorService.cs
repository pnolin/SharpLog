using Fare;
using SharpLog.Core.Interfaces;

namespace SharpLog.Infrastructure.Services
{
    public class IDGeneratorService : IIDGeneratorService
    {
        public string GenerateId(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                var pattern = new Xeger("^[0-9a-fA-F]{24}$");
                return pattern.Generate();
            }

            return id;
        }
    }
}