using Benefits.Shared.Configuration;
using Benefits.Shared.Interfaces;
using Microsoft.Extensions.Options;

namespace Benefits.Shared
{
    public class UIHelpers : IUIHelpers
    {
        private readonly Constants _constants;

        public UIHelpers(IOptions<Constants> constants)
        {
            _constants = constants.Value;
        }

        public string GetDocLocRenderURL(string objectID)
        {
            if (string.IsNullOrEmpty(objectID))
                return "";

            return (objectID.Contains("/dl/")
                ? objectID
                : $"{_constants.CISApi}/{_constants.CISApiImageEndpoint}/{objectID}");
        }
    }
}