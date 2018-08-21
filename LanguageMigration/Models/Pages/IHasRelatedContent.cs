using EPiServer.Core;

namespace LanguageMigration.Models.Pages
{
    public interface IHasRelatedContent
    {
        ContentArea RelatedContentArea { get; }
    }
}
