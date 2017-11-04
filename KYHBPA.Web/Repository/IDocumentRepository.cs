using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KYHBPA.Repository
{
    public interface IDocumentRepository : IRepository<Document, Guid>
    {
        ICollection<Document> FindDocuments();
        Task<ICollection<Document>> FindDocumentsAsync();

        ICollection<Guid> FindDocumentIds();
        Task<ICollection<Guid>> FindDocumentIdsAsync();

        ICollection<Guid> FindDocumentListIds();
        Task<ICollection<Guid>> FindDocumentListIdsAsync();

        ICollection<Guid> FindDeletedDocumentIds();
        Task<ICollection<Guid>> FindDeletedDocumentIdsAsync();

        ICollection<Document> FindDeletedDocuments();
        Task<ICollection<Document>> FindDeletedDocumentsAsync();

        Document FindDocumentByKey(string key);
        Task<Document> FindDocumentByKeyAsync(string key);

        Guid FindDocumentIdByKey(string key);
        Task<Guid> FindDocumentIdByKeyAsync(string key);

        DocumentCollection FindDocumentsByKey(string key);
        Task<DocumentCollection> FindDocumentsByKeyAsync(string key);

        ICollection<Guid> FindDocumentIdsByKey(string key);
        Task<ICollection<Guid>> FindDocumentIdsByKeyAsync(string key);

        ICollection<string> FindCollectionKeys();
        Task<ICollection<string>> FindCollectionKeysAsync();

        ICollection<string> FindAvailableCollectionKeys();
        Task<ICollection<string>> FindAvailableCollectionKeysAsync();
    }
}